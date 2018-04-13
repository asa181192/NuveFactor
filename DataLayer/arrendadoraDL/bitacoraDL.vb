Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data.Linq.SqlClient
Imports Entidades
Imports Entidades.arrendadora

Namespace arrendadoraDL

  Public Class bitacoraDL
    Inherits ConnClassDL

    Const sInsertQry As String = "INSERT INTO dbo.bitacora (usuario, maquina, fecha, accion, folio, corte, llave, void) " & _
                                 "VALUES (@usuario, @maquina, @fecha, @accion, @folio, @corte, @llave, @void);"

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      MyBase.New()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="scnn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal scnn As String)
      MyBase.New(scnn)
    End Sub

    Public Function Selectbitacora(ByVal usuario As String, ByVal fecini As Date, ByVal fecfin As Date) As List(Of bitacora)
      Dim obitacoralst As List(Of bitacora) = Nothing
      Try
        MyBase.Start_context()
        Dim ovar = From b As bitacora In context.bitacoras
                   Where b.usuario = usuario AndAlso b.fecha >= fecini AndAlso b.fecha <= fecfin
                   Select b

        If ovar.Count > 0 Then
          obitacoralst = ovar.ToList()
        Else
          obitacoralst = New List(Of bitacora)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        obitacoralst = New List(Of bitacora)
      End Try
      Return obitacoralst
    End Function

    Public Function Selectbitacora(ByVal fecini As Date, ByVal fecfin As Date) As List(Of bitacora)
      Dim obitacoralst As List(Of bitacora) = Nothing
      Try
        MyBase.Start_context()
        Dim ovar = From b As bitacora In context.bitacoras
                   Where b.fecha >= fecini AndAlso b.fecha <= fecfin
                   Select b

        If ovar.Count > 0 Then
          obitacoralst = ovar.ToList()
        Else
          obitacoralst = New List(Of bitacora)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        obitacoralst = New List(Of bitacora)
      End Try
      Return obitacoralst
    End Function

    Public Function Selectbitacorafolio(ByVal folio As String) As bitacora
      Dim oBitacora As bitacora = Nothing
      Try
        MyBase.Start_context()
        Dim ovar = From b As bitacora In context.bitacoras
                   Where b.folio = folio AndAlso SqlMethods.Like(b.accion, "%Reimpreso: 01%")
                   Select b

        If (ovar.Count() > 0) Then
          oBitacora = ovar.Take(1).Single()
        Else
          oBitacora = New bitacora()
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oBitacora = New bitacora()
      End Try
      Return oBitacora
    End Function

    Public Function Selectbitacorascortecajero(ByVal usuario As String) As List(Of bitacora)
      Dim obitacoraslst As List(Of bitacora) = Nothing
      Try
        Dim llaves = {"COB", "HIS"}
        MyBase.Start_context()
        Dim oVar = From b As bitacora In context.bitacoras
                   Where b.usuario = usuario AndAlso b.folio <> "" AndAlso b.corte <= New Date(1900, 1, 1, 0, 0, 0) AndAlso llaves.Contains(b.llave) AndAlso b.accion.Contains(":") AndAlso Not b.folio = "0"
                   Select b

        If oVar.Count > 0 Then
          obitacoraslst = oVar.ToList
        Else
          obitacoraslst = New List(Of bitacora)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        obitacoraslst = New List(Of bitacora)
      End Try
      Return obitacoraslst
    End Function

    Public Function Submit(ByRef bitacora As bitacora) As Boolean
      Dim ret As Boolean = False
      Try
        MyBase.Start_context()
        Dim susuario = bitacora.usuario
        Dim smaquina = bitacora.maquina
        Dim dfecha = bitacora.fecha
        Dim obitacora = From b As bitacora In context.bitacoras
                        Where b.usuario = susuario And b.maquina = smaquina And b.fecha = dfecha
                        Select b

        If obitacora.Count() > 0 Then
          For Each prop In bitacora.GetType.GetProperties.ToList
            prop.SetValue(obitacora.Single(), prop.GetValue(bitacora))
          Next
          context.SaveChanges()
          ret = True
        Else
          context.bitacoras.Add(bitacora)
          context.SaveChanges()
          ret = True
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        ret = False
      End Try
      Return ret
    End Function

    Public Function Submit(ByRef bitacoras As List(Of bitacora)) As Boolean
      Dim ret As Boolean = False
      Try
        MyBase.Start_context()
        Dim ollave = bitacoras.Select(Function(s) New With {s.usuario, s.maquina, s.fecha}).ToList
        Dim obitacora = From b1 As bitacora In context.bitacoras
                        Where ollave.Contains(New With {b1.usuario, b1.maquina, b1.fecha})
                        Select b1

        If obitacora.Count() > 0 Then
          For Each obita As bitacora In obitacora.ToList()
            Dim ob = bitacoras.Where(Function(w) w.usuario = obita.usuario And w.maquina = obita.maquina And w.fecha = obita.fecha)
            If ob.Count() > 0 Then
              If ob.Count() = 1 Then
                Dim oprops = ob.Single().GetType().GetProperties
                For Each oprop As System.Reflection.PropertyInfo In oprops
                  oprop.SetValue(obita, oprop.GetValue(ob.Single()))
                Next

              Else
                For i As Integer = 0 To ob.ToList().Count - 1
                  Dim olog As bitacora = ob.ToList()(i)
                  Dim oprops = olog.GetType().GetProperties
                  For Each oprop As System.Reflection.PropertyInfo In oprops
                    oprop.SetValue(obita, oprop.GetValue(olog))
                  Next
                Next

              End If
            End If
          Next

          Dim oInsert = bitacoras.Where(Function(w) Not obitacora.Contains(w))

          If oInsert.Count() > 0 Then
            context.bitacoras.AddRange(DirectCast(oInsert.ToList(), IEnumerable(Of bitacora)))
          End If

          context.SaveChanges()
          ret = True
        Else
          context.bitacoras.AddRange(DirectCast(bitacoras, IEnumerable(Of bitacora)))
          context.SaveChanges()
          ret = True
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        ret = False
      End Try
      Return ret
    End Function

    Public Function CreaBitacora(ByVal bitacora As bitacora) As Boolean
      Dim bTrans As Boolean = False
      Dim ocmd As SqlCommand = Nothing
      Try
        MyBase.Start_context()
        ocmd = New SqlCommand()
        ocmd.CommandText = sInsertQry
        ocmd.CommandType = CommandType.Text
        ocmd.Parameters.AddWithValue("@usuario", bitacora.usuario)
        ocmd.Parameters.AddWithValue("@maquina", bitacora.maquina)
        ocmd.Parameters.AddWithValue("@fecha", bitacora.fecha)
        ocmd.Parameters.AddWithValue("@accion", bitacora.accion)
        ocmd.Parameters.AddWithValue("@folio", bitacora.folio)
        ocmd.Parameters.AddWithValue("@corte", bitacora.corte)
        ocmd.Parameters.AddWithValue("@llave", bitacora.llave)
        ocmd.Parameters.AddWithValue("@void", bitacora.void)
        MyBase.ExecuteNonQuery(ocmd)
        If ocmd IsNot Nothing Then ocmd.Dispose()
        If ocmd IsNot Nothing Then ocmd = Nothing
        bTrans = True
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        bTrans = False
      End Try
      Return bTrans
    End Function

  End Class

End Namespace
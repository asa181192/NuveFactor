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
  Public Class persoDL
    Inherits ConnClassDL

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

    Private _oNewpersoOuBx As perso
    Public Property oNewpersoOuBx() As perso
      Get
        Return Me._oNewpersoOuBx
      End Get
      Set(value As perso)
        If Not Me._oNewpersoOuBx Is Nothing Then Me._oNewpersoOuBx = Nothing
        Me._oNewpersoOuBx = New perso()
        For Each prop As System.Reflection.PropertyInfo In value.GetType.GetProperties.ToList()
          prop.SetValue(Me._oNewpersoOuBx, prop.GetValue(value))
        Next
      End Set
    End Property

    Private _oNewpersosOuBx As List(Of perso)
    Public Property oNewpersosOuBx() As List(Of perso)
      Get
        Return Me._oNewpersosOuBx
      End Get
      Set(value As List(Of perso))
        If Not Me._oNewpersosOuBx Is Nothing Then Me._oNewpersosOuBx = Nothing
        Me._oNewpersosOuBx = New List(Of perso)
        For Each pers As perso In value
          Dim p As New perso()
          For Each prop As System.Reflection.PropertyInfo In pers.GetType.GetProperties.ToList()
            prop.SetValue(p, prop.GetValue(pers))
          Next
          Me._oNewpersosOuBx.Add(p)
          p = Nothing
        Next
      End Set
    End Property
    Public WriteOnly Property oNewpersosOuBx_add() As perso
      Set(ByVal value As perso)
        If Me._oNewpersosOuBx Is Nothing Then Me._oNewpersosOuBx = New List(Of perso)
        Me._oNewpersosOuBx.Add(value)
      End Set
    End Property

    Private _oOripersoOuBx As perso
    Public Property oOripersoOuBx() As perso
      Get
        Return Me._oOripersoOuBx
      End Get
      Set(value As perso)
        If Not Me._oOripersoOuBx Is Nothing Then Me._oOripersoOuBx = Nothing
        Me._oOripersoOuBx = New perso()
        For Each prop As System.Reflection.PropertyInfo In value.GetType.GetProperties.ToList()
          prop.SetValue(Me._oOripersoOuBx, prop.GetValue(value))
        Next
      End Set
    End Property

    Private _oOripersosOuBx As List(Of perso)
    Public Property oOripersosOuBx() As List(Of perso)
      Get
        Return Me._oOripersosOuBx
      End Get
      Set(value As List(Of perso))
        If Not Me._oOripersosOuBx Is Nothing Then Me._oOripersosOuBx = Nothing
        Me._oOripersosOuBx = New List(Of perso)
        For Each pers As perso In value
          Dim p As New perso()
          For Each prop As System.Reflection.PropertyInfo In pers.GetType.GetProperties.ToList()
            prop.SetValue(p, prop.GetValue(pers))
          Next
          Me._oOripersosOuBx.Add(p)
          p = Nothing
        Next
      End Set
    End Property

    Public Function Selectperso(ByVal cliente As Integer) As perso
      Dim operso As perso = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From perso As perso In context.persos
                   Where perso.cliente = cliente
                   Select perso

        If (oVar.Count() > 0) Then
          operso = oVar.Single()
        Else
          operso = New perso()
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        operso = New perso()
      End Try
      Return operso
    End Function

    Public Function Selectpersos(ByVal clientes As List(Of Integer)) As List(Of perso)
      Dim opersos As List(Of perso) = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From p As perso In context.persos
                   Where clientes.Contains(p.cliente)
                   Select p

        If oVar.Count > 0 Then
          opersos = oVar.ToList
        Else
          opersos = New List(Of perso)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        opersos = New List(Of perso)
      End Try
      Return opersos
    End Function

    Public Function obteneraccionistas(ByVal cliente As Integer) As List(Of Entidades.arrendadora.personalidad_accionista)
      Dim oAccionistas As List(Of Entidades.arrendadora.personalidad_accionista) = Nothing
      Try
        MyBase.Start_context()
        Dim oAccionistasLst = From per As perso In context.persos
                              Where per.cliente = cliente
                              Select per.accionista

        If oAccionistasLst.Count() > 0 Then
          Dim oPerso_asign = oAccionistasLst.Single().Split(Chr(13)).ToList()

          If oPerso_asign.Count() > 0 Then
            oAccionistas = New List(Of personalidad_accionista)

            For Each sPer_Asign As String In oPerso_asign
              If sPer_Asign.Trim.Length > 0 Then
                If sPer_Asign.Split("|").Count() > 0 Then
                  Dim sclie_porc = sPer_Asign.Split("|").ToList()

                  Dim ncliente As Nullable(Of Integer) = Nothing
                  Dim srfc As String = ""
                  Dim snombre As String = ""
                  Dim nporcentaje As Nullable(Of Decimal) = Nothing

                  If sclie_porc.Count >= 1 Then
                    If sclie_porc.ElementAt(0).Trim.Length > 0 Then
                      ncliente = Convert.ToInt32(sclie_porc.ElementAt(0).Trim)
                      Dim ocliente = context.clientes.Where(Function(w) w.cliente_id = Convert.ToInt32(ncliente)).Single()
                      snombre = ocliente.nombre.Trim
                      srfc = ocliente.rfc.Trim
                      ocliente = Nothing
                    End If
                  End If

                  If sclie_porc.Count >= 2 Then
                    If sclie_porc.ElementAt(1).Trim.Length > 0 Then
                      nporcentaje = Convert.ToDecimal(sclie_porc.ElementAt(1).Trim)
                    End If
                  End If

                  oAccionistas.Add(New personalidad_accionista With {.cliente = ncliente, .rfc = srfc, .nombre = snombre, .porcentaje = nporcentaje})

                End If

              End If

            Next

          End If

        Else
          oAccionistas = New List(Of personalidad_accionista)

        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oAccionistas = New List(Of personalidad_accionista)
      End Try
      Return oAccionistas
    End Function

    Public Function obtenerrepresentantes(ByVal cliente As Integer) As List(Of cliente)
      Dim oclientes As List(Of cliente) = Nothing
      Try
        MyBase.Start_context()
        Dim ovar = From p As perso In context.persos
                   Where p.cliente = cliente
                   Select p

        oclientes = New List(Of cliente)
        If ovar.Count > 0 Then
          Dim operso = ovar.Single()
          If Not String.IsNullOrEmpty(operso.representantes) Then
            Dim clts = operso.representantes.Split(vbCrLf).Where(Function(w) w.Trim.Length > 0).Select(Function(s) Convert.ToInt32(s.Trim)).ToList()
            Dim ovar2 = From c As cliente In context.clientes
                        Where clts.Contains(c.cliente_id)
                        Select c

            If ovar2.Count > 0 Then
              oclientes = ovar2.ToList()
            Else
              oclientes = New List(Of cliente)
            End If
          End If
          operso = Nothing
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oclientes = New List(Of cliente)
      End Try
      Return oclientes
    End Function

    Public Function obteneradministradores(ByVal cliente As Integer) As List(Of cliente)
      Dim oclientes As List(Of cliente) = Nothing
      Try
        MyBase.Start_context()
        Dim ovar = From p As perso In context.persos
                   Where p.cliente = cliente
                   Select p

        oclientes = New List(Of cliente)
        If ovar.Count > 0 Then
          Dim operso = ovar.Single()
          If Not String.IsNullOrEmpty(operso.administradores) Then
            Dim clts = operso.administradores.Split(vbCrLf).Where(Function(w) w.Trim.Length > 0).Select(Function(s) Convert.ToInt32(s.Trim)).ToList()
            Dim ovar2 = From c As cliente In context.clientes
                        Where clts.Contains(c.cliente_id)
                        Select c

            If ovar2.Count > 0 Then
              oclientes = ovar2.ToList()
            Else
              oclientes = New List(Of cliente)
            End If
          End If
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oclientes = New List(Of cliente)
      End Try
      Return oclientes
    End Function

    Public Function Submit(ByRef perso As perso) As Boolean
      Dim bTrans As Boolean = False
      Try
        Dim icliente = perso.cliente
        MyBase.Start_context()

        Dim operso = From o As perso In context.persos
                     Where o.cliente = icliente And o.cliente > 0
                     Select o

        oNewpersoOuBx = perso
        If (operso.Count > 0) Then
          oOripersoOuBx = operso.Single()
          Dim props = perso.GetType().GetProperties()
          For Each prop As System.Reflection.PropertyInfo In props.ToList()
            prop.SetValue(operso.Single(), prop.GetValue(perso))
          Next
          context.SaveChanges()
          bTrans = True
        Else
          context.persos.AddRange(perso)
          context.SaveChanges()
          bTrans = True
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        bTrans = False
      End Try
      Return bTrans
    End Function

    Public Function Submit(ByRef persos As List(Of perso)) As Boolean
      Dim bTrans As Boolean = False

      Try
        MyBase.Start_context()

        Dim oLlaves = persos.Select(Function(s) s.cliente).ToList()

        Dim opersos = From o As perso In context.persos
                      Where oLlaves.Contains(o.cliente) AndAlso o.cliente > 0
                      Select o

        If (opersos.Count() > 0) Then
          If Not Me._oNewpersosOuBx Is Nothing Then Me._oNewpersosOuBx = Nothing
          Me.oOripersosOuBx = opersos.ToList()

          Dim props = persos.ElementAt(0).GetType().GetProperties()
          Dim oInsert As New List(Of perso)

          For Each oUpdate As perso In opersos.ToList()
            Dim operso = persos.Where(Function(w) w.cliente = oUpdate.cliente)
            If operso.Count > 0 Then
              For Each prop As System.Reflection.PropertyInfo In props.ToList()
                prop.SetValue(oUpdate, prop.GetValue(operso.Single()))
              Next
              Me.oNewpersosOuBx_add = operso.Single()
            Else
              oInsert.Add(oUpdate)
            End If
          Next

          If (oInsert.Count() > 0) Then
            For Each operso As perso In oInsert.ToList()
              Me.oNewpersosOuBx_add = operso
            Next
            context.persos.AddRange(DirectCast(oInsert.ToList(), IEnumerable(Of perso)))
          End If

          context.SaveChanges()
          bTrans = True

        Else
          oNewpersosOuBx = persos
          context.persos.AddRange(DirectCast(persos, IEnumerable(Of perso)))
          context.SaveChanges()
          bTrans = True

        End If

      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        bTrans = False
      End Try

      Return bTrans
    End Function

    Public Overloads Function GeneraOutbox(ByVal oficina As Integer, ByVal archivo As String, ByVal tag As String, ByVal llave As String, ByVal changes As String) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Metodos.GeneraOutbox(oficina, archivo, tag, llave, changes)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = ex
        bTrans = False
      End Try
      Return bTrans
    End Function

    Public Overloads Function GeneraOutbox(ByVal oficina As Integer, ByVal archivo As String, ByVal tag As String, ByVal llave As String, ByVal chageslst As List(Of String)) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Metodos.GeneraOutbox(oficina, archivo, tag, llave, chageslst)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = ex
        bTrans = False
      End Try
      Return bTrans
    End Function

  End Class
End Namespace
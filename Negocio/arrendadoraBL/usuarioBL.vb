Imports System
Imports System.Data
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports Negocio.Validaciones
Imports Entidades
Imports Entidades.arrendadora

Namespace arrendadoraBL

  Public Class usuarioBL
    Inherits arrendadora.usuario

    Private Campos As System.Collections.Generic.IEnumerable(Of System.Xml.XmlNode)
    Private sConsLlave As List(Of String) = New List(Of String)({"userid"})
    Private schanges As String
    Private schangeslst As List(Of String)

    Public Property oNewusuarioOuBx As usuario
    Public Property oNewusuariosOuBx As List(Of usuario)
    Public Property oOriusuarioOuBx As usuario
    Public Property oOriusuariosOuBx As List(Of usuario)

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

    Public Property PaqueteValidacion() As List(Of PaqueteValidacion)

    Public Overrides Function SelectFoliobyEmail(ByVal email As String) As List(Of Decimal)
      Return MyBase.SelectFoliobyEmail(email)
    End Function

    Public Overrides Function Selectusuario() As List(Of usuario)
      Return MyBase.Normaliza(MyBase.Selectusuario())
    End Function

    Public Overrides Function Selectusuario(ByVal user As String) As usuario
      Return MyBase.Normaliza(MyBase.Selectusuario(user))
    End Function

    Public Overrides Function Selectusuario(ByVal folio As Integer) As usuario
      Return MyBase.Normaliza(MyBase.Selectusuario(folio))
    End Function

    Public Overrides Function Submit(ByRef usuario As usuario) As Boolean
      Dim bTrans As Boolean = False
      MyBase.Normaliza(usuario)
      bTrans = MyBase.Submit(usuario)
      Me.oNewusuarioOuBx = MyBase.usuarioDL.oNewusuarioOuBx
      Me.oOriusuarioOuBx = MyBase.usuarioDL.oOriusuarioOuBx
      Return bTrans
    End Function

    Public Overrides Function Submit(ByRef usuarios As List(Of usuario)) As Boolean
      Dim bTrans As Boolean = False
      MyBase.Normaliza(usuarios)
      bTrans = MyBase.Submit(usuarios)
      Me.oNewusuariosOuBx = MyBase.usuarioDL.oNewusuariosOuBx
      Me.oOriusuariosOuBx = MyBase.usuarioDL.oOriusuariosOuBx
      Return bTrans
    End Function

    Public Function GeneraOutbox(ByVal oficina As Integer, Optional ByVal campos As String = "") As Boolean
      Dim bTrans As Boolean = False

      Try
        If Not Me.oNewusuarioOuBx Is Nothing Then Me.usuarioDL.oNewusuarioOuBx = Me.oNewusuarioOuBx
        If Not Me.oNewusuariosOuBx Is Nothing Then Me.usuarioDL.oNewusuariosOuBx = Me.oNewusuariosOuBx
        If Not Me.oOriusuarioOuBx Is Nothing Then Me.usuarioDL.oOriusuarioOuBx = Me.oOriusuarioOuBx
        If Not Me.oOriusuariosOuBx Is Nothing Then Me.usuarioDL.oOriusuariosOuBx = Me.oOriusuariosOuBx

        If campos.Trim.Length > 0 Then
          sConsLlave.AddRange(campos.Split(",").ToList.Where(Function(w) Not sConsLlave.Select(Function(s) s.ToLower).ToList.Contains(w.ToLower)).ToList)
        End If

        If Not Me.oNewusuarioOuBx Is Nothing Then
          MyBase.CargaXML(Me.oNewusuarioOuBx.GetType().Name)
          Dim oProps = Me.oNewusuarioOuBx.GetType().GetProperties()
          If Me.oOriusuarioOuBx Is Nothing Then
            schanges = ""
            For Each prop As System.Reflection.PropertyInfo In oProps
              schanges &= MyBase.GenerarOutbox(prop, Me.oNewusuarioOuBx)
            Next
          Else
            schanges = MyBase.ChangesOutbox(Me.oOriusuarioOuBx, Me.oNewusuarioOuBx, sConsLlave)
          End If
          bTrans = MyBase.Outbox(oficina, "USUARIOS", "USERID", "M.USERID", schanges)
          MyBase.LiberaXML()
        End If

        If Not Me.oNewusuariosOuBx Is Nothing Then
          MyBase.CargaXML(Me.oNewusuariosOuBx.ElementAt(0).GetType().Name)
          Dim oProps = Me.oNewusuariosOuBx.ElementAt(0).GetType().GetProperties()
          If Not schangeslst Is Nothing Then schangeslst = Nothing
          schangeslst = New List(Of String)
          If Me.oOriusuariosOuBx Is Nothing Then
            For Each usr As usuario In Me.oNewusuariosOuBx
              schanges = ""
              For Each prop As System.Reflection.PropertyInfo In oProps
                schanges &= MyBase.GenerarOutbox(prop, usr)
              Next
              schangeslst.Add(schanges)
            Next
          Else
            For Each Newusrs As usuario In Me.oNewusuariosOuBx
              Dim oOldusrs = Me.oOriusuariosOuBx.Where(Function(w) w.userid = Newusrs.userid)
              schanges = ""
              If oOldusrs.Count() > 0 Then
                schanges = MyBase.ChangesOutbox(oOldusrs.Single, Newusrs, sConsLlave)
              Else
                For Each prop As System.Reflection.PropertyInfo In oProps
                  schanges &= MyBase.GenerarOutbox(prop, Newusrs)
                Next
              End If
              schangeslst.Add(schanges)
            Next
          End If
          bTrans = MyBase.Outbox(oficina, "USUARIOS", "USERID", "M.USERID", schangeslst)
          MyBase.LiberaXML()
        End If
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        ElseIf ex.Message = "Error negocio" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        bTrans = False
      End Try

      Return bTrans
    End Function

    Public Function Validausuario(ByVal usuario As usuario) As Boolean
      Dim bValida As Boolean = False
      Dim oPaqueteVal As New PaqueteValidacion
      Dim oProps = usuario.GetType().GetProperties()

      With oPaqueteVal
        .Aprovado = True
        .Entidad = usuario
        For Each oProp As System.Reflection.PropertyInfo In oProps
          Dim oComentario As Comentario = Nothing

          Select Case oProp.Name
            Case Is = "folio"
              oComentario = Metodos.ValidaNumero(1, usuario, oProp, False, True, -1, -1)
            Case Is = "userid"
              oComentario = Metodos.ValidaCadena(2, usuario, oProp, False, True, 20)
            Case Is = "nombre"
              oComentario = Metodos.ValidaCadena(3, usuario, oProp, False, True, 50)
            Case Is = "password"
              oComentario = Metodos.ValidaNumero(4, usuario, oProp, False, True, -1, -1)
            Case Is = "activo"
              oComentario = Metodos.ValidaBoleano(5, usuario, oProp, False)
            Case Is = "supervisor"
              oComentario = Metodos.ValidaBoleano(6, usuario, oProp, False)
            Case Is = "trustees"
              oComentario = Metodos.ValidaCadena(7, usuario, oProp, False, True, 2147483647)
            Case Is = "email"
              oComentario = Metodos.ValidaCadena(8, usuario, oProp, False, True, 2147483647)
            Case Is = "lista_pass"
              oComentario = Metodos.ValidaCadena(9, usuario, oProp, False, True, 2147483647)
            Case Is = "fec_pass"
              oComentario = Metodos.ValidaFecha(10, usuario, oProp, False)
            Case Is = "jefe"
              oComentario = Metodos.ValidaCadena(11, usuario, oProp, False, True, 50)
            Case Is = "user_job"
              oComentario = Metodos.ValidaCadena(12, usuario, oProp, False, True, 30)
            Case Is = "acepta"
              oComentario = Metodos.ValidaFecha(13, usuario, oProp, False)
            Case Is = "historia"
              oComentario = Metodos.ValidaCadena(14, usuario, oProp, False, True, 2147483647)
            Case Is = "void"
              oComentario = Metodos.ValidaBoleano(15, usuario, oProp, False)
            Case Is = "oficina"
              oComentario = Metodos.ValidaNumero(16, usuario, oProp, False, True, -1, -1)
            Case Is = "perfil"
              oComentario = Metodos.ValidaCadena(17, usuario, oProp, False, True, 2147483647)
            Case Is = "sign"
              oComentario = Metodos.ValidaCadena(18, usuario, oProp, True, True, 2147483647)
            Case Is = "promotor"
              oComentario = Metodos.ValidaNumero(19, usuario, oProp, True, True, -1, -1)
            Case Is = "fecbaja"
              oComentario = Metodos.ValidaFecha(20, usuario, oProp, True)
            Case Is = "regional"
              oComentario = Metodos.ValidaNumero(21, usuario, oProp, True, True, -1, -1)
            Case Is = "id_regi"
              oComentario = Metodos.ValidaCadena(22, usuario, oProp, True, True, 30)
            Case Is = "ubicacion"
              oComentario = Metodos.ValidaNumero(23, usuario, oProp, True, True, -1, -1)
            Case Is = "oficinas"
              oComentario = Metodos.ValidaCadena(24, usuario, oProp, True, True, 400)
            Case Is = "session"
              oComentario = Metodos.ValidaCadena(25, usuario, oProp, True, True, 2147483647)
            Case Is = "firma"
            Case Is = "token"
              oComentario = Metodos.ValidaCadena(27, usuario, oProp, True, True, 2147483647)
          End Select

          If oComentario Is Nothing Then oComentario = New Negocio.Validaciones.Comentario(0, oProp.PropertyType, oProp, "")

          If oComentario.Comentario.Trim.Length > 0 Then
            oPaqueteVal.Aprovado = False
            If oPaqueteVal.Comentarios Is Nothing Then oPaqueteVal.Comentarios = New List(Of Comentario)
            oPaqueteVal.Comentarios.Add(New Comentario(i:=oComentario.Indice, Tipo:=oComentario.Tipo, Campo:=oComentario.Campo, Cometario:=oComentario.Comentario))
          End If

          oComentario.Dispose()
        Next
      End With

      bValida = oPaqueteVal.Aprovado
      If oPaqueteVal.Comentarios Is Nothing Then oPaqueteVal.Comentarios = New List(Of Comentario)
      If Me.PaqueteValidacion Is Nothing Then Me.PaqueteValidacion = New List(Of PaqueteValidacion)
      Me.PaqueteValidacion.Add(New PaqueteValidacion(Entidad:=oPaqueteVal.Entidad, Aprovado:=oPaqueteVal.Aprovado, Comentarios:=oPaqueteVal.Comentarios))
      oPaqueteVal.Dispose()

      Return bValida
    End Function

    Public Function Validausuarios(ByVal usuarios As List(Of usuario)) As Boolean
      Dim bValida As Boolean = True
      For Each oClass As usuario In usuarios
        bValida = bValida And Me.Validausuario(oClass)
      Next
      Return bValida
    End Function

    Public Overrides Function GetParametrosControl() As List(Of fdu_ParametrosControl_Result)
      Return MyBase.GetParametrosControl
    End Function

    Public Overrides Function GetAvisos_AutorizacionesRechazos(ByVal oficinas As String, ByVal fecha As Date, Optional fecha2 As Nullable(Of Date) = Nothing) As List(Of sp_Avisos_AutorizacionesRechazos_Result)
      Return MyBase.GetAvisos_AutorizacionesRechazos(oficinas, fecha, fecha2)
    End Function

    Public Overrides Function GetNueva_Solicheq(ByVal oficina As Integer) As Nullable(Of Decimal)
      Return MyBase.GetNueva_Solicheq(oficina)
    End Function

    Public Overrides Function GetNueva_Nota(ByVal oficina As Integer) As Nullable(Of Integer)
      Return MyBase.GetNueva_Nota(oficina)
    End Function

  End Class

End Namespace
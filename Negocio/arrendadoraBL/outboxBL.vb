Imports System
Imports System.Data
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports Negocio.Validaciones
Imports Entidades
Imports Entidades.arrendadora

Namespace arrendadoraBL

  Public Class outboxBL    
    Inherits arrendadora.outbox

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

    Public Overrides Function Submit(ByRef outbx As outbox) As Boolean
      MyBase.Normaliza(outbx)
      Return MyBase.Submit(outbx)
    End Function

    Public Overrides Function Submit(ByRef outbxLst As List(Of outbox)) As Boolean
      MyBase.Normaliza(outbxLst)
      Return MyBase.Submit(outbxLst)
    End Function

    Public Function Validaoutbox(ByVal outbox As outbox) As Boolean
      Dim bValida As Boolean = False
      Dim oPaqueteVal As New PaqueteValidacion
      Dim oProps = outbox.GetType().GetProperties()

      With oPaqueteVal
        .Aprovado = True
        .Entidad = outbox
        For Each oProp As System.Reflection.PropertyInfo In oProps
          Dim oComentario As Comentario = Nothing

          Select Case oProp.Name
            Case Is = "office"
              oComentario = Metodos.ValidaNumero(1, outbox, oProp, False, False, -1, -1)
            Case Is = "archivo"
              oComentario = Metodos.ValidaCadena(2, outbox, oProp, True, True, 15)
            Case Is = "tag"
              oComentario = Metodos.ValidaCadena(3, outbox, oProp, False, True, 15)
            Case Is = "llave"
              oComentario = Metodos.ValidaCadena(4, outbox, oProp, False, True, 2147483647)
            Case Is = "changes"
              oComentario = Metodos.ValidaCadena(5, outbox, oProp, False, True, 2147483647)
            Case Is = "fecalta"
              oComentario = Metodos.ValidaFecha(6, outbox, oProp, False)
            Case Is = "fecxfer"
              oComentario = Metodos.ValidaFecha(7, outbox, oProp, False)
            Case Is = "consfile"
              oComentario = Metodos.ValidaCadena(8, outbox, oProp, False, True, 26)
            Case Is = "void"
              oComentario = Metodos.ValidaBoleano(9, outbox, oProp, False)
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

    Public Function Validaoutboxs(ByVal outboxs As List(Of outbox)) As Boolean
      Dim bValida As Boolean = True
      For Each oInst As outbox In outboxs
        bValida = bValida And Me.Validaoutbox(oInst)
      Next
      Return bValida
    End Function

  End Class

End Namespace
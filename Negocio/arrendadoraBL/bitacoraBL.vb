Imports System
Imports System.Data
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports Negocio.Validaciones
Imports Entidades
Imports Entidades.arrendadora

Namespace arrendadoraBL

  Public Class bitacoraBL
    Inherits arrendadora.bitacora

    Private sConsLlave As List(Of String) = New List(Of String)({"usuario", "maquina", "fecha"})

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

    Public Overrides Function Selectbitacora(ByVal usuario As String, ByVal fecini As Date, ByVal fecfin As Date) As List(Of bitacora)
      Return MyBase.Normaliza(MyBase.Selectbitacora(usuario, fecini, fecfin))
    End Function

    Public Overrides Function Selectbitacora(ByVal fecini As Date, ByVal fecfin As Date) As List(Of bitacora)
      Return MyBase.Normaliza(MyBase.Selectbitacora(fecini, fecfin))
    End Function

    Public Overrides Function Selectbitacorafolio(ByVal folio As String) As bitacora
      Return MyBase.Normaliza(MyBase.Selectbitacorafolio(folio))
    End Function

    Public Overrides Function Selectbitacorascortecajero(ByVal usuario As String) As List(Of bitacora)
      Return MyBase.Normaliza(MyBase.Selectbitacorascortecajero(usuario))
    End Function

    Public Overrides Function Submit(ByRef bitacora As bitacora) As Boolean
      MyBase.Normaliza(bitacora)
      Return MyBase.Submit(bitacora)
    End Function

    Public Overrides Function Submit(ByRef bitacoras As List(Of bitacora)) As Boolean
      MyBase.Normaliza(bitacoras)
      Return MyBase.Submit(bitacoras)
    End Function

    Public Overrides Function CreaBitacora(ByVal bitacora As bitacora) As Boolean
      MyBase.Normaliza(bitacora)
      Return MyBase.CreaBitacora(bitacora)
    End Function

    Public Function Validabitacora(ByVal bitacora As bitacora) As Boolean
      Dim bValida As Boolean = False
      Dim oPaqueteVal As New PaqueteValidacion
      Dim oProps = bitacora.GetType().GetProperties()

      With oPaqueteVal
        .Aprovado = True
        .Entidad = bitacora
        For Each oProp As System.Reflection.PropertyInfo In oProps
          Dim oComentario As Comentario = Nothing

          Select Case oProp.Name
            Case Is = "usuario"
              oComentario = Metodos.ValidaCadena(1, bitacora, oProp, False, True, 20)
            Case Is = "maquina"
              oComentario = Metodos.ValidaCadena(2, bitacora, oProp, False, True, 30)
            Case Is = "fecha"
              oComentario = Metodos.ValidaFecha(3, bitacora, oProp, False)
            Case Is = "accion"
              oComentario = Metodos.ValidaCadena(4, bitacora, oProp, False, True, -1)
            Case Is = "folio"
              oComentario = Metodos.ValidaCadena(5, bitacora, oProp, False, True, 10)
            Case Is = "corte"
              oComentario = Metodos.ValidaFecha(6, bitacora, oProp, False)
            Case Is = "llave"
              oComentario = Metodos.ValidaCadena(7, bitacora, oProp, True, True, 3)
            Case Is = "void"
              oComentario = Metodos.ValidaBoleano(8, bitacora, oProp, False)
          End Select

          If oComentario Is Nothing Then oComentario = New Comentario(0, oProp.PropertyType, oProp, "")

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

    Public Function Validabitacoras(ByVal bitacoras As List(Of bitacora)) As Boolean
      Dim bValida As Boolean = True
      For Each bitacora As bitacora In bitacoras
        bValida = bValida And Me.Validabitacora(bitacora)
      Next
      Return bValida
    End Function

  End Class

End Namespace
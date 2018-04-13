Imports System
Imports System.Data
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic

Namespace Validaciones

  Public Class PaqueteValidacion
    Implements IDisposable

    Public Sub New()
      Me.Parametros = ""
      Me.Entidad = Nothing
      Me.Aprovado = False
      Me.Comentarios = Nothing
    End Sub

    Public Sub New(ByVal Entidad As Object, ByVal Aprovado As Boolean, Comentarios As List(Of Comentario))
      Me.Entidad = Entidad
      Me.Aprovado = Aprovado
      Me.Comentarios = Comentarios
    End Sub

    Public Sub New(ByVal parametros As String, ByVal Aprovado As Boolean, Comentarios As List(Of Comentario))
      Me.Parametros = parametros
      Me.Aprovado = Aprovado
      Me.Comentarios = Comentarios
    End Sub

    Public Property Parametros() As String

    Public Property Entidad() As Object

    Public Property Aprovado() As Boolean

    Public Property Comentarios As List(Of Comentario)

#Region "IDisposable Support"
    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          If Not Me.Entidad Is Nothing Then Me.Entidad = Nothing
          If Not Me.Comentarios Is Nothing Then Me.Comentarios = Nothing
        End If
      End If
      Me.disposedValue = True
    End Sub

    Protected Overrides Sub Finalize()
      Dispose(False)
      MyBase.Finalize()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region

  End Class

End Namespace
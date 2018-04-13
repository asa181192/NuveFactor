Imports System
Imports System.Data
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic

Namespace Validaciones

  Public Class Comentario
    Implements IDisposable

    Public Sub New()
      Me.Indice = 0
      Me.Tipo = Nothing
      Me.Campo = Nothing
      Me.Comentario = ""
    End Sub

    Public Sub New(ByVal i As Integer, ByVal Tipo As Type, ByVal Campo As System.Reflection.PropertyInfo, ByVal Cometario As String)
      Me.Indice = i
      Me.Tipo = Tipo
      Me.Campo = Campo
      Me.Comentario = Cometario
    End Sub

    Public Property Indice() As Integer

    Public Property Tipo() As Type

    Public Property Campo() As System.Reflection.PropertyInfo

    Public Property Comentario As String

#Region "IDisposable Support"
    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          If Not Me.Tipo Is Nothing Then Me.Tipo = Nothing
          If Not Me.Campo Is Nothing Then Me.Campo = Nothing
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
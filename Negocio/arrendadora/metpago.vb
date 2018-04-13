Imports System
Imports System.Data
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports DataLayer
Imports DataLayer.arrendadoraDL
Imports Entidades
Imports Entidades.arrendadora

Namespace arrendadora
  Public MustInherit Class metpago
    Inherits standardization
    Implements IDisposable

    Public Property metpagoDL() As metpagoDL
    Public Property Err() As Exception
    Public Property hayErr() As Boolean

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      Me.hayErr = False
      Me.Err = Nothing
      Me.metpagoDL = New metpagoDL()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="sconn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal sconn As String)
      Me.hayErr = False
      Me.Err = Nothing
      Me.metpagoDL = New metpagoDL(sconn)
    End Sub

    Public Overridable Function Selectmetpago() As List(Of Entidades.arrendadora.metpago)
      Dim ometpagos As List(Of Entidades.arrendadora.metpago) = Nothing
      Try
        ometpagos = Me.metpagoDL.Selectmetpago()
        If Me.metpagoDL.hayErr Then Throw Me.metpagoDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        ometpagos = New List(Of Entidades.arrendadora.metpago)
      End Try
      Return ometpagos
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          If Me.metpagoDL IsNot Nothing Then Me.metpagoDL.Dispose()
          If Me.metpagoDL IsNot Nothing Then Me.metpagoDL = Nothing
          If Me.Err IsNot Nothing Then Me.Err = Nothing
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
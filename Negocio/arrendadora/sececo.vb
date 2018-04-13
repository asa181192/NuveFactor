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
  Public MustInherit Class sececo
    Inherits standardization
    Implements IDisposable

    Public Property sececoDL() As sececoDL
    Public Property Err() As Exception
    Public Property hayErr() As Boolean

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      Me.hayErr = False
      Me.Err = Nothing
      Me.sececoDL = New sececoDL()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="sconn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal sconn As String)
      Me.hayErr = False
      Me.Err = Nothing
      Me.sececoDL = New sececoDL(sconn)
    End Sub

    Public Overridable Function Selectsececo() As List(Of Entidades.arrendadora.sececo)
      Dim oSececo As List(Of Entidades.arrendadora.sececo) = Nothing
      Try
        oSececo = Me.sececoDL.Selectsececo()
        If Me.sececoDL.hayErr Then Throw Me.sececoDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oSececo = New List(Of Entidades.arrendadora.sececo)
      End Try
      Return oSececo
    End Function

    Public Overridable Function Existesececo(ByVal numero As Integer) As Boolean
      Dim bExiste As Boolean = False
      Try
        bExiste = Me.sececoDL.Existesececo(numero)
        If Me.sececoDL.hayErr Then Throw Me.sececoDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        bExiste = False
      End Try
      Return bExiste
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          If Me.sececoDL IsNot Nothing Then Me.sececoDL.Dispose()
          If Me.sececoDL IsNot Nothing Then Me.sececoDL = Nothing
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
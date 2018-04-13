Imports System
Imports System.Data
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports DataLayer
Imports DataLayer.catalogosDL
Imports Entidades
Imports Entidades.catalogos

Namespace catalogos

  Public MustInherit Class ipaddr
    Inherits arrendadora.standardization
    Implements IDisposable

    Public Property ipaddrDL() As ipaddrDL
    Public Property Err() As Exception
    Public Property hayErr() As Boolean

    ''' <summary>
    ''' Catalogos
    ''' </summary>
    ''' <remarks>Catalogos</remarks>
    Public Sub New()
      Me.hayErr = False
      Me.Err = Nothing
      Me.ipaddrDL = New ipaddrDL()
    End Sub

    ''' <summary>
    ''' Catalogos
    ''' </summary>
    ''' <param name="sconn">cnnstr</param>
    ''' <remarks>Catalogos</remarks>
    Public Sub New(ByVal sconn As String)
      Me.hayErr = False
      Me.Err = Nothing
      Me.ipaddrDL = New ipaddrDL(sconn)
    End Sub

    Public Overridable Function Selectipaddr() As List(Of Entidades.catalogos.ipaddr)
      Dim oIpAddress As List(Of Entidades.catalogos.ipaddr) = Nothing
      Try
        oIpAddress = Me.ipaddrDL.Selectipaddr()
        If Me.ipaddrDL.hayErr Then Throw Me.ipaddrDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oIpAddress = New List(Of Entidades.catalogos.ipaddr)
      End Try
      Return oIpAddress
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          If Not Me.ipaddrDL Is Nothing Then Me.ipaddrDL.Dispose()
          Me.ipaddrDL = Nothing
          If Not Me.Err Is Nothing Then Me.Err = Nothing
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
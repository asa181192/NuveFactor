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

  Public MustInherit Class outbox
    Inherits standardization
    Implements IDisposable

    Public Property outboxDL() As outboxDL
    Public Property Err() As Exception
    Public Property hayErr() As Boolean

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      Me.hayErr = False
      Me.Err = Nothing
      Me.outboxDL = New outboxDL()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="sconn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal sconn As String)
      Me.hayErr = False
      Me.Err = Nothing
      Me.outboxDL = New outboxDL(sconn)
    End Sub

    Public Overridable Function Submit(ByRef outbx As Entidades.arrendadora.outbox) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Me.outboxDL.Submit(outbx)
        If Me.outboxDL.hayErr Then Throw Me.outboxDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        bTrans = False
      End Try
      Return bTrans
    End Function

    Public Overridable Function Submit(ByRef outbxLst As List(Of Entidades.arrendadora.outbox)) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Me.outboxDL.Submit(outbxLst)
        If Me.outboxDL.hayErr Then Throw Me.outboxDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        bTrans = False
      End Try
      Return bTrans
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          If Not Me.outboxDL Is Nothing Then Me.outboxDL.Dispose()
          Me.outboxDL = Nothing
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
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
  Public MustInherit Class tipoid
    Inherits standardization
    Implements IDisposable
    Public Property TipoidDL() As tipoidDL
    Public Property Err() As Exception
    Public Property hayErr() As Boolean

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      Me.hayErr = False
      Me.Err = Nothing
      Me.TipoidDL = New TipoidDL()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="sconn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal sconn As String)
      Me.hayErr = False
      Me.Err = Nothing
      Me.TipoidDL = New TipoidDL(sconn)
    End Sub

    Public Overridable Function SelectTipoid() As List(Of Entidades.arrendadora.tipoid)
      Dim oTipoid As List(Of Entidades.arrendadora.tipoid) = Nothing
      Try
        oTipoid = Me.TipoidDL.SelectTipoid()
        If Me.TipoidDL.hayErr Then Throw Me.TipoidDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oTipoid = New List(Of Entidades.arrendadora.tipoid)
      End Try
      Return oTipoid
    End Function

    Public Overridable Function ExisteTipoid(ByVal numero As Integer) As Boolean
      Dim bExiste As Boolean = False
      Try
        bExiste = Me.TipoidDL.ExisteTipoid(numero)
        If Me.TipoidDL.hayErr Then Throw Me.TipoidDL.Err
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
          If Me.TipoidDL IsNot Nothing Then Me.TipoidDL.Dispose()
          If Me.TipoidDL IsNot Nothing Then Me.TipoidDL = Nothing
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
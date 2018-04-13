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

  Public MustInherit Class control
    Inherits standardization
    Implements IDisposable

    Public Property controlDL As controlDL
    Public Property Err() As Exception
    Public Property hayErr() As Boolean

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      Me.hayErr = False
      Me.Err = Nothing
      Me.controlDL = New controlDL()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="sconn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal sconn As String)
      Me.hayErr = False
      Me.Err = Nothing
      Me.controlDL = New controlDL(sconn)
    End Sub

    Public Overridable Function SelectControl() As Entidades.arrendadora.control
      Dim ocontrol As Entidades.arrendadora.control = Nothing
      Try
        ocontrol = Me.controlDL.SelectControl()
        If Me.controlDL.hayErr Then Throw Me.controlDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        ocontrol = New Entidades.arrendadora.control()
        ocontrol.registro = -1
      End Try
      Return ocontrol
    End Function

    Public Overridable Function GetParametros() As List(Of Entidades.arrendadora.fdu_ParametrosControl_Result)
      Dim oParametros As List(Of Entidades.arrendadora.fdu_ParametrosControl_Result) = Nothing
      Try
        oParametros = Me.controlDL.GetParametros()
        If Me.controlDL.hayErr Then Throw Me.controlDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oParametros = New List(Of Entidades.arrendadora.fdu_ParametrosControl_Result)
      End Try
      Return oParametros
    End Function

    Public Overridable Function Submit(ByRef control As Entidades.arrendadora.control) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Me.controlDL.Submit(control)
        If Me.controlDL.hayErr Then Throw Me.controlDL.Err
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

    Public Function Outbox(ByVal oficina As Integer, ByVal archivo As String, ByVal tag As String, ByVal llave As String, ByVal changes As String) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Me.controlDL.GeneraOutbox(oficina, archivo, tag, llave, changes)
        If Me.controlDL.hayErr Then Throw Me.controlDL.Err
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
          If Not Me.controlDL Is Nothing Then Me.controlDL.Dispose()
          If Not Me.controlDL Is Nothing Then Me.controlDL = Nothing
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
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

  Public MustInherit Class usuario
    Inherits standardization
    Implements IDisposable

    Public Property usuarioDL() As usuarioDL
    Public Property Err() As Exception
    Public Property hayErr() As Boolean

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      Me.hayErr = False
      Me.Err = Nothing
      Me.usuarioDL = New usuarioDL()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="sconn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal sconn As String)
      Me.hayErr = False
      Me.Err = Nothing
      Me.usuarioDL = New usuarioDL(sconn)
    End Sub

    Public Overridable Function SelectFoliobyEmail(ByVal email As String) As List(Of Decimal)
      Dim oEmails As List(Of Decimal) = Nothing
      Try
        oEmails = Me.usuarioDL.SelectFoliobyEmail(email)
        If Me.usuarioDL.hayErr Then Throw Me.usuarioDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oEmails = New List(Of Decimal)
      End Try
      Return oEmails
    End Function

    Public Overridable Function Selectusuario() As List(Of Entidades.arrendadora.usuario)
      Dim ousuarios As List(Of Entidades.arrendadora.usuario) = Nothing
      Try
        ousuarios = Me.usuarioDL.Selectusuario()
        If Me.usuarioDL.hayErr Then Throw Me.usuarioDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        ousuarios = New List(Of Entidades.arrendadora.usuario)
      End Try
      Return ousuarios
    End Function

    Public Overridable Function Selectusuario(ByVal user As String) As Entidades.arrendadora.usuario
      Dim ousuario As Entidades.arrendadora.usuario = Nothing
      Try
        ousuario = Me.usuarioDL.Selectusuario(user)
        If Me.usuarioDL.hayErr Then Throw Me.usuarioDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        ousuario = New Entidades.arrendadora.usuario
      End Try
      Return ousuario
    End Function

    Public Overridable Function Selectusuario(ByVal folio As Integer) As Entidades.arrendadora.usuario
      Dim ousuario As Entidades.arrendadora.usuario = Nothing
      Try
        ousuario = Me.usuarioDL.Selectusuario(folio)
        If Me.usuarioDL.hayErr Then Throw Me.usuarioDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        ousuario = New Entidades.arrendadora.usuario
      End Try
      Return ousuario
    End Function

    Public Overridable Function Submit(ByRef usuario As Entidades.arrendadora.usuario) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Me.usuarioDL.Submit(usuario)
        If Me.usuarioDL.hayErr Then Throw Me.usuarioDL.Err
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

    Public Overridable Function Submit(ByRef usuarios As List(Of Entidades.arrendadora.usuario)) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Me.usuarioDL.Submit(usuarios)
        If Me.usuarioDL.hayErr Then Throw Me.usuarioDL.Err
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
        bTrans = Me.usuarioDL.GeneraOutbox(oficina, archivo, tag, llave, changes)
        If Me.usuarioDL.hayErr Then Throw Me.usuarioDL.Err
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

    Public Function Outbox(ByVal oficina As Integer, ByVal archivo As String, ByVal tag As String, ByVal llave As String, ByVal chageslst As List(Of String)) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Me.usuarioDL.GeneraOutbox(oficina, archivo, tag, llave, chageslst)
        If Me.usuarioDL.hayErr Then Throw Me.usuarioDL.Err
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
          If Not Me.usuarioDL Is Nothing Then Me.usuarioDL.Dispose()
          Me.usuarioDL = Nothing
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

    Public Overridable Function GetParametrosControl() As List(Of Entidades.arrendadora.fdu_ParametrosControl_Result)
      Dim oParametros As List(Of Entidades.arrendadora.fdu_ParametrosControl_Result) = Nothing
      Try
        oParametros = Me.usuarioDL.GetParametrosControl
        If Me.usuarioDL.hayErr Then Throw Me.usuarioDL.Err
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

    Public Overridable Function GetAvisos_AutorizacionesRechazos(ByVal oficinas As String, ByVal fecha As Date, Optional fecha2 As Nullable(Of Date) = Nothing) As List(Of Entidades.arrendadora.sp_Avisos_AutorizacionesRechazos_Result)
      Dim oAutorizacionesRechazos As List(Of Entidades.arrendadora.sp_Avisos_AutorizacionesRechazos_Result) = Nothing
      Try
        oAutorizacionesRechazos = Me.usuarioDL.GetAvisos_AutorizacionesRechazos(oficinas, fecha, fecha2)
        If Me.usuarioDL.hayErr Then Throw Me.usuarioDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oAutorizacionesRechazos = New List(Of Entidades.arrendadora.sp_Avisos_AutorizacionesRechazos_Result)
      End Try
      Return oAutorizacionesRechazos
    End Function

    Public Overridable Function GetNueva_Solicheq(ByVal oficina As Integer) As Nullable(Of Decimal)
      Dim Nueva_Solicheq As Nullable(Of Decimal) = Nothing
      Try
        Nueva_Solicheq = Me.usuarioDL.GetNueva_Solicheq(oficina)
        If Me.usuarioDL.hayErr Then Throw Me.usuarioDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        Nueva_Solicheq = Nothing
      End Try
      Return Nueva_Solicheq
    End Function

    Public Overridable Function GetNueva_Nota(ByVal oficina As Integer) As Nullable(Of Integer)
      Dim Nueva_Nota As Nullable(Of Integer) = Nothing
      Try
        Nueva_Nota = Me.usuarioDL.GetNueva_Nota(oficina)
        If Me.usuarioDL.hayErr Then Throw Me.usuarioDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        Nueva_Nota = Nothing
      End Try
      Return Nueva_Nota
    End Function

  End Class

End Namespace
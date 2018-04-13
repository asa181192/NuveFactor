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
  Public MustInherit Class perso
    Inherits standardization
    Implements IDisposable

    Public Property persoDL() As persoDL
    Public Property Err() As Exception
    Public Property hayErr() As Boolean

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      Me.hayErr = False
      Me.Err = Nothing
      Me.persoDL = New persoDL()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="sconn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal sconn As String)
      Me.hayErr = False
      Me.Err = Nothing
      Me.persoDL = New persoDL(sconn)
    End Sub

    Public Overridable Function Selectperso(ByVal cliente As Integer) As Entidades.arrendadora.perso
      Dim oPerso As Entidades.arrendadora.perso = Nothing
      Try
        oPerso = Me.persoDL.Selectperso(cliente)
        If Me.persoDL.hayErr Then Throw Me.persoDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oPerso = New Entidades.arrendadora.perso()
        oPerso.cliente = -1
      End Try
      Return oPerso
    End Function

    Public Overridable Function Selectpersos(ByVal clientes As List(Of Integer)) As List(Of Entidades.arrendadora.perso)
      Dim opersos As List(Of Entidades.arrendadora.perso) = Nothing
      Try
        opersos = Me.persoDL.Selectpersos(clientes)
        If Me.persoDL.hayErr Then Throw Me.persoDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        opersos = New List(Of Entidades.arrendadora.perso)
      End Try
      Return opersos
    End Function

    Public Overridable Function obteneraccionistas(ByVal cliente As Integer) As List(Of Entidades.arrendadora.personalidad_accionista)
      Dim oAccionistas As List(Of Entidades.arrendadora.personalidad_accionista) = Nothing
      Try
        oAccionistas = Me.persoDL.obteneraccionistas(cliente)
        If Me.persoDL.hayErr Then Throw Me.persoDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oAccionistas = New List(Of personalidad_accionista)
      End Try
      Return oAccionistas
    End Function

    Public Overridable Function obtenerrepresentantes(ByVal cliente As Integer) As List(Of Entidades.arrendadora.cliente)
      Dim oclientes As List(Of Entidades.arrendadora.cliente) = Nothing
      Try
        oclientes = Me.persoDL.obtenerrepresentantes(cliente)
        If Me.persoDL.hayErr Then Throw Me.persoDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oclientes = New List(Of Entidades.arrendadora.cliente)
      End Try
      Return oclientes
    End Function

    Public Overridable Function obteneradministradores(ByVal cliente As Integer) As List(Of Entidades.arrendadora.cliente)
      Dim oclientes As List(Of Entidades.arrendadora.cliente) = Nothing
      Try
        oclientes = Me.persoDL.obteneradministradores(cliente)
        If Me.persoDL.hayErr Then Throw Me.persoDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oclientes = New List(Of Entidades.arrendadora.cliente)
      End Try
      Return oclientes
    End Function

    Public Overridable Function Submit(ByRef personalidad As Entidades.arrendadora.perso) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Me.persoDL.Submit(personalidad)
        If Me.persoDL.hayErr Then Throw Me.persoDL.Err
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

    Public Overridable Function Submit(ByRef personalidads As List(Of Entidades.arrendadora.perso)) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Me.persoDL.Submit(personalidads)
        If Me.persoDL.hayErr Then Throw Me.persoDL.Err
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
        bTrans = Me.persoDL.GeneraOutbox(oficina, archivo, tag, llave, changes)
        If Me.persoDL.hayErr Then Throw Me.persoDL.Err
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
        bTrans = Me.persoDL.GeneraOutbox(oficina, archivo, tag, llave, chageslst)
        If Me.persoDL.hayErr Then Throw Me.persoDL.Err
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
          If Me.persoDL IsNot Nothing Then Me.persoDL.Dispose()
          If Me.persoDL IsNot Nothing Then Me.persoDL = Nothing
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
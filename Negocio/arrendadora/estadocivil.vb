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
  Public MustInherit Class estadocivil
    Inherits standardization
    Implements IDisposable

    Public Property estadocivilDL() As estadocivilDL
    Public Property Err() As Exception
    Public Property hayErr() As Boolean

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      Me.hayErr = False
      Me.Err = Nothing
      Me.estadocivilDL = New estadocivilDL()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="sconn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal sconn As String)
      Me.hayErr = False
      Me.Err = Nothing
      Me.estadocivilDL = New estadocivilDL(sconn)
    End Sub

    Public Overridable Function SelectEstadocivil() As List(Of Entidades.arrendadora.estadocivil)
      Dim oEstadocivil As List(Of Entidades.arrendadora.estadocivil) = Nothing
      Try
        oEstadocivil = Me.estadocivilDL.SelectEstadocivil()
        If Me.estadocivilDL.hayErr Then Throw estadocivilDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oEstadocivil = New List(Of Entidades.arrendadora.estadocivil)
      End Try
      Return oEstadocivil
    End Function

    Public Overridable Function ExisteEstadocivil(ByVal numero As Integer) As Boolean
      Dim bExiste As Boolean = False
      Try
        bExiste = Me.EstadocivilDL.ExisteEstadocivil(numero)
        If Me.EstadocivilDL.hayErr Then Throw EstadocivilDL.Err
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
          If Me.estadocivilDL IsNot Nothing Then Me.estadocivilDL.Dispose()
          If Me.estadocivilDL IsNot Nothing Then Me.estadocivilDL = Nothing
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
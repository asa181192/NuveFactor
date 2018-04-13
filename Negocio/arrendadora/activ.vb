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
  Public MustInherit Class activ
    Inherits standardization
    Implements IDisposable

    Public Property activDL() As activDL
    Public Property Err() As Exception
    Public Property hayErr() As Boolean

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      Me.hayErr = False
      Me.Err = Nothing
      Me.activDL = New activDL()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="sconn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal sconn As String)
      Me.hayErr = False
      Me.Err = Nothing
      Me.activDL = New activDL(sconn)
    End Sub

    Public Overridable Function Selectactiv() As List(Of Entidades.arrendadora.activ)
      Dim oAcividad As List(Of Entidades.arrendadora.activ) = Nothing
      Try
        oAcividad = Me.activDL.Selectactiv()
        If Me.activDL.hayErr Then Throw activDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oAcividad = New List(Of Entidades.arrendadora.activ)
      End Try
      Return oAcividad
    End Function

    Public Overridable Function Existeactivi(ByVal clave As Decimal) As Boolean
      Dim bExiste As Boolean = False
      Try
        bExiste = Me.activDL.Existeactivi(clave)
        If Me.activDL.hayErr Then Throw activDL.Err
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
          If Me.activDL IsNot Nothing Then Me.activDL.Dispose()
          If Me.activDL IsNot Nothing Then Me.activDL = Nothing
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
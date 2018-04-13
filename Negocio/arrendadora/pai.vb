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
  Public MustInherit Class pai
    Inherits standardization
    Implements IDisposable

    Public Property paiDL() As paiDL
    Public Property Err() As Exception
    Public Property hayErr() As Boolean

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      Me.hayErr = False
      Me.Err = Nothing
      Me.paiDL = New paiDL()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="sconn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal sconn As String)
      Me.hayErr = False
      Me.Err = Nothing
      Me.paiDL = New paiDL(sconn)
    End Sub

    Public Overridable Function Selectpais() As List(Of Entidades.arrendadora.pai)
      Dim oPai As List(Of Entidades.arrendadora.pai) = Nothing
      Try
        oPai = Me.paiDL.Selectpais()
        If Me.paiDL.hayErr Then Throw Me.paiDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oPai = New List(Of Entidades.arrendadora.pai)
      End Try
      Return oPai
    End Function

    Public Overridable Function Selectpai(ByVal folio As Integer) As Entidades.arrendadora.pai
      Dim opai As Entidades.arrendadora.pai = Nothing
      Try
        opai = Me.paiDL.Selectpai(folio)
        If Me.paiDL.hayErr Then Throw Me.paiDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        opai = New Entidades.arrendadora.pai
      End Try
      Return opai
    End Function

    Public Overridable Function ExistePais(ByVal folio As Integer) As Boolean
      Dim bExiste As Boolean = False
      Try
        bExiste = Me.paiDL.ExistePais(folio)
        If Me.paiDL.hayErr Then Throw Me.paiDL.Err
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
          If Me.paiDL IsNot Nothing Then Me.paiDL.Dispose()
          If Me.paiDL IsNot Nothing Then Me.paiDL = Nothing
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
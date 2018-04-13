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
  Public MustInherit Class subactiv
    Inherits standardization
    Implements IDisposable

    Public Property subactivDL() As subactivDL
    Public Property Err() As Exception
    Public Property hayErr() As Boolean

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      Me.hayErr = False
      Me.Err = Nothing
      Me.subactivDL = New subactivDL()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="sconn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal sconn As String)
      Me.hayErr = False
      Me.Err = Nothing
      Me.subactivDL = New subactivDL(sconn)
    End Sub

    Public Overridable Function Selectsubactiv(ByVal subactiv As Decimal) As Entidades.arrendadora.subactiv
      Dim oSubactiv As Entidades.arrendadora.subactiv = Nothing
      Try
        oSubactiv = Me.subactivDL.Selectsubactiv(subactiv)
        If Me.subactivDL.hayErr Then Throw Me.subactivDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oSubactiv = New Entidades.arrendadora.subactiv()
        oSubactiv.subactiv_id = -1
      End Try
      Return oSubactiv
    End Function

    Public Overridable Function Selectsubactiv() As List(Of Entidades.arrendadora.subactiv)
      Dim oSubactiv As List(Of Entidades.arrendadora.subactiv) = Nothing
      Try
        oSubactiv = Me.subactivDL.Selectsubactiv()
        If Me.subactivDL.hayErr Then Throw Me.subactivDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oSubactiv = New List(Of Entidades.arrendadora.subactiv)
      End Try
      Return oSubactiv
    End Function

    Public Overridable Function Existesubactiv(ByVal subactiv As Decimal) As Boolean
      Dim bExiste As Boolean = False
      Try
        bExiste = Me.subactivDL.Existesubactiv(subactiv)
        If Me.subactivDL.hayErr Then Throw Me.subactivDL.Err
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
          If Me.subactivDL IsNot Nothing Then Me.subactivDL.Dispose()
          If Me.subactivDL IsNot Nothing Then Me.subactivDL = Nothing
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
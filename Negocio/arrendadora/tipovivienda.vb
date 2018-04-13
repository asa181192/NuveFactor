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
  Public MustInherit Class tipovivienda
    Inherits standardization
    Implements IDisposable

    Public Property TipoviviendaDL() As tipoviviendaDL
    Public Property Err() As Exception
    Public Property hayErr() As Boolean

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      Me.hayErr = False
      Me.Err = Nothing
      Me.TipoviviendaDL = New TipoviviendaDL()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="sconn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal sconn As String)
      Me.hayErr = False
      Me.Err = Nothing
      Me.TipoviviendaDL = New TipoviviendaDL(sconn)
    End Sub

    Public Overridable Function SelectTipovivienda() As List(Of Entidades.arrendadora.tipovivienda)
      Dim oTipovivienda As IList(Of Entidades.arrendadora.tipovivienda) = Nothing
      Try
        oTipovivienda = Me.TipoviviendaDL.SelectTipovivienda()
        If Me.TipoviviendaDL.hayErr Then Throw Me.TipoviviendaDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oTipovivienda = New List(Of Entidades.arrendadora.tipovivienda)
      End Try
      Return oTipovivienda
    End Function

    Public Overridable Function ExisteTipovivienda(ByVal numero As Integer) As Boolean
      Dim bExiste As Boolean = False
      Try
        bExiste = Me.TipoviviendaDL.ExisteTipovivienda(numero)
        If Me.TipoviviendaDL.hayErr Then Throw Me.TipoviviendaDL.Err
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
          If Me.TipoviviendaDL IsNot Nothing Then Me.TipoviviendaDL.Dispose()
          If Me.TipoviviendaDL IsNot Nothing Then Me.TipoviviendaDL = Nothing
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
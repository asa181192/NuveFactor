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
  Public MustInherit Class tiposociedad
    Inherits standardization
    Implements IDisposable

    Public Property tiposociedadDL() As tiposociedadDL
    Public Property Err() As Exception
    Public Property hayErr() As Boolean

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      Me.hayErr = False
      Me.Err = Nothing
      Me.tiposociedadDL = New tiposociedadDL()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="sconn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal sconn As String)
      Me.hayErr = False
      Me.Err = Nothing
      Me.tiposociedadDL = New tiposociedadDL(sconn)
    End Sub

    Public Overridable Function Selecttiposociedad(ByVal numero As Integer) As Entidades.arrendadora.tiposociedad
      Dim oTiposociedad As Entidades.arrendadora.tiposociedad = Nothing
      Try
        oTiposociedad = Me.tiposociedadDL.Selecttiposociedad(numero)
        If Me.tiposociedadDL.hayErr Then Throw Me.tiposociedadDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oTiposociedad = New Entidades.arrendadora.tiposociedad
      End Try
      Return oTiposociedad
    End Function

    Public Overridable Function Selecttiposociedad() As List(Of Entidades.arrendadora.tiposociedad)
      Dim oTiposociedad As List(Of Entidades.arrendadora.tiposociedad) = Nothing
      Try
        oTiposociedad = Me.tiposociedadDL.Selecttiposociedad()
        If Me.tiposociedadDL.hayErr Then Throw Me.tiposociedadDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oTiposociedad = New List(Of Entidades.arrendadora.tiposociedad)
      End Try
      Return oTiposociedad
    End Function

    Public Overridable Function Existetiposociedad(ByVal numero As Integer) As Boolean
      Dim bExiste As Boolean = False
      Try
        bExiste = Me.tiposociedadDL.Existetiposociedad(numero)
        If Me.tiposociedadDL.hayErr Then Throw Me.tiposociedadDL.Err
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
          If Me.tiposociedadDL IsNot Nothing Then Me.tiposociedadDL.Dispose()
          If Me.tiposociedadDL IsNot Nothing Then Me.tiposociedadDL = Nothing
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
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

  Public MustInherit Class oficina
    Inherits standardization
    Implements IDisposable

    Public Property oficinaDL() As oficinaDL
    Public Property Err() As Exception
    Public Property hayErr() As Boolean

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      MyBase.New()
      Me.hayErr = False
      Me.Err = Nothing
      Me.oficinaDL = New oficinaDL()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="sconn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal sconn As String)
      MyBase.New()
      Me.hayErr = False
      Me.Err = Nothing
      Me.oficinaDL = New oficinaDL(sconn)
    End Sub

    Public Overridable Function SelectOficina() As List(Of Entidades.arrendadora.oficina)
      Dim ooficinas As List(Of Entidades.arrendadora.oficina) = Nothing
      Try
        ooficinas = Me.oficinaDL.SelectOficina()
        If Me.oficinaDL.hayErr Then Throw Me.oficinaDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        ooficinas = New List(Of Entidades.arrendadora.oficina)
      End Try
      Return ooficinas
    End Function

    Public Overridable Function SelectOficina(ByVal ofi As Decimal) As Entidades.arrendadora.oficina
      Dim ooficina As Entidades.arrendadora.oficina = Nothing
      Try
        ooficina = Me.oficinaDL.SelectOficina(ofi)
        If Me.oficinaDL.hayErr Then Throw Me.oficinaDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        ooficina = New Entidades.arrendadora.oficina()
      End Try
      Return ooficina
    End Function

    Public Overridable Function SelectOficinaxOrigen(ByVal origen As Decimal) As List(Of Entidades.arrendadora.oficina)
      Dim ooficinas As List(Of Entidades.arrendadora.oficina) = Nothing
      Try
        ooficinas = Me.oficinaDL.SelectOficinaxOrigen(origen)
        If Me.oficinaDL.hayErr Then Throw Me.oficinaDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        ooficinas = New List(Of Entidades.arrendadora.oficina)
      End Try
      Return ooficinas
    End Function

    Public Overridable Function Submit(ByRef oficina As Entidades.arrendadora.oficina) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Me.oficinaDL.Submit(oficina)
        If Me.oficinaDL.hayErr Then Throw Me.oficinaDL.Err
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

    Public Overridable Function Submit(ByRef oficinas As List(Of Entidades.arrendadora.oficina)) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Me.oficinaDL.Submit(oficinas)
        If Me.oficinaDL.hayErr Then Throw Me.oficinaDL.Err
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
        bTrans = Me.oficinaDL.GeneraOutbox(oficina, archivo, tag, llave, changes)
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
        bTrans = Me.oficinaDL.GeneraOutbox(oficina, archivo, tag, llave, chageslst)
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
          MyBase.Release()
          If Not Me.oficinaDL Is Nothing Then Me.oficinaDL.Dispose()
          If Not Me.oficinaDL Is Nothing Then Me.oficinaDL = Nothing
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
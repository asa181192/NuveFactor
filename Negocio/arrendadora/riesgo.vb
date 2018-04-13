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
  Public MustInherit Class riesgo
    Inherits standardization
    Implements IDisposable

    Public Property riesgoDL() As riesgoDL
    Public Property Err() As Exception
    Public Property hayErr() As Boolean

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      Me.hayErr = False
      Me.Err = Nothing
      Me.riesgoDL = New riesgoDL()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="sconn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal sconn As String)
      Me.hayErr = False
      Me.Err = Nothing
      Me.riesgoDL = New riesgoDL(sconn)
    End Sub

    Public Overridable Function getSaldoInsolutoRiesgo(ByVal riesgo As Integer) As Decimal
      Dim oSalInSan As Decimal
      Try
        oSalInSan = Me.riesgoDL.getSaldoInsolutoRiesgo(riesgo)
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oSalInSan = 0
      End Try
      Return oSalInSan
    End Function

    Public Overridable Function Selectriesgo() As List(Of Entidades.arrendadora.riesgo)
      Dim oriesgo As List(Of Entidades.arrendadora.riesgo) = Nothing
      Try
        oriesgo = Me.riesgoDL.Selectriesgo()
        If Me.riesgoDL.hayErr Then Throw Me.riesgoDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oriesgo = New List(Of Entidades.arrendadora.riesgo)
      End Try
      Return oriesgo
    End Function

    Public Overridable Function SelectGrupoNombre(ByVal oficinas As String) As List(Of Entidades.arrendadora.GrupoNombre_Result)
      Dim oriesgo As List(Of Entidades.arrendadora.GrupoNombre_Result) = Nothing
      Try
        oriesgo = Me.riesgoDL.SelectGrupoNombre(oficinas)
        If Me.riesgoDL.hayErr Then Throw Me.riesgoDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oriesgo = New List(Of Entidades.arrendadora.GrupoNombre_Result)
      End Try
      Return oriesgo
    End Function

    Public Overridable Function Selectriesgo(ByVal grupo As Decimal) As Entidades.arrendadora.riesgo
      Dim oriesgo As Entidades.arrendadora.riesgo = Nothing
      Try
        oriesgo = Me.riesgoDL.Selectriesgo(grupo)
        If Me.riesgoDL.hayErr Then Throw Me.riesgoDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oriesgo = New Entidades.arrendadora.riesgo
      End Try
      Return oriesgo
    End Function

    Public Overridable Function SelectRiesgoXNombreXGrupo(ByVal grupo As Decimal?, Optional Nombre As String = "{string.value.null}") As List(Of Entidades.arrendadora.riesgo)
      Dim oriesgoLst As List(Of Entidades.arrendadora.riesgo) = Nothing
      Try
        oriesgoLst = Me.riesgoDL.SelectRiesgoXNombreXGrupo(grupo, Nombre)
        If Me.riesgoDL.hayErr Then Throw Me.riesgoDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oriesgoLst = New List(Of Entidades.arrendadora.riesgo)
      End Try
      Return oriesgoLst
    End Function

    Public Overridable Function SelectRiesgoXNombreXGrupoOficina(ByVal grupo As Decimal?, Optional ByVal nombre As String = Nothing, Optional ByVal oficinas As String = Nothing) As List(Of sp_RiesgoBusquedaXNombreXGrupo_Result)
      Dim oriesgoLst As List(Of Entidades.arrendadora.sp_RiesgoBusquedaXNombreXGrupo_Result) = Nothing
      Try
        oriesgoLst = Me.riesgoDL.SelectRiesgoXNombreXGrupoOficina(grupo, nombre, oficinas)
        If Me.riesgoDL.hayErr Then Throw Me.riesgoDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oriesgoLst = New List(Of Entidades.arrendadora.sp_RiesgoBusquedaXNombreXGrupo_Result)
      End Try
      Return oriesgoLst
    End Function

    Public Overridable Function Submit(ByRef riesgo As Entidades.arrendadora.riesgo, ByRef oficina As Integer) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Me.riesgoDL.Submit(riesgo, oficina)
        If Me.riesgoDL.hayErr Then Throw Me.riesgoDL.Err
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

    Public Overridable Function Submit(ByRef riesgos As List(Of Entidades.arrendadora.riesgo), ByRef oficina As Integer) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Me.riesgoDL.Submit(riesgos, oficina)
        If Me.riesgoDL.hayErr Then Throw Me.riesgoDL.Err
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
        bTrans = Me.riesgoDL.GeneraOutbox(oficina, archivo, tag, llave, changes)
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
        bTrans = Me.riesgoDL.GeneraOutbox(oficina, archivo, tag, llave, chageslst)
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
          If Me.riesgoDL IsNot Nothing Then Me.riesgoDL.Dispose()
          If Me.riesgoDL IsNot Nothing Then Me.riesgoDL = Nothing
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
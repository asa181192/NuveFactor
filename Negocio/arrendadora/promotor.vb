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
  Public MustInherit Class promotor
    Inherits standardization
    Implements IDisposable

    Public Property promotorDL() As promotorDL
    Public Property Err() As Exception
    Public Property hayErr() As Boolean

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      Me.hayErr = False
      Me.Err = Nothing
      Me.promotorDL = New promotorDL()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="sconn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal sconn As String)
      Me.hayErr = False
      Me.Err = Nothing
      Me.promotorDL = New promotorDL(sconn)
    End Sub

    Public Overridable Function SelectpromotorRegion(ByVal activo As Boolean?, ByVal oficinas As String, Optional ByVal todos As Boolean = False) As List(Of Entidades.arrendadora.promotorregion_Result)
      Dim promotorregion As List(Of Entidades.arrendadora.promotorregion_Result) = Nothing
      Try
        promotorregion = Me.promotorDL.SelectpromotorRegion(activo, oficinas, todos)
        If Me.promotorDL.hayErr Then Throw Me.promotorDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        promotorregion = New List(Of Entidades.arrendadora.promotorregion_Result)
      End Try
      Return promotorregion
    End Function

    Public Overridable Function Selectpromotores(ByVal activo As Boolean?) As List(Of Entidades.arrendadora.promotor)
      Dim opromotors As List(Of Entidades.arrendadora.promotor) = Nothing
      Try
        opromotors = Me.promotorDL.Selectpromotores(activo)
        If Me.promotorDL.hayErr Then Throw Me.promotorDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        opromotors = New List(Of Entidades.arrendadora.promotor)
      End Try
      Return opromotors
    End Function

    Public Overridable Function Selectpromotor(ByVal promotor As Integer, Optional ByVal oficina As Integer = 0) As Entidades.arrendadora.promotor
      Dim oPromotor As Entidades.arrendadora.promotor = Nothing
      Try
        oPromotor = Me.promotorDL.Selectpromotor(promotor, oficina)
        If Me.promotorDL.hayErr Then Throw Me.promotorDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oPromotor = New Entidades.arrendadora.promotor
        oPromotor.promotor_id = -1
      End Try
      Return oPromotor
    End Function

    Public Overridable Function SelectPromotorbyNombre(ByVal promotor As Decimal?, Optional ByVal nombre As String = Nothing, Optional ByVal oficinas As String = Nothing) As List(Of Entidades.arrendadora.sp_PromotoresBusquedaXNombre_Result)
      Dim oPromotorporNombreResult As List(Of Entidades.arrendadora.sp_PromotoresBusquedaXNombre_Result) = Nothing
      Try
        oPromotorporNombreResult = Me.promotorDL.SelectPromotorbyNombrebyNumero(promotor, nombre, oficinas)
        If Me.promotorDL.hayErr Then Throw Me.promotorDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oPromotorporNombreResult = New List(Of Entidades.arrendadora.sp_PromotoresBusquedaXNombre_Result)
      End Try
      Return oPromotorporNombreResult
    End Function

    Public Overridable Function Selectpromotordetalle(Optional ByVal oficinas As String = "") As List(Of Entidades.arrendadora.sp_PromotoresDetalle_Result)
      Dim opromotordetalle As List(Of Entidades.arrendadora.sp_PromotoresDetalle_Result) = Nothing
      Try
        opromotordetalle = Me.promotorDL.Selectpromotordetalle(oficinas)
        If Me.promotorDL.hayErr Then Throw Me.promotorDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        opromotordetalle = New List(Of Entidades.arrendadora.sp_PromotoresDetalle_Result)
      End Try
      Return opromotordetalle
    End Function

    Public Overridable Function Selectpromotorcontratos(ByVal promotor As Integer) As List(Of Entidades.arrendadora.promotorcontratos_Result)
      Dim oPromotorContratos As List(Of Entidades.arrendadora.promotorcontratos_Result) = Nothing
      Try
        oPromotorContratos = Me.promotorDL.Selectpromotorcontratos(promotor)
        If Me.promotorDL.hayErr Then Throw Me.promotorDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oPromotorContratos = New List(Of Entidades.arrendadora.promotorcontratos_Result)
      End Try
      Return oPromotorContratos
    End Function

    Public Overridable Function Selectpromotorclientes(ByVal promotor As Integer) As List(Of Entidades.arrendadora.promotorclientes_Result)
      Dim oPromotorClientes As List(Of Entidades.arrendadora.promotorclientes_Result) = Nothing
      Try
        oPromotorClientes = Me.promotorDL.Selectpromotorclientes(promotor)
        If Me.promotorDL.hayErr Then Throw Me.promotorDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oPromotorClientes = New List(Of Entidades.arrendadora.promotorclientes_Result)
      End Try
      Return oPromotorClientes
    End Function

    Public Overridable Function GetColocxM(ByVal ano As Integer, ByVal mes As Integer, ByVal oficina As Integer, ByVal modalidad As Integer, Optional ByVal oficinas As String = "1") As List(Of Entidades.arrendadora.sp_rpt_colocxm_Result)
      Dim oColocxm As List(Of Entidades.arrendadora.sp_rpt_colocxm_Result) = Nothing
      Try
        oColocxm = Me.promotorDL.GetColocxM(ano, mes, oficina, modalidad, oficinas)
        If Me.promotorDL.hayErr Then Throw Me.promotorDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oColocxm = New List(Of Entidades.arrendadora.sp_rpt_colocxm_Result)
      End Try
      Return oColocxm
    End Function

    Public Overridable Function ExisteRFC(ByVal RFC As String, Optional ByVal oficinas As String = "") As Boolean
      Dim bExiste As Boolean = False
      Try
        bExiste = Me.promotorDL.ExisteRFC(RFC, oficinas)
        If Me.promotorDL.hayErr Then Throw Me.promotorDL.Err
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

    Public Overridable Function getSaldoInsolutoPromotor(ByVal promotor As Integer, Optional ByVal SumaIvaInsoluto As Boolean = False) As Decimal
      Dim decSaldoInsoluto As Decimal = 0
      Try
        decSaldoInsoluto = Me.promotorDL.getSaldoInsolutoPromotor(promotor, SumaIvaInsoluto)
        If Me.promotorDL.hayErr Then Throw Me.promotorDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        decSaldoInsoluto = 0
      End Try
      Return decSaldoInsoluto
    End Function

    Public Overridable Function SelectPromotorAdeudoClientes(ByVal promotor As Integer) As List(Of Entidades.arrendadora.sp_AdeudoClientesXPromotor_Result)
      Dim oPromotorLst As List(Of Entidades.arrendadora.sp_AdeudoClientesXPromotor_Result) = Nothing
      Try
        oPromotorLst = Me.promotorDL.SelectPromotorAdeudoClientes(promotor)
        If Me.promotorDL.hayErr Then Throw Me.promotorDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oPromotorLst = New List(Of Entidades.arrendadora.sp_AdeudoClientesXPromotor_Result)
      End Try
      Return oPromotorLst

    End Function

    Public Overridable Function Submit(ByRef promotor As Entidades.arrendadora.promotor, ByRef oficina As Integer) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Me.promotorDL.Submit(promotor, oficina)
        If Me.promotorDL.hayErr Then Throw Me.promotorDL.Err
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

    Public Overridable Function Submit(ByRef promotores As List(Of Entidades.arrendadora.promotor), ByRef oficina As Integer) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Me.promotorDL.Submit(promotores, oficina)
        If Me.promotorDL.hayErr Then Throw Me.promotorDL.Err
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
        bTrans = Me.promotorDL.GeneraOutbox(oficina, archivo, tag, llave, changes)
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
        bTrans = Me.promotorDL.GeneraOutbox(oficina, archivo, tag, llave, chageslst)
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
          If Me.promotorDL IsNot Nothing Then Me.promotorDL.Dispose()
          If Me.promotorDL IsNot Nothing Then Me.promotorDL = Nothing
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
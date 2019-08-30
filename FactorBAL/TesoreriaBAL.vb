﻿Imports FactorDAL
Imports FactorEntidades

Public Class TesoreriaBAL

#Region "Cuentas"

    Function consultaBanco(idbanco As Integer, ByRef model As DropDownEntidad) As Result
        Dim banco = New CuentasDAL
        Return banco.consultaBanco(idbanco, model)
    End Function

    Function ConsultaCuentasBAL(cancelado As Boolean, ByRef model As List(Of cuentasEntidad)) As Result
        Dim cuentas = New FactorDAL.CuentasDAL()
        Return cuentas.consultaCuentasBanco(cancelado, model)
    End Function

    Function ConsultaCuentaDetalle(idctaBanco As Integer, ByRef model As cuentasEntidad) As Result
        Dim cuentas = New CuentasDAL()
        Return cuentas.ConsultaCuentaDetalle(idctaBanco, model)
    End Function

    Function altaCuentaBancoBAL(model As cuentas) As Result
        Dim alta = New CuentasDAL()
        Return alta.altaCuentaBanco(model)
    End Function

    Function actualizarBancoBAL(model As cuentas) As Result
        Dim actualiza = New CuentasDAL()
        Return actualiza.actualizarCuentaBanco(model)
    End Function

#End Region

#Region "Movimientos"

    Function ConsultaMovimientosBAL(fecIni As Date, idctabanco As Integer, ByRef model As List(Of MovimientosEntidad)) As Result
        Dim movimientos = New MovimientosDAL
        Return movimientos.consultaMovimientosDAL(fecIni, idctabanco, model)
    End Function

    Function consultaMovimientoDetalleBAL(numrec As Integer, ByRef model As MovimientosEntidad) As Result
        Dim movtos = New MovimientosDAL
        Return movtos.consultaMovimientoDetalleDAL(numrec, model)
    End Function

    Function altaMovimientoBAL(model As MovimientosEntidad) As Result
        Dim movtos = New MovimientosDAL
        Return movtos.altaMovimientosDAL(model)
    End Function

    Function actualizarMovimientoBAL(model As MovimientosEntidad) As Result
        Dim movtos = New MovimientosDAL
        Return movtos.actualizarMovimientosDAL(model)
    End Function

    Function cancelarMovimientoBAL(numrec As Integer) As Result
        Dim movtos = New MovimientosDAL
        Return movtos.cancelarMovtoDAL(numrec)
    End Function

#End Region

#Region "Utilitarios"

    Function consultaContratoBAL(contrato As Integer, ByRef model As MovimientosEntidad) As Result
        Dim contratos = New MovimientosDAL
        Return contratos.consultarClienteDAL(contrato, model)
    End Function

#End Region

#Region "Registro Cuentas Bancarias"

    Function consultaCuentasBancariasBAL(deudor As Integer, identidad As Integer, ByRef model As List(Of ctaproveEntidad)) As Result
        Dim cuentasBancarias = New RegistroCuentasBancariasDAL
        Return cuentasBancarias.ConsultaCuentasBancariasDAL(deudor, identidad, model)
    End Function

    Function consultarCuentaBancariaDetalleBAL(numrec As Integer, ByRef model As ctaproveEntidad) As Object
        Dim ctaprov = New RegistroCuentasBancariasDAL
        Return ctaprov.consultaCuentaBancariaDetalleDAL(numrec, model)
    End Function

    Function altaCuentaBancariaBAL(model As ctaproveEntidad) As Result
        Dim alta = New RegistroCuentasBancariasDAL()
        Return alta.altaCuentasBancariasDAL(model)
    End Function

    Function actualizarCuentaBancariaBAL(model As ctaproveEntidad) As Result
        Dim actualizar = New RegistroCuentasBancariasDAL
        Return actualizar.actualizarCuentaBancariaDAL(model)
    End Function

    Function consultaDeudorBAL(deudor As Integer, identidad As Integer, ByRef model As ctaproveEntidad) As Result
        Dim deudores = New RegistroCuentasBancariasDAL
        Return deudores.consultaDeudorDAL(deudor, identidad, model)
    End Function

#End Region

    Function obtenerSaldosCuentaBAL(idctabanco As Integer, ByRef model As cuentasEntidad) As Result
        Dim cuentas = New MovimientosDAL
        Return cuentas.consultarSaldosDAL(idctabanco, model)
    End Function

    





End Class

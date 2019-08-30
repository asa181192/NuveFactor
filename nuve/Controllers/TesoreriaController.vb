﻿Imports FactorEntidades
Imports Nelibur.ObjectMapper
Imports nuve.TesoreriaModel
Imports FactorBAL
Imports System.Web.Script.Serialization

Namespace nuve
    <CustomAuthorize(Permisos.Acciones.TESORERIA)>
    Public Class TesoreriaController
        Inherits System.Web.Mvc.Controller

#Region "Menu"
        <CustomAuthorize>
        <HttpGet>
        Function Index() As ViewResult

            Dim model As New Helpers.Menu

            model.sMenu = "<div class=""BoxFlex"" id="""" >"
            model.sMenu &= "<div class=""BoxFlexShadow"">"
            model.sMenu &= "<label>Regresar</label>"
            model.sMenu &= "<a href=""../Home/Welcome""> <img src=""../Images/regresar_gris.png""/> </a>"
            model.sMenu &= "</div>"
            model.sMenu &= "</div>"

            model.sMenu &= "<div class=""BoxFlex"" id=""dvflexCuentasBancos"" >"
            model.sMenu &= "<div class=""BoxFlexShadow"">"
            model.sMenu &= "<p>Cuentas</p>"
            'model.sMenu &= "<img src=""../Images/cuentasBancos.png""/> </a>"
            model.sMenu &= "</div>"
            model.sMenu &= "</div>"

            model.sMenu &= "<div class=""BoxFlex"" id=""dvflexmovimientos"" >"
            model.sMenu &= "<div class=""BoxFlexShadow"">"
            model.sMenu &= "<p>Movimientos</p>"
            'model.sMenu &= "<img src=""../Images/cuentasBancos.png""/> </a>"
            model.sMenu &= "</div>"
            model.sMenu &= "</div>"

            model.sMenu &= "<div class=""BoxFlex"" id=""dvflexReporteDepositos"" >"
            model.sMenu &= "<div class=""BoxFlexShadow"">"
            model.sMenu &= "<p>Reporte Depósitos</p>"
            'model.sMenu &= "<img src=""../Images/cuentasBancos.png""/> </a>"
            model.sMenu &= "</div>"
            model.sMenu &= "</div>"

            model.sMenu &= "<div class=""BoxFlex"" id=""dvflexReporteSalidas"" >"
            model.sMenu &= "<div class=""BoxFlexShadow"">"
            model.sMenu &= "<p>Reporte Salidas</p>"
            'model.sMenu &= "<img src=""../Images/cuentasBancos.png""/> </a>"
            model.sMenu &= "</div>"
            model.sMenu &= "</div>"

            Return View(model)
        End Function

        Function CuentasBancos() As ViewResult

            Dim model As New Helpers.Menu

            model.sMenu = "<div class=""BoxFlex"" id="""" >"
            model.sMenu &= "<div class=""BoxFlexShadow"">"
            model.sMenu &= "<label>Regresar</label>"
            model.sMenu &= "<a href=""../Tesoreria/Index""> <img src=""../Images/regresar_gris.png""/> </a>"
            model.sMenu &= "</div>"
            model.sMenu &= "</div>"

            model.sMenu &= "<div class=""BoxFlex"" id=""dvflexBancos"" >"
            model.sMenu &= "<div class=""BoxFlexShadow"">"
            model.sMenu &= "<p>Bancos</p>"

            model.sMenu &= "</div>"
            model.sMenu &= "</div>"

            model.sMenu &= "<div class=""BoxFlex"" id=""dvflexCuentas"" >"
            model.sMenu &= "<div class=""BoxFlexShadow"">"
            model.sMenu &= "<p>Cuentas</p>"

            model.sMenu &= "</div>"
            model.sMenu &= "</div>"

            Return View(model)

        End Function

#End Region

#Region "Views"

        Function cuentas() As ViewResult
            Return View()
        End Function

        Function movimientos() As ViewResult
            Dim model = New MovimientosModels
            model.Cargacontroles()
            Return View(model)
        End Function

        Function obtenerCuentasContables(deudor As Integer, identidad As Integer) As ViewResult
            Dim model As New RegistroCuentasModel
            model.deudor = deudor
            model.identidad = identidad
            Return View(model)
        End Function

#End Region

#Region "Get"

#Region "Cuentas"

    <CustomAuthorize(Permisos.Acciones.TESORERIA_CUENTAS)>
    Public Function ObtenerCuentasBanco(cancelado As Boolean) As ActionResult

      Dim jresult
      Dim resultado
      Dim consulta = New TesoreriaBAL()

      Dim listaCuentas = New List(Of cuentasEntidad)

      resultado = consulta.ConsultaCuentasBAL(cancelado, listaCuentas)

      If resultado.Ok And resultado IsNot Nothing Then
        jresult = Json(New With {Key .Results = listaCuentas}, JsonRequestBehavior.AllowGet)
      Else
        resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
      End If



      Return jresult

    End Function

    <CustomAuthorize(Permisos.Acciones.TESORERIA_CUENTAS)>
    Public Function ObtenerDetalleCuenta(ctaid As Integer) As ActionResult

      Dim model = New TesoreriaModel.CuentasModel
      Dim consulta = New TesoreriaBAL()
      Dim cuenta = New cuentasEntidad

      If ctaid > 0 Then

        Dim resultado = consulta.ConsultaCuentaDetalle(ctaid, cuenta)
        TinyMapper.Bind(Of cuentas, TesoreriaModel.CuentasModel)()
        model = TinyMapper.Map(Of TesoreriaModel.CuentasModel)(cuenta)

      End If

      model.Cargacontroles()


      Return PartialView(model)

    End Function

#End Region

#Region "Movimientos"

    <CustomAuthorize(Permisos.Acciones.TESORERIA_MOVIMIENTOS)>
    Public Function ObtenerDetalleMovimiento(numrec As Integer, folio As Integer, tipo As String, idcta As Integer) As ActionResult

      Dim model = New MovimientosModels
      Dim consulta = New TesoreriaBAL
      Dim movimiento = New MovimientosEntidad
      Dim vista As String = ""

      If numrec > 0 Then
        movimiento.tipo = tipo
        movimiento.folio = folio
        movimiento.numrec = numrec
        Dim resultado = consulta.consultaMovimientoDetalleBAL(numrec, movimiento)
        TinyMapper.Bind(Of MovimientosEntidad, MovimientosModels)()
        model = TinyMapper.Map(Of MovimientosModels)(movimiento)
      Else
        model.concconta = ""
        model.idctabanco = idcta
        model.fecha = Date.Now
        model.tipo = tipo
        model.contrato = 0
        model.entrada = 0
        model.salida = 0
        model.impresiones = 0
        model.ficha = 0


      End If

      Return PartialView(model)


    End Function

    <CustomAuthorize(Permisos.Acciones.TESORERIA_MOVIMIENTOS)>
    Public Function consultaMovimientos(fecIni As String, idcta As Integer) As ActionResult

      Dim jresult = New JsonResult()
      Dim resultado
      Dim consulta = New TesoreriaBAL()
      Dim model = New MovimientosModels
      Dim serial = New JavaScriptSerializer


      Dim listMov = New List(Of MovimientosEntidad)

      resultado = consulta.ConsultaMovimientosBAL(Date.Parse(fecIni), idcta, listMov)

      If resultado.Ok And resultado IsNot Nothing Then
        jresult = Json(New With {Key .Results = listMov}, JsonRequestBehavior.AllowGet)
        jresult.MaxJsonLength = Integer.MaxValue

      Else
        resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)

      End If

      Return jresult

    End Function

    <CustomAuthorize(Permisos.Acciones.TESORERIA_MOVIMIENTOS)>
    Public Function consultaContrato(contrato As Integer) As ActionResult

      Dim model = New MovimientosEntidad
      Dim resultado
      Dim jresult = New JsonResult()
      Dim consulta = New TesoreriaBAL()



      resultado = consulta.consultaContratoBAL(contrato, model)

      If resultado.ok Then
        If model IsNot Nothing Then
          jresult = Json(New With {Key .nombre = model.nombre}, JsonRequestBehavior.AllowGet)
          jresult.MaxJsonLength = Integer.MaxValue
        Else
          resultado.Mensaje = "El contrato no existe, favor de verificar."
          jresult = Json(New With {Key .Mensaje = resultado.Mensaje + resultado.Detalle}, JsonRequestBehavior.AllowGet)

        End If
      Else
        resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!  " + resultado.Detalle}, JsonRequestBehavior.AllowGet)

      End If

      Return jresult
    End Function

    <CustomAuthorize(Permisos.Acciones.TESORERIA_MOVIMIENTOS)>
    Public Function obtenerSaldosCuenta(idctabanco As Integer) As ActionResult
      Dim model = New cuentasEntidad
      Dim resultado
      Dim jresult = New JsonResult()
      Dim consulta = New TesoreriaBAL()

      resultado = consulta.obtenerSaldosCuentaBAL(idctabanco, model)

      If resultado.ok Then
        If model IsNot Nothing Then
          jresult = Json(New With {Key .saldo = model.saldo, .saldoInicial = model.saldoInicial}, JsonRequestBehavior.AllowGet)
          jresult.MaxJsonLength = Integer.MaxValue
        Else
          resultado.Mensaje = "No se localizó la cuenta"
          jresult = Json(New With {Key .Mensaje = resultado.Mensaje + resultado.Detalle}, JsonRequestBehavior.AllowGet)
        End If
      Else
        resultado.Mensaje = "Ocurrió un error al consultar la información"
        jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!  " + resultado.Detalle}, JsonRequestBehavior.AllowGet)
      End If

      Return jresult

    End Function

#End Region

#Region "Registro de cuentas bancarias"

    <CustomAuthorize(Permisos.Acciones.TESORERIA_REGISTROCUENTASFONDEO)>
    Public Function consultaCuentasBancarias(deudor As Integer, identidad As Integer) As ActionResult

      Dim jresult = New JsonResult()
      Dim resultado
      Dim consulta = New TesoreriaBAL()
      Dim model = New RegistroCuentasModel
      Dim serial = New JavaScriptSerializer

      Dim listCuentas = New List(Of ctaproveEntidad)

      resultado = consulta.consultaCuentasBancariasBAL(deudor, identidad, listCuentas)

      If resultado.Ok And resultado IsNot Nothing Then
        jresult = Json(New With {Key .Results = listCuentas}, JsonRequestBehavior.AllowGet)
        jresult.MaxJsonLength = Integer.MaxValue

      Else
        resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)

      End If

      Return jresult


    End Function

    <CustomAuthorize(Permisos.Acciones.TESORERIA_REGISTROCUENTASFONDEO)>
    Public Function consultarCuentaBancariaDetalle(numrec As Integer, id As Integer, identidad As Integer) As ActionResult

      Dim model = New RegistroCuentasModel
      Dim consulta = New TesoreriaBAL
      Dim ctaprov = New ctaproveEntidad

      If numrec > 0 Then

        Dim resultado = consulta.consultarCuentaBancariaDetalleBAL(numrec, ctaprov)
        TinyMapper.Bind(Of ctaproveEntidad, RegistroCuentasModel)()
        model = TinyMapper.Map(Of RegistroCuentasModel)(ctaprov)

      Else
        model.id = id
        model.deudor = id
        model.identidad = identidad
        model.void = 0
        model.updaterec = ""
        model.modifica = False

      End If

      model.CargaControles()

      Return PartialView(model)

    End Function

        Public Function consultaDeudor(deudor As Integer, identidad As Integer) As ActionResult

            Dim model = New ctaproveEntidad
            Dim resultado
            Dim jresult = New JsonResult()
            Dim consulta = New TesoreriaBAL()

            resultado = consulta.consultaDeudorBAL(deudor, identidad, model)

            If resultado.ok And model IsNot Nothing Then
                jresult = Json(New With {Key .nombre = model.nombre}, JsonRequestBehavior.AllowGet)
                jresult.MaxJsonLength = Integer.MaxValue
            Else
                resultado.Mensaje = "Ocurrio un error al consultar la informacion"
                jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!  " + resultado.Detalle}, JsonRequestBehavior.AllowGet)

            End If

            Return jresult
        End Function

#End Region

#End Region

#Region "POST"

#Region "Cuentas"

        <HttpPost>
        <CustomAuthorize(Permisos.Acciones.TESORERIA_ACTUALIZAR)>
        Public Function GuardarCuenta(modelC As CuentasModel) As ActionResult

            Dim resultado
            Dim bs = New TesoreriaBAL()
            TinyMapper.Bind(Of CuentasModel, cuentas)()
            Dim model = TinyMapper.Map(Of cuentas)(modelC)

            If model.idctabanco = 0 Then

                model.fecha = Date.Today

                resultado = bs.altaCuentaBancoBAL(model)
                If resultado.OK And resultado IsNot Nothing Then
                    Utility.Monitor(Session("userid"), "Alta de la cuenta " & model.ctabanco.ToString())
                    resultado.mensaje = "Registro Guardado"
                    resultado.tipo = Enumerador.eTipoTransaccion.eAlta
                End If

            Else

                resultado = bs.actualizarBancoBAL(model)
                If resultado.ok And resultado IsNot Nothing Then
                    Utility.Monitor(Session("userid"), "Actualización de la cuenta " & model.ctabanco.ToString())
                    resultado.Mensaje = "Registro actualizado"
                    resultado.tipo = Enumerador.eTipoTransaccion.eActualizar
                Else
                    resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro {0}" + "tipo de error: {1}", Environment.NewLine, resultado.Detalle)

                End If

            End If

            Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})

        End Function

#End Region

#Region "Movimientos"

        <HttpPost>
        <CustomAuthorize(Permisos.Acciones.TESORERIA_ACTUALIZAR)>
        Public Function GuardarMovimiento(modelM As MovimientosModels) As ActionResult

            Dim resultado
            Dim bs = New TesoreriaBAL()
            TinyMapper.Bind(Of MovimientosModels, MovimientosEntidad)()
            Dim model = TinyMapper.Map(Of MovimientosEntidad)(modelM)

            If modelM.numrec = 0 Then

                model.fecha = Date.Today
                resultado = bs.altaMovimientoBAL(model)
                If resultado.ok And resultado IsNot Nothing Then
                    Utility.Monitor(Session("userid"), model.concepto)
                    resultado.tipo = Enumerador.eTipoTransaccion.eAlta
                    resultado.mensaje = "Movimiento Generado"
                End If

            Else
                resultado = bs.actualizarMovimientoBAL(model)
                If resultado.ok And resultado IsNot Nothing Then
                    Utility.Monitor(Session("userid"), model.concepto)
                    resultado.tipo = Enumerador.eTipoTransaccion.eActualizar
                    resultado.mensaje = "Movimiento Actualizado"
                Else
                    resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro {0}" + "tipo de error: {1}", Environment.NewLine, resultado.Detalle)
                End If
            End If

            Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})

        End Function

        <CustomAuthorize(Permisos.Acciones.TESORERIA_ACTUALIZAR)>
        Public Function CancelarMovimiento(numrec As Integer) As ActionResult

            Dim model = New MovimientosModels
            Dim consulta = New TesoreriaBAL
            Dim movimiento = New MovimientosEntidad

            Dim resultado = consulta.cancelarMovimientoBAL(numrec)
            TinyMapper.Bind(Of MovimientosEntidad, MovimientosModels)()
            model = TinyMapper.Map(Of MovimientosModels)(movimiento)

            If resultado.Ok Then
                Utility.Monitor(Session("userid"), "Cancelación del movimiento " & numrec.ToString())
            End If

            Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})

        End Function

#End Region

#Region "Registro Cuentas bancarias"

        <HttpPost>
        <CustomAuthorize(Permisos.Acciones.TESORERIA_ACTUALIZAR)>
        Public Function GuardarCuentaBancaria(modelR As RegistroCuentasModel) As ActionResult
            Dim resultado
            Dim bs = New TesoreriaBAL()

            TinyMapper.Bind(Of RegistroCuentasModel, ctaproveEntidad)()
            Dim model = TinyMapper.Map(Of ctaproveEntidad)(modelR)

            If model.numrec = 0 Then
                resultado = bs.altaCuentaBancariaBAL(model)
                If resultado IsNot Nothing Then
                    resultado.mensaje = "Cuenta registrada correctamente"
                    Utility.Monitor(Session("userid"), "Registro de cuenta bancaria " & model.cuenta)
                Else
                    resultado.mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro {0}" + "tipo de error: {1}", Environment.NewLine, resultado.Detalle)
                End If
            Else
                resultado = bs.actualizarCuentaBancariaBAL(model)
                If resultado IsNot Nothing Then
                    resultado.mensaje = "Cuenta actualizada correctamente"
                    Utility.Monitor(Session("userid"), "Actualización de cuenta bancaria " & model.cuenta)
                Else
                    resultado.mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro {0}" + "tipo de error: {1}", Environment.NewLine, resultado.Detalle)
                End If
            End If

            Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})

        End Function

#End Region

#End Region

#Region "Validaciones (Remote)"

        Public Function ValidacionClabe(clabe As String, numrec As Integer) As ActionResult

            Dim jresult = New JsonResult()
            Dim resultado
            Dim validaciones = New RepositorioValidacion()
            Dim existe = False


            resultado = validaciones.ValidarCLABE(clabe, existe, numrec)

            If resultado.Ok And resultado IsNot Nothing Then
                If existe Then
                    jresult = Json("La CLABE ya está registrada en otra cuenta.</br>", JsonRequestBehavior.AllowGet)
                Else
                    jresult = Json("true", JsonRequestBehavior.AllowGet)
                End If
            Else
                resultado.Mensaje = "Ocurrio un error al validar la CLABE."
                jresult = Json(resultado.Mensaje, JsonRequestBehavior.AllowGet)
            End If


            Return jresult

        End Function

#End Region

    End Class

End Namespace

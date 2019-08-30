﻿Imports FactorEntidades
Imports Nelibur.ObjectMapper
Imports nuve.Models
Imports Microsoft.Reporting.WebForms
Imports System.Reflection

Namespace nuve
	<CustomAuthorize(Permisos.Acciones.CATALOGOS)>
	Public Class CatalogosController
		Inherits Controller


#Region "Views"	'*****VIEW*****

#Region "Sucursales"
		<HttpGet>
		Function Sucursales() As ViewResult
			Dim model = New ModeloSucursal()
			Return View(model)
		End Function
#End Region

#Region "Paridad Cambiaria"

		<HttpGet>
		Function paridadCambiaria() As ViewResult
			Dim model = New ModeloPar()

			Return View(model)
		End Function

#End Region

#Region "Proveedores"
		<HttpGet>
		Function Proveedores() As ViewResult
			Dim model = New ModeloProveedor()
			model.CargaControles()
			Return View(model)
		End Function

#End Region

#Region "Compradores"
		<HttpGet>
		Function Compradores() As ViewResult
			Dim model = New ModeloComprador()

			model.CargaControles()
			Return View(model)
		End Function
#End Region

#Region "Estados Financieros"

		<HttpGet>
		Function Financieros() As ViewResult
			Dim model = New ModeloFinanciero()

			Return View(model)
		End Function

#End Region

#Region "Clientes"
		<HttpGet>
		Function Clientes() As ViewResult
			Dim model = New ModeloClientes()

			Return View(model)
		End Function
#End Region

#Region "Promotor"
		<HttpGet>
		Function Promotores() As ViewResult
			Dim model = New ModeloPromotor()
			model.CargaControles()

			Return View(model)
		End Function
#End Region

#Region "Control de Riesgo"

		<HttpGet>
		Public Function ControlRiesgo(clienteId As Int32, nombre As String) As ActionResult


			Dim model = New ModeloControlRiesgo()
			model.propCliente = New ModeloClientes()
			model.propCliente.cliente = clienteId
			model.propCliente.nombre = nombre
			Return View(model)

		End Function

#End Region

#Region "Apoderado"
		<HttpGet>
		<CustomAuthorize(Permisos.Acciones.CATALOGOS_CLIENTES)>
		Public Function Apoderado(clienteId As Int32) As ActionResult

			Dim model = New ModeloApoderado()
			model.cliente = clienteId
			Return View(model)

		End Function
#End Region

#Region "Contratos"
		<HttpGet>
		Public Function Contratos(ClienteId As Integer, Nombre As String) As ActionResult

			Dim model = New Contrato_Cliente
			model.Cliente.nombre = Nombre
			model.Contrato.cliente = ClienteId
			Return View(model)
		End Function
#End Region

#Region "Anexo"
    <HttpGet>
    Public Function Anexo(Contrato As Integer, producto As Integer, nombrecte As String) As ActionResult

      Dim model = New ModeloAnexoVM
      model.Anexo.contrato = Contrato
      model.Producto = producto
      model.nombrecte = nombrecte
      Return View(model)
    End Function
#End Region

#Region "Cesion"
        <HttpGet>
        Public Function Cesiones(Contrato As Integer, producto As Integer, clienteNombre As String, cliente As Integer) As ActionResult

            Dim model = New ModeloCesion
            model.contrato = Contrato
            model.producto = producto
            model.clienteNombre = clienteNombre
            model.cliente = cliente
            Return View(model)
        End Function
#End Region

#Region "Menu"

    <HttpGet>
    Function Index() As ActionResult

      Dim model As New Helpers.Menu
      model.sMenu = "<div class=""BoxFlex"" id="""" >"
      model.sMenu &= "<div class=""BoxFlexShadow"">"
      model.sMenu &= "<label>Regresar</label>"
      model.sMenu &= "<a href=""../Home/Welcome""> <img src=""../Images/regresar_gris.png""/> </a>"
      model.sMenu &= "</div>"
      model.sMenu &= "</div>"

      If TryCast(Session("Permisos"), List(Of Integer)).Contains(Permisos.Acciones.CATALOGOS_INDICADORESFINANCIEROS) Then
        model.sMenu &= "<div class=""BoxFlex"" id=""dvflexFinancieros"" >"
        model.sMenu &= "<div class=""BoxFlexShadow"">"
        model.sMenu &= "<p>Indicadores Financieros</p>"
        model.sMenu &= "</div>"
        model.sMenu &= "</div>"
      End If

      If TryCast(Session("Permisos"), List(Of Integer)).Contains(Permisos.Acciones.CATALOGOS_PARIDADCAMBIARIA) Then
        model.sMenu &= "<div class=""BoxFlex"" id=""dvflexParidad"" >"
        model.sMenu &= "<div class=""BoxFlexShadow"">"
        model.sMenu &= "<p>Paridad Cambiaria</p>"
        model.sMenu &= "</div>"
        model.sMenu &= "</div>"
      End If

      If TryCast(Session("Permisos"), List(Of Integer)).Contains(Permisos.Acciones.CATALOGOS_SUCURSALES) Then
        model.sMenu &= "<div class=""BoxFlex"" id=""dvflexSucursales"" >"
        model.sMenu &= "<div class=""BoxFlexShadow"">"
        model.sMenu &= "<p>Sucursales</p>"
        model.sMenu &= "</div>"
        model.sMenu &= "</div>"
      End If

      If TryCast(Session("Permisos"), List(Of Integer)).Contains(Permisos.Acciones.CATALOGOS_CLIENTES) Then
        model.sMenu &= "<div class=""BoxFlex"" id=""dvflexClientes"" >"
        model.sMenu &= "<div class=""BoxFlexShadow"">"
        model.sMenu &= "<p>Clientes</p>"
        model.sMenu &= "</div>"
        model.sMenu &= "</div>"
      End If

      If TryCast(Session("Permisos"), List(Of Integer)).Contains(Permisos.Acciones.CATALOGOS_COMPRADORES) Then
        model.sMenu &= "<div class=""BoxFlex"" id=""dvflexCompradores"" >"
        model.sMenu &= "<div class=""BoxFlexShadow"">"
        model.sMenu &= "<p>Compradores</p>"
        model.sMenu &= "</div>"
        model.sMenu &= "</div>"
      End If

      If TryCast(Session("Permisos"), List(Of Integer)).Contains(Permisos.Acciones.CATALOGOS_PROVEEDORES) Then
        model.sMenu &= "<div class=""BoxFlex"" id=""dvflexProveedores"" >"
        model.sMenu &= "<div class=""BoxFlexShadow"">"
        model.sMenu &= "<p>Proveedores</p>"
        model.sMenu &= "</div>"
        model.sMenu &= "</div>"
      End If

      If TryCast(Session("Permisos"), List(Of Integer)).Contains(Permisos.Acciones.CATALOGOS_PROMOTORES) Then
        model.sMenu &= "<div class=""BoxFlex"" id=""dvflexPromotores"" >"
        model.sMenu &= "<div class=""BoxFlexShadow"">"
        model.sMenu &= "<p>Promotores</p>"
        model.sMenu &= "</div>"
        model.sMenu &= "</div>"
      End If



      Return View(model)
    End Function

#End Region

#Region "Usuarios Web"

    <HttpGet>
    <CustomAuthorize(Permisos.Acciones.PORTAL)>
    Public Function UsuariosWeb(Nombre As String, Clave As Integer, identidad As Integer) As ActionResult

      Dim model = New ModeloUsuarioWeb
      model.nombre = Nombre
      model.Clave = Clave
      model.identidad = identidad

      Return View(model)
    End Function

    <HttpGet>
    <CustomAuthorize(Permisos.Acciones.PORTAL)>
    Public Function WebMonitor(username As String, nombre As String) As ActionResult

      Dim model = New ModeloWebMonitor()
      model.username = username
      model.nombre = nombre.Trim()
      Return PartialView(model)
    End Function

#End Region

#End Region

#Region "Get" '*****GET*****

#Region "Paridad Cambiaria"

    'Obtiene el total de registros
    <HttpGet>
    Public Function obtenerListaParidad(fechaMes As String, fechaAnio As String) As ActionResult

      Dim jresult
      Dim resultado
      Dim consulta = New FactorBAL.Manager()

      Dim listaPardiad = New List(Of ParidadEntidad)

      resultado = consulta.ConsultaParidadBAL(fechaMes, fechaAnio, listaPardiad)

      If resultado.Ok And resultado IsNot Nothing Then
        jresult = Json(New With {Key .Results = listaPardiad}, JsonRequestBehavior.AllowGet)
      Else
        resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
      End If

      Return jresult

    End Function

    'Detalle de la paridad '
    <HttpGet>
    Public Function GuardarParidad(fecha As String) As ActionResult

      Dim model = New ModeloPar
      Dim consulta = New FactorBAL.Manager()
      Dim paridad = New paridad

      Dim resultado = consulta.ConsultaParidadDetalleBAL(fecha, paridad)

      TinyMapper.Bind(Of paridad, ModeloPar)()  'Mapeo de propiedad para modelo.
      model = TinyMapper.Map(Of ModeloPar)(paridad)

      Return PartialView(model)
    End Function

#End Region

#Region "Proveedores"

    <HttpGet()>
    Public Function ObtenerListaProveedores(sucursal As Int16) As ActionResult

      Dim jresult = New JsonResult()
      Dim resultado
      Dim consulta = New FactorBAL.Manager()
      Dim listaProveedor = New List(Of ProveedorEntidad)

      resultado = consulta.ConsultaProveedorBAL(sucursal, listaProveedor)

      If resultado.Ok And resultado IsNot Nothing Then
        jresult = Json(New With {Key .Results = listaProveedor}, JsonRequestBehavior.AllowGet)
        jresult.MaxJsonLength = 500000000
      Else
        resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
      End If

      Return jresult

    End Function

    <HttpGet>
    Public Function GuardarProveedor(deudor As Int32) As ActionResult

      Dim model = New ModeloProveedor()
      Dim consulta = New FactorBAL.Manager()
      Dim proveedor = New proveedor
      Dim resultado = consulta.ConsultaDetalleProveedorBAL(deudor, proveedor)

      If Request.UrlReferrer IsNot Nothing Then
        If Request.UrlReferrer.AbsolutePath.Contains("BusquedaGlobal") Then
          ViewBag.Layout = True
        End If
      End If

      If resultado.Ok And resultado IsNot Nothing Then
        TinyMapper.Bind(Of proveedor, ModeloProveedor)()  'Mapeo de propiedad para modelo.
        model = TinyMapper.Map(Of ModeloProveedor)(proveedor)
        model.CargaControles()

        Return PartialView(model)
      Else
        If resultado.Id_Out = 1 Then
          Return PartialView("~/Views/Shared/_ErrorPopUp.vbhtml")
        Else
          model.CargaControles()
          Return PartialView(model)
        End If
      End If

    End Function

#End Region

#Region "Compradores"
    <HttpGet()>
    Public Function ObtenerListaCompradores(sucursal As Int16) As ActionResult

      Dim jresult = New JsonResult()
      Dim resultado
      Dim consulta = New FactorBAL.Manager()

      Dim listaComprador = New List(Of ProveedorEntidad)

      resultado = consulta.ConsultaCompradorBAL(sucursal, listaComprador)

      If resultado.Ok And resultado IsNot Nothing Then
        jresult = Json(New With {Key .Results = listaComprador}, JsonRequestBehavior.AllowGet)
        jresult.MaxJsonLength = 500000000
      Else
        resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
      End If

      Return jresult

    End Function

    <HttpGet>
    Public Function GuardarComprador(deudor As Int32) As ActionResult

      Dim model = New ModeloComprador()
      Dim consulta = New FactorBAL.Manager()
      Dim comprador = New comprador
      Dim resultado = consulta.ConsultaDetalleCompradorBAL(deudor, comprador)

      If Request.UrlReferrer IsNot Nothing Then
        If Request.UrlReferrer.AbsolutePath.Contains("BusquedaGlobal") Then
          ViewBag.Layout = True
        End If
      End If

      If resultado.Ok And resultado IsNot Nothing Then
        TinyMapper.Bind(Of comprador, ModeloProveedor)()  'Mapeo de propiedad para modelo.
        model = TinyMapper.Map(Of ModeloComprador)(comprador)
        model.CargaControles()

        Return PartialView(model)
      Else
        If resultado.Id_Out = 1 Then
          Return PartialView("~/Views/Shared/_ErrorPopUp.vbhtml")
        Else
          model.CargaControles()
          Return PartialView(model)
        End If
      End If


    End Function
#End Region

#Region "Indicadores Financieros"
    <HttpGet>
    Public Function ObtenerListaFinancieros(fechaMes As String, fechaAnio As String) As ActionResult

      Dim jresult
      Dim resultado
      Dim consulta = New FactorBAL.Manager()

      Dim listaPardiad = New List(Of FinancieroEntidad)

      resultado = consulta.ConsultaIndicadoresBAL(fechaMes, fechaAnio, listaPardiad)

      If resultado.Ok And resultado IsNot Nothing Then
        jresult = Json(New With {Key .Results = listaPardiad}, JsonRequestBehavior.AllowGet)
      Else
        resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
      End If

      Return jresult

    End Function

    <HttpGet>
    Public Function GuardarFinanciero(fecha As String) As ActionResult

      Dim model = New ModeloFinanciero
      Dim consulta = New FactorBAL.Manager()
      Dim indicador = New indicadores

      Dim resultado = consulta.ConsultaIndicadorDetalleBAL(fecha, indicador)

      TinyMapper.Bind(Of indicadores, ModeloFinanciero)() 'Mapeo de propiedad para modelo.
      model = TinyMapper.Map(Of ModeloFinanciero)(indicador)

      Return PartialView(model)
    End Function

#End Region

#Region "Sucursal"
    <HttpGet>
    Public Function ObtenerListaSucursal() As ActionResult

      Dim jresult
      Dim resultado
      Dim consulta = New FactorBAL.Manager()

      Dim listaSucursal = New List(Of SucursalEntidad)

      resultado = consulta.ConsultaSucursalBAL(listaSucursal)

      If resultado.Ok And resultado IsNot Nothing Then
        jresult = Json(New With {Key .Results = listaSucursal}, JsonRequestBehavior.AllowGet)
      Else
        resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
      End If

      Return jresult

    End Function

    <HttpGet>
    Public Function GuardarSucursal(suc As Int32) As ActionResult

      Dim model = New ModeloSucursal()
      Dim consulta = New FactorBAL.Manager()
      Dim sucursal = New sucursal

      Dim resultado = consulta.ConsultaDetalleSucursalBAL(suc, sucursal)

      If resultado.Ok And resultado IsNot Nothing Then
        TinyMapper.Bind(Of sucursal, ModeloSucursal)()  'Mapeo de propiedad para modelo.
        model = TinyMapper.Map(Of ModeloSucursal)(sucursal)

        Return PartialView(model)
      Else
        If resultado.Id_Out = 1 Then
          Return PartialView("~/Views/Shared/_ErrorPopUp.vbhtml")
        Else
          Return PartialView(model)
        End If
      End If


    End Function

#End Region

#Region "Clientes"
    <HttpGet>
    Public Function ObtenerListaClientes() As ActionResult

      Dim jresult
      Dim resultado
      Dim consulta = New FactorBAL.Manager()

      Dim listaTipo = New List(Of ClienteEntidad)

      resultado = consulta.ConsultaClienteBAL(listaTipo)

      If resultado.Ok And resultado IsNot Nothing Then
        jresult = Json(New With {Key .Results = listaTipo}, JsonRequestBehavior.AllowGet)
      Else
        resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
      End If

      Return jresult

    End Function

    <HttpGet>
    Public Function GuardarCliente(clienteId As Int32) As ActionResult

      Dim model = New ModeloClientes()
      Dim consulta = New FactorBAL.Manager()
      Dim cliente = New clientes
      Dim resultado = consulta.ConsultaDetalleClienteBAL(clienteId, cliente)

      'If Request.UrlReferrer IsNot Nothing Then
      '	If Request.UrlReferrer.AbsolutePath.Contains("BusquedaGlobal") Then
      '		ViewBag.Layout = True
      '	End If
      'End If
      ViewBag.Layout = True

      If resultado.Ok And resultado IsNot Nothing Then
        TinyMapper.Bind(Of clientes, ModeloClientes)()  'Mapeo de propiedad para modelo.
        model = TinyMapper.Map(Of ModeloClientes)(cliente)
        model.CargaControles()

        Return PartialView(model) 'Modelo para modificar registro
      Else
        If resultado.Id_Out = 1 Then
          Return PartialView("~/Views/Shared/_ErrorPopUp.vbhtml")
        Else
          model.CargaControles()
          Return PartialView(model) 'Modelo para alta
        End If
      End If


    End Function
#End Region

#Region "Promotores"

    <HttpGet>
    Public Function ObtenerListaPromotor(sucursal As Integer) As ActionResult

      Dim jresult
      Dim resultado
      Dim consulta = New FactorBAL.Manager()

      Dim listaPromotor = New List(Of PromotorEntidad)

      resultado = consulta.ConsultaListaPromotorBAL(sucursal, listaPromotor)

      If resultado.Ok And resultado IsNot Nothing Then
        jresult = Json(New With {Key .Results = listaPromotor}, JsonRequestBehavior.AllowGet)
      Else
        resultado.Mensaje = "Ocurrio un error al consultar la informacion !! "
        jresult = Json(New With {Key .Mensaje = resultado.Mensaje + resultado.Detalle}, JsonRequestBehavior.AllowGet)
      End If

      Return jresult

    End Function

    <HttpGet>
    Public Function GuardarPromotor(clave As Int32) As ActionResult

      Dim model = New ModeloPromotor()
      Dim consulta = New FactorBAL.Manager()
      Dim promotor = New promotor
      Dim resultado = consulta.ConsultaDetallePromotorBAL(clave, promotor)

      If Request.UrlReferrer IsNot Nothing Then
        If Request.UrlReferrer.AbsolutePath.Contains("BusquedaGlobal") Then
          ViewBag.Layout = True
        End If
      End If

      If resultado.Ok And resultado IsNot Nothing Then
        TinyMapper.Bind(Of promotor, ModeloPromotor)()  'Mapeo de propiedad para modelo.
        model = TinyMapper.Map(Of ModeloPromotor)(promotor)
        model.CargaControles()
        Return PartialView(model)
      Else
        If resultado.Id_Out = 1 Then
          Return PartialView("~/Views/Shared/_ErrorPopUp.vbhtml")
        Else
          model.CargaControles()
          Return PartialView(model)
        End If
      End If


    End Function

#End Region

#Region "Control de Riesgo"

    <HttpGet>
    Public Function obtenerListaRiesgo(clienteId As Integer) As ActionResult

      Dim jresult
      Dim resultado
      Dim manager = New FactorBAL.Manager()
      Dim riesgo = New ControlRiesgo_Cliente

      resultado = manager.ConsultaControlRiesgoBAL(clienteId, riesgo)

      If resultado.Ok And resultado IsNot Nothing Then
        jresult = New CustomJsonResult With {
          .Data = New With {Key .Results = riesgo.controlRiesgo.ToList(), .cliente = riesgo.cliente},
          .JsonRequestBehavior = JsonRequestBehavior.AllowGet
        }

      Else
        jresult = Json(New With {Key .Mensaje = resultado.Detalle + " !!"}, JsonRequestBehavior.AllowGet)
      End If


      Return jresult

    End Function

    <HttpGet>
    Public Function GuardarAsociarLineas(clienteId As Integer) As ActionResult

      Dim resultado
      Dim manager = New FactorBAL.Manager()
      Dim model = New ModeloControlRiesgo()
      Dim entidad = New ControlRiesgo()

      resultado = manager.consultaLineasBAL(clienteId, entidad)

      TinyMapper.Bind(Of ControlRiesgo, ModeloControlRiesgo)()  'Mapeo de propiedad para modelo.
      model = TinyMapper.Map(Of ModeloControlRiesgo)(entidad)
      model.propCliente = New ModeloClientes()
      model.propCliente.cliente = clienteId
      model.RelacionLineas = entidad.dropdown.Select(Function(x) New SelectListItem With {.Value = x.claveStr, .Text = x.nombre}).ToList()

      If resultado.Ok And resultado IsNot Nothing Then
        Return PartialView(model)
      Else
        Return PartialView()
      End If


    End Function

    <HttpGet>
    Public Function GuardarGarantiaLiquida(idRec As String) As ActionResult

      Dim resultado
      Dim manager = New FactorBAL.Manager()
      Dim model = New ModeloControlRiesgo()
      Dim entidad = New Ctrlriesgo

      resultado = manager.ConsultaGarantiaLiquidaBAL(idRec, entidad)

      If resultado.Ok And resultado IsNot Nothing Then
        TinyMapper.Bind(Of linea, ModeloControlRiesgo)()  'Mapeo de propiedad para modelo.
        model = TinyMapper.Map(Of ModeloControlRiesgo)(entidad)
        model.propCliente = New ModeloClientes()
        model.propCliente.cliente = entidad.cliente

        Return PartialView(model)
      Else
        Return PartialView("~/Views/Shared/_ErrorPopUp.vbhtml")
      End If


    End Function

    <HttpGet>
    Public Function GuardarClienteLineas(clienteId As Integer) As ActionResult

      Dim model = New ModeloControlRiesgo
      model.propCliente = New ModeloClientes
      model.propCliente.cliente = clienteId
      Return PartialView(model)

    End Function

#End Region

#Region "Apoderado"
    <HttpGet>
    Public Function ObtenerApoderados(cliente As Integer) As ActionResult

      Dim jresult
      Dim resultado
      Dim consulta = New FactorBAL.Manager()

      Dim lista = New List(Of ApoderadoEntidad)

      resultado = consulta.ConsultaApoderadoBAL(cliente, lista)

      If resultado.Ok And resultado IsNot Nothing Then
        jresult = Json(New With {Key .Results = lista}, JsonRequestBehavior.AllowGet)
      Else
        resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
      End If

      Return jresult

    End Function

    <HttpGet>
    Public Function GuardarApoderado(clienteId As Int32) As ActionResult

      Dim model = New ModeloApoderado()
      Dim consulta = New FactorBAL.Manager()
      Dim apoderado = New apoderados
      Dim resultado = consulta.ConsultaDetalleApoderadoBAL(clienteId, apoderado)

      If Request.UrlReferrer IsNot Nothing Then
        If Request.UrlReferrer.AbsolutePath.Contains("BusquedaGlobal") Then
          ViewBag.Layout = True
        End If
      End If

      If resultado.Ok And resultado IsNot Nothing Then
        TinyMapper.Bind(Of apoderados, ModeloApoderado)() 'Mapeo de propiedad para modelo.
        model = TinyMapper.Map(Of ModeloApoderado)(apoderado)
        model.CargaControles()

        Return PartialView(model) 'Modelo para modificar registro
      Else
        If resultado.Id_Out = 1 Then
          Return PartialView("~/Views/Shared/_ErrorPopUp.vbhtml")
        Else
          model.CargaControles()
          model.cliente = clienteId
          Return PartialView(model) 'Modelo para alta
        End If
      End If


    End Function
#End Region

#Region "Contratos"
    <HttpGet>
    Public Function ObtenerContratos(ClienteID As Integer) As ActionResult

      Dim jresult
      Dim resultado
      Dim consulta = New FactorBAL.Manager()

      Dim lista = New List(Of OperacionContrato)

      resultado = consulta.ConsultaContratosBAL(ClienteID, lista)

      If resultado.Ok And resultado IsNot Nothing Then
        'jresult = Json(New With {Key .Results = lista}, JsonRequestBehavior.AllowGet)

        jresult = New CustomJsonResult With {
          .Data = New With {Key .Results = lista},
          .JsonRequestBehavior = JsonRequestBehavior.AllowGet
        }

      Else
        resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
      End If

      Return jresult

    End Function

    <HttpGet>
    Public Function GuardarContrato(clienteId As Integer, ContratoId As Int32) As ActionResult

      Dim model = New Contrato_Cliente()
      Dim consulta = New FactorBAL.Manager()
      Dim contrato = New ContratoCliente
      contrato.clientes = New clientes
      contrato.contrato = New contratos
      Dim resultado = consulta.ConsultaDetalleContratoBAL(clienteId, ContratoId, contrato)

      If Request.UrlReferrer IsNot Nothing Then
        If Request.UrlReferrer.AbsolutePath.Contains("BusquedaGlobal") Then
          ViewBag.Layout = True
        End If
      End If

      If resultado.Ok And resultado IsNot Nothing Then

        TinyMapper.Bind(Of contratos, ModeloContrato)()  'Mapeo de propiedad para modelo.
        model.Contrato = TinyMapper.Map(Of ModeloContrato)(contrato.contrato)
        model.Contrato.CargaControles()

        TinyMapper.Bind(Of clientes, ModeloClientes)()   'Mapeo de propiedad para modelo.
        model.Cliente = TinyMapper.Map(Of ModeloClientes)(contrato.clientes)
        model.Cliente.CargaControles()

        Return PartialView(model)
      Else
        If resultado.Id_Out = 1 Then
          Return PartialView("~/Views/Shared/_ErrorPopUp.vbhtml")
        Else
          model.Contrato.CargaControles()
          TinyMapper.Bind(Of clientes, ModeloClientes)()   'Mapeo de propiedad para modelo.
          model.Cliente = TinyMapper.Map(Of ModeloClientes)(contrato.clientes)
          model.Cliente.CargaControles()

          Return PartialView(model)
        End If
      End If

    End Function

    <HttpGet>
    Public Function ObtenerClienteContrato(ClienteID As Integer) As ActionResult

      Dim jresult
      Dim resultado
      Dim consulta = New FactorBAL.Manager()

      Dim cliente = New OperacionContrato

      resultado = consulta.ConsultaClienteContratoBAL(ClienteID, cliente)

      If resultado.Ok And resultado IsNot Nothing Then

        jresult = New CustomJsonResult With {
          .Data = New With {Key .Results = cliente},
          .JsonRequestBehavior = JsonRequestBehavior.AllowGet
        }

      Else
        resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
      End If

      Return jresult

    End Function
#End Region

#Region "Anexo"
    <HttpGet>
    Public Function ObtenerAnexo(Contrato As Integer, Producto As Integer) As ActionResult

      Dim jresult
      Dim resultado
      Dim consulta = New FactorBAL.Manager()
      Dim lista = New List(Of AnexoConsulta)
      resultado = consulta.ConsultaAnexoBAL(Contrato, Producto, lista)


      If resultado.Ok And resultado IsNot Nothing Then
        jresult = New CustomJsonResult With {
          .Data = New With {Key .Results = lista},
          .JsonRequestBehavior = JsonRequestBehavior.AllowGet
        }
      Else
        resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
      End If

      Return jresult

    End Function

    <HttpGet>
    Public Function GuardarAnexo(deudor As Integer, producto As Integer, contrato As Integer) As ActionResult

      Dim model = New ModeloAnexoVM
      Dim consulta = New FactorBAL.Manager()
      Dim anexo = New AnexoConsulta
      Dim resultado = consulta.ConsultaDetalleAnexoBAL(deudor, producto, anexo, contrato)

      If Request.UrlReferrer IsNot Nothing Then
        If Request.UrlReferrer.AbsolutePath.Contains("BusquedaGlobal") Then
          ViewBag.Layout = True
        End If
      End If

      If resultado.Ok And resultado IsNot Nothing Then

        TinyMapper.Bind(Of AnexoConsulta, ModeloAnexo)()  'Mapeo de propiedad para modelo.
        model.Anexo = TinyMapper.Map(Of ModeloAnexo)(anexo)
        model.Comprador.nombre = anexo.nombre
        model.Anexo.contrato = contrato
        model.Anexo.producto = producto
        model.Anexo.tasadif = anexo.tasadif
        model.Anexo.modifica = True
        Return PartialView(model) 'Modelo para modificar registro
      Else
        If resultado.Id_Out = 1 Then
          Return PartialView("~/Views/Shared/_ErrorPopUp.vbhtml")
        Else
          model.Anexo.producto = producto
          model.Anexo.contrato = contrato
          model.Anexo.modifica = False
          Return PartialView(model) 'Modelo para alta
        End If
      End If


    End Function

    <HttpGet>
    Public Function Printanexo(contrato As Integer) As ActionResult
      Dim localReport = New Microsoft.Reporting.WebForms.LocalReport()


      Dim resultado = New Result
      Dim bs = New FactorBAL.Manager()
      Dim lista = New List(Of AnexoConsulta)

      resultado = bs.PrintAnexoBAL(contrato, lista)
      localReport.ReportPath = Server.MapPath("~/Reports/Anexo.rdlc")
      localReport.DataSources.Clear()

      Dim reportDataSource = New ReportDataSource()
      reportDataSource.Name = "Anexo"
      reportDataSource.Value = lista

      localReport.DataSources.Add(reportDataSource)
      If resultado.Ok And resultado IsNot Nothing Then

        Dim reportType As String = "PDF"
        Dim mimeType As String = ""
        Dim encoding As String = ""
        Dim fileNameExtension As String = ""

        Dim Waring() As Warning = Nothing 'Array
        Dim Streams() As String = Nothing 'Array 
        Dim renderedBytes() As Byte 'Array

        Dim list(0) As ReportParameter
        list(0) = New ReportParameter("Usuario", Session("USERID").ToString())

        localReport.SetParameters(list)
        renderedBytes = localReport.Render(reportType, Nothing, mimeType, encoding, fileNameExtension, Streams, Waring)
        If Request.Cookies("reporte") IsNot Nothing Then
          Request.Cookies("reporte").Value = "OK"
          Response.SetCookie(Request.Cookies("reporte"))
        End If
        Response.BufferOutput = False
        Return File(renderedBytes, "pdf", "Anexo_Contrato.pdf")

      Else
        Return Content("<script language='javascript' type='text/javascript'>alert('Error al generar el PDF favor de volver a consultar !!\n\nClick Aceptar para volver'); window.location.href ='../Catalogos/Printanexo?contrato=" + contrato.ToString() + "';</script>")
      End If

    End Function


#End Region

#Region "Cesiones"
        <HttpGet>
        Public Function ObtenerCesiones(Contrato As Integer) As ActionResult

            Dim jresult
            Dim resultado
            Dim consulta = New FactorBAL.Manager()

            Dim lista = New List(Of CesionEntidad)

            resultado = consulta.ConsultaCesionesBAL(Contrato, lista)

            If resultado.Ok And resultado IsNot Nothing Then

                jresult = New CustomJsonResult With {
                  .Data = New With {Key .Results = lista},
                  .JsonRequestBehavior = JsonRequestBehavior.AllowGet
                }

            Else
                resultado.Mensaje = "Ocurrio un error al consultar la informacion"
                jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
            End If

            Return jresult

        End Function


    <HttpGet>
    Public Function GuardarCesion(cesion As Integer, producto As Integer, clienteNombre As String, contrato As Integer, Optional last As Boolean = False) As ActionResult

      Dim model = New ModeloCesionVM
      Dim consulta = New FactorBAL.Manager()
      Dim CesionEntidad = New CesionEntidad
      Dim resultado = consulta.ConsultaDetalleCesionBAL(cesion, CesionEntidad, contrato)

      If Request.UrlReferrer IsNot Nothing Then
        If Request.UrlReferrer.AbsolutePath.Contains("BusquedaGlobal") Then
          ViewBag.Layout = True
        End If
      End If

      If resultado.Ok And resultado IsNot Nothing Then

        TinyMapper.Bind(Of CesionEntidad, ModeloCesion)() 'Mapeo de propiedad para modelo.
        model.Cesion = TinyMapper.Map(Of ModeloCesion)(CesionEntidad)

        model.producto = producto
        model.Cesion.contrato = contrato
        If producto = 1 Then
          model.Cesion.Beneficiario = clienteNombre
        Else
          model.Cesion.Beneficiario = CesionEntidad.proveedorNombre
        End If

        Return PartialView(model) 'Modelo para modificar registro
      Else

        Return PartialView("~/Views/Shared/_ErrorPopUp.vbhtml")

      End If

    End Function



        <HttpGet>
        Public Function CesionWzd(contrato As Integer, producto As Integer, cesion As Integer, cliente As Integer, nombre As String) As ActionResult

            Dim model = New ModeloCesionWzd
            Dim consulta = New FactorBAL.Manager()
            Dim CesionWzdEntidad = New CesionWzdEntidad
            Dim resultado = consulta.ConsultaCesionWzdBAL(contrato, producto, cesion, CesionWzdEntidad)

            Dim m2 = New ContratoCliente
            Dim cteCto = consulta.ConsultaDetalleContratoBAL(cliente, contrato, m2)

            If Request.UrlReferrer IsNot Nothing Then
                If Request.UrlReferrer.AbsolutePath.Contains("BusquedaGlobal") Then
                    ViewBag.Layout = True
                End If
            End If

            If resultado.Ok And resultado IsNot Nothing Then

                TinyMapper.Bind(Of CesionWzdEntidad, ModeloCesionWzd)() 'Mapeo de propiedad para modelo.
                model = TinyMapper.Map(Of ModeloCesionWzd)(CesionWzdEntidad)
                model.CargaControles()

                model.doc = CesionWzdEntidad.doctos
                model.contrato = contrato
                model.cesion = cesion
                model.producto = producto
                model.nombre = nombre
                'If producto = 1 Then
                '    model.Cesion.Beneficiario = clienteNombre
                'Else
                '    model.Cesion.Beneficiario = CesionEntidad.proveedorNombre
                'End If

                Return PartialView(model) 'Modelo para modificar registro
            Else

                If resultado.Id_Out = 1 Then
                    Return PartialView("~/Views/Shared/_ErrorPopUp.vbhtml")
                Else

                    Dim sf = DateTime.Now.ToString("dd/MM/yyyy")
                    Dim tasas = New indicadores
                    Dim dtasas = consulta.ConsultaIndicadorDetalleBAL(sf, tasas)
                    TinyMapper.Bind(Of ContratoCliente, ModeloContrato)() 'Mapeo de propiedad para modelo.

                    model.CargaControles()

                    Dim sGuid As String
                    sGuid = System.Guid.NewGuid.ToString()
                    model.idtransact = sGuid
                    model.userid = Session("USERID").ToString()


                    model.producto = producto
                    model.contrato = contrato
                    model.nombre = nombre

                    model.cesion = cesion
                    model.fec_alta = Date.Now
                    model.fec_vence = Date.Now.AddDays(11)

                    model.plazo = DateDiff(DateInterval.Day, Date.Now, Date.Now.AddDays(11))
                    model.importe = 0
                    model.impanticipado = 0
                    model.porc_anti = m2.contrato.porc_anti
                    model.moneda = m2.contrato.moneda
                    model.doctos = 1

                    model.interes = 0
                    model.tasaoper = IIf(m2.contrato.interes = 2, 0, m2.contrato.tasa_ord + tasas.tiie)

                    Return PartialView(model) 'Modelo para alta
                End If


            End If

        End Function


        <HttpGet>
        Public Function ObtenerDoctos(Cesion As Integer, Contrato As Integer, idtransact As String) As ActionResult

            Dim jresult
            Dim resultado
            Dim consulta = New FactorBAL.Manager()

            Dim lista = New List(Of DoctosEntidad)

            resultado = consulta.ConsultaDoctosBAL(Contrato, Cesion, idtransact, lista)

            If resultado.Ok And resultado IsNot Nothing Then

                jresult = New CustomJsonResult With {
                  .Data = New With {Key .Results = lista},
                  .JsonRequestBehavior = JsonRequestBehavior.AllowGet
                }

            Else
                resultado.Mensaje = "Ocurrio un error al consultar la informacion"
                jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
            End If

            Return jresult

        End Function

        <HttpGet>
        Public Function ObtenerAdeudosCto(Contrato As Integer) As ActionResult

            Dim jresult
            Dim resultado
            Dim consulta = New FactorBAL.Manager()

            Dim lista = New List(Of adeudosEntidad)

            resultado = consulta.ConsultaAdeudosCtoBAL(Contrato, lista)

            If resultado.Ok And resultado IsNot Nothing Then

                jresult = New CustomJsonResult With {
                  .Data = New With {Key .Results = lista},
                  .JsonRequestBehavior = JsonRequestBehavior.AllowGet
                }

            Else
                resultado.Mensaje = "Ocurrio un error al consultar la informacion"
                jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
            End If

            Return jresult

        End Function

        <HttpGet>
        Public Function Adeudosporpagar(Contrato As Integer) As ActionResult

            Dim jresult
            Dim resultado
            Dim consulta = New FactorBAL.Manager()

            Dim lista = New List(Of AdeudosWzdEntidad)

            resultado = consulta.ConsultaAdeudosxpagarBAL(Contrato, lista)

            If resultado.Ok And resultado IsNot Nothing Then

                jresult = New CustomJsonResult With {
                  .Data = New With {Key .Data = lista},
                  .JsonRequestBehavior = JsonRequestBehavior.AllowGet
                }

            Else
                resultado.Mensaje = "Ocurrio un error al consultar la informacion"
                jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
            End If

            Return jresult

        End Function



        <HttpGet>
        Public Function ObtenerpagosadeudosCtoCes(Cesion As Integer, Contrato As Integer, idtransact As String) As ActionResult

            Dim jresult
            Dim resultado
            Dim consulta = New FactorBAL.Manager()

            Dim lista = New List(Of PagosAdeudosEntidad)

            resultado = consulta.ConsultapagosadeudosCtoCesBAL(Cesion, Contrato, idtransact, lista)

            If resultado.Ok And resultado IsNot Nothing Then

                jresult = New CustomJsonResult With {
                  .Data = New With {Key .Results = lista},
                  .JsonRequestBehavior = JsonRequestBehavior.AllowGet
                }

            Else
                resultado.Mensaje = "Ocurrio un error al consultar la informacion"
                jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
            End If

            Return jresult

        End Function


        '<HttpGet>
        'Public Function GuardaradeudosWzd(Contrato As Integer) As ActionResult

        '    Dim jresult
        '    Dim resultado
        '    Dim consulta = New FactorBAL.Manager()

        '    Dim lista = New List(Of adeudosEntidad)

        '    resultado = consulta.ConsultaAdeudosxpagarBAL(Contrato, lista)

        '    If resultado.Ok And resultado IsNot Nothing Then

        '        jresult = New CustomJsonResult With {
        '          .Data = New With {Key .Results = lista},
        '          .JsonRequestBehavior = JsonRequestBehavior.AllowGet
        '        }

        '    Else
        '        resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        '        jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
        '    End If

        '    Return jresult

        'End Function


        <HttpGet>
        Public Function ObtenergarantiaCto(Cesion As Integer, Contrato As Integer, idtransact As String) As ActionResult

            Dim jresult
            Dim resultado
            Dim consulta = New FactorBAL.Manager()

            Dim lista = New List(Of GarantiaEntidad)

            resultado = consulta.ConsultaGarantiasBAL(Contrato, Cesion, idtransact, lista)

            If resultado.Ok And resultado IsNot Nothing Then
                jresult = New CustomJsonResult With {
                  .Data = New With {Key .Results = lista},
                  .JsonRequestBehavior = JsonRequestBehavior.AllowGet
                }
            Else
                resultado.Mensaje = "Ocurrio un error al consultar la informacion"
                jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
            End If

            Return jresult

        End Function

    <HttpGet>
    Public Function GuardarGarantia(garantiaid As Integer, contrato As Integer, cesion As Integer) As ActionResult

      Dim model = New ModeloGarantia
      Dim consulta = New FactorBAL.Manager()
      Dim GarantiaEntidad = New GarantiaEntidad
      Dim resultado = consulta.ConsultaDetalleGarantiaBAL(garantiaid, GarantiaEntidad)

      If Request.UrlReferrer IsNot Nothing Then
        If Request.UrlReferrer.AbsolutePath.Contains("BusquedaGlobal") Then
          ViewBag.Layout = True
        End If
      End If

      If resultado.Ok And resultado IsNot Nothing Then

        TinyMapper.Bind(Of GarantiaEntidad, ModeloGarantia)() 'Mapeo de propiedad para modelo.
        model = TinyMapper.Map(Of ModeloGarantia)(GarantiaEntidad)
        model.CargaControles()
        model.contrato = contrato
        model.cesion = cesion

        Return PartialView(model) 'Modelo para modificar registro
      Else
        If resultado.Id_Out = 1 Then
          Return PartialView("~/Views/Shared/_ErrorPopUp.vbhtml")
        Else
          model.CargaControles()
          Return PartialView(model) 'Modelo para alta
        End If
      End If

        End Function

        <HttpGet>
        Public Function Guardardocto(iddocto As Integer, contrato As Integer, idtransact As String, producto As Integer, cesion As Integer) As ActionResult

            Dim model = New ModeloDocto

            Dim controles = New controles()
            Dim consulta = New FactorBAL.Manager()

            Dim cesion_num As Integer = 0
            Dim res = New Result(False)
            res = consulta.GetCesionNumberBAL(cesion, contrato, idtransact, cesion_num)

            Dim Ces = New CesionWzdEntidad
            Dim Resultado_ces = consulta.ConsultaCesionWzdBAL(contrato, producto, cesion_num, Ces)

            Dim doc = New DoctosEntidad
            Dim resultado = consulta.GuardardoctoBAL(iddocto, contrato, cesion_num, doc)

            If Request.UrlReferrer IsNot Nothing Then
                If Request.UrlReferrer.AbsolutePath.Contains("BusquedaGlobal") Then
                    ViewBag.Layout = True
                End If
            End If

            If resultado.Ok And resultado IsNot Nothing Then

                TinyMapper.Bind(Of DoctosEntidad, ModeloDocto)() 'Mapeo de propiedad para modelo.
                model = TinyMapper.Map(Of ModeloDocto)(doc)

                model.contrato = contrato
                model.cesion = cesion_num
                model.CargaControles(contrato)

                Return PartialView(model) 'Modelo para modificar registro
            Else
                If resultado.Id_Out = 1 Then
                    Return PartialView("~/Views/Shared/_ErrorPopUp.vbhtml")
                Else
                    'model.CargaControles()
                    model.CargaControles(contrato)
                    model.monto = 0
                    model.contrato = contrato
                    model.cesion = cesion_num
                    model.fec_alta = Ces.fec_alta
                    model.fec_vence = Ces.fec_vence
                    model.dfec_vence = Ces.fec_vence
                    model.idcesion = Ces.idcesion
                    model.idtransact = idtransact


                    Return PartialView(model) 'Modelo para alta
                End If
            End If

        End Function

        <HttpGet>
        Public Function GuardargarantiaWzd(garantiaid As Integer, contrato As Integer, idtransact As String, producto As Integer, cesion As Integer) As ActionResult

            Dim model = New ModeloGarantia

            Dim controles = New controles()
            Dim consulta = New FactorBAL.Manager()

            Dim cesion_num As Integer = 0
            Dim res = New Result(False)
            res = consulta.GetCesionNumberBAL(cesion, contrato, idtransact, cesion_num)

            Dim Ces = New CesionWzdEntidad
            Dim Resultado_ces = consulta.ConsultaCesionWzdBAL(contrato, producto, cesion_num, Ces)

            Dim gar = New GarantiaEntidad
            Dim resultado = consulta.GuardargarantiaBAL(garantiaid, contrato, cesion_num, gar)

            If Request.UrlReferrer IsNot Nothing Then
                If Request.UrlReferrer.AbsolutePath.Contains("BusquedaGlobal") Then
                    ViewBag.Layout = True
                End If
            End If

            If resultado.Ok And resultado IsNot Nothing Then

                TinyMapper.Bind(Of GarantiaEntidad, ModeloGarantia)() 'Mapeo de propiedad para modelo.
                model = TinyMapper.Map(Of ModeloGarantia)(gar)

                model.contrato = contrato
                model.cesion = cesion_num
                model.CargaControles()

                Return PartialView(model) 'Modelo para modificar registro
            Else
                If resultado.Id_Out = 1 Then
                    Return PartialView("~/Views/Shared/_ErrorPopUp.vbhtml")
                Else



                    model.contrato = contrato
                    model.cesion = cesion_num
                    model.codigo = 1
                    model.tipo = 1
                    model.costo = 2.4
                    model.porcentaje = 50
                    model.CargaControles()


                    Return PartialView(model) 'Modelo para alta
                End If
            End If

        End Function


        <HttpGet>
        Public Function GuardaradeudosWzd(contrato As Integer) As ActionResult

            Dim model = New ModeloAdeudosWzd
            model.contrato = contrato
            'Dim controles = New controles()
            'Dim consulta = New FactorBAL.Manager()

            'Dim cesion_num As Integer = 0
            'Dim res = New Result(False)
            'res = consulta.GetCesionNumberBAL(cesion, contrato, idtransact, cesion_num)

            'Dim Ces = New CesionWzdEntidad
            'Dim Resultado_ces = consulta.ConsultaCesionWzdBAL(contrato, producto, cesion_num, Ces)

            'Dim gar = New GarantiaEntidad
            'Dim resultado = consulta.GuardargarantiaBAL(garantiaid, contrato, cesion_num, gar)

            'If Request.UrlReferrer IsNot Nothing Then
            '    If Request.UrlReferrer.AbsolutePath.Contains("BusquedaGlobal") Then
            '        ViewBag.Layout = True
            '    End If
            'End If

            'If resultado.Ok And resultado IsNot Nothing Then

            '    TinyMapper.Bind(Of GarantiaEntidad, ModeloGarantia)() 'Mapeo de propiedad para modelo.
            '    model = TinyMapper.Map(Of ModeloGarantia)(gar)

            '    model.contrato = contrato
            '    model.cesion = cesion_num
            '    model.CargaControles()

            Return PartialView(model) 'Modelo para modificar registro
            'Else
            'If resultado.Id_Out = 1 Then
            '    Return PartialView("~/Views/Shared/_ErrorPopUp.vbhtml")
            'Else



            '    model.contrato = contrato
            '    model.cesion = cesion_num
            '    model.codigo = 1
            '    model.tipo = 1
            '    model.costo = 2.4
            '    model.porcentaje = 50
            '    model.CargaControles()


            '    Return PartialView(model) 'Modelo para alta
            'End If
            'End If

        End Function


#End Region

#Region "UsuariosWeb"

    <HttpGet>
    <CustomAuthorize(Permisos.Acciones.PORTAL)>
    Public Function ObtenerUsuariosWeb(id As Integer, identidad As Integer) As ActionResult

      Dim jresult
      Dim resultado
      Dim consulta = New FactorBAL.Manager()

      Dim lista = New List(Of UsuarioWebEntidad)

      resultado = consulta.ConsultaUsuariosWebBAL(lista, id, identidad)

      If resultado.Ok And resultado IsNot Nothing Then
        'jresult = Json(New With {Key .Results = lista}, JsonRequestBehavior.AllowGet)

        jresult = New CustomJsonResult With {
          .Data = New With {Key .Results = lista},
          .JsonRequestBehavior = JsonRequestBehavior.AllowGet
        }

      Else
        resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
      End If

      Return jresult

    End Function

		<HttpGet>
		<CustomAuthorize(Permisos.Acciones.PORTAL)>
		Public Function GuardarUsuarioWeb(folio As Integer, id As Integer, identidad As Integer) As ActionResult

			Dim model = New ModeloUsuarioWeb()
			Dim consulta = New FactorBAL.Manager()
			Dim userWeb = New usersregs()

			Dim resultado = consulta.ConsultaDetalleUsuarioWebBAL(folio, userWeb)
			ModelState.Clear()
			userWeb.id = id
			userWeb.identidad = identidad

			If resultado.Ok And resultado IsNot Nothing Then
				TinyMapper.Bind(Of usersregs, ModeloUsuarioWeb)() 'Mapeo de propiedad para modelo.
				model = TinyMapper.Map(Of ModeloUsuarioWeb)(userWeb)
				Return PartialView(model)
			Else
				If resultado.Id_Out = 1 Then
					Return PartialView("~/Views/Shared/_ErrorPopUp.vbhtml")
				Else
					Return PartialView(model)
				End If
			End If


		End Function

    <HttpGet>
    <CustomAuthorize(Permisos.Acciones.PORTAL)>
    Public Function ConsultaDetalleBitacora(username As String, fechaini As String, fechafin As String) As ActionResult

      Dim jresult
      Dim consulta = New FactorBAL.Manager()
      Dim bitacora = New List(Of BitacoraEntidad)()
      Dim resultado = New Result()

      If fechafin.Trim() = "" Or fechafin.Trim() = "" Then
        resultado.Mensaje = "Seleccione una fecha!!"
        jresult = Json(New With {Key .Mensaje = resultado.Mensaje + resultado.Detalle, .Color = "warning"}, JsonRequestBehavior.AllowGet)
      Else
        resultado = consulta.ConsultaDetalleBitacoraBAL(bitacora, username, fechaini, fechafin)

        If resultado.Ok And resultado IsNot Nothing Then

          jresult = New CustomJsonResult With {
            .Data = New With {Key .Results = bitacora},
            .JsonRequestBehavior = JsonRequestBehavior.AllowGet
          }

        Else
          resultado.Mensaje = "Ocurrio un error al consultar la informacion"
          jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
        End If


      End If
      Return jresult

    End Function


    <HttpGet>
    Public Function PrintUsersWeb(id As Integer, identidad As Integer) As ActionResult
      Dim localReport = New Microsoft.Reporting.WebForms.LocalReport()


      Dim resultado = New Result
      Dim bs = New FactorBAL.Manager()
      Dim lista = New List(Of UsuarioWebEntidad)

      resultado = bs.PrintUsersWebBAL(id, identidad, lista)
      localReport.ReportPath = Server.MapPath("~/Reports/Usersregs.rdlc")
      localReport.DataSources.Clear()

      Dim reportDataSource = New ReportDataSource()
      reportDataSource.Name = "Usersregs"
      reportDataSource.Value = lista

      localReport.DataSources.Add(reportDataSource)
      If resultado.Ok And resultado IsNot Nothing Then

        Dim reportType As String = "PDF"
        Dim mimeType As String = ""
        Dim encoding As String = ""
        Dim fileNameExtension As String = ""

        Dim Waring() As Warning = Nothing 'Array
        Dim Streams() As String = Nothing 'Array 
        Dim renderedBytes() As Byte 'Array

        Dim list(0) As ReportParameter
        list(0) = New ReportParameter("Usuario", Session("USERID").ToString())

        localReport.SetParameters(list)
        renderedBytes = localReport.Render(reportType, Nothing, mimeType, encoding, fileNameExtension, Streams, Waring)
        If Request.Cookies("reporte") IsNot Nothing Then
          Request.Cookies("reporte").Value = "OK"
          Response.SetCookie(Request.Cookies("reporte"))
        End If
        Response.BufferOutput = False
        Return File(renderedBytes, "pdf", "UsersWeb.pdf")

      Else
        Return Content("<script language='javascript' type='text/javascript'>alert('Error al generar el PDF favor de volver a consultar !!\n\nClick Aceptar para volver'); window.location.href ='../Catalogos/Printusersregs?contrato=" + id.ToString() + "&nombre=" + identidad.ToString() + "';</script>")
      End If

    End Function


#End Region

#End Region

#Region "Post"  '*****POST*****

#Region "Paridad Cambiaria"
    'Actualiza Parida'
    <HttpPost>
    <CustomAuthorize(Permisos.Acciones.CATALOGOS_ACTUALIZAR)>
    Public Function GuardarParidad(modelP As ModeloPar) As ActionResult

      Dim resultado
      If ModelState.IsValid Then
        Dim bs = New FactorBAL.Manager()

        TinyMapper.Bind(Of ModeloPar, paridad)() 'Mapeo de propiedades Modelo a DTO's
        Dim model = TinyMapper.Map(Of paridad)(modelP)

        resultado = bs.ActualizarParidad(model)

        If resultado.Ok And resultado IsNot Nothing Then
          If resultado.Mensaje = "Registro Guardado" Then
            FactorBAL.Utility.Monitor(Session("USERID"), "Agregado nuevo registro de Paridad para fecha : " + model.fecha)
          Else
            FactorBAL.Utility.Monitor(Session("USERID"), "Actualizado registro de Paridad para fecha : " + model.fecha)
          End If

          resultado.tipo = Enumerador.eTipoTransaccion.eActualizar
        Else
          resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro!! {0}" +
                  "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)

        End If
        Return Json(New With {Key .Result = resultado.Ok, .color = "success", .Text = resultado.Mensaje, .Tipo = resultado.Tipo, .titulo = ""})
      Else
        resultado = New Result(False)

        For item As Integer = 0 To ModelState.Keys.Count - 1 Step +1
          If ModelState.Values(item).Errors.Count > 0 Then
            Dim val = item
            resultado.Mensaje = resultado.Mensaje + "<br/> - " + modelP.GetType().GetProperties().Where(Function(x) x.Name = ModelState.Keys(val)).SingleOrDefault().
                            GetCustomAttributes(GetType(System.ComponentModel.DataAnnotations.DisplayAttribute), False).
                              Cast(Of System.ComponentModel.DataAnnotations.DisplayAttribute).
                                FirstOrDefault().Name
          End If
        Next

        Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .titulo = "Revisar los siguientes campos !!"})
      End If


    End Function
#End Region

#Region "Proveedor"
    <HttpPost>
    <CustomAuthorize(Permisos.Acciones.CATALOGOS_ACTUALIZAR)>
    Public Function GuardarProveedor(proveedor As ModeloProveedor) As ActionResult
      Dim resultado
      If ModelState.IsValid Then

        Dim bs = New FactorBAL.Manager()

        TinyMapper.Bind(Of ModeloProveedor, proveedor)() 'Mapeo de propiedades Modelo a DTO's
        Dim model = TinyMapper.Map(Of proveedor)(proveedor)
        FieldsReflect.initialize(model) ' inicializamos todos los campos string a blanco 

        If proveedor.deudor > 0 Then

          Dim validaciones = New RepositorioValidacion()
          Dim existe = False
          Dim resp = "nombre"

          resultado = validaciones.ValidarRFC(model.rfc, "proveedor", resp, "deudor ", "RFC", "deudor", model.deudor, existe)

          If resultado.Ok And resultado IsNot Nothing Then
            If existe Then
              resultado.Mensaje = "R.F.C. ya existe " + resp
              Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .Tipo = resultado.tipo, .titulo = "Revisar los siguientes campos !!"})
            Else


              resultado = bs.ActualizarProveedor(Session("USERID").ToString(), model)
              If resultado.Ok And resultado IsNot Nothing Then
                resultado.Mensaje = "Registro Actualizado"
                FactorBAL.Utility.Monitor(Session("USERID"), "Actualizado registro de proveedor  clave  : " + model.deudor.ToString())
                resultado.tipo = Enumerador.eTipoTransaccion.eActualizar
              Else
                resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro!! {0}" +
                        "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
              End If
            End If
          Else
            resultado.Mensaje = "Ocurrio un error al validar R.F.C. "
            Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .Tipo = resultado.tipo, .titulo = ""})
          End If
        Else

          Dim validaciones = New RepositorioValidacion()
          Dim existe = False
          Dim resp = "nombre"

          resultado = validaciones.ValidarRFC(model.rfc, "proveedor", resp, "deudor ", "RFC", "deudor", model.deudor, existe)

          If resultado.Ok And resultado IsNot Nothing Then
            If existe Then
              resultado.Mensaje = "R.F.C. ya existe </br>" + resp
              Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .Tipo = resultado.tipo, .titulo = "Revisar los siguientes campos !!"})
            Else
              resultado = bs.AltaProveedor(model)

              If resultado.Ok And resultado IsNot Nothing Then
                resultado.Mensaje = "Registro Guardado"
                FactorBAL.Utility.Monitor(Session("USERID"), "Agregado nuevo registro de proveedor  clave  : " + model.deudor.ToString())
                resultado.tipo = Enumerador.eTipoTransaccion.eAlta
              Else
                resultado.Mensaje = String.Format("Ocurrio un error al tratar de guardar el registro!! {0}" +
                      "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
              End If
            End If
          Else
            resultado.Mensaje = "Ocurrio un error al validar R.F.C. "
            Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .Tipo = resultado.tipo, .titulo = ""})
          End If
        End If
        Return Json(New With {Key .Result = resultado.Ok, .color = "success", .Text = resultado.Mensaje, .Tipo = resultado.tipo, .titulo = ""})
      Else
        resultado = New Result(False)

        For item As Integer = 0 To ModelState.Keys.Count - 1 Step +1
          If ModelState.Values(item).Errors.Count > 0 Then
            Dim val = item
            resultado.Mensaje = resultado.Mensaje + "<br/> - " + proveedor.GetType().GetProperties().Where(Function(x) x.Name = ModelState.Keys(val)).SingleOrDefault().
                            GetCustomAttributes(GetType(System.ComponentModel.DataAnnotations.DisplayAttribute), False).
                              Cast(Of System.ComponentModel.DataAnnotations.DisplayAttribute).
                                FirstOrDefault().Name
          End If
        Next

        Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .titulo = "Revisar los siguientes campos !!"})
      End If



    End Function
#End Region

#Region "Comprador"
    <HttpPost>
    <CustomAuthorize(Permisos.Acciones.CATALOGOS_ACTUALIZAR)>
    Public Function GuardarComprador(comprador As ModeloComprador) As ActionResult

      Dim resultado

      If ModelState.IsValid Then
        Dim bs = New FactorBAL.Manager()

        TinyMapper.Bind(Of ModeloComprador, comprador)() 'Mapeo de propiedades Modelo a DTO's
        Dim model = TinyMapper.Map(Of comprador)(comprador)

        FieldsReflect.initialize(model)

        If comprador.deudor > 0 Then


          Dim validaciones = New RepositorioValidacion()
          Dim existe = False
          Dim resp = "nombre"

          resultado = validaciones.ValidarRFC(model.rfc, "comprador", resp, "deudor", "RFC", "deudor", model.deudor, existe)

          If resultado.Ok And resultado IsNot Nothing Then
            If existe Then
              resultado.Mensaje = "R.F.C. ya existe " + resp
              Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .Tipo = resultado.tipo, .titulo = "Revisar los siguientes campos !!"})
            Else
              resultado = bs.ActualizarComprador(model)

              If resultado.Ok And resultado IsNot Nothing Then
                resultado.Mensaje = "Registro Actualizado"
                FactorBAL.Utility.Monitor(Session("USERID"), "Actualizado registro de Proveedor  clave  : " + model.deudor.ToString())
                resultado.tipo = Enumerador.eTipoTransaccion.eActualizar
              Else
                resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro!! {0}" +
                        "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
              End If
            End If
          Else
            resultado.Mensaje = "Ocurrio un error al validar R.F.C. "
            Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .Tipo = resultado.tipo, .titulo = ""})
          End If
        Else
          'Inicializa todas las variables que no tengan valor 

          Dim validaciones = New RepositorioValidacion()
          Dim existe = False
          Dim resp = "nombre"

          resultado = validaciones.ValidarRFC(model.rfc, "comprador", resp, "deudor", "RFC", "deudor", model.deudor, existe)

          If resultado.Ok And resultado IsNot Nothing Then
            If existe Then
              resultado.Mensaje = "R.F.C. ya existe " + resp
              Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .Tipo = resultado.tipo, .titulo = "Revisar los siguientes campos !!"})
            Else
              resultado = bs.Altacomprador(model)

              If resultado.Ok And resultado IsNot Nothing Then
                resultado.Mensaje = "Registro Guardado"
                FactorBAL.Utility.Monitor(Session("USERID"), "Agregado nuevo registro de Comprador  clave  : " + model.deudor.ToString())
                resultado.tipo = Enumerador.eTipoTransaccion.eAlta
              Else
                resultado.Mensaje = String.Format("Ocurrio un error al tratar de guardar el registro!! {0}" +
                      "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
              End If
            End If
          Else
            resultado.Mensaje = "Ocurrio un error al validar R.F.C. "
            Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .Tipo = resultado.tipo, .titulo = ""})
          End If

        End If
        Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.tipo, .titulo = ""})
      Else
        resultado = New Result(False)

        For item As Integer = 0 To ModelState.Keys.Count - 1 Step +1
          If ModelState.Values(item).Errors.Count > 0 Then
            Dim val = item
            resultado.Mensaje = resultado.Mensaje + "<br/> - " + comprador.GetType().GetProperties().Where(Function(x) x.Name = ModelState.Keys(val)).SingleOrDefault().
                            GetCustomAttributes(GetType(System.ComponentModel.DataAnnotations.DisplayAttribute), False).
                              Cast(Of System.ComponentModel.DataAnnotations.DisplayAttribute).
                                FirstOrDefault().Name
          End If
        Next

        Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .titulo = "Revisar los siguientes campos !!"})
      End If


    End Function
#End Region

#Region "Indicadores Financieros"
    <HttpPost>
    <CustomAuthorize(Permisos.Acciones.CATALOGOS_ACTUALIZAR)>
    Public Function GuardarFinanciero(modelF As ModeloFinanciero) As ActionResult
      Dim jresult
      Dim resultado
      Dim bs = New FactorBAL.Manager()

      TinyMapper.Bind(Of ModeloFinanciero, indicadores)() 'Mapeo de propiedades Modelo a DTO's
      Dim model = TinyMapper.Map(Of indicadores)(modelF)

      resultado = bs.ActualizarIndicador(model)

      If resultado.Ok And resultado IsNot Nothing Then

        If resultado.Mensaje = "Registro Guardado" Then
          FactorBAL.Utility.Monitor(Session("USERID"), "Agregado nuevo registro de Indicadores Financieros para fecha : " + model.fecha)
        Else
          FactorBAL.Utility.Monitor(Session("USERID"), "Actualizado registro de Indicadores Financieros para fecha : " + model.fecha)
        End If

        resultado.tipo = Enumerador.eTipoTransaccion.eActualizar
      Else
        resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro!! {0}" +
              "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
      End If
      jresult = Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})

      Return jresult

    End Function
#End Region

#Region "Sucursal"
    <HttpPost>
    <CustomAuthorize(Permisos.Acciones.CATALOGOS_ACTUALIZAR)>
    Public Function GuardarSucursal(sucursal As ModeloSucursal) As ActionResult

      Dim resultado

      If ModelState.IsValid Then
        Dim bs = New FactorBAL.Manager()

        TinyMapper.Bind(Of ModeloSucursal, sucursal)()  'Mapeo de propiedades Modelo a DTO's
        Dim model = TinyMapper.Map(Of sucursal)(sucursal)

        FieldsReflect.initialize(model) 'Inicializa todas las variables que no tengan valor 


        If sucursal.sucursal1 > 0 Then
          resultado = bs.ActualizarSucursal(model)

          If resultado.Ok And resultado IsNot Nothing Then
            resultado.Mensaje = "Registro Actualizado"
            FactorBAL.Utility.Monitor(Session("USERID"), "Actualizado registro de Sucursal clave : " + model.sucursal1.ToString())
            resultado.tipo = Enumerador.eTipoTransaccion.eActualizar
          Else
            resultado.Mensaje = "Ocurrio un error al tratar de actualizar el registro!! "
          End If

        Else

          resultado = bs.AltaSucursal(model)

          If resultado.Ok And resultado IsNot Nothing Then
            resultado.Mensaje = "Registro Guardado"
            FactorBAL.Utility.Monitor(Session("USERID"), "Agregado nuevo registro de Sucursal clave : " + model.sucursal1.ToString())
            resultado.tipo = Enumerador.eTipoTransaccion.eAlta
          Else
            resultado.Mensaje = "Ocurrio un error al tratar de guardar el registro!! "
          End If

        End If

        Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})
      Else

      End If
      resultado = New Result(False)
      For item As Integer = 0 To ModelState.Keys.Count - 1 Step +1
        If ModelState.Values(item).Errors.Count > 0 Then
          Dim val = item
          resultado.Mensaje = resultado.Mensaje + "<br/> - " + sucursal.GetType().GetProperties().Where(Function(x) x.Name = ModelState.Keys(val)).SingleOrDefault().
                          GetCustomAttributes(GetType(System.ComponentModel.DataAnnotations.DisplayAttribute), False).
                            Cast(Of System.ComponentModel.DataAnnotations.DisplayAttribute).
                              FirstOrDefault().Name
        End If
      Next
      Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .titulo = "Revisar los siguientes campos !!"})
    End Function
#End Region

#Region "Clientes"
    <HttpPost>
    <CustomAuthorize(Permisos.Acciones.CATALOGOS_ACTUALIZAR)>
    Public Function GuardarCliente(objetoModelo As ModeloClientes) As ActionResult
      Dim resultado
      If ModelState.IsValid Then
        Dim bs = New FactorBAL.Manager()
        TinyMapper.Bind(Of ModeloClientes, clientes)()  'Mapeo de propiedades Modelo a DTO's
        Dim model = TinyMapper.Map(Of clientes)(objetoModelo)
        FieldsReflect.initialize(model)

        If model.cliente > 0 Then

          Dim validaciones = New RepositorioValidacion()
          Dim existe = False
          Dim resp = "nombre"

          resultado = validaciones.ValidarRFC(model.rfc, "clientes", resp, "cliente ", "RFC", "cliente", model.cliente, existe)

          If resultado.Ok And resultado IsNot Nothing Then
            If existe Then
              resultado.Mensaje = "R.F.C. ya existe " + resp
              Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .Tipo = resultado.tipo, .titulo = "Revisar los siguientes campos !!"})
            Else
              resultado = bs.ActualizarCliente(model)
              If resultado.Ok And resultado IsNot Nothing Then
                resultado.Mensaje = "Registro Actualizado"
                FactorBAL.Utility.Monitor(Session("USERID"), "Actualizado registro de Cliente clave  : " + model.cliente.ToString())
                resultado.tipo = Enumerador.eTipoTransaccion.eActualizar
              Else
                resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro!! {0}" +
                      "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
              End If
            End If
          Else
            resultado.Mensaje = "Ocurrio un error al validar R.F.C. "
            Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .Tipo = resultado.tipo, .titulo = ""})
          End If
        Else

          Dim validaciones = New RepositorioValidacion()
          Dim existe = False
          Dim resp = "nombre"

          resultado = validaciones.ValidarRFC(model.rfc, "clientes", resp, "cliente ", "RFC", "cliente", model.cliente, existe)

          If resultado.Ok And resultado IsNot Nothing Then
            If existe Then
              resultado.Mensaje = "R.F.C. ya existe " + resp
              Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .Tipo = resultado.tipo, .titulo = "Revisar los siguientes campos !!"})
            Else
              resultado = bs.AltaCliente(model)
              If resultado.Ok And resultado IsNot Nothing Then
                resultado.Mensaje = "Registro Guardado"
                FactorBAL.Utility.Monitor(Session("USERID"), "Agregado nuevo registro de Cliente clave  : " + model.cliente.ToString())
                resultado.tipo = Enumerador.eTipoTransaccion.eAlta
              Else
                resultado.Mensaje = String.Format("Ocurrio un error al tratar de guardar el registro!! {0}" +
                      "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
              End If
            End If
          Else
            resultado.Mensaje = "Ocurrio un error al validar R.F.C. "
            Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .Tipo = resultado.tipo, .titulo = ""})
          End If
        End If
        Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})
      Else
        resultado = New Result(False)
        For item As Integer = 0 To ModelState.Keys.Count - 1 Step +1
          If ModelState.Values(item).Errors.Count > 0 Then
            Dim val = item
            resultado.Mensaje = resultado.Mensaje + "<br/> - " + objetoModelo.GetType().GetProperties().Where(Function(x) x.Name = ModelState.Keys(val)).SingleOrDefault().
                            GetCustomAttributes(GetType(System.ComponentModel.DataAnnotations.DisplayAttribute), False).
                              Cast(Of System.ComponentModel.DataAnnotations.DisplayAttribute).
                                FirstOrDefault().Name
          End If
        Next
        Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .titulo = "Revisar los siguientes campos !!"})
      End If
    End Function


#End Region

#Region "Promotor"
    <HttpPost>
    <CustomAuthorize(Permisos.Acciones.CATALOGOS_ACTUALIZAR)>
    Public Function GuardarPromotor(promotor As ModeloPromotor) As ActionResult

      Dim resultado

      If ModelState.IsValid Then
        Dim bs = New FactorBAL.Manager()

        FieldsReflect.initialize(promotor)

        TinyMapper.Bind(Of ModeloPromotor, promotor)()  'Mapeo de propiedades Modelo a DTO's
        Dim model = TinyMapper.Map(Of promotor)(promotor)

        If promotor.promotor1 > 0 Then
          resultado = bs.ActualizarPromotor(model)

          If resultado.Ok And resultado IsNot Nothing Then
            resultado.Mensaje = "Registro Actualizado"
            FactorBAL.Utility.Monitor(Session("USERID"), "Actualizado registro de promotor clave  : " + model.promotor1.ToString())
            resultado.tipo = Enumerador.eTipoTransaccion.eActualizar
          Else
            resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro!! {0}" +
                  "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
          End If

        Else

          resultado = bs.AltaPromotor(model)

          If resultado.Ok And resultado IsNot Nothing Then
            resultado.Mensaje = "Registro Guardado"
            FactorBAL.Utility.Monitor(Session("USERID"), "Agregado nuevo registro de promotor clave  : " + model.promotor1.ToString())
            resultado.tipo = Enumerador.eTipoTransaccion.eAlta
          Else
            resultado.Mensaje = String.Format("Ocurrio un error al tratar de guardar el registro!! {0}" +
                  "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
          End If

        End If
        Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo, .titulo = ""})
      Else
        resultado = New Result(False)

        For item As Integer = 0 To ModelState.Keys.Count - 1 Step +1
          If ModelState.Values(item).Errors.Count > 0 Then
            Dim val = item
            resultado.Mensaje = resultado.Mensaje + "<br/> - " + promotor.GetType().GetProperties().Where(Function(x) x.Name = ModelState.Keys(val)).SingleOrDefault().
                            GetCustomAttributes(GetType(System.ComponentModel.DataAnnotations.DisplayAttribute), False).
                              Cast(Of System.ComponentModel.DataAnnotations.DisplayAttribute).
                                FirstOrDefault().Name
          End If
        Next

        Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .titulo = "Revisar los siguientes campos !!"})
      End If


    End Function
#End Region

#Region "Control Riesgo"

    <HttpPost>
    Public Function GuardarControlCliente(modeloRiesgo As ModeloControlRiesgo) As ActionResult

      Dim resultado
      Dim bs = New FactorBAL.Manager()

      TinyMapper.Bind(Of ModeloClientes, clientes)() 'Mapeo de propiedades Modelo a DTO's
      Dim model = TinyMapper.Map(Of clientes)(modeloRiesgo.propCliente)

      resultado = bs.ActualizarControlRiesgoBAL(model)

      If resultado.Ok And resultado IsNot Nothing Then
        resultado.Mensaje = "Informacion Actualizada"
        FactorBAL.Utility.Monitor(Session("USERID"), "Control de Riesgo - Actualizado Control de Riesgo ; vobo : " + model.vobo.ToString() + " voboreg :" + model.voboreg.ToString() + " rgpo : " + model.rgpo.ToString() + " riesgogpo : " + model.riesgogpo.ToString() + " riesgo : " + model.riesgo.ToString())
        resultado.tipo = Enumerador.eTipoTransaccion.eActualizar
      Else
        resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro!! {0}" +
              "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
      End If

      Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})
    End Function

    <HttpPost>
    Public Function GuardarAsociarLineas(model As ModeloControlRiesgo) As ActionResult

      Dim resultado = New Result
      Dim bs = New FactorBAL.Manager()

      'Arreglar esto para cuando no haya registros daba nulo 
      If model.claves.Length > 1 Then


        'Mapeo de propiedades Modelo a DTO's
        TinyMapper.Bind(Of ModeloControlRiesgo, ControlRiesgo)()
        Dim entidad = TinyMapper.Map(Of ControlRiesgo)(model)

        'mapeo Manual de propeidades debido al bug de Tiny Mapper
        entidad.cliente = model.propCliente.cliente

        resultado = bs.ActualizarAsociarLineasBAL(entidad)

        If resultado.Ok And resultado IsNot Nothing Then
          resultado.Mensaje = "Lineas Relacionadas correctamente"
          FactorBAL.Utility.Monitor(Session("USERID"), "Control de Riesgo  - " + " Cliente : " + model.propCliente.cliente.ToString() + ", Creditos Asociados : " + String.Join(",", model.claves) + ", Clave Generada : " + model.idmultiple + ", Cantidad : " + model.lmultiple.ToString())

          resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar 'eActualizar permite enviar al json el tipo para saber si la tabla se recargara 
        Else
          resultado.Mensaje = String.Format("Ocurrio un error al tratar de guardar la informacion !! {0}" +
                "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
        End If

        Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})
      Else
        resultado.Ok = False
        resultado.Detalle = "Se debe seleccionar mas de una linea. "
        resultado.Mensaje = String.Format("Ocurrio un error al tratar de guardar la informacion !! {0}" +
              "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)

        Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})
      End If



    End Function

    <HttpPost>
    Public Function DesasociarLineas(clienteId As Integer) As ActionResult

      Dim resultado
      Dim bs = New FactorBAL.Manager()
      resultado = bs.DesasociarLineasBAL(clienteId)
      If resultado.Ok And resultado IsNot Nothing Then
        resultado.Mensaje = "Lineas desasociadas correctamente"
        FactorBAL.Utility.Monitor(Session("USERID"), "Control de Riesgo - Lineas desasociadas para cliente :" + clienteId.ToString())
        resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar 'eActualizar permite enviar al json el tipo para saber si la tabla se recargara 
      Else
        resultado.Mensaje = String.Format("Ocurrio un error al tratar de guardar la informacion !! {0}" +
              "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
      End If
      Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})
    End Function

    <HttpPost>
    Public Function GuardarGarantiaLiquida(model As ModeloControlRiesgo) As ActionResult

      Dim resultado
      Dim bs = New FactorBAL.Manager()

      'Mapeo de propiedades Modelo a DTO's
      TinyMapper.Bind(Of ModeloControlRiesgo, linea)()
      Dim entidad = TinyMapper.Map(Of linea)(model)
      resultado = bs.ActualizarGarantiaLiquidaBAL(entidad)

      If resultado.Ok And resultado IsNot Nothing Then
        resultado.Mensaje = "Informacion Actualizada"
        FactorBAL.Utility.Monitor(Session("USERID"), "Control de Riesgo - Actualizada Garantia Liquida Cliente : " + model.propCliente.cliente.ToString() + " , Cuenta " + model.cuenta.ToString() + "," + "Porcentaje : " + model.porcentaje.ToString() + "%")
        resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar 'eActualizar permite enviar al json el tipo para saber si la tabla se recargara 
      Else
        resultado.Mensaje = String.Format("Ocurrio un error al tratar de guardar la informacion !! {0}" +
              "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
      End If
      Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})

    End Function

        <HttpPost>
        Public Function GuardardoctoUpd(model As ModeloDocto) As ActionResult

            Dim resultado
            Dim bs = New FactorBAL.Manager()

            'Mapeo de propiedades Modelo a DTO's
            TinyMapper.Bind(Of ModeloDocto, doctos)()
            Dim doc = TinyMapper.Map(Of doctos)(model)
            doc.fec_vence = model.dfec_vence
            resultado = bs.GuardardoctoUpdBAL(doc)

            If resultado.Ok And resultado IsNot Nothing Then
                resultado.Mensaje = "Informacion Actualizada"
                FactorBAL.Utility.Monitor(Session("USERID"), "Documentos - Actualizado docto : " + model.docto())
                resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar 'eActualizar permite enviar al json el tipo para saber si la tabla se recargara 
            Else
                resultado.Mensaje = String.Format("Inconsistencias en la informacion !! {0}" + "{1}", Environment.NewLine, resultado.Detalle)
            End If
            Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})

        End Function

        Public Function GuardarGarantiaWzdUpd(model As ModeloGarantia) As ActionResult

            Dim resultado
            Dim bs = New FactorBAL.Manager()

            'Mapeo de propiedades Modelo a DTO's
            TinyMapper.Bind(Of ModeloGarantia, garantia)()
            Dim gar = TinyMapper.Map(Of garantia)(model)
            resultado = bs.GuardarGarantiaWzdUpdBAL(gar)

            If resultado.Ok And resultado IsNot Nothing Then
                resultado.Mensaje = "Informacion Actualizada"
                FactorBAL.Utility.Monitor(Session("USERID"), "Garantía - Actualizado garantia:  Contrato= " + model.contrato.ToString + ", Cesión= " + model.cesion.ToString)
                resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar 'eActualizar permite enviar al json el tipo para saber si la tabla se recargara 
            Else
                resultado.Mensaje = String.Format("Inconsistencias en la informacion !! {0}" + "{1}", Environment.NewLine, resultado.Detalle)
            End If
            Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})

        End Function

    <HttpPost>
    Public Function CancelarLinea(idRec As String) As ActionResult

      Dim resultado
      Dim bs = New FactorBAL.Manager()
      resultado = bs.CancelarLineaBAL(idRec)
      If resultado.Ok And resultado IsNot Nothing Then
        resultado.Mensaje = "Linea Cancelada"
        FactorBAL.Utility.Monitor(Session("USERID"), "Control de Riesgo Linea cancelada : " + idRec)
        resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar 'eActualizar permite enviar al json el tipo para saber si la tabla se recargara 
      Else
        resultado.Mensaje = String.Format("Ocurrio un error al tratar de cancelar la linea !! {0}" +
              "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
      End If
      Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})
    End Function

    <HttpPost>
    Public Function GuardarClienteLineas(model As ModeloControlRiesgo) As ActionResult

      Dim resultado = New Result
      Dim bs = New FactorBAL.Manager()

      'Arreglar esto para cuando no haya registros daba nulo 
      resultado = bs.GuardarClienteLinea(model.propCliente.cliente, model.propCliente.clientet24)

      If resultado.Ok And resultado IsNot Nothing Then
        FactorBAL.Utility.Monitor(Session("USERID"), "Control de Riesgo - Nueva Linea Registrada Cliente : " + model.propCliente.cliente.ToString() + " , Clave T24 :" + model.propCliente.clientet24.ToString())
        resultado.Mensaje = "Registro Guardado"
        resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar 'eActualizar permite enviar al json el tipo para saber si la tabla se recargara 
      Else
        If resultado.Id_Out <> 1 Then
          resultado.Mensaje = String.Format("Ocurrio un error al tratar de guardar la informacion !! {0}" +
                  "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
        Else
          resultado.Mensaje = String.Format(resultado.Detalle)
        End If

      End If

      Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})

    End Function

    <HttpGet>
    Public Function ReporteCtrlRiesgo(idcliente As Integer, nombre As String) As ActionResult
      Dim localReport = New Microsoft.Reporting.WebForms.LocalReport()

      Dim resultado = New Result
      Dim bs = New FactorBAL.Manager()
      Dim listaRiesgo = New ControlRiesgo_Cliente

      resultado = bs.ReporteCtrlRiesgo(idcliente, listaRiesgo)
      localReport.ReportPath = Server.MapPath("~/Reports/CtrlRiesgoTotales.rdlc")
      localReport.DataSources.Clear()

      Dim reportDataSource = New ReportDataSource()
      reportDataSource.Name = "CtrlRiesgoDS"
      reportDataSource.Value = listaRiesgo.controlRiesgo

      localReport.DataSources.Add(reportDataSource)
      If resultado.Ok And resultado IsNot Nothing Then

        Dim reportType As String = "PDF"
        Dim mimeType As String = ""
        Dim encoding As String = ""
        Dim fileNameExtension As String = ""

        Dim Waring() As Warning = Nothing 'Array
        Dim Streams() As String = Nothing 'Array 
        Dim renderedBytes() As Byte 'Array

        Dim list(5) As ReportParameter
        list(0) = New ReportParameter("TasaCambio", listaRiesgo.cliente.tipoCambio.ToString())
        list(1) = New ReportParameter("NombreCliente", nombre)
        list(2) = New ReportParameter("RiesgoIndividual", listaRiesgo.cliente.riesgo.ToString())
        list(3) = New ReportParameter("RiesgoGrupo", listaRiesgo.cliente.riesgogpo.ToString())
        list(4) = New ReportParameter("Cliente", idcliente.ToString())
        list(5) = New ReportParameter("Usuario", Session("USERID").ToString())

        localReport.SetParameters(list)
        renderedBytes = localReport.Render(reportType, Nothing, mimeType, encoding, fileNameExtension, Streams, Waring)
        If Request.Cookies("reporte") IsNot Nothing Then
          Request.Cookies("reporte").Value = "OK"
          Response.SetCookie(Request.Cookies("reporte"))
        End If
        Response.BufferOutput = False
        Return File(renderedBytes, "pdf", "ReporteControlRiesgo.pdf")

      Else
        Return Content("<script language='javascript' type='text/javascript'>alert('Error al generar el PDF favor de volver a consultar !!\n\nClick Aceptar para volver'); window.location.href ='../Catalogos/ControlRiesgo?clienteId=" + idcliente.ToString() + "&nombre=" + nombre + "';</script>")
      End If

    End Function

#End Region

#Region "Apoderados"
    <HttpPost>
      <CustomAuthorize(Permisos.Acciones.CATALOGOS_ACTUALIZAR)>
    Public Function GuardarApoderado(apoderados As ModeloApoderado) As ActionResult

      Dim resultado

      If ModelState.IsValid Then
        Dim bs = New FactorBAL.Manager()

        FieldsReflect.initialize(apoderados)

        TinyMapper.Bind(Of ModeloApoderado, apoderados)() 'Mapeo de propiedades Modelo a DTO's
        Dim model = TinyMapper.Map(Of apoderados)(apoderados)
        If apoderados.id > 0 Then
          resultado = bs.ActualizarApoderadoBAL(model)

          If resultado.Ok And resultado IsNot Nothing Then
            resultado.Mensaje = "Registro Actualizado"
            FactorBAL.Utility.Monitor(Session("USERID"), "Actualizado registro de apoderado  clave  : " + model.id.ToString())
            resultado.tipo = Enumerador.eTipoTransaccion.eActualizar
          Else
            resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro!! {0}" +
                  "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
          End If

        Else

          resultado = bs.AltaApoderadoBAL(model)

          If resultado.Ok And resultado IsNot Nothing Then
            resultado.Mensaje = "Registro Guardado"
            FactorBAL.Utility.Monitor(Session("USERID"), "Agregado nuevo registro de apoderado  clave  : " + model.id.ToString())
            resultado.tipo = Enumerador.eTipoTransaccion.eAlta
          Else
            resultado.Mensaje = String.Format("Ocurrio un error al tratar de guardar el registro!! {0}" +
                  "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
          End If

        End If
        Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo, .titulo = ""})
      Else
        resultado = New Result(False)

        For item As Integer = 0 To ModelState.Keys.Count - 1 Step +1
          If ModelState.Values(item).Errors.Count > 0 Then
            Dim val = item
            resultado.Mensaje = resultado.Mensaje + "<br/> - " + apoderados.GetType().GetProperties().Where(Function(x) x.Name = ModelState.Keys(val)).SingleOrDefault().
                            GetCustomAttributes(GetType(System.ComponentModel.DataAnnotations.DisplayAttribute), False).
                              Cast(Of System.ComponentModel.DataAnnotations.DisplayAttribute).
                                FirstOrDefault().Name
          End If
        Next

        Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .titulo = "Revisar los siguientes campos !!"})
      End If


    End Function

    <HttpPost>
    Public Function CancelarApoderado(clienteid As Integer) As ActionResult

      Dim resultado
      Dim bs = New FactorBAL.Manager()
      resultado = bs.CancelarApoderadoBAL(clienteid)
      If resultado.Ok And resultado IsNot Nothing Then
        resultado.Mensaje = "Apoderado Cancelado"
        resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar 'eActualizar permite enviar al json el tipo para saber si la tabla se recargara 
      Else
        resultado.Mensaje = String.Format("Ocurrio un error al tratar de cancelar el Apoderado. !! {0}" +
              "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
      End If
      Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})
      Return Nothing
    End Function
#End Region

#Region "Contratos"
    <HttpPost>
    <ValidateIncludeAttributes>
    <CustomAuthorize(Permisos.Acciones.CATALOGOS_ACTUALIZAR)>
    Public Function GuardarContrato(ModeloContrato As Contrato_Cliente) As ActionResult
      Dim resultado
      If ModelState.IsValid Then

        Dim bs = New FactorBAL.Manager()
        ModeloContrato.Contrato.cliente = ModeloContrato.Cliente.cliente 'Mapeamos Cliente que se encuentra en otra propiedad compleja
        TinyMapper.Bind(Of Contrato_Cliente, contratos)()  'Mapeo de propiedades Modelo a DTO's
        Dim model = TinyMapper.Map(Of contratos)(ModeloContrato.Contrato)
        model.sucursal = ModeloContrato.Cliente.sucursal
        model.promotor = ModeloContrato.Cliente.promotor

        FieldsReflect.initialize(model) ' inicializamos todos los campos string a blanco 

        If ModeloContrato.Contrato.contrato > 0 Then
          resultado = bs.ActualizarContratoBAL(model)
          If resultado.Ok And resultado IsNot Nothing Then
            resultado.Mensaje = "Registro Actualizado"
            FactorBAL.Utility.Monitor(Session("USERID"), "Actualizado Contrato : " + model.contrato.ToString())
            resultado.tipo = Enumerador.eTipoTransaccion.eActualizar
          Else
            resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro!! {0}" +
                    "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
          End If


        Else

          resultado = bs.AltaContratoBAL(model)

          If resultado.Ok And resultado IsNot Nothing Then
            resultado.Mensaje = "Registro Guardado"
            FactorBAL.Utility.Monitor(Session("USERID"), "Agregado nuevo contrato clave  : " + model.contrato.ToString())
            resultado.tipo = Enumerador.eTipoTransaccion.eAlta
          Else
            resultado.Mensaje = String.Format("Ocurrio un error al tratar de guardar el registro!! {0}" +
                  "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
          End If
        End If
        Return Json(New With {Key .Result = resultado.Ok, .color = "success", .Text = resultado.Mensaje, .Tipo = resultado.tipo, .titulo = ""})
      Else
        resultado = New Result(False)
        Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = "Problema con uno o mas campos.", .titulo = "Error !!"})
      End If



    End Function

    <HttpPost>
    Public Function CancelarContrato(Contrato As Integer) As ActionResult

      Dim resultado
      Dim bs = New FactorBAL.Manager()
      resultado = bs.CancelarContratoBAL(Contrato)
      If resultado.Ok And resultado IsNot Nothing Then
        FactorBAL.Utility.Monitor(Session("USERID"), "Contrato Cancelado : " + Contrato.ToString())
        resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar 'eActualizar permite enviar al json el tipo para saber si la tabla se recargara 
        If resultado.DetalleServicio Is Nothing Then
          Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .Tipo = resultado.Tipo, .titulo = "Problema"})
        Else
          Return Json(New With {Key .Result = resultado.Ok, .color = "success", .Text = resultado.Mensaje, .Tipo = resultado.Tipo})

        End If
      Else
        resultado.Mensaje = String.Format("Ocurrio un error al tratar de cancelar el contrato !! {0}" +
              "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
        Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .Tipo = resultado.Tipo})
      End If

    End Function
#End Region

#Region "Anexo"

    <HttpPost>
    <ValidateIncludeAttributes()>
    <CustomAuthorize(Permisos.Acciones.CATALOGOS_ACTUALIZAR)>
    Public Function GuardarAnexo(AnexoVM As ModeloAnexoVM) As ActionResult

      Dim resultado

      If ModelState.IsValid Then
        Dim bs = New FactorBAL.Manager()
				TinyMapper.Bind(Of ModeloAnexo, anexo)() 'Mapeo de propiedades Modelo a DTO's
        Dim model = TinyMapper.Map(Of anexo)(AnexoVM.Anexo)
        FieldsReflect.initialize(model)

        If AnexoVM.Anexo.anexoid > 0 Then
          resultado = bs.ActualizarAnexoBAL(model)

          If resultado.Ok And resultado IsNot Nothing Then
            resultado.Mensaje = "Registro Actualizado"
            FactorBAL.Utility.Monitor(Session("USERID"), "Actualizado registro de anexo  Contrato : " + model.contrato.ToString() + " Deudor : " + model.deudor.ToString())
            resultado.tipo = Enumerador.eTipoTransaccion.eActualizar
          Else
            resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro!! {0}" +
                    "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)

          End If
        Else

          resultado = bs.AltaAnexoBAL(model)

          If resultado.Ok And resultado IsNot Nothing Then
            resultado.Mensaje = "Registro Guardado"
            FactorBAL.Utility.Monitor(Session("USERID"), "Nuevo registro de anexo  Contrato : " + model.contrato.ToString() + " Deudor : " + model.deudor.ToString())
            resultado.tipo = Enumerador.eTipoTransaccion.eActualizar
          Else
            resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro!! {0}" +
                    "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)

          End If
        End If

        Return Json(New With {Key .Result = resultado.Ok, .color = "success", .Text = resultado.Mensaje, .Tipo = resultado.Tipo, .titulo = ""})
      Else
        resultado = New Result(False)
        Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .titulo = "Error favor de revisar los campos !!"})
      End If


    End Function





#End Region

#Region "Cesion"
    <HttpPost>
    <ValidateIncludeAttributes>
    <CustomAuthorize(Permisos.Acciones.CATALOGOS_ACTUALIZAR)>
    Public Function GuardarGarantia(ModeloGarantia As ModeloGarantia) As ActionResult
      Dim resultado = New Result(False)
      If ModelState.IsValid Then

        Dim bs = New FactorBAL.Manager()
        TinyMapper.Bind(Of ModeloGarantia, garantia)()   'Mapeo de propiedades Modelo a DTO's
        Dim model = TinyMapper.Map(Of garantia)(ModeloGarantia)

        FieldsReflect.initialize(model) ' inicializamos todos los campos string a blanco 

        If ModeloGarantia.garantiaid > 0 Then
          resultado = bs.ActualizarGarantiaBAL(model)
          If resultado.Ok And resultado IsNot Nothing Then
            resultado.Mensaje = "Registro Actualizado"
            FactorBAL.Utility.Monitor(Session("USERID"), "Actualizada Garantia : " + model.garantiaid.ToString())
            resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar
          Else
            resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro!! {0}" +
                    "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
          End If
        End If
        Return Json(New With {Key .Result = resultado.Ok, .color = "success", .Text = resultado.Mensaje, .Tipo = resultado.Tipo, .titulo = ""})
      Else
        resultado = New Result(False)
        Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = "Problema con uno o mas campos.", .titulo = "Error !!"})
      End If



        End Function



        <HttpPost>
   <ValidateIncludeAttributes>
   <CustomAuthorize(Permisos.Acciones.CATALOGOS_ACTUALIZAR)>
        Public Function CesionWzdUpd(ModeloCesionWzd As ModeloCesionWzd) As ActionResult
            Dim resultado = New Result(False)
            If ModelState.IsValid Then

                Dim cesion_num As Integer = 0
                Dim res = New Result(False)

                Dim bs = New FactorBAL.Manager()

                res = bs.GetCesionNumberBAL(ModeloCesionWzd.cesion, ModeloCesionWzd.contrato, ModeloCesionWzd.idtransact, cesion_num)

                'CesionWzdEntidad()

                Dim model As New cesiones
                model.doctos = ModeloCesionWzd.doctos
                model.fec_alta = ModeloCesionWzd.fec_alta
                model.fec_vence = ModeloCesionWzd.fec_vence
                model.idtransact = ModeloCesionWzd.idtransact
                model.impanticipado = ModeloCesionWzd.impanticipado
                model.importe = ModeloCesionWzd.importe
                model.plazo = ModeloCesionWzd.plazo
                model.tasaoper = ModeloCesionWzd.tasaoper
                model.contrato = ModeloCesionWzd.contrato
                model.userid = ModeloCesionWzd.userid
                model.tinter = ModeloCesionWzd.tinter



                'TinyMapper.Bind(Of ModeloCesionWzd, cesiones)()   'Mapeo de propiedades Modelo a DTO's
                'Dim model = TinyMapper.Map(Of cesiones)(ModeloCesionWzd)

                FieldsReflect.initialize(model) ' inicializamos todos los campos string a blanco 

                model.cesion = cesion_num

                If model.cesion > 0 Then
                    resultado = bs.ActualizarcesionWzdBAL(model)
                Else
                    resultado = bs.AltacesionWzdBAL(model)
                End If

                If resultado.Ok And resultado IsNot Nothing Then
                    resultado.Mensaje = "Registro Actualizado"
                    'FactorBAL.Utility.Monitor(Session("USERID"), "Actualizada Garantia : " + model.garantiaid.ToString())
                    resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar
                Else
                    resultado.Mensaje = String.Format("Inconsistencias en la informacion !! {0}" + "{1}", Environment.NewLine, resultado.Detalle)

                    'resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro!! {0}" +
                    '        "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
                End If


                Return Json(New With {Key .Result = resultado.Ok, .color = "success", .Text = resultado.Mensaje, .Tipo = resultado.Tipo, .titulo = "", .cesion = model.cesion})
            Else
                resultado = New Result(False)

                For item As Integer = 0 To ModelState.Keys.Count - 1 Step +1
                    If ModelState.Values(item).Errors.Count > 0 Then
                        Dim val = item
                        resultado.Mensaje = resultado.Mensaje + "<br/> - " + ModeloCesionWzd.GetType().GetProperties().Where(Function(x) x.Name = ModelState.Keys(val)).SingleOrDefault().
                                        GetCustomAttributes(GetType(System.ComponentModel.DataAnnotations.DisplayAttribute), False).
                                          Cast(Of System.ComponentModel.DataAnnotations.DisplayAttribute).
                                            FirstOrDefault().Name
                    End If
                Next


                Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = "Problema con uno o mas campos. ( " + resultado.Mensaje + " )", .titulo = "Error !!"})
            End If



        End Function


        <HttpPost>
        Public Function CancelargarantiaWzd(garantiaid As Integer) As ActionResult

            Dim resultado
            Dim consulta = New FactorBAL.Manager()

            resultado = consulta.EliminagarantiaBAL(garantiaid)

            If resultado.Ok And resultado IsNot Nothing Then
                resultado.Mensaje = "Registro eliminado"
                FactorBAL.Utility.Monitor(Session("USERID"), "Registro " + garantiaid.ToString() + "Eliminado de cesión ")
                resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar 'eActualizar permite enviar al json el tipo para saber si la tabla se recargara 
            Else
                resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro!! {0}" +
                    "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
            End If

            Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})

        End Function



#End Region

#Region "Usuarios Web"

    <HttpPost>
    <ValidateIncludeAttributes>
    <CustomAuthorize(Permisos.Acciones.CATALOGOS_ACTUALIZAR)>
    Public Function GuardarUsuarioWeb(ModeloContrato As ModeloUsuarioWeb) As ActionResult
      Dim resultado
      If ModelState.IsValid Then

        Dim bs = New FactorBAL.Manager()
        TinyMapper.Bind(Of ModeloUsuarioWeb, usersregs)()  'Mapeo de propiedades Modelo a DTO's
        Dim model = TinyMapper.Map(Of usersregs)(ModeloContrato)

        resultado = bs.ActualizarUsuarioWebBAL(model)
        If resultado.Ok And resultado IsNot Nothing Then
          resultado.Mensaje = "Registro Guardado"
          FactorBAL.Utility.Monitor(Session("USERID"), "Actualizado Usuario web : " + model.folio.ToString())
          resultado.tipo = Enumerador.eTipoTransaccion.eActualizar
        Else
          resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro!! {0}" +
                  "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
        End If
        Return Json(New With {Key .Result = resultado.Ok, .color = "success", .Text = resultado.Mensaje, .Tipo = resultado.tipo, .titulo = ""})
      Else
        resultado = New Result(False)
        Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = "Problema con uno o mas campos.", .titulo = "Error !!"})
      End If

    End Function

    <HttpPost>
    Public Function GenerarPassword(folio As Integer) As ActionResult
      Dim resultado
      Dim bs = New FactorBAL.Manager()
      resultado = bs.GenerarPasswordBAL(folio)
      If resultado.Ok And resultado IsNot Nothing Then
        resultado.Mensaje = "Password temporal generado y enviado correctamente"
        FactorBAL.Utility.Monitor(Session("USERID"), "Generacion de password para usuario Web folio : " + folio.ToString())
        resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar 'eActualizar permite enviar al json el tipo para saber si la tabla se recargara 
        Return Json(New With {Key .Result = resultado.Ok, .color = "success", .Text = resultado.Mensaje, .Tipo = resultado.tipo, .titulo = ""})
      Else
        resultado.Mensaje = String.Format("Ocurrio un error al tratar de generar el password!! {0}" +
              "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
        Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .Tipo = resultado.tipo, .titulo = ""})
      End If

    End Function


#End Region

#End Region

#Region "Validaciones"
		<HttpGet>
		Public Function ValidarProveedorRFC(rfc As String, Optional deudor As Integer = 0) As ActionResult

			Dim jresult = New JsonResult()
			Dim resultado
			Dim validaciones = New RepositorioValidacion()
			Dim existe = False
			Dim resp = "nombre"
			resultado = validaciones.ValidarRFC(rfc, "proveedor", resp, "deudor ", "RFC", "deudor", deudor, existe)

			If resultado.Ok And resultado IsNot Nothing Then
				If existe Then
					jresult = Json("R.F.C. ya existe </br>" + resp, JsonRequestBehavior.AllowGet)
				Else
					jresult = Json("true", JsonRequestBehavior.AllowGet)
				End If
			Else
				resultado.Mensaje = "Ocurrio un error al validar R.F.C. "
				jresult = Json(resultado.Mensaje, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function
		<HttpGet>
		Public Function validaSirac(sirac As Integer, Optional deudor As Integer = 0) As ActionResult

			Dim jresult = New JsonResult()
			Dim resultado
			Dim validaciones = New RepositorioValidacion()
			Dim existe = False
			Dim nombre As String = Nothing
			resultado = validaciones.validarSirac(sirac, deudor, existe, nombre)

			If resultado.Ok And resultado IsNot Nothing Then
				If existe Then
					jresult = Json("No. Sirac ya existe en proveedor " + nombre + " :</br>", JsonRequestBehavior.AllowGet)
				Else
					jresult = Json("true", JsonRequestBehavior.AllowGet)
				End If
			Else
				resultado.Mensaje = "Ocurrio un error al validar Sirac "
				jresult = Json(resultado.Mensaje, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function
		<HttpGet>
		Public Function validaFira(fira_idcon As Decimal, Optional deudor As Integer = 0) As ActionResult

			Dim jresult = New JsonResult()
			Dim resultado
			Dim validaciones = New RepositorioValidacion()
			Dim existe = False
			Dim nombre As String = Nothing
			resultado = validaciones.validarFira(fira_idcon, deudor, existe, nombre)

			If resultado.Ok And resultado IsNot Nothing Then
				If existe Then
					jresult = Json("No. fira ya existe en proveedor " + nombre + " :</br>", JsonRequestBehavior.AllowGet)
				Else
					jresult = Json("true", JsonRequestBehavior.AllowGet)
				End If
			Else
				resultado.Mensaje = "Ocurrio un error al validar Sirac "
				jresult = Json(resultado.Mensaje, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function
		<HttpGet>
		Public Function ValidarClienteRFC(rfc As String, Optional cliente As Integer = 0) As ActionResult

			Dim jresult = New JsonResult()
			Dim resultado
			Dim validaciones = New RepositorioValidacion()
			Dim existe = False
			Dim resp = "nombre"
			resultado = validaciones.ValidarRFC(rfc, "clientes", resp, "cliente ", "RFC", "cliente", cliente, existe)

			If resultado.Ok And resultado IsNot Nothing Then
				If existe Then
					jresult = Json("R.F.C. ya existe </br>" + resp, JsonRequestBehavior.AllowGet)
				Else
					jresult = Json("true", JsonRequestBehavior.AllowGet)
				End If
			Else
				resultado.Mensaje = "Ocurrio un error al validar R.F.C."
				jresult = Json(resultado.Mensaje, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function
		<HttpGet>
		Public Function ValidarCompradorRFC(rfc As String, Optional deudor As Integer = 0) As ActionResult

			Dim jresult = New JsonResult()
			Dim resultado
			Dim validaciones = New RepositorioValidacion()
			Dim existe = False
			Dim resp = "nombre"
			resultado = validaciones.ValidarRFC(rfc, "comprador", resp, "deudor", "RFC", "deudor", deudor, existe)

			If resultado.Ok And resultado IsNot Nothing Then
				If existe Then
					jresult = Json("R.F.C. ya existe </br>" + resp, JsonRequestBehavior.AllowGet)
				Else
					jresult = Json("true", JsonRequestBehavior.AllowGet)
				End If
			Else
				resultado.Mensaje = "Ocurrio un error al validar R.F.C."
				jresult = Json(resultado.Mensaje, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function
		Public Function ValidaDeudor(<Bind(Prefix:="Anexo.deudor")> deudor As Integer, <Bind(Prefix:="Anexo.producto")> Optional producto As Integer = 0, <Bind(Prefix:="Anexo.contrato")> Optional contrato As Integer = 0, <Bind(Prefix:="Anexo.anexoid")> Optional anexoid As Integer = 0) As ActionResult
			Dim jresult = New JsonResult()
			Dim resultado
			Dim validaciones = New RepositorioValidacion()
			Dim existe = False
			resultado = validaciones.ValidaDeudor(deudor, producto, existe)

			'si anexo id es 0 significa que sera una alta 
			If anexoid = 0 Then
				If resultado.Ok And resultado IsNot Nothing Then
					If existe Then
						Dim nombre As String = ""
						resultado = validaciones.ExisteAnexoContrato_Deudor(deudor, contrato, nombre, producto, existe)

						If resultado.ok And resultado IsNot Nothing Then
							If existe Then
								jresult = Json("Clave de deudor ya existe con este contrato", JsonRequestBehavior.AllowGet)
							Else
								Response.AddHeader("X-Nombre", nombre.Trim())
								jresult = Json("true", JsonRequestBehavior.AllowGet)
							End If
						End If


					Else
						If producto = 13 Then
							jresult = Json("Clave de deudor en proveedor no existe.", JsonRequestBehavior.AllowGet)
						Else
							jresult = Json("Clave de deudor en comprador no existe.", JsonRequestBehavior.AllowGet)
						End If

					End If
				Else
					resultado.Mensaje = "Ocurrio un error al validar el deudor ."
					jresult = Json(resultado.Mensaje, JsonRequestBehavior.AllowGet)
				End If
			Else
				jresult = Json("true", JsonRequestBehavior.AllowGet)
			End If

			Return jresult
		End Function
#End Region

	End Class
End Namespace



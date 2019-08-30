Imports FactorEntidades
Imports FactorBAL
Imports System.IO
Imports System.Net

<CustomAuthorize(Permisos.Acciones.FACTURACION)>
Public Class FacturacionController
	Inherits System.Web.Mvc.Controller





#Region "Views"

	<HttpGet>
	Function index() As ViewResult
		Dim model As New Helpers.Menu

		model.sMenu = "<div class=""BoxFlex"" id="""" >"
		model.sMenu &= "<div class=""BoxFlexShadow"">"
		model.sMenu &= "<label>Regresar</label>"
		model.sMenu &= "<a href=""../Operaciones/Index""> <img src=""../Images/regresar_gris.png""/> </a>"
		model.sMenu &= "</div>"
		model.sMenu &= "</div>"

		model.sMenu &= "<div class=""BoxFlex"" id=""dvflexFacturacion"" >"
		model.sMenu &= "<div class=""BoxFlexShadow"">"
		model.sMenu &= "<p>Histórico de facturas</p>"
		model.sMenu &= "</div>"
		model.sMenu &= "</div>"


		model.sMenu &= "<div class=""BoxFlex"" id=""dvflexcomplementopago"" >"
		model.sMenu &= "<div class=""BoxFlexShadow"">"
		model.sMenu &= "<p>Histórico de complementos</p>"
		model.sMenu &= "</div>"
		model.sMenu &= "</div>"

		Return View(model)

	End Function

	<HttpGet>
	Function HistorialFacturas() As ViewResult
		Dim model = New Facturacion.FacturacionModel
		model.Cargacontroles()
		Return View(model)
	End Function

	Function NuevaFactura(tipo As String) As ActionResult
		Dim model = New Facturacion.fiscalPfModel()
		Dim vista As String = ""

		Select Case tipo
			Case Is = "A"
				vista = "../Facturacion/FacturasManuales"

			Case Is = "B"
				vista = "../Facturacion/NotasCredito"

			Case Is = "C"
				vista = "../Facturacion/NotasCargo"

			Case Is = "D"
				vista = "../Facturacion/Remisiones"

		End Select
		model.CargaControles(tipo)
		model.serie = tipo

		Return PartialView(vista, model)
	End Function

	Function GeneraForm() As ActionResult
		Return PartialView("../Facturacion/GeneraIndicium")
	End Function

	<HttpGet>
	Function complementopago() As ViewResult

		Return View()
	End Function

#End Region

#Region "GET"

	Public Function ConsultaFacturas(serie As String, fecha As String) As ActionResult
		Dim jresult
		Dim resultado
		Dim consulta = New FacturacionBAL()
		Dim histFacturas = New List(Of FacturacionEntidad)

		Dim fechaI As Date = Date.Parse(fecha)

		resultado = consulta.ConsultaFacturasBAL(histFacturas, serie, fechaI)

		If resultado.ok And resultado IsNot Nothing Then
			jresult = Json(New With {Key .results = histFacturas}, JsonRequestBehavior.AllowGet)
			jresult.MaxJsonLength = Integer.MaxValue
		Else
			jresult = Json(New With {Key .Mensaje = resultado.mensaje}, JsonRequestBehavior.AllowGet)
		End If

		Return jresult
	End Function

	Public Function ConsultaDetalle(sisfol As Integer, serie As String) As ActionResult
		Dim jresult
		Dim resultado
		Dim consulta = New FacturacionBAL()
		Dim list = New List(Of fiscalpv)

		resultado = consulta.ConsultaDetalleBAL(list, sisfol, serie)

		If resultado.ok And resultado IsNot Nothing Then
			If list.Count() > 0 Then
				jresult = Json(New With {Key .results = list}, JsonRequestBehavior.AllowGet)
				jresult.MaxJsonLength = Integer.MaxValue
			Else
				jresult = Json(New With {Key .Mensaje = "0"}, JsonRequestBehavior.AllowGet)
			End If
		Else
			jresult = Json(New With {Key .Mensaje = resultado.mensaje}, JsonRequestBehavior.AllowGet)
		End If

		Return jresult
	End Function

	Public Function GetContrato(contrato As Integer) As ActionResult
		Dim jresult
		Dim model = New FacturacionEntidad
		Dim resultado
		Dim consulta = New FacturacionBAL()

		resultado = consulta.GetContratoBAL(contrato, model)

		If resultado.ok Then
			If model Is Nothing Then
				resultado.Mensaje = "No se encontró el contrato."
				'model.nombre = ""
			Else
				resultado.Mensaje = "0"
			End If
			jresult = Json(New With {Key .nombre = model.nombre.Trim(), .cliente = model.cliente, .contrato = model.contrato, .Mensaje = resultado.Mensaje}, JsonRequestBehavior.AllowGet)
		Else
			resultado.Mensaje = "Error al consultar el contrato"
			jresult = Json(New With {Key .mensaje = resultado.Mensaje}, JsonRequestBehavior.AllowGet)

		End If

		Return jresult
	End Function

	Public Function GetId(deudor As Integer, id As Integer, identidad As String) As ActionResult
		Dim jresult
		Dim resultado = New Result(False)
		Dim consulta = New FacturacionBAL()
		Dim nombre As String = ""
		resultado = consulta.GetIdBAL(deudor, id, nombre)

		If resultado.Ok Then
			jresult = Json(New With {Key .nombre = nombre, .Mensaje = "0"}, JsonRequestBehavior.AllowGet)
		Else
			jresult = Json(New With {.Mensaje = resultado.Mensaje + identidad}, JsonRequestBehavior.AllowGet)
		End If

		Return jresult
	End Function

	Public Function GetPorcentaje(contrato As String) As ActionResult
		Dim jresult
		Dim porcentaje As Decimal = 0
		Dim consulta = New FacturacionBAL()
		Dim resultado = New Result()
		Dim contrato1 As Integer

		Integer.TryParse(contrato, contrato1)

		resultado = consulta.GetPorcentajeBAL(contrato1, porcentaje)

		If resultado.Ok And resultado IsNot Nothing Then
			jresult = Json(New With {Key .porcentaje = porcentaje, .Mensaje = "0"}, JsonRequestBehavior.AllowGet)
		Else
			jresult = Json(New With {Key .porcentaje = porcentaje, .Mensaje = ""}, JsonRequestBehavior.AllowGet)
		End If


		Return jresult
	End Function

	Public Function ValidDoctos(sisfol As Integer, serie As String) As ActionResult
		Dim jresult
		Dim resultado = New Result(False)
		Dim consulta = New FacturacionBAL()
		Dim model = New FacturacionEntidad
		Dim aplicaA As Boolean = False
		Dim aplicaF As Boolean = False

		resultado = consulta.ValidDoctosBAL(sisfol, serie, model)

		If resultado.Ok Then
			If model IsNot Nothing Then
				jresult = Json(New With {Key .saldo = model.saldo, .contrato = model.contrato,
										 .aplicarFactura = model.aplicarFactura, .aplicarAdeudo = model.aplicarAdeudo,
										 .folio = model.folio, .Mensaje = resultado.Mensaje}, JsonRequestBehavior.AllowGet)
			Else
				jresult = Json(New With {Key .Mensaje = resultado.Mensaje}, JsonRequestBehavior.AllowGet)
			End If
		Else
			jresult = Json(New With {Key .Mensaje = resultado.Mensaje}, JsonRequestBehavior.AllowGet)
		End If

		Return jresult
	End Function

	Public Function GetFileFactura(factura As String, tipo As Integer) As FileResult
		Dim resultado = New Result(False)
		Dim consulta = New FacturacionBAL()
		Dim consultaUrl = New Utility()
		Dim archivo As Byte() = Nothing
		Dim extension As String = IIf(tipo = 1, ".pdf", ".xml")
		Dim url As String = ""

		consultaUrl.ConsultaParametroBAL("Temporal", url)

		resultado = consulta.GetPdfBAL(factura, archivo, tipo)

		If resultado.Ok And archivo IsNot Nothing Then

			'url += "\" + factura + extension
			'Dim fs As FileStream = New FileStream(url, FileMode.Create)
			'fs.Write(archivo, 0, archivo.Length)
			'fs.Close()

			Return File(archivo, "application/" + extension, factura + extension)
		Else

			'url = url + "\error.txt"
			'Dim txt As FileStream = New FileStream(My.Computer.FileSystem.SpecialDirectories.Temp, FileMode.Create)
			archivo = System.Text.Encoding.ASCII.GetBytes(resultado.Mensaje)
			'txt.Write(archivo, 0, archivo.Length)
			'txt.Close()

			Return File(archivo, "application/txt", factura + ".txt")
		End If

		'Return File(archivo, "application/" + extension, factura + extension)

	End Function

	<HttpPost>
	Public Function EnviarFactura(factura As String, identidad As Integer, id As Integer, numrec As Integer, tipo As Integer) As JsonResult
		Dim resultado = New Result(False)
		Dim jresult = New JsonResult()
		Dim consulta = New FacturacionBAL()
		Dim url As String = ""

		resultado = consulta.enviarFacturaBAL(factura, identidad, id, numrec, tipo)

		If resultado.Ok Then
			jresult = Json(New With {Key .ok = True, .mensaje = "Correo enviado"}, JsonRequestBehavior.AllowGet)
		Else
			jresult = Json(New With {Key .ok = False, .mensaje = "Error al enviar correo , favor de volver a intentar"}, JsonRequestBehavior.AllowGet)
		End If

		Return jresult

	End Function

	<HttpPost>
	Public Function EnvioMasivo(fecha As String, tipo As Integer) As JsonResult
		Dim resultado = New Result(False)
		Dim jresult = New JsonResult()
		Dim consulta = New FacturacionBAL()
		Dim url As String = ""

		Dim fechaI As Date = Date.Parse(fecha)

		resultado = consulta.EnvioMasivoBal(fecha, tipo)

		If resultado.Ok Then
			If resultado.Id_Out = 0 Then
				jresult = Json(New With {Key .ok = True, .mensaje = "No hay correos por enviar"}, JsonRequestBehavior.AllowGet)
			Else
				jresult = Json(New With {Key .ok = True, .mensaje = "Correo enviado"}, JsonRequestBehavior.AllowGet)
			End If
		Else
			jresult = Json(New With {Key .ok = False, .mensaje = "Error al enviar correo , favor de volver a intentar"}, JsonRequestBehavior.AllowGet)
		End If

		Return jresult

	End Function


	Public Function consultaComplemento(tipo As Integer, fecha As String) As ActionResult
		Dim jresult
		Dim resultado
		Dim consulta = New FacturacionBAL()
		Dim lista = New List(Of FacturacionEntidad)

		Dim fechaI As Date = Date.Parse(fecha)

		resultado = consulta.ConsultaComplemento(tipo, fechaI, lista)

		If resultado.ok And resultado IsNot Nothing Then
			jresult = Json(New With {Key .Results = lista}, JsonRequestBehavior.AllowGet)
			jresult.MaxJsonLength = Integer.MaxValue
		Else
			jresult = Json(New With {Key .Mensaje = resultado.mensaje}, JsonRequestBehavior.AllowGet)
		End If

		Return jresult
	End Function



#End Region

#Region "Transaccionales"

	<CustomAuthorize(Permisos.Acciones.FACTURACION_ACTUALIZAR)>
	Public Function GuardarFactura(model As FacturacionEntidad) As ActionResult
		Dim resultado = New Result(False)
		Dim consulta = New FacturacionBAL()
		Dim jresult
		Dim process As Boolean = False
		resultado = consulta.GuardarFacturaBAL(model)

		If resultado.Ok Then
			jresult = Json(New With {Key .Mensaje = "Factura guardada correctamente", .Ok = resultado.Ok, .process = True}, JsonRequestBehavior.AllowGet)
			Utility.Monitor(Session("userid"), "Dio de alta la factura con folio del sistema A - " & model.sisfol.ToString() & " por la cantidad de $ " + model.importe.ToString())
		Else
			jresult = Json(New With {Key .Mensaje = "No se pudo guardad la factura", .Ok = resultado.Ok, .process = process}, JsonRequestBehavior.AllowGet)
		End If

		Return jresult
	End Function

	<CustomAuthorize(Permisos.Acciones.FACTURACION_ACTUALIZAR)>
	Public Function GuardarNotaCredito(model As FacturacionEntidad) As ActionResult
		Dim jresult
		Dim consulta = New FacturacionBAL()
		Dim resultado = New Result(False)
		Dim process As Boolean = False

		resultado = consulta.GuardarNotaCreditoBAL(model, process)

		If resultado.Ok And resultado IsNot Nothing Then
			jresult = Json(New With {Key .Mensaje = resultado.Mensaje, .ok = resultado.Ok, .process = process}, JsonRequestBehavior.AllowGet)
			Utility.Monitor(Session("userid"), "Dio de alta la Nota de crédito con folio del sistema B - " & model.sisfol & " por la cantidad de $" & model.importe.ToString())
		Else
			jresult = Json(New With {Key .Mensaje = resultado.Mensaje, .ok = resultado.Ok, .process = process}, JsonRequestBehavior.AllowGet)
		End If

		Return jresult
	End Function

	<CustomAuthorize(Permisos.Acciones.FACTURACION_ACTUALIZAR)>
	Public Function GuardarRemisiones(model As FacturacionEntidad) As ActionResult
		Dim jresult
		Dim consulta = New FacturacionBAL()
		Dim resultado = New Result(False)
		Dim process As Boolean = False

		resultado = consulta.GuardarRemisionesBAL(model, process)

		If resultado.Ok Then
			jresult = Json(New With {Key .Mensaje = resultado.Mensaje, .process = True, .Ok = resultado.Ok}, JsonRequestBehavior.AllowGet)
			Utility.Monitor(Session("userid"), "Dio de alta la remisión con folio del sistema D - " & model.sisfol.ToString() + " por la cantidad de $" & model.importe.ToString())
		Else
			jresult = Json(New With {Key .Mensaje = resultado.Mensaje, .process = False, .Ok = resultado.Ok}, JsonRequestBehavior.AllowGet)
		End If

		Return jresult
	End Function

	<CustomAuthorize(Permisos.Acciones.FACTURACION_ACTUALIZAR)>
	Public Function CancelarFactura(serie As String, sisfol As String) As ActionResult
		Dim jresult
		Dim response = New Result(False)
		Dim consulta = New FacturacionBAL()
		Dim process As String = ""


		response = consulta.CancelarFacturaBAL(serie, sisfol, process)

		If response.Ok And response IsNot Nothing Then
			jresult = Json(New With {Key .Mensaje = response.Mensaje, .process = "1"}, JsonRequestBehavior.AllowGet)
			Utility.Monitor(Session("userid"), "Cancelación factura sisfol " + sisfol + ", serie " + serie)
		Else
			jresult = Json(New With {Key .Mensajee = response.Mensaje, .process = "0"}, JsonRequestBehavior.AllowGet)
		End If

		Return jresult
	End Function

	<CustomAuthorize(Permisos.Acciones.FACTURACION_ACTUALIZAR)>
	Public Function SustituirFolioSat(sat As Integer) As ActionResult
		Dim jresult
		Dim consulta = New FacturacionBAL()
		Dim resultado = New Result(False)
		Dim process As String = ""

		resultado = consulta.SustituirFolioSatBAL(sat, process)

		jresult = Json(New With {Key .Mensaje = resultado.Mensaje, .ok = resultado.Ok, .Process = process}, JsonRequestBehavior.AllowGet)

		Return jresult
	End Function

	<CustomAuthorize(Permisos.Acciones.FACTURACION_ACTUALIZAR)>
	Public Function Generar(fecha As String) As ActionResult
		Dim jresult
		Dim consulta = New FacturacionBAL()
		Dim resultado = New Result(False)
		Dim process As String = ""
		resultado = consulta.GenerarBAL(fecha, process)

		jresult = Json(New With {Key .Mensaje = resultado.Mensaje, .ok = resultado.Ok, .process = process}, JsonRequestBehavior.AllowGet)

		Return jresult
	End Function



#End Region

End Class
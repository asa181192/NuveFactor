﻿Imports FactorEntidades
Imports Nelibur.ObjectMapper
Imports nuve.Models
Imports Microsoft.Reporting.WebForms
Imports System.Reflection
Imports System.Globalization
Imports FactorBAL
Imports System.IO
Imports System.Data
Imports System.Threading.Tasks


Namespace nuve
	Public Class reportesController
		Inherits Controller
#Region "Views"

		Function Informes() As ActionResult
			Dim model = New ModeloInformes()
			Return View(model)
		End Function

		<HttpGet>
		Function Informecobros() As ViewResult
			Return View()
		End Function

		<HttpGet>
		Function Adeudosxliquidar() As ViewResult
			Return View()
		End Function


		<HttpGet>
		Function Reportes() As ViewResult
			Dim model = New Helpers.Menu

			model.sMenu = "<div class=""BoxFlex"" id="""" >"
			model.sMenu &= "<div class=""BoxFlexShadow"">"
			model.sMenu &= "<label>Regresar</label>"
			model.sMenu &= "<a href=""../Home/Welcome""> <img src=""../Images/regresar_gris.png""/> </a>"
			model.sMenu &= "</div>"
			model.sMenu &= "</div>"

			model.sMenu &= "<div class=""BoxFlex"" id=""dvflexVencimientoNAFIN"" >"
			model.sMenu &= "<div class=""BoxFlexShadow"">"
			model.sMenu &= "<p>Vencimientos Fondeo NAFIN</p>"
			model.sMenu &= "</div>"
			model.sMenu &= "</div>"

			Return View(model)
		End Function

		<HttpGet>
		Function ReporteVNAFIN() As ViewResult
			Return View()
		End Function


		<HttpGet>
		Function ReportesDeposito() As ViewResult
			Dim model = New Reportes.ReporteDepModel
			model.CargaControles()
			Return View(model)
		End Function

		Function ReporteSalidas() As ViewResult
			Dim model = New Reportes.ReporteDepModel
			model.CargaControles()
			Return View(model)
		End Function

		<HttpGet>
		Function ReporteSaldos() As ViewResult
			Dim model = New Reportes.reporteSaldos
			model.CargaControles()
			Return View(model)
		End Function

		<HttpGet>
		Function HistoriaDocumento() As ViewResult
			Return View()
		End Function

		<HttpGet>
		Function ReporteLineasFactor() As ViewResult

			Return View()
		End Function

		Function DocPorDescontar() As ViewResult

			Return View()
		End Function

		Function HistoriaAdeudo() As ViewResult

			Return View()
		End Function

		Function GraficaPie() As ActionResult
			Return View()
		End Function

		Function GraficaLinea() As ActionResult
			Return View()
		End Function

		Function GraficaCartera() As ActionResult
			Return View()
		End Function

		Function GraficaBarra() As ActionResult
			Return View()
		End Function

		<HttpGet>
		Function Rebatemensual() As ViewResult
			Return View()
		End Function

#End Region

#Region "Reportes"

		Public Function Reportecobranza(fecha As String, contrato As Integer) As ActionResult

			Dim localReport = New Microsoft.Reporting.WebForms.LocalReport()

			Dim a = New Result(False)
			Dim resultado = New Result
			Dim bs = New FactorBAL.ReportesBAL()
			Dim cobros = New List(Of CobranzaEntidad)

			resultado = bs.ReportecobranzaBAL(fecha, contrato, cobros)
			localReport.ReportPath = Server.MapPath("~/Reports/Reportecobranza.rdlc")

			Dim reportDataSource = New ReportDataSource()
			reportDataSource.Name = "Informacobros"
			reportDataSource.Value = cobros

			localReport.DataSources.Clear()

			localReport.DataSources.Add(reportDataSource)

			If resultado.Ok And resultado IsNot Nothing Then

				Dim reportType As String = "PDF"
				Dim mimeType As String = ""
				Dim encoding As String = ""
				Dim fileNameExtension As String = ""

				Dim Waring() As Warning = Nothing 'Array
				Dim Streams() As String = Nothing 'Array 
				Dim renderedBytes() As Byte	'Array

				Dim list(0) As ReportParameter
				list(0) = New ReportParameter("Usuario", Session("USERID").ToString())

				localReport.SetParameters(list)
				renderedBytes = localReport.Render(reportType, Nothing, mimeType, encoding, fileNameExtension, Streams, Waring)
				If Request.Cookies("reporte") IsNot Nothing Then
					Request.Cookies("reporte").Value = "OK"
				End If
				Response.SetCookie(Request.Cookies("reporte"))
				Return File(renderedBytes, "pdf", "Informacioncobros.pdf")

			Else
				Return Content("<script language='javascript' type='text/javascript'>alert('Error al generar el PDF favor de volver a consultar !!\n\nClick Aceptar para volver'); window.location.href ='../Informes/Informescbros")
				'+ idcliente.ToString() + "&nombre=" + nombre + "';</script>")

			End If

		End Function

		Public Function Reporteaforo(fecha As String, contrato As Integer) As ActionResult

			Dim localReport = New Microsoft.Reporting.WebForms.LocalReport()

			Dim a = New Result(False)
			Dim resultado = New Result
			Dim bs = New FactorBAL.ReportesBAL()
			Dim cobros = New List(Of CobranzaEntidad)

			resultado = bs.ReporteaforoBAL(fecha, contrato, cobros)
			localReport.ReportPath = Server.MapPath("~/Reports/Reporteaforo.rdlc")

			Dim reportDataSource = New ReportDataSource()
			reportDataSource.Name = "Reporteaforo"
			reportDataSource.Value = cobros

			localReport.DataSources.Clear()

			localReport.DataSources.Add(reportDataSource)

			If resultado.Ok And resultado IsNot Nothing Then

				Dim reportType As String = "PDF"
				Dim mimeType As String = ""
				Dim encoding As String = ""
				Dim fileNameExtension As String = ""

				Dim Waring() As Warning = Nothing 'Array
				Dim Streams() As String = Nothing 'Array 
				Dim renderedBytes() As Byte	'Array

				Dim list(0) As ReportParameter
				list(0) = New ReportParameter("Usuario", Session("USERID").ToString())

				localReport.SetParameters(list)
				renderedBytes = localReport.Render(reportType, Nothing, mimeType, encoding, fileNameExtension, Streams, Waring)
				If Request.Cookies("reporte") IsNot Nothing Then
					Request.Cookies("reporte").Value = "OK"
				End If
				Response.SetCookie(Request.Cookies("reporte"))
				Return File(renderedBytes, "pdf", "Reporteaforo.pdf")

			Else
				Dim archivo As Byte() = Nothing
				Dim url = "\\192.168.121.237\Files\temp\"
				url = url + "Reporte.txt"
				Dim txt As FileStream = New FileStream(url, FileMode.Create)
				archivo = System.Text.Encoding.ASCII.GetBytes("NO SE ENCONTRO INFORMACION!!")
				txt.Write(archivo, 0, archivo.Length)
				txt.Close()

				If Request.Cookies("reporte") IsNot Nothing Then
					Request.Cookies("reporte").Value = "OK"
				End If
				Response.SetCookie(Request.Cookies("reporte"))
				Return File(archivo, "application/txt", "Reporte.txt")

			End If

		End Function

		Public Function Reporteadeudos(moneda As String, tipo As String) As ActionResult

			Dim localReport = New Microsoft.Reporting.WebForms.LocalReport()

			Dim a = New Result(False)
			Dim resultado = New Result
			Dim bs = New FactorBAL.ReportesBAL()
			Dim ut = New FactorBAL.Utility()

			Dim adeudos = New List(Of adeudosEntidad)
			resultado = bs.ReporteadeudosBAL(moneda, adeudos)

			'Dim otabla = ut.ConvertToDataTable(adeudos)
			'Dim sreporte = ut.ExportToExcel(otabla)

			localReport.ReportPath = Server.MapPath("~/Reports/Reporteadeudos.rdlc")

			Dim reportDataSource = New ReportDataSource()
			reportDataSource.Name = "Reporteadeudos"
			reportDataSource.Value = adeudos

			localReport.DataSources.Clear()

			localReport.DataSources.Add(reportDataSource)

			If resultado.Ok And resultado IsNot Nothing Then


				Dim reportType As String = If(tipo = "XLS", "EXCEL", "PDF")
				Dim mimeType As String = ""
				Dim encoding As String = ""
				Dim fileNameExtension As String = ""

				Dim Waring() As Warning = Nothing 'Array
				Dim Streams() As String = Nothing 'Array 
				Dim renderedBytes() As Byte	'Array

				Dim list(1) As ReportParameter
				list(0) = New ReportParameter("Usuario", Session("USERID").ToString())
				list(1) = New ReportParameter("moneda", If(moneda = "1", "Moneda Nacional", "Dólares"))

				localReport.SetParameters(list)
				renderedBytes = localReport.Render(reportType, Nothing, mimeType, encoding, fileNameExtension, Streams, Waring)
				If Request.Cookies("reporte") IsNot Nothing Then
					Request.Cookies("reporte").Value = "OK"
				End If
				Response.SetCookie(Request.Cookies("reporte"))
				If (tipo = "PDF") Then
					Return File(renderedBytes, tipo, "Reporteadeudos." + tipo)
				Else
					Return File(renderedBytes, tipo, "Reporteadeudos.xls")

				End If




			Else
				Return Content("<script language='javascript' type='text/javascript'>alert('Error al generar el PDF favor de volver a consultar !!\n\nClick Aceptar para volver'); window.location.href ='../Informes/Informescbros")
				'+ idcliente.ToString() + "&nombre=" + nombre + "';</script>")

			End If

		End Function

		<HttpGet>
		Public Function ReporteDocPorDescontar(opcion As Boolean, Optional contrato As Integer = 0) As ActionResult

			Dim localReport = New Microsoft.Reporting.WebForms.LocalReport()

			Dim resultado = New Result
			Dim bs = New FactorBAL.ReportesBAL()
			Dim lista = New List(Of SP_ReporteDocSinDescontar)

			resultado = bs.ReporteDocPorDescontarBAL(opcion, contrato, lista)
			localReport.ReportPath = Server.MapPath("~/Reports/ReporteDocSinDescontar.rdlc")

			Dim reportDataSource = New ReportDataSource()
			reportDataSource.Name = "DocSinDescontar"
			reportDataSource.Value = lista

			localReport.DataSources.Clear()

			localReport.DataSources.Add(reportDataSource)

			If resultado.Ok And resultado IsNot Nothing Then

				Dim reportType As String = "PDF"
				Dim mimeType As String = ""
				Dim encoding As String = ""
				Dim fileNameExtension As String = ""

				Dim Waring() As Warning = Nothing 'Array
				Dim Streams() As String = Nothing 'Array 
				Dim renderedBytes() As Byte	'Array

				renderedBytes = localReport.Render(reportType, Nothing, mimeType, encoding, fileNameExtension, Streams, Waring)
				If Request.Cookies("reporte") IsNot Nothing Then
					Request.Cookies("reporte").Value = "OK"
				End If
				Response.SetCookie(Request.Cookies("reporte"))
				Return File(renderedBytes, "pdf", "Reporte.pdf")
			Else
				Return Nothing
			End If


		End Function

#End Region



#Region "Get"

#Region "Vencimientos Nafin"

		Public Function ReporteVencimientosNAFIN(moneda As String, tipo As String, inicio1 As String, fin1 As String) As ActionResult
			Dim localReport = New Microsoft.Reporting.WebForms.LocalReport()
			Dim inicio As Date
			Dim fin As Date



			If inicio1 Is Nothing Or inicio1 = "" Then
				inicio = Today.Date
			Else
				inicio = Date.Parse(inicio1)
			End If

			If fin1 Is Nothing Or fin1 = "" Then
				fin = Today.Date
			Else
				fin = Date.Parse(fin1)
			End If

			Dim a = New Result(False)
			Dim resultado = New Result
			Dim bs = New FactorBAL.ReportesBAL()
			Dim vencimientos = New sp_vencimientosnafin

			resultado = bs.ReporteVencimientosNafinBAL(moneda, tipo, inicio, fin, vencimientos)
			localReport.ReportPath = Server.MapPath("~/Reports/VencimientosFondeoNafin.rdlc")

			Dim reportDataSource = New ReportDataSource()
			reportDataSource.Name = "vencimientosNafin"
			reportDataSource.Value = vencimientos.list

			localReport.DataSources.Clear()

			localReport.DataSources.Add(reportDataSource)

			If resultado.Ok And resultado IsNot Nothing Then

				Dim reportType As String = "PDF"
				Dim mimeType As String = ""
				Dim encoding As String = ""
				Dim fileNameExtension As String = ""

				Dim Waring() As Warning = Nothing 'Array
				Dim Streams() As String = Nothing 'Array 
				Dim renderedBytes() As Byte	'Array

				Dim list(0) As ReportParameter
				list(0) = New ReportParameter("Usuario", Session("USERID").ToString())

				localReport.SetParameters(list)
				renderedBytes = localReport.Render(reportType, Nothing, mimeType, encoding, fileNameExtension, Streams, Waring)
				If Request.Cookies("reporte") IsNot Nothing Then
					Request.Cookies("reporte").Value = "OK"
				End If
				Response.SetCookie(Request.Cookies("reporte"))
				Return File(renderedBytes, "pdf", "VencimientosFondeoNafin.pdf")

			Else
				Return Content("<script language='javascript' type='text/javascript'>alert('Error al generar el PDF favor de volver a consultar !!\n\nClick Aceptar para volver'); window.location.href ='../Catalogos/ControlRiesgo?clienteId=")
				'+ idcliente.ToString() + "&nombre=" + nombre + "';</script>")

			End If

		End Function

#End Region

#Region "Movimientos"

		<HttpGet>
		Public Function ConsultaDepositos(fecha As String, idctabanco As Integer) As ActionResult
			Dim jresult
			Dim response
			Dim consulta = New ReportesBAL()
			Dim model As New List(Of ReporteDepositos)

			response = consulta.ConsultaDepositosBAL(fecha, idctabanco, model)

			If response IsNot Nothing And response.ok Then
				jresult = Json(New With {Key .Results = model}, JsonRequestBehavior.AllowGet)
				jresult.MaxJsonLength = Integer.MaxValue
			Else
				response.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + response.Mensaje + "!!" + response.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult
		End Function

		<HttpGet>
		Public Function ConsultaSalidas(fecha As String, idctabanco As Integer) As ActionResult
			Dim jresult
			Dim response
			Dim consulta = New ReportesBAL()
			Dim model As New List(Of ReporteDepositos)

			response = consulta.ConsultaSalidasBAL(fecha, idctabanco, model)

			If response.ok And response IsNot Nothing Then
				jresult = Json(New With {Key .results = model}, JsonRequestBehavior.AllowGet)
				jresult.MaxJsonLength = Integer.MaxValue
			Else
				response.mensaje = "Ocurrió un error al consultar la información"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + response.Mensaje + "!!" + response.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult
		End Function

#End Region

#Region "Cobranza"

		<HttpGet>
		Public Function Obtenercliente(contrato As Integer) As ActionResult

			Dim jresult
			Dim resultado
			Dim reporte = New reporteSaldos
			Dim consulta = New FactorBAL.ReportesBAL()

			resultado = consulta.consultaClienteBAL(reporte, contrato)

			If resultado.Ok And resultado IsNot Nothing Then

				jresult = New CustomJsonResult With {
				  .Data = New With {Key .reporte = reporte, .result = resultado.OK, .JsonRequestBehavior = JsonRequestBehavior.AllowGet}
				}

			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function

		<HttpGet>
		Public Function ObtenerListaReportes() As ActionResult

			Dim jresult
			Dim resultado
			Dim consulta = New FactorBAL.ReportesBAL()


			Dim listaReportes = New List(Of ReporteEntidad)
			resultado = consulta.ConsultaReportesBAL(listaReportes)

			If resultado.Ok And resultado IsNot Nothing Then

				jresult = New CustomJsonResult With {
				  .Data = New With {Key .Results = listaReportes,
				.JsonRequestBehavior = JsonRequestBehavior.AllowGet}
				}

			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function

#End Region

#Region "Historia de un documento"


		<HttpGet>
		Public Function consultarContratoDocumento(Optional contrato As Integer = 0, Optional documento As String = "", Optional deudor As Integer = 0) As ActionResult

			Dim jresult
			Dim resultado
			Dim consulta = New FactorBAL.ReportesBAL()
			Dim control = New controles()
			Dim lista = New List(Of Integer)
			Dim listaProvedores = Nothing
			Dim docto As New doctoentidad()

			resultado = consulta.consultarContratoDocumentoBAL(contrato, documento, docto, lista, deudor)



			If lista IsNot Nothing Then
				listaProvedores = control.CargaProveedores(lista)
			End If


			If resultado.Ok And resultado IsNot Nothing Then

				jresult = New CustomJsonResult With {
				  .Data = New With {Key .resp = resultado.OK, .docto = docto, .lista = listaProvedores,
				.JsonRequestBehavior = JsonRequestBehavior.AllowGet}
				}

			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function

#End Region

#Region "Reporte Saldos "
		<HttpGet>
		Public Function obtenerSaldos(contrato As Integer, Optional anio As Integer = 0) As ActionResult

			Dim jresult
			Dim resultado
			Dim consulta = New FactorBAL.ReportesBAL()


			Dim listaSaldos = New List(Of SaldosEntidad)
			resultado = consulta.obtenerSaldosBAL(contrato, anio, listaSaldos)

			If resultado.Ok And resultado IsNot Nothing Then

				jresult = New CustomJsonResult With {
				  .Data = New With {Key .Results = listaSaldos,
				.JsonRequestBehavior = JsonRequestBehavior.AllowGet}
				}

			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function
#End Region

#Region "Reporte Lineas Factor"
		'<HttpGet>
		'Public Function obtenerLineasFactor() As ActionResult

		'	Dim jresult
		'	Dim resultado
		'	Dim consulta = New FactorBAL.ReportesBAL()


		'	Dim lista = New List(Of LineasFactor)
		'	resultado = consulta.obtenerLineasFactor(lista)

		'	If resultado.Ok And resultado IsNot Nothing Then

		'		jresult = New CustomJsonResult With {
		'		  .Data = New With {Key .Results = lista,
		'		.JsonRequestBehavior = JsonRequestBehavior.AllowGet}
		'		}

		'	Else
		'		resultado.Mensaje = "Ocurrio un error al consultar la informacion"
		'		jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
		'	End If

		'	Return jresult

		'End Function


		<HttpGet>
		Public Function ReporteLineasFactorDesc(tipo As String) As ActionResult
			Dim localReport = New Microsoft.Reporting.WebForms.LocalReport()

			Dim resultado = New Result
			Dim bs = New FactorBAL.ReportesBAL()
			Dim lista = New List(Of LineasFactor)

			resultado = bs.obtenerLineasFactor(lista)
			localReport.ReportPath = Server.MapPath("~/Reports/LineasFactor.rdlc")
			localReport.DataSources.Clear()

			Dim reportDataSource = New ReportDataSource()
			reportDataSource.Name = "dataset"
			reportDataSource.Value = lista

			localReport.DataSources.Add(reportDataSource)
			'If resultado.Ok And resultado IsNot Nothing Then

			Dim reportType As String = tipo
			Dim mimeType As String = ""
			Dim encoding As String = ""
			Dim fileNameExtension As String = ""

			Dim Waring() As Warning = Nothing 'Array
			Dim Streams() As String = Nothing 'Array 
			Dim renderedBytes() As Byte	'Array

			'localReport.SetParameters(lista)
			renderedBytes = localReport.Render(reportType, Nothing, mimeType, encoding, fileNameExtension, Streams, Waring)
			If Request.Cookies("reporte") IsNot Nothing Then
				Request.Cookies("reporte").Value = "OK"
				Response.SetCookie(Request.Cookies("reporte"))
			End If
			Response.BufferOutput = False
			If (tipo = "pdf") Then
				Return File(renderedBytes, tipo, "ReporteListaFactor." + tipo)
			Else
				Return File(renderedBytes, tipo, "ReporteListaFactor.xls")
			End If


			'Else
			'	Return Content("<script language='javascript' type='text/javascript'>alert('Error al generar el PDF favor de volver a consultar !!\n\nClick Aceptar para volver'); window.location.href ='../Catalogos/ControlRiesgo?clienteId=" + idcliente.ToString() + "&nombre=" + nombre + "';</script>")
			'End If

		End Function


		<HttpGet>
		Public Function ObtenerRebatemensual(mes As String, anio As String) As ActionResult
			Dim localReport = New Microsoft.Reporting.WebForms.LocalReport()

			Dim resultado = New Result
			Dim bs = New FactorBAL.ReportesBAL()
			Dim model = New List(Of Rebate)
			Dim tipo = "excel"


			resultado = bs.RebatemensualBAL(mes, anio, model)
			localReport.ReportPath = Server.MapPath("~/Reports/Rebate.rdlc")
			localReport.DataSources.Clear()

			Dim reportDataSource = New ReportDataSource()
			reportDataSource.Name = "Rebatemensual"
			reportDataSource.Value = model

			localReport.DataSources.Add(reportDataSource)
			'If resultado.Ok And resultado IsNot Nothing Then

			Dim reportType As String = tipo
			Dim mimeType As String = ""
			Dim encoding As String = ""
			Dim fileNameExtension As String = ""

			Dim Warning() As Warning = Nothing 'Array
			Dim Streams() As String = Nothing 'Array 
			Dim renderedBytes() As Byte	'Array

      'Dim fecini As String = anio + "-" + mes + "-" + "01"
      'Dim fecha1 As Date
      'fecha1 = Date.Parse(fecini)
      'Dim list(0) As ReportParameter
      'list(0) = New ReportParameter("fecha1", fecha1)

			'localReport.SetParameters(lista)
			renderedBytes = localReport.Render(reportType, Nothing, mimeType, encoding, fileNameExtension, Streams, Warning)
			'If Request.Cookies("reporte") IsNot Nothing Then
			'	Request.Cookies("reporte").Value = "OK"
			'	Response.SetCookie(Request.Cookies("reporte"))
			'End If
			'Response.BufferOutput = False
			'If (tipo = "pdf") Then
			'	Return File(renderedBytes, tipo, "Rebatemensual." + tipo)
			'Else
			'	Return File(renderedBytes, tipo, "Rebatemensual.xls")
			'End If
			Return File(renderedBytes, tipo, "Rebatemensual.xls")

			'Else
			'	Return Content("<script language='javascript' type='text/javascript'>alert('Error al generar el PDF favor de volver a consultar !!\n\nClick Aceptar para volver'); window.location.href ='../Catalogos/ControlRiesgo?clienteId=" + idcliente.ToString() + "&nombre=" + nombre + "';</script>")
			'End If

		End Function


#End Region

#Region "Historia de un adeudo"
		<HttpGet>
		Public Function ConsultaDetalleHistoriaAdeudo(serie As String, docto As Integer) As ActionResult

			Dim jresult
			Dim resultado
			Dim detalle = New RespHistAdeudo()
			Dim consulta = New FactorBAL.ReportesBAL()

			resultado = consulta.ConsultaHistoriaAdeudoBAL(serie, docto, detalle)

			If resultado.Ok And resultado IsNot Nothing Then

				jresult = New CustomJsonResult With {
				  .Data = New With {Key .detalle = detalle, .result = resultado.OK, .JsonRequestBehavior = JsonRequestBehavior.AllowGet}
				}

			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function
#End Region

#Region "Operaciones"
		<HttpGet>
		Public Function ConsultaOperaciones(tipo As Integer) As ActionResult
			Dim jresult
			Dim response
			Dim consulta = New ReportesBAL()
			Dim lista = New List(Of Sp_GraficaOperacion)


			response = consulta.ConsultaOperacionesBAL(tipo, lista)

			If response IsNot Nothing And response.ok Then

				jresult = New CustomJsonResult With {
				  .Data = New With {Key .Results = lista,
				.JsonRequestBehavior = JsonRequestBehavior.AllowGet}
				}
				jresult.MaxJsonLength = Integer.MaxValue
			Else
				response.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + response.Mensaje + "!!" + response.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult
		End Function


#End Region

#Region "Graficas"
		<HttpGet>
		Public Function consultaCartera() As ActionResult
			Dim jresult
			Dim response
			Dim consulta = New ReportesBAL()
			Dim lista = New List(Of Sp_GraficaCartera)

			response = consulta.ConsultaCarteraBAL(lista)

			If response IsNot Nothing And response.ok Then
				jresult = New CustomJsonResult With {
				  .Data = New With {Key .Results = lista,
				.JsonRequestBehavior = JsonRequestBehavior.AllowGet}
				}
				jresult.MaxJsonLength = Integer.MaxValue
			Else
				response.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + response.Mensaje + "!!" + response.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult
		End Function

		<HttpGet>
		Public Function consultaColoCbrnza() As ActionResult
			Dim jresult
			Dim response
			Dim consulta = New ReportesBAL()
			Dim lista = New List(Of SP_GraficaColocacion)

			response = consulta.consultaColoCbrnzaBAL(lista)

			If response IsNot Nothing And response.ok Then
				jresult = New CustomJsonResult With {
				  .Data = New With {Key .Results = lista,
				.JsonRequestBehavior = JsonRequestBehavior.AllowGet}
				}
				jresult.MaxJsonLength = Integer.MaxValue
			Else
				response.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + response.Mensaje + "!!" + response.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult
		End Function
#End Region

#Region "Cartera Vencida"

		<HttpGet>
		Public Function ReporteCarteraVencida(tipo As String, contrato As Integer, nombre As String) As ActionResult
			Dim localReport = New Microsoft.Reporting.WebForms.LocalReport()

			Dim resultado = New Result
			Dim bs = New FactorBAL.CobranzaBAL()
			Dim lista = New List(Of SP_Vencidacontrato)

			resultado = bs.obtenerCarteraVencidaBAL(lista, contrato)
			localReport.ReportPath = Server.MapPath("~/Reports/CteraVencida.rdlc")
			localReport.DataSources.Clear()

			Dim reportDataSource = New ReportDataSource()
			reportDataSource.Name = "carteraVencidaDS"
			reportDataSource.Value = lista

			localReport.DataSources.Add(reportDataSource)
			'If resultado.Ok And resultado IsNot Nothing Then

			Dim reportType As String = tipo
			Dim mimeType As String = ""
			Dim encoding As String = ""
			Dim fileNameExtension As String = ""

			Dim Waring() As Warning = Nothing 'Array
			Dim Streams() As String = Nothing 'Array 
			Dim renderedBytes() As Byte	'Array

			Dim list(0) As ReportParameter
			list(0) = New ReportParameter("Nombre", nombre)

			localReport.SetParameters(list)
			renderedBytes = localReport.Render(reportType, Nothing, mimeType, encoding, fileNameExtension, Streams, Waring)
			If Request.Cookies("reporte") IsNot Nothing Then
				Request.Cookies("reporte").Value = "OK"
				Response.SetCookie(Request.Cookies("reporte"))
			End If
			Response.BufferOutput = False
			If (tipo = "pdf") Then
				Return File(renderedBytes, tipo, "ReporteCarteraVencida." + tipo)
			Else
				Return File(renderedBytes, tipo, "ReporteCarteraVencida.xls")
			End If

		End Function
#End Region

#End Region





	End Class

End Namespace



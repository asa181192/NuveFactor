Imports FactorEntidades
Imports Nelibur.ObjectMapper
Imports nuve.Models
Imports Microsoft.Reporting.WebForms
Imports System.Web.Script.Serialization

Namespace nuve
	<CustomAuthorize(Permisos.Acciones.COBRANZA)>
	Public Class CobranzaController
		Inherits System.Web.Mvc.Controller

#Region "Views"	'*****VIEW*****

		<HttpGet>
		Function adeudos(Optional contrato As Integer = 0) As ViewResult
			Dim model = New Modeloadeudos()
			model.contrato = contrato
			Return View(model)
		End Function

		<HttpGet>
		Function pagos() As ViewResult
			Dim model = New Modeloadeudos()
			Return View(model)
		End Function

		<HttpGet>
		Function estadocta(Optional contrato As Integer = 0) As ViewResult
			Dim model = New Modeloedocuenta()
			model.contrato = contrato
			Return View(model)
		End Function

		<HttpGet>
		Function registrocobranza() As ViewResult
			Dim model = New Modelocobranza()
			Return View(model)
		End Function

		<HttpGet>
		Function carteravencida(cliente As String, Optional contrato As Integer = 0) As ViewResult
			ViewBag.contrato = contrato
			ViewBag.nombre = cliente
			Return View()
		End Function

#Region "Aforos"
		<HttpGet>
		Function Aforos(Optional contrato As Integer = 0) As ViewResult
			Dim model = New ModeloAforos
			model.contrato = contrato
			Return View(model)
		End Function

		<HttpGet>
		Function AforosPorLiquidar(Optional contrato As Integer = 0) As ViewResult
			Dim model = New ModeloAforos
			Return View(model)
		End Function
#End Region

#Region "Cobranza"
		<HttpGet>
		Function aplicacob(fecha As String, contrato As String) As ViewResult
			Dim model = New Modelocobranza()
			Dim paforo As Decimal

			Dim porc = New FactorBAL.CobranzaBAL()
			porc.Obtenerpgeaforo(contrato, paforo)
			model.porc_aforo = paforo

			Return View(model)
		End Function

		<HttpGet>
		Function Cobglobal(fecha As String) As ViewResult
			Dim model = New Modelocobranza()
			'     Dim paforo As Decimal

			'      Dim porc = New FactorBAL.CobranzaBAL()
			'     porc.Obtenerpgeaforo(contrato, paforo)
			'      model.porc_aforo = paforo

			Return View(model)
		End Function

		<HttpGet>
		Function Accesorios() As ViewResult
			Dim model = New ModeloMonitorlineas
			Return View(model)
		End Function

#End Region




#End Region


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


			model.sMenu &= "<div class=""BoxFlex"" id=""dvflexadeudos"" >"
			model.sMenu &= "<div class=""BoxFlexShadow"">"
			model.sMenu &= "<p>Adeudos</p>"
			'model.sMenu &= "<img src=""../Images/Contratos.png""/> </a>"
			model.sMenu &= "</div>"
			model.sMenu &= "</div>"


			model.sMenu &= "<div class=""BoxFlex"" id=""dvflexpagos"" >"
			model.sMenu &= "<div class=""BoxFlexShadow"">"
			model.sMenu &= "<p>Pagos adeudos</p>"
			'model.sMenu &= "<img src=""../Images/Contratos.png""/> </a>"
			model.sMenu &= "</div>"
			model.sMenu &= "</div>"

			model.sMenu &= "<div class=""BoxFlex"" id=""dvflexestado"" >"
			model.sMenu &= "<div class=""BoxFlexShadow"">"
			model.sMenu &= "<p>Estado de cuenta</p>"
			'model.sMenu &= "<img src=""../Images/Contratos.png""/> </a>"
			model.sMenu &= "</div>"
			model.sMenu &= "</div>"

			If TryCast(Session("Permisos"), List(Of Integer)).Contains(Permisos.Acciones.COBRANZA_ACTUALIZAR) Then
				model.sMenu &= "<div class=""BoxFlex"" id=""dvflexregistro"" >"
				model.sMenu &= "<div class=""BoxFlexShadow"">"
				model.sMenu &= "<p>Registro de cobranza</p>"
				'model.sMenu &= "<img src=""../Images/Contratos.png""/> </a>"
				model.sMenu &= "</div>"
				model.sMenu &= "</div>"
			End If

			model.sMenu &= "<div class=""BoxFlex"" id=""dvflexcobglobal"" >"
			model.sMenu &= "<div class=""BoxFlexShadow"">"
			model.sMenu &= "<p>Cobranza global</p>"
			'model.sMenu &= "<img src=""../Images/Contratos.png""/> </a>"
			model.sMenu &= "</div>"
			model.sMenu &= "</div>"

			model.sMenu &= "<div class=""BoxFlex"" id=""dvflexaforos"" >"
			model.sMenu &= "<div class=""BoxFlexShadow"">"
			model.sMenu &= "<p>Aforos</p>"
			'model.sMenu &= "<img src=""../Images/Contratos.png""/> </a>"
			model.sMenu &= "</div>"
			model.sMenu &= "</div>"

			model.sMenu &= "<div class=""BoxFlex"" id=""dvflexaccesorios"" >"
			model.sMenu &= "<div class=""BoxFlexShadow"">"
			model.sMenu &= "<p>Accesorios</p>"
			'model.sMenu &= "<img src=""../Images/Contratos.png""/> </a>"
			model.sMenu &= "</div>"
			model.sMenu &= "</div>"


			Return View(model)
		End Function

#End Region


#Region "Get"

#Region "Adeudos"

		'Obtiene el total de registros
		<HttpGet>
		Public Function obtenerListaAdeudos(contrato As Integer) As ActionResult

			Dim jresult
			Dim resultado
			Dim consulta = New FactorBAL.CobranzaBAL()


			Dim listaAdeudos = New List(Of adeudosEntidad)
			resultado = consulta.ConsultaAdeudosBAL(listaAdeudos, contrato)

			If resultado.Ok And resultado IsNot Nothing Then

				jresult = New CustomJsonResult With {
				  .Data = New With {Key .Results = listaAdeudos,
				.JsonRequestBehavior = JsonRequestBehavior.AllowGet}
				}
			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function

		'Detalle de Adeudo '
		<HttpGet>
		Public Function GuardarAdeudo(idadeudo As Integer, m As String) As ActionResult

			Dim model = New Modeloadeudos
			Dim consulta = New FactorBAL.CobranzaBAL()
			Dim adeudos = New adeudos

			Dim resultado = consulta.ConsultaAdeudosDetalleBAL(idadeudo, adeudos)

			If resultado.Ok And resultado IsNot Nothing Then
				TinyMapper.Bind(Of adeudos, Modeloadeudos)()  'Mapeo de propiedad para modelo.
				model = TinyMapper.Map(Of Modeloadeudos)(adeudos)
			End If
			model.SaldoPago = model.saldo
			model.Adeudo = model.tipo + "-" + model.docto.ToString("0000000")
			model.movto = m
			model.importe = model.saldo

			Return PartialView(model)
		End Function

#End Region

#Region "Pagosadeudos"

		'Obtiene el total de registros
		<HttpGet>
		Public Function obtenerListapagosadeudos(dfecha As String) As ActionResult

			Dim jresult
			Dim resultado
			Dim consulta = New FactorBAL.CobranzaBAL()

			Dim listaPagosadeudos = New List(Of adeudosEntidad)
			resultado = consulta.ConsultaPagosadeudosBAL(listaPagosadeudos, dfecha)

			If resultado.Ok And resultado IsNot Nothing Then

				jresult = New CustomJsonResult With {
				  .Data = New With {Key .Results = listaPagosadeudos,
				.JsonRequestBehavior = JsonRequestBehavior.AllowGet}
				}

				'jresult = Json(New With {Key .Results = listaAdeudos}, JsonRequestBehavior.AllowGet)
			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function


#End Region

#Region "edocuenta"

		'Obtiene el total de registros
		<HttpGet>
		Public Function obtenerListaedocuenta(fechaMes As String, fechaAnio As String, contrato As String) As ActionResult

			Dim jresult
			Dim resultado
			Dim nombre = ""
			Dim lineacto = ""
			Dim monedastr = ""
			Dim anticipo = ""
			Dim cartera = ""
			Dim cont = ""
			Dim disponible = ""
			Dim consulta = New FactorBAL.CobranzaBAL()


			Dim listaedocuenta = New List(Of EdocuentaEntidad)
			resultado = consulta.ConsultaedocuentaBAL(listaedocuenta, fechaMes, fechaAnio, contrato)

			If listaedocuenta IsNot Nothing And listaedocuenta.Count > 0 Then
				nombre = listaedocuenta.FirstOrDefault().nombre
				lineacto = listaedocuenta.FirstOrDefault().linea.ToString()
				monedastr = listaedocuenta.FirstOrDefault().monedastr
				anticipo = listaedocuenta.FirstOrDefault().anticipo.ToString()
				cartera = listaedocuenta.FirstOrDefault().cartera.ToString()
				cont = listaedocuenta.FirstOrDefault().contrato
				disponible = listaedocuenta.Last().disponible.ToString()
			End If


			If resultado.Ok And resultado IsNot Nothing Then

				jresult = New CustomJsonResult With {
				  .Data = New With {Key .Results = listaedocuenta, .nombre = nombre, .lineacto = lineacto, .monedastr = monedastr, .cont = contrato, .disponible = disponible,
				.JsonRequestBehavior = JsonRequestBehavior.AllowGet}
				}

				'jresult = Json(New With {Key .Results = listaAdeudos}, JsonRequestBehavior.AllowGet)
			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function


#End Region

#Region "Regitro de cobranza"

		'Obtiene el total de registros
		<HttpGet>
		Public Function obtenerlistacobranza(fecha As String, contrato As String) As ActionResult

			Dim jresult
			Dim resultado
			Dim nom = ""
			Dim timporte = ""
			Dim tdescto = ""
			Dim tneto = ""
			Dim tbonifica = ""
			Dim monedastr = ""
			Dim cont = ""
			Dim descrip = ""

			Dim tprovision = ""
			Dim tadeudo = ""
			Dim tmoratorio = ""

			Dim consulta = New FactorBAL.CobranzaBAL()

			Dim listaregistro = New List(Of CobranzaEntidad)
			resultado = consulta.ConsultaregistrocobranzaBAL(listaregistro, fecha, contrato)

			If listaregistro IsNot Nothing And listaregistro.Count > 0 Then

				nom = listaregistro.FirstOrDefault().Nombre.Trim
				monedastr = listaregistro.FirstOrDefault().monedastr
				cont = listaregistro.FirstOrDefault().contrato

				timporte = listaregistro.FirstOrDefault().timporte
				tdescto = listaregistro.FirstOrDefault().tdescto
				tbonifica = listaregistro.FirstOrDefault().tbonifica
				tneto = listaregistro.FirstOrDefault().tneto
				descrip = listaregistro.FirstOrDefault().descrip.Trim

				tprovision = listaregistro.FirstOrDefault().tprovision
				tadeudo = listaregistro.FirstOrDefault().contrato
				tmoratorio = listaregistro.FirstOrDefault().contrato
			End If


			If resultado.Ok And resultado IsNot Nothing Then

				jresult = New CustomJsonResult With {
				  .Data = New With {Key .Results = listaregistro, .descrip = descrip, .nom = nom, .monedastr = monedastr, .cont = contrato,
					  .timporte = timporte, .tdescto = tdescto, .tneto = tneto, .tbonifica = tbonifica, .tprovision = tprovision, .tadeudo = tadeudo, .tmoratorio = tmoratorio,
				.JsonRequestBehavior = JsonRequestBehavior.AllowGet}
				}

				'jresult = Json(New With {Key .Results = listaAdeudos}, JsonRequestBehavior.AllowGet)
			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function

		'Obtiene el total de registros
		<HttpGet>
		Public Function obtenerCobglobal(fecha As String) As ActionResult

			Dim jresult
			Dim resultado

			Dim timporte = ""
			Dim tdescto = ""
			Dim tneto = ""
			Dim tbonifica = ""
			Dim tdeposito = ""
			Dim afectado = ""

			Dim monedastr = ""

			Dim consulta = New FactorBAL.CobranzaBAL()

			Dim listaregistro = New List(Of CobranzaEntidad)
			resultado = consulta.ConsultaCobglobalBAL(listaregistro, fecha)

			If listaregistro IsNot Nothing And listaregistro.Count > 0 Then

				'nom = listaregistro.FirstOrDefault().Nombre.Trim
				'monedastr = listaregistro.FirstOrDefault().monedastr
				'cont = listaregistro.FirstOrDefault().contrato

				timporte = listaregistro.FirstOrDefault().timporte
				tdescto = listaregistro.FirstOrDefault().tdescto
				tbonifica = listaregistro.FirstOrDefault().tbonifica
				tneto = listaregistro.FirstOrDefault().tneto
				tdeposito = listaregistro.FirstOrDefault().tdeposito
				afectado = listaregistro.FirstOrDefault().afectado
				'descrip = listaregistro.FirstOrDefault().descrip.Trim

				'tprovision = listaregistro.FirstOrDefault().tprovision
				'tadeudo = listaregistro.FirstOrDefault().contrato
				'tmoratorio = listaregistro.FirstOrDefault().contrato
			End If


			If resultado.Ok And resultado IsNot Nothing Then

				jresult = New CustomJsonResult With {
				  .Data = New With {Key .Results = listaregistro, .timporte = timporte, .tdescto = tdescto, .afectado = afectado, .tneto = tneto, .tbonifica = tbonifica, .tdeposito = tdeposito,
				.JsonRequestBehavior = JsonRequestBehavior.AllowGet}
				}

				'jresult = Json(New With {Key .Results = listaAdeudos}, JsonRequestBehavior.AllowGet)
			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function


		'Obtiene el total de registros
		<HttpGet>
		Public Function Obtenerdocumentosxpagar(fecha As String, contrato As Integer) As ActionResult

			Dim jresult
			Dim resultado

			Dim consulta = New FactorBAL.CobranzaBAL()

			Dim listaregistro = New List(Of CobranzaEntidad)
			resultado = consulta.ObtenerdocumentosxpagarBAL(listaregistro, fecha, contrato)

			If resultado.Ok And resultado IsNot Nothing Then

				jresult = New CustomJsonResult With {
				  .Data = New With {Key .Results = listaregistro,
				.JsonRequestBehavior = JsonRequestBehavior.AllowGet}
				}
			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If


			Return jresult

		End Function


#End Region

#Region "Aforos"

		<HttpGet()>
		Public Function ObtenerAforosLiquidados(fecha As String, contrato As Integer) As ActionResult

			Dim jresult = New JsonResult()
			Dim resultado
			Dim consulta = New FactorBAL.CobranzaBAL()
			Dim lista = New List(Of AforosLiquidadosEntidad)

			resultado = consulta.ConsultaAforosLiquidadosBAL(fecha, lista, contrato)

			If resultado.Ok And resultado IsNot Nothing Then
				jresult = Json(New With {Key .Results = lista}, JsonRequestBehavior.AllowGet)
			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function

		<HttpGet()>
		Public Function ObtenerAforosPorLiquidar(Optional contrato As Integer = 0) As ActionResult

			Dim jresult = New JsonResult()
			Dim resultado
			Dim consulta = New FactorBAL.CobranzaBAL()
			Dim lista = New List(Of AforosPorLiquidar)

			resultado = consulta.ConsultaAforosPorLiquidarBAL(lista, contrato)

			If resultado.Ok And resultado IsNot Nothing Then
				jresult = Json(New With {Key .Results = lista}, JsonRequestBehavior.AllowGet)
				jresult.MaxJsonLength = 500000000
			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function

		<HttpGet>
		Public Function liquidarAforo(beneficiario As String, pago As Decimal, identidad As Integer, id As Integer, moneda As Integer, contrato As Integer) As ActionResult

			Dim model = New ModeloAforos
			Dim consulta = New FactorBAL.CobranzaBAL()
			Dim anexo = New AforosPorLiquidar

			model.contrato = contrato
			model.benef = beneficiario
			model.pago = pago
			model.identidad = identidad
			model.id = id
			model.Moneda = moneda
			model.CargaControles(identidad, id, moneda)
			model.monto = model.pago
			Return PartialView(model)

		End Function

#End Region

#Region "Accesorios"

		'Obtiene el total de registros
		<HttpGet>
		Public Function obtenerMonitorlineas() As ActionResult

			Dim jresult
			Dim resultado
			Dim consulta = New FactorBAL.CobranzaBAL()


			Dim listaMonitor = New List(Of MonitorlineasEntidad)
			resultado = consulta.AccesoriosBAL(listaMonitor)

			If resultado.Ok And resultado IsNot Nothing Then

				jresult = New CustomJsonResult With {
				  .Data = New With {Key .Results = listaMonitor,
				.JsonRequestBehavior = JsonRequestBehavior.AllowGet}
				}

				'jresult = Json(New With {Key .Results = listaAdeudos}, JsonRequestBehavior.AllowGet)
			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function


#End Region

#Region "Cartera Vencida"
		<HttpGet()>
		Public Function obtenerCarteraVencida(contrato As Integer) As ActionResult

			Dim jresult = New JsonResult()
			Dim resultado
			Dim consulta = New FactorBAL.CobranzaBAL()
			Dim lista = New List(Of SP_Vencidacontrato)

			resultado = consulta.obtenerCarteraVencidaBAL(lista, contrato)

			If resultado.Ok And resultado IsNot Nothing Then

				jresult = New CustomJsonResult With {
				  .Data = New With {Key .Results = lista,
				.JsonRequestBehavior = JsonRequestBehavior.AllowGet}
				}

			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function
#End Region

#End Region


#Region "Post"	'*****POST*****

		'Detalle de Adeudo
		<HttpPost>
		<CustomAuthorize(Permisos.Acciones.COBRANZA_ACTUALIZAR)>
		Public Function GuardarAdeudo(modadeudo As Modeloadeudos) As ActionResult

			Dim resultado


			Dim consulta = New FactorBAL.CobranzaBAL()
			Dim madeudos = New adeudos

			TinyMapper.Bind(Of Modeloadeudos, adeudosEntidad)()	 'Mapeo de propiedad para modelo
			Dim model = TinyMapper.Map(Of adeudosEntidad)(modadeudo)

			resultado = consulta.ActualizarAdeudoBAL(model)

			If resultado.Ok And resultado IsNot Nothing Then
				resultado.Mensaje = "Informacion Actualizada"
				resultado.tipo = Enumerador.eTipoTransaccion.eActualizar
			Else
				resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro!! {0}" +
					"Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
			End If

			Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})



		End Function

#Region "Cobranza"

		<HttpPost>
		<CustomAuthorize(Permisos.Acciones.COBRANZA_ACTUALIZAR)>
		Public Function GuardarCobranza(docs As List(Of CobranzaEntidad)) As ActionResult
			Dim resultado
			Dim JsonStr

			'Dim serializer = New JavaScriptSerializer()
			'serializer.MaxJsonLength = ConfigurationManager.AppSettings("maxJsonlLength")

			Dim bs = New FactorBAL.CobranzaBAL()
			resultado = bs.GuardarCobranzaBAL(docs)

			If resultado.Ok And resultado IsNot Nothing Then
				resultado.Mensaje = "Cobranza registrada"
				FactorBAL.Utility.Monitor(Session("USERID"), "Registro de cobranza contrato : " + docs(0).contrato.ToString())
				resultado.tipo = Enumerador.eTipoTransaccion.eAlta

				JsonStr = Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo, .color = "success"}, JsonRequestBehavior.AllowGet)
				JsonStr.MaxJsonLength = Integer.MaxValue

			Else
				resultado.Mensaje = String.Format("Ocurrio un error al tratar de guardar la cobranza!! {0}" +
					  "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
				JsonStr = Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo, .color = "warning"})
			End If
			Return JsonStr

		End Function

		<HttpPost>
		<CustomAuthorize(Permisos.Acciones.COBRANZA_ACTUALIZAR)>
		Public Function Provision(contrato As Integer, tipo As String) As ActionResult

			Dim resultado
			Dim consulta = New FactorBAL.CobranzaBAL()

			resultado = consulta.ProvisionBAL(contrato, tipo)

			If resultado.Ok And resultado IsNot Nothing Then
				resultado.Mensaje = "Partida generada"
				FactorBAL.Utility.Monitor(Session("USERID"), "Genero Provision " + tipo + "Contrato " + contrato.ToString)
				resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar 'eActualizar permite enviar al json el tipo para saber si la tabla se recargara 
			Else
				resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro!! {0}" +
					"Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
			End If

			Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})

		End Function





		<HttpPost>
		Public Function Eliminadocto(idcob As Integer) As ActionResult

			Dim resultado
			Dim consulta = New FactorBAL.CobranzaBAL()

			resultado = consulta.EliminadoctoBAL(idcob)

			If resultado.Ok And resultado IsNot Nothing Then
				resultado.Mensaje = "Registro eliminado"
				FactorBAL.Utility.Monitor(Session("USERID"), "Registro " + idcob.ToString() + "Eliminado de cobranza ")
				resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar 'eActualizar permite enviar al json el tipo para saber si la tabla se recargara 
			Else
				resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro!! {0}" +
					"Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
			End If

			Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})

		End Function

		<HttpPost>
		Public Function Afectacob(fecha As String, contrato As Integer) As ActionResult

			Dim resultado
			Dim consulta = New FactorBAL.CobranzaBAL()

			resultado = consulta.AfectacobBAL(fecha, contrato)

			If resultado.Ok And resultado IsNot Nothing Then
				If resultado.Mensaje = "Cobranza afectada" Then
					FactorBAL.Utility.Monitor(Session("USERID"), "Afecto cobranza del " + fecha.ToString() + ". ")
					resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar 'eActualizar permite enviar al json el tipo para saber si la tabla se recargara 
				End If
			Else
				resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro!! {0}" +
					"Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
			End If

			Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})

		End Function

		<HttpPost>
		Public Function Eliminacob(fecha As String, contrato As Integer) As ActionResult

			Dim resultado
			Dim consulta = New FactorBAL.CobranzaBAL()

			resultado = consulta.EliminacobBAL(fecha, contrato)

			If resultado.Ok And resultado IsNot Nothing Then
				If resultado.Mensaje = "Cobranza afectada" Then
					FactorBAL.Utility.Monitor(Session("USERID"), "Afecto cobranza del " + fecha.ToString() + ". ")
					resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar 'eActualizar permite enviar al json el tipo para saber si la tabla se recargara 
				End If
			Else
				resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro!! {0}" +
					"Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
			End If

			Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})

		End Function

		<HttpPost>
		Public Function Afectacobglobal(fecha As String) As ActionResult

			Dim resultado
			Dim consulta = New FactorBAL.CobranzaBAL()

			resultado = consulta.AfectacobglobalBAL(fecha)

			If resultado.Ok And resultado IsNot Nothing Then
				If resultado.Mensaje = "Cobranza afectada" Then
					FactorBAL.Utility.Monitor(Session("USERID"), "Afecto cobranza del " + fecha.ToString() + ". ")
					resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar 'eActualizar permite enviar al json el tipo para saber si la tabla se recargara 
				End If
			Else
				resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro!! {0}" +
					"Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
			End If

			Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})

		End Function

		<HttpPost>
		Public Function Reversocob(fecha As String, contrato As Integer) As ActionResult

			Dim resultado
			Dim consulta = New FactorBAL.CobranzaBAL()

			resultado = consulta.ReversocobBAL(fecha, contrato)

			If resultado.Ok And resultado IsNot Nothing Then
				resultado.Mensaje = "Cobranza desafectada"
				FactorBAL.Utility.Monitor(Session("USERID"), "Desafecto cobranza del " + fecha + ", Contrato " + contrato.ToString() + ". ")
				resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar 'eActualizar permite enviar al json el tipo para saber si la tabla se recargara 
			Else
				resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro!! {0}" +
					"Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
			End If

			Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})

		End Function


#End Region



#Region "Aforos"
		<HttpPost()>
		Public Function InicializarAforo(contrato As Integer, id As Integer, identidad As Integer) As ActionResult
			Dim resultado
			Dim bs = New FactorBAL.CobranzaBAL()
			resultado = bs.InicializarAforoBAL(contrato, id, identidad)
			If resultado.Ok And resultado IsNot Nothing Then
				resultado.Mensaje = "Aforo inicializado"
				FactorBAL.Utility.Monitor(Session("USERID"), "Aforo inicializado" + contrato.ToString() + ", Id : " + id.ToString() + ", identidad : " + identidad.ToString())
				resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar 'eActualizar permite enviar al json el tipo para saber si la tabla se recargara 
			Else
				resultado.Mensaje = String.Format("Ocurrio un error al tratar de inicializar el Aforo !! {0}" +
					  "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
			End If
			Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})
		End Function

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

		<HttpPost>
		Public Function liquidarAforo(model As ModeloAforos) As ActionResult

			Dim resultado
			Dim bs = New FactorBAL.CobranzaBAL()
			Dim entidad = New AforosPorLiquidar()

			entidad.id = model.id
			entidad.identidad = model.identidad
			entidad.moneda = model.Moneda
			entidad.numrec = model.numreccta
			entidad.contrato = model.contrato
			entidad.cartera = model.cartera

			resultado = bs.liquidaAforoBAL(entidad)
			If resultado.Ok And resultado IsNot Nothing Then
				resultado.Mensaje = "Aforo liquidado"
				FactorBAL.Utility.Monitor(Session("USERID"), "Aforo Liquidado Id:" + model.id.ToString())
				resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar 'eActualizar permite enviar al json el tipo para saber si la tabla se recargara 
			Else
				resultado.Mensaje = String.Format("Ocurrio un error al tratar de guardar la informacion !! {0}" +
					  "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
			End If
			Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})
		End Function

		<HttpPost>
		Public Function CancelarAforo(numrec As Integer) As ActionResult

			Dim resultado
			Dim bs = New FactorBAL.CobranzaBAL()
			resultado = bs.CancelarAforoBAL(numrec)
			If resultado.Ok And resultado IsNot Nothing Then
				FactorBAL.Utility.Monitor(Session("USERID"), "Aforo Cancelado numrec" + numrec.ToString())
				resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar 'eActualizar permite enviar al json el tipo para saber si la tabla se recargara 
				resultado.Mensaje = "Aforo cancelado correctamente"
				Return Json(New With {Key .Result = resultado.Ok, .color = "success", .Text = resultado.Mensaje, .Tipo = resultado.Tipo})

			Else
				resultado.Mensaje = String.Format("Ocurrio un error al tratar de cancelar el contrato !! {0}" +
					  "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
				Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .Tipo = resultado.Tipo})
			End If

		End Function

		<HttpGet>
		Public Function ReporteCalculoAforo(fecha As String, contrato As Integer, id As Integer, identidad As Integer) As ActionResult
			Dim localReport = New Microsoft.Reporting.WebForms.LocalReport()

			Dim resultado = New Result
			Dim bs = New FactorBAL.CobranzaBAL()
			Dim listaRiesgo = New List(Of AforosLiquidadosEntidad)

			resultado = bs.ConsultaAforosLiquidadosBAL(fecha, listaRiesgo, contrato)
			localReport.ReportPath = Server.MapPath("~/Reports/CalculoAforo.rdlc")
			localReport.DataSources.Clear()

			Dim reportDataSource = New ReportDataSource()
			reportDataSource.Name = "DataSet1"
			reportDataSource.Value = listaRiesgo.Where(Function(x) x.contrato = contrato And x.id = id And x.identidad = identidad).ToList()

			localReport.DataSources.Add(reportDataSource)

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
				Response.SetCookie(Request.Cookies("reporte"))
			End If
			Response.BufferOutput = False
			Return File(renderedBytes, "pdf", "ReporteCalculoAforo.pdf")

		End Function


#End Region


#End Region


	End Class

End Namespace

﻿Imports nuve.AdminModels
Imports FactorEntidades
Imports Nelibur.ObjectMapper
Imports FactorBAL
Imports nuve.Models

Namespace nuve
	Public Class AdminController
		Inherits System.Web.Mvc.Controller

#Region "VIEW"
#Region "Usuarios"
		<HttpGet>
		<CustomAuthorize>
		Function Usuarios() As ViewResult
			Dim model = New ModeloUsuario()
			Return View(model)
		End Function
#End Region

#Region "Tipos de Garantia"
		<HttpGet>
		Function TipoGarantia() As ViewResult
			Dim model = New ModeloTipoGarantia()
			Return View(model)
		End Function
#End Region

#Region "Codigos de Garantia"
		<HttpGet>
		Function CodigoGarantia() As ViewResult
			Dim model = New ModeloCodigoGarantia()
			Return View(model)
		End Function
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

			model.sMenu &= "<div class=""BoxFlex"" id=""dvflexUsuarios"" >"
			model.sMenu &= "<div class=""BoxFlexShadow"">"
			model.sMenu &= "<p>Usuarios</p>"
			model.sMenu &= "</div>"
			model.sMenu &= "</div>"

			model.sMenu &= "<div class=""BoxFlex"" id=""dvflexGarantia"" >"
			model.sMenu &= "<div class=""BoxFlexShadow"">"
			model.sMenu &= "<p>Códigos de Garantía</p>"
			model.sMenu &= "</div>"
			model.sMenu &= "</div>"

			model.sMenu &= "<div class=""BoxFlex"" id=""dvflexGarantiaTipo"" >"
			model.sMenu &= "<div class=""BoxFlexShadow"">"
			model.sMenu &= "<p>Tipos de Garantía</p>"
			model.sMenu &= "</div>"
			model.sMenu &= "</div>"

			Return View(model)
		End Function
#End Region
#End Region

#Region "GET"

#Region "usuarios"
		<HttpGet>
		<CustomAuthorize>
		Public Function ObtenerListaUsuarios() As ActionResult

			Dim jresult
			Dim resultado
			Dim consulta = New FactorBAL.Manager()

			Dim listaUsusario = New List(Of UsuarioEntidad)

			resultado = consulta.ConsultaUsuariosBAL(listaUsusario)

			If resultado.Ok And resultado IsNot Nothing Then
				jresult = Json(New With {Key .Results = listaUsusario}, JsonRequestBehavior.AllowGet)
			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function

		<HttpGet>
		Public Function GuardarUsuario(id As Int32) As ActionResult

			Dim model = New ModeloUsuario()
			Dim consulta = New FactorBAL.Manager()
			Dim usuario = New usuarios
			Dim resultado = consulta.ConsultaDetalleUsuarioBAL(id, usuario)



			If resultado.Ok And resultado IsNot Nothing Then
				TinyMapper.Bind(Of clientes, ModeloUsuario)()	'Mapeo de propiedad para modelo.
				model = TinyMapper.Map(Of ModeloUsuario)(usuario)
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

		<HttpGet>
		Public Function ObtenerPerfiles() As ActionResult

			Dim jresult
			Dim resultado
			Dim consulta = New FactorBAL.Manager()
			Dim controles = New controles()
			Dim listaPerfiles = New List(Of SelectListItem)
			listaPerfiles = controles.CargaPerfiles()

			If resultado.Ok And resultado IsNot Nothing Then
				jresult = Json(New With {Key .Results = listaPerfiles}, JsonRequestBehavior.AllowGet)
			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function
#End Region

#Region "Codigos de Garantia"

		<HttpGet>
		Public Function ObtenerListaCodigoGarantia() As ActionResult

			Dim jresult
			Dim resultado
			Dim consulta = New FactorBAL.Manager()

			Dim listaGarantia = New List(Of CodigoGarantiaEntidad)

			resultado = consulta.ConsultaCodigoGarantiaBAL(listaGarantia)

			If resultado.Ok And resultado IsNot Nothing Then
				jresult = Json(New With {Key .Results = listaGarantia}, JsonRequestBehavior.AllowGet)
			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function

		<HttpGet>
		Public Function GuardarCodigoGarantia(codigoid As Int32) As ActionResult

			Dim model = New ModeloCodigoGarantia()
			Dim consulta = New FactorBAL.Manager()
			Dim codigo = New codigogarantia

			Dim resultado = consulta.ConsultaDetalleCodigoGarantiaBAL(codigoid, codigo)

			If resultado.Ok And resultado IsNot Nothing Then
				TinyMapper.Bind(Of codigogarantia, ModeloCodigoGarantia)()	'Mapeo de propiedad para modelo.
				model = TinyMapper.Map(Of ModeloCodigoGarantia)(codigo)

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

#Region "Tipos de Garantia"

		<HttpGet>
		Public Function ObtenerListaTipoGarantia() As ActionResult

			Dim jresult
			Dim resultado
			Dim consulta = New FactorBAL.Manager()

			Dim listaTipo = New List(Of TipoGarantiaEntidad)

			resultado = consulta.ConsultaTipoGarantiaBAL(listaTipo)

			If resultado.Ok And resultado IsNot Nothing Then
				jresult = Json(New With {Key .Results = listaTipo}, JsonRequestBehavior.AllowGet)
			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function

		<HttpGet>
		Public Function GuardarTipoGarantia(tipoid As Int32) As ActionResult

			Dim model = New ModeloTipoGarantia()

			Dim consulta = New FactorBAL.Manager()
			Dim codigo = New tipogarantia

			Dim resultado = consulta.ConsultaDetalleTipoGarantiaBAL(tipoid, codigo)

			If resultado.Ok And resultado IsNot Nothing Then
				TinyMapper.Bind(Of tipogarantia, ModeloTipoGarantia)()	'Mapeo de propiedad para modelo.
				model = TinyMapper.Map(Of ModeloTipoGarantia)(codigo)
				model.Cargacontroles()
				Return PartialView(model)
			Else
				If resultado.Id_Out = 1 Then
					Return PartialView("~/Views/Shared/_ErrorPopUp.vbhtml")
				Else
					model.Cargacontroles()
					Return PartialView(model)
				End If
			End If


		End Function

#End Region

#End Region

#Region "POST"

#Region "usuarios"
		<HttpPost>
		Public Function GuardarUsuario(usuario As ModeloUsuario) As ActionResult

			Dim resultado
			Dim bs = New FactorBAL.Manager()

			TinyMapper.Bind(Of ModeloUsuario, usuarios)()	'Mapeo de propiedades Modelo a DTO's
			Dim model = TinyMapper.Map(Of usuarios)(usuario)
			If Not (usuario.Pass2 = Nothing) Then
				model.password = New Utility().Encripta(usuario.Pass2, Enumerador.eTipoEncriptacion.eTipoPassword)
			End If

			If usuario.id > 0 Then
				resultado = bs.ActualizarUsuario(model)

				If resultado.Ok And resultado IsNot Nothing Then
					resultado.Mensaje = "Registro Actualizado"
				Else
					resultado.Mensaje = "Ocurrio un error al tratar de actualizar el registro!! "
				End If

			Else

				resultado = bs.AltaUsuario(model)

				If resultado.Ok And resultado IsNot Nothing Then
					resultado.Mensaje = "Registro Guardado"
					bs.MandarContrasena(model.userid)
				Else
					resultado.Mensaje = "Ocurrio un error al tratar de guardar el registro!! "
				End If

			End If
			Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje})
		End Function

		<HttpPost>
		Public Function resetPassword(id As Integer) As ActionResult
			Dim resultado
			Dim bs = New FactorBAL.Manager()
			resultado = bs.resetPasswordBAL(id)
			If resultado.Ok And resultado IsNot Nothing Then
				resultado.Mensaje = "Password temporal generado y enviado correctamente"
				FactorBAL.Utility.Monitor(Session("USERID"), "Generacion de password para usuario : " + id.ToString())
				resultado.Tipo = Enumerador.eTipoTransaccion.eActualizar 'eActualizar permite enviar al json el tipo para saber si la tabla se recargara 
				Return Json(New With {Key .Result = resultado.Ok, .color = "success", .Text = resultado.Mensaje, .Tipo = resultado.tipo, .titulo = ""})
			Else
				resultado.Mensaje = String.Format("Ocurrio un error al tratar de generar el password!! {0}" +
					  "Tipo de error:{1}", Environment.NewLine, resultado.Detalle)
				Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .Tipo = resultado.tipo, .titulo = ""})
			End If

		End Function

#End Region

#Region "CodigoGarantia"
		<HttpPost>
		Public Function GuardarCodigoGarantia(codigo As ModeloCodigoGarantia) As ActionResult

			Dim resultado
			Dim bs = New FactorBAL.Manager()

			TinyMapper.Bind(Of ModeloCodigoGarantia, codigogarantia)()	'Mapeo de propiedades Modelo a DTO's
			Dim model = TinyMapper.Map(Of codigogarantia)(codigo)

			If codigo.codigoid > 0 Then
				resultado = bs.ActualizarCodigoGarantia(model)

				If resultado.Ok And resultado IsNot Nothing Then
					resultado.Mensaje = "Registro Actualizado"
					resultado.tipo = Enumerador.eTipoTransaccion.eActualizar
				Else
					resultado.Mensaje = "Ocurrio un error al tratar de actualizar el registro!! "
				End If

			Else

				resultado = bs.AltaCodigoGarantia(model)

				If resultado.Ok And resultado IsNot Nothing Then
					resultado.Mensaje = "Registro Guardado"
					resultado.tipo = Enumerador.eTipoTransaccion.eAlta
				Else
					resultado.Mensaje = "Ocurrio un error al tratar de guardar el registro!! "
				End If

			End If
			Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})
		End Function
#End Region

#Region "TipoGarantia"
		<HttpPost>
		Public Function GuardarTipoGarantia(codigo As ModeloTipoGarantia) As ActionResult

			Dim resultado
			Dim bs = New FactorBAL.Manager()

			TinyMapper.Bind(Of ModeloTipoGarantia, tipogarantia)()	'Mapeo de propiedades Modelo a DTO's
			Dim model = TinyMapper.Map(Of tipogarantia)(codigo)

			If codigo.tipoid > 0 Then
				resultado = bs.ActualizarTipoGarantia(model)

				If resultado.Ok And resultado IsNot Nothing Then
					resultado.Mensaje = "Registro Actualizado"
					resultado.tipo = Enumerador.eTipoTransaccion.eActualizar
				Else
					resultado.Mensaje = "Ocurrio un error al tratar de actualizar el registro!! "
				End If

			Else

				resultado = bs.AltaTipoGarantia(model)

				If resultado.Ok And resultado IsNot Nothing Then
					resultado.Mensaje = "Registro Guardado"
					resultado.tipo = Enumerador.eTipoTransaccion.eAlta
				Else
					resultado.Mensaje = "Ocurrio un error al tratar de guardar el registro!! "
				End If

			End If
			Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo})
		End Function
#End Region

#End Region

	End Class
End Namespace
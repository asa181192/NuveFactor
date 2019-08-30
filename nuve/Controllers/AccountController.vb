﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Security
Imports System.Configuration
Imports System.Net.Mail
Imports System.Threading
Imports nuve
Imports FactorBAL
Imports FactorEntidades
Imports nuve.AdminModels
Imports Newtonsoft.Json

Public Class AccountController
	Inherits Controller

	<AllowAnonymous()> _
	Public Function login(ByVal returnUrl As String) As ActionResult
		ViewData("ReturnUrl") = returnUrl
		Return View()
	End Function

	<HttpPost()> _
	<AllowAnonymous()> _
	<ValidateAntiForgeryToken()> _
	Public Function login(ByVal model As login, ByVal returnUrl As String) As ActionResult

		Dim manager = New Manager()
		Dim resultado = New Result()
		Dim usuario = New UsuarioConsulta()

		resultado = manager.ValidarUsuario(usuario, model.user, model.password)


		If resultado.Ok And resultado IsNot Nothing Then

			If usuario IsNot Nothing Then
				If usuario.user.activo Then

					If usuario.fec_pass >= Date.Today() Then
						FormsAuth(usuario)
						Return RedirectToAction("welcome", "Home")
					Else
						Dim modelCambio = New contrasena_cambio()
						modelCambio.userid = usuario.id
						modelCambio.username = usuario.user.userid

						Return View("~/Views/Account/contrasena_cambio.vbhtml", modelCambio)
					End If
				Else
					ModelState.AddModelError("", "Acceso Denegado")
					Return View(model)
				End If
			Else
				ModelState.AddModelError("", "Credenciales Invalidas")
				Return View(model)
			End If
		Else
			ModelState.AddModelError("", "Ocurrio un error")
			Return View(model)
		End If

	End Function



	<AllowAnonymous()> _
	Public Function sesion_expirada(ByVal returnUrl As String) As ActionResult
		ViewData("ReturnUrl") = returnUrl

		Session("USERID") = ""
		Session("NAME") = ""
		Session("FOLIO") = ""
		Session("EMAIL") = ""
		Session("OFICINA") = ""
		Session("PERFIL") = ""
		Session("REGIONALES") = ""
		Session("DIAS_PASS") = ""
		Session("OFICINAS") = ""
		Session("WORKDATE") = ""
		FormsAuthentication.SignOut()
		Dim c As HttpCookie = Request.Cookies(FormsAuthentication.FormsCookieName)
		c.Expires = Date.Now.AddDays(-1)
		Response.Cookies.Set(c)
		Session.Clear()
		Session.Abandon()

		Return View()
	End Function

	<AllowAnonymous> _
	<HttpPost()> _
	<ValidateAntiForgeryToken()> _
	Public Function LogOff() As ActionResult
		Session("USERID") = ""
		Session("ESTADO") = ""
		Session("NAME") = ""
		Session("EMAIL") = ""
		Session("OFICINA") = ""
		Session("PERFIL") = ""
		FormsAuthentication.SignOut()
		Dim c As HttpCookie = Request.Cookies(FormsAuthentication.FormsCookieName)
		c.Expires = Date.Now.AddDays(-1)
		Response.Cookies.Set(c)
		Session.Clear()
		Session.Abandon()

		Return RedirectToAction("login", "Account")
	End Function

	<HttpPost>
	Public Function ReiniciarPassword(model As contrasena_cambio) As ActionResult

		Dim resultado
		If ModelState.IsValid Then
			Dim bal = New Manager()

			resultado = bal.ActualizarPassworResetBAL(model.userid, model.nueva)

			If resultado.Ok And resultado IsNot Nothing Then
				resultado.tipo = Enumerador.eTipoTransaccion.eActualizar

				'exp para saber si es por fuera o dentro de la aplicacion el cambio del password
				Dim usuario = New UsuarioConsulta()

				resultado = bal.ValidarUsuario(usuario, model.username, model.nueva)

				If resultado.Ok And resultado IsNot Nothing Then

					FormsAuth(usuario)
					resultado.Mensaje = String.Format("Contraseña actualizada correctamente.", Environment.NewLine, resultado.Detalle)
				Else
					resultado.Mensaje = String.Format("Ocurrio un error favor de volver a intentar.", Environment.NewLine, resultado.Detalle)
				End If
				Return Json(New With {Key .Result = resultado.Ok, .color = "success", .url = Url.Action("welcome", "home"), .Text = resultado.Mensaje, .Tipo = resultado.Tipo, .titulo = ""})
			Else
				Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .Tipo = resultado.Tipo, .titulo = "Error al actualizar"})
			End If

		Else
			resultado = New Result(False)
			Return Json(New With {Key .Result = resultado.Ok, .color = "warning", .Text = resultado.Mensaje, .titulo = "Revisar los siguientes campos !!"})
		End If

	End Function



#Region "Helpers"
	Private Function FormsAuth(ByRef model As UsuarioConsulta) As Boolean

		Try
			FormsAuthentication.SetAuthCookie("Factor - AuthCookie" & model.user.userid.Trim(), True)
			Response.Cookies("userid").Value = model.user.userid
			Response.Cookies("userid").Expires = Now.AddDays(15)

			Dim ipaddress As String
			ipaddress = Request.ServerVariables("REMOTE_ADDR")

			If Request.Cookies("userinfo") IsNot Nothing Then
				Request.Cookies("userinfo").Value = ipaddress
				Response.SetCookie(Request.Cookies("userinfo"))
			Else
				Dim cookie = New HttpCookie("userinfo")
				cookie.Value = ipaddress
				Response.Cookies.Add(cookie)
			End If

			Session.Clear()
			Session("Permisos") = model.permisos
			Session("USERID") = model.user.userid.Trim()
			Session("ESTADO") = model.sucursal.estado.Trim()
			Session("NAME") = model.user.nombre.Trim()
			Session("EMAIL") = model.user.email.Trim()
			Session("OFICINA") = model.sucursal.nombre.Trim()
			Session("PERFIL") = model.perfil.nombre.Trim()
			FactorBAL.Utility.Monitor(Request.Cookies("userinfo").Value, Session("USERID"), "Autenticacion del usuario")
			Return True
		Catch ex As Exception
			ModelState.AddModelError("", "Ocurrio un error")
			Return False
		End Try
	End Function

	<HttpPost>
	Public Function ResetSession() As ActionResult
		Dim jresult
		System.Diagnostics.Debug.WriteLine("Tiempo : " + HttpContext.Session.Timeout.ToString())
		jresult = Json(New With {Key .Mensaje = "Session Refrescada", .Value = True}, JsonRequestBehavior.AllowGet)
		Return jresult
	End Function


#End Region

End Class

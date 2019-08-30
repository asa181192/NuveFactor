﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports nuve.Permisos
Public Class CustomAuthorize
	Inherits AuthorizeAttribute

	Private _permiso As Integer

	Public Sub New(Optional permiso As Permisos.Acciones = Acciones.NINGUN_PERMISO)
		_permiso = permiso
	End Sub

	Protected Overrides Function AuthorizeCore(httpContext As HttpContextBase) As Boolean
		Dim authorized = MyBase.AuthorizeCore(httpContext)
		If Not authorized Then
			'Se denega aceso al usuario se regresa al login 
			Return False
		Else
			If httpContext.Session("USERID") IsNot Nothing Then
				'Validamos si el permiso que se mando debe validar una accion o solo es para autorizacion 
				If _permiso > 0 Then
					If TryCast(httpContext.Session("Permisos"), List(Of Integer)).Contains(_permiso) Then
						Return True
					Else
						'Se muestra pantalla que no cuenta con los permisos para ejecutar dicha accion .
						Return False
					End If
				Else
					Return True
				End If
			Else
				'Se denega acceso al usuario se regresa a alguna pagina se regrewa a pantalla de login 
				Return False
			End If
		End If

	End Function

	Protected Overrides Sub HandleUnauthorizedRequest(ByVal filterContext As AuthorizationContext)
		If Not filterContext.HttpContext.User.Identity.IsAuthenticated Then
			MyBase.HandleUnauthorizedRequest(filterContext)
		Else
			filterContext.Result = New RedirectToRouteResult(New RouteValueDictionary(New With {
				.controller = "Error",
				.action = "AccesoDenegado"
			}))
		End If
	End Sub
End Class

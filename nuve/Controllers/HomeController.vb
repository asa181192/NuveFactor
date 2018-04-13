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
Imports Negocio.arrendadoraBL


Public Class HomeController
    Inherits BaseController

    <CustomAuthorize> _
    <HttpGet> _
    Function welcome(ByVal returnUrl As String) As ActionResult
        Dim oUsuarioBL As New usuarioBL
        Dim oUsuario As Entidades.arrendadora.usuario = Nothing
        Try
            oUsuario = oUsuarioBL.Selectusuario(Session("USERID"))
            If oUsuarioBL.hayErr Then Throw oUsuarioBL.Err

            ViewData("Title") = "ARRENDADORA BX+ NUVE"
            ViewData("welcome") = String.Format("BIENVENIDO, {0}", oUsuario.nombre.Trim.ToUpper)
        Catch ex As Exception
            BitacoraError(ex, CType(Session("USERID"), String), Request.ServerVariables("REMOTE_ADDR"))
        Finally
            If oUsuarioBL IsNot Nothing Then oUsuarioBL.Dispose()
            If oUsuarioBL IsNot Nothing Then oUsuarioBL = Nothing
            If oUsuario IsNot Nothing Then oUsuario = Nothing
        End Try

        Dim model As New Helpers.Menu


        model.sMenu = "<div class=""BoxFlex"" id=""dvflexCatalogos"" >"
        model.sMenu &= "<div class=""BoxFlexShadow"">"
        model.sMenu &= "<p>Catalogos</p>"
        model.sMenu &= "<img src=""/Images/list.png"" />"
        model.sMenu &= "</div>"
        model.sMenu &= "</div>"

        Return View(model)
    End Function

    <CustomAuthorize> _
    <ValidateAntiForgeryToken> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function welcome(ByVal model As HomeModels, ByVal returnUrl As String) As ActionResult
        If ModelState.IsValid Then
            Dim oUsuarioBL As New usuarioBL
            Dim oUsuario As Entidades.arrendadora.usuario = Nothing
            Try
                oUsuario = oUsuarioBL.Selectusuario(Session("USERID"))
                If oUsuarioBL.hayErr Then Throw oUsuarioBL.Err

                ViewData("Title") = "ARRENDADORA BX+ NUVE"
                ViewData("welcome") = String.Format("BIENVENIDO, {0}", oUsuario.nombre.Trim.ToUpper)
            Catch ex As Exception
                BitacoraError(ex, CType(Session("USERID"), String), Request.ServerVariables("REMOTE_ADDR"))
            Finally
                If oUsuarioBL IsNot Nothing Then oUsuarioBL.Dispose()
                If oUsuarioBL IsNot Nothing Then oUsuarioBL = Nothing
                If oUsuario IsNot Nothing Then oUsuario = Nothing
            End Try
        End If
        Return View()
    End Function

    <CustomAuthorize> _
    <HttpGet> _
    Function configuracion() As ActionResult
        Return View()
    End Function


End Class

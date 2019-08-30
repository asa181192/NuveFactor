﻿Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization


Namespace Notificaciones

    Public Class NotificacionesModel

        <Display(Name:="Id")>
        Public Property idrec As Decimal

        Public Property fecha As Date?

        <Display(Name:="Contrato")>
        Public Property contrato As Integer?

        <Display(Name:="Cliente")>
        Public Property nombre As String

        <Display(Name:="Notificar a")>
        Public Property deudorname As String

        <Display(Name:="Cliente/Deudor")>
        Public Property deudor As Integer?

        <Display(Name:="Reenviar")>
        Public Property filename As String

        <Display(Name:="Correo")>
        Public Property envio As String

        <Display(Name:="Tipo")>
        Public Property descrip As String

        Public Property email As String

        Public Property confirma As Boolean?

        Public Property evidencia As String

        <Display(Name:="Ver archivo")>
        Public Property void As Boolean?

        Public Property void2 As Boolean

        <Display(Name:="Factoraje con recurso")>
        Public Property recurso As Boolean

        <Display(Name:="Incluir acuse de recibo")>
        Public Property acuse As Boolean

        <Display(Name:="Factoraje a proveedores")>
        Public Property proveedor As Boolean

        <Display(Name:="Incluir testigos")>
        Public Property testigos As Boolean

        Public Property calle As String

        Public Property noext As Integer

        Public Property noint As Integer

        Public Property domicilio As String

        Public Property municipio As String

        Public Property estado As String

        Public Property colonia As String

    End Class


End Namespace

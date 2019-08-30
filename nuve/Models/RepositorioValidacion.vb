﻿Imports FactorEntidades
Imports FactorBAL

Public Class RepositorioValidacion

	Public Function ValidarRFC(rfc As String, tabla As String, ByRef Nombre1 As String, ByVal Id1 As String, param1 As String, param2 As String, clave As Integer, ByRef existe As Boolean) As Result
		Dim consulta = New FactorBAL.Utility()
		Return consulta.ConsultaRFC(rfc, tabla, Nombre1, Id1, param1, param2, clave, existe)
	End Function

    Function ValidarCLABE(clabe As String, ByRef existe As Boolean, numrec As Integer) As Object
        Dim consulta = New Utility()
        Return consulta.ConsultaCLABE(clabe, existe, numrec)

    End Function

	Public Function ValidaDeudor(deudor As Integer, producto As Integer, ByRef existe As Boolean) As Result
		Dim consulta = New Utility()
		Return consulta.ConsultaDeudor(deudor, producto, existe)
	End Function

	Public Function ExisteAnexoContrato_Deudor(deudor As Integer, contrato As Integer, ByRef nombre As String, producto As Integer, ByRef existe As Boolean) As Result
		Dim consulta = New Utility()
		Return consulta.ExisteAnexoContrato_Deudor(deudor, contrato, nombre, producto, existe)
	End Function

	Function validarSirac(sirac As Integer, deudor As Integer, ByRef existe As Boolean, ByRef nombre As String) As Result
		Dim consulta = New Utility()
		Return consulta.validarSirac(sirac, deudor, existe, nombre)
	End Function

	Function validarFira(fira As Decimal, deudor As Integer, ByRef existe As Boolean, ByRef nombre As String) As Result
		Dim consulta = New Utility()
		Return consulta.validarFira(fira, deudor, existe, nombre)
	End Function

End Class

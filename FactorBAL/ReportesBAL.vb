﻿Imports FactorEntidades
Imports FactorDAL


Public Class ReportesBAL

	Function ReporteVencimientosNafinBAL(moneda As Integer, tipo As String, inicio As Date, fin As Date, ByRef model As sp_vencimientosnafin) As Result
		Dim consulta = New ReportesDAL()
		Return consulta.vencimientoFondeoNafin(moneda, tipo, inicio, fin, model)
	End Function

	Public Function ConsultaDepositosBAL(fecha As String, idctabanco As Integer, ByRef model As List(Of ReporteDepositos)) As Result
		Dim consulta As New ReportesDAL()
		Return consulta.ConsultaDepositosDAL(fecha, idctabanco, model)
	End Function

	Public Function ConsultaSalidasBAL(fecha As String, idctabanco As Integer, ByRef model As List(Of ReporteDepositos)) As Result
		Dim consulta As New ReportesDAL()
		Return consulta.ConsultaSalidasDAL(fecha, idctabanco, model)
	End Function

	Public Function ConsultaReportesBAL(ByRef model As List(Of ReporteEntidad)) As Result
		Dim consulta As New ReportesDAL()
		Return consulta.ConsultaReportesDAL(model)
	End Function

	Public Function ReportecobranzaBAL(fecha As String, contrato As Integer, ByRef model As List(Of CobranzaEntidad)) As Result
		Dim consulta As New ReportesDAL()
		Return consulta.ReportecobranzaDAL(fecha, contrato, model)
	End Function

	Public Function ReporteaforoBAL(fecha As String, contrato As Integer, ByRef model As List(Of CobranzaEntidad)) As Result
		Dim consulta As New ReportesDAL()
		Return consulta.ReporteaforoDAL(fecha, contrato, model)
	End Function

	Public Function ReporteadeudosBAL(moneda As Integer, ByRef model As List(Of adeudosEntidad)) As Result
		Dim consulta As New ReportesDAL()
		Return consulta.ReporteadeudosDAL(moneda, model)
	End Function

	Public Function ConsultaHistDocBAL(model As HistoriaDocumento) As Result
		Dim consulta As New ReportesDAL()
		Return consulta.ConsultaHistDocDAL(model)
	End Function

	'Function ConsultaClienteBAL(model As HistoriaDocumento) As Object
	'	Dim consulta As New ReportesDAL()
	'	Return consulta.ConsultaClienteDAL(model)
	'End Function

	Function obtenerSaldosBAL(contrato As Integer, anio As Integer, ByRef listaReportes As List(Of SaldosEntidad)) As Result
		Dim consulta As New ReportesDAL()
		Return consulta.obtenerSaldosDAL(contrato, anio, listaReportes)
	End Function

	Function consultaClienteBAL(ByRef repote As reporteSaldos, contrato As Integer) As Object
		Dim consulta As New ReportesDAL()
		Return consulta.consultaClienteDAL(repote, contrato)
	End Function

	Function obtenerLineasFactor(ByRef lista As List(Of LineasFactor)) As Object
		Dim consulta As New ReportesDAL()
		Return consulta.obtenerLineasFactor(lista)
	End Function

	Function ReporteDocPorDescontarBAL(opcion As Boolean, contrato As Integer, ByRef lista As List(Of SP_ReporteDocSinDescontar)) As Result
		Dim consulta As New ReportesDAL()
		Return consulta.obtenerLineasFactorDAL(opcion, contrato, lista)
	End Function

	Function ConsultaHistoriaAdeudoBAL(serie As String, docto As String, ByRef detalle As RespHistAdeudo) As Object
		Dim consulta As New ReportesDAL()
		Return consulta.ConsultaHistoriaAdeudoDAL(serie, docto, detalle)
	End Function

	Function consultarContratoDocumentoBAL(contrato As Integer, documento As String, ByRef docto As doctoentidad, ByRef lista As List(Of Integer), deudor As Integer) As Result
		Dim consulta As New ReportesDAL()
		Return consulta.consultarContratoDocumentoDAL(contrato, documento, docto, lista, deudor)
	End Function

	Function ConsultaOperacionesBAL(tipo As Integer, ByRef lista As List(Of Sp_GraficaOperacion)) As Result
		Dim consulta As New ReportesDAL()
		Return consulta.ConsultaOperacionesDAL(tipo, lista)
	End Function

	Function ConsultaCarteraBAL(ByRef lista As List(Of Sp_GraficaCartera)) As Result
		Dim consulta As New ReportesDAL()
		Return consulta.ConsultaCarteraDAL(lista)
	End Function

	Function consultaColoCbrnzaBAL(ByRef lista As List(Of SP_GraficaColocacion)) As Object
		Dim consulta As New ReportesDAL()
		Return consulta.consultaColoCbrnzaDAL(lista)
	End Function

	Public Function RebatemensualBAL(mes As String, anio As String, ByRef model As List(Of Rebate)) As Result
		Dim consulta As New ReportesDAL()
		Return consulta.RebatemensualDAL(mes, anio, model)
	End Function

End Class

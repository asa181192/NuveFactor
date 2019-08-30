﻿Imports FactorEntidades
Imports FactorDAL

Public Class FacturacionBAL

	Public Function ConsultaFacturasBAL(ByRef model As List(Of FacturacionEntidad), serie As String, fecha As Date) As Result
		Dim consulta = New FacturacionDAL()
		Return consulta.ConsultaFacturasDAL(model, serie, fecha)
	End Function

	Function ConsultaDetalleBAL(ByRef list As List(Of fiscalpv), sisfol As Integer, serie As String) As Result
		Dim consulta = New FacturacionDAL()
		Return consulta.ConsultaDetalleDAL(list, sisfol, serie)
	End Function

	Function GetContratoBAL(contrato As Integer, ByRef model As FacturacionEntidad) As Result
		Dim consulta = New FacturacionDAL()
		Return consulta.GetContratoDAL(contrato, model)
	End Function

	Function GetIdBAL(deudor As Integer, id As Integer, ByRef nombre As String) As Result
		Dim consulta = New FacturacionDAL()
		Return consulta.GetIdDAL(deudor, id, nombre)
	End Function

	Function CargaConceptosBAL(ByRef conceptos As List(Of cfiscales), tipo As String) As Result
		Dim consulta As New FacturacionDAL()
		Return consulta.CargaConceptosDAL(conceptos, tipo)
	End Function

	Function GuardarFacturaBAL(model As FacturacionEntidad) As Result
		Dim consulta = New FacturacionDAL()
		Return consulta.GuardarFacturaDAL(model)
	End Function

	Function GetPorcentajeBAL(contrato As Integer, ByRef porcentaje As Decimal) As Result
		Dim consulta = New FacturacionDAL()
		Return consulta.GetPorcentajeDAL(contrato, porcentaje)
	End Function

	Function ValidDoctosBAL(sisfol As Integer, serie As String, ByRef model As FacturacionEntidad) As Result
		Dim consulta = New FacturacionDAL()
		Return consulta.ValidDoctosDAL(sisfol, serie, model)
	End Function

	Function GuardarNotaCreditoBAL(model As FacturacionEntidad, ByRef process As Boolean) As Result
		Dim consulta = New FacturacionDAL()
		Return consulta.GuardarNotaCreditoDAL(model, process)
	End Function

	Function GuardarRemisionesBAL(ByRef model As FacturacionEntidad, ByRef process As Boolean) As Result
		Dim consulta = New FacturacionDAL()
		Return consulta.GuardarRemisionesDAL(model, process)
	End Function

	Function GetPdfBAL(factura As String, ByRef archivo As Byte(), tipo As Integer) As Result
		Dim consulta = New FacturacionDAL()
		Return consulta.GetFacturaFileDAL(factura, archivo, tipo)
	End Function

	Function CancelarFacturaBAL(serie As String, sisfol As Integer, ByRef process As String) As Result
		Dim consulta = New FacturacionDAL()
		Return consulta.CancelarFacturaDAL(serie, sisfol, process)
	End Function

	Function SustituirFolioSatBAL(sat As Integer, ByRef process As String) As Result
		Dim consulta = New FacturacionDAL()
		Return consulta.SustituirFolioSatDAL(sat, process)
	End Function

	Function GenerarBAL(fecha As String, ByRef process As String) As Result
		Dim consulta = New FacturacionDAL()
		Return consulta.GenerarDAL(fecha, process)
	End Function

	Function ConsultaComplemento(tipo As Integer, fecha As Date, ByRef lista As List(Of FacturacionEntidad)) As Result
		Dim consulta = New FacturacionDAL()
		Return consulta.ConsultaComplementoDAL(tipo, fecha, lista)
	End Function

	Function enviarFacturaBAL(factura As String, identidad As Integer, id As Integer, numrec As Integer, tipo As Integer) As Result
		Dim consulta = New FacturacionDAL()
		Return consulta.enviarFacturaDAL(factura, identidad, id, numrec, tipo)
	End Function

	Function EnvioMasivoBal(fecha As Date, tipo As Integer) As Result
		Dim consulta = New FacturacionDAL()
		Return consulta.EnvioMasivoDal(fecha, tipo)
	End Function

End Class

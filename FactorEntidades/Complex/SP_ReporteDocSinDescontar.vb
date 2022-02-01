﻿Public Class SP_ReporteDocSinDescontar
	Public Property Entidad As String '(char(100), null)
	Public Property Contrato As Integer?	'(int, null)
	Public Property Moneda As String '(varchar(15), not null)
	Public Property Deudor As Integer? '(int, null)
	Public Property Nombre As String '(varchar(max), null)
	Public Property RFC As String '(char(15), null)
	Public Property Docto As String	'(char(20), null)
	Public Property Monto As Decimal? '(decimal(14,2), null)
	Public Property Responsable As String '(char(100), null)
	Public Property Telefono As String '(char(50), null)
	Public Property eMail As String	'(varchar(30), null)
	Public Property Autoriza As DateTime? '(datetime, null)
	Public Property Fec_Vence As DateTime? '(datetime, null)
	Public Property dispersion As Boolean? '(bit, null)
	Public Property nofinan As Integer?	'(int, not null)
	Public Property Plazo As Integer? '(int, null)
End Class
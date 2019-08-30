Public Class HistoriaDocumento
	Public Property iddocto As Decimal

	Public Property contrato As Integer?

	Public Property docto As String

	Public Property nombreCliente As String

	Public Property producto As Integer

	Public Property moneda As Integer

	Public Property interes As Integer

	Public Property cesion As Integer

	Public Property porcanti As Decimal

	Public Property fec_alta As Date

	Public Property fec_vence As Date

	Public Property monto As Decimal

	Public Property saldo As Decimal

	Public Property plaza As String

	Public Property c_delegada As Integer

	Public Property deudor As Integer

	Public Property nombreDocumento As String

	Public Property fmvto As Date

	Public Property Tasaoper As Decimal

	Public Property pagos As List(Of registroPago)

End Class

Public Class registroPago
	Public Property importe As Decimal

	Public Property fecha As String
End Class
Public Class RespHistAdeudo
	Public Property deudor As Integer
	Public Property contrato As Integer
	Public Property nombre As String
	Public Property fec_alta As Date
	Public Property monto As Decimal
	Public Property saldo As Decimal
	Public Property idadeudo As Integer
	Public Property pagos As List(Of pagos)
End Class

Public Class pagos
	Public Property fecha As Date?
	Public Property importe As Decimal
	Public Property concepto As String
End Class
Imports FactorEntidades

Public Class doctoentidad
	Public Property deudor As Integer?
	Public Property contrato As Integer?
	Public Property iddocto As Integer?
	Public Property nombreproveedor As String
	Public Property nombrecliente As String
	Public Property producto As Integer?
	Public Property divisa As Integer?
	Public Property interes As Integer?
	Public Property idcesion As Integer
	Public Property tasa As Decimal?
	Public Property altacesion As Date?
	Public Property porc_anti As Decimal?
	Public Property porcanticipo As Decimal?
	Public Property importe As Decimal?
	Public Property fechaVencedocto As Date?
	Public Property fechavencecesion As Date?
	Public Property saldo As Decimal?
	Public Property historiapagos As List(Of historiapagos)
End Class

Public Class historiapagos
	Public Property fecha As Date?
	Public Property monto As Decimal?
End Class
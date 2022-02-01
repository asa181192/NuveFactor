﻿Imports System.ComponentModel.DataAnnotations.Schema
Imports System.ComponentModel.DataAnnotations

Public Class ControlRiesgo

	Public Property id_rec As String

	Public Property clientet24 As Decimal

	Public Property cliente As Integer

	Public Property nombre As String

	Public Property ldescrip As String

	Public Property lmonto As Decimal

	Public Property lutilizado As Decimal

	Public Property ldisponibl As Decimal

	Public Property lvence As Date

	Public Property porcentaje As Decimal

	Public Property cuenta As String

	Public Property adeudo As Decimal

	Public Property vencida As Decimal

	Public Property garantsdo As Decimal

	Public Property garantutl As Decimal

	Public Property lmultiple As Decimal

	Public Property idmultiple As String

	Public Property dropdown As List(Of DropDownEntidad)

	Public Property claves As String()

	Public Property lcredito As String

	Public Property RgoDesc As String
	Public Property gliq As String
	Public Property Cancela As String
	Public Property Infolinea As String
	Public Property Div As String

End Class

Public Class ControlCliente

	Public Property riesgo As Decimal
	Public Property rgpo As Boolean
	Public Property riesgogpo As Decimal
	Public Property voboreg As Boolean
	Public Property vobo As Boolean
	Public Property tipoCambio As Decimal
	Public Property Paridad As Decimal

End Class

Public Class ControlRiesgo_Cliente

	Public Property controlRiesgo As List(Of ControlRiesgo)
	Public Property cliente As ControlCliente

End Class
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class indicadores
	<Key>
	Public Property fecha As Date?

	<Column(Order:=0, TypeName:="numeric")>
	Public Property cetes28 As Decimal


	<Column(Order:=1, TypeName:="numeric")>
	Public Property cetes91 As Decimal


	<Column(Order:=2, TypeName:="numeric")>
	Public Property cpp As Decimal


	<Column(Order:=3, TypeName:="numeric")>
	Public Property tiip As Decimal


	<Column(Order:=4, TypeName:="numeric")>
	Public Property tiie As Decimal


	<Column(Order:=5, TypeName:="numeric")>
	Public Property tiie91 As Decimal


	<Column(Order:=6, TypeName:="numeric")>
	Public Property fondeo As Decimal


	<Column(Order:=7, TypeName:="numeric")>
	Public Property libor As Decimal


	<Column(Order:=8, TypeName:="numeric")>
	Public Property libor3m As Decimal


	<Column(Order:=9)>
	Public Property void As Boolean


	<Column(Order:=10, TypeName:="numeric")>
	Public Property fondeousd As Decimal


	<Column(Order:=11, TypeName:="numeric")>
	Public Property libor6m As Decimal


	<Column(Order:=12, TypeName:="numeric")>
	Public Property libor12m As Decimal
End Class

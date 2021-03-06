Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("anexo")>
Partial Public Class anexo
	<Key>
	<Column(Order:=0)>
	<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
	Public Property anexoid As Integer

	<Key>
	<Column(Order:=1)>
	Public Property contrato As Integer?

	<Key>
	<Column(Order:=2)>
	Public Property deudor As Integer?

	Public Property mancobranza As Boolean?

	Public Property notifica As Boolean?

	Public Property activo As Boolean?

	Public Property cancelado As Boolean?

	<StringLength(20)>
	Public Property catcte As String

	Public Property imprimir As Boolean?

	<Column(TypeName:="numeric")>
	Public Property sobretasa As Decimal?

	<Column(TypeName:="numeric")>
	Public Property limite As Decimal?

	Public Property void As Boolean?

	Public Property modifica As Boolean?

	<StringLength(10)>
	Public Property updaterec As String
End Class

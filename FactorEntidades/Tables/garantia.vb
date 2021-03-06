Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("garantia")>
Partial Public Class garantia
	<Key>
	<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
	Public Property garantiaid As Integer

	Public Property contrato As Integer?

	Public Property cesion As Integer?

	Public Property codigo As Integer?

	Public Property tipo As Integer?

	<Column(TypeName:="numeric")>
	Public Property valor As Decimal?

	<Column(TypeName:="numeric")>
	Public Property porcentaje As Decimal?

	<Column(TypeName:="numeric")>
	Public Property costo As Decimal?

	<Column(TypeName:="numeric")>
	Public Property cobrado As Decimal?

	<Column(TypeName:="numeric")>
	Public Property ivacobrado As Decimal?

	Public Property cancelado As Boolean

	Public Property fec_alta As Date?

	<Column(TypeName:="numeric")>
	Public Property valor_ant As Decimal?

	<Column(TypeName:="numeric")>
	Public Property saldo As Decimal?

	Public Property void As Boolean
End Class

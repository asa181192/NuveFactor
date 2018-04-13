Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("paridad")>
Partial Public Class paridad
	<Key>
	<Display(Name:="Fecha")>
	Public Property fecha As Date?

	<Column("paridad", TypeName:="money")>
	<Display(Name:="Peso-Dolar")>
	Public Property paridad1 As Decimal?

	<Column(TypeName:="numeric")>
	<Display(Name:="Peso-UDIS")>
	Public Property udis As Decimal?

	Public Property void As Boolean

End Class

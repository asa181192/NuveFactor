Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class remanentes
	<Key>
	<Column(Order:=0)>
	Public Property contrato As Integer?

	<Column(TypeName:="numeric")>
	Public Property remanente As Decimal?

	<Column(TypeName:="numeric")>
	Public Property anterior As Decimal?

	Public Property fec_change As Date?

	<StringLength(40)>
	Public Property movto As String

	<Key>
	<Column(Order:=1)>
	Public Property id As Integer?

	<Key>
	<Column(Order:=2)>
	Public Property identidad As Integer?

	Public Property void As Boolean
End Class

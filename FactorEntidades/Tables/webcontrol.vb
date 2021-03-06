Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("webcontrol")>
Partial Public Class webcontrol

	<Key>
	<Column(Order:=0)>
	   Public Property registro As Integer?

	Public Property baskets As Integer?

	<Column(TypeName:="numeric")>
	Public Property tasa As Decimal?

	<Column(TypeName:="numeric")>
	Public Property tasadlls As Decimal?

	Public Property folio As Integer?

	Public Property cuentaid As Integer?

	Public Property online As Boolean

	Public Property timeinit As Date?

	Public Property timeend As Date?

	Public Property timecte As Date?

	Public Property envios As Integer?

	Public Property autoriza As Integer?

	<StringLength(50)>
	Public Property mailserver As String

	Public Property expiration As Integer?

	<StringLength(50)>
	Public Property dominio As String

	<Key>
	<Column(Order:=1)>
	Public Property void As Boolean

	<StringLength(10)>
	Public Property sv As String

	Public Property dplazo As Integer?

	<StringLength(2)>
	Public Property factura As String

	<StringLength(2)>
	Public Property serie As String

	Public Property notifica As Integer?

	Public Property pagolinea As Integer?

	<StringLength(12)>
	Public Property ctausd As String

	<StringLength(11)>
	Public Property ctamxn As String

	Public Property idbx As Integer?

	Public Property docprov As Integer?

	<StringLength(2)>
	Public Property factother As String

	Public Property folcfdi As Integer?
End Class

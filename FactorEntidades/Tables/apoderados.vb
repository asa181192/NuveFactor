Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class apoderados
	Public Property id As Integer

	Public Property cliente As Integer?

	<StringLength(50)>
	Public Property apoderado As String

	Public Property ap_domicilio As String

	<StringLength(20)>
	Public Property ap_ecivil As String

	<StringLength(20)>
	Public Property ap_ocupa As String

	Public Property ap_fnac As Date?

	Public Property ep_numnot As Integer?

	<StringLength(40)>
	Public Property ep_nombre As String

	Public Property ep_escrit As Integer?

	Public Property ep_fecha As Date?

	<StringLength(40)>
	Public Property ep_localidad As String

	<StringLength(10)>
	Public Property ep_numero As String

	<StringLength(10)>
	Public Property ep_folio As String

	<StringLength(10)>
	Public Property ep_libro As String

	<StringLength(10)>
	Public Property ep_auxiliar As String

	<StringLength(10)>
	Public Property ep_volumen As String

	Public Property ep_fechareg As Date?

	<StringLength(40)>
	Public Property ep_poderlocal As String

	Public Property dominio As Boolean?

	Public Property dfacultad As Boolean?

	Public Property endoso As Boolean?

	Public Property efacultad As Boolean?

	Public Property cancelado As Boolean?

	Public Property admon As Boolean?

	Public Property afacultad As Boolean?

	<StringLength(15)>
	Public Property nacion As String

	Public Property esapoderado As Boolean?

	Public Property esobligado As Boolean?

	<StringLength(50)>
	Public Property ap_colonia As String

	Public Property ap_ciudad As Integer?

	Public Property ap_estado As Integer?

	Public Property ap_cp As Integer?

	Public Property politica As Boolean?

	Public Property pfisica As Boolean?

	Public Property n As String

	Public Property s As String

	Public Property p As String

	Public Property m As String

	<StringLength(50)>
	Public Property telefono As String

	<StringLength(15)>
	Public Property rfc As String

	<StringLength(20)>
	Public Property curp As String

	Public Property esaccion As Boolean?

	<Column(TypeName:="numeric")>
	Public Property porcentaje As Decimal?

	Public Property esdeposita As Boolean?

	Public Property fec_update As Date?

	Public Property void As Boolean?

	Public Property idtransact As String
End Class


Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports FactorEntidades

Namespace Models

	Public Class ModeloPar

		<Display(Name:="Fecha")>
		Public Property fecha() As String

		<Required>
		<Display(Name:="Peso-Dolar")>
		Public Property paridad() As Decimal?

		<Required>
		<Display(Name:="Peso-UDIS")>
		Public Property udis() As Decimal?

		Public Property void() As Boolean

		Public Property add() As Boolean 'Propiedad control para insertar o actualizar

	End Class

	Public Class ModeloProveedor
		Inherits ProveedorEntidad

		<Display(Name:="Firmado")>
		Public Overloads Property firmado() As Boolean

		<Display(Name:="Formado")>
		Public Overloads Property elaborado() As Boolean

		<Display(Name:="Rectificado")>
		Public Overloads Property rectificado() As Boolean

		<Display(Name:="Internet")>
		Public Overloads Property internet() As Boolean

		'Public Property sucursal As Integer?

		'Public Property fec_alta As Date?

		'<Key>
		'<Display(Name:="Deudor")>
		'Public Property deudor As Integer

		'<StringLength(100)>
		'<Display(Name:="Nombre")>
		'Public Property nombre As String

		'<StringLength(50)>
		'Public Property domicilio As String

		'<StringLength(50)>
		'Public Property colonia As String

		'<StringLength(50)>
		'Public Property municipio As String

		'<StringLength(50)>
		'Public Property estado As String

		'<StringLength(50)>
		'Public Property telefono As String

		'Public Property cp As Integer?

		'<StringLength(50)>
		'Public Property responsable As String

		'<StringLength(3)>
		'Public Property plaza As String

		'Public Property plazacob As Integer?

		'<StringLength(50)>
		'Public Property giro As String

		'<StringLength(15)>
		'Public Property rfc As String

		'<StringLength(20)>
		'Public Property curp As String

		'Public Property elaborado As Boolean

		'Public Property firmado As Boolean

		'Public Property rectificado As Boolean

		'Public Property historia As Boolean?

		'<Column(TypeName:="text")>
		'Public Property notas As String

		'<Column(TypeName:="text")>
		'Public Property email As String

		'<StringLength(10)>
		'Public Property password As String

		'Public Property internet As Boolean

		'Public Property regiva As Integer?

		'<Column(TypeName:="numeric")>
		'Public Property sirac As Decimal?

		'Public Property promotor As Integer?

		'Public Property void As Boolean?

		'<StringLength(50)>
		'Public Property calle As String

		'<StringLength(15)>
		'Public Property noext As String

		'<StringLength(15)>
		'Public Property noint As String

		'<Column(TypeName:="numeric")>
		'Public Property enviafact As Decimal?

		'<Column(TypeName:="numeric")>
		'Public Property repeco As Decimal?

		'Public Property fec_update As Date?

		'Public Property folio_envio As Integer?

		'<StringLength(10)>
		'Public Property updaterec As String

		'Public Property modifica As Boolean?

		'<Column(TypeName:="numeric")>
		'Public Property fira_idcon As Decimal?

		'<StringLength(36)>
		'Public Property idtransact As String
	End Class

End Namespace
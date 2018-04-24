
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports FactorEntidades

Namespace Models

	Public Class ModeloPar
		Inherits paridad

		<Display(Name:="Fecha")>
		<DataType(DataType.Date)>
		<DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}", ApplyFormatInEditMode:=True)> _
		Public Overloads Property fecha() As Date?

		<Required>
		<Display(Name:="Peso-Dolar")>
		Public Overloads Property paridad1() As Decimal?

		<Required>
		<Display(Name:="Peso-UDIS")>
		Public Overloads Property udis() As Decimal?

		Public Property add() As Boolean 'Propiedad control para insertar o actualizar

	End Class

	Public Class ModeloProveedor
		Inherits proveedor

		Sub New()
			SucursalDropDown = New controles().CargaSucursales()
			RegimenDropDown = New controles().CargaRegimen()
		End Sub

		<Display(Name:="Firmado")>
		Public Overloads Property firmado() As Boolean

		<Display(Name:="Sucursal")>
		Public Overloads Property sucursal() As Integer?

		<Display(Name:="Fecha de alta")>
		Public Overloads Property fec_alta As Date?

		<Display(Name:="Formado")>
		Public Overloads Property elaborado() As Boolean

		<Display(Name:="Rectificado")>
		Public Overloads Property rectificado() As Boolean

		<Display(Name:="Internet")>
		Public Overloads Property internet() As Boolean

		<Display(Name:="Fira")>
		<RegularExpression("[0-9]+(\.[0-9][0-9]?)?", ErrorMessage:="El Valor debe ser numerico")>
		Public Overloads Property fira_idcon As Decimal?

		Public SucursalDropDown As List(Of SelectListItem)

		Public RegimenDropDown As List(Of SelectListItem)

		<Display(Name:="Municipio")>
		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		Public Overloads Property municipio() As String

		<Display(Name:="Nombre")>
		<StringLength(100, ErrorMessage:="Demasiados Caraceteres")>
		Public Overloads Property nombre() As String

		<Display(Name:="Domicilio")>
		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		Public Overloads Property domicilio As String

		<Display(Name:="Colonia")>
		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		Public Overloads Property colonia As String

		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="Estado")>
		Public Property estado As String

		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="Telefono")>
		Public Property telefono As String

		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="Responsable")>
		Public Property responsable As String

		<StringLength(3, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="Plaza")>
		Public Property plaza As String

		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="Giro")>
		Public Property giro As String

		<StringLength(15, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="RFC")>
		Public Property rfc As String

		<StringLength(20, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="Curp")>
		Public Property curp As String

		<StringLength(10, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="Password")>
		Public Property password As String

		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="Calle")>
		Public Property calle As String

		<StringLength(15, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="No. Ext")>
		Public Property noext As String

		<StringLength(15, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="No. Int")>
		Public Property noint As String

	End Class

	Public Class ModeloComprador
		Inherits comprador

		Sub New()
			SucursalDropDown = New controles().CargaSucursales()
			RegimenDropDown = New controles().CargaRegimen()
		End Sub

		Public SucursalDropDown As List(Of SelectListItem)

		Public RegimenDropDown As List(Of SelectListItem)
	End Class

End Namespace
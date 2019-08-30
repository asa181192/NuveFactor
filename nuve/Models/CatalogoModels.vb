﻿
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports FactorEntidades
Imports nuve.CustomValidations

Namespace Models

	Public Class ModeloPar

		<Display(Name:="Fecha")>
		<DataType(DataType.Date)>
		<DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}", ApplyFormatInEditMode:=True)>
		Public Property fecha() As Date?

		<Display(Name:="mifecha")>
		<DataType(DataType.Date)>
		<DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}", ApplyFormatInEditMode:=True)>
		Public Property mifecha() As Date?

		<Required(ErrorMessage:="EL campo Paridad es obligatorio.")>
		<Display(Name:="Paridad")>
		<DisplayFormat(DataFormatString:="{0:0.0000}", ApplyFormatInEditMode:=True)>
		<RegularExpression("\d+(\.\d{0,4})?", ErrorMessage:="El Valor debe ser numerico o no tener mas de 4 decimales")>
		<Range(1.0, Double.PositiveInfinity, ErrorMessage:="El valor debe ser mayor a 0")>
		Public Property paridad1() As Decimal

		<Required(ErrorMessage:="EL campo Peso-UDIS es obligatorio.")>
		<Display(Name:="Udis-Peso")>
		<DisplayFormat(DataFormatString:="{0:n8}", ApplyFormatInEditMode:=True)>
		<RegularExpression("^\d{0,3}(\.\d{0,8})?", ErrorMessage:="El Valor debe ser numerico, no contar con mas de 8 decimales")>
		Public Property udis() As Decimal

		Public Property add() As Boolean 'Propiedad control para insertar o actualizar

	End Class
	Public Class ModeloProveedor

		Public Sub CargaControles()
			SucursalDropDown = New controles().CargaSucursales()
			RegimenDropDown = New controles().CargaRegimen()
			FelectronicaDropDown = New controles().CargaFelectronica()
		End Sub

		Public FelectronicaDropDown As List(Of SelectListItem)

		<Display(Name:="Deudor")>
		Public Property deudor As Integer

		<Display(Name:="Envio de Factura")>
		Public Property enviafact As Decimal

		<Display(Name:="Numero de Sirac")>
		<Required(ErrorMessage:="El campo Sirac es Obligatorio")>
		<RegularExpression("^\d{0,10}(\.\d{0})?", ErrorMessage:="El Valor debe ser numerico y no tener decimales")>
		<Remote("validaSirac", "Catalogos", AdditionalFields:="deudor")>
		Public Property sirac As Decimal

		<Display(Name:="Codigo Postal")>
		<RegularExpression("^[0-9]*$", ErrorMessage:="El Valor debe ser numerico")>
		<Required(ErrorMessage:="El campo C.P. es Obligatorio")>
		Public Property cp As Integer?

		<Display(Name:="Email")>
		<Required(ErrorMessage:="El campo Email es Obligatorio")>
		Public Property email As String

		<Display(Name:="Plaza de Cobro")>
		Public Property plazacob As Integer

		<Display(Name:="Regimen de IVA")>
		Public Property regiva As Integer?

		<Display(Name:="Notas")>
		Public Property notas As String

		<Display(Name:="Firmado")>
		Public Property firmado() As Boolean

		<Display(Name:="Sucursal")>
		Public Property sucursal() As Integer

		<Display(Name:="Fecha de alta")>
		Public Property fec_alta As Date?

		<Display(Name:="Formado")>
		Public Property elaborado() As Boolean

		<Display(Name:="Rectificado")>
		Public Property rectificado() As Boolean

		<Display(Name:="Internet")>
		Public Property internet() As Boolean

		<Display(Name:="Fira")>
		<RegularExpression("^\d{0,10}(\.\d{0})?", ErrorMessage:="El Valor debe ser numerico y no tener decimales")>
		<Remote("validaFira", "Catalogos", AdditionalFields:="deudor")>
		Public Property fira_idcon As Decimal

		Public SucursalDropDown As List(Of SelectListItem)

		Public RegimenDropDown As List(Of SelectListItem)

		<Display(Name:="Municipio")>
		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		Public Property municipio() As String

		<Display(Name:="Nombre")>
		<Required(ErrorMessage:="El campo Nombre es Obligatorio")>
		Public Property nombre() As String

		<Display(Name:="Domicilio")>
		<Required(ErrorMessage:="El campo Domicilio es Obligatorio")>
		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		Public Property calle As String

		<Display(Name:="Colonia")>
		<Required(ErrorMessage:="El campo Nombre es Obligatorio")>
		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		Public Property colonia As String

		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="Estado")>
		Public Property estado As String

		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="Telefono")>
		<Required(ErrorMessage:="El campo Telefono es Obligatorio")>
		Public Overloads Property telefono As String

		<StringLength(1000, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="Responsable")>
		Public Property responsable As String

		<StringLength(3, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="Plaza")>
		Public Property plaza As String

		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		<Required(ErrorMessage:="El campo Giro es Obligatorio")>
		<Display(Name:="Giro")>
		Public Overloads Property giro As String


		<Remote("ValidarProveedorRFC", "Catalogos", AdditionalFields:="deudor")>
		<StringLength(15, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="RFC")>
		<Required(ErrorMessage:="El campo RFC es Obligatorio")>
		Public Overloads Property rfc As String

		<StringLength(20, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="CURP")>
		Public Overloads Property curp As String

		<StringLength(10, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="Password")>
		Public Overloads Property password As String

		<StringLength(15, ErrorMessage:="Demasiados Caraceteres")>
		<Required(ErrorMessage:="El campo Ext es Obligatorio")>
		<Display(Name:="No. Ext")>
		Public Overloads Property noext As String

		<StringLength(1000, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="No. Int")>
		Public Overloads Property noint As String

	End Class
	Public Class ModeloComprador

		Public Sub CargaControles()
			SucursalDropDown = New controles().CargaSucursales()
			RegimenDropDown = New controles().CargaRegimen()
			DiasDropDown = New controles().CargaDias()
			FelectronicaDropDown = New controles().CargaFelectronica()
		End Sub

		Public SucursalDropDown As List(Of SelectListItem)
		Public RegimenDropDown As List(Of SelectListItem)
		Public DiasDropDown As List(Of SelectListItem)
		Public FelectronicaDropDown As List(Of SelectListItem)

		<Display(Name:="Sucursal")>
		Public Property sucursal As Integer?

		<Display(Name:="Fecha de Alta")>
		<DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}", ApplyFormatInEditMode:=True)>
		Public Property fec_alta As Date?

		<Display(Name:="Deudor")>
		Public Property deudor As Integer

		<Display(Name:="Nombre")>
		<StringLength(100, ErrorMessage:="Demasiados Caraceteres")>
		<Required(ErrorMessage:="El campo Nombre es Obligatorio")>
		Public Property nombre As String

		<Display(Name:="Domiclio")>
		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		<Required(ErrorMessage:="El campo Domicilio es Obligatorio")>
		Public Property calle As String

		<Display(Name:="Colonia")>
		<Required(ErrorMessage:="El campo Colonia es Obligatorio")>
		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		Public Property colonia As String

		<Display(Name:="Municipio")>
		<Required(ErrorMessage:="El campo Municipio es Obligatorio")>
		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		Public Property municipio As String

		<Display(Name:="Estado")>
		<Required(ErrorMessage:="El campo Estado es Obligatorio")>
		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		Public Property estado As String

		<Display(Name:="Telefono")>
		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		Public Property telefono As String

		<Display(Name:="Codigo Postal")>
		<RegularExpression("^[0-9]*$", ErrorMessage:="El Valor debe ser numerico")>
		<Required(ErrorMessage:="El campo C.P. es Obligatorio")>
		Public Property cp As Integer

		<Display(Name:="Día de Revision")>
		Public Property revision As Integer?

		<Display(Name:="Día de Cobro")>
		Public Property cobranza As Integer?

		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="Responsable de Pagos")>
		Public Property responsable As String

		<Display(Name:="Plaza")>
		<StringLength(3, ErrorMessage:="Demasiados Caraceteres")>
		Public Property plaza As String

		<Display(Name:="Plaza de Cobro")>
		Public Property plazacob As Integer?

		<Display(Name:="Giro")>
		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		Public Property giro As String

		<StringLength(15, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="R.F.C.")>
		<Remote("ValidarCompradorRFC", "Catalogos", AdditionalFields:="deudor")>
		<Required(ErrorMessage:="El campo R.F.C. es Obligatorio")>
		Public Property rfc As String

		<Display(Name:="C.U.R.P.")>
		<StringLength(20, ErrorMessage:="Demasiados Caraceteres")>
		Public Property curp As String

		<Display(Name:="Contrato Elaborado")>
		Public Property elaborado As Boolean

		<Display(Name:="Contrato Firmado")>
		Public Property firmado As Boolean

		<Display(Name:="Contrato Rectificado")>
		Public Property rectificado As Boolean


		Public Property notas As String

		<Display(Name:="Regimen de IVA")>
		Public Property regiva As Integer?

		<DataType(DataType.Currency)>
		<DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
		<RegularExpression("^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,4})?))\)?$", ErrorMessage:="El Valor debe ser numerico o no tener mas de 2 decimales")>
		Public Property cobertura As Decimal

		<Display(Name:="Plazo (días)")>
		<RegularExpression("^[0-9]*$", ErrorMessage:="El Valor debe ser numerico")>
		Public Property plazo As Integer?

		<Display(Name:="Seguro de Crédito")>
		Public Property seguro As Boolean

		<Display(Name:="Endoso")>
		<DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}", ApplyFormatInEditMode:=True)>
		Public Property endoso As Date?

		<Display(Name:="Código")>
		<StringLength(10, ErrorMessage:="Demasiados Caraceteres")>
		Public Property idmapfre As String


		<Display(Name:="Numero Exterior")>
		<StringLength(15, ErrorMessage:="Demasiados Caraceteres")>
		Public Property noext As String

		<Display(Name:="Numero Interior")>
		<StringLength(15, ErrorMessage:="Demasiados Caraceteres")>
		Public Property noint As String

		<Display(Name:="Email")>
		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		Public Property email As String

		<Display(Name:="Envío de Factura")>
		Public Property enviafact As Decimal?


	End Class
	Public Class ModeloFinanciero

		<Display(Name:="Fecha")>
		<DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}", ApplyFormatInEditMode:=True)> _
		Public Overloads Property fecha() As Date

		<Display(Name:="Cetes-28")>
		<Required(ErrorMessage:="EL campo es obligatorio.")>
		<Range(1.0, Double.PositiveInfinity, ErrorMessage:="El valor debe ser mayor a 0")>
		<RegularExpression("^\d{1,7}(\.\d{0,4})?", ErrorMessage:="El Valor debe ser numerico o no tener mas de 4 decimales")>
		Public Overloads Property cetes28 As Decimal

		<Display(Name:="Cetes-91")>
		<Required(ErrorMessage:="EL campo es obligatorio.")>
		<Range(1.0, Double.PositiveInfinity, ErrorMessage:="El valor debe ser mayor a 0")>
		<RegularExpression("^\d{1,7}(\.\d{0,4})?", ErrorMessage:="El Valor debe ser numerico o no tener mas de 4 decimales")>
		Public Overloads Property cetes91 As Decimal

		<Display(Name:="CPP")>
		<Required(ErrorMessage:="EL campo es obligatorio.")>
		<RegularExpression("^\d{1,7}(\.\d{0,4})?", ErrorMessage:="El Valor debe ser numerico o no tener mas de 4 decimales")>
		Public Overloads Property cpp As Decimal

		<Display(Name:="TIIP")>
		<Required(ErrorMessage:="EL campo es obligatorio.")>
		<Range(1.0, Double.PositiveInfinity, ErrorMessage:="El valor debe ser mayor a 0")>
		<RegularExpression("^\d{1,7}(\.\d{0,4})?", ErrorMessage:="El Valor debe ser numerico o no tener mas de 4 decimales")>
		Public Overloads Property tiip As Decimal

		<Display(Name:="TIIE28")>
		<Required(ErrorMessage:="EL campo es obligatorio.")>
		<Range(1.0, Double.PositiveInfinity, ErrorMessage:="El valor debe ser mayor a 0")>
		<RegularExpression("^\d{1,7}(\.\d{0,4})?", ErrorMessage:="El Valor debe ser numerico o no tener mas de 4 decimales")>
		Public Overloads Property tiie As Decimal

		<Display(Name:="TIIE91")>
		<Required(ErrorMessage:="EL campo es obligatorio.")>
		<Range(1.0, Double.PositiveInfinity, ErrorMessage:="El valor debe ser mayor a 0")>
		<RegularExpression("^\d{1,7}(\.\d{0,4})?", ErrorMessage:="El Valor debe ser numerico o no tener mas de 4 decimales")>
		Public Overloads Property tiie91 As Decimal

		<Display(Name:="C.Fondeo")>
		<Required(ErrorMessage:="EL campo es obligatorio.")>
		<RegularExpression("^\d{1,7}(\.\d{0,4})?", ErrorMessage:="El Valor debe ser numerico o no tener mas de 4 decimales")>
		Public Overloads Property fondeo As Decimal

		<Display(Name:="Libor")>
		<Required(ErrorMessage:="EL campo es obligatorio.")>
		<Range(1.0, Double.PositiveInfinity, ErrorMessage:="El valor debe ser mayor a 0")>
		<RegularExpression("^\d{1,7}(\.\d{0,4})?", ErrorMessage:="El Valor debe ser numerico o no tener mas de 4 decimales")>
		Public Overloads Property libor As Decimal

		<Display(Name:="Libor-3M")>
		<Required(ErrorMessage:="EL campo es obligatorio.")>
		<Range(1.0, Double.PositiveInfinity, ErrorMessage:="El valor debe ser mayor a 0")>
		<RegularExpression("^\d{1,7}(\.\d{0,4})?", ErrorMessage:="El Valor debe ser numerico o no tener mas de 4 decimales")>
		Public Overloads Property libor3m As Decimal

		<Display(Name:="C.fondeo.Usd")>
		<Required(ErrorMessage:="EL campo es obligatorio.")>
		<RegularExpression("^\d{1,7}(\.\d{0,4})?", ErrorMessage:="El Valor debe ser numerico o no tener mas de 4 decimales")>
		Public Overloads Property fondeousd As Decimal

		<Display(Name:="Libor-6M")>
		<Required(ErrorMessage:="EL campo es obligatorio.")>
		<RegularExpression("^\d{1,7}(\.\d{0,4})?", ErrorMessage:="El Valor debe ser numerico o no tener mas de 4 decimales")>
		Public Overloads Property libor6m As Decimal

		<Display(Name:="Libor-12M")>
		<Required(ErrorMessage:="EL campo es obligatorio.")>
		<RegularExpression("^\d{1,7}(\.\d{0,4})?", ErrorMessage:="El Valor debe ser numerico o no tener mas de 4 decimales")>
		Public Overloads Property libor12m As Decimal

		Public Overloads Property add() As Boolean 'Propiedad control para insertar o actualizar

	End Class
	Public Class ModeloSucursal

		<Display(Name:="No.")>
		Public Property sucursal1 As Integer

		<Display(Name:="SIGLAS")>
		<StringLength(3, ErrorMessage:="Demasiados Caraceteres")>
		<Required(ErrorMessage:="El campo SIGLAS es Obligatorio")>
		Public Property abrev_suc As String

		<Display(Name:="Sucursal")>
		<StringLength(20, ErrorMessage:="Demasiados Caraceteres")>
		<Required(ErrorMessage:="El campo Sucursal es Obligatorio")>
		Public Property nombre As String

		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="Domicilio")>
		<Required(ErrorMessage:="El campo Domicilio es Obligatorio")>
		Public Property domicilio As String

		<Display(Name:="Colonia")>
		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		<Required(ErrorMessage:="El campo Colonia es Obligatorio")>
		Public Property colonia As String

		<Display(Name:="Municipio")>
		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		<Required(ErrorMessage:="El campo Municipio es Obligatorio")>
		Public Property municipio As String

		<Display(Name:="Estado")>
		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		<Required(ErrorMessage:="El campo Estado es Obligatorio")>
		Public Property estado As String

		<Display(Name:="Codigo Postal")>
		<Required(ErrorMessage:="El campo C.P. es Obligatorio")>
		<RegularExpression("^[0-9]*$", ErrorMessage:="El Valor debe ser numerico")>
		Public Property cp As String

		<Display(Name:="Telefono")>
		<StringLength(40, ErrorMessage:="Demasiados Caraceteres")>
		Public Property telefono As String

		<StringLength(100, ErrorMessage:="Demasiados Caraceteres")>
		<Display(Name:="Colonia")>
		Public Property apoderado1 As String

		<StringLength(100, ErrorMessage:="Demasiados Caraceteres")>
		Public Property apoderado2 As String

		<StringLength(100, ErrorMessage:="Demasiados Caraceteres")>
		Public Property testigo1 As String

		<StringLength(100, ErrorMessage:="Demasiados Caraceteres")>
		Public Property testigo2 As String

		<Display(Name:="IVA")>
		<RegularExpression("^\d{0,5}(\.\d{2})?", ErrorMessage:="El Valor debe ser numerico y no tener mas de dos decimales")>
		Public Property iva As Decimal?


	End Class
	Public Class ModeloCodigoGarantia

		<Display(Name:="Clave")>
		Public Property codigoid As Integer

		<Display(Name:="Nombre")>
		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		Public Property nombre As String

		<Display(Name:="Código BX+")>
		<RegularExpression("^[0-9]*$", ErrorMessage:="El Valor debe ser numerico")>
		Public Property cod_alterno As Integer

	End Class
	Public Class ModeloTipoGarantia

		Public Sub Cargacontroles()
			CodigoGarantiaDropDown = New controles().CargaCodigoGarantia()
		End Sub

		Public CodigoGarantiaDropDown As List(Of SelectListItem)

		<Display(Name:="Clave")>
		Public Property tipoid As Integer

		<Display(Name:="Código Garantía")>
		Public Property codigoid As Integer?

		<Display(Name:="Nombre")>
		<StringLength(50)>
		Public Property nombre As String

		<Display(Name:="Tipo BX+")>
		<RegularExpression("([0-9]+)", ErrorMessage:="El Valor debe ser numerico")>
		Public Property tip_alterno As Integer?

		<Display(Name:="Concepto")>
		<StringLength(70)>
		Public Property concepto As String

		<Display(Name:="Cuenta de cargo")>
		<Required(ErrorMessage:="El Campo Cuenta de Cargo es obligatorio.")>
		<StringLength(15, ErrorMessage:="Demasiados Caraceteres")>
		<RegularExpression("([0-9]+)", ErrorMessage:="El Valor debe ser numerico")>
		Public Property conta_cargo As String

		<Display(Name:="Cuenta de Abono")>
		<Required(ErrorMessage:="El Campo Cuenta de Abono es obligatorio.")>
		<StringLength(15)>
		<RegularExpression("([0-9]+)", ErrorMessage:="El Valor debe ser numerico")>
		Public Property conta_abono As String

	End Class
	Public Class ModeloClientes

		Public Sub CargaControles()
			SucursalDropDown = New controles().CargaSucursales()
			PromotorDropDown = New controles().CargaPromotores(False)
			PromProdDropDown = New controles().CargaPromotores(True)
			GrupoEmpresarialDropDown = New controles().CargaGrupos()
			CiudadDropDown = New controles().CargaCiudades()
			EstadoDropDown = New controles().CargaEstados()
			SectorFinancieroDropDown = New controles().CargaSectorFinanciero()
			SectorEconomicoDropDown = New controles().CargaSectorEconomico()
			GiroDropDown = New controles().CargaGiro()

			RelacionadoDropDown = New controles().CargaRelacion()
			RelevanteDropDown = New controles().CargaRelevante()
			RegimenDropDown = New controles().CargaRegimen()
			ClasificaDropDown = New controles().CargaClasifica()
			CalClienteDropDown = New controles().CargaCalCliente()
			FelectronicaDropDown = New controles().CargaFelectronica()

		End Sub

		Public SucursalDropDown As List(Of SelectListItem)
		Public PromotorDropDown As List(Of SelectListItem)
		Public PromProdDropDown As List(Of SelectListItem)
		Public GrupoEmpresarialDropDown As List(Of SelectListItem)
		Public CiudadDropDown As List(Of SelectListItem)
		Public EstadoDropDown As List(Of SelectListItem)
		Public SectorFinancieroDropDown As List(Of SelectListItem)
		Public SectorEconomicoDropDown As List(Of SelectListItem)
		Public GiroDropDown As List(Of SelectListItem)

		Public RelacionadoDropDown As List(Of SelectListItem)
		Public RelevanteDropDown As List(Of SelectListItem)
		Public RegimenDropDown As List(Of SelectListItem)
		Public ClasificaDropDown As List(Of SelectListItem)
		Public CalClienteDropDown As List(Of SelectListItem)
		Public FelectronicaDropDown As List(Of SelectListItem)

		<Display(Name:="Sucursal")>
		Public Property sucursal As Integer?

    <Display(Name:="Cliente")>
    Public Property cliente As Integer

    <Display(Name:="Persona Física")>
    Public Property pfisica As Boolean

    <Display(Name:="Actividad Empresarial")>
    Public Property actempres As Boolean

    <Display(Name:="Nombre")>
    <StringLength(100, ErrorMessage:="Demasiados Caraceteres")>
    Public Property nombre As String

    <Display(Name:="Primer Nombre")>
    Public Property n As String

    <Display(Name:="Segundo Nombre")>
    Public Property s As String

    <Display(Name:="Apellido Paterno")>
    Public Property p As String

    <Display(Name:="Apellido Materno")>
    Public Property m As String

    <Display(Name:="RFC")>
    <StringLength(15, ErrorMessage:="Demasiados Caraceteres")>
    <Required(ErrorMessage:="El Campo RFC es Requerido")>
    <Remote("ValidarClienteRFC", "Catalogos", AdditionalFields:="cliente")>
    Public Property rfc As String

    <Display(Name:="CURP")>
    <StringLength(20, ErrorMessage:="Demasiados Caraceteres")>
    Public Property curp As String

    <Display(Name:="Domicilio")>
    <StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
    <Required(ErrorMessage:="El Campo Domicilio es Requerido")>
    Public Property calle As String

    <Display(Name:="Colonia")>
    <StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
    <Required(ErrorMessage:="El Campo Colonia es Requerido")>
    Public Property colonia As String

    <Display(Name:="Municipio")>
    <StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
    Public Property municipio As String

    <Display(Name:="Estado")>
    <StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
    Public Property estado As String

    <Display(Name:="Estado")>
    Public Property cveedo As Integer?

    <Display(Name:="C.P.")>
    <RegularExpression("^[0-9]*$", ErrorMessage:="El Valor debe ser numerico")>
    Public Property cp As Integer?

    <Display(Name:="Telefono")>
    <StringLength(50)>
    Public Property telefono As String

    <Display(Name:="Promotor")>
    Public Property promotor As Integer?

    <Display(Name:="Sector Financiero")>
    Public Property sectorfina As Integer?

    <Display(Name:="Ciudad")>
    Public Property cvecd As Integer?

    <Display(Name:="Giro")>
    Public Property cvegiro As Integer?

    <Display(Name:="Fecha de Alta")>
    <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}", ApplyFormatInEditMode:=True)>
    Public Property fec_alta As Date?

    <Display(Name:="Notario No.")>
    <RegularExpression("^[0-9]*$", ErrorMessage:="El Valor debe ser numerico")>
    Public Property ac_numnot As Integer?

    <Display(Name:="Nombre")>
    <StringLength(40, ErrorMessage:="Demasiados Caraceteres")>
    Public Property ac_nombre As String

    <Display(Name:="Escritura")>
    <RegularExpression("^[0-9]*$", ErrorMessage:="El Valor debe ser numerico")>
    Public Property ac_escrit As Integer?

    <Display(Name:="Fecha")>
    <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}", ApplyFormatInEditMode:=True)>
    Public Property ac_fecha As Date?

    <Display(Name:="Localidad")>
    <StringLength(40, ErrorMessage:="Demasiados Caraceteres")>
    Public Property ac_localid As String

    <Display(Name:="Número")>
    <StringLength(30, ErrorMessage:="Demasiados Caraceteres")>
    Public Property ac_numero As String

    <Display(Name:="Folio")>
    <StringLength(10, ErrorMessage:="Demasiados Caraceteres")>
    Public Property ac_folio As String

    <Display(Name:="Libro")>
    <StringLength(10, ErrorMessage:="Demasiados Caraceteres")>
    Public Property ac_libro As String

    <Display(Name:="Auxiliar")>
    <StringLength(10, ErrorMessage:="Demasiados Caraceteres")>
    Public Property ac_auxilia As String

    <Display(Name:="Volumen")>
    <StringLength(10, ErrorMessage:="Demasiados Caraceteres")>
    Public Property ac_volumen As String

    <Display(Name:="Fecha de registro")>
    <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}", ApplyFormatInEditMode:=True)>
    Public Property ac_fechare As Date?

    <Display(Name:="Localidad")>
    <StringLength(40, ErrorMessage:="Demasiados Caraceteres")>
    Public Property ac_actaloc As String

    <Display(Name:="Pertenece a algún grupo empresarial")>
    Public Property grupoemp As Boolean

    Public Property clave As Integer

    <Display(Name:="F. Enlance")>
    <StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
    Public Property fenlace As String

    <Display(Name:="Puesto")>
    <StringLength(100, ErrorMessage:="Demasiados Caraceteres")>
    Public Property puesto As String

    <Display(Name:="Sector Económico")>
    Public Property seconomico As Integer?

    <Display(Name:="Password")>
    <StringLength(10, ErrorMessage:="Demasiados Caraceteres")>
    Public Property password As String

    <Display(Name:="Utiliza SIF Express")>
    Public Property sif As Boolean

    <Display(Name:="Email")>
    Public Property email As String

    <Display(Name:="Numero Sirac")>
    <RegularExpression("^\d{0,10}(\.\d{0})?", ErrorMessage:="El Valor debe ser numerico y no tener decimales")>
    Public Property sirac As Decimal?

    <Display(Name:="Régimen IVA")>
    Public Property regiva As Integer?

    <Display(Name:="Actividad")>
    <StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
    Public Property actividad As String

    <Display(Name:="Clasifica")>
    Public Property clasifica As Integer?

    <Display(Name:="Persona Póliticamente Expuesta")>
    Public Property politica As Boolean

    <Display(Name:="Empleados")>
    <RegularExpression("^[0-9]*$", ErrorMessage:="El Valor debe ser numerico")>
    Public Property empleados As Integer?

    <Display(Name:="EPO")>
    <RegularExpression("^\d{0,5}(\.\d{0})?", ErrorMessage:="El Valor debe ser numerico y no tener decimales")>
    Public Property epo As Decimal?

    <Display(Name:="Calificación de Deudor")>
    Public Property calcliente As Decimal?

    <Display(Name:="Grupo Económico (C.N.B.V.)")>
    <RegularExpression("^[0-9]*$", ErrorMessage:="El Valor debe ser numerico")>
    Public Property gpoecono As Integer?

    <Display(Name:="Director de Producto")>
    Public Property promprod As Integer?

    <Display(Name:="Número Externo")>
    <StringLength(15, ErrorMessage:="Demasiados Caraceteres")>
    <Required(ErrorMessage:="El Campo Número Externo es Requerido")>
    Public Property noext As String

    <Display(Name:="Número Interno")>
    <StringLength(15, ErrorMessage:="Demasiados Caraceteres")>
    Public Property noint As String

    <Display(Name:="Factura Electrónica - Método de Envío")>
    Public Property enviafact As Decimal?

    <Display(Name:="Cliente T24")>
    <RegularExpression("^\d{0,10}(\.\d{0})?", ErrorMessage:="El Valor debe ser numerico y no tener decimales")>
    Public Property clientet24 As Decimal?

    <Display(Name:="Nombre T24")>
    <StringLength(100, ErrorMessage:="Demasiados Caraceteres")>
    Public Property nombret24 As String

    <Display(Name:="Relevante")>
    Public Property idrelevant As Integer?

    <Display(Name:="Relacionado")>
    Public Property idrelacion As Integer?

    <Display(Name:="Riesgo Industria")>
    Public Property rgo_indust As Integer?

    <Display(Name:="Riesgo Financiero")>
    Public Property rgo_finan As Integer?

    <Display(Name:="Exp. de Pago")>
    Public Property exp_pago As Integer?

    <Display(Name:="FIRA")>
    <RegularExpression("^\d{0,10}(\.\d{0})?", ErrorMessage:="El Valor debe ser numerico y no tener decimales")>
    Public Property fira_idacr As Decimal?

    <Display(Name:="Riesgo Inidividual")>
    <DataType(DataType.Currency)>
    <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    <RegularExpression("^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,4})?))\)?$", ErrorMessage:="El Valor debe ser numerico o no tener mas de 2 decimales")>
    Public Property riesgo As Decimal

    <Display(Name:="Rieso de Grupo")>
    Public Property rgpo As Boolean

    <DataType(DataType.Currency)>
    <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    <RegularExpression("^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,4})?))\)?$", ErrorMessage:="El Valor debe ser numerico o no tener mas de 2 decimales")>
    Public Property riesgogpo As Decimal

    <Display(Name:="Vo.Bo. Registro")>
    Public Property voboreg As Boolean

    <Display(Name:="Vo.Bo. Mesa de Control")>
    Public Property vobo As Boolean


  End Class
    Public Class ModeloPromotor

        Public Sub CargaControles()
            SucursalDropDown = New controles().CargaSucursales()
        End Sub

        Public SucursalDropDown As List(Of SelectListItem)

        <Display(Name:="Clave")>
        Public Property promotor1 As Integer

        <Display(Name:="Código")>
        <StringLength(15, ErrorMessage:="Demasiados Caraceteres")>
        Public Property codigo As String

        <Display(Name:="Nombre")>
        <StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
        <Required(ErrorMessage:="El campo Nombre es obligatorio")>
        Public Property nombre As String

        <Display(Name:="Domicilio")>
        <StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
        Public Property domicilio As String

        <Display(Name:="Colonia")>
        <StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
        Public Property colonia As String

        <Display(Name:="Codigo Postal")>
        <RegularExpression("^[0-9]*$", ErrorMessage:="El Valor debe ser numerico")>
        Public Property cp As Integer?

        <Display(Name:="Municipio")>
        <StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
        Public Property municipio As String

        <Display(Name:="Estado")>
        <StringLength(40, ErrorMessage:="Demasiados Caraceteres")>
        Public Property estado As String

        <Display(Name:="Teléfono")>
        <StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
        Public Property telefono As String

        <Display(Name:="R.F.C.")>
        <StringLength(17, ErrorMessage:="Demasiados Caraceteres")>
        Public Property rfc As String

        <Display(Name:="¿Es Promotor Interno?")>
        Public Property interno As Boolean

        <Display(Name:="¿Se Encuentra Activo?")>
        Public Property activo As Boolean

        <Display(Name:="Tipo")>
        Public Property tipopromo As Decimal?

        <Display(Name:="Sucursal")>
        Public Property sucursal As Integer?

        <Display(Name:="C.C.")>
        <StringLength(15, ErrorMessage:="Demasiados Caraceteres")>
        Public Property cc As String

        <Display(Name:="Id Empleado")>
        <StringLength(15, ErrorMessage:="Demasiados Caraceteres")>
        <Required(ErrorMessage:="El campo Id es obligatorio")>
        Public Property empleado As String

        <Display(Name:="Clave T24")>
        <RegularExpression("^\d{0,16}(\.\d{0})?", ErrorMessage:="El Valor debe ser numerico, no contar con mas de 16 digitos y no tener decimales")>
        Public Property idt24 As Decimal?

        <Display(Name:="Nombre T24")>
        <StringLength(100, ErrorMessage:="Demasiados Caraceteres")>
        Public Property nombret24 As String

    End Class
    Public Class ModeloControlRiesgo

        Public Property propCliente As ModeloClientes

        Public Property id_rec As String

        Public Property RelacionLineas As List(Of SelectListItem)

        <Display(Name:="Linea")>
        <RegularExpression("^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,4})?))\)?$", ErrorMessage:="El Valor debe ser numerico o no tener mas de 2 decimales")>
        Public Property lmultiple As Decimal

        <Display(Name:="Id")>
        Public Property idmultiple As String

        <Display(Name:="Garantia Liquida")>
        Public Property liquida As Boolean

        <Display(Name:="Porcentaje")>
        <RegularExpression("\d+(\.\d{0,2})?", ErrorMessage:="porentaje invalido")>
        Public Property porcentaje As Decimal

        <Display(Name:="Cuenta")>
        Public Property cuenta As String

        <Display(Name:="numero")>
        <RegularExpression("^\d{0,10}(\.\d{0})?", ErrorMessage:="El Valor debe ser numerico y no tener decimales")>
        Public Property numer As Integer

        Public Property claves As String()

    End Class
    Public Class ModeloApoderado

        Public Sub CargaControles()
            CiudadDropDown = New controles().CargaCiudades()
            EstadoDropDown = New controles().CargaEstados()

        End Sub

        Public CiudadDropDown As List(Of SelectListItem)
        Public EstadoDropDown As List(Of SelectListItem)

        Public Property id As Integer

        Public Property cliente As Integer?

        <StringLength(50)>
        <Display(Name:="Nombre")>
        Public Property apoderado As String

        <Display(Name:="Domicilio")>
        <Required(ErrorMessage:="El campo Domicilio es obligatorio")>
        Public Property ap_domicilio As String

        <StringLength(20)>
        <Display(Name:="Estado Civil")>
        Public Property ap_ecivil As String

        <StringLength(20)>
        <Display(Name:="Ocupación")>
        Public Property ap_ocupa As String

        <Display(Name:="Fecha de Nacimiento")>
        <Required(ErrorMessage:="El campo Nombre Fecha de Nacimiento es obligatorio")>
        Public Property ap_fnac As Date?

        <Display(Name:="Notario No.")>
        Public Property ep_numnot As Integer

        <StringLength(40)>
        <Display(Name:="Nombre")>
        Public Property ep_nombre As String

        <Display(Name:="Escritura")>
        Public Property ep_escrit As Integer

        <Display(Name:="Fecha")>
        Public Property ep_fecha As Date?

        <StringLength(40)>
        <Display(Name:="Localidad")>
        Public Property ep_localidad As String

        <StringLength(10)>
        <Display(Name:="Número")>
        Public Property ep_numero As String

        <StringLength(10)>
        <Display(Name:="Folio")>
        Public Property ep_folio As String

        <StringLength(10)>
        <Display(Name:="Libro")>
        Public Property ep_libro As String

        <StringLength(10)>
        <Display(Name:="Auxiliar")>
        Public Property ep_auxiliar As String

        <StringLength(10)>
        <Display(Name:="Volumen")>
        Public Property ep_volumen As String

        <Display(Name:="Fecha de Registro")>
        Public Property ep_fechareg As Date?

        <StringLength(40)>
        <Display(Name:="Localidad")>
        Public Property ep_poderlocal As String

        <Display(Name:="Dominio")>
        Public Property dominio As Boolean

        <Display(Name:="Individual")>
        Public Property dfacultad As Boolean?

        <Display(Name:="Poder Para Endoso")>
        Public Property endoso As Boolean

        <Display(Name:="Individual")>
        Public Property efacultad As Boolean?

        <Display(Name:="Poder de administración")>
        Public Property admon As Boolean

        <Display(Name:="Individual")>
        Public Property afacultad As Boolean?

        <StringLength(15)>
        <Display(Name:="Nacionalidad")>
        Public Property nacion As String

        <Display(Name:="Apoderado")>
        Public Property esapoderado As Boolean

        <Display(Name:="Obligado")>
        Public Property esobligado As Boolean

        <StringLength(50)>
        <Display(Name:="Colonia")>
        Public Property ap_colonia As String

        <Display(Name:="Ciudad")>
        Public Property ap_ciudad As Integer

        <Display(Name:="Estado")>
        Public Property ap_estado As Integer

        <Display(Name:="Codigo Postal")>
        <RegularExpression("^[0-9]*$", ErrorMessage:="El Valor debe ser numerico")>
        <Required(ErrorMessage:="El campo C.P. es Obligatorio")>
        Public Property ap_cp As Integer

        <Display(Name:="Persona Póliticamente Expuesta")>
        Public Property politica As Boolean

        <Display(Name:="Persona Fisica")>
        Public Property pfisica As Boolean

        <Display(Name:="Primer Nombre")>
        Public Property n As String

        <Display(Name:="Segundo Nombre")>
        Public Property s As String

        <Display(Name:="Apellido Paterno")>
        Public Property p As String

        <Display(Name:="Apellido Materno")>
        Public Property m As String

        <StringLength(50)>
        <Display(Name:="Telefono")>
        Public Property telefono As String

        <StringLength(15)>
        <Display(Name:="R.F.C.")>
        <Required(ErrorMessage:="El campo Nombre R.F.C. es obligatorio")>
        Public Property rfc As String

        <StringLength(20)>
        <Display(Name:="C.U.R.P.")>
        Public Property curp As String

        <Display(Name:="Accionista")>
        Public Property esaccion As Boolean

        <Display(Name:="Acciones")>
        <RegularExpression("\d+(\.\d{0,2})?", ErrorMessage:="El Valor debe ser numerico o no tener mas de 2 decimales")>
        Public Property porcentaje As Decimal

        <Display(Name:="Depositario")>
        Public Property esdeposita As Boolean
    End Class
    Public Class ModeloContrato

        Public Sub CargaControles()
            SucursalDropDown = New controles().CargaSucursales() 'SI 
            PromotorDropDown = New controles().CargaPromotores(False) 'SI 
            IndicadoresDropDown = New controles().CargaIndicadores() ' SI 
            TipoEsqDropDown = New controles().CargaTipoEsq() 'SI 
            GarantiasDropDown = New controles().CargaGarantias() ' SI 
            DivisaDropDown = New controles().CargaDivisa() ' SI 
            TipointeresDropDown = New controles().Cargatipointeres() ' SI 
        End Sub

        Public GarantiasDropDown As List(Of SelectListItem)
        Public TipoEsqDropDown As List(Of SelectListItem)
        Public IndicadoresDropDown As List(Of SelectListItem)
        Public SucursalDropDown As List(Of SelectListItem)
        Public PromotorDropDown As List(Of SelectListItem)
        Public DivisaDropDown As List(Of SelectListItem)
        Public TipointeresDropDown As List(Of SelectListItem)

        <Display(Name:="Fecha de Contrato")>
        <Required(ErrorMessage:="El campo Fecha de contrato es Obligatorio")>
        Public Property fec_alta As Date?

        Public Property griesgo As Integer?

        <Display(Name:="Sucursal")>
        Public Property sucursal As Integer?

        <Display(Name:="Producto")>
        Public Property producto As Integer?

        <Display(Name:="Moneda")>
        Public Property moneda As Integer?

        <Display(Name:="Contrato")>
        Public Property contrato As Integer

        <Display(Name:="Cliente")>
        Public Property cliente As Integer?

        <Display(Name:="Promotor")>
        Public Property promotor As Integer?

        Public Property codigo As String

        <Required(ErrorMessage:="Debe Seleccionar una opcion de Tipo Interés")>
        <Display(Name:="Interés")>
        Public Property interes As Integer

        Public Property cargo As Integer?

        <Display(Name:="S/Tasa Ordinaria (%)")>
        <RegularExpression("^\d{0,3}(\.\d{2})?", ErrorMessage:="Campo Tasa Ordinaria solo puede tener tres enteros y dos decimales")>
        <Required(ErrorMessage:="El campo Tasa Ordinaria es Obligatorio")>
        Public Property tasa_ord As Decimal?

        <Display(Name:="S/Tasa Extraordinaria (%)")>
        <RegularExpression("^\d{0,3}(\.\d{2})?", ErrorMessage:="Campo Tasa Extraordinaria solo puede tener tres enteros y dos decimales")>
        <Required(ErrorMessage:="El campo Tasa Extraordinaria es Obligatorio")>
        Public Property tasa_ext As Decimal?

        <Display(Name:="Comisión por Contrato (%)")>
        <Required(ErrorMessage:="El Campo Comisión por Contrato es Obligatorio")>
        <RegularExpression("^\d{0,3}(\.\d{2})?", ErrorMessage:="Campo Comision por Contrato solo puede tener tres enteros y dos decimales")>
        Public Property com_cont As Decimal?

        <Display(Name:="Horario por Admón. (%)")>
        <Required(ErrorMessage:="El campo Horario por Admón. es Obligatorio")>
        <RegularExpression("^\d{0,3}(\.\d{2})?", ErrorMessage:="Campo Horario por Admon. solo puede tener tres enteros y dos decimales")>
        Public Property hon_admon As Decimal?

        <Display(Name:="Anticipo(%)")>
        <Required(ErrorMessage:="El campo Porcentaje es Obligatorio")>
        <RegularExpression("^\d{0,3}(\.\d{2})?", ErrorMessage:="Campo Porcentaje solo puede tener tres enteros y dos decimales")>
        Public Property porc_anti As Decimal

        <Display(Name:="Línea de Crédito")>
        <DataType(DataType.Currency)>
        <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
        <Required(ErrorMessage:="El campo linea es Obligatorio")>
        <RegularExpression("^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,2})?))\)?$", ErrorMessage:="Campo Linea solo puede tener doce enteros y dos decimales")>
        Public Property linea As Decimal

        <Display(Name:="Vigencia (Meses)")>
        <RegularExpression("^[0-9]*$", ErrorMessage:="Campo Vigencia debe ser numerico")>
        Public Property vigencia As Integer?

        <Display(Name:="Vencimiento")>
        <Required(ErrorMessage:="Campo Fecha de Vencimiento es Obligatorio")>
        Public Property fec_vence As Date?

        <Display(Name:="Garantía del Contrato ")>
        Public Property cve_garant As Integer?

        <Display(Name:="Comisión al promotor (%)")>
        <RegularExpression("^\d{0,3}(\.\d{2})?", ErrorMessage:="Campo Porcentaje solo puede tener tres enteros y dos decimales")>
        Public Property com_prom As Decimal?

        <Display(Name:="Tasa de Honorarios Modificable")>
        Public Property variahonorario As Boolean

        <Display(Name:="Tasa de Interés Modificable")>
        Public Property variainteres As Boolean

        <Display(Name:="Mandato de Cobranza")>
        Public Property mancobranza As Boolean

        <Display(Name:="Tasa diferenciada")>
        Public Property tasadif As Boolean

        <Display(Name:="Rebate")>
        Public Property rebate As Boolean

        <Display(Name:="Rebate puntos")>
        <RegularExpression("^\d{0,3}(\.\d{2})?", ErrorMessage:="Campo solo puede tener tres enteros y dos decimales")>
        Public Property rebatepts As Decimal?

        <Display(Name:="Bonitifación de Moratorios")>
        Public Property bonmoratorio As Boolean

        Public Property cesiones As Integer?

        Public Property cobranzas As Integer?

        Public Property documentos As Integer?

        <Display(Name:="Línea Bloqueada")>
        Public Property bloqueado As Boolean

        <Display(Name:="Notas")>
        Public Property notas As String

        Public Property bancos As String

        Public Property historia As Boolean

        <Display(Name:="Negociar Tasa de Operación")>
        Public Property negociar As Boolean

        Public Property promesa As Integer?

        <Required(ErrorMessage:="Debe seleccionar una opcion de Cobro Honorario")>
        Public Property honorario As Integer

        <Display(Name:="Contrato Normativo")>
        Public Property cnorma As Integer?

        <Display(Name:="Notifiación Electrónica")>
        Public Property enotifica As Boolean

        <Display(Name:="Admón. de Cartera")>
        Public Property admoncart As Boolean

        <Display(Name:="No operativo - Recuperación")>
        Public Property edoiva As Boolean

        Public Property utilizado As Decimal?

        <Display(Name:="Cobertura")>
        <DataType(DataType.Currency)>
        <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
        <RegularExpression("^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,2})?))\)?$", ErrorMessage:="Campo Cobertura solo puede tener doce enteros y dos decimales")>
        Public Property cobertura As Decimal

        <Display(Name:="Endoso")>
        Public Property endoso As Date?

        <Display(Name:="Seguro de Crédito")>
        Public Property seguro As Boolean

        <Display(Name:="Plazo (días)")>
        <RegularExpression("^[0-9]*$", ErrorMessage:="Campo Plazo debe ser numerico")>
        Public Property plazo As Integer?

        <Display(Name:="Código")>
        <RegularExpression("[\d\w]{0,10}", ErrorMessage:="El Campo Infolinea solo puede tener maximo 10 caracteres")>
        Public Property idmapfre As String

        Public Property fira As Boolean

        Public Property pgeseguro As Decimal?

        <Display(Name:="Cto Obra. Pública")>
        <DataType(DataType.Currency)>
        <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
        <RegularExpression("^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,2})?))\)?$", ErrorMessage:="Campo Cobertura solo puede tener doce enteros y dos decimales")>
        Public Property ctoobrapub As Decimal

        <Display(Name:="Tipo de Esquema")>
        <Required(ErrorMessage:="El campo esquema es Obligatorio")>
        Public Property tipoesq As Integer

        Public Property regla As Integer?

        Public Property tipo_tasa As Integer?

        Public Property tasa_opera As Decimal?

        Public Property tasa_mora As Decimal?

        Public Property tasa_calc As Integer?

        Public Property void As Boolean

        Public Property reservado As Boolean

        <Display(Name:="Indicador")>
        Public Property tipoindica As Integer?

        <Display(Name:="Plazo Operaciones (días)")>
        <Required(ErrorMessage:="El campo Plazo Operaciones es obligatorio")>
        <RegularExpression("^[0-9]*$", ErrorMessage:="Campo Plazo Operaciones debe ser numerico")>
        Public Property plazoopera As Integer

        Public Property digitov As Decimal?

        Public Property garantnafin As Boolean

        Public Property fec_update As Date?

        Public Property histprod As Integer?

        <Display(Name:="Autorización de Línea")>
        <Required(ErrorMessage:="El campo Fecha Autorizacion de linea es obligatorio")>
        Public Property altalinea As Date?

        <Display(Name:="Vencimiento de Línea")>
        <Required(ErrorMessage:="El campo Vencimiento de linea obligatorio")>
        Public Property vencelinea As Date?

        Public Property honocargo As Integer?

        Public Property incumple As Date?

        Public Property fec_reserv As Date?

        Public Property gliquida As Boolean

        Public Property fec_pago As Date?

        Public Property fec_upago As Date?

        Public Property fpago As Date?

        Public Property registro_cnto As Date?

        <Display(Name:="Infolínea")>
        <RegularExpression("[\d\w]{0,6}", ErrorMessage:="El Campo Infolinea solo puede tener maximo 6 caracteres")>
        Public Property infolinea As String

        Public Property dexigible As Integer?

        Public Property idipoliza As Integer?

        <Display(Name:="Servicio de Dispersión")>
        Public Property dispersion As Boolean

        <Display(Name:="Comisión por Eveno")>
        <RegularExpression("^\d{0,13}(\.\d{2})?", ErrorMessage:="Campo Tasa Extraordinaria solo puede tener trece enteros y dos decimales")>
        Public Property dispercom As Decimal?

        Public Property idtransact As String

    End Class
    Public Class Contrato_Cliente
        Public Sub New()
            Cliente = New ModeloClientes
            Contrato = New ModeloContrato
            Contrato.CargaControles()
        End Sub

        Public Property Cliente As ModeloClientes
        Public Property Contrato As ModeloContrato
    End Class
    Public Class ModeloAnexo


        Public Property contrato As Integer
        Public Property contname As String
        Public Property nombre As String
        Public Property anexoid As Integer

        <Display(Name:="Deudor")>
        <RegularExpression("^[0-9]*$", ErrorMessage:="El campo Deudor debe ser numerico")>
        <Remote("ValidaDeudor", "Catalogos", AdditionalFields:="producto,contrato,anexoid")>
        <Required(ErrorMessage:="El campo Deudor es obligatorio")>
        Public Property deudor As Integer

        Public Property mancobranza As Boolean
        Public Property notifica As Boolean
        <Display(Name:="Activo")>
        Public Property activo As Boolean
        Public Property cancelado As Boolean

        <Display(Name:="Cliente Id")>
        <StringLength(20, ErrorMessage:="El campo Cliente ID solo permite 20 caracteres")>
        Public Property catcte As String

        Public Property imprimir As Boolean

        <Display(Name:="SobreTasa")>
        <RegularExpression("^\d{0,3}(\.\d{2})?", ErrorMessage:="Campo Tasa Extraordinaria solo puede tener tres enteros y dos decimales")>
        Public Property sobretasa As Decimal

        '<Range(1, Decimal.MaxValue, ErrorMessage:="ingrese un valor mayor a 0")>

        <Display(Name:="Límite")>
        <DataType(DataType.Currency)>
        <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
        <RegularExpression("^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,2})?))\)?$", ErrorMessage:="Campo Límite solo puede tener doce enteros y dos decimales")>
        Public Property limite As Decimal


        Public Property void As Boolean

        Public Property modifica As Boolean
        Public Property updaterec As String
        Public Property producto As Integer

        Public Property tasadif As Boolean

    End Class
	Public Class ModeloAnexoVM
		Public Sub New()
			Comprador = New ModeloComprador
			Anexo = New ModeloAnexo
      Proveedor = New ModeloProveedor
    End Sub

		Public Property Comprador As ModeloComprador
		Public Property Anexo As ModeloAnexo
		Public Property Proveedor As ModeloProveedor
    Public Property Producto As Integer
    Public Property nombrecte As String

	End Class
	Public Class ModeloCesion
		Public Property idcesion As Integer

		Public Property contrato As Integer?

        <Display(Name:="Cesión")>
        Public Property cesion As Integer?

        <Display(Name:="Doctos")>
        Public Property doctos As Integer?

		Public Property sumadoctos As Decimal?

        <Display(Name:="Alta")>
        Public Property fec_alta As Date?

        <Display(Name:="Vence")>
        <Required(ErrorMessage:="El campo importe es Obligatorio")>
        Public Property fec_vence As Date?

		Public Property proveedor As Integer?


        <Display(Name:="Importe")>
        <Required(ErrorMessage:="El campo importe es Obligatorio")>
        <GreaterThanZero()>
        Public Property importe As Decimal?

		<Display(Name:="Anticipado")>
		Public Property impanticipado As Decimal?

        <Display(Name:="Tasa")>
              Public Property tasaoper As Decimal?

		<Display(Name:="Interes")>
		Public Property interes As Decimal?

		Public Property ivainteres As Decimal?

        <Display(Name:="Tasa Hon.")>
        Public Property tasahono As Decimal?

		<Display(Name:="Honorario")>
		Public Property honorario As Decimal?

        <Display(Name:="IVA Hon")>
        Public Property ivahonorario As Decimal?

		Public Property tnafin As Decimal?

		Public Property cartera As Decimal?

		Public Property pagos As Decimal?

        <Display(Name:="A Pagar")>
        Public Property totalpagar As Decimal?

		Public Property facturado As Boolean

		Public Property pagoprom As Boolean

		<Display(Name:="Cheque")>
		Public Property cheque As Integer?

		Public Property idctabanco As Integer?

		<Display(Name:="Cuenta")>
		Public Property cuenta As String

		<Display(Name:="Movimiento")>
		Public Property movto As String

		Public Property pagomatriz As Boolean

		Public Property factinte As Boolean

		Public Property userid As String

		Public Property acuse As String

		Public Property costonafin As Decimal?

		<Display(Name:="Tasa")>
		Public Property tasa_ord As Decimal?

		Public Property fec_fondeo As Date?

		Public Property folioevento As String

		Public Property fira As Boolean

        <Display(Name:="Cuenta")>
        Public Property numreccta As Integer?

		Public Property timestart As Date?

		Public Property vbremote As Integer?

		Public Property timeremote As Date?

		Public Property vboperador As Integer?

		Public Property timeoper As Date?

		Public Property vbsuper As Integer?

		Public Property timesuper As Date?

		Public Property vbfirma1 As Integer?

		Public Property timefirma1 As Date?

		Public Property vbfirma2 As Integer?

		Public Property timefirma2 As Date?

		Public Property timefondeo As Date?

		Public Property tdevengue As Boolean

		Public Property disperfile As String

		Public Property void As Boolean

		Public Property tasaganafin As Decimal?

		<Display(Name:="Garantía")>
		Public Property garantnafin As Decimal?

        <Display(Name:="IVA garantía")>
        Public Property ivaganafin As Decimal?

		Public Property imvfacnafin As Decimal?

		Public Property gliquida As Decimal?

		Public Property glqreccta As Integer?

		Public Property tinter As Integer?

		Public Property disperstat As Integer?

		Public Property folio As Integer?

		Public Property cfdi As String

        <Display(Name:="Plazo")>
        Public Property plazo As Decimal?

		Public Property dsalida As Integer?

		Public Property int_diario As Decimal?

		Public Property producto As Integer

        Public Property Beneficiario As String

        Public Property idtransact As String

		<Display(Name:="Clabe")>
		Public Property clabe As String

        <Display(Name:="Anticipo%")>
        Public Property porc_anti As Decimal?

        Public Property clienteNombre As String

        Public Property cliente As Integer
    End Class

    Public Class ModeloCesionWzd

        
        Public Sub CargaControles()
            'GarantiasDropDown = New controles().CargaGarantias() ' SI 
            DivisaDropDown = New controles().CargaDivisa() ' SI 
            TipointeresDropDown = New controles().Cargatipointeres() ' SI 
        End Sub

        'Public GarantiasDropDown As List(Of SelectListItem)
        Public DivisaDropDown As List(Of SelectListItem)
        Public TipointeresDropDown As List(Of SelectListItem)

        'Public Property idcesion As Integer

        Public Property contrato As Integer?

        <Display(Name:="Cesión")>
        Public Property cesion As Integer?

        <Display(Name:="Divisa")>
        Public Property moneda As Integer

        Public Property producto As Integer

        <Display(Name:="Anticipo%")>
        Public Property porc_anti As Decimal

        <Display(Name:="Interes")>
        Public Property interes As Decimal?

        <Display(Name:="Interes")>
        Public Property tinter As Integer?

        <Display(Name:="Doctos")>
        Public Property doctos As Integer?

        Public Property doc As Integer?

        <Display(Name:="Alta")>
        Public Property fec_alta As Date?

        <Display(Name:="Vence")>
        <Required(ErrorMessage:="El campo importe es Obligatorio")>
        Public Property fec_vence As Date?

        '<Display(Name:="Importe")>
        ' <Required(ErrorMessage:="El campo importe es Obligatorio")>
        ' <GreaterThanZero()>
        'Public Property vimporte As Decimal?

        '<Display(Name:="Anticipado")>
        'Public Property vimpanticipado As Decimal?

        <Display(Name:="Importe")>
         <Required(ErrorMessage:="El campo importe es Obligatorio")>
         <GreaterThanZero()>
        Public Property importe As Decimal

        <Display(Name:="Anticipado")>
        Public Property impanticipado As Decimal


        <Display(Name:="Tasa")>
        Public Property tasaoper As Decimal?

        <Display(Name:="Plazo")>
        Public Property plazo As Integer?

        Public Property idtransact As String

        Public Property userid As String

        Public Property nombre As String

        <Display(Name:="Deudor")>
        Public Property nombreDeudor As String

        Public Property docto As String

        <Display(Name:="Iddocto")>
        Public Property iddocto As Integer

        Public Property monto As Decimal?

        Public Property hono As Decimal?

        Public Property iva As Decimal?

        Public Property deudor As Integer


        'Garantías datatable
        <Display(Name:="IdG")>
        Public Property garantiaid As Integer

        <Display(Name:="Valor")>
        Public Property valor As Decimal

        <Display(Name:="Porcentaje")>
        Public Property porcentaje As Decimal

        <Display(Name:="Costo")>
        Public Property costo As Decimal

        <Display(Name:="Cobrado")>
        Public Property cobrado As Decimal

        <Display(Name:="IVA")>
        Public Property ivacobrado As Decimal

        <Display(Name:="Tipo")>
        Public Property tipogarantia As String

        <Display(Name:="Serie")>
        Public Property serie As String

        <Display(Name:="Tipo")>
        Public Property tipo As String

        <Display(Name:="Id")>
        Public Property numrec As Integer


    End Class

	Public Class ModeloCesionVM

		Public Sub New()
			Doctos = New ModeloDocto
			Garantia = New ModeloGarantia
            Cesion = New ModeloCesion
            Contrato_Cliente = New Contrato_Cliente
            adeudos = New Modeloadeudos
            adeudos = New Modeloadeudos
            tasas = New ModeloFinanciero
		End Sub

		Public Property Doctos As ModeloDocto
		Public Property Cesion As ModeloCesion
        Public Property Garantia As ModeloGarantia
        Public Property Contrato_Cliente As Contrato_Cliente
        Public Property adeudos As Modeloadeudos
        Public Property tasas As ModeloFinanciero
        Public Property producto As Integer
        Public Property importe As Decimal
        Public Property impanticipado As Decimal



	End Class
	Public Class ModeloGarantia

		Public Sub CargaControles()
			TipoGarantiaDropDown = New controles().CargaTipoGarantia()
			CodigoGarantiaDropDown = New controles().CargaCodigoGarantia()
		End Sub

		Public TipoGarantiaDropDown As List(Of SelectListItem)
		Public CodigoGarantiaDropDown As List(Of SelectListItem)

		Public Property garantiaid As Integer

		<Display(Name:="Contrato")>
		Public Property contrato As Integer?

		<Display(Name:="Cesion")>
		Public Property cesion As Integer?

		<Display(Name:="Código de garantía")>
		Public Property codigo As Integer?

        <Display(Name:="Tipo de garantía")>
        Public Property tipo As Integer?

        <Display(Name:="Tipo")>
        Public Property nombreTipo As String

		<DataType(DataType.Currency)>
		<DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
		<RegularExpression("^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,2})?))\)?$", ErrorMessage:="Campo Valor solo puede tener doce enteros y dos decimales")>
		<Display(Name:="Valor de garantía")>
		Public Property valor As Decimal

        '<RegularExpression("^\d{0,3}(\.\d{2})?", ErrorMessage:="Campo Porcentaje solo puede tener tres enteros y dos decimales")>


        <Display(Name:="Porcentaje Cubierto")>
        Public Property porcentaje As Decimal

        '<DataType(DataType.Currency)>
        '<DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
        '<RegularExpression("^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,2})?))\)?$", ErrorMessage:="Campo Costo solo puede tener cuatro enteros y dos decimales")>


        <Display(Name:="Costo de la garatía %")>
        Public Property costo As Decimal

		<Display(Name:="Cobrado")>
		<DataType(DataType.Currency)>
		<DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
		<RegularExpression("^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,2})?))\)?$", ErrorMessage:="Campo Cobrado solo puede tener cuatro enteros y dos decimales")>
		Public Property cobrado As Decimal

		<Display(Name:="IVA Cobrado")>
		<DataType(DataType.Currency)>
		<DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
		<RegularExpression("^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,2})?))\)?$", ErrorMessage:="Campo IVA Cobrado solo puede tener cuatro enteros y dos decimales")>
		Public Property ivacobrado As Decimal

		Public Property cancelado As Boolean

		Public Property fec_alta As Date?

		Public Property valor_ant As Decimal?

		Public Property saldo As Decimal?

		Public Property void As Boolean
	End Class
    Public Class ModeloDocto


        Public Sub CargaControles(contrato As Integer)
            AnexoDropDown = New controles().CargaAnexo(contrato)
        End Sub

        Public AnexoDropDown As List(Of SelectListItem)

        <Display(Name:="Id Documento")>
        Public Property iddocto As Decimal

        Public Property contrato As Integer?

        <Display(Name:="Cesión")>
        Public Property cesion As Integer?

        Public Property pagare As String

        <Display(Name:="Documento")>
        Public Property docto As String

        Public Property referencia As String

        <Display(Name:="Deudor")>
        Public Property deudor As Integer?

        Public Property plaza As String

        Public Property plazacob As Integer?

        Public Property c_delegada As Boolean

        <Display(Name:="Importe")>
        Public Property importe As Decimal?

        <Display(Name:="Monto")>
        Public Property monto As Decimal?

        <Display(Name:="Monto")>
        Public Property dmonto As Decimal?


        Public Property saldo As Decimal?

        <Display(Name:="Interés")>
        Public Property interes As Decimal?

        Public Property ivainteres As Decimal?

        <Display(Name:="Descuento")>
        Public Property descto As Decimal?

        Public Property fec_alta As Date?

        <Display(Name:="Vencimiento")>
        Public Property fec_vence As Date

        <Display(Name:="Vence")>
        Public Property dfec_vence As Date


        Public Property pagos As Integer?

        Public Property excento As Boolean

        Public Property prestamo As Integer?

        <Display(Name:="Honorario")>
        Public Property hono As Decimal?

        <Display(Name:="IVA")>
        Public Property iva As Decimal?

        Public Property fec_prepago As Date?

        Public Property void As Boolean

        Public Property factinte As Boolean

        Public Property seguro As Boolean

        Public Property idcesion As Integer?

        Public Property plazo As Decimal?

        Public Property int_diario As Decimal?

        Public Property dsalida As Integer?

        Public Property idtransact As String

        <Display(Name:="Nombre del deudor")>
        Public Property NombreDeudor As String

        Public anexo As List(Of SelectListItem)

    End Class
	Public Class ModeloUsuarioWeb

		<Display(Name:="Fecha de Alta")>
		Public Property fec_alta As Date?

		<Display(Name:="Folio")>
		Public Property folio As Integer

		<Display(Name:="Usuario")>
		Public Property username As String

		Public Property ca As String

		Public Property pw As Integer?

		Public Property sessionid As Integer?

		Public Property listpass As String

		<Display(Name:="Nombre")>
		<StringLength(50, ErrorMessage:="Demasiados Caraceteres")>
		Public Property nombre As String

		Public Property id As Integer?

		Public Property identidad As Integer?

		Public Property tipo As Integer

		Public Property expires As Date?

		<Display(Name:="Activo")>
		Public Property activo As Boolean

		<Display(Name:="Email")>
		Public Property email As String

		Public Property asignada As Boolean

		Public Property insession As Boolean

		Public Property lastlog As Date?

		<Display(Name:="Notas")>
		Public Property notas As String

		Public Property void As Boolean

		Public Property updaterec As String

		Public Property Clave As Integer
	End Class
	Public Class ModeloWebMonitor
		<Display(Name:="Fecha")>
		Public Property fecha As Date?

		<Display(Name:="Acción")>
		Public Property action As String

		Public Property username As String

		Public Property nombre As String
    End Class

    Public Class ModeloAdeudosWzd

        <Display(Name:="Adeudo")>
        Public Property adeudo As String

        Public Property contrato As Integer?

        <Display(Name:="Monto")>
        Public Property monto As Decimal?

        <Display(Name:="Saldo")>
        Public Property saldo As Decimal?

        <Display(Name:="Id")>
        Public Property idadeudo As Integer

        <Display(Name:="Tipo")>
        Public Property tipo As String

        <Display(Name:="Serie")>
        Public Property serie As String

        <Display(Name:="Docto")>
        Public Property docto As Integer?

        <Display(Name:=" ")>
        Public Property void As Boolean
    End Class

End Namespace
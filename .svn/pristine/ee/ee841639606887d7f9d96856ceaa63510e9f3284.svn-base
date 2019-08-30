Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class AseguradoraModels

    Public Class aseguradora
        Public Property idaseguradora As Integer

        <Display(Name:="Nombre")>
        <Required(ErrorMessage:="Capture el nombre")>
        Public Property nombre As String

        <Display(Name:="Calle")>
        <Required(ErrorMessage:="Capture la calle")>
        Public Property calle As String

        <Display(Name:="No. Exterior")>
        <Required(ErrorMessage:="Capture el número exterior")>
        Public Property noext As String

        <Display(Name:="No. Interior")>
        Public Property noint As String

        <Display(Name:="Colonia")>
        <Required(ErrorMessage:="Capture la colonia")>
        Public Property colonia As String

        <Display(Name:="Municipio")>
        <Required(ErrorMessage:="Capture el municipio")>
        Public Property municipio As String

        <Display(Name:="Estado")>
        <Required(ErrorMessage:="Capture el estado")>
        Public Property estado As String

        <Display(Name:="País")>
        <Required(ErrorMessage:="Capture el país")>
        Public Property pais As String

        <Display(Name:="Código Postal")>
        <Required(ErrorMessage:="Capture el código postal")>
        <RegularExpression("^[0-9]\d{4,}$", ErrorMessage:="El codigo postal debe contar con 5 digitos")>
        Public Property cp As Integer?

        <Display(Name:="Teléfono")>
        <Required(ErrorMessage:="Capture el teléfono")>
        Public Property telefono As String

        <Display(Name:="RFC")>
        <Required(ErrorMessage:="Capture el RFC")>
        Public Property rfc As String

        <Display(Name:="Correo Electrónico")>
        <Required(ErrorMessage:="Capture el correo electrónico")>
        <RegularExpression("([\w\.\-_]+)?\w+@[\w-_]+(\.\w+){1,}", ErrorMessage:="El correo electrónico no cumple con el formato correcto")>
        Public Property email As String

    End Class

    Public Class poliza

        Public Sub Cargacontroles()
            VigenciaDropDown = New controles().CargaVigencias()
            PeriodosDropDown = New controles().CargaPeriodos()
            MonedaDropDown = New controles().CargaDivisa()
            AseguradoraDropDown = New controles().CargaAseguradoras()

        End Sub

        Public Property idpoliza As Integer

        <Display(Name:="Aseguradora")>
        Public Property idaseguradora As Integer

        <Display(Name:="Póliza")>
        <Required(ErrorMessage:="Capture la póliza")>
        Public Property poliza As String

        Public Property cancelada As Boolean

        <Display(Name:="Moneda")>
        Public Property moneda As Integer

        <Display(Name:="Vigencia de la póliza")>
        Public Property mvigencia As Integer

        <Display(Name:="Emisión")>
        Public Property femision As Date

        <Display(Name:="Inicio Vigencia")>
        Public Property fvigencia1 As Date

        <Display(Name:="Fin Vigencia")>
        Public Property fvigencia2 As Date

        <Display(Name:="IVA")>
        Public Property piva As Decimal

        <Display(Name:="Indemnización máxima asegurable")>
        <RegularExpression("^\d{1,3}(?:,\s?\d{3})*(?:\.\d*)?$")>
        Public Property indemnizacion As Decimal

        <Display(Name:="Facturación asegurable estimada")>
        <RegularExpression("^\d{1,3}(?:,\s?\d{3})*(?:\.\d*)?$")>
        Public Property facturacion As Decimal

        <Display(Name:="Periodicidad")>
        Public Property primaperiodos As Integer

        <Display(Name:="Subtotal")>
        Public Property primaasubtotal As Decimal

        <Display(Name:="IVA")>
        Public Property primaaiva As Decimal

        <Display(Name:="Total")>
        Public Property primaatotal As Decimal

        <Display(Name:="Primer Pago")>
        Public Property primaafprimera As Date

        <Display(Name:="Estimada anual")>
        <RegularExpression("^\d{1,3}(?:,\s?\d{3})*(?:\.\d*)?$")>
        Public Property primasubtotal As Decimal

        <Display(Name:="IVA")>
        Public Property primaiva As Decimal

        <Display(Name:="Total")>
        Public Property primatotal As Decimal

        <Display(Name:="% Descuento")>
        <RegularExpression("^\d{1,3}(?:,\s?\d{3})*(?:\.\d*)?$")>
        Public Property primapdescuento As Decimal

        <Display(Name:="A Pagar (Sin IVA)")>
        Public Property primapagar As Decimal

        <Display(Name:="Mínima anual (Sin IVA)")>
        <RegularExpression("^\d{1,3}(?:,\s?\d{3})*(?:\.\d*)?$")>
        Public Property primaminima As Decimal

        <Display(Name:="Costo")>
        <RegularExpression("^\d{1,3}(?:,\s?\d{3})*(?:\.\d*)?$")>
        Public Property gecosto As Decimal

        <Display(Name:="Asegurados")>
        <RegularExpression("^\d{1,3}(?:,\s?\d{3})*(?:\.\d*)?$")>
        Public Property geasegurados As Integer

        <Display(Name:="Periodicidad")>
        Public Property geperiodos As Integer

        <Display(Name:="Subtotal")>
        Public Property gesubtotal As Decimal

        <Display(Name:="IVA")>
        Public Property geiva As Decimal

        <Display(Name:="Total")>
        Public Property getotal As Decimal

        <Display(Name:="Anticipo (Con IVA)")>
        Public Property geatotal As Decimal

        <Display(Name:="Primer Pago")>
        Public Property gefprimera As Date

        <Display(Name:="Monto del deducible")>
        Public Property deducible As Decimal

        Public Property archivopdf As String

        Public Property nombre As String

        Public Property VigenciaDropDown As List(Of SelectListItem)

        Public Property PeriodosDropDown As List(Of SelectListItem)

        Public Property MonedaDropDown As List(Of SelectListItem)

        Public Property AseguradoraDropDown As List(Of SelectListItem)

    End Class
    



End Class

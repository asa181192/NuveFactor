﻿Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports FactorEntidades


Namespace TesoreriaModel

#Region "Cuentas"

    Public Class CuentasModel

        Public Sub Cargacontroles()
            DivisaDropDownList = New controles().CargaDivisa()
            bancosDropDownList = New controles().cargaBancos()
        End Sub

        <Key>
        Public Property idctabanco As Integer

        <Display(Name:="N° Cuenta")>
        <StringLength(15)>
        <Required(ErrorMessage:="Capture el número de cuenta")>
        <RegularExpression("^[0-9]*\s*$", ErrorMessage:="El Valor debe ser numerico")>
        Public Property ctabanco As String

        <Display(Name:="N° Banco")>
        Public Property idbanco As Integer

        <Display(Name:="N° Sucursal")>
        <RegularExpression("^[0-9]*$", ErrorMessage:="El Valor debe ser numerico")>
        Public Property sucursal As Integer

        <StringLength(35)>
        <Display(Name:="Banco")>
        <Required(ErrorMessage:="Capture el nombre del banco")>
        Public Property banco As String

        <StringLength(35)>
        <Display(Name:="Sucursal Bancaria")>
        <Required(ErrorMessage:="Seleccione el banco")>
        Public Property sucbancaria As String

        <StringLength(60)>
        <Display(Name:="Slogan")>
        Public Property slogan As String

        <StringLength(20)>
        <Display(Name:="Cuenta Contable")>
        Public Property ctacontable As String

        <Column(TypeName:="numeric")>
        <Display(Name:="Saldo")>
        <DataType(DataType.Currency)>
        <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
        Public Property saldo As Decimal

        <Display(Name:="Oficina")>
        Public Property oficina As String

        Public Property moneda As Integer

        <Display(Name:="Divisa")>
        Public Property divisa As String

        <Display(Name:="Cancelado")>
        Public Property cancelado As Boolean

        <Display(Name:="Estatus")>
        Public Property cancel As String

        Public Property cheques As Integer

        Public Property traspasos As Integer

        Public Property depositos As Integer

        Public Property cargos As Integer

        Public Property inversion As Integer

        Public Property cancelacion As Integer

        Public Property fichas As Integer

        Public Property traspactivo As Boolean

        <Column(TypeName:="numeric")>
        Public Property cobrado As Decimal

        Public Property fecha As Date

        <Column(TypeName:="numeric")>
        Public Property entradas As Decimal

        <Column(TypeName:="numeric")>
        Public Property salidas As Decimal

        <StringLength(40)>
        Public Property banda As String

        <StringLength(3)>
        Public Property codigoseg As String

        <StringLength(3)>
        <Display(name:="N° Banco")>
        Public Property numbanco As String

        <StringLength(3)>
        Public Property plazacomp As String

        <Display(Name:="N° Sucursal")>
        Public Property nosucur As Integer

        Public Property interbanco As Boolean

        Public Property impbanda As Boolean

        Public Property fondeaoper As Boolean

        Public Property chequesfora As Boolean

        Public Property exporta As Boolean

        Public Property void As Boolean

        Public DivisaDropDownList As List(Of SelectListItem)
        Public bancosDropDownList As List(Of SelectListItem)

    End Class

#End Region

#Region "Movimientos"

    Public Class MovimientosModels

        Public Sub Cargacontroles()
            cuentasDropDownList = New controles().CargaCuentas()

        End Sub

        Public Property numrec As Integer

        Public Property idctabanco As Integer

        <Display(name:="Fecha")>
        <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}", ApplyFormatInEditMode:=True)>
        Public Property fecha As Date?

        Public Property ctabancobk As String

        <Display(name:="Tipo")>
        Public Property tipo As String

        <Display(name:="Folio")>
        Public Property folio As Integer

        Public Property cesion As Integer

        <Display(Name:="Beneficiario")>
        <Required(ErrorMessage:="Capture el beneficiario.")>
        Public Property beneficiario As String

        <Display(Name:="Concepto")>
        <Required(ErrorMessage:="Capture el concepto.")>
        Public Property concepto As String

        <Display(Name:="Cuenta Contable")>
        Public Property concconta As String

        Public Property depoencta As Boolean

        Public Property impresiones As Integer


        <RegularExpression("^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,4})?))\)?$", ErrorMessage:="El Valor debe ser numerico o no tener mas de 2 decimales")>
        <DataType(DataType.Currency)>
        <Display(name:="Entrada")>
        Public Property entrada As Decimal


        <RegularExpression("^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,4})?))\)?$", ErrorMessage:="El Valor debe ser numerico o no tener mas de 2 decimales")>
        <DataType(DataType.Currency)>
        <Display(name:="Salida")>
        Public Property salida As Decimal

        <Display(name:="Saldo")>
        Public Property saldo As Decimal

        Public Property ficha As Integer

        Public Property cancelado As Boolean

        <Display(Name:="Movimiento")>
        Public Property cancel As String

        <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}", ApplyFormatInEditMode:=True)>
        Public Property feccanc As Date

        Public Property vence As Date

        Public Property tasa As Decimal

        Public Property chequesfora As Boolean

        Public Property sucursal As Integer

        Public Property void As Boolean

        Public cuentasDropDownList As List(Of SelectListItem)

        <Display(Name:="Banco")>
        Public Property banco As String

        <Display(Name:="Docto")>
        <RegularExpression("^\d+$", ErrorMessage:="Solo se admiten números")>
        <Required(ErrorMessage:="El documento es obligatorio")>
        Public Property docto As String

        <Display(Name:="Capital")>
        <RegularExpression("^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,4})?))\)?$", ErrorMessage:="El Valor debe ser numerico o no tener mas de 2 decimales")>
        <DataType(DataType.Currency)>
        Public Property capital As Decimal

        <Display(Name:="Contrato")>
        Public Property contrato As String

        <Display(Name:="Nombre")>
        Public Property nombre As String

        Public Property ctabanco As String

        <RegularExpression("^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,4})?))\)?$", ErrorMessage:="El Valor debe ser numerico o no tener mas de 2 decimales")>
        <DataType(DataType.Currency)>
        Public Property generales As Decimal

    End Class

#End Region

#Region "Registro de cuentas"

    Public Class RegistroCuentasModel

        Public Sub CargaControles()
            dropDownBancos = New controles().cargaWebBancos()
            dropDownDivisa = New controles().CargaDivisa()

        End Sub

        <Key>
        Public Property numrec As Integer

        Public Property identidad As Integer?

        <Display(Name:="Id")>
        Public Property id As Integer?

        Public Property deudor As Integer?

        <Display(Name:="Banco")>
        <Required(ErrorMessage:="Seleccione el banco")>
        Public Property cuentaid As Integer?

        <StringLength(15)>
        <Display(Name:="Cuenta")>
        <Required(ErrorMessage:="Capture el número de cuenta")>
        <RegularExpression("^\d*$", ErrorMessage:="Solo se permiten numeros")>
        Public Property cuenta As String

        <Display(Name:="Divisa")>
        <Required(ErrorMessage:="Seleccione la divisa")>
        Public Property moneda As Integer?

        Public Property activo As Boolean

        <StringLength(15)>
        <Display(Name:="Plaza")>
        Public Property plaza As String

        <StringLength(15)>
        <Display(Name:="Sucursal")>
        Public Property sucursal As String

        <StringLength(18, ErrorMessage:="La CLABE no puede exceder de 18 carácteres")>
        <Display(Name:="CLABE")>
        <RegularExpression("^\d*$", ErrorMessage:="Solo se permiten numeros")>
        <Required(ErrorMessage:="Capture la CLABE")>
        <Remote("ValidacionClabe", "Tesoreria", AdditionalFields:="numrec")>
        Public Property clabe As String

        Public Property garantia As Boolean

        Public Property void As Boolean

        <StringLength(10)>
        Public Property updaterec As String

        Public Property modifica As Boolean

        Public Property dropDownBancos As List(Of SelectListItem)
        Public Property dropDownDivisa As List(Of SelectListItem)

        <Display(Name:="Banco")>
        Public Property nombre As String

        <Display(Name:="Estatus")>
        Public Property status As String

        <Display(Name:="Divisa")>
        Public Property divisa As String

    End Class

#End Region



End Namespace

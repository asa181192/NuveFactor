﻿Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization

Namespace Facturacion

	Public Class FacturacionModel

		Public Sub Cargacontroles()
			serieDropDownList = New controles().CargaDocumentos()
		End Sub

		<Display(Name:="Fecha")>
		Public Property fecha As Date?

		Public Property serie As String

		<Display(Name:="Docto")>
		Public Property folio As Integer?

		<Display(Name:="F.I.")>
		Public Property sisfol As Integer?

		<Display(Name:="Email")>
		Public Property email As Integer?

		Public Property identidad As Integer?

		Public Property id As Integer?

		<Display(Name:="Contrato")>
		Public Property contrato As Integer?

		<RegularExpression("^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,4})?))\)?$", ErrorMessage:="El Valor debe ser numerico o no tener mas de 2 decimales")>
		<DataType(DataType.Currency)>
		<DisplayFormat(DataFormatString:="{0:C}")>
		Public Property iva As Decimal?

		<RegularExpression("^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,4})?))\)?$", ErrorMessage:="El Valor debe ser numerico o no tener mas de 2 decimales")>
		<DataType(DataType.Currency)>
		<Display(Name:="Importe")>
		Public Property importe As Decimal?

		<Display(Name:="Imp")>
		Public Property impresiones As Integer?

		Public Property referencia As Integer?

		Public Property remark As String

		Public Property cancelado As Boolean?

		Public Property fcancelado As Date?

		Public Property moneda As Integer?

		Public Property manual As Boolean?

		Public Property void As Boolean?

		<Display(Name:="Emision")>
		Public Property emision As Date?

		<Display(Name:="Distrib")>
		Public Property distrib As String

		<Display(Name:="SAT")>
		Public Property sat As Decimal?

		<Display(Name:="Sustituir")>
		Public Property sustituir As Integer?

		<Display(Name:="ID")>
		Public Property idfiscalpf As Integer

		Public Property idcesion As Integer?

		Public Property envio As Boolean?

		Public Property foliooper As Integer?

		Public Property ati As String

		<Display(Name:="A nombre de")>
		Public Property nombre As String

		<Display(Name:="Canc")>
		Public Property cancel As String

		<Display(Name:="GP")>
		Public Property generated As String

		<Display(Name:="Divisa")>
		Public Property divisa As String

		<Display(Name:="Serie")>
		Public Property ssat As String

		Public Property serieDropDownList As List(Of SelectListItem)

		Public Property fecha1 As Date

	End Class

	Public Class fiscalPfModel

		Public Sub CargaControles(tipo As String)
			identidadDropDownList = New controles().CargaIdentidad()
			conceptoDropDownList = New controles().CargaConceptos(tipo)
			seriesDropDownList = New controles().CargaSeries()

		End Sub

		Public Property ivaBool As Boolean

		Public Property fecha As Date?

		Public Property serie As String

		Public Property folio As Integer?

		Public Property identidad As Integer?

		<Required(ErrorMessage:="Capture el contrato.")>
		Public Property id As Integer?

		<Required(ErrorMessage:="Capture el Id.")>
		Public Property contrato As Integer?

		Public Property iva As Decimal?

		<DisplayFormat(DataFormatString:="{0:C0}")>
		Public Property importe As Decimal?

		Public Property impresiones As Integer?

		Public Property referencia As Integer?

		Public Property remark As String

		Public Property cancelado As Boolean?

		Public Property fcancelado As Date?

		Public Property moneda As Integer?

		Public Property manual As Boolean?

		Public Property void As Boolean?

		Public Property emision As Date?

		Public Property distrib As String

		Public Property sat As Decimal?

		Public Property sustituir As Integer?

		Public Property idfiscalpf As Integer

		Public Property idcesion As Integer?

		Public Property envio As Boolean?

		Public Property foliooper As Integer?

		Public Property ati As String

		Public Property timestamp_column As Byte()

		Public Property tipo As String

		Public Property identidadDropDownList As List(Of SelectListItem)

		Public Property conceptoDropDownList As List(Of SelectListItem)

		Public Property seriesDropDownList As List(Of SelectListItem)

		<RegularExpression("^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,4})?))\)?$", ErrorMessage:="El Valor debe ser numerico o no tener mas de 2 decimales")>
		<DataType(DataType.Currency)>
		<DisplayFormat(DataFormatString:="{0:C0}")>
		<Required(ErrorMessage:="Capture el importe.")>
		Public Property base As Decimal

		<Required(ErrorMessage:="Capture el comentario.")>
		Public Property txtConcepto As String

		<Required(ErrorMessage:="Capture el documento.")>
		Public Property sisfol As Integer

		Public Property saldo As Decimal

		Public Property serie2 As String

		Public Property aplicarFactura As Boolean
		Public Property aplicarAdeudo As Boolean

		Public Property comision As Decimal
		Public Property ivacomision As Decimal

		Public Property seguro As Decimal
		Public Property ivaseguro As Decimal


	End Class

End Namespace



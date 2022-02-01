﻿Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports FactorEntidades
Imports nuve.CustomValidations
Imports nuve.OperacionesModels

Namespace Models

  Public Class Modeloadeudos

    <Display(Name:="Alta")>
    <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}", ApplyFormatInEditMode:=True)>
    Public Property fec_alta As Date?

    <Display(Name:="Fecha")>
    <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}", ApplyFormatInEditMode:=True)>
    Public Property fecha As Date?

    <Display(Name:="Adeudo")>
    Public Property Adeudo As String

    <Column(TypeName:="numeric")>
    <Display(Name:="Saldo")>
    <DataType(DataType.Currency)>
    <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    <CompareValuesValidation("SaldoPago")>
    Public Property saldo As Decimal

    <Column(TypeName:="numeric")>
      <Display(Name:="Monto")>
      <DataType(DataType.Currency)>
      <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    Public Property monto As Decimal

    Public Property moneda As Integer

    <Display(Name:="Contrato")>
    Public Property contrato As Integer

    <Display(Name:="Id Adeudo")>
    Public Property idadeudo As Integer

    <Display(Name:="Id Pago")>
    Public Property numrec As Integer

    <Display(Name:="Referencia")>
    Public Property referencia As Integer

    Public Property docto As Integer

    <Display(Name:="tipo")>
    <StringLength(3, ErrorMessage:="Demasiados Caraceteres")>
    Public Property tipo As String

    <Display(Name:="serie")>
    <StringLength(1, ErrorMessage:="Demasiados Caraceteres")>
    Public Property serie As String

    <Display(Name:="Divisa")>
    <StringLength(3, ErrorMessage:="Demasiados Caraceteres")>
    Public Property monedaStr As String

    <Display(Name:="Nombre")>
    <StringLength(100, ErrorMessage:="Demasiados Caraceteres")>
    Public Property Nombre As String

    <StringLength(2)>
    Public Property movto As String

    <Display(Name:="Concepto")>
    <StringLength(80)>
    <Required(ErrorMessage:="El campo Concepto es obligatorio")>
    Public Property concepto As String

    <Column(TypeName:="numeric")>
      <Display(Name:="Pago")>
    <DataType(DataType.Currency)>
      <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    Public Property importe As Decimal

        Public Property SaldoPago As Decimal

        <Display(Name:="  ")>
    Public Property void As Boolean


  End Class

  Public Class Modeloedocuenta

    <Display(Name:="Fecha")>
    <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}", ApplyFormatInEditMode:=True)>
    Public Property fecha As Date?

    <Display(Name:="Contrato")>
    Public Property contrato As Integer

    Public Property id As Integer

    <Display(Name:="Concepto")>
    <StringLength(40)>
    Public Property concepto As String

    <StringLength(2)>
    Public Property movto As String

    <Column(TypeName:="numeric")>
    <Display(Name:="Cartera")>
    <DataType(DataType.Currency)>
    <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    Public Property cartera As Decimal

    <Column(TypeName:="numeric")>
    <Display(Name:="Ant_debe")>
    <DataType(DataType.Currency)>
    <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    Public Property ant_debe As Decimal

    <Column(TypeName:="numeric")>
    <Display(Name:="Ant_haber")>
    <DataType(DataType.Currency)>
    <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    Public Property ant_haber As Decimal

    <Column(TypeName:="numeric")>
    <Display(Name:="Ant_saldo")>
    <DataType(DataType.Currency)>
    <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    Public Property ant_saldo As Decimal

    <Column(TypeName:="numeric")>
    <Display(Name:="Anticipo")>
    <DataType(DataType.Currency)>
    <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    Public Property anticipo As Decimal

    <Column(TypeName:="numeric")>
    <Display(Name:="Car_debe")>
    <DataType(DataType.Currency)>
    <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    Public Property car_debe As Decimal

    <Column(TypeName:="numeric")>
    <Display(Name:="Car_haber")>
    <DataType(DataType.Currency)>
    <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    Public Property car_haber As Decimal

    <Column(TypeName:="numeric")>
    <Display(Name:="Car_saldo")>
    <DataType(DataType.Currency)>
    <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    Public Property car_saldo As Decimal

    <Display(Name:="Cancelado")>
    Public Property cancelado As Integer

    <Display(Name:="Proveedor")>
    Public Property proveedor As Integer

    <Display(Name:="Nombre")>
    <StringLength(100, ErrorMessage:="Demasiados Caraceteres")>
    Public Property nombre As String

    <Display(Name:="Descripción")>
    <StringLength(100, ErrorMessage:="Demasiados Caraceteres")>
    Public Property descripcion As String

    <Display(Name:="Producto")>
    Public Property producto As Integer

    <Column(TypeName:="numeric")>
    <Display(Name:="Línea")>
    <DataType(DataType.Currency)>
    <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    Public Property linea As Decimal

    Public Property disponible As Decimal

  End Class

  Public Class Modelocobranza

    <Display(Name:="Fecha")>
    <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}", ApplyFormatInEditMode:=True)>
    Public Property fecha As Date?

    <Display(Name:="Fec_vmto")>
    <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}", ApplyFormatInEditMode:=True)>
    Public Property fec_vence As Date?

    Public Property iddocto As Integer

    <Display(Name:="Contrato")>
    Public Property contrato As Integer

    Public Property interes As Integer
    Public Property deudor As Integer
    Public Property cobranza As Integer

    <Display(Name:="Afectado")>
    Public Property afectado As Integer
    Public Property cancelado As Integer
    Public Property producto As Integer
    Public Property descrip As String
    Public Property cv As Integer
    Public Property scv As String

    <Display(Name:="Status")>
    Public Property safectado As String

    <Display(Name:="Cesión")>
    Public Property cesion As Integer

    Public Property pagare As Integer

    <Display(Name:="Documento")>
    Public Property docto As String

    <Column(TypeName:="numeric")>
    <Display(Name:="Saldo")>
    <DataType(DataType.Currency)>
    <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    Public Property saldo As Decimal

    <Column(TypeName:="numeric")>
    <Display(Name:="Importe")>
    <DataType(DataType.Currency)>
    <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    Public Property importe As Decimal

    <Column(TypeName:="numeric")>
    <Display(Name:="Descto")>
    <DataType(DataType.Currency)>
    <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    Public Property descto As Decimal

    <Column(TypeName:="numeric")>
    <Display(Name:="Neto")>
    <DataType(DataType.Currency)>
    <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    Public Property neto As Decimal

    <Column(TypeName:="numeric")>
    <Display(Name:="Bonifica")>
    <DataType(DataType.Currency)>
    <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    Public Property bonifica As Decimal

    <Column(TypeName:="numeric")>
    <Display(Name:="saldoanterior")>
    <DataType(DataType.Currency)>
    <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    Public Property saldoanterior As Decimal

    <Display(Name:="Nombre")>
    <StringLength(100, ErrorMessage:="Demasiados Caraceteres")>
    Public Property Nombre As String

    <Display(Name:="Deudor")>
    <StringLength(100, ErrorMessage:="Demasiados Caraceteres")>
    Public Property nombredeudor As String

    <Column(TypeName:="numeric")>
     <Display(Name:="Adeudos")>
     <DataType(DataType.Currency)>
     <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    Public Property adeudo As Decimal

    <Column(TypeName:="numeric")>
    <Display(Name:="Provisión")>
    <DataType(DataType.Currency)>
    <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    Public Property provision As Decimal

    <Column(TypeName:="numeric")>
  <Display(Name:="Moratorios")>
  <DataType(DataType.Currency)>
  <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    Public Property moratorio As Decimal

    Public Property timporte As Decimal

    Public Property tdescto As Decimal

    Public Property tdeposito As Decimal

    Public Property tneto As Decimal

    Public Property tbonifica As Decimal

    Public Property idcobranza As Integer

    Public Property moneda As Integer

    <Display(Name:="Divisa")>
    Public Property monedastr As String

    <Display(Name:="  ")>
    Public Property void As Boolean

    Public Property porc_aforo As Decimal

    Public Property porc_anti As Decimal

    <Column(TypeName:="numeric")>
 <Display(Name:="Depósito")>
 <DataType(DataType.Currency)>
 <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    Public Property deposito As Decimal

  End Class

  Public Class ModeloHistRemante
    Public Property numrec As Integer

    Public Property fecha As Date?

    Public Property contrato As Integer?

    Public Property cobranza As Integer?

    Public Property importe As Decimal?

    Public Property pago As Decimal?

    Public Property cobrado As Decimal?

    Public Property aforo As Decimal?

    Public Property descto As Decimal?

    Public Property bonifica As Decimal?

    Public Property cartera As Decimal?

    Public Property adeudos As Decimal?

    Public Property idctabanco As Integer?

    Public Property cuenta As String

    Public Property folio As Integer?

    Public Property movto As String

    Public Property cancelado As Boolean

    Public Property pagomatriz As Boolean

    Public Property userid As String

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

    Public Property disperfile As String

    Public Property id As Integer?

    Public Property identidad As Integer?

    Public Property disperstat As Integer?

  End Class

  Public Class ModeloRemanente
    Public Property contrato As Integer?

    Public Property remanente As Decimal?

    Public Property anterior As Decimal?

    Public Property fec_change As Date?

    Public Property movto As String

    Public Property id As Integer?

    Public Property identidad As Integer?

  End Class

  Public Class ModeloAforos

    Public Sub CargaControles(identidad As Integer, id As Integer, moneda As Integer)
      CuentaLiquidaDropDown = New controles().CargaLiquidaCuenta(identidad, id, moneda)
    End Sub

    Public CuentaLiquidaDropDown As List(Of SelectListItem)

    <Display(Name:="Contrato")>
    Public Property contrato As Integer
    <Display(Name:="Importe")>
    Public Property importe As Decimal

  
    Public Property monto As Decimal
    <Display(Name:="Pago")>
    <CompareValuesValidation("monto")>
    Public Property pago As Decimal

    Public Property Cuenta As String
    <Display(Name:="Folio")>
    Public Property folio As Integer
    Public Property movto As String
    <Display(Name:="Nombre")>
    Public Property nombre As String
    Public Property cobranza As Integer
    Public Property pagomatriz As Boolean
    Public Property fecpago As DateTime
    Public Property Moneda As String
    Public Property userid As String
    <Display(Name:="Número de Cuenta")>
    Public Property numreccta As Integer
    Public Property idctabanco As Integer
    <Display(Name:="Beneficiario")>
    Public Property benef As String
    Public Property producto As Integer
    Public Property mone As Integer
    Public Property id As Integer
    Public Property identidad As Integer
    Public Property aforo As Decimal
    Public Property descto As Decimal
    Public Property bonifica As Decimal
    <Display(Name:="Cartera")>
    Public Property cartera As Decimal
    Public Property adeudos As Decimal
    Public Property remanente As Decimal
  End Class

  Public Class ModeloMonitorlineas

    <Display(Name:="Contrato")>
    Public Property contrato As Integer

    <Display(Name:="Cliente")>
    Public Property cliente As Integer

    <Display(Name:="Nombre")>
    Public Property nombre As String

    <Display(Name:="Producto")>
    Public Property producto As String

    <Display(Name:="Divisa")>
    Public Property divisa As String

    <Display(Name:="Línea")>
    Public Property linea As Decimal

    <Display(Name:="Cartera")>
    Public Property cartera As Decimal

    <Display(Name:="C.Vencida")>
    Public Property vencida As Decimal

    <Display(Name:="Moratorio")>
    Public Property moratorio As Decimal

    <Display(Name:="I.M.V.")>
    Public Property imv As Decimal

    <Display(Name:="I. VMTO")>
    Public Property iv As Decimal

    <Display(Name:="Adeudos")>
    Public Property adeudo As Decimal

    <Display(Name:="Interés")>
    Public Property Tinteres As String

    <Display(Name:="Total")>
    Public Property total As Decimal


  End Class


End Namespace

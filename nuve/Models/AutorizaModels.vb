Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports FactorEntidades
Imports nuve.CustomValidations
Imports nuve.OperacionesModels

Namespace Models

  Public Class Modeloautoriza

    <Display(Name:="Oper")>
    Public Property oper As String

    <Display(Name:="Contrato")>
    Public Property contrato As Integer

    <Display(Name:="Fecha")>
    Public Property fecha As Date

    <Display(Name:="Fondeo")>
    Public Property timefondeo As String

    <Display(Name:="Inicio")>
    Public Property timestart As String

    <Display(Name:="Nombre")>
    Public Property contname As String

    <Display(Name:="Divisa")>
    Public Property moneda As String

    <Display(Name:="Descrip")>
    Public Property descrip As String

    <Column(TypeName:="numeric")>
        <Display(Name:="Pago")>
        <DataType(DataType.Currency)>
        <DisplayFormat(DataFormatString:="{0:N}", ApplyFormatInEditMode:=True)>
    Public Property pago As Decimal

    <Display(Name:="Cheque")>
    Public Property cheque As Integer

    <Display(Name:="CtaBanco")>
    Public Property banco As String

    <Display(Name:="idbanco")>
    Public Property idbanco As Integer

    <Display(Name:="ctabanco")>
    Public Property ctabanco As String

    <Display(Name:="Cuenta")>
    Public Property cuenta As String

    <Display(Name:="Clabe")>
    Public Property clabe As String

    <Display(Name:="Banco")>
    Public Property shortname As String


    <Display(Name:="Rfc")>
    Public Property rfc As String

    <Display(Name:="Beneficiario")>
    Public Property benefi As String

    <Display(Name:="Ref. Pago")>
    Public Property disperfile As String

    Public Property id As Integer

    Public Property identidad As Integer

    <Display(Name:="Estatus")>
    Public Property disperstat As Integer


    <Display(Name:="IdRec")>
    Public Property IdRec As Integer

    <Display(Name:="Producto")>
    Public Property producto As Integer

    <Display(Name:="Cuentaid")>
    Public Property cuentaid As Integer

    <Display(Name:="Status")>
    Public Property stat As String

    <Display(Name:=" ")>
    Public Property movto As Integer

    <Display(Name:="  ")>
    Public Property void As Boolean

  End Class
End Namespace
















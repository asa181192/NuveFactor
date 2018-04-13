Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class dev_iv
    <Key>
    <Column(TypeName:="numeric")>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property numrec As Decimal

    Public Property fecha As Date?

    Public Property fec_alta As Date?

    Public Property fec_vence As Date?

    Public Property fec_pago As Date?

    Public Property producto As Integer?

    Public Property contrato As Integer?

    Public Property moneda As Integer?

    Public Property cesion As Integer?

    <StringLength(20)>
    Public Property docto As String

    Public Property iddocto As Integer?

    Public Property idcesion As Integer?

    Public Property deudor As Integer?

    <Column(TypeName:="numeric")>
    Public Property anticipo As Decimal?

    <Column(TypeName:="numeric")>
    Public Property interes As Decimal?

    <Column(TypeName:="numeric")>
    Public Property movto As Decimal?

    <Column(TypeName:="numeric")>
    Public Property imp_inter As Decimal?

    <Column(TypeName:="numeric")>
    Public Property int_diario As Decimal?

    <Column(TypeName:="numeric")>
    Public Property tasaoper As Decimal?

    <Column(TypeName:="numeric")>
    Public Property plazo As Decimal?

    Public Property void As Boolean

    <Column(TypeName:="numeric")>
    Public Property sisfol As Decimal?

    <StringLength(2)>
    Public Property serie As String

    <Column(TypeName:="numeric")>
    Public Property folio As Decimal?

    Public Property fec_prov As Date?
End Class

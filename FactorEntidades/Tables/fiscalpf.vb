Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("fiscalpf")>
Partial Public Class fiscalpf
    Public Property fecha As Date?

    <StringLength(1)>
    Public Property serie As String

    Public Property folio As Integer?

    Public Property sisfol As Integer?

    Public Property identidad As Integer?

    Public Property id As Integer?

    Public Property contrato As Integer?

    <Column(TypeName:="numeric")>
    Public Property iva As Decimal?

    <Column(TypeName:="money")>
    Public Property importe As Decimal?

    Public Property impresiones As Integer?

    Public Property referencia As Integer?

    <Column(TypeName:="text")>
    Public Property remark As String

    Public Property cancelado As Boolean?

    Public Property fcancelado As Date?

    Public Property moneda As Integer?

    Public Property manual As Boolean?

    Public Property void As Boolean?

    Public Property emision As Date?

    <StringLength(1)>
    Public Property distrib As String

    <Column(TypeName:="numeric")>
    Public Property sat As Decimal?

    Public Property sustituir As Integer?

    <Key>
    Public Property idfiscalpf As Integer

    Public Property idcesion As Integer?

    Public Property envio As Boolean?

    Public Property foliooper As Integer?

    <Column(TypeName:="text")>
    Public Property ati As String


End Class

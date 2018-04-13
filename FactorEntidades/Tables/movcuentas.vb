Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class movcuentas
    <Key>
    Public Property numrec As Integer

    Public Property idctabanco As Integer?

    Public Property fecha As Date?

    <StringLength(15)>
    Public Property ctabancobk As String

    <StringLength(2)>
    Public Property tipo As String

    Public Property folio As Integer?

    Public Property contrato As Integer?

    Public Property cesion As Integer?

    <StringLength(75)>
    Public Property beneficiario As String

    <StringLength(75)>
    Public Property concepto As String

    <StringLength(60)>
    Public Property concconta As String

    Public Property depoencta As Boolean

    Public Property impresiones As Integer?

    <Column(TypeName:="numeric")>
    Public Property entrada As Decimal?

    <Column(TypeName:="numeric")>
    Public Property salida As Decimal?

    <Column(TypeName:="numeric")>
    Public Property saldo As Decimal?

    Public Property ficha As Integer?

    Public Property cancelado As Boolean

    Public Property feccanc As Date?

    Public Property vence As Date?

    <Column(TypeName:="numeric")>
    Public Property tasa As Decimal?

    Public Property chequesfora As Boolean

    Public Property sucursal As Integer?

    Public Property void As Boolean
End Class

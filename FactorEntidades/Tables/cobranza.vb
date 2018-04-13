Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("cobranza")>
Partial Public Class cobranza
    <Key>
    <Column(Order:=0)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property idcobranza As Integer

    Public Property fecha As Date?

    <Column(TypeName:="numeric")>
    Public Property iddocto As Decimal?

    Public Property contrato As Integer?

    Public Property cesion As Integer?

    <StringLength(10)>
    Public Property pagare As String

    <StringLength(15)>
    Public Property docto As String

    <Column(TypeName:="numeric")>
    Public Property importe As Decimal?

    <Column(TypeName:="numeric")>
    Public Property descto As Decimal?

    <Column(TypeName:="numeric")>
    Public Property neto As Decimal?

    <Column(TypeName:="numeric")>
    Public Property bonifica As Decimal?

    Public Property deudor As Integer?

    <Column(TypeName:="numeric")>
    Public Property saldoanterior As Decimal?

    <Column("cobranza")>
    Public Property cobranza1 As Integer?

    <Key>
    <Column(Order:=1)>
    Public Property afectado As Boolean

    <Key>
    <Column(Order:=2)>
    Public Property cancelado As Boolean

    <Key>
    <Column(Order:=3)>
    Public Property cv As Boolean

    <Key>
    <Column(Order:=4)>
    Public Property void As Boolean
End Class

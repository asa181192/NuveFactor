Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class basketitems
    <Key>
    <Column(Order:=0)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property basketitemid As Integer

    <Key>
    <Column(Order:=1)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property basketid As Integer

    Public Property contrato As Integer?

    Public Property deudor As Integer?

    <StringLength(20)>
    Public Property docto As String

    <Column(TypeName:="numeric")>
    Public Property total As Decimal?

    <Column(TypeName:="numeric")>
    Public Property monto As Decimal?

    <Column(TypeName:="numeric")>
    Public Property descto As Decimal?

    <Column(TypeName:="numeric")>
    Public Property hono As Decimal?

    <Column(TypeName:="numeric")>
    Public Property iva As Decimal?

    Public Property plazo As Integer?

    <Column(TypeName:="numeric")>
    Public Property tinter As Decimal?

    <Column(TypeName:="numeric")>
    Public Property neto As Decimal?

    <Key>
    <Column(Order:=2)>
    Public Property void As Boolean

    <Column(TypeName:="numeric")>
    Public Property ivainteres As Decimal?

    <Column(TypeName:="numeric")>
    Public Property tasaoper As Decimal?

    <Column(TypeName:="numeric")>
    Public Property servnafin As Decimal?

    <Column(TypeName:="numeric")>
    Public Property ivaserv As Decimal?

    <Column(TypeName:="numeric")>
    Public Property int_diario As Decimal?

    <Column(TypeName:="numeric")>
    Public Property ctetinter As Decimal?

    <Column(TypeName:="numeric")>
    Public Property ctehono As Decimal?

    <Column(TypeName:="numeric")>
    Public Property cteiva As Decimal?
End Class

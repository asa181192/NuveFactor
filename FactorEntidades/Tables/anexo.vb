Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("anexo")>
Partial Public Class anexo
    Public Property contrato As Integer?

    Public Property deudor As Integer?

    <Key>
    <Column(Order:=0)>
    Public Property mancobranza As Boolean

    <Key>
    <Column(Order:=1)>
    Public Property notifica As Boolean

    <Key>
    <Column(Order:=2)>
    Public Property activo As Boolean

    <Key>
    <Column(Order:=3)>
    Public Property cancelado As Boolean

    <StringLength(20)>
    Public Property catcte As String

    <Key>
    <Column(Order:=4)>
    Public Property imprimir As Boolean

    <Column(TypeName:="numeric")>
    Public Property sobretasa As Decimal?

    <Column(TypeName:="numeric")>
    Public Property limite As Decimal?

    <Key>
    <Column(Order:=5)>
    Public Property void As Boolean

    <Key>
    <Column(Order:=6)>
    Public Property modifica As Boolean

    <StringLength(10)>
    Public Property updaterec As String
End Class

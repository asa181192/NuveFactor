Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("edocuenta")>
Partial Public Class edocuenta
    Public Property contrato As Integer?

    Public Property id As Integer?

    Public Property fecha As Date?

    <StringLength(40)>
    Public Property concepto As String

    <StringLength(2)>
    Public Property movto As String

    <Column(TypeName:="numeric")>
    Public Property ant_debe As Decimal?

    <Column(TypeName:="numeric")>
    Public Property ant_haber As Decimal?

    <Column(TypeName:="numeric")>
    Public Property car_debe As Decimal?

    <Column(TypeName:="numeric")>
    Public Property car_haber As Decimal?

    <Key>
    <Column(Order:=0)>
    Public Property cancelado As Boolean

    Public Property proveedor As Integer?

    <Key>
    <Column(Order:=1)>
    Public Property void As Boolean
End Class

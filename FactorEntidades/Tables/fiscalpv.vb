Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("fiscalpv")>
Partial Public Class fiscalpv
    Public Property fecha As Date?

    <StringLength(1)>
    Public Property serie As String

    <StringLength(2)>
    Public Property tipo As String

    Public Property folio As Integer?

    <Column(Order:=1)>
    Public Property sisfol As Integer?

    <StringLength(70)>
    Public Property concepto As String

    <Column(TypeName:="money")>
    Public Property monto As Decimal?

    <Column(TypeName:="money")>
    Public Property seguro As Decimal?

    Public Property cancelado As Boolean

    Public Property void As Boolean

    Public Property idfiscalpf As Integer?

    <Key>
    Public Property idfisacalpv As Integer

End Class

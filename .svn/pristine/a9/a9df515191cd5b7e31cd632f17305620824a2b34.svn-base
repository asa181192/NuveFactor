Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("descuento")>
Partial Public Class descuento
    Public Property basketid As Integer?

    <Key>
    <Column(Order:=0)>
    Public Property numdesc As Integer

    Public Property fecha As Date?

    Public Property contrato As Integer?

    Public Property deudor As Integer?

    <Column(TypeName:="numeric")>
    Public Property importe As Decimal?

    <StringLength(20)>
    Public Property docto As String

    <StringLength(20)>
    Public Property descto As String

    <StringLength(20)>
    Public Property referencia As String

    Public Property folio As Integer?

    <Key>
    <Column(Order:=1)>
    Public Property basket As Boolean

    <Key>
    <Column(Order:=2)>
    Public Property importado As Boolean

    Public Property folioauto As Integer?

    Public Property autoriza As Date?

    Public Property envio As Integer?

    <Key>
    <Column(Order:=3)>
    Public Property void As Boolean
End Class

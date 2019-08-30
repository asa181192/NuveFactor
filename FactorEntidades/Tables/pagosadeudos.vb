Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class pagosadeudos
    <Key>
    Public Property numrec As Integer

    Public Property id As Integer?

    Public Property contrato As Integer?

    Public Property fecha As Date?

    <StringLength(2)>
    Public Property tipo As String

    <StringLength(1)>
    Public Property serie As String

    Public Property sisfol As Integer?

    Public Property docto As Integer?

    <StringLength(2)>
    Public Property movto As String

    <Column(TypeName:="numeric")>
    Public Property importe As Decimal?

    Public Property referencia As Integer?

    <StringLength(80)>
    Public Property concepto As String

    Public Property identidad As Integer?

    Public Property idctabanco As Integer?

    <StringLength(15)>
    Public Property cuenta As String

    Public Property cheque As Integer?

    Public Property cancelado As Boolean?

    Public Property void As Boolean?

    Public Property idadeudo As Integer?

    Public Property ati As String

    Public Property sat As Integer

    Public Property envio As Boolean?
End Class

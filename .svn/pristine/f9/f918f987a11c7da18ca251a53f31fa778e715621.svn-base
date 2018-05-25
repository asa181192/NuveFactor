Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class ctasaldos
    <Key>
    Public Property numrec As Integer

    Public Property fecha As Date?

    Public Property idctabanco As Integer?

    <StringLength(15)>
    Public Property ctabanco As String

    <Column(TypeName:="money")>
    Public Property santerior As Decimal?

    <Column(TypeName:="money")>
    Public Property entradas As Decimal?

    <Column(TypeName:="money")>
    Public Property salidas As Decimal?

    <Column(TypeName:="money")>
    Public Property sactual As Decimal?

    <Column(TypeName:="text")>
    Public Property saldos As String

    Public Property void As Boolean

    <Column(TypeName:="timestamp")>
    <MaxLength(8)>
    <Timestamp>
    Public Property timestamp_column As Byte()
End Class

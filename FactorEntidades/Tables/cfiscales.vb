Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class cfiscales
    <Key>
    <Column(Order:=0)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property id As Integer

    <StringLength(1)>
    Public Property serie As String

    <StringLength(2)>
    Public Property tipo As String

    <StringLength(50)>
    Public Property descrip As String

    <Column(TypeName:="money")>
    Public Property totales As Decimal?

    <Key>
    <Column(Order:=1)>
    Public Property void As Boolean
End Class

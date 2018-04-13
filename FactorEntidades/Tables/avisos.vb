Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class avisos
    Public Property fecha As Date?

    <Column(TypeName:="text")>
    Public Property aviso As String

    <Key>
    <Column(Order:=0)>
    Public Property diacompleto As Boolean

    <Key>
    <Column(Order:=1)>
    Public Property void As Boolean

    <Key>
    <Column(Order:=2, TypeName:="timestamp")>
    <MaxLength(8)>
    <Timestamp>
    Public Property timestamp_column As Byte()
End Class

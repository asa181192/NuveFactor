Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("monitor")>
Partial Public Class monitor
    <Key>
    <Column(Order:=0)>
    <StringLength(20)>
    Public Property userid As String

    Public Property fechatime As Date?

    <Key>
    <Column(Order:=1, TypeName:="text")>
    Public Property action As String

    Public Property fecha As Date?

    <Key>
    <Column(Order:=2)>
    <StringLength(10)>
    Public Property void As String

    <Key>
    <Column(Order:=3, TypeName:="timestamp")>
    <MaxLength(8)>
    <Timestamp>
    Public Property timestamp_column As Byte()
End Class

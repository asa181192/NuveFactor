Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("webservice")>
Partial Public Class webservice
    <Column("webservice")>
    <StringLength(30)>
    Public Property webservice1 As String

    <StringLength(50)>
    Public Property soapfield As String

    <StringLength(254)>
    Public Property soapurl As String

    <StringLength(200)>
    Public Property soapaction As String

    <Column(TypeName:="text")>
    Public Property soaprequest As String

    <Key>
    <Column(TypeName:="timestamp")>
    <MaxLength(8)>
    <Timestamp>
    Public Property timestamp_column As Byte()
End Class

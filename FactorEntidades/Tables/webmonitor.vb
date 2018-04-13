Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("webmonitor")>
Partial Public Class webmonitor
    <Key>
    Public Property idmonitor As Integer

    Public Property folio As Integer?

    Public Property basketid As Integer?

    Public Property fecha As Date?

    Public Property movto As Integer?

    <Column(TypeName:="text")>
    Public Property action As String

    <StringLength(20)>
    Public Property userfeb As String

    Public Property void As Boolean?

    <Column(TypeName:="timestamp")>
    <MaxLength(8)>
    <Timestamp>
    Public Property timestamp_column As Byte()
End Class

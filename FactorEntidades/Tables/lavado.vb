Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("lavado")>
Partial Public Class lavado
    <StringLength(10)>
    Public Property idrec As String

    <Column(TypeName:="numeric")>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property id As Decimal

    Public Property fecha As Date?

    Public Property tipo As Integer?

    <Column(TypeName:="text")>
    Public Property detalle As String

    Public Property status As Integer?

    Public Property void As Boolean

    <Column(TypeName:="timestamp")>
    <MaxLength(8)>
    <Timestamp>
    Public Property timestamp_column As Byte()
End Class

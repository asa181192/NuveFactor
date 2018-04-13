Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("foliosat")>
Partial Public Class foliosat
    <Key>
    Public Property idserie As Integer

    Public Property fecha As Date?

    <StringLength(3)>
    Public Property serie As String

    <StringLength(15)>
    Public Property autoriza As String

    Public Property inicio As Integer?

    Public Property fin As Integer?

    Public Property estado As Integer?

    Public Property fec_aprob As Date?

    Public Property anio As Integer?

    <StringLength(20)>
    Public Property certifica As String

    Public Property void As Boolean
End Class

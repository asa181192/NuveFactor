Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("monitor")>
Partial Public Class monitor
    <Key>
    Public Property idmonitor As Integer

    <StringLength(20)>
    Public Property userid As String

    Public Property fechatime As Date?

    Public Property ip As String

    Public Property action As String

    Public Property fecha As Date?

    <StringLength(10)>
    Public Property void As String
End Class

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("estadosmexicocnbv")>
Partial Public Class estadosmexicocnbv
    <Key>
    <Column(Order:=0)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property num As Integer

    <StringLength(25)>
    Public Property estado As String

    <Key>
    <Column(Order:=1)>
    Public Property void As Boolean
End Class

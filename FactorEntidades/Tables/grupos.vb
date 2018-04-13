Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class grupos
    <Key>
    Public Property clave As Integer

    <StringLength(40)>
    Public Property nombre As String

    Public Property void As Boolean?
End Class

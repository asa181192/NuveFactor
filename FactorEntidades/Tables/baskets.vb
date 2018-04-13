Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class baskets
    <Key>
    Public Property basketid As Integer

    Public Property expires As Date?

    Public Property post As Integer?

    Public Property void As Boolean?

    <StringLength(38)>
    Public Property idtransact As String
End Class

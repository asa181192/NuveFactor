Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class webbancos
    <Key>
    Public Property cuentaid As Integer

    <StringLength(20)>
    Public Property shortname As String

    Public Property tipofondeo As Integer?

    Public Property idctabanco As Integer?

    Public Property moneda As Integer?

    Public Property void As Boolean?
End Class

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class notifica_e
    <Key>
    <Column(TypeName:="numeric")>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property idrec As Decimal

    Public Property fecha As Date?

    Public Property contrato As Integer?

    Public Property deudor As Integer?

    <StringLength(200)>
    Public Property filename As String

    <StringLength(10)>
    Public Property descrip As String

    <StringLength(200)>
    Public Property email As String

    Public Property confirma As Boolean?

    <StringLength(200)>
    Public Property evidencia As String

    Public Property void As Boolean?
End Class

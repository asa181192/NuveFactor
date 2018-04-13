Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("aseguradora")>
Partial Public Class aseguradora
    <Key>
    Public Property idaseguradora As Integer

    <StringLength(100)>
    Public Property nombre As String

    <StringLength(50)>
    Public Property calle As String

    <StringLength(15)>
    Public Property noext As String

    <StringLength(15)>
    Public Property noint As String

    <StringLength(50)>
    Public Property colonia As String

    <StringLength(50)>
    Public Property municipio As String

    <StringLength(50)>
    Public Property estado As String

    <StringLength(50)>
    Public Property pais As String

    Public Property cp As Integer?

    <StringLength(50)>
    Public Property telefono As String

    <StringLength(15)>
    Public Property rfc As String

    <StringLength(100)>
    Public Property email As String
End Class

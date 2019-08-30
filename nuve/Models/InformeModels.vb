Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports FactorEntidades
Imports nuve.CustomValidations
Imports nuve.Models

Namespace Models

  Public Class ModeloInformes


    <Display(Name:="Id")>
    Public Property Idreporte As Integer

    <Display(Name:="Módulo")>
    Public Property modulo As String

    <Display(Name:="Descripción")>
    Public Property descripcion As String

    <Display(Name:="Url")>
    Public Property url As String

  End Class

End Namespace

Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports FactorEntidades
Imports nuve.CustomValidations


Namespace Models

  Public Class ModeloConsolida

    <Display(Name:="Id")>
    Public Property idrec As Integer

    <Display(Name:="Fecha")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:MM-dd-yyyy hh:mm tt}", ApplyFormatInEditMode:=True)>
    Public Property fecha() As Date?


    '<Display(Name:="Fecha")>
    '<DataType(DataType.Date)>
    '<DisplayFormat(DataFormatString:="{0:MM-dd-yyyy hh:mm tt}", ApplyFormatInEditMode:=True)>
    '    Public Property fecha() As Date?

    <Display(Name:="Archivo")>
    Public Property archivo As String

    <Display(Name:="Resultado")>
    Public Property resultado As String

    <Display(Name:="Importado")>
    Public Property exito As Boolean

    <Display(Name:="Procesado")>
    Public Property tfecha As String




  End Class


End Namespace

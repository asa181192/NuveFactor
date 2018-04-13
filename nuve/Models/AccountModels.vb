﻿Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization

Public Class login
  <Required()> _
  <Display(Name:="Usuario")> _
  Public Property user As String

  <Required()> _
  <DataType(DataType.Password)> _
  <Display(Name:="Contraseña")> _
  Public Property password As String
End Class

Public Class contrasena_olvidada
  <Required()> _
  <Display(Name:="Dirección de correo")> _
  <EmailAddress(ErrorMessage:="la dirección de correo no es valida")> _
  <StringLength(150)> _
  Public Property mail As String
End Class

Public Class contrasena_cambio
  <Required()> _
  <StringLength(255, ErrorMessage:="Debe escribir la contraseña actual", MinimumLength:=1)> _
  <DataType(DataType.Password)> _
  <Display(Name:="Actual")> _
  Public Property actual As String

  <Required()> _
  <StringLength(255, ErrorMessage:="Debe escribir la nueva contraseña", MinimumLength:=1)> _
  <DataType(DataType.Password)> _
  <Display(Name:="Nueva")> _
  Public Property nueva As String

    <Required()> _
    <StringLength(255, ErrorMessage:="Debe confirmar la nueva contraseña", MinimumLength:=1)> _
    <DataType(DataType.Password)> _
    <Display(Name:="Confirmación")> _
    <System.ComponentModel.DataAnnotations.Compare("nueva", ErrorMessage:="La contraseña y confirmación no son iguales.")> _
    Public Property confirmacion As String




End Class
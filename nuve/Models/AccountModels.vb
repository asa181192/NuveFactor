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
  
	Public Property userid As Integer

	Public Property username As String

	<Required()> _
	<DataType(DataType.Password)> _
	<Display(Name:="Contraseña nueva")> _
	<RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[\\/.+*:_{\[\]]).{8,10}$", ErrorMessage:="Contraseña no cumple con las reglas")>
	Public Property nueva As String

	<Required()> _
	<DataType(DataType.Password)> _
	<Display(Name:="Confirmar contraseña nueva")> _
	<System.ComponentModel.DataAnnotations.Compare("nueva", ErrorMessage:="La contraseña nueva y la confirmación no son iguales.")> _
	<RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[\\/.+*:_{\[\]]).{8,10}$", ErrorMessage:="Contraseña no cumple con las reglas")>
	Public Property confirmacion As String




End Class
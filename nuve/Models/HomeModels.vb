﻿Imports System.ComponentModel.DataAnnotations

Public Class ModeloVersion
	<Display(Name:="Fecha")>
	<Required(ErrorMessage:="El campo fecha es Obligatorio")>
	Public Property fecha As Date?
	<Display(Name:="Notas de la version")>
	<Required(ErrorMessage:="El campo notas es Obligatorio")>
	Public Property notas As String
	<Display(Name:="Version")>
	<Required(ErrorMessage:="El campo Version es Obligatorio")>
 Public Property version As String
End Class

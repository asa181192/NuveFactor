﻿Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Perfil")>
Partial Public Class Perfil
	<Key>
	Public Property idPerfil As Integer

	<StringLength(30)>
	Public Property nombre As String

	Public Property activo As Integer?
End Class

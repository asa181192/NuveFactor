Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class perfil

	<Key>
	<Column("perfil")>
	Public Property perfil1 As Integer

	<StringLength(30)>
	Public Property nombre As String

	Public Property activo As Boolean

	Public Property void As Boolean

End Class

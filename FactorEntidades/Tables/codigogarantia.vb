Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("codigogarantia")>
Partial Public Class codigogarantia
	<Key>
	Public Property codigoid As Integer

	<StringLength(50)>
	Public Property nombre As String

	Public Property cod_alterno As Integer?

	Public Property void As Boolean?
End Class

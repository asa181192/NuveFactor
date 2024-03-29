Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class usersregs
	Public Property fec_alta As Date?

	<Key>
	Public Property folio As Integer

	<StringLength(10)>
	Public Property username As String

	<StringLength(10)>
	Public Property ca As String

	Public Property pw As Integer?

	Public Property sessionid As Integer?

	<StringLength(20)>
	Public Property listpass As String

	<StringLength(50)>
	Public Property nombre As String

	Public Property id As Integer?

	Public Property identidad As Integer?

	Public Property tipo As Integer?

	Public Property expires As Date?

	Public Property activo As Boolean?

	Public Property email As String

	Public Property asignada As Boolean?

	Public Property insession As Boolean?

	Public Property lastlog As Date?

	Public Property notas As String

	Public Property void As Boolean?

	<StringLength(10)>
	Public Property updaterec As String

	Public Property imageId As Integer?

	<StringLength(50)>
	Public Property passphrase As String

	Public Property perfil As Integer?

	Public Property intentos As Integer?
End Class

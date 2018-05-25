Imports FactorEntidades
Imports System.ComponentModel.DataAnnotations

Namespace AdminModels
	Public Class ModeloUsuario
		Inherits usuarios

		Public Sub CargaControles()
			SucursalDropDown = New controles().CargaSucursales()
			PerfilesDropDown = New controles().CargaPerfiles()
		End Sub

		Public SucursalDropDown As List(Of SelectListItem)
		Public PerfilesDropDown As List(Of SelectListItem)

		<Required()> _
		<DataType(DataType.Password)> _
		<Display(Name:="Contraseña")> _
		Public Property Pass1 As String

		<Required()> _
		<DataType(DataType.Password)> _
		<Display(Name:="Vuelve a escribir la contraseña")> _
		Public Property Pass2 As String

	End Class
End Namespace


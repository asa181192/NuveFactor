Imports FactorEntidades

Public Class controles
	Inherits Controller

	Public Function CargaSucursales() As List(Of SelectListItem)
		Dim resultado
		Dim consulta = New FactorBAL.Manager()
		Dim sucursales = New List(Of SelectListItem)()
		Dim lista = New List(Of SucursalEntidad)

		resultado = consulta.ConsultaSucursal(lista)

		If resultado.Ok And resultado IsNot Nothing Then
			sucursales = lista.Select(Function(s) New SelectListItem With {.Value = s.sucursal1, .Text = s.nombre}).ToList()

		Else
			resultado.Mensaje = "Ocurrio un error al consultar la informacion"
		End If

		Return sucursales

	End Function
	Public Function CargaRegimen() As List(Of SelectListItem)

		Return New List(Of SelectListItem)({
							New SelectListItem() With {
											  .Value = 0,
											  .Text = "Tasa de IVA al 0%"
											  },
							New SelectListItem() With {
											  .Value = 1,
											  .Text = "Tasa de IVA al 11%"
											  },
							New SelectListItem() With {
											  .Value = 2,
											  .Text = "Tasa de IVA al 16%"
											  },
							New SelectListItem() With {
											  .Value = 3,
											  .Text = "Exento"
											}
										   }).ToList()
	End Function

End Class

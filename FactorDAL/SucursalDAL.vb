Imports FactorEntidades

Public Class SucursalDAL

#Region "Constructor"

#End Region

#Region "Metodos de Consulta"


	Public Function ConsultaSucursal(ByRef listaSucursal As List(Of SucursalEntidad)) As Result

		Dim respuesta = New Result(False)

		Using context As New FactorContext

			Try

				listaSucursal = (From p In context.sucursal Select New SucursalEntidad With {.nombre = p.nombre, .sucursal1 = p.sucursal1}).ToList()

				respuesta.Ok = True

			Catch e As Exception

				respuesta.Detalle = e.Message

			End Try

		End Using

		Return respuesta

	End Function
#End Region

#Region "Metodos transaccionales"

#End Region
End Class

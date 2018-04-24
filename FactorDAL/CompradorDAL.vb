Imports FactorEntidades
Imports System.Data.Entity

Public Class CompradorDAL

#Region "Constructor"

#End Region

#Region "Metodos de consulta"
	Public Function ConsultaCompradorDAL(sucursal As Int16, ByRef model As List(Of ProveedorEntidad)) As Result

		Dim respuesta = New Result(False)

		Using context As New FactorContext
			Try
				model = (From p In context.comprador Where (p.sucursal = sucursal Or 0 = sucursal) Select New ProveedorEntidad With {.deudor = p.deudor, .nombre = p.nombre.TrimEnd()}).ToList()
				respuesta.Ok = True
			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try

		End Using

		Return respuesta

	End Function

	Function ConsultaDetalleCompradorDAL(deudor As Int32, ByRef model As comprador) As Result

		Dim respuesta = New Result(False)
		Using context As New FactorContext

			Try
				model = (From p In context.comprador
						Where p.deudor = deudor).SingleOrDefault()

				If model IsNot Nothing Then
					respuesta.Ok = True
				End If

			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try

		End Using
		Return respuesta
	End Function
#End Region

#Region "Metodos Transaccionales"
	Public Function ActualizarComprador(model As comprador) As Result
		Dim respuesta = New Result(False)

		Using context As New FactorContext

			Try

				context.comprador.Attach(model)
				context.Entry(model).State = EntityState.Modified
				context.SaveChanges()

				respuesta.Ok = True


			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try

		End Using

		Return respuesta
	End Function

	Public Function AltaComprador(model As comprador) As Result

		Dim respuesta = New Result(False)

		Using context As New FactorContext

			Try
				context.comprador.Add(model)
				context.SaveChanges()
				respuesta.Ok = True
			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try

		End Using

		Return respuesta

	End Function
#End Region

End Class

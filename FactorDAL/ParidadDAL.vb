Imports System.Data.Entity.Infrastructure
Imports System.Data.SqlClient
Imports FactorEntidades

Public Class ParidadDAL

#Region "Constructor"

#End Region

#Region "Metodos de consulta"
	Public Function ConsultaParidadDAL(fechaMes As String, fechaAnio As String, ByRef model As List(Of ParidadEntidad)) As Result

		Dim respuesta = New Result(False)

		Using context As New FactorContext

			Try

				Dim values = (From p In context.paridad
						Where p.fecha.Value.Year = fechaAnio AndAlso p.fecha.Value.Month = fechaMes
						Select p).ToList()

				For Each item As paridad In values
					Dim p = New ParidadEntidad

					p.fecha = item.fecha.Value.ToShortDateString()
					p.paridad = item.paridad1
					p.udis = item.udis

					model.Add(p)
				Next

				respuesta.Ok = True
			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try

		End Using

		Return respuesta

	End Function

	Function ConsultaParidadDetalleDAL(fecha As String, ByRef model As paridad) As Result
		Dim respuesta = New Result(False)
		Using context As New FactorContext

			Try
				model = (From p In context.paridad
									Where p.fecha = fecha).SingleOrDefault()
				
				respuesta.Ok = True
			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try

		End Using
		Return respuesta
	End Function

#End Region

#Region "Metodos Transaccionales"

	Public Function AltaParidad(model As paridad) As Result

		Dim respuesta = New Result(False)

		Using context As New FactorContext

			Try

				context.paridad.Add(model)
				context.SaveChanges()
				respuesta.Ok = True

			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try

		End Using

		Return respuesta

	End Function

	Public Function ActualizarParidad(model As paridad) As Result
		Dim respuesta = New Result(False)

		Using context As New FactorContext

			Try
				Dim consulta = context.paridad.SingleOrDefault(Function(x) x.fecha = model.fecha)

				If consulta IsNot Nothing Then
					consulta.paridad1 = model.paridad1
					consulta.udis = model.udis
					respuesta.Ok = True

					context.SaveChanges()
				End If

			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try

		End Using

		Return respuesta
	End Function

	Public Function BorrarParidad(fecha As String) As Result
		Dim respuesta = New Result(False)

		Using context As New FactorContext

			Try
				Dim consulta = context.paridad.SingleOrDefault(Function(a) a.fecha = fecha)

				If consulta IsNot Nothing Then

					context.paridad.Remove(consulta)
					context.SaveChanges()

				End If

			Catch e As Exception
				respuesta.Detalle = "Ocurrio un problema al eliminar registro !!"
			End Try

		End Using

		Return respuesta
	End Function

#End Region

End Class

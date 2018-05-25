Imports FactorEntidades
Imports System.Data.Entity
Imports System.Data.SqlClient

Public Class ClienteDAL
#Region "Constructor"

#End Region

#Region "Metodos de consulta"
	Function ConsultaClienteDAL(ByRef model As List(Of ClienteEntidad)) As Result

		Dim respuesta = New Result(False)

		Using context As New FactorContext
			Try
				model = (From p In context.clientes Select New ClienteEntidad With {.cliente = p.cliente, .nombre = p.nombre.TrimEnd(), .rfc = p.rfc}).ToList()
				respuesta.Ok = True
			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try
		End Using

		Return respuesta

	End Function

	Function ConsultaDetalleClienteDAL(cliente As Int32, ByRef model As clientes) As Result

		Dim respuesta = New Result(False)
		Using context As New FactorContext

			Try
				model = (From p In context.clientes
						Where p.cliente = cliente).SingleOrDefault()

				If model IsNot Nothing Then
					respuesta.Ok = True
				End If

			Catch e As Exception
				respuesta.Detalle = e.Message
				respuesta.Id_Out = 1
			End Try

		End Using
		Return respuesta
	End Function

	Function BusquedaGlobalDAL(BusquedaTxt As String, ByRef cliente As List(Of ClienteEntidad),
							   ByRef proveedor As List(Of ProveedorEntidad),
							   ByRef comprador As List(Of ProveedorEntidad),
							   ByRef promotor As List(Of PromotorEntidad)) As Result

		Dim respuesta = New Result(False)
		Using context As New FactorContext

			Try

				Dim parameters = New List(Of SqlParameter)
				parameters.Add(New SqlParameter("@Busqueda", BusquedaTxt))
				parameters.Add(New SqlParameter("@Tipo", 1))

				cliente = context.Database.SqlQuery(Of ClienteEntidad)("Exec SP_BusquedaGlobal @Busqueda,@Tipo",
												   parameters.ToArray()).ToList()

				parameters.Clear()
				parameters.Add(New SqlParameter("@Busqueda", BusquedaTxt))
				parameters.Add(New SqlParameter("@Tipo", 2))

				proveedor = context.Database.SqlQuery(Of ProveedorEntidad)("Exec SP_BusquedaGlobal @Busqueda,@Tipo",
												   parameters.ToArray()).ToList()

				parameters.Clear()
				parameters.Add(New SqlParameter("@Busqueda", BusquedaTxt))
				parameters.Add(New SqlParameter("@Tipo", 3))

				comprador = context.Database.SqlQuery(Of ProveedorEntidad)("Exec SP_BusquedaGlobal @Busqueda,@Tipo",
												   parameters.ToArray()).ToList()

				parameters.Clear()
				parameters.Add(New SqlParameter("@Busqueda", BusquedaTxt))
				parameters.Add(New SqlParameter("@Tipo", 4))

				promotor = context.Database.SqlQuery(Of PromotorEntidad)("Exec SP_BusquedaGlobal @Busqueda,@Tipo",
												   parameters.ToArray()).ToList()

				If cliente IsNot Nothing And proveedor IsNot Nothing And comprador IsNot Nothing And promotor IsNot Nothing Then
					respuesta.Ok = True
				End If

			Catch e As Exception
				respuesta.Detalle = e.Message
				respuesta.Id_Out = 1
			End Try

		End Using
		Return respuesta
	End Function

#End Region

#Region "Metodos Transaccionales"
	Public Function ActualizarCliente(model As clientes) As Result
		Dim respuesta = New Result(False)

		Using context As New FactorContext

			Try

				context.clientes.Attach(model)
				context.Entry(model).State = EntityState.Modified
				context.SaveChanges()

				respuesta.Ok = True


			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try

		End Using

		Return respuesta
	End Function

	Public Function AltaCliente(model As clientes) As Result

		Dim respuesta = New Result(False)

		Using context As New FactorContext

			Try
				context.clientes.Add(model)
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

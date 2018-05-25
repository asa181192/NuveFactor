Imports FactorEntidades
Imports System.Data.Entity

Public Class UsuarioDAL

#Region "Constructor"

#End Region

#Region "Metodos de consulta"
	Function ValidarUsuario(ByRef model As UsuarioConsulta, userid As String, password As Integer) As Result

		Dim respuesta = New Result(False)
		Using context As New FactorContext
			Try
				model = (From u In context.usuarios
						Join s In context.sucursal
						On u.sucursal Equals s.sucursal1
						Join p In context.perfil
						On u.perfil Equals p.perfil1
						Where u.userid = userid AndAlso u.password = password
						Select New UsuarioConsulta With {
						.user = u,
						.sucursal = s,
						.perfil = p}).SingleOrDefault()

				respuesta.Ok = True
			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try
		End Using

		Return respuesta

	End Function

	Public Function ConsultaUsuarioDAL(ByRef model As List(Of UsuarioEntidad)) As Result

		Dim respuesta = New Result(False)

		Using context As New FactorContext
			Try
				model = (From p In context.usuarios
							Select New UsuarioEntidad With {.id = p.id, .nombre = p.nombre.TrimEnd(), .puesto = p.puesto, .activo = If(p.activo = True, "SI", "NO"), .userid = p.userid}).ToList()
				respuesta.Ok = True
			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try

		End Using

		Return respuesta

	End Function

	Function ConsultaDetalleUsuarioDAL(id As Int32, ByRef model As usuarios) As Result
		Dim respuesta = New Result(False)
		Using context As New FactorContext
			Try
				model = (From p In context.usuarios
						Where p.id = id).SingleOrDefault()
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
#End Region

#Region "Metodos Transaccionales"
	Public Function ActualizarUsuario(model As usuarios) As Result
		Dim respuesta = New Result(False)
		Using context As New FactorContext
			Try
				context.usuarios.Attach(model)
				context.Entry(model).State = EntityState.Modified
				If model.password.Equals(Nothing) Then
					context.Entry(model).Property(Function(x) x.password).IsModified = False
				End If
				context.Entry(model).Property(Function(x) x.lista_pass).IsModified = False
				context.Entry(model).Property(Function(x) x.fec_pass).IsModified = False
				context.Entry(model).Property(Function(x) x.insession).IsModified = False
				context.Entry(model).Property(Function(x) x.initsession).IsModified = False
				context.Entry(model).Property(Function(x) x.mailext).IsModified = False
				context.Entry(model).Property(Function(x) x.agree).IsModified = False
				context.Entry(model).Property(Function(x) x.void).IsModified = False
				context.SaveChanges()
				respuesta.Ok = True
			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try

		End Using

		Return respuesta
	End Function

	Public Function AltaUsuario(model As usuarios) As Result
		Dim respuesta = New Result(False)
		Using context As New FactorContext
			Try
				context.usuarios.Add(model)
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

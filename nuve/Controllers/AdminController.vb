Imports nuve.AdminModels
Imports FactorEntidades
Imports Nelibur.ObjectMapper
Imports FactorBAL

Namespace nuve
	Public Class AdminController
		Inherits System.Web.Mvc.Controller

#Region "VIEW"
#Region "Usuarios"
		<HttpGet>
		<CustomAuthorize>
		Function Usuarios() As ViewResult
			Dim model = New ModeloUsuario()
			Return View(model)
		End Function
#End Region

#Region "Menu"
		<CustomAuthorize>
				<HttpGet>
		Function Index() As ViewResult

			Dim model As New Helpers.Menu

			model.sMenu = "<div class=""BoxFlex"" id="""" >"
			model.sMenu &= "<div class=""BoxFlexShadow"">"
			model.sMenu &= "<label>Regresar</label>"
			model.sMenu &= "<a href=""../Home/Welcome""> <img src=""../Images/regresar_gris.png""/> </a>"
			model.sMenu &= "</div>"
			model.sMenu &= "</div>"

			model.sMenu &= "<div class=""BoxFlex"" id=""dvflexUsuarios"" >"
			model.sMenu &= "<div class=""BoxFlexShadow"">"
			model.sMenu &= "<p>Usuarios</p>"
			model.sMenu &= "</div>"
			model.sMenu &= "</div>"

			Return View(model)
		End Function
#End Region
#End Region

#Region "GET"
		<HttpGet>
		<CustomAuthorize>
		Public Function ObtenerListaUsuarios() As ActionResult

			Dim jresult
			Dim resultado
			Dim consulta = New FactorBAL.Manager()

			Dim listaUsusario = New List(Of UsuarioEntidad)

			resultado = consulta.ConsultaUsuariosBAL(listaUsusario)

			If resultado.Ok And resultado IsNot Nothing Then
				jresult = Json(New With {Key .Results = listaUsusario}, JsonRequestBehavior.AllowGet)
			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function

		<HttpGet>
		Public Function GuardarUsuario(id As Int32) As ActionResult

			Dim model = New ModeloUsuario()
			Dim consulta = New FactorBAL.Manager()
			Dim usuario = New usuarios
			Dim resultado = consulta.ConsultaDetalleUsuarioBAL(id, usuario)



			If resultado.Ok And resultado IsNot Nothing Then
				TinyMapper.Bind(Of clientes, ModeloUsuario)()	'Mapeo de propiedad para modelo.
				model = TinyMapper.Map(Of ModeloUsuario)(usuario)
				model.CargaControles()
				Return PartialView(model)
			Else
				If resultado.Id_Out = 1 Then
					Return PartialView("~/Views/Shared/_ErrorPopUp.vbhtml")
				Else
					model.CargaControles()
					Return PartialView(model)
				End If
			End If

		End Function

#End Region

#Region "POST"
		<HttpPost>
		Public Function GuardarUsuario(usuario As ModeloUsuario) As ActionResult

			Dim resultado
			Dim bs = New FactorBAL.Manager()

			TinyMapper.Bind(Of ModeloUsuario, usuarios)()	'Mapeo de propiedades Modelo a DTO's
			Dim model = TinyMapper.Map(Of usuarios)(usuario)
			If Not (usuario.Pass2 = Nothing) Then
				model.password = New Utility().Encripta(usuario.Pass2, Enumerador.eTipoEncriptacion.eTipoPassword)
			End If

			If usuario.id > 0 Then
				resultado = bs.ActualizarUsuario(model)

				If resultado.Ok And resultado IsNot Nothing Then
					resultado.Mensaje = "Registro Actualizado"
				Else
					resultado.Mensaje = "Ocurrio un error al tratar de actualizar el registro!! "
				End If

			Else

				resultado = bs.AltaUsuario(model)

				If resultado.Ok And resultado IsNot Nothing Then
					resultado.Mensaje = "Registro Guardado"
				Else
					resultado.Mensaje = "Ocurrio un error al tratar de guardar el registro!! "
				End If

			End If
			Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje})
		End Function
#End Region

	End Class
End Namespace
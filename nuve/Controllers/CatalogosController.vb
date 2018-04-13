
Imports System.ComponentModel.DataAnnotations
Imports AutoMapper
Imports FactorEntidades
Imports nuve.Models

Namespace nuve
	Public Class CatalogosController
		Inherits BaseController


#Region "Views"	'*****VIEW*****

#Region "Paridad Cambiaria"

		<HttpGet>
		Function paridadCambiaria() As ViewResult

			Dim model = New ModeloPar()
			Return View(model)
		End Function

#End Region

#Region "Proveedores"
		<HttpGet>
		Function Proveedores() As ViewResult

			Dim model = New ModeloProveedor()

			Return View(model)
		End Function

#End Region

#Region "Menu"

		<CustomAuthorize> _
	  <HttpGet>
  Function Index() As ActionResult

			Dim model As New Helpers.Menu


			model.sMenu = "<div class=""BoxFlex"" id="""" >"
			model.sMenu &= "<div class=""BoxFlexShadow"">"
			model.sMenu &= "<label>Regresar</label>"
			model.sMenu &= "<a href=""/Home/Welcome""> <img src=""/Images/regresar_gris.png""/> </a>"
			model.sMenu &= "</div>"
			model.sMenu &= "</div>"

			model.sMenu &= "<div class=""BoxFlex"" id="""" >"
			model.sMenu &= "<div class=""BoxFlexShadow"">"
			model.sMenu &= "<p>Indicadores Financieros</p>"
			model.sMenu &= "</div>"
			model.sMenu &= "</div>"

			model.sMenu &= "<div class=""BoxFlex"" id=""dvflexParidad"" >"
			model.sMenu &= "<div class=""BoxFlexShadow"">"
			model.sMenu &= "<p>Paridad Cambiaria</p>"
			model.sMenu &= "</div>"
			model.sMenu &= "</div>"

			model.sMenu &= "<div class=""BoxFlex"" id="""" >"
			model.sMenu &= "<div class=""BoxFlexShadow"">"
			model.sMenu &= "<p>Sucursales</p>"
			model.sMenu &= "</div>"
			model.sMenu &= "</div>"

			model.sMenu &= "<div class=""BoxFlex"" id="""" >"
			model.sMenu &= "<div class=""BoxFlexShadow"">"
			model.sMenu &= "<p>Codigo de Garantia</p>"
			model.sMenu &= "</div>"
			model.sMenu &= "</div>"

			model.sMenu &= "<div class=""BoxFlex"" id="""" >"
			model.sMenu &= "<div class=""BoxFlexShadow"">"
			model.sMenu &= "<p>Tipos de Garantia</p>"
			model.sMenu &= "</div>"
			model.sMenu &= "</div>"

			model.sMenu &= "<div class=""BoxFlex"" id="""" >"
			model.sMenu &= "<div class=""BoxFlexShadow"">"
			model.sMenu &= "<p>Clientes</p>"
			model.sMenu &= "</div>"
			model.sMenu &= "</div>"

			model.sMenu &= "<div class=""BoxFlex"" id="""" >"
			model.sMenu &= "<div class=""BoxFlexShadow"">"
			model.sMenu &= "<p>Compradores</p>"
			model.sMenu &= "</div>"
			model.sMenu &= "</div>"

			model.sMenu &= "<div class=""BoxFlex"" id=""dvflexProveedores"" >"
			model.sMenu &= "<div class=""BoxFlexShadow"">"
			model.sMenu &= "<p>Proveedores</p>"
			model.sMenu &= "</div>"
			model.sMenu &= "</div>"

			Return View(model)
		End Function

#End Region

#End Region

#Region "Get" '*****GET*****

#Region "Paridad Cambiaria"

		'Obtiene el total de registros
		<HttpGet>
		Public Function obtenerListaParidad(fechaMes As String, fechaAnio As String) As ActionResult


			Dim jresult
			Dim resultado
			Dim consulta = New FactorBAL.Manager()

			Dim listaPardiad = New List(Of ParidadEntidad)

			resultado = consulta.ConsultaParidadBAL(fechaMes, fechaAnio, listaPardiad)

			If resultado.Ok And resultado IsNot Nothing Then
				jresult = Json(New With {Key .Results = listaPardiad}, JsonRequestBehavior.AllowGet)
			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function

		'Detalle de la paridad '
		<HttpGet>
		Public Function GuardarParidad(fecha As String) As ActionResult

			Dim model = New ModeloPar
			Dim consulta = New FactorBAL.Manager()
			Dim paridad = New FactorEntidades.ParidadEntidad()

			If fecha IsNot Nothing Then
				Dim resultado = consulta.ConsultaParidadDetalleBAL(fecha, paridad)

				If resultado.Ok And resultado IsNot Nothing Then
					model.fecha = paridad.fecha
					model.paridad = paridad.paridad
					model.udis = paridad.udis
				End If


			End If

			Return PartialView(model)
		End Function

#End Region

#Region "Proveedores"

		<HttpGet()>
		Public Function ObtenerListaProveedores() As ActionResult

			Dim jresult = New JsonResult()
			Dim resultado
			Dim consulta = New FactorBAL.Manager()

			Dim listaProveedor = New List(Of ProveedorEntidad)

			resultado = consulta.ConsultaProveedorBAL(listaProveedor)

			If resultado.Ok And resultado IsNot Nothing Then
				jresult = Json(New With {Key .Results = listaProveedor}, JsonRequestBehavior.AllowGet)
				jresult.MaxJsonLength = 500000000
			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function

		<HttpGet>
		Public Function GuardarProveedor(deudor As Int16) As ActionResult

			Dim model = New ModeloProveedor()
			Dim consulta = New FactorBAL.Manager()
			Dim proveedor = New ProveedorEntidad

			
			If deudor > 0 Then
				'Dim resultado = consulta.ConsultaDetalleProveedorBAL(deudor, proveedor)

				'If resultado.Ok And resultado IsNot Nothing Then
				'	model.fecha = paridad.fecha
				'	model.paridad = paridad.paridad
				'	model.udis = paridad.udis
				'End If


			End If

			Return PartialView(model)
		End Function

#End Region

#End Region

#Region "Post"	'*****POST*****

#Region "Paridad Cambiaria"
		'Actualiza Parida'
		<HttpPost>
		Public Function GuardarParidad(modelP As ModeloPar) As ActionResult

			Dim resultado
			Dim bs = New FactorBAL.Manager()


			Dim model = New FactorEntidades.paridad() With {.fecha = modelP.fecha,
					.paridad1 = modelP.paridad,
					.udis = modelP.udis, .void = modelP.void}

			If Boolean.Parse(modelP.add) Then

				resultado = bs.AltaParidad(model)

				If resultado.Ok And resultado IsNot Nothing Then
					resultado.Mensaje = "Registro Guardado"
				Else
					resultado.Mensaje = "Ocurrio un error al tratar de guardar el registro!! "
				End If

			Else

				resultado = bs.ActualizarParidad(model)


				If resultado.Ok And resultado IsNot Nothing Then
					resultado.Mensaje = "Registro Actualizado"
				Else
					resultado.Mensaje = "Ocurrio un error al tratar de actualizar el registro!! "
				End If

			End If
			Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje})

		End Function
#End Region

#Region "Proveedor"
		'<HttpPost>
		'Public Function GuardarProveedor(modelProveedor As ModeloProveedor) As ActionResult

		'	Dim resultado
		'	Dim bs = New FactorBAL.Manager()

		'	Dim model = New proveedor()

		'	If Boolean.Parse(modelP.add) Then

		'		resultado = bs.AltaParidad(model)

		'		If resultado.Ok And resultado IsNot Nothing Then
		'			resultado.Mensaje = "Registro Guardado"
		'		Else
		'			resultado.Mensaje = "Ocurrio un error al tratar de guardar el registro!! "
		'		End If

		'	Else

		'		resultado = bs.ActualizarParidad(model)


		'		If resultado.Ok And resultado IsNot Nothing Then
		'			resultado.Mensaje = "Registro Actualizado"
		'		Else
		'			resultado.Mensaje = "Ocurrio un error al tratar de actualizar el registro!! "
		'		End If

		'	End If
		'	Return Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje})

		'End Function
#End Region

#End Region

	End Class
End Namespace

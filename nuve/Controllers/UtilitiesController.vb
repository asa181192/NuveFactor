Imports FactorEntidades

Namespace nuve
	Public Class UtilitiesController
		Inherits BaseController


#Region "GET"
		<HttpGet>
		Public Function ObtenerSucursal() As ActionResult

			Dim jresult
			Dim resultado
			Dim consulta = New FactorBAL.Manager()

			Dim lista = New List(Of SucursalEntidad)

			resultado = consulta.ConsultaSucursal(lista)

			If resultado.Ok And resultado IsNot Nothing Then
				jresult = Json(New With {Key .Results = lista}, JsonRequestBehavior.AllowGet)
			Else
				resultado.Mensaje = "Ocurrio un error al consultar la informacion"
				jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
			End If

			Return jresult

		End Function

		

#End Region


	End Class
End Namespace
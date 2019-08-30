Namespace nuve
	<AllowAnonymous()>
	Public Class ErrorController
		Inherits System.Web.Mvc.Controller

		<HttpGet>
		Function AccesoDenegado() As ActionResult
			Return View("~/Views/Shared/_PermisoDenegado.vbhtml")
		End Function

	End Class
End Namespace
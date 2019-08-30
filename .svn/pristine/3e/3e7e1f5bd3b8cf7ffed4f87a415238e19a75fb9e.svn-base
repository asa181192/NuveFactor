Imports FactorEntidades
Imports FactorBAL
Imports Microsoft.Reporting.WebForms


<CustomAuthorize(Permisos.Acciones.AUTORIZACIONES)>
Public Class AutorizaController
  Inherits System.Web.Mvc.Controller

#Region "Views"
  <HttpGet>
  Public Function Autoriza() As ViewResult
    Return View()
  End Function

#End Region

#Region "Get"

  <HttpGet>
  Public Function obtenermovtos(fecha As String, movto As String) As ActionResult
    Dim jresult = New JsonResult()
    Dim response
    Dim consulta = New AutorizaBAL()

    Dim autorizaList = New List(Of AutorizaEntidad)

    response = consulta.ObtenermovtosBAL(fecha, movto, autorizaList)
    If response.Ok And response IsNot Nothing Then
      jresult = Json(New With {Key .Results = autorizaList}, JsonRequestBehavior.AllowGet)
    Else
      response.Mensaje = "Ocurrió un Error al consultar la información.(Controller)"
      jresult = Json(New With {Key .Mensaje = response.Mensaje + " " + response.Detalle}, JsonRequestBehavior.AllowGet)
    End If

    Return jresult
  End Function


#End Region

#Region "Post"


  Public Function Pagarmovtos(docs As List(Of AutorizaEntidad)) As ActionResult
    Dim resultado
    Dim JsonStr

    'Dim serializer = New JavaScriptSerializer()
    'serializer.MaxJsonLength = ConfigurationManager.AppSettings("maxJsonlLength")

    Dim bs = New FactorBAL.AutorizaBAL()
    resultado = bs.PagarmovtosBAL(docs)

    If resultado.Ok And resultado IsNot Nothing Then
      resultado.Mensaje = "Pagos realizados"
      FactorBAL.Utility.Monitor(Session("USERID"), "Genero pagos de Spei : " + docs(0).contrato.ToString())
      resultado.tipo = Enumerador.eTipoTransaccion.eAlta

      JsonStr = Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo, .color = "success"}, JsonRequestBehavior.AllowGet)
      JsonStr.MaxJsonLength = Integer.MaxValue

    Else
      resultado.Mensaje = String.Format("No es posible generar los pagos SPEI!! ", Environment.NewLine, resultado.Detalle)
      JsonStr = Json(New With {Key .Result = resultado.Ok, .Text = resultado.Mensaje, .Tipo = resultado.Tipo, .color = "warning"})
    End If
    Return JsonStr

  End Function


#End Region

End Class
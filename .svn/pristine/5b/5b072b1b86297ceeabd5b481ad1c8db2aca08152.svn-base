Imports FactorEntidades
Imports Nelibur.ObjectMapper
Imports nuve.Models
Imports Microsoft.Reporting.WebForms
Imports System.Web.Script.Serialization

Namespace nuve

  Public Class ConsolidacionesController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /Consolidaciones

#Region "Views"

    <HttpGet>
    Function bitacora() As ViewResult
      Dim model = New ModeloConsolida()
      Return View(model)
    End Function

#End Region


#Region "GET"

    <HttpGet()>
    Public Function Obtenermovtos(fecha As String) As ActionResult

      Dim jresult = New JsonResult()
      Dim resultado
      Dim consulta = New FactorBAL.ConsolidacionesBAL()
      Dim lista = New List(Of ConsolidacionesEntidad)

      resultado = consulta.ConsultaBitacoraBAL(fecha, lista)

      If resultado.Ok And resultado IsNot Nothing Then
        jresult = New CustomJsonResult With {
          .Data = New With {Key .Results = lista.ToList()},
          .JsonRequestBehavior = JsonRequestBehavior.AllowGet
        }
      Else
        resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        jresult = Json(New With {Key .Mensaje = "ERR!!" + resultado.Mensaje + "!!" + resultado.Detalle}, JsonRequestBehavior.AllowGet)
      End If

      Return jresult

    End Function


#End Region
  End Class

End Namespace
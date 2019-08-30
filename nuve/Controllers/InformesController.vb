﻿Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports FactorEntidades
Imports nuve.CustomValidations
Imports nuve.Models
Imports Microsoft.Reporting.WebForms
Imports System.Reflection
Imports System.Globalization
Imports Nelibur.ObjectMapper
Imports System.IO

Namespace nuve

  Public Class InformesController
    Inherits System.Web.Mvc.Controller

#Region "Views"

    Function Informes() As ActionResult
      Dim model = New ModeloInformes()
      Return View(model)
    End Function

    <HttpGet>
    Function Informecobros() As ViewResult
      Return View()
    End Function


#End Region


#Region "Reportes"

    Public Function Reportecobranza(fecha As String, contrato As Integer) As ActionResult

      Dim localReport = New Microsoft.Reporting.WebForms.LocalReport()

      Dim a = New Result(False)
      Dim resultado = New Result
      Dim bs = New FactorBAL.ReportesBAL()
      Dim cobros = New List(Of CobranzaEntidad)

      resultado = bs.ReportecobranzaBAL(fecha, contrato, cobros)
      localReport.ReportPath = Server.MapPath("~/Reports/Reportecobranza.rdlc")

      Dim reportDataSource = New ReportDataSource()
      reportDataSource.Name = "Informacobros"
      reportDataSource.Value = cobros

      localReport.DataSources.Clear()

      localReport.DataSources.Add(reportDataSource)

      If resultado.Ok And resultado IsNot Nothing Then

        Dim reportType As String = "PDF"
        Dim mimeType As String = ""
        Dim encoding As String = ""
        Dim fileNameExtension As String = ""

        Dim Waring() As Warning = Nothing   'Array
        Dim Streams() As String = Nothing   'Array 
        Dim renderedBytes() As Byte 'Array

        Dim list(0) As ReportParameter
        list(0) = New ReportParameter("Usuario", Session("USERID").ToString())

        localReport.SetParameters(list)
        renderedBytes = localReport.Render(reportType, Nothing, mimeType, encoding, fileNameExtension, Streams, Waring)
        If Request.Cookies("reporte") IsNot Nothing Then
          Request.Cookies("reporte").Value = "OK"
        End If
        Response.SetCookie(Request.Cookies("reporte"))
        Return File(renderedBytes, "pdf", "Informacioncobros.pdf")

      Else
        Return Content("<script language='javascript' type='text/javascript'>alert('Error al generar el PDF favor de volver a consultar !!\n\nClick Aceptar para volver'); window.location.href ='../Informes/Informescbros")
        '+ idcliente.ToString() + "&nombre=" + nombre + "';</script>")

      End If

    End Function

    Public Function Reporteaforo(fecha As String, contrato As Integer) As ActionResult

      Dim localReport = New Microsoft.Reporting.WebForms.LocalReport()

      Dim a = New Result(False)
      Dim resultado = New Result
      Dim bs = New FactorBAL.ReportesBAL()
      Dim cobros = New List(Of CobranzaEntidad)

      resultado = bs.ReporteaforoBAL(fecha, contrato, cobros)
      localReport.ReportPath = Server.MapPath("~/Reports/Reporteaforo.rdlc")

      Dim reportDataSource = New ReportDataSource()
      reportDataSource.Name = "Reporteaforo"
      reportDataSource.Value = cobros

      localReport.DataSources.Clear()

      localReport.DataSources.Add(reportDataSource)

      If resultado.Ok And resultado IsNot Nothing Then

        Dim reportType As String = "PDF"
        Dim mimeType As String = ""
        Dim encoding As String = ""
        Dim fileNameExtension As String = ""

        Dim Waring() As Warning = Nothing   'Array
        Dim Streams() As String = Nothing   'Array 
        Dim renderedBytes() As Byte 'Array

        Dim list(0) As ReportParameter
        list(0) = New ReportParameter("Usuario", Session("USERID").ToString())

        localReport.SetParameters(list)
        renderedBytes = localReport.Render(reportType, Nothing, mimeType, encoding, fileNameExtension, Streams, Waring)
        If Request.Cookies("reporte") IsNot Nothing Then
          Request.Cookies("reporte").Value = "OK"
        End If
        Response.SetCookie(Request.Cookies("reporte"))
        Return File(renderedBytes, "pdf", "Reporteaforo.pdf")

      Else
        Dim archivo As Byte() = Nothing
        Dim url = "\\192.168.121.237\Files\temp\"
        url = url + "Reporte.txt"
        Dim txt As FileStream = New FileStream(url, FileMode.Create)
        archivo = System.Text.Encoding.ASCII.GetBytes("NO SE ENCONTRO INFORMACION!!")
        txt.Write(archivo, 0, archivo.Length)
        txt.Close()

        If Request.Cookies("reporte") IsNot Nothing Then
          Request.Cookies("reporte").Value = "OK"
        End If
        Response.SetCookie(Request.Cookies("reporte"))
        Return File(archivo, "application/txt", "Reporte.txt")

      End If

    End Function


#End Region

#Region "Get"
    'Obtiene el total de registros
    <HttpGet>
    Public Function ObtenerListaReportes() As ActionResult

      Dim jresult
      Dim resultado
      Dim consulta = New FactorBAL.ReportesBAL()


      Dim listaReportes = New List(Of ReporteEntidad)
      resultado = consulta.ConsultaReportesBAL(listaReportes)

      If resultado.Ok And resultado IsNot Nothing Then

        jresult = New CustomJsonResult With {
          .Data = New With {Key .Results = listaReportes,
        .JsonRequestBehavior = JsonRequestBehavior.AllowGet}
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
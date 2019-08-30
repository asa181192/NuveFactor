Imports System.Data.Entity.Infrastructure
Imports System.Data.SqlClient
Imports FactorEntidades
Imports System.Data.Entity
Imports System.Transactions
Imports System.Text

Public Class AutorizaDAL

#Region "Consultas"

  Public Function ObtenermovtosDAL(fecha As Date, movto As Integer, ByRef model As List(Of AutorizaEntidad)) As Result
    Dim respuesta = New Result(False)

    Using context As New FactorContext
      Try

        Dim parameters = New List(Of SqlParameter)
        parameters.Add(New SqlParameter("@fecha", fecha))
        parameters.Add(New SqlParameter("@movto", movto))

        model = context.Database.SqlQuery(Of AutorizaEntidad)("Exec [dbo].[sp_autorizaciones] " +
                                          "@fecha,@movto", parameters.ToArray()).ToList()

        respuesta.Ok = True
      Catch e As Exception
        respuesta.Detalle = e.Message
      End Try
    End Using

    Return respuesta

  End Function

  Public Function PagarmovtosDAL(docs As List(Of AutorizaEntidad)) As Result
    Dim respuesta = New Result(False)
    
    Dim cadenaXml As New StringBuilder()
    Dim proceso As String

    Using context As New FactorContext
      Try

        If docs IsNot Nothing Then

          cadenaXml.Append("<root>")
          For Each item In docs

            cadenaXml.Append("<row>")
            cadenaXml.Append("<idrec>" & item.IdRec.ToString() & "</idrec>")
            cadenaXml.Append("<oper>" & item.oper.ToString() & "</oper>")
            cadenaXml.Append("</row>")

          Next
          cadenaXml.Append("</root>")

          Dim parameters = New List(Of SqlParameter)
          parameters.Add(New SqlParameter("@PagosXml", cadenaXml.ToString()))
          proceso = context.Database.SqlQuery(Of String)("Exec SP_AutorizaPagos @PagosXml",
                     parameters.ToArray()).SingleOrDefault()

          If proceso = "Proceso realizado con exito" Then
            respuesta.DetalleServicio = ""
            respuesta.Mensaje = proceso
          Else
            respuesta.Mensaje = proceso
          End If

          respuesta.Ok = True
        Else
          respuesta.Ok = False
          respuesta.Mensaje = "No se realizaron pagos"
        End If

      Catch e As Exception
        respuesta.Detalle = e.Message
      End Try

    End Using

    Return respuesta
  End Function


#End Region

End Class

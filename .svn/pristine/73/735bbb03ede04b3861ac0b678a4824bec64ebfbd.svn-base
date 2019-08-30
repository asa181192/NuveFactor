Imports FactorEntidades
Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Data.SqlClient


Public Class ConsolidacionesDAL

#Region "Metodos de consulta"

  Public Function ConsultaBitacoraDAL(fecha As Date, ByRef model As List(Of ConsolidacionesEntidad)) As Result

    Dim respuesta = New Result(False)

    Using context As New FactorContext
      Try

        Dim parameters = New List(Of SqlParameter)
        parameters.Add(New SqlParameter("@fecha", fecha))

        model = context.Database.SqlQuery(Of ConsolidacionesEntidad)("Exec [dbo].[sp_ConsultaConsolida]" + "@fecha", parameters.ToArray()).ToList()


        'model = (From a In context.consolida
        '         Where (DbFunctions.TruncateTime(a.fecha) = fecha)
        '         Order By a.idrec Ascending
        '         Select New ConsolidacionesEntidad With {.idrec = a.idrec, .fecha = a.fecha, .archivo = a.archivo, .resultado = a.resultado,
        '                                             .exito = a.exito}).ToList()


        If model IsNot Nothing Then
          respuesta.Ok = True
        End If


      Catch e As Exception
        respuesta.Detalle = e.Message
      End Try

    End Using

    Return respuesta

  End Function


#End Region

End Class

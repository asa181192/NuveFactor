Imports FactorDAL
Imports FactorEntidades


Public Class ConsolidacionesBAL

#Region "Consultas"

  Function ConsultaBitacoraBAL(fecha As Date, ByRef model As List(Of ConsolidacionesEntidad)) As Result

    Dim consulta = New FactorDAL.ConsolidacionesDAL()

    Return consulta.ConsultaBitacoraDAL(fecha, model)
  End Function



#End Region

End Class

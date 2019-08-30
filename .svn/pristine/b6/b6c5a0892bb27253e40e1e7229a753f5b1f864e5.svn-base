Imports FactorDAL
Imports FactorEntidades

Public Class AutorizaBAL

#Region "Consultas"


  Function ObtenermovtosBAL(fecha As Date, movto As Integer, ByRef model As List(Of AutorizaEntidad)) As Result

    Dim consulta = New FactorDAL.AutorizaDAL()

    Return consulta.ObtenermovtosDAL(fecha, movto, model)
  End Function

  Function PagarmovtosBAL(docs As List(Of AutorizaEntidad)) As Result

    Dim consulta = New FactorDAL.AutorizaDAL()

    Return consulta.PagarmovtosDAL(docs)
  End Function


#End Region

End Class

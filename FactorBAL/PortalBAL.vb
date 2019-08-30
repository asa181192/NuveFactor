Imports FactorEntidades
Imports FactorDAL

Public Class PortalBAL
#Region "Parametros"
	Function ConsultaParametrosBAL(ByRef model As webcontrol) As Result

		Dim par = New ParametrosDAL()
		Return par.ConsultaParametrosDAL(model)

	End Function
	Function ActualizarParametrosBAL(ByRef model As webcontrol) As Result

		Dim par = New ParametrosDAL()
		Return par.ActualizarParametrosDAL(model)

	End Function
#End Region

#Region "Operaciones"
	Function ConsultaOperacionesBAL(fecha As Date, ByRef model As List(Of OperacionesEntidad)) As Result

		Dim par = New OperacionesDAL()
		Return par.ConsultaOperacionesDAL(fecha, model)

	End Function

	Function ReporteDetalleOPeracionBAL(folio As Integer, ByRef model As ReporteOperacionDetalle) As Result

		Dim par = New OperacionesDAL()
		Return par.ReporteDetalleOPeracionDAL(folio, model)

	End Function
#End Region

End Class

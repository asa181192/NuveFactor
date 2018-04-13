Imports FactorDAL
Imports FactorEntidades

Public Class Manager

#Region "Paridad"

	Function ConsultaParidadBAL(fechaMes As String, fechaAnio As String, ByRef model As List(Of ParidadEntidad)) As Result

		Dim paridad = New ParidadDAL()
		Return paridad.ConsultaParidadDAL(fechaMes, fechaAnio, model)

	End Function

	Function ConsultaParidadDetalleBAL(fecha As String, ByRef model As ParidadEntidad) As Result

		Dim paridad = New ParidadDAL()
		Return paridad.ConsultaParidadDetalleDAL(fecha, model)
	

	End Function

	Function AltaParidad(model As paridad) As Result
		Dim paridad = New ParidadDAL()
		
		Return paridad.AltaParidad(model)


	End Function

	Function ActualizarParidad(model As paridad) As Result
		Dim paridad = New ParidadDAL()
		Return paridad.ActualizarParidad(model)


	End Function

	Function BorrarParidad(fecha As String)
		Dim paridad = New ParidadDAL()

		Try
			Return paridad.BorrarParidad(fecha)
		Catch ex As Exception
			Throw ex
		End Try
	End Function

#End Region

#Region "Proveedores"
	Function ConsultaProveedorBAL(ByRef model As List(Of ProveedorEntidad)) As Result

		Dim proveedor = New ProveedorDAL()
		Return proveedor.ConsultaProveedorDAL(model)

	End Function
#End Region

End Class

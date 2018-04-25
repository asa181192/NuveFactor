Imports FactorDAL
Imports FactorEntidades

Public Class Manager

#Region "Paridad"

	Function ConsultaParidadBAL(fechaMes As String, fechaAnio As String, ByRef model As List(Of ParidadEntidad)) As Result

		Dim paridad = New ParidadDAL()
		Return paridad.ConsultaParidadDAL(fechaMes, fechaAnio, model)

	End Function

	Function ConsultaParidadDetalleBAL(fecha As String, ByRef model As paridad) As Result

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
	Function ConsultaProveedorBAL(sucursal As Int16, ByRef model As List(Of ProveedorEntidad)) As Result

		Dim proveedor = New ProveedorDAL()
		Return proveedor.ConsultaProveedorDAL(sucursal, model)

	End Function

	Function AltaProveedor(model As proveedor) As Result
		Dim proveedor = New ProveedorDAL()

		Return proveedor.AltaProveedor(model)

	End Function

	Function ConsultaDetalleProveedorBAL(deudor As Int32, ByRef model As proveedor) As Result

		Dim proveedor = New ProveedorDAL()
		Return proveedor.ConsultaDetalleProveedorDAL(deudor, model)

	End Function

	Function ActualizarProveedor(model As proveedor) As Result
		Dim proveedor = New ProveedorDAL()
		Return proveedor.ActualizarProveedor(model)


	End Function

#End Region

#Region "Comprador"

	Function ConsultaCompradorBAL(sucursal As Int16, ByRef model As List(Of ProveedorEntidad)) As Result

		Dim comprador = New CompradorDAL()
		Return comprador.ConsultaCompradorDAL(sucursal, model)

	End Function

	Function ConsultaDetalleCompradorBAL(deudor As Int32, ByRef model As comprador) As Result

		Dim comprador = New CompradorDAL()
		Return comprador.ConsultaDetalleCompradorDAL(deudor, model)

	End Function

	Function ActualizarComprador(model As comprador) As Result
		Dim comprador = New CompradorDAL()
		Return comprador.ActualizarComprador(model)
	End Function

	Function Altacomprador(model As comprador) As Result
		Dim comprador = New CompradorDAL()

		Return comprador.AltaComprador(model)

	End Function

#End Region

#Region "Utilities Dropdown"

	Function ConsultaSucursal(ByRef listaSucursal As List(Of SucursalEntidad)) As Result

		Dim sucursal = New SucursalDAL()
		Return sucursal.ConsultaSucursal(listaSucursal)

	End Function

#End Region

End Class

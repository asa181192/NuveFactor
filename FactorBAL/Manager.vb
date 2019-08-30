﻿Imports FactorDAL
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

	Function ActualizarParidad(model As paridad) As Result
		Dim paridad = New ParidadDAL()
		Return paridad.ActualizarParidad(model)
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

	Function ActualizarProveedor(userid As String, model As proveedor) As Result
		Dim proveedor = New ProveedorDAL()
		Return proveedor.ActualizarProveedor(userid, model)
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

#Region "Indicadores Financieros"

	'Listado
	Function ConsultaIndicadoresBAL(fechaMes As String, fechaAnio As String, ByRef model As List(Of FinancieroEntidad)) As Result
		Dim indicador = New IndicadoresDAL()
		Return indicador.ConsultaIndicadorDAL(fechaMes, fechaAnio, model)
	End Function
	'Detalle
	Function ConsultaIndicadorDetalleBAL(fecha As String, ByRef model As indicadores) As Result
		Dim indicador = New IndicadoresDAL()
		Return indicador.ConsultaIndicadorDetalleDAL(fecha, model)
	End Function
	'Alta
	'Function AltaIndicador(model As indicadores) As Result
	'	Dim indicador = New IndicadoresDAL()
	'	Return indicador.AltaIndicador(model)
	'End Function
	'Actualizacion 
	Function ActualizarIndicador(model As indicadores) As Result
		Dim indicador = New IndicadoresDAL()
		Return indicador.ActualizarIndicador(model)
	End Function

#End Region

#Region "Sucursal"
	Function ConsultaSucursalBAL(ByRef model As List(Of SucursalEntidad)) As Result

		Dim sucursal = New SucursalDAL()
		Return sucursal.ConsultaSucursal(model)

	End Function

	Function ConsultaDetalleSucursalBAL(suc As Int32, ByRef model As sucursal) As Result

		Dim sucursal = New SucursalDAL()
		Return sucursal.ConsultaDetalleSucursalDAL(suc, model)

	End Function

	Function ActualizarSucursal(model As sucursal) As Result
		Dim sucursal = New SucursalDAL()
		Return sucursal.ActualizarSucursal(model)
	End Function

	Function AltaSucursal(model As sucursal) As Result
		Dim sucursal = New SucursalDAL()
		Return sucursal.AltaSucursal(model)
	End Function

#End Region

#Region "Codigos de Garantia"
	Function ConsultaCodigoGarantiaBAL(ByRef model As List(Of CodigoGarantiaEntidad)) As Result

		Dim codigo = New CodigoGarantiaDAL()
		Return codigo.ConsultaCodigoGarantiaDAL(model)

	End Function

	Function ConsultaDetalleCodigoGarantiaBAL(codigoid As Int32, ByRef model As codigogarantia) As Result

		Dim codigo = New CodigoGarantiaDAL()
		Return codigo.ConsultaDetalleCodigoGarantiaDAL(codigoid, model)

	End Function

	Function ActualizarCodigoGarantia(model As codigogarantia) As Result
		Dim codigo = New CodigoGarantiaDAL()
		Return codigo.ActualizarCodigoGarantia(model)
	End Function

	Function AltaCodigoGarantia(model As codigogarantia) As Result
		Dim codigo = New CodigoGarantiaDAL()
		Return codigo.AltaCodigoGarantia(model)
	End Function
#End Region

#Region "Codigos de Garantia"
	Function ConsultaTipoGarantiaBAL(ByRef model As List(Of TipoGarantiaEntidad)) As Result

		Dim codigo = New TipoGarantiaDAL()
		Return codigo.ConsultaTipoGarantiaDAL(model)

	End Function

	Function ConsultaDetalleTipoGarantiaBAL(tipoid As Int32, ByRef model As tipogarantia) As Result

		Dim codigo = New TipoGarantiaDAL()
		Return codigo.ConsultaDetalleTipoGarantiaDAL(tipoid, model)

	End Function

	Function ActualizarTipoGarantia(model As tipogarantia) As Result
		Dim codigo = New TipoGarantiaDAL()
		Return codigo.ActualizarTipoGarantia(model)
	End Function

	Function AltaTipoGarantia(model As tipogarantia) As Result
		Dim codigo = New TipoGarantiaDAL()
		Return codigo.AltaTipoGarantia(model)
	End Function
#End Region

#Region "Clientes"
	Function ConsultaClienteBAL(ByRef model As List(Of ClienteEntidad)) As Result

		Dim cliente = New ClienteDAL()
		Return cliente.ConsultaClienteDAL(model)

	End Function

	Function ConsultaDetalleClienteBAL(clienteid As Int32, ByRef model As clientes) As Result
		Dim cliente = New ClienteDAL()
		Return cliente.ConsultaDetalleClienteDAL(clienteid, model)
	End Function

	Function ActualizarCliente(model As clientes) As Result
		Dim cliente = New ClienteDAL()
		If model.pfisica Then
			model.nombre = String.Concat(model.n, " ", model.p, " ", model.m)
		End If
		Return cliente.ActualizarCliente(model)
	End Function

	Function AltaCliente(model As clientes) As Result
		Dim cliente = New ClienteDAL()
		If model.pfisica Then
			model.nombre = String.Concat(model.n, " ", model.p, " ", model.m)
		End If
		Return cliente.AltaCliente(model)
	End Function
#End Region

#Region "Promotor"

	Function ConsultaPromotorBAL(promprod As Boolean, ByRef model As List(Of DropDownEntidad)) As Result

		Dim dropdown = New DropDownDAL()
		Return dropdown.ConsultaPromotorDAL(promprod, model)

	End Function

	Function ConsultaListaPromotorBAL(sucursal As Integer, ByRef model As List(Of PromotorEntidad)) As Result

		Dim promotor = New PromotorDAL()
		Return promotor.ConsultaPromotorDAL(sucursal, model)

	End Function

	Function ConsultaDetallePromotorBAL(clave As Int32, ByRef model As promotor) As Result

		Dim promotor = New PromotorDAL()
		Return promotor.ConsultaDetallePromotorDAL(clave, model)

	End Function

	Function ActualizarPromotor(model As promotor) As Result
		Dim promotor = New PromotorDAL()
		Return promotor.ActualizarPromotor(model)
	End Function

	Function AltaPromotor(model As promotor) As Result
		Dim promotor = New PromotorDAL()
		Return promotor.AltaPromotor(model)
	End Function

#End Region

#Region "grupos"
	Function ConsultaGrupoEmpresarialBAL(ByRef model As List(Of DropDownEntidad)) As Result

		Dim grupo = New DropDownDAL()
		Return grupo.ConsultaGrupoEmpresarialDAL(model)

	End Function
#End Region

#Region "Ciudades"
	Function ConsultaCiudadesBAL(ByRef model As List(Of DropDownEntidad)) As Result

		Dim dropdown = New DropDownDAL()
		Return dropdown.ConsultaCiudadesDAL(model)

	End Function
#End Region

#Region "Estados"
	Function ConsultaEstadosBAL(ByRef model As List(Of DropDownEntidad)) As Result

		Dim dropdown = New DropDownDAL()
		Return dropdown.ConsultaEstadosDAL(model)

	End Function
#End Region

#Region "Seguridad"
	Function ValidarUsuario(ByRef model As UsuarioConsulta, userid As String, password As String) As Result

		Dim user = New UsuarioDAL()
		''---IMPORTANTE--- ESTA LOGICA SOLO ES PARA AMBIENTE DE DESARROLLO ELIMINAR UNA VEZ EN PRODUCCION '
		If password Is Nothing Then
			password = ""
		End If
		'--------------------------------------------------------------------------------------------------
		Dim pass = New Utility().Encripta(password.Trim().ToUpper(), Enumerador.eTipoEncriptacion.eTipoPassword)
		Return user.ValidarUsuario(model, userid, pass)

	End Function

#End Region

#Region "BusquedaGlobal"
	Function BusquedaGlobalBAL(BusquedaTxt As String,
							   ByRef cliente As List(Of ClienteEntidad),
							   ByRef proveedor As List(Of ProveedorEntidad),
							   ByRef comprador As List(Of ProveedorEntidad),
							   ByRef promotor As List(Of PromotorEntidad)) As Result
		Dim busqueda = New ClienteDAL()
		Return busqueda.BusquedaGlobalDAL(BusquedaTxt, cliente, proveedor, comprador, promotor)
	End Function
#End Region

#Region "Usuarios"
	Function ConsultaUsuariosBAL(ByRef model As List(Of UsuarioEntidad)) As Result
		Dim cliente = New UsuarioDAL()
		Return cliente.ConsultaUsuarioDAL(model)
	End Function

	Function ConsultaDetalleUsuarioBAL(id As Int32, ByRef model As usuarios) As Result
		Dim usuario = New UsuarioDAL()
		Return usuario.ConsultaDetalleUsuarioDAL(id, model)
	End Function

	Function ActualizarUsuario(model As usuarios) As Result
		Dim usuario = New UsuarioDAL()
		Return usuario.ActualizarUsuario(model)
	End Function

	Function AltaUsuario(model As usuarios) As Result
		Dim usuario = New UsuarioDAL()
		Return usuario.AltaUsuario(model)
	End Function
#End Region

#Region "Perfil"
	Function ConsultaPerfilBAL(ByRef model As List(Of DropDownEntidad)) As Result
		Dim perfil = New DropDownDAL()
		Return perfil.ConsultaPerfilesDAL(model)
	End Function
#End Region

#Region "Control Riesgo"

	Function ConsultaControlRiesgoBAL(ClienteId As Integer, ByRef model As ControlRiesgo_Cliente) As Result
		Dim proc = New Procesos()
		Return proc.ConsultaControlRiesgoDAL(ClienteId, model)
	End Function

	Function ActualizarControlRiesgoBAL(ByRef model As clientes) As Result
		Dim proc = New Procesos()
		Return proc.ActualizarControlRiesgoDAL(model)
	End Function

	Function ActualizarAsociarLineasBAL(ByRef model As ControlRiesgo) As Result
		Dim proc = New Procesos()
		Return proc.ActualizarAsociarLineasDAL(model)
	End Function

	Function consultaLineasBAL(clienteId As Integer, ByRef entidad As ControlRiesgo) As Result
		Dim proc = New Procesos()
		entidad.idmultiple = Guid.NewGuid().ToString("N").Substring(0, 9)
		Return proc.consultaLineasDAL(clienteId, entidad)
	End Function

	Function DesasociarLineasBAL(clienteId As Integer) As Result
		Dim proc = New Procesos()
		Return proc.DesasociarLineasDAL(clienteId)
	End Function

	Function ConsultaGarantiaLiquidaBAL(idRec As String, ByRef entidad As CtrlRiesgo) As Result
		Dim proc = New Procesos()
		Return proc.ConsultaGarantiaLiquidaDAL(idRec, entidad)
	End Function

	Function ActualizarGarantiaLiquidaBAL(ByRef model As linea) As Result
		Dim proc = New Procesos()
		Return proc.ActualizarGarantiaLiquidaDAL(model)
	End Function

	Function CancelarLineaBAL(idRec As String) As Result
		Dim proc = New Procesos()
		Return proc.CancelarLineaDAL(idRec)
	End Function

	Function GuardarClienteLinea(ClienteId As Integer, ClienteT24 As Decimal) As Result
		Dim proc = New Procesos()
		Return proc.GuardarClienteLinea(ClienteId, ClienteT24)
	End Function

	Function ReporteCtrlRiesgo(ClienteId As Integer, model As ControlRiesgo_Cliente) As Result
		Dim proc = New Procesos()
		Return proc.ReporteCtrlRiesgo(ClienteId, model)
	End Function

#End Region

#Region "Giros"

	Function ConsultaGirosBAL(ByRef model As List(Of DropDownEntidad)) As Result

		Dim giro = New DropDownDAL()
		Return giro.ConsultaGirosDAL(model)

	End Function

#End Region

#Region "Apoderados"
	Function ConsultaApoderadoBAL(cliente As Integer, ByRef model As List(Of ApoderadoEntidad)) As Result

		Dim apoderado = New ApoderadoDAL()
		Return apoderado.ConsultaApoderadoDAL(cliente, model)

	End Function

	Function ConsultaDetalleApoderadoBAL(clienteid As Int32, ByRef model As apoderados) As Result
		Dim apoderado = New ApoderadoDAL()
		Return apoderado.ConsultaDetalleApoderadoDAL(clienteid, model)
	End Function

	Function ActualizarApoderadoBAL(model As apoderados) As Result
		Dim apoderado = New ApoderadoDAL()

		If model.pfisica Then
			model.apoderado = String.Concat(model.n, " ", model.p, " ", model.m)
		End If

		Return apoderado.ActualizarApoderadoDAL(model)
	End Function

	Function AltaApoderadoBAL(model As apoderados) As Result
		Dim apoderado = New ApoderadoDAL()

		'False es Persona Fisica
		If model.pfisica Then
			model.apoderado = String.Concat(model.n, " ", model.p, " ", model.m)
		End If

		Return apoderado.AltaApoderadoDAL(model)
	End Function

	Function CancelarApoderadoBAL(id As Integer) As Result
		Dim apoderado = New ApoderadoDAL()
		Return apoderado.CancelarApoderadoDAL(id)
	End Function

#End Region

#Region "Contratos"
	Function ConsultaContratosBAL(ClienteID As Integer, ByRef model As List(Of OperacionContrato)) As Result
		Dim contrato = New ContratosDAL()
		Return contrato.ConsultaContratosDAL(ClienteID, model)
	End Function

	Function ConsultaDetalleContratoBAL(clienteid As Integer, ContratoID As Integer, ByRef model As ContratoCliente) As Result
		Dim contrato = New ContratosDAL()
		Return contrato.ConsultaDetalleContratoDAL(clienteid, ContratoID, model)
	End Function

	Function ActualizarContratoBAL(ByRef model As contratos) As Result
		Dim contrato = New ContratosDAL()
		Return contrato.ActualizarContratoDAL(model)
	End Function

	Function AltaContratoBAL(ByRef model As contratos) As Result
		Dim contrato = New ContratosDAL()
		Return contrato.AltaContratoDAL(model)
	End Function

	Function ConsultaClienteContratoBAL(ClienteID As Integer, ByRef model As OperacionContrato) As Result
		Dim contrato = New ContratosDAL()
		Return contrato.ConsultaClienteContratoDAL(ClienteID, model)
	End Function

	Function CancelarContratoBAL(ClienteID As Integer) As Result
		Dim contrato = New ContratosDAL()
		Return contrato.CancelarContratoDAL(ClienteID)
	End Function

#End Region

#Region "Anexo"
	Function ConsultaAnexoBAL(Contrato As Integer, Producto As Integer, ByRef lista As List(Of AnexoConsulta)) As Result
		Dim anexo = New AnexoDAL()
		Return anexo.ConsultaAnexoDAL(Contrato, Producto, lista)
	End Function


    Function ConsultaAnexoCtoBAL(Contrato As Integer, ByRef lista As List(Of DropDownEntidad))
        Dim anexo = New AnexoDAL()
        Return anexo.ConsultaAnexoCtoDAL(Contrato, lista)
    End Function

	Function ConsultaDetalleAnexoBAL(deudor As Integer, producto As Integer, ByRef model As AnexoConsulta, contrato As Integer) As Result
		Dim anexo = New AnexoDAL()
		Return anexo.ConsultaDetalleAnexoDAL(deudor, producto, model, contrato)
	End Function

	Function AltaAnexoBAL(model As anexo) As Result
		Dim anexo = New AnexoDAL()
		Return anexo.AltaAnexoDAL(model)
	End Function

	Function ActualizarAnexoBAL(model As anexo) As Result
		Dim anexo = New AnexoDAL()
		Return anexo.ActualizarAnexoDAL(model)
	End Function

	Function PrintAnexoBAL(Contrato As Integer, ByRef lista As List(Of AnexoConsulta)) As Result
		Dim anexo = New AnexoDAL()
		Return anexo.PrintAnexoDAL(Contrato, lista)
	End Function

#End Region

#Region "Cesiones"
    Function ConsultaCesionesBAL(Contrato As Integer, ByRef lista As List(Of CesionEntidad)) As Result
        Dim cesion = New CesionesDAL()
        Return cesion.ConsultaCesionesDAL(Contrato, lista)
    End Function

    Function ConsultaDoctosBAL(contrato As Integer, cesion As Integer, idtransact As String, ByRef lista As List(Of DoctosEntidad)) As Result
        Dim docto = New CesionesDAL()
        Return docto.ConsultaDoctosDAL(contrato, cesion, idtransact, lista)
    End Function

    Function ConsultaGarantiasBAL(contrato As Integer, cesion As Integer, idtransact As String, ByRef lista As List(Of GarantiaEntidad)) As Result
        Dim gar = New CesionesDAL()
        Return gar.ConsultaGarantiaDAL(contrato, cesion, idtransact, lista)
    End Function
    Function ConsultapagosadeudosCtoCesBAL(contrato As Integer, cesion As Integer, idtransact As String, ByRef lista As List(Of PagosAdeudosEntidad)) As Result
        Dim gar = New CesionesDAL()
        Return gar.ConsultapagosadeudosCtoCesDAL(contrato, cesion, idtransact, lista)
    End Function
	Function ConsultaDetalleCesionBAL(cesion As Integer, ByRef model As CesionEntidad, contrato As Integer) As Result
		Dim cons = New CesionesDAL()
		Return cons.ConsultaDetalleCesionDAL(cesion, model, contrato)
	End Function

    Function ConsultaCesionWzdBAL(contrato As Integer, producto As Integer, cesion As Integer, ByRef model As CesionWzdEntidad) As Result
        Dim cons = New CesionesDAL()
        Return cons.ConsultaCesionWzdDAL(contrato, producto, cesion, model)
    End Function

	Function ConsultaDetalleGarantiaBAL(garantiaid As Integer, ByRef model As GarantiaEntidad) As Result
		Dim gar = New CesionesDAL()
		Return gar.ConsultaDetalleGarantiaDAL(garantiaid, model)
	End Function

	Function ActualizarGarantiaBAL(model As garantia) As Result
		Dim gar = New CesionesDAL()
		Return gar.ActualizarGarantiaDAL(model)
    End Function

    Function ActualizarcesionBAL(model As cesiones) As Result
        Dim c = New CesionesDAL()
        Return c.ActualizarcesionDAL(model)
    End Function

    Function ActualizarcesionWzdBAL(model As cesiones) As Result
        Dim c = New CesionesDAL()
        Return c.ActualizarcesionWzdDAL(model)
    End Function


    Function AltacesionBAL(model As cesiones) As Result
        Dim c = New CesionesDAL()
        Return c.AltacesionDAL(model)
    End Function

    Function AltacesionWzdBAL(model As cesiones) As Result
        Dim c = New CesionesDAL()
        Return c.AltacesionWzdDAL(model)
    End Function

    Function ConsultaAdeudosCtoBAL(contrato As Integer, ByRef model As List(Of adeudosEntidad)) As Result
        Dim cons = New CobranzaDAL()
        Return cons.consultaAdeudos(model, contrato)
    End Function
    Function ConsultaAdeudosxpagarBAL(contrato As Integer, ByRef lista As List(Of AdeudosWzdEntidad)) As Result
        Dim cons = New CobranzaDAL()
        Return cons.ConsultaAdeudosxpagarDAL(contrato, lista)
    End Function

    Function GetCesionNumberBAL(cesion As Integer, contrato As Integer, idtransact As String, ByRef cesion_num As Integer) As Result
        Dim cons = New CesionesDAL()
        Return cons.GetCesionNumberDAL(cesion, contrato, idtransact, cesion_num)
    End Function

    Function GuardardoctoBAL(iddocto As Integer, contrato As Integer, cesion As Integer, ByRef model As DoctosEntidad) As Result
        Dim gar = New CesionesDAL()
        Return gar.GuardardoctoDAL(iddocto, contrato, cesion, model)
    End Function


    Function GuardarGarantiaWzdUpdBAL(model As garantia) As Result
        Dim ces = New CesionesDAL()
        Return ces.GuardarGarantiaWzdUpdDAL(model)
    End Function

    Function GuardardoctoUpdBAL(model As doctos) As Result
        Dim doc = New CesionesDAL()
        Return doc.GuardardoctoUpdDAL(model)
    End Function

    Function GuardargarantiaBAL(garantiaid As Integer, contrato As Integer, cesion As Integer, ByRef model As GarantiaEntidad) As Result
        Dim gar = New CesionesDAL()
        Return gar.GuardargarantiaDAL(garantiaid, contrato, cesion, model)
    End Function

    Function EliminagarantiaBAL(garantiaid As Integer) As Result
        Dim gar = New CesionesDAL()
        Return gar.EliminagarantiaDAL(garantiaid)
    End Function


#End Region

#Region "Ususarios Web "
	Function ConsultaUsuariosWebBAL(ByRef lista As List(Of UsuarioWebEntidad), id As Integer, identidad As Integer) As Result
		Dim web = New UsuariosWebDAL()
		Return web.ConsultaUsuariosWebDAL(lista, id, identidad)
	End Function

	Function ConsultaDetalleUsuarioWebBAL(folio As Integer, ByRef userweb As usersregs)
		Dim web = New UsuariosWebDAL()
		Return web.ConsultaDetalleUsuarioWebDAL(folio, userweb)
	End Function

	Function ActualizarUsuarioWebBAL(userweb As usersregs)
		Dim web = New UsuariosWebDAL()
		Return web.ActualizarUsuarioWebDAL(userweb)
	End Function

	Function GenerarPasswordBAL(folio As Integer)
		Dim web = New UsuariosWebDAL()

		Dim ca = Guid.NewGuid().ToString("N").Substring(0, 9)
		Dim pw = New Utility().Encripta(ca.Trim(), Enumerador.eTipoEncriptacion.eTipoPassword)

		Return web.GenerarPasswordDAL(folio, ca, pw)
	End Function

	Function ConsultaDetalleBitacoraBAL(ByRef lista As List(Of BitacoraEntidad), username As String, fechainicio As Date, fechafin As Date)
		Dim web = New UsuariosWebDAL()

		Return web.ConsultaDetalleBitacoraDAL(lista, username, fechainicio, fechafin)
	End Function

	Function PrintUsersWebBAL(id As Integer, identidad As Integer, ByRef lista As List(Of UsuarioWebEntidad))
		Dim web = New UsuariosWebDAL()

		Return web.PrintUsuariosWebDAL(id, identidad, lista)
	End Function


#End Region

	Function MandarContrasena(userid As String) As Result
		Dim web = New UsuarioDAL()

		Dim ca = Guid.NewGuid().ToString("N").Substring(0, 9)
		Dim pw = New Utility().Encripta(ca.Trim().ToUpper, Enumerador.eTipoEncriptacion.eTipoPassword)

		Return web.MandarContrasenDAL(userid, ca, pw)
	End Function

	Function resetPasswordBAL(id As Integer) As Result
		Dim web = New UsuarioDAL()

		Dim ca = Guid.NewGuid().ToString("N").Substring(0, 9)
		Dim pw = New Utility().Encripta(ca.Trim().ToUpper, Enumerador.eTipoEncriptacion.eTipoPassword)

		Return web.resetPasswordDAL(id, ca, pw)
	End Function

	Function ActualizarPassworResetBAL(userid As Integer, nueva As String) As Result
		Dim web = New UsuarioDAL()
		Dim pw = New Utility().Encripta(nueva.Trim().ToUpper(), Enumerador.eTipoEncriptacion.eTipoPassword)

		Return web.ActualizarPassworResetDAL(userid, nueva, pw)
	End Function

	Function obtenerVersionesBAL(ByRef lista As List(Of Versiones)) As Result
		Dim web = New UtilitiesDAL()
		Return web.obtenerVersionesDAL(lista)
	End Function

	Function DetalleVersionBAL(id As Integer, ByRef notas As String) As Result
		Dim web = New UtilitiesDAL()
		Return web.DetalleVersioDBAL(id, notas)
	End Function

	Function NuevaVersionBAL(modelo As version) As Result
		Dim web = New UtilitiesDAL()
		Return web.NuevaVersionDAL(modelo)
	End Function



End Class
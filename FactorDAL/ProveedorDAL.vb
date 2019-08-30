﻿Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.Validation
Imports FactorEntidades
Imports Nelibur.ObjectMapper

Public Class ProveedorDAL
#Region "Constructor"

#End Region

#Region "Metodos de consulta"

	Public Function ConsultaProveedorDAL(sucursal As Int16, ByRef model As List(Of ProveedorEntidad)) As Result

		Dim respuesta = New Result(False)

		Using context As New FactorContext
			Try
				model = (From p In context.proveedor Where (p.sucursal = sucursal Or 0 = sucursal) And p.historia = False Select New ProveedorEntidad With {.deudor = p.deudor, .nombre = p.nombre.TrimEnd(), .rfc = p.rfc}).ToList()

				respuesta.Ok = True
			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try
			Return respuesta
		End Using

	End Function

	Function ConsultaDetalleProveedorDAL(deudor As Int32, ByRef model As proveedor) As Result

		Dim respuesta = New Result(False)
		Using context As New FactorContext

			Try
				model = (From p In context.proveedor
					Where p.deudor = deudor).SingleOrDefault()

				If model IsNot Nothing Then
					respuesta.Ok = True
				End If


			Catch e As Exception
				respuesta.Detalle = e.Message
				respuesta.Id_Out = 1
			End Try

		End Using
		Return respuesta
	End Function

	Function CargaProveedoresDAL(ByRef lista As List(Of DropDownEntidad), listaDeudor As List(Of Integer)) As Result
		Dim respuesta = New Result(False)
		Using context As New FactorContext
			Try

				lista = context.proveedor.Where(Function(x) listaDeudor.Contains(x.deudor)).Select(Function(w) New DropDownEntidad With {
																									   .clave = w.deudor,
																									   .nombre = w.nombre
																									   }).ToList()
				respuesta.Ok = True
			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try

		End Using

		Return respuesta
	End Function


#End Region

#Region "Metodos Transaccionales"

	Public Function AltaProveedor(model As proveedor) As Result

		Dim respuesta = New Result(False)

		Using context As New FactorContext

			Try
				model.fec_update = Date.Today()
				model.modifica = False
				model.historia = False
				model.promotor = 0
				model.repeco = 0D
				model.folio_envio = 0
				model.internet = False
				model.void = False
				model.fec_update = Date.Today()
				context.proveedor.Add(model)
				context.SaveChanges()
				respuesta.Ok = True
			Catch e As Exception
				respuesta.Detalle = e.InnerException.InnerException.Message
			End Try

		End Using

		Return respuesta

	End Function

	Public Function ActualizarProveedor(userid As String, model As proveedor) As Result
		Dim respuesta = New Result(False)
		Using context As New FactorContext

			Try

				Dim proveedor = context.proveedor.Where(Function(w) w.deudor = model.deudor).SingleOrDefault()

				proveedor.calle = model.calle
				proveedor.colonia = model.colonia
				proveedor.cp = model.cp
				proveedor.curp = model.curp
				proveedor.domicilio = model.domicilio
				proveedor.email = model.email
				proveedor.enviafact = model.enviafact
				proveedor.estado = model.estado
				proveedor.fec_alta = model.fec_alta
				proveedor.fec_update = Date.Today()
				proveedor.fira_idcon = model.fira_idcon
				proveedor.firmado = model.firmado
				proveedor.giro = model.giro
				proveedor.municipio = model.municipio
				proveedor.noext = model.noext
				proveedor.noint = model.noint
				proveedor.nombre = model.nombre
				proveedor.notas = model.notas
				proveedor.plaza = model.plaza
				proveedor.plazacob = model.plazacob
				proveedor.rectificado = model.rectificado
				proveedor.regiva = model.regiva
				proveedor.responsable = model.responsable
				proveedor.rfc = model.rfc
				proveedor.sirac = model.sirac
				proveedor.sucursal = model.sucursal
				proveedor.telefono = model.telefono
				proveedor.updaterec = model.updaterec
				UtilitiesDAL.MonitorModifiedProp(userid, proveedor, context)
				context.SaveChanges()
				respuesta.Ok = True

			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try


		End Using

		Return respuesta
	End Function

#End Region



End Class

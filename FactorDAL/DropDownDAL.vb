﻿Imports FactorEntidades

Public Class DropDownDAL
	Public Function ConsultaPromotorDAL(promprod As Boolean, ByRef model As List(Of DropDownEntidad)) As Result

		Dim respuesta = New Result(False)

		Using context As New FactorContext
			Try
				If promprod Then
					model = (From p In context.promotor Where p.interno = True And p.tipopromo = 2 Select New DropDownEntidad With {.nombre = p.nombre, .clave = p.promotor1}).ToList()
				Else
					model = (From p In context.promotor Select New DropDownEntidad With {.nombre = p.nombre, .clave = p.promotor1}).ToList()
				End If
				respuesta.Ok = True
			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try
		End Using

		Return respuesta

	End Function

	Public Function ConsultaGrupoEmpresarialDAL(ByRef model As List(Of DropDownEntidad)) As Result

		Dim respuesta = New Result(False)

		Using context As New FactorContext
			Try
				model = (From p In context.grupos Select New DropDownEntidad With {.nombre = p.nombre, .clave = p.clave}).ToList()
				respuesta.Ok = True
			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try
		End Using

		Return respuesta

	End Function

	Public Function ConsultaCiudadesDAL(ByRef model As List(Of DropDownEntidad)) As Result

		Dim respuesta = New Result(False)

		Using context As New FactorContext
			Try
				model = (From p In context.ciudades Select New DropDownEntidad With {.nombre = p.ciudad, .clave = p.clave}).ToList()
				respuesta.Ok = True
			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try
		End Using

		Return respuesta

	End Function

	Public Function ConsultaEstadosDAL(ByRef model As List(Of DropDownEntidad)) As Result

		Dim respuesta = New Result(False)

		Using context As New FactorContext
			Try
				model = (From p In context.estadosdemexico Select New DropDownEntidad With {.nombre = p.estado, .clave = p.num}).ToList()
				respuesta.Ok = True
			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try
		End Using

		Return respuesta

	End Function

	Public Function ConsultaPerfilesDAL(ByRef model As List(Of DropDownEntidad)) As Result

		Dim respuesta = New Result(False)
		Dim ExcL = New List(Of Integer) From {
			10,
			11,
			12}


		Using context As New FactorContext
			Try
				model = (From p In context.perfil Where p.activo = 1 And Not ExcL.Contains(p.idPerfil) Select New DropDownEntidad With {.nombre = p.nombre, .clave = p.idPerfil}).ToList()
				respuesta.Ok = True
			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try
		End Using

		Return respuesta

	End Function

	Public Function ConsultaGirosDAL(ByRef model As List(Of DropDownEntidad)) As Result

		Dim respuesta = New Result(False)

		Using context As New FactorContext
			Try
				model = (From p In context.actividad Select New DropDownEntidad With {.clave = p.id, .nombre = p.descrip}).ToList()
				respuesta.Ok = True
			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try
		End Using

		Return respuesta

	End Function

	Public Function consultaBancosDAL(ByRef model As List(Of DropDownEntidad)) As Result

		Dim respuesta = New Result(False)

		Using context As New FactorContext
			Try
				model = (From p In context.bancos Select New DropDownEntidad With {.clave = p.idbanco, .nombre = p.shortname.Trim() + " [ " + p.banco.Trim() + " ]"}).ToList()
				respuesta.Ok = True
			Catch ex As Exception
				respuesta.Detalle = ex.Message
			End Try
		End Using

		Return respuesta
	End Function

	Public Function consultaCuentasDAL(ByRef model As List(Of DropDownEntidad)) As Result

		Dim respuesta = New Result(False)
		Using context As New FactorContext

			Try
				model = (From a In context.cuentas Where a.cancelado = False Select New DropDownEntidad With {.clave = a.idctabanco, .nombre = a.ctabanco.Trim() + " [ " + a.banco.Trim() + " ]"}).ToList()
				respuesta.Ok = True

			Catch ex As Exception
				respuesta.Detalle = ex.Message

			End Try
		End Using

		Return respuesta

	End Function

	Function consultarWebBancos(ByRef lista As List(Of DropDownEntidad)) As Result
		Dim respuesta = New Result(False)

		Using context As New FactorContext
			Try
				lista = (From p In context.webbancos Select New DropDownEntidad With {.clave = p.cuentaid, .nombre = p.shortname.Trim()}).ToList()
				respuesta.Ok = True
			Catch ex As Exception
				respuesta.Detalle = ex.Message
			End Try
		End Using

		Return respuesta
	End Function

End Class

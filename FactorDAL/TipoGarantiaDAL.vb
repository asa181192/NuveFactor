﻿Imports FactorEntidades
Imports System.Data.Entity
Imports Nelibur.ObjectMapper

Public Class TipoGarantiaDAL
#Region "Constructor"

#End Region

#Region "Metodos Consulta"
	Public Function ConsultaTipoGarantiaDAL(ByRef model As List(Of TipoGarantiaEntidad)) As Result

		Dim respuesta = New Result(False)

    Using context As New FactorContext
      Try

        model = (From p In context.tipogarantia Select New TipoGarantiaEntidad With {.tipoid = p.tipoid, .nombre = p.nombre, .tip_alterno = p.tip_alterno, .concepto = p.concepto}).ToList()
        respuesta.Ok = True

      Catch e As Exception
        respuesta.Detalle = e.Message
      End Try

    End Using

    Return respuesta

  End Function

  Function ConsultaDetalleTipoGarantiaDAL(tipoid As Integer, ByRef model As tipogarantia) As Result
    Dim respuesta = New Result(False)
    Using context As New FactorContext

      Try
        Dim consulta = (From p In context.tipogarantia Where p.tipoid = tipoid).SingleOrDefault()

        If consulta IsNot Nothing Then
          'mapeo de propiedades 
          model.codigoid = consulta.codigoid
          model.concepto = consulta.concepto
          model.conta_abono = consulta.conta_abono.TrimEnd()
          model.conta_cargo = consulta.conta_cargo.TrimEnd()
          model.nombre = consulta.nombre
          model.tip_alterno = consulta.tip_alterno
          model.tipoid = consulta.tipoid
          respuesta.Ok = True
        End If

      Catch e As Exception
        respuesta.Detalle = e.Message
        respuesta.Id_Out = 1
      End Try

    End Using
    Return respuesta
  End Function
#End Region

#Region "Metodos Transaccionales"
  Public Function AltaTipoGarantia(model As tipogarantia) As Result
    Dim respuesta = New Result(False)
    Using context As New FactorContext
      Try
        context.tipogarantia.Add(model)
        context.SaveChanges()
        respuesta.Ok = True
      Catch e As Exception
        respuesta.Detalle = e.Message
      End Try

    End Using

    Return respuesta

  End Function

  Public Function ActualizarTipoGarantia(model As tipogarantia) As Result
    Dim respuesta = New Result(False)

    Using context As New FactorContext

      Try
        context.tipogarantia.Attach(model)
        context.Entry(model).State = EntityState.Modified
        context.Entry(model).Property(Function(x) x.void).IsModified = False
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

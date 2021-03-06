﻿Imports FactorEntidades
Imports System.Data.Entity

Public Class CodigoGarantiaDAL

#Region "Constructor"

#End Region

#Region "Metodos Consulta"
	Public Function ConsultaCodigoGarantiaDAL(ByRef model As List(Of CodigoGarantiaEntidad)) As Result

		Dim respuesta = New Result(False)

    Using context As New FactorContext
      Try

        model = (From p In context.codigogarantia Select New CodigoGarantiaEntidad With {.cod_alterno = p.cod_alterno, .codigoid = p.codigoid, .nombre = p.nombre}).ToList()
        respuesta.Ok = True

      Catch e As Exception
        respuesta.Detalle = e.Message
      End Try

    End Using

    Return respuesta

  End Function

  Function ConsultaDetalleCodigoGarantiaDAL(codigoid As Integer, ByRef model As codigogarantia) As Result
    Dim respuesta = New Result(False)
    Using context As New FactorContext

      Try
        model = (From p In context.codigogarantia Where p.codigoid = codigoid).SingleOrDefault()

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
#End Region

#Region "Metodos Transaccionales"
  Public Function AltaCodigoGarantia(model As codigogarantia) As Result
    Dim respuesta = New Result(False)
    Using context As New FactorContext
      Try
        context.codigogarantia.Add(model)
        context.SaveChanges()
        respuesta.Ok = True
      Catch e As Exception
        respuesta.Detalle = e.Message
      End Try

    End Using

    Return respuesta

  End Function

  Public Function ActualizarCodigoGarantia(model As codigogarantia) As Result
    Dim respuesta = New Result(False)

    Using context As New FactorContext

      Try
        context.codigogarantia.Attach(model)
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

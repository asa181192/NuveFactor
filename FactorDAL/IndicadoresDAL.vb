﻿Imports System.Data.Entity.Infrastructure
Imports System.Data.SqlClient
Imports FactorEntidades
Imports System.Data.Entity


Public Class IndicadoresDAL

#Region "Constructor"

#End Region

#Region "Metodos Consulta"
	Public Function ConsultaIndicadorDAL(fechaMes As String, fechaAnio As String, ByRef model As List(Of FinancieroEntidad)) As Result

		Dim respuesta = New Result(False)

    Using context As New FactorContext
      Try

        Dim values = (From p In context.indicadores Where p.fecha.Value.Year = fechaAnio AndAlso p.fecha.Value.Month = fechaMes).ToList()


        For Each item As indicadores In values
          Dim p = New FinancieroEntidad

          p.fecha = item.fecha.Value.ToShortDateString()
          p.cetes28 = item.cetes28
          p.cetes91 = item.cetes91
          p.cpp = item.cpp
          p.fondeo = item.fondeo
          p.fondeousd = item.fondeousd
          p.libor = item.libor
          p.libor12m = item.libor12m
          p.libor3m = item.libor3m
          p.libor6m = item.libor6m
          p.tiie = item.tiie
          p.tiie91 = item.tiie91
          p.tiip = item.tiip

          model.Add(p)
        Next
        respuesta.Ok = True

      Catch e As Exception
        respuesta.Detalle = e.Message
      End Try

    End Using

    Return respuesta

  End Function

  Function ConsultaIndicadorDetalleDAL(fecha As String, ByRef model As indicadores) As Result
    Dim respuesta = New Result(False)
    Using context As New FactorContext

      Try

        If fecha Is Nothing Then
          model.fecha = context.indicadores.OrderByDescending(Function(e) e.fecha).Select(Function(e) e.fecha).FirstOrDefault()
          model.fecha = model.fecha.Value.AddDays(1)
        Else
          model = (From p In context.indicadores
                  Where p.fecha = fecha).SingleOrDefault()

          If model IsNot Nothing Then
            respuesta.Ok = True
          End If
        End If



      Catch e As Exception
        respuesta.Detalle = e.Message
      End Try

    End Using
    Return respuesta
  End Function
#End Region

#Region "Metodos Transaccionales"
  'Public Function AltaIndicador(model As indicadores) As Result
  '	Dim respuesta = New Result(False)
  '	Using context As New FactorContext
  '		Try

  '			If Not context.indicadores.Any(Function(x) x.fecha = model.fecha) Then
  '				context.indicadores.Add(model)
  '				context.SaveChanges()
  '				respuesta.Ok = True
  '			Else
  '				respuesta.Mensaje = "El registro Ya existe !!."
  '			End If

  '		Catch e As Exception
  '			respuesta.Detalle = e.InnerException.InnerException.Message
  '		End Try

  '	End Using

  '	Return respuesta

  'End Function

  Public Function ActualizarIndicador(model As indicadores) As Result
    Dim respuesta = New Result(False)

    Using context As New FactorContext

      Try
        Dim modelfn = context.indicadores.Find(model.fecha)

        'no existe registro 
        If modelfn Is Nothing Then
          context.indicadores.Add(model)
          context.SaveChanges()
          respuesta.Mensaje = "Registro Guardado"
          respuesta.Ok = True
        Else
          ' se actualiza registro

          modelfn.cetes28 = model.cetes28
          modelfn.cetes91 = model.cetes91
          modelfn.cpp = model.cpp
          modelfn.fondeo = model.fondeo
          modelfn.fondeousd = model.fondeousd
          modelfn.libor = model.libor
          modelfn.libor12m = model.libor12m
          modelfn.libor3m = model.libor3m
          modelfn.libor6m = model.libor6m
          modelfn.tiie = model.tiie
          modelfn.tiie91 = model.tiie91
          modelfn.tiip = model.tiip

          context.SaveChanges()
          respuesta.Mensaje = "Registro Actualizado"
          respuesta.Ok = True
        End If

      Catch e As Exception
        respuesta.Detalle = e.InnerException.InnerException.Message
      End Try

    End Using

    Return respuesta
  End Function
#End Region

End Class
﻿Imports FactorEntidades
Imports System.Data.Entity

Public Class ApoderadoDAL

#Region "Constructor"

#End Region

#Region "Metodos de consulta"
	Function ConsultaApoderadoDAL(cliente As Integer, ByRef model As List(Of ApoderadoEntidad)) As Result

		Dim respuesta = New Result(False)

    Using context As New FactorContext
      Try
        model = context.apoderados.Where(Function(p) p.cliente = cliente And p.cancelado = False).Select(Function(p) New ApoderadoEntidad With {.id = p.id,
                                                                .apoderado = p.apoderado,
                                                                .esaccion = p.esaccion,
                                                                .esapoderado = p.esapoderado,
                                                                .esdeposita = p.esdeposita,
                                                                .esobligado = p.esobligado}).ToList()

        If model IsNot Nothing Then
          respuesta.Ok = True
        End If

      Catch e As Exception
        respuesta.Detalle = e.Message
      End Try
    End Using

    Return respuesta

  End Function

  Function ConsultaDetalleApoderadoDAL(id As Int32, ByRef model As apoderados) As Result

    Dim respuesta = New Result(False)
    Using context As New FactorContext

      Try
        model = (From p In context.apoderados
            Where p.id = id).SingleOrDefault()

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
  Public Function ActualizarApoderadoDAL(model As apoderados) As Result
    Dim respuesta = New Result(False)

    Using context As New FactorContext

      Try

        model.fec_update = Date.Today
        context.apoderados.Attach(model)
        context.Entry(model).State = EntityState.Modified
        context.Entry(model).Property(Function(x) x.void).IsModified = False
        context.Entry(model).Property(Function(x) x.cancelado).IsModified = False
        context.Entry(model).Property(Function(x) x.idtransact).IsModified = False
        context.SaveChanges()
        respuesta.Ok = True
      Catch e As Exception
        respuesta.Detalle = e.InnerException.InnerException.Message
      End Try

    End Using

    Return respuesta
  End Function

  Public Function AltaApoderadoDAL(model As apoderados) As Result

    Dim respuesta = New Result(False)

    Using context As New FactorContext
      Try

        model.fec_update = Date.Today
        model.void = False
        model.cancelado = False
        model.idtransact = ""
        context.apoderados.Add(model)
        context.SaveChanges()
        respuesta.Ok = True
      Catch e As Exception
        respuesta.Detalle = e.InnerException.InnerException.Message
      End Try

    End Using

    Return respuesta

  End Function

  Public Function CancelarApoderadoDAL(id As Integer) As Result
    Dim respuesta = New Result(False)

    Using context As New FactorContext

      Try
        Dim apoderado = context.apoderados.Where(Function(x) x.id = id).SingleOrDefault()
        apoderado.cancelado = True
        context.SaveChanges()
        respuesta.Ok = True

      Catch e As Exception
        respuesta.Detalle = e.InnerException.InnerException.Message
      End Try

    End Using

    Return respuesta
  End Function
#End Region

End Class

﻿Imports FactorEntidades
Imports System.Data.Entity

Public Class CompradorDAL

#Region "Constructor"

#End Region

#Region "Metodos de consulta"
	Public Function ConsultaCompradorDAL(sucursal As Int16, ByRef model As List(Of ProveedorEntidad)) As Result

		Dim respuesta = New Result(False)

    Using context As New FactorContext
      Try
        model = (From p In context.comprador Where (p.sucursal = sucursal Or 0 = sucursal) And p.historia = False Select New ProveedorEntidad With {.deudor = p.deudor, .nombre = p.nombre.TrimEnd()}).ToList()
        respuesta.Ok = True
      Catch e As Exception
        respuesta.Detalle = e.Message
      End Try

    End Using

    Return respuesta

  End Function

  Function ConsultaDetalleCompradorDAL(deudor As Int32, ByRef model As comprador) As Result

    Dim respuesta = New Result(False)
    Using context As New FactorContext

      Try
        model = (From p In context.comprador
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
#End Region

#Region "Metodos Transaccionales"
  Public Function ActualizarComprador(model As comprador) As Result
    Dim respuesta = New Result(False)

    Using context As New FactorContext

      Try
        model.fec_update = Date.Today()
        context.comprador.Attach(model)
        context.Entry(model).State = EntityState.Modified
        context.Entry(model).Property(Function(x) x.historia).IsModified = False
        context.Entry(model).Property(Function(x) x.void).IsModified = False
        context.Entry(model).Property(Function(x) x.calle).IsModified = False
        context.Entry(model).Property(Function(x) x.fec_update).IsModified = False
        context.Entry(model).Property(Function(x) x.idipoliza).IsModified = False
        context.Entry(model).Property(Function(x) x.idtransact).IsModified = False
        context.SaveChanges()
        respuesta.Ok = True

      Catch e As Exception
        respuesta.Detalle = e.InnerException.InnerException.Message
      End Try

    End Using

    Return respuesta
  End Function

  Public Function AltaComprador(model As comprador) As Result

    Dim respuesta = New Result(False)
    Using context As New FactorContext
      Try
        model.endoso = Date.Today()
        model.historia = 0
        model.fec_update = Date.Today()
        context.comprador.Add(model)
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

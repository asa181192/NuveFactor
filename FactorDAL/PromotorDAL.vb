﻿Imports FactorEntidades
Imports System.Data.Entity

Public Class PromotorDAL
#Region "Constructor"

#End Region

#Region "Metodos de consulta"

	Public Function ConsultaPromotorDAL(sucursal As Int16, ByRef model As List(Of PromotorEntidad)) As Result

		Dim respuesta = New Result(False)

    Using context As New FactorContext
      Try
        model = (From p In context.promotor Where (p.sucursal = sucursal Or 0 = sucursal)
              Select New PromotorEntidad With {.promotor = p.promotor1, .nombre = p.nombre.Trim(), .activo1 = If(p.activo = True, "Si", "No"), .idt24 = p.idt24}).ToList()

        respuesta.Ok = True
      Catch e As Exception
        respuesta.Detalle = e.InnerException.InnerException.Message
      End Try

    End Using

    Return respuesta

  End Function

  Function ConsultaDetallePromotorDAL(promotor As Int32, ByRef model As promotor) As Result

    Dim respuesta = New Result(False)
    Using context As New FactorContext

      Try
        model = (From p In context.promotor
            Where p.promotor1 = promotor).SingleOrDefault()

        If model IsNot Nothing Then
          respuesta.Ok = True
        End If

      Catch e As Exception
        respuesta.Detalle = e.InnerException.InnerException.Message
        respuesta.Id_Out = 1
      End Try

    End Using
    Return respuesta
  End Function

#End Region

#Region "Metodos Transaccionales"

  Public Function AltaPromotor(model As promotor) As Result

    Dim respuesta = New Result(False)

    Using context As New FactorContext

      Try
        context.promotor.Add(model)
        context.SaveChanges()
        respuesta.Ok = True
      Catch e As Exception
        respuesta.Detalle = e.InnerException.InnerException.Message
      End Try

    End Using

    Return respuesta

  End Function

  Public Function ActualizarPromotor(model As promotor) As Result
    Dim respuesta = New Result(False)
    Using context As New FactorContext

      Try
        context.promotor.Attach(model)
        context.Entry(model).State = EntityState.Modified
        context.Entry(model).Property(Function(x) x.void).IsModified = False

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

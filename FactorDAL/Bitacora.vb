﻿Imports FactorEntidades

Public Class Bitacora
	Public Shared Function Monitor(ip As String, userid As String, action As String) As Result
		Dim respuesta = New Result(False)
		Dim model = New monitor()
		Using context As New FactorContext
			Try
				model.userid = userid
				model.action = action
				model.ip = ip
				model.fechatime = Date.Now
				model.fecha = Date.Now
				model.void = "0"
				context.monitor.Add(model)
				context.SaveChanges()
				respuesta.Ok = True
			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try
		End Using
		Return respuesta
	End Function

End Class
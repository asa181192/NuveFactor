Imports System.Data.Entity
Imports FactorEntidades

Public Class ProveedorDAL
#Region "Constructor"

#End Region

#Region "Metodos de consulta"
	Public Function ConsultaProveedorDAL(ByRef model As List(Of ProveedorEntidad)) As Result

		Dim respuesta = New Result(False)

		Using context As New FactorContext

			Try
				model = (From p In context.proveedor Select New ProveedorEntidad With {.deudor = p.deudor, .nombre = p.nombre}).AsNoTracking().ToList()
				respuesta.Ok = True
			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try

		End Using

		Return respuesta

	End Function

#End Region

#Region "Metodos Transaccionales"


#End Region
End Class

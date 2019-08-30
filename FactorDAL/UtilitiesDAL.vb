Imports System.Data.Entity.Infrastructure
Imports System.Data.SqlClient
Imports FactorEntidades
Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Transactions
Imports Nelibur.ObjectMapper
Imports NPOI.SS.UserModel
Imports NPOI.XSSF.UserModel
Imports NPOI.HSSF.UserModel
Imports System.IO
Imports System.Reflection
Imports System.ComponentModel


Public Class UtilitiesDAL

	Public Function ConsultaParametros(clave As String, ByRef parametro As String) As Result
		Dim response = New Result(False)

		Using context As New FactorContext

			Try
				Dim values = (From a In context.parametros
						 Where a.clave = clave
						 Select a).SingleOrDefault()

				parametro = values.ruta

				response.Ok = True
			Catch ex As Exception
				response.Mensaje = "Error al consultar los parámetros"
			End Try

		End Using

		Return response
	End Function

	Function Base64Decode(ByVal base64String)
		'rfc1521
		'1999 Antonin Foller, Motobit Software, http://Motobit.cz
		Const Base64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"
		Dim dataLength, sOut, groupBegin

		'remove white spaces, If any
		base64String = Replace(base64String, vbCrLf, "")
		base64String = Replace(base64String, vbTab, "")
		base64String = Replace(base64String, " ", "")

		'The source must consists from groups with Len of 4 chars
		dataLength = Len(base64String)

		If dataLength Mod 4 <> 0 Then
			Err.Raise(1, "Base64Decode", "Bad Base64 string.")
			Return Nothing
		End If


		' Now decode each group:
		For groupBegin = 1 To dataLength Step 4
			Dim numDataBytes, CharCounter, thisChar, thisData, nGroup, pOut
			' Each data group encodes up To 3 actual bytes.
			numDataBytes = 3
			nGroup = 0

			For CharCounter = 0 To 3
				' Convert each character into 6 bits of data, And add it To
				' an integer For temporary storage.  If a character is a '=', there
				' is one fewer data byte.  (There can only be a maximum of 2 '=' In
				' the whole string.)

				thisChar = Mid(base64String, groupBegin + CharCounter, 1)

				If thisChar = "=" Then
					numDataBytes = numDataBytes - 1
					thisData = 0
				Else
					thisData = InStr(1, Base64, thisChar, vbBinaryCompare) - 1
				End If
				If thisData = -1 Then
					Err.Raise(2, "Base64Decode", "Bad character In Base64 string.")
					Return Nothing
				End If

				nGroup = 64 * nGroup + thisData
			Next

			'Hex splits the long To 6 groups with 4 bits
			nGroup = Hex(nGroup)

			'Add leading zeros
			nGroup = String.Format(6 - Len(nGroup), "0") & nGroup

			'Convert the 3 byte hex integer (6 chars) To 3 characters
			pOut = Chr(CByte("&H" & Mid(nGroup, 1, 2))) + _
			  Chr(CByte("&H" & Mid(nGroup, 3, 2))) + _
			  Chr(CByte("&H" & Mid(nGroup, 5, 2)))

			'add numDataBytes characters To out string
			sOut = sOut & Left(pOut, numDataBytes)
		Next

		Base64Decode = sOut
	End Function

	Function ConvertToDataTable(Of T)(data As IList(Of T)) As DataTable
		Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(GetType(T))
		Dim table As New DataTable(GetType(T).Name)
		For Each prop As PropertyDescriptor In properties
			table.Columns.Add(prop.Name, If(Nullable.GetUnderlyingType(prop.PropertyType), prop.PropertyType))
		Next
		For Each item As T In data
			Dim row As DataRow = table.NewRow()
			For Each prop As PropertyDescriptor In properties
				row(prop.Name) = If(prop.GetValue(item), DBNull.Value)
			Next
			table.Rows.Add(row)
		Next
		Return table
	End Function

	Public Shared Function MonitorModifiedProp(userid As String, baseObject As Object, ByRef context As FactorContext) As Result
		Dim response = New Result(False)

		Dim original = context.Entry(baseObject).OriginalValues

		Dim modProp As String = ""

		For Each item As PropertyInfo In baseObject.GetType().GetProperties().ToList()

			Dim typeBase = baseObject.GetType()
			Dim propertyInfoBase As PropertyInfo = typeBase.GetProperty(item.Name)
			If propertyInfoBase IsNot Nothing Then
				If item.PropertyType.Name = "String" Then

					If propertyInfoBase.GetValue(baseObject, Nothing) IsNot Nothing And original.Item(item.Name) IsNot Nothing Then
						If propertyInfoBase.GetValue(baseObject, Nothing).ToString().Trim() <> original.Item(item.Name).ToString().Trim() Then

							modProp = modProp + " Campo modificado : " + item.Name + " valor anterior: " + original.Item(item.Name).ToString() + " nuevo valor :" + propertyInfoBase.GetValue(baseObject, Nothing).ToString()
						End If
					End If

				Else
					If propertyInfoBase.GetValue(baseObject, Nothing) IsNot Nothing And original.Item(item.Name) IsNot Nothing Then
						If propertyInfoBase.GetValue(baseObject, Nothing) <> original.Item(item.Name) Then

							modProp = modProp + " Campo modificado : " + item.Name + " valor anterior : " + original.Item(item.Name).ToString() + " nuevo valor :" + propertyInfoBase.GetValue(baseObject, Nothing).ToString()
						End If
					End If

				End If

			End If

		Next

		Dim model = New monitor()
		model.userid = userid
		model.action = modProp
		model.fechatime = Date.Now
		model.fecha = Date.Now
		model.void = "0"
		context.monitor.Add(model)

		response.Ok = True

		Return response
	End Function

	Function obtenerVersionesDAL(ByRef lista As List(Of Versiones)) As Object
		Dim respuesta = New Result(False)
		Using context As New FactorContext
			Try
				lista = context.version.Select(Function(x) New Versiones With {
												   .fecha = x.fecha,
												   .id = x.id,
												   .notas = x.notas,
												   .version = x.version1
												   }).OrderByDescending(Function(x) x.id).ToList()

				If lista IsNot Nothing Then
					respuesta.Ok = True
				End If

			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try

		End Using

		Return respuesta
	End Function

	Function DetalleVersioDBAL(id As Integer, ByRef notas As String) As Result
		Dim respuesta = New Result(False)
		Using context As New FactorContext
			Try
				notas = context.version.Where(Function(x) x.id = id).Select(Function(x) x.notas).SingleOrDefault()

				If notas IsNot Nothing Then
					respuesta.Ok = True
				End If

			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try

		End Using

		Return respuesta
	End Function

	Function NuevaVersionDAL(modelo As version) As Result
		Dim respuesta = New Result(False)

		Using context As New FactorContext
			Try
				context.version.Add(modelo)
				context.SaveChanges()
				respuesta.Ok = True
			Catch e As Exception
				respuesta.Detalle = e.Message
			End Try

		End Using

		Return respuesta
	End Function

End Class

Imports Newtonsoft.Json.Converters
Imports Newtonsoft.Json

'Esta clase permite convertir el tipo datetime a un formato reconocible para el JSON serialize
Public Class CustomJsonResult
	Inherits JsonResult

	Private Const _dateFormat As String = "dd/MM/yyyy"

	Public Overrides Sub ExecuteResult(ByVal context As ControllerContext)
		If context Is Nothing Then
			Throw New ArgumentNullException("context")
		End If

		Dim response As HttpResponseBase = context.HttpContext.Response

		If Not String.IsNullOrEmpty(ContentType) Then
			response.ContentType = ContentType
		Else
			response.ContentType = "application/json"
		End If

		If ContentEncoding IsNot Nothing Then
			response.ContentEncoding = ContentEncoding
		End If

		If Data IsNot Nothing Then
			Dim isoConvert = New IsoDateTimeConverter()
			isoConvert.DateTimeFormat = _dateFormat
			response.Write(JsonConvert.SerializeObject(Data, isoConvert))
		End If

	End Sub
End Class


'Esta clase permite validar solo los elementos que se mandan en el post desde el cliente 
'En caso de que se mande un elemento en el post y quiera ser excluido utilizar el constructor"

Public Class ValidateIncludeAttributes
	Inherits ActionFilterAttribute

	Private _excludeProp As List(Of String)

	Public Sub New(excludeProp As String)
		_excludeProp = excludeProp.Split(",").ToList()
	End Sub

	Public Sub New()
		_excludeProp = Nothing
	End Sub

	'Validate all atributtes included in the parameter of the controller 
	Public Overrides Sub OnActionExecuting(ByVal filterContext As ActionExecutingContext)
		Dim modelState = filterContext.Controller.ViewData.ModelState
		Dim valueProvider = filterContext.Controller.ValueProvider
		Dim keysWithValue = modelState.Keys.Where(Function(x) Not valueProvider.ContainsPrefix(x))

		For Each key In keysWithValue
			modelState(key).Errors.Clear()
		Next

		If _excludeProp IsNot Nothing Then
			For Each item In _excludeProp
				modelState(item).Errors.Clear()
			Next
		End If



	End Sub
End Class


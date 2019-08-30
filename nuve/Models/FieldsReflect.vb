Imports System.Reflection

Public Class FieldsReflect

	'Esta Clase permite inicializar las variables TipoString de cualquier clase .

	Private Shared Sub SetProperty(propertyName As String, value As String, ByRef refObj As Object)
		Dim type = refObj.GetType()
		Dim propertyInfo As PropertyInfo = type.GetProperty(propertyName)
		If propertyInfo IsNot Nothing Then
			If propertyInfo.GetValue(refObj, Nothing) Is Nothing Then
				propertyInfo.SetValue(refObj, value)
			End If
		End If
	End Sub

	Public Shared Sub initialize(ByRef clase As Object)
		For Each item As PropertyInfo In clase.GetType().GetProperties().ToList()
			If item.PropertyType.Name = "String" Then
				SetProperty(item.Name, "", clase)
			End If
		Next
	End Sub


End Class

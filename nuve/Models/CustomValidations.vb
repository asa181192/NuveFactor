Imports System.ComponentModel.DataAnnotations
Imports nuve.Models
Imports System.Reflection

Namespace CustomValidations

    'Ejemplo de Validacion usando Reflexion .
    'Esta esuna validacion para el lado del servidor
    Public Class CompareValuesValidation : Inherits ValidationAttribute : Implements IClientValidatable

        Dim _p As String
        Public Sub New(prop As String)
            _p = prop
        End Sub
        'Se hace validacion de lado del servidor 
        Protected Overrides Function IsValid(ByVal value As Object, ByVal validationContext As ValidationContext) As ValidationResult
            'Revisamos si es valida la propiedad
            Dim prop As PropertyInfo = validationContext.ObjectType.GetProperty(_p)

            If Convert.ToDecimal(value) <= Convert.ToDecimal(prop.GetValue(validationContext.ObjectInstance, Nothing)) Then
                Return ValidationResult.Success
            Else
                'Mostramos un Mensaje de error 
                Return New ValidationResult("valor debe ser menor o igual")
            End If

        End Function

        'Aqui se despliega errores hacia el cliente por javascript 
        Public Function GetClientValidationRules(ByVal metadata As ModelMetadata, ByVal context As ControllerContext) As IEnumerable(Of ModelClientValidationRule) Implements IClientValidatable.GetClientValidationRules
            Dim mvr As ModelClientValidationRule = New ModelClientValidationRule()
            mvr.ErrorMessage = "valor debe ser menor o igual"
            mvr.ValidationType = "valida"
            Return {mvr}
        End Function
    End Class


    Public Class GreaterThanZero : Inherits ValidationAttribute : Implements IClientValidatable

        'Se hace validacion de lado del servidor 
        Protected Overrides Function IsValid(ByVal value As Object, ByVal validationContext As ValidationContext) As ValidationResult
            'Revisamos si es valida la propiedad
            If Convert.ToDecimal(value) > 0.0 Then
                Return ValidationResult.Success
            Else
                'Mostramos un Mensaje de error 
                Return New ValidationResult("Monto debe ser mayor a 0.0")
            End If

        End Function

        'Aqui se despliega errores hacia el cliente por javascript 
        Public Function GetClientValidationRules(ByVal metadata As ModelMetadata, ByVal context As ControllerContext) As IEnumerable(Of ModelClientValidationRule) Implements IClientValidatable.GetClientValidationRules
            Dim mvr As ModelClientValidationRule = New ModelClientValidationRule()
            mvr.ErrorMessage = "Monto debe ser mayor a cero."
            mvr.ValidationType = "mayorcero"
            Return {mvr}

        End Function

    End Class





End Namespace



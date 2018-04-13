Imports System
Imports System.Data
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports Negocio.Validaciones
Imports System.Reflection
Imports Entidades
Imports Entidades.arrendadora

Namespace arrendadoraBL
  Public Class subactivBL
    Inherits arrendadora.subactiv

    ''' <summary>
    ''' Arrendadora
    ''' </summary>    
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      MyBase.New()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="scnn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal scnn As String)
      MyBase.New(scnn)
    End Sub

    Public Overrides Function Selectsubactiv(ByVal subactiv As Decimal) As subactiv
      Return MyBase.Normaliza(MyBase.Selectsubactiv(subactiv))
    End Function

    Public Overrides Function Selectsubactiv() As List(Of subactiv)
      Return MyBase.Normaliza(MyBase.Selectsubactiv())
    End Function

    Public Overrides Function Existesubactiv(ByVal subactiv As Decimal) As Boolean
      Return MyBase.Existesubactiv(subactiv)
    End Function
  End Class
End Namespace
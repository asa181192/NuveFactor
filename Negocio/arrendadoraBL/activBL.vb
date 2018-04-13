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
  Public Class activBL
    Inherits arrendadora.activ

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

    Public Overrides Function Selectactiv() As List(Of activ)
      Return MyBase.Normaliza(MyBase.Selectactiv())
    End Function

    Public Overrides Function Existeactivi(ByVal clave As Decimal) As Boolean
      Return MyBase.Existeactivi(clave)
    End Function
  End Class
End Namespace
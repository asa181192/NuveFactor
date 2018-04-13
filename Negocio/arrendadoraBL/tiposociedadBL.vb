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
  Public Class tiposociedadBL
    Inherits arrendadora.tiposociedad

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

    Public Overrides Function Selecttiposociedad(ByVal numero As Integer) As tiposociedad
      Return MyBase.Normaliza(MyBase.Selecttiposociedad(numero))
    End Function

    Public Overrides Function Selecttiposociedad() As List(Of tiposociedad)
      Return MyBase.Normaliza(MyBase.Selecttiposociedad())
    End Function

    Public Overrides Function Existetiposociedad(ByVal numero As Integer) As Boolean
      Return MyBase.Existetiposociedad(numero)
    End Function

  End Class
End Namespace
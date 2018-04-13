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
  Public Class sececoBL
    Inherits arrendadora.sececo

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

    Public Overrides Function Selectsececo() As List(Of sececo)
      Return MyBase.Normaliza(MyBase.Selectsececo())
    End Function

    Public Overrides Function Existesececo(ByVal numero As Integer) As Boolean
      Return MyBase.Existesececo(numero)
    End Function
  End Class
End Namespace
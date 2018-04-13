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
  Public Class paiBL
    Inherits arrendadora.pai

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

    Public Overrides Function Selectpais() As List(Of pai)
      Return MyBase.Normaliza(MyBase.Selectpais())
    End Function

    Public Overrides Function Selectpai(ByVal folio As Integer) As pai
      Return MyBase.Normaliza(MyBase.Selectpai(folio))
    End Function

    Public Overrides Function ExistePais(ByVal folio As Integer) As Boolean
      Return MyBase.ExistePais(folio)
    End Function

  End Class
End Namespace
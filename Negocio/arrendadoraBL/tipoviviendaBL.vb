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
  Public Class tipoviviendaBL
    Inherits arrendadora.tipovivienda

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

    Public Overrides Function SelectTipovivienda() As List(Of tipovivienda)
      Return MyBase.Normaliza(MyBase.SelectTipovivienda())
    End Function

    Public Overrides Function ExisteTipovivienda(ByVal Numero As Integer) As Boolean
      Return MyBase.ExisteTipovivienda(Numero)
    End Function
  End Class
End Namespace
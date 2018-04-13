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
  Public Class estadocivilBL
    Inherits arrendadora.estadocivil

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

    Public Overrides Function SelectEstadocivil() As List(Of estadocivil)
      Return MyBase.Normaliza(MyBase.SelectEstadocivil())
    End Function

    Public Overrides Function ExisteEstadocivil(ByVal numero As Integer) As Boolean
      Return MyBase.ExisteEstadocivil(numero)
    End Function

  End Class
End Namespace
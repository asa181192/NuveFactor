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
  Public Class tipoidBL
    Inherits arrendadora.tipoid

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

    Public Overrides Function SelectTipoid() As List(Of tipoid)
      Return MyBase.Normaliza(MyBase.SelectTipoid())
    End Function

    Public Overrides Function ExisteTipoid(ByVal Numero As Integer) As Boolean
      Return MyBase.ExisteTipoid(Numero)
    End Function
  End Class
End Namespace
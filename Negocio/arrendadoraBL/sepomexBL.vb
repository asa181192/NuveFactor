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
  Public Class sepomexBL
    Inherits arrendadora.sepomex

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

    Public Overrides Function Selectsepomex(ByVal id_unico As String) As sepomex
      Return MyBase.Normaliza(MyBase.Selectsepomex(id_unico))
    End Function

    Public Overrides Function Selectsepomex(ByVal codigo As Double) As List(Of sepomex)
      Return MyBase.Normaliza(MyBase.Selectsepomex(codigo))
    End Function

    Public Overrides Function SelectsepomexbyCodigo(dcodigo As Double?) As List(Of sepomexbyCodigo_Result)
      Return MyBase.Normaliza(MyBase.SelectsepomexbyCodigo(dcodigo))
    End Function

    Public Overrides Function Selectsepomexedo() As List(Of estado)
      Return MyBase.Normaliza(MyBase.Selectsepomexedo())
    End Function

    Public Overrides Function Selectsepomexmuni(ByVal estado As Integer) As List(Of municipio)
      Return MyBase.Normaliza(MyBase.Selectsepomexmuni(estado))
    End Function

  End Class
End Namespace
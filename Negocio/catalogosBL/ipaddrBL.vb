Imports System
Imports System.Data
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports Negocio.Validaciones
Imports Entidades
Imports Entidades.catalogos

Namespace catalogosBL

  Public Class ipaddrBL
    Inherits catalogos.ipaddr

    ''' <summary>
    ''' Catalogos
    ''' </summary>    
    ''' <remarks>Catalogos</remarks>
    Public Sub New()
      MyBase.New()
    End Sub

    ''' <summary>
    ''' Catalogos
    ''' </summary>
    ''' <param name="scnn">cnnstr</param>
    ''' <remarks>Catalogos</remarks>
    Public Sub New(ByVal scnn As String)
      MyBase.New(scnn)
    End Sub

    Public Overrides Function Selectipaddr() As List(Of ipaddr)
      Return MyBase.Normaliza(MyBase.Selectipaddr())
    End Function

  End Class

End Namespace
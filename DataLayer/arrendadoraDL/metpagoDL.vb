Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data.Linq.SqlClient
Imports Entidades
Imports Entidades.arrendadora

Namespace arrendadoraDL
  Public Class metpagoDL
    Inherits ConnClassDL

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

    Public Function Selectmetpago() As List(Of metpago)
      Dim ometpagos As List(Of Entidades.arrendadora.metpago) = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From mp As metpago In context.metpagos
                  Where mp.void = False
                  Select mp

        If oVar.Count() > 0 Then
          ometpagos = oVar.ToList()
        Else
          ometpagos = New List(Of metpago)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        ometpagos = New List(Of metpago)
      End Try
      Return ometpagos
    End Function

  End Class
End Namespace
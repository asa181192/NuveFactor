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
  Public Class tipoviviendaDL
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

    Public Function SelectTipovivienda() As List(Of tipovivienda)
      Dim oTipovivienda As List(Of tipovivienda) = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From tv As tipovivienda In context.tipoviviendas
                   Select tv

        If (oVar.Count() > 0) Then
          oTipovivienda = oVar.ToList()
        Else
          oTipovivienda = New List(Of tipovivienda)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oTipovivienda = New List(Of tipovivienda)
      End Try
      Return oTipovivienda
    End Function

    Public Function ExisteTipovivienda(ByVal numero As Integer) As Boolean
      Dim bExiste As Boolean = False
      Try
        MyBase.Start_context()
        Dim oVar = From tv As tipovivienda In context.tipoviviendas
                   Where tv.numero = numero
                   Select tv

        If (oVar.Count() > 0) Then
          bExiste = True
        Else
          bExiste = False
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        bExiste = False
      End Try
      Return bExiste
    End Function

  End Class
End Namespace
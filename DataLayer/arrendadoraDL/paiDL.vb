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
  Public Class paiDL
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

    Public Function Selectpais() As List(Of pai)
      Dim opais As List(Of pai) = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From o As pai In context.pais
                   Select o

        If (oVar.Count() > 0) Then
          opais = oVar.ToList()
        Else
          opais = New List(Of pai)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        opais = New List(Of pai)
      End Try
      Return opais
    End Function

    Public Function Selectpai(ByVal folio As Integer) As pai
      Dim opai As pai = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From o As pai In context.pais
                   Where o.folio = folio
                   Select o

        If oVar.Count() > 0 Then
          opai = oVar.Single()
        Else
          opai = New pai()
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        opai = New pai
      End Try
      Return opai
    End Function

    Public Function ExistePais(ByVal folio As Integer) As Boolean
      Dim bExiste As Boolean = False
      Try
        MyBase.Start_context()
        Dim oVar = From p As pai In context.pais
                   Where p.folio = folio
                   Select p

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
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
  Public Class subactivDL
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

    Public Function Selectsubactiv(ByVal subactiv As Decimal) As subactiv
      Dim oSubactividad As subactiv = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From sa As subactiv In context.subactivs
                   Where sa.subactiv_id = subactiv
                   Select sa

        If oVar.Count > 0 Then
          oSubactividad = oVar.Single()
        Else
          oSubactividad = New subactiv()
          oSubactividad.subactiv_id = -1
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oSubactividad = New subactiv()
        oSubactividad.subactiv_id = -1
      End Try
      Return oSubactividad
    End Function


    Public Function Selectsubactiv() As List(Of subactiv)
      Dim oSubactividad As List(Of subactiv) = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From sa As subactiv In context.subactivs
                   Select sa

        If (oVar.Count() > 0) Then
          oSubactividad = oVar.ToList()
        Else
          oSubactividad = New List(Of subactiv)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oSubactividad = New List(Of subactiv)
      End Try
      Return oSubactividad
    End Function

    Public Function Existesubactiv(ByVal subactiv As Decimal) As Boolean
      Dim bExiste As Boolean = False
      Try
        MyBase.Start_context()
        Dim oVar = From sa As subactiv In context.subactivs
                   Where sa.subactiv_id = subactiv
                   Select sa

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

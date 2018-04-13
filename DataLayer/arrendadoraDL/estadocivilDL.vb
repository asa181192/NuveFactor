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
  Public Class estadocivilDL
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

    Public Function SelectEstadocivil() As List(Of estadocivil)
      Dim oEstadocivil As List(Of estadocivil) = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From ec As estadocivil In context.estadocivils
                   Select ec

        If (oVar.Count() > 0) Then
          oEstadocivil = oVar.ToList()
        Else
          oEstadocivil = New List(Of estadocivil)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oEstadocivil = New List(Of estadocivil)
      End Try
      Return oEstadocivil
    End Function

    Public Function ExisteEstadocivil(ByVal numero As Integer) As Boolean
      Dim bExiste As Boolean = False
      Try
        MyBase.Start_context()
        Dim oVar = From ec As estadocivil In context.estadocivils
                   Where ec.numero = numero
                   Select ec

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
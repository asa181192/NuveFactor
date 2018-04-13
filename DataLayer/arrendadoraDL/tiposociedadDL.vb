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
  Public Class tiposociedadDL
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

    Public Function Selecttiposociedad(ByVal numero As Integer) As tiposociedad
      Dim oTiposociedad As tiposociedad = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From ts As tiposociedad In context.tiposociedads
                   Where ts.numero = numero
                   Select ts

        If (oVar.Count() > 0) Then
          oTiposociedad = oVar.Single
        Else
          oTiposociedad = New tiposociedad()
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oTiposociedad = New tiposociedad()
      End Try
      Return oTiposociedad
    End Function

    Public Function Selecttiposociedad() As List(Of tiposociedad)
      Dim oTiposociedad As List(Of tiposociedad) = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From ts As tiposociedad In context.tiposociedads
                   Select ts
                   Where ts.numero <> 0

        If (oVar.Count > 0) Then
          oTiposociedad = oVar.ToList()
        Else
          oTiposociedad = New List(Of tiposociedad)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oTiposociedad = New List(Of tiposociedad)
      End Try
      Return oTiposociedad
    End Function

    Public Function Existetiposociedad(ByVal numero As Integer) As Boolean
      Dim bExiste As Boolean = False
      Try
        MyBase.Start_context()
        Dim oVar = From ts As tiposociedad In context.tiposociedads
                   Where ts.numero = numero
                   Select ts

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
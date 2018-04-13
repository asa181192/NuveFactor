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
  Public Class tipoidDL
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

    Public Function SelectTipoid() As List(Of tipoid)
      Dim oTipoid As List(Of tipoid) = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From ti As tipoid In context.tipoids
                   Select ti

        If (oVar.Count() > 0) Then
          oTipoid = oVar.ToList()
        Else
          oTipoid = New List(Of tipoid)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oTipoid = New List(Of tipoid)
      End Try
      Return oTipoid
    End Function

    Public Function ExisteTipoid(ByVal numero As Integer) As Boolean
      Dim bExiste As Boolean = False
      Try
        MyBase.Start_context()
        Dim oVar = From ti As tipoid In context.tipoids
                   Where ti.numero = numero
                   Select ti

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
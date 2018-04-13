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
Imports Entidades.catalogos

Namespace catalogosDL

  Public Class ipaddrDL
    Inherits ConnClassDL

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

    Public Function Selectipaddr() As List(Of ipaddr)
      Dim oIpaddr As List(Of ipaddr) = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From ips As ipaddr In context.ipaddr
                   Select ips

        If (oVar.Count() > 0) Then
          oIpaddr = oVar.ToList()
        Else
          oIpaddr = New List(Of ipaddr)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oIpaddr = New List(Of ipaddr)
      End Try
      Return oIpaddr
    End Function
  End Class

End Namespace
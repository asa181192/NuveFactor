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
  Public Class sepomexDL
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

    Public Function Selectsepomex(ByVal id_unico As String) As sepomex
      Dim osepomex As sepomex = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From s As sepomex In context.sepomexs
                   Where s.id_unico = id_unico
                   Select s

        If oVar.Count() > 0 Then
          osepomex = oVar.Single()
        Else
          osepomex = New sepomex
        End If

      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        osepomex = New sepomex
      End Try
      Return osepomex
    End Function

    Public Function Selectsepomex(ByVal codigo As Double) As List(Of sepomex)
      Dim osepomexlst As List(Of sepomex) = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From sepo As sepomex In context.sepomexs
                   Where sepo.d_codigo = codigo
                   Select sepo

        If oVar.Count() > 0 Then
          osepomexlst = oVar.ToList()
        Else
          osepomexlst = New List(Of sepomex)
        End If

      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        osepomexlst = New List(Of sepomex)
      End Try
      Return osepomexlst
    End Function

    Public Function SelectsepomexbyCodigo(dcodigo As Double?) As List(Of sepomexbyCodigo_Result)
      Dim osepomexbyCodigo As List(Of sepomexbyCodigo_Result) = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From sepo As sepomex In context.sepomexs
                   Where sepo.d_codigo = dcodigo
                   Order By sepo.d_asenta Ascending
                   Select New sepomexbyCodigo_Result With {.id_unico = sepo.id_unico,
                                                             .d_asenta = sepo.d_asenta.Trim(),
                                                             .D_mnpio = sepo.D_mnpio,
                                                             .d_estado = sepo.d_estado
                                                            }

        If oVar.Count() > 0 Then
          osepomexbyCodigo = oVar.ToList()
        Else
          osepomexbyCodigo = New List(Of sepomexbyCodigo_Result)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        osepomexbyCodigo = New List(Of sepomexbyCodigo_Result)
      End Try
      Return osepomexbyCodigo
    End Function

    Public Function Selectsepomexedo() As List(Of estado)
      Dim osepomexedo As List(Of estado)
      Try
        MyBase.Start_context()
        Dim oVar = (From sepo As sepomex In context.sepomexs
                     Order By sepo.c_estado Ascending
                     Select New estado With {.idestado = sepo.c_estado, .estado = sepo.d_estado}).Distinct.ToList()

        If oVar.Count > 0 Then
          osepomexedo = oVar.ToList()
        Else
          osepomexedo = New List(Of estado)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        osepomexedo = New List(Of estado)
      End Try
      Return osepomexedo
    End Function

    Public Function Selectsepomexmuni(ByVal estado As Integer) As List(Of municipio)
      Dim osepomexmuni As List(Of municipio)
      Try
        MyBase.Start_context()
        Dim oVar = (From sepo As sepomex In context.sepomexs
                     Where sepo.c_estado = estado
                     Order By sepo.c_mnpio Ascending
                     Select New municipio With {.idmunicipio = sepo.c_mnpio, .municipio = sepo.D_mnpio}).Distinct.ToList()

        If oVar.Count > 0 Then
          osepomexmuni = oVar.ToList()
        Else
          osepomexmuni = New List(Of municipio)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        osepomexmuni = New List(Of municipio)
      End Try
      Return osepomexmuni
    End Function

  End Class
End Namespace
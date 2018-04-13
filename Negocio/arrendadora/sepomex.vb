Imports System
Imports System.Data
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports DataLayer
Imports DataLayer.arrendadoraDL
Imports Entidades
Imports Entidades.arrendadora

Namespace arrendadora
  Public MustInherit Class sepomex
    Inherits standardization
    Implements IDisposable

    Public Property sepomexDL() As sepomexDL
    Public Property Err() As Exception
    Public Property hayErr() As Boolean

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      Me.hayErr = False
      Me.Err = Nothing
      Me.sepomexDL = New sepomexDL()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="sconn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal sconn As String)
      Me.hayErr = False
      Me.Err = Nothing
      Me.sepomexDL = New sepomexDL(sconn)
    End Sub

    Public Overridable Function Selectsepomex(ByVal id_unico As String) As Entidades.arrendadora.sepomex
      Dim osepomex As Entidades.arrendadora.sepomex = Nothing
      Try
        osepomex = Me.sepomexDL.Selectsepomex(id_unico)
        If Me.sepomexDL.hayErr Then Throw Me.sepomexDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        osepomex = New Entidades.arrendadora.sepomex
      End Try
      Return osepomex
    End Function

    Public Overridable Function Selectsepomex(ByVal codigo As Double) As List(Of Entidades.arrendadora.sepomex)
      Dim osepomexlst As List(Of Entidades.arrendadora.sepomex) = Nothing
      Try
        osepomexlst = Me.sepomexDL.Selectsepomex(codigo)
        If Me.sepomexDL.hayErr Then Throw Me.sepomexDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        osepomexlst = New List(Of Entidades.arrendadora.sepomex)
      End Try
      Return osepomexlst
    End Function

    Public Overridable Function SelectsepomexbyCodigo(dcodigo As Double?) As List(Of Entidades.arrendadora.sepomexbyCodigo_Result)
      Dim osepomexbyCodigo As List(Of Entidades.arrendadora.sepomexbyCodigo_Result) = Nothing
      Try
        osepomexbyCodigo = Me.sepomexDL.SelectsepomexbyCodigo(dcodigo)
        If Me.sepomexDL.hayErr Then Throw Me.sepomexDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        osepomexbyCodigo = New List(Of Entidades.arrendadora.sepomexbyCodigo_Result)
      End Try
      Return osepomexbyCodigo
    End Function

    Public Overridable Function Selectsepomexedo() As List(Of Entidades.arrendadora.estado)
      Dim osepomexedo As List(Of Entidades.arrendadora.estado) = Nothing
      Try
        osepomexedo = Me.sepomexDL.Selectsepomexedo()
        If Me.sepomexDL.hayErr Then Throw Me.sepomexDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        osepomexedo = New List(Of Entidades.arrendadora.estado)
      End Try
      Return osepomexedo
    End Function

    Public Overridable Function Selectsepomexmuni(ByVal estado As Integer) As List(Of Entidades.arrendadora.municipio)
      Dim osepomexmuni As List(Of Entidades.arrendadora.municipio) = Nothing
      Try
        osepomexmuni = Me.Selectsepomexmuni(estado)
        If Me.sepomexDL.hayErr Then Throw Me.sepomexDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        osepomexmuni = New List(Of Entidades.arrendadora.municipio)
      End Try
      Return osepomexmuni
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then

        End If
      End If
      Me.disposedValue = True
    End Sub

    Protected Overrides Sub Finalize()      
      Dispose(False)
      MyBase.Finalize()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose      
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region

  End Class
End Namespace
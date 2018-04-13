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

  Public MustInherit Class bitacora
    Inherits standardization
    Implements IDisposable

    Public Property bitacoraDL() As bitacoraDL
    Public Property Err() As Exception
    Public Property hayErr() As Boolean

    ''' <summary>
    ''' Arrendadora
    ''' </summary>    
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      Me.hayErr = False
      Me.Err = Nothing
      Me.bitacoraDL = New bitacoraDL()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="sconn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal sconn As String)
      Me.hayErr = False
      Me.Err = Nothing
      Me.bitacoraDL = New bitacoraDL(sconn)
    End Sub

    Public Overridable Function Selectbitacora(ByVal usuario As String, ByVal fecini As Date, ByVal fecfin As Date) As List(Of Entidades.arrendadora.bitacora)
      Dim obitacoralst As List(Of Entidades.arrendadora.bitacora) = Nothing
      Try
        obitacoralst = Me.bitacoraDL.Selectbitacora(usuario, fecini, fecfin)
        If Me.bitacoraDL.hayErr Then Throw Me.bitacoraDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        obitacoralst = New List(Of Entidades.arrendadora.bitacora)
      End Try
      Return obitacoralst
    End Function

    Public Overridable Function Selectbitacora(ByVal fecini As Date, ByVal fecfin As Date) As List(Of Entidades.arrendadora.bitacora)
      Dim obitacoralst As List(Of Entidades.arrendadora.bitacora) = Nothing
      Try
        obitacoralst = Me.bitacoraDL.Selectbitacora(fecini, fecfin)
        If Me.bitacoraDL.hayErr Then Throw Me.bitacoraDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        obitacoralst = New List(Of Entidades.arrendadora.bitacora)
      End Try
      Return obitacoralst
    End Function

    Public Overridable Function Selectbitacorafolio(ByVal folio As String) As Entidades.arrendadora.bitacora
      Dim obitacora As Entidades.arrendadora.bitacora = Nothing
      Try
        obitacora = Me.bitacoraDL.Selectbitacorafolio(folio)
        If Me.bitacoraDL.hayErr Then Throw Me.bitacoraDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        obitacora = New Entidades.arrendadora.bitacora
      End Try
      Return obitacora
    End Function

    Public Overridable Function Selectbitacorascortecajero(ByVal usuario As String) As List(Of Entidades.arrendadora.bitacora)
      Dim obitacoraslst As List(Of Entidades.arrendadora.bitacora) = Nothing
      Try
        obitacoraslst = Me.bitacoraDL.Selectbitacorascortecajero(usuario)
        If Me.bitacoraDL.hayErr Then Throw Me.bitacoraDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        obitacoraslst = New List(Of Entidades.arrendadora.bitacora)
      End Try
      Return obitacoraslst
    End Function

    Public Overridable Function Submit(ByRef bitacora As Entidades.arrendadora.bitacora) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Me.bitacoraDL.Submit(bitacora)
        If Me.bitacoraDL.hayErr Then Throw Me.bitacoraDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        bTrans = False
      End Try
      Return bTrans
    End Function

    Public Overridable Function Submit(ByRef bitacoras As List(Of Entidades.arrendadora.bitacora)) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Me.bitacoraDL.Submit(bitacoras)
        If Me.bitacoraDL.hayErr Then Throw Me.bitacoraDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        bTrans = False
      End Try
      Return bTrans
    End Function

    Public Overridable Function CreaBitacora(ByVal bitacora As Entidades.arrendadora.bitacora) As Boolean
      Dim btrans As Boolean = False
      Try
        btrans = Me.bitacoraDL.CreaBitacora(bitacora)
        If Me.bitacoraDL.hayErr Then Throw Me.bitacoraDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        btrans = False
      End Try
      Return btrans
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          If Not Me.bitacoraDL Is Nothing Then Me.bitacoraDL.Dispose()
          Me.bitacoraDL = Nothing
          If Not Me.Err Is Nothing Then Me.Err = Nothing
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
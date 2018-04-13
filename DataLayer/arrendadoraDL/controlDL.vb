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

  Public Class controlDL
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

    Private _oNewControlOuBx As control
    Public Property oNewControlOuBx() As control
      Get
        Return Me._oNewControlOuBx
      End Get
      Set(value As control)
        If Not Me._oNewControlOuBx Is Nothing Then Me._oNewControlOuBx = Nothing
        Me._oNewControlOuBx = New control()
        For Each prop As System.Reflection.PropertyInfo In value.GetType.GetProperties.ToList()
          prop.SetValue(_oNewControlOuBx, prop.GetValue(value))
        Next
      End Set
    End Property

    Private _oOriControlOuBx As control
    Public Property oOriControlOuBx() As control
      Get
        Return Me._oOriControlOuBx
      End Get
      Set(value As control)
        If Not Me._oOriControlOuBx Is Nothing Then Me._oOriControlOuBx = Nothing
        Me._oOriControlOuBx = New control()
        For Each prop As System.Reflection.PropertyInfo In value.GetType.GetProperties.ToList()
          prop.SetValue(_oOriControlOuBx, prop.GetValue(value))
        Next
      End Set
    End Property

    Public Function SelectControl() As control
      Dim ocontrol As control = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From cont As control In context.controls
                   Select cont

        If (oVar.Count > 0) Then
          ocontrol = oVar.FirstOrDefault()
        Else
          ocontrol = New control()
          ocontrol.registro = -1
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        ocontrol = New control()
        ocontrol.registro = -1
      End Try
      Return ocontrol
    End Function

    Public Function GetParametros() As List(Of fdu_ParametrosControl_Result)
      Dim oParametros As List(Of fdu_ParametrosControl_Result) = Nothing
      Try
        MyBase.Start_context()
        oParametros = context.fdu_ParametrosControl().ToList()
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oParametros = New List(Of fdu_ParametrosControl_Result)
      End Try
      Return oParametros
    End Function

    Public Function Submit(ByRef control As control) As Boolean
      Dim bTrans As Boolean = False
      Try
        Dim iregistro = control.registro
        MyBase.Start_context()

        Dim ocontrol = From cont As control In context.controls
                       Where cont.registro = iregistro And cont.registro > 0

        oNewControlOuBx = control

        If (ocontrol.Count() > 0) Then
          Me.oOriControlOuBx = ocontrol.Single()

          For Each prop In control.GetType.GetProperties.ToList
            prop.SetValue(ocontrol.Single(), prop.GetValue(control))
          Next

          context.SaveChanges()
          bTrans = True

        Else
          control.registro = context.controls.Select(Function(s) s.registro).Max + 1
          oNewControlOuBx.registro = control.registro
          context.controls.Add(control)
          context.SaveChanges()
          bTrans = True
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        bTrans = False
      End Try
      Return bTrans
    End Function

    Public Overloads Function GeneraOutbox(ByVal oficina As Integer, ByVal archivo As String, ByVal tag As String, ByVal llave As String, ByVal changes As String) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Metodos.GeneraOutbox(oficina, archivo, tag, llave, changes)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = ex
        bTrans = False
      End Try
      Return bTrans
    End Function

  End Class

End Namespace
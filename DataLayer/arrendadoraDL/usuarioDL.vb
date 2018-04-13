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

  Public Class usuarioDL
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

    Private _oNewusuarioOuBx As usuario
    Public Property oNewusuarioOuBx() As usuario
      Get
        Return Me._oNewusuarioOuBx
      End Get
      Set(value As usuario)
        If Not Me._oNewusuarioOuBx Is Nothing Then Me._oNewusuarioOuBx = Nothing
        Me._oNewusuarioOuBx = New usuario()
        For Each prop As System.Reflection.PropertyInfo In value.GetType.GetProperties.ToList()
          prop.SetValue(Me._oNewusuarioOuBx, prop.GetValue(value))
        Next
      End Set
    End Property

    Private _oNewusuariosOuBx As List(Of usuario)
    Public Property oNewusuariosOuBx() As List(Of usuario)
      Get
        Return Me._oNewusuariosOuBx
      End Get
      Set(value As List(Of usuario))
        If Not Me._oNewusuariosOuBx Is Nothing Then Me._oNewusuariosOuBx = Nothing
        Me._oNewusuariosOuBx = New List(Of usuario)
        For Each usr As usuario In value
          Dim u As New usuario()
          For Each prop As System.Reflection.PropertyInfo In usr.GetType.GetProperties.ToList()
            prop.SetValue(u, prop.GetValue(usr))
          Next
          Me._oNewusuariosOuBx.Add(u)
          u = Nothing
        Next
      End Set
    End Property
    Public WriteOnly Property oNewusuariosOuBx_add() As usuario
      Set(ByVal value As usuario)
        If Me._oNewusuariosOuBx Is Nothing Then Me._oNewusuariosOuBx = New List(Of usuario)
        Me._oNewusuariosOuBx.Add(value)
      End Set
    End Property

    Private _oOriusuarioOuBx As usuario
    Public Property oOriusuarioOuBx() As usuario
      Get
        Return Me._oOriusuarioOuBx
      End Get
      Set(value As usuario)
        If Not Me._oOriusuarioOuBx Is Nothing Then Me._oOriusuarioOuBx = Nothing
        Me._oOriusuarioOuBx = New usuario()
        For Each prop As System.Reflection.PropertyInfo In value.GetType.GetProperties.ToList()
          prop.SetValue(Me._oOriusuarioOuBx, prop.GetValue(value))
        Next
      End Set
    End Property

    Private _oOriusuariosOuBx As List(Of usuario)
    Public Property oOriusuariosOuBx() As List(Of usuario)
      Get
        Return Me._oOriusuariosOuBx
      End Get
      Set(value As List(Of usuario))
        If Not Me._oOriusuariosOuBx Is Nothing Then Me._oOriusuariosOuBx = Nothing
        Me._oOriusuariosOuBx = New List(Of usuario)
        For Each usr As usuario In value
          Dim u As New usuario()
          For Each prop As System.Reflection.PropertyInfo In usr.GetType.GetProperties.ToList()
            prop.SetValue(u, prop.GetValue(usr))
          Next
          Me._oOriusuariosOuBx.Add(u)
          u = Nothing
        Next
      End Set
    End Property

    Public Function SelectFoliobyEmail(ByVal email As String) As List(Of Decimal)
      Dim oEmails As List(Of Decimal) = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From u As usuario In context.usuarios
                   Where u.email.ToString = email
                   Select Convert.ToDecimal(u.folio)

        If oVar.Count() > 0 Then
          oEmails = oVar.ToList()
        Else
          oEmails = New List(Of Decimal)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oEmails = New List(Of Decimal)
      End Try
      Return oEmails
    End Function

    Public Function Selectusuario() As List(Of usuario)
      Dim ousuarios As List(Of usuario) = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From usr As usuario In context.usuarios
                   Select usr

        If oVar.Count() > 0 Then
          ousuarios = oVar.ToList()
        Else
          ousuarios = New List(Of usuario)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        ousuarios = New List(Of usuario)
      End Try
      Return ousuarios
    End Function

    Public Function Selectusuario(ByVal user As String) As usuario
      Dim ousuario As usuario = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From usr As usuario In context.usuarios
                   Where usr.userid = user
                   Select usr

        If oVar.Count() > 0 Then
          ousuario = oVar.Single()
        Else
          ousuario = New usuario()
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        ousuario = New usuario()
      End Try
      Return ousuario
    End Function

    Public Function Selectusuario(ByVal folio As Integer) As usuario
      Dim ousuario As usuario = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From usr As usuario In context.usuarios
                   Where usr.folio = folio
                   Select usr

        If oVar.Count > 0 Then
          ousuario = oVar.Single()
        Else
          ousuario = New usuario()
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        ousuario = New usuario()
      End Try
      Return ousuario
    End Function

    Public Function Submit(ByRef usuario As usuario) As Boolean
      Dim bTrans As Boolean = False
      Try
        Dim ifolio = usuario.folio
        Dim suserid = usuario.userid
        MyBase.Start_context()
        Dim ousuario = From us As usuario In context.usuarios
                       Where us.folio = ifolio And us.userid = suserid
                       Select us

        oNewusuarioOuBx = usuario
        If ousuario.Count() Then
          Me.oOriusuarioOuBx = ousuario.Single()

          For Each prop In usuario.GetType.GetProperties.ToList
            prop.SetValue(ousuario.Single(), prop.GetValue(usuario))
          Next

          context.SaveChanges()
          bTrans = True
        Else
          context.usuarios.Add(usuario)
          context.SaveChanges()
          bTrans = True
        End If
      Catch ex_entity As Entity.Validation.DbEntityValidationException
        Dim err_str As String = "Error datos: "
        For Each eve In ex_entity.EntityValidationErrors.ToList
          Dim err_obj As String = "Entity of type {0} in state {1} has the following validation errors: {2}"
          err_obj = String.Format(err_obj, eve.Entry.Entity.GetType().Name, eve.Entry.State)
          Dim err_props As String = ""
          For Each ve In eve.ValidationErrors.ToList
            Dim err_prop As String = "- Property: {0}, Error: {1}"
            err_prop = String.Format(err_prop, ve.PropertyName, ve.ErrorMessage)
            err_props &= err_prop
          Next
          err_obj = String.Format(err_obj, err_props)
          err_str &= err_obj
        Next
        Me.hayErr = True
        Me.Err = New Exception(err_str, ex_entity)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        bTrans = False
      End Try
      Return bTrans
    End Function

    Public Function Submit(ByRef usuarios As List(Of usuario)) As Boolean
      Dim bTrans As Boolean = False

      Try
        MyBase.Start_context()

        Dim oLlaves = usuarios.Select(Function(s) New With {.folio = s.folio, .userid = s.userid.Trim.ToUpper}).ToList()

        Dim ousuarios = From u As usuario In context.usuarios
                        Where oLlaves.Contains(New With {.folio = u.folio, .userid = u.userid.Trim.ToUpper})
                        Select u

        If ousuarios.Count() Then
          If Not Me._oNewusuariosOuBx Is Nothing Then Me._oNewusuariosOuBx = Nothing
          Me.oOriusuariosOuBx = ousuarios.ToList()

          Dim props = usuarios.ElementAt(0).GetType().GetProperties()
          Dim oInsert As New List(Of usuario)

          For Each oUpdate As usuario In ousuarios.ToList()
            Dim ouser = usuarios.Where(Function(w) w.folio = oUpdate.folio And w.userid = oUpdate.userid)
            If ouser.Count() > 0 Then
              Me.oNewusuariosOuBx_add = ouser.Single()
              For Each prop As System.Reflection.PropertyInfo In props.ToList()
                prop.SetValue(oUpdate, prop.GetValue(ouser.Single()))
              Next
            Else
              oInsert.Add(oUpdate)
            End If
          Next

          If oInsert.Count() > 0 Then
            For Each ouser As usuario In oInsert.ToList()
              Me.oNewusuariosOuBx_add = ouser
            Next
            context.usuarios.AddRange(DirectCast(oInsert.ToList(), IEnumerable(Of usuario)))
          End If

          context.SaveChanges()
          bTrans = True

        Else
          Me.oNewusuariosOuBx = usuarios
          context.usuarios.AddRange(DirectCast(usuarios, IEnumerable(Of usuario)))
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

    Public Overloads Function GeneraOutbox(ByVal oficina As Integer, ByVal archivo As String, ByVal tag As String, ByVal llave As String, ByVal chageslst As List(Of String)) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Metodos.GeneraOutbox(oficina, archivo, tag, llave, chageslst)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = ex
        bTrans = False
      End Try
      Return bTrans
    End Function

    Public Function GetParametrosControl() As List(Of fdu_ParametrosControl_Result)
      Dim oParametros As List(Of fdu_ParametrosControl_Result) = Nothing
      Try
        MyBase.Start_context()
        oParametros = context.fdu_ParametrosControl.ToList()
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oParametros = New List(Of fdu_ParametrosControl_Result)
      End Try
      Return oParametros
    End Function

    Public Function GetAvisos_AutorizacionesRechazos(ByVal oficinas As String, ByVal fecha As Date, Optional fecha2 As Nullable(Of Date) = Nothing) As List(Of sp_Avisos_AutorizacionesRechazos_Result)
      Dim oAutorizacionesRechazos As List(Of sp_Avisos_AutorizacionesRechazos_Result) = Nothing
      Try
        MyBase.Start_context()
        oAutorizacionesRechazos = context.sp_Avisos_AutorizacionesRechazos(oficinas, fecha, fecha2).ToList()
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oAutorizacionesRechazos = New List(Of sp_Avisos_AutorizacionesRechazos_Result)
      End Try
      Return oAutorizacionesRechazos
    End Function

    Public Function GetNueva_Solicheq(ByVal oficina As Integer) As Nullable(Of Decimal)
      Dim Nueva_Solicheq As Nullable(Of Decimal) = Nothing      
      Try
        MyBase.Start_context()      
        Nueva_Solicheq = context.sp_Nueva_Solicheq(oficina)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        Nueva_Solicheq = Nothing      
      End Try
      Return Nueva_Solicheq
    End Function

    Public Function GetNueva_Nota(ByVal oficina As Integer) As Nullable(Of Integer)
      Dim Nueva_Nota As Nullable(Of Integer) = Nothing      
      Try
        MyBase.Start_context()        
        Nueva_Nota = context.sp_Nueva_Nota(oficina)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        Nueva_Nota = Nothing      
      End Try
      Return Nueva_Nota
    End Function


  End Class

End Namespace
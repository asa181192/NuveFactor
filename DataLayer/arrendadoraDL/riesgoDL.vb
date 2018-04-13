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
  Public Class riesgoDL
    Inherits ConnClassDL

    Private _oNewriesgoOuBx As riesgo
    Public Property oNewriesgoOuBx() As riesgo
      Get
        Return Me._oNewriesgoOuBx
      End Get
      Set(value As riesgo)
        If Not Me._oNewriesgoOuBx Is Nothing Then Me._oNewriesgoOuBx = Nothing
        Me._oNewriesgoOuBx = New riesgo()
        For Each prop As System.Reflection.PropertyInfo In value.GetType.GetProperties.ToList()
          prop.SetValue(_oNewriesgoOuBx, prop.GetValue(value))
        Next
      End Set
    End Property

    Private _oNewriesgosOuBx As List(Of riesgo)
    Public Property oNewriesgosOuBx() As List(Of riesgo)
      Get
        Return Me._oNewriesgosOuBx
      End Get
      Set(value As List(Of riesgo))
        If Not Me._oNewriesgosOuBx Is Nothing Then Me._oNewriesgosOuBx = Nothing
        Me._oNewriesgosOuBx = New List(Of riesgo)
        For Each riesgo As riesgo In value
          Dim r As New riesgo()
          For Each prop As System.Reflection.PropertyInfo In riesgo.GetType.GetProperties.ToList()
            prop.SetValue(r, prop.GetValue(riesgo))
          Next
          Me._oNewriesgosOuBx.Add(r)
          r = Nothing
        Next
      End Set
    End Property
    Public WriteOnly Property oNewriesgosOuBx_add() As riesgo
      Set(ByVal value As riesgo)
        If Me._oNewriesgosOuBx Is Nothing Then Me._oNewriesgosOuBx = New List(Of riesgo)
        Me._oNewriesgosOuBx.Add(value)
      End Set
    End Property

    Private _oOririesgoOuBx As riesgo
    Public Property oOririesgoOuBx() As riesgo
      Get
        Return Me._oOririesgoOuBx
      End Get
      Set(value As riesgo)
        If Not Me._oOririesgoOuBx Is Nothing Then Me._oOririesgoOuBx = Nothing
        Me._oOririesgoOuBx = New riesgo()
        For Each prop As System.Reflection.PropertyInfo In value.GetType.GetProperties.ToList()
          prop.SetValue(_oOririesgoOuBx, prop.GetValue(value))
        Next
      End Set
    End Property

    Private _oOririesgosOuBx As List(Of riesgo)
    Public Property oOririesgosOuBx() As List(Of riesgo)
      Get
        Return Me._oOririesgosOuBx
      End Get
      Set(value As List(Of riesgo))
        If Not Me._oOririesgosOuBx Is Nothing Then Me._oOririesgosOuBx = Nothing
        Me._oOririesgosOuBx = New List(Of riesgo)
        For Each riesgo As riesgo In value
          Dim r As New riesgo()
          For Each prop As System.Reflection.PropertyInfo In riesgo.GetType.GetProperties.ToList()
            prop.SetValue(r, prop.GetValue(riesgo))
          Next
          Me._oOririesgosOuBx.Add(r)
          r = Nothing
        Next
      End Set
    End Property

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

    Public Function getSaldoInsolutoRiesgo(ByVal riesgo As Integer) As Decimal
      Dim nSalInSan As Decimal
      Try
        MyBase.Start_context()
        nSalInSan = context.getSaldoInsolutoRiesgo(riesgo)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        nSalInSan = 0
      End Try
      Return nSalInSan
    End Function

    Public Function Selectriesgo() As List(Of riesgo)
      Dim oriesgo As List(Of riesgo) = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From rie As riesgo In context.riesgos
                   Select rie

        If oVar.Count() > 0 Then
          oriesgo = oVar.ToList()
        Else
          oriesgo = New List(Of riesgo)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oriesgo = New List(Of riesgo)
      End Try
      Return oriesgo
    End Function

    Public Function SelectGrupoNombre(ByVal oficinas As String) As List(Of GrupoNombre_Result)

      Dim oriesgo As List(Of GrupoNombre_Result) = Nothing
      Dim noficinas As List(Of Integer) = Nothing
      Try
        MyBase.Start_context()
        noficinas = oficinas.Split(",").Select(Function(s) Convert.ToInt32(s.Trim)).ToList()
        noficinas.Add(1) '' Esta OFICINA SE AGREGA PARA QUE CARGUE EL DEFAULT QUE NINGUNO

        Dim oVar = From rie As riesgo In context.riesgos
                   Order By rie.nombre Ascending
                   Where noficinas.Contains(rie.oficina)
                   Select New With {.grupo = rie.grupo, .nombre = rie.nombre}

        If oVar.Count() > 0 Then
          oriesgo = oVar.ToList().Select(Function(s) New GrupoNombre_Result With {.grupo = s.grupo, .nombre = s.nombre.Trim}).ToList()
        Else
          oriesgo = New List(Of GrupoNombre_Result)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oriesgo = New List(Of GrupoNombre_Result)
      End Try
      Return oriesgo
    End Function

    Public Function Selectriesgo(ByVal grupo As Decimal) As riesgo
      Dim oriesgo As riesgo = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From rie As riesgo In context.riesgos
                   Where rie.grupo = grupo
                   Select rie

        If oVar.Count() > 0 Then
          oriesgo = oVar.First()
        Else
          oriesgo = New riesgo()
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oriesgo = New riesgo()
      End Try
      Return oriesgo
    End Function

    Public Function SelectRiesgoXNombreXGrupo(ByVal grupo As Decimal?, Optional Nombre As String = "{string.value.null}") As List(Of riesgo)
      Dim oRiesgoLst As List(Of riesgo) = Nothing
      Dim oVar As System.Linq.IQueryable(Of riesgo) = Nothing
      Try
        MyBase.Start_context()
        If (Nombre <> "{string.value.null}") Then
          Nombre = Nombre.Replace("%", "")
          oVar = From rie As riesgo In context.riesgos
                 Where SqlMethods.Like(rie.nombre, Nombre.Trim + "%")
                 Order By rie.nombre

        Else
          oVar = From rie As riesgo In context.riesgos
                 Where rie.grupo = If(grupo IsNot Nothing, grupo, rie.grupo)
                 Order By rie.grupo

        End If
        If (oVar.Count > 0) Then
          oRiesgoLst = oVar.Take(5).ToList()
        Else
          oRiesgoLst = New List(Of riesgo)
        End If

      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oRiesgoLst = New List(Of riesgo)

      End Try
      Return oRiesgoLst
    End Function

    Public Function SelectRiesgoXNombreXGrupoOficina(ByVal grupo As Decimal?, Optional ByVal nombre As String = Nothing, Optional ByVal oficinas As String = Nothing) As List(Of sp_RiesgoBusquedaXNombreXGrupo_Result)
      Dim oRiesgo As List(Of sp_RiesgoBusquedaXNombreXGrupo_Result) = Nothing
      Try
        MyBase.Start_context()
        oRiesgo = context.sp_RiesgoBusquedaXNombreXGrupo(grupo, nombre, oficinas).ToList
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oRiesgo = New List(Of sp_RiesgoBusquedaXNombreXGrupo_Result)
      End Try
      Return oRiesgo
    End Function

    Public Function Submit(ByRef riesgo As riesgo, ByRef oficina As Integer) As Boolean
      Dim bTrans As Boolean = False
      Try
        Dim dgrupo = riesgo.grupo
        MyBase.Start_context()
        Dim oriesgo = From r As riesgo In context.riesgos
                      Where r.grupo = dgrupo AndAlso r.grupo > 0
                      Select r
        
        If oriesgo.Count() > 0 Then
          Me.oOririesgoOuBx = oriesgo.Single()
          For Each prop In riesgo.GetType.GetProperties.ToList
            prop.SetValue(oriesgo.Single(), prop.GetValue(riesgo))
          Next
          context.SaveChanges()
          bTrans = True
        Else
          context.sp_Nuevo_Riesgo(oficina, riesgo.grupo)
          oNewriesgoOuBx = riesgo
          context.riesgos.Add(riesgo)
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

    Public Function Submit(ByRef riesgos As List(Of riesgo), ByRef oficina As Integer) As Boolean
      Dim bTrans As Boolean = False

      Try
        Dim noficina = oficina
        MyBase.Start_context()

        Dim oLlaves = riesgos.Select(Function(s) s.grupo).ToList()

        Dim oriesgos = From r As riesgo In context.riesgos
                       Where oLlaves.Contains(r.grupo) AndAlso r.grupo > 0
                       Select r

        If oriesgos.Count() > 0 Then
          If Not Me._oNewriesgosOuBx Is Nothing Then Me._oNewriesgosOuBx = Nothing
          Me.oOririesgosOuBx = oriesgos.ToList()

          Dim props = riesgos.ElementAt(0).GetType().GetProperties()
          Dim oInsert As New List(Of riesgo)          

          For Each oUpdate As riesgo In oriesgos.ToList()
            Dim oriesgo = riesgos.Where(Function(w) w.grupo = oUpdate.grupo)
            If oriesgo.Count() > 0 Then
              For Each oprop As System.Reflection.PropertyInfo In props
                oprop.SetValue(oUpdate, oprop.GetValue(oriesgo.Single()))
              Next
            Else
              oInsert.Add(oUpdate)
            End If
          Next

          If oInsert.Count() > 0 Then
            For Each oriesgo As riesgo In oInsert.ToList()
              context.sp_Nuevo_Riesgo(noficina, oriesgo.grupo)
              Me.oNewriesgosOuBx_add = oriesgo
            Next
            context.riesgos.AddRange(DirectCast(oInsert.ToList(), IEnumerable(Of riesgo)))
          End If

          context.SaveChanges()
          bTrans = True

        Else
          For Each oNewRie As riesgo In riesgos
            context.sp_Nuevo_Riesgo(noficina, oNewRie.grupo)
          Next
          Me.oNewriesgosOuBx = riesgos
          context.riesgos.AddRange(DirectCast(riesgos, IEnumerable(Of riesgo)))
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

  End Class
End Namespace
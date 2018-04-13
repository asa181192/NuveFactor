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

  Public Class oficinaDL
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

    Private _oNewOficinaOuBx As oficina
    Public Property oNewOficinaOuBx() As oficina
      Get
        Return Me._oNewOficinaOuBx
      End Get
      Set(value As oficina)
        If Not Me._oNewOficinaOuBx Is Nothing Then Me._oNewOficinaOuBx = Nothing
        Me._oNewOficinaOuBx = New oficina()
        For Each prop As System.Reflection.PropertyInfo In value.GetType.GetProperties.ToList()
          prop.SetValue(_oNewOficinaOuBx, prop.GetValue(value))
        Next
      End Set
    End Property

    Private _oNewOficinasOuBx As List(Of oficina)
    Public Property oNewOficinasOuBx() As List(Of oficina)
      Get
        Return Me._oNewOficinasOuBx
      End Get
      Set(value As List(Of oficina))
        If Not Me._oNewOficinasOuBx Is Nothing Then Me._oNewOficinasOuBx = Nothing
        Me._oNewOficinasOuBx = New List(Of oficina)
        For Each clie As oficina In value
          Dim c As New oficina()
          For Each prop As System.Reflection.PropertyInfo In clie.GetType.GetProperties.ToList()
            prop.SetValue(c, prop.GetValue(clie))
          Next
          Me._oNewOficinasOuBx.Add(c)
          c = Nothing
        Next
      End Set
    End Property
    Public WriteOnly Property oNewOficinasOuBx_add() As oficina
      Set(ByVal value As oficina)
        If Me._oNewOficinasOuBx Is Nothing Then Me._oNewOficinasOuBx = New List(Of oficina)
        Me._oNewOficinasOuBx.Add(value)
      End Set
    End Property

    Private _oOriOficinaOuBx As oficina
    Public Property oOriOficinaOuBx() As oficina
      Get
        Return Me._oOriOficinaOuBx
      End Get
      Set(value As oficina)
        If Not Me._oOriOficinaOuBx Is Nothing Then Me._oOriOficinaOuBx = Nothing
        Me._oOriOficinaOuBx = New oficina()
        For Each prop As System.Reflection.PropertyInfo In value.GetType.GetProperties.ToList()
          prop.SetValue(_oOriOficinaOuBx, prop.GetValue(value))
        Next
      End Set
    End Property

    Private _oOriOficinasOuBx As List(Of oficina)
    Public Property oOriOficinasOuBx() As List(Of oficina)
      Get
        Return Me._oOriOficinasOuBx
      End Get
      Set(value As List(Of oficina))
        If Not Me._oOriOficinasOuBx Is Nothing Then Me._oOriOficinasOuBx = Nothing
        Me._oOriOficinasOuBx = New List(Of oficina)
        For Each clie As oficina In value
          Dim c As New oficina()
          For Each prop As System.Reflection.PropertyInfo In clie.GetType.GetProperties.ToList()
            prop.SetValue(c, prop.GetValue(clie))
          Next
          Me._oOriOficinasOuBx.Add(c)
          c = Nothing
        Next
      End Set
    End Property

    Public Function SelectOficina() As List(Of oficina)
      Dim ooficinas As List(Of oficina) = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From ofis As oficina In context.oficinas
                   Select ofis

        If oVar.Count() > 0 Then
          ooficinas = oVar.ToList()
        Else
          ooficinas = New List(Of oficina)
        End If

      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        ooficinas = New List(Of oficina)
      End Try

      Return ooficinas
    End Function

    Public Function SelectOficina(ByVal ofi As Decimal) As oficina
      Dim ooficina As oficina = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From ofis As oficina In context.oficinas
                   Where ofis.oficina_id = ofi
                   Select ofis

        If oVar.Count > 0 Then
          ooficina = oVar.Single()
        Else
          ooficina = New oficina()
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        ooficina = New oficina()
      End Try
      Return ooficina
    End Function

    Public Function SelectOficinaxOrigen(ByVal origen As Decimal) As List(Of oficina)
      Dim ooficinas As List(Of oficina) = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From ofis As oficina In context.oficinas
                   Where ofis.origen = origen
                   Select ofis

        If oVar.Count() > 0 Then
          ooficinas = oVar.ToList()
        Else
          ooficinas = New List(Of oficina)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        ooficinas = New List(Of oficina)
      End Try
      Return ooficinas
    End Function

    Public Function Submit(ByRef oficina As oficina) As Boolean
      Dim bTrans As Boolean = False

      Try
        Dim doficina = oficina.oficina_id
        MyBase.Start_context()

        Dim ooficina = From o As oficina In context.oficinas
                       Where o.oficina_id = doficina AndAlso o.oficina_id > 0
                       Select o

        Me.oNewOficinaOuBx = oficina

        If (ooficina.Count() > 0) Then
          Me.oOriOficinaOuBx = ooficina.Single()

          For Each prop In oficina.GetType.GetProperties.ToList
            prop.SetValue(ooficina.Single(), prop.GetValue(oficina))
          Next

          context.SaveChanges()
          bTrans = True
        Else
          context.oficinas.Add(oficina)
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

    Public Function Submit(ByRef oficinas As List(Of oficina)) As Boolean
      Dim bTrans As Boolean = False

      Try
        MyBase.Start_context()
        Dim oLlaves = oficinas.Select(Function(s) s.oficina_id).ToList()

        Dim oOficinas = From o As oficina In context.oficinas
                        Where oLlaves.Contains(o.oficina_id) AndAlso o.oficina_id > 0
                        Select o

        If (oOficinas.Count() > 0) Then
          If Not Me._oNewOficinasOuBx Is Nothing Then Me._oNewOficinasOuBx = Nothing
          Me.oOriOficinasOuBx = oOficinas.ToList()

          Dim props = oficinas.ElementAt(0).GetType().GetProperties()
          Dim oInsert As New List(Of oficina)          

          For Each oUpdate As oficina In oOficinas.ToList()
            Dim oofi = oficinas.Where(Function(w) w.oficina_id = oUpdate.oficina_id)
            If oofi.Count() > 0 Then
              For Each prop As System.Reflection.PropertyInfo In props.ToList()
                prop.SetValue(oUpdate, prop.GetValue(oofi.Single()))
              Next              
            Else
              oInsert.Add(oUpdate)
            End If
          Next

          If (oInsert.Count() > 0) Then
            For Each oofi In oInsert.ToList()
              Me.oNewOficinasOuBx_add = oofi
            Next
            context.oficinas.AddRange(DirectCast(oInsert.ToList(), IEnumerable(Of oficina)))
          End If

          context.SaveChanges()
          bTrans = True

        Else
          Me.oNewOficinasOuBx = oficinas
          context.oficinas.AddRange(DirectCast(oficinas, IEnumerable(Of oficina)))
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
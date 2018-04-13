Imports System
Imports System.Data
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports Negocio.Validaciones
Imports System.Reflection
Imports Entidades
Imports Entidades.arrendadora

Namespace arrendadoraBL
  Public Class riesgoBL
    Inherits arrendadora.riesgo

    Private Campos As System.Collections.Generic.IEnumerable(Of System.Xml.XmlNode)
    Private sConsLlave As List(Of String) = New List(Of String)({"grupo"})
    Private schanges As String
    Private schangeslst As List(Of String)

    Public Property oNewriesgoOuBx() As riesgo
    Public Property oNewriesgosOuBx() As List(Of riesgo)
    Public Property oOririesgoOuBx() As riesgo
    Public Property oOririesgosOuBx() As List(Of riesgo)

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

    Public Property PaqueteValidacion() As List(Of PaqueteValidacion)

    Public Overrides Function getSaldoInsolutoRiesgo(ByVal riesgo As Integer) As Decimal
      Return MyBase.getSaldoInsolutoRiesgo(riesgo)
    End Function

    Public Overrides Function Selectriesgo() As List(Of riesgo)
      Return MyBase.Normaliza(MyBase.Selectriesgo())
    End Function

    Public Overrides Function SelectGrupoNombre(ByVal oficinas As String) As List(Of GrupoNombre_Result)
      Return MyBase.SelectGrupoNombre(oficinas)
    End Function

    Public Overrides Function Selectriesgo(ByVal grupo As Decimal) As riesgo
      Return MyBase.Normaliza(MyBase.Selectriesgo(grupo))
    End Function

    Public Overrides Function SelectRiesgoXNombreXGrupo(ByVal grupo As Decimal?, Optional Nombre As String = "{string.value.null}") As List(Of riesgo)
      Return MyBase.Normaliza(MyBase.SelectRiesgoXNombreXGrupo(grupo, Nombre))
    End Function

    Public Overrides Function SelectRiesgoXNombreXGrupoOficina(ByVal grupo As Decimal?, Optional ByVal nombre As String = Nothing, Optional ByVal oficinas As String = Nothing) As List(Of sp_RiesgoBusquedaXNombreXGrupo_Result)
      Return MyBase.Normaliza(MyBase.SelectRiesgoXNombreXGrupoOficina(grupo, nombre, oficinas))
    End Function

    Public Overrides Function Submit(ByRef riesgo As Entidades.arrendadora.riesgo, ByRef oficina As Integer) As Boolean
      Dim bTrans As Boolean = False
      MyBase.Normaliza(riesgo)
      bTrans = MyBase.Submit(riesgo, oficina)
      Me.oNewriesgoOuBx = MyBase.riesgoDL.oNewriesgoOuBx
      Me.oOririesgoOuBx = MyBase.riesgoDL.oOririesgoOuBx
      Return bTrans
    End Function

    Public Overrides Function Submit(ByRef riesgos As List(Of Entidades.arrendadora.riesgo), ByRef oficina As Integer) As Boolean
      Dim bTrans As Boolean = False
      MyBase.Normaliza(riesgos)
      bTrans = MyBase.Submit(riesgos, oficina)
      Me.oNewriesgosOuBx = MyBase.riesgoDL.oNewriesgosOuBx
      Me.oOririesgosOuBx = MyBase.riesgoDL.oOririesgosOuBx
      Return bTrans
    End Function

    Public Function Validariesgo(ByVal riesgo As riesgo) As Boolean
      Dim bValida As Boolean = False
      Dim oPaqueteVal As New PaqueteValidacion
      Dim oProps = riesgo.GetType().GetProperties()

      With oPaqueteVal
        .Aprovado = True
        .Entidad = riesgo
        For Each oProp As System.Reflection.PropertyInfo In oProps
          Dim oComentario As Comentario = Nothing

          Select Case oProp.Name
            Case Is = "grupo"
              oComentario = Metodos.ValidaNumero(1, riesgo, oProp, False, False, -1, -1)
            Case Is = "nombre"
              oComentario = Metodos.ValidaCadena(2, riesgo, oProp, False, True, 40)
            Case Is = "domicilio"
              oComentario = Metodos.ValidaCadena(3, riesgo, oProp, False, True, 2147483647)
            Case Is = "colonia"
              oComentario = Metodos.ValidaCadena(4, riesgo, oProp, False, True, 2147483647)
            Case Is = "municipio"
              oComentario = Metodos.ValidaCadena(5, riesgo, oProp, False, True, 2147483647)
            Case Is = "estado"
              oComentario = Metodos.ValidaCadena(6, riesgo, oProp, False, True, 2147483647)
            Case Is = "cp"
              oComentario = Metodos.ValidaNumero(7, riesgo, oProp, False, False, -1, -1)
            Case Is = "tels"
              oComentario = Metodos.ValidaCadena(8, riesgo, oProp, False, True, 2147483647)
            Case Is = "socios"
              oComentario = Metodos.ValidaCadena(9, riesgo, oProp, False, True, 2147483647)
            Case Is = "actividad"
              oComentario = Metodos.ValidaCadena(10, riesgo, oProp, False, True, 2147483647)
            Case Is = "cltedesde"
              oComentario = Metodos.ValidaFecha(11, riesgo, oProp, False)
            Case Is = "void"
              oComentario = Metodos.ValidaBoleano(12, riesgo, oProp, False)
            Case Is = "oficina"
              oComentario = Metodos.ValidaNumero(13, riesgo, oProp, True, True, -1, -1)
          End Select

          If oComentario Is Nothing Then oComentario = New Negocio.Validaciones.Comentario(0, oProp.PropertyType, oProp, "")

          If oComentario.Comentario.Trim.Length > 0 Then
            oPaqueteVal.Aprovado = False
            If oPaqueteVal.Comentarios Is Nothing Then oPaqueteVal.Comentarios = New List(Of Comentario)
            oPaqueteVal.Comentarios.Add(New Comentario(i:=oComentario.Indice, Tipo:=oComentario.Tipo, Campo:=oComentario.Campo, Cometario:=oComentario.Comentario))
          End If

          oComentario.Dispose()
        Next
      End With

      bValida = oPaqueteVal.Aprovado
      If oPaqueteVal.Comentarios Is Nothing Then oPaqueteVal.Comentarios = New List(Of Comentario)
      If Me.PaqueteValidacion Is Nothing Then Me.PaqueteValidacion = New List(Of PaqueteValidacion)
      Me.PaqueteValidacion.Add(New PaqueteValidacion(Entidad:=oPaqueteVal.Entidad, Aprovado:=oPaqueteVal.Aprovado, Comentarios:=oPaqueteVal.Comentarios))
      oPaqueteVal.Dispose()

      Return bValida
    End Function

    Public Function Validariesgos(ByVal riesgos As List(Of riesgo)) As Boolean
      Dim bValida As Boolean = True
      For Each oInst As riesgo In riesgos
        bValida = bValida And Me.Validariesgo(oInst)
      Next
      Return bValida
    End Function

    Public Function GeneraOutbox(ByVal oficina As Integer, Optional ByVal campos As String = "") As Boolean
      Dim bTrans As Boolean = False

      Try
        If Not Me.oNewriesgoOuBx Is Nothing Then MyBase.riesgoDL.oNewriesgoOuBx = Me.oNewriesgoOuBx
        If Not Me.oNewriesgosOuBx Is Nothing Then MyBase.riesgoDL.oNewriesgosOuBx = Me.oNewriesgosOuBx
        If Not Me.oOririesgoOuBx Is Nothing Then MyBase.riesgoDL.oOririesgoOuBx = Me.oOririesgoOuBx
        If Not Me.oOririesgosOuBx Is Nothing Then MyBase.riesgoDL.oOririesgosOuBx = Me.oOririesgosOuBx

        If campos.Trim.Length > 0 Then
          sConsLlave.AddRange(campos.Split(",").ToList.Where(Function(w) Not sConsLlave.Select(Function(s) s.ToLower).ToList.Contains(w.ToLower)).ToList)
        End If

        If Not Me.oNewriesgoOuBx Is Nothing Then
          MyBase.CargaXML(oNewriesgoOuBx.GetType().Name)
          Dim oProps = oNewriesgoOuBx.GetType().GetProperties()
          If oOririesgoOuBx Is Nothing Then
            schanges = ""
            For Each prop As System.Reflection.PropertyInfo In oProps
              schanges &= MyBase.GenerarOutbox(prop, oNewriesgoOuBx)
            Next
          Else
            schanges = MyBase.ChangesOutbox(oOririesgoOuBx, oNewriesgoOuBx, sConsLlave)
          End If
          bTrans = MyBase.Outbox(oficina, "RIESGO", "GRUPO", "M.GRUPO", schanges)
          MyBase.LiberaXML()
        End If

        If Not Me.oNewriesgosOuBx Is Nothing Then
          MyBase.CargaXML(Me.oNewriesgosOuBx.ElementAt(0).GetType().Name)
          Dim oProps = Me.oNewriesgosOuBx.ElementAt(0).GetType().GetProperties()
          If Not schangeslst Is Nothing Then schangeslst = Nothing
          schangeslst = New List(Of String)
          If oOririesgosOuBx Is Nothing Then
            For Each riesgo As riesgo In Me.oNewriesgosOuBx
              schanges = ""
              For Each prop As System.Reflection.PropertyInfo In oProps
                schanges &= MyBase.GenerarOutbox(prop, riesgo)
              Next
              schangeslst.Add(schanges)
            Next
          Else
            For Each Newriesgo As riesgo In oNewriesgosOuBx
              Dim oOldriesgo = oOririesgosOuBx.Where(Function(w) w.grupo = Newriesgo.grupo)
              schanges = ""
              If oOldriesgo.Count() > 0 Then
                schanges = MyBase.ChangesOutbox(oOldriesgo.Single, Newriesgo, sConsLlave)
              Else
                For Each prop As System.Reflection.PropertyInfo In oProps
                  schanges &= MyBase.GenerarOutbox(prop, Newriesgo)
                Next
              End If
              schangeslst.Add(schanges)
            Next
          End If
          bTrans = MyBase.Outbox(oficina, "RIESGO", "GRUPO", "M.GRUPO", schangeslst)
          MyBase.LiberaXML()
        End If
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        ElseIf ex.Message = "Error negocio" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        bTrans = False
      End Try

      Return bTrans
    End Function

  End Class
End Namespace
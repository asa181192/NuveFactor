Imports System
Imports System.Data
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports Negocio.Validaciones
Imports Entidades
Imports Entidades.arrendadora

Namespace arrendadoraBL

  Public Class oficinaBL
    Inherits arrendadora.oficina

    Private Campos As System.Collections.Generic.IEnumerable(Of System.Xml.XmlNode)
    Private sConsLlave As List(Of String) = New List(Of String)({"oficina"})
    Private schanges As String
    Private schangeslst As List(Of String)

    Public Property oNewOficinaOuBx() As oficina
    Public Property oNewOficinasOuBx() As List(Of oficina)
    Public Property oOriOficinaOuBx() As oficina
    Public Property oOriOficinasOuBx() As List(Of oficina)

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

    Public Overrides Function SelectOficina() As List(Of oficina)
      Return MyBase.Normaliza(MyBase.SelectOficina())
    End Function

    Public Overrides Function SelectOficina(ByVal ofi As Decimal) As oficina
      Return MyBase.Normaliza(MyBase.SelectOficina(ofi))
    End Function

    Public Overrides Function SelectOficinaxOrigen(ByVal origen As Decimal) As List(Of oficina)
      Return MyBase.Normaliza(MyBase.SelectOficinaxOrigen(origen))
    End Function

    Public Overrides Function Submit(ByRef oficina As oficina) As Boolean
      Dim oTrans As Boolean = False
      MyBase.Normaliza(oficina)
      oTrans = MyBase.Submit(oficina)
      Me.oNewOficinaOuBx = MyBase.oficinaDL.oNewOficinaOuBx
      Me.oOriOficinaOuBx = MyBase.oficinaDL.oOriOficinaOuBx
      Return oTrans
    End Function

    Public Overrides Function Submit(ByRef oficinas As List(Of oficina)) As Boolean
      Dim oTrans As Boolean = False
      MyBase.Normaliza(oficinas)
      oTrans = MyBase.Submit(oficinas)
      Me.oNewOficinasOuBx = Me.oficinaDL.oNewOficinasOuBx
      Me.oOriOficinasOuBx = Me.oficinaDL.oOriOficinasOuBx
      Return oTrans
    End Function

    Public Function GeneraOutbox(ByVal oficina As Integer, Optional ByVal campos As String = "") As Boolean
      Dim bTrans As Boolean = False

      Try
        If Not Me.oNewOficinaOuBx Is Nothing Then Me.oficinaDL.oNewOficinaOuBx = Me.oNewOficinaOuBx
        If Not Me.oNewOficinasOuBx Is Nothing Then Me.oficinaDL.oNewOficinasOuBx = Me.oNewOficinasOuBx
        If Not Me.oOriOficinaOuBx Is Nothing Then Me.oficinaDL.oOriOficinaOuBx = Me.oOriOficinaOuBx
        If Not Me.oOriOficinasOuBx Is Nothing Then Me.oficinaDL.oOriOficinasOuBx = Me.oOriOficinasOuBx

        If campos.Trim.Length > 0 Then
          sConsLlave.AddRange(campos.Split(",").ToList.Where(Function(w) Not sConsLlave.Select(Function(s) s.ToLower).ToList.Contains(w.ToLower)).ToList)
        End If

        If Not Me.oNewOficinaOuBx Is Nothing Then
          MyBase.CargaXML(oNewOficinaOuBx.GetType().Name)
          Dim oProps = Me.oNewOficinaOuBx.GetType().GetProperties()
          If Me.oOriOficinaOuBx Is Nothing Then
            schanges = ""
            For Each prop As System.Reflection.PropertyInfo In oProps
              schanges &= MyBase.GenerarOutbox(prop, Me.oNewOficinaOuBx)
            Next
          Else
            schanges &= MyBase.ChangesOutbox(Me.oOriOficinaOuBx, Me.oNewOficinaOuBx, sConsLlave)
          End If
          bTrans = MyBase.Outbox(oficina, "OFICINAS", "OFICINA", "M.OFICINA", schanges)
          MyBase.LiberaXML()
        End If

        If Not Me.oNewOficinasOuBx Is Nothing Then
          MyBase.CargaXML(Me.oNewOficinasOuBx.ElementAt(0).GetType().Name)
          Dim oProps = Me.oNewOficinasOuBx.ElementAt(0).GetType().GetProperties()
          If Not schangeslst Is Nothing Then schangeslst = Nothing
          schangeslst = New List(Of String)
          If Me.oOriOficinasOuBx Is Nothing Then
            For Each ofi As oficina In Me.oNewOficinasOuBx
              schanges = ""
              For Each prop As System.Reflection.PropertyInfo In oProps
                schanges &= MyBase.GenerarOutbox(prop, ofi)
              Next
              schangeslst.Add(schanges)
            Next
          Else
            For Each Newofi As oficina In Me.oNewOficinasOuBx
              Dim oOldofi = Me.oOriOficinasOuBx.Where(Function(w) w.oficina_id = Newofi.oficina_id)
              schanges = ""
              If (oOldofi.Count() > 0) Then
                schanges = MyBase.ChangesOutbox(oOldofi.Single(), Newofi, sConsLlave)
              Else
                For Each prop As System.Reflection.PropertyInfo In oProps
                  schanges &= MyBase.GenerarOutbox(prop, Newofi)
                Next
              End If
              schangeslst.Add(schanges)
            Next
          End If
          bTrans = MyBase.Outbox(oficina, "OFICINAS", "OFICINA", "M.OFICINA", schangeslst)
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

    Public Function Validaoficina(ByVal oficina As oficina) As Boolean
      Dim bValida As Boolean = False
      Dim oPaqueteVal As New PaqueteValidacion
      Dim oProps = oficina.GetType().GetProperties()

      With oPaqueteVal
        .Aprovado = True
        .Entidad = oficina
        For Each oProp As System.Reflection.PropertyInfo In oProps
          Dim oComentario As Comentario = Nothing

          Select Case oProp.Name
            Case Is = "clave"
              oComentario = Metodos.ValidaCadena(1, oficina, oProp, False, True, 2)
            Case Is = "origen"
              oComentario = Metodos.ValidaNumero(2, oficina, oProp, False, True, -1, -1)
            Case Is = "oficina_id"
              oComentario = Metodos.ValidaNumero(3, oficina, oProp, False, True, -1, -1)
            Case Is = "folio"
              oComentario = Metodos.ValidaNumero(4, oficina, oProp, False, True, -1, -1)
            Case Is = "nombre"
              oComentario = Metodos.ValidaCadena(5, oficina, oProp, False, True, 20)
            Case Is = "tasaiva"
              oComentario = Metodos.ValidaNumero(6, oficina, oProp, False, True, -1, -1)
            Case Is = "s_domic"
              oComentario = Metodos.ValidaCadena(7, oficina, oProp, False, True, 50)
            Case Is = "s_colonia"
              oComentario = Metodos.ValidaCadena(8, oficina, oProp, False, True, 40)
            Case Is = "s_ciudad"
              oComentario = Metodos.ValidaCadena(9, oficina, oProp, False, True, 40)
            Case Is = "s_emitido"
              oComentario = Metodos.ValidaCadena(10, oficina, oProp, False, True, 40)
            Case Is = "c_domic"
              oComentario = Metodos.ValidaCadena(11, oficina, oProp, False, True, 60)
            Case Is = "c_colonia"
              oComentario = Metodos.ValidaCadena(12, oficina, oProp, False, True, 40)
            Case Is = "c_ciudad"
              oComentario = Metodos.ValidaCadena(13, oficina, oProp, False, True, 50)
            Case Is = "c_municipio"
              oComentario = Metodos.ValidaCadena(14, oficina, oProp, True, True, 40)
            Case Is = "c_estado"
              oComentario = Metodos.ValidaCadena(15, oficina, oProp, True, True, 40)
            Case Is = "c_cp"
              oComentario = Metodos.ValidaNumero(16, oficina, oProp, True, True, -1, -1)
            Case Is = "representante"
              oComentario = Metodos.ValidaCadena(17, oficina, oProp, False, True, 50)
            Case Is = "correo_repre"
              oComentario = Metodos.ValidaCadena(18, oficina, oProp, False, True, 50)
            Case Is = "c_telefonos"
              oComentario = Metodos.ValidaCadena(19, oficina, oProp, False, True, 2147483647)
            Case Is = "print_ofic"
              oComentario = Metodos.ValidaBoleano(20, oficina, oProp, False)
            Case Is = "path_sucur"
              oComentario = Metodos.ValidaCadena(21, oficina, oProp, False, True, 2147483647)
            Case Is = "path_bnc_in"
              oComentario = Metodos.ValidaCadena(22, oficina, oProp, False, True, 2147483647)
            Case Is = "path_bnc_loaded"
              oComentario = Metodos.ValidaCadena(23, oficina, oProp, False, True, 2147483647)
            Case Is = "path_xch_out"
              oComentario = Metodos.ValidaCadena(24, oficina, oProp, False, True, 2147483647)
            Case Is = "path_xch_sent"
              oComentario = Metodos.ValidaCadena(25, oficina, oProp, False, True, 2147483647)
            Case Is = "bncgenera"
              oComentario = Metodos.ValidaBoleano(26, oficina, oProp, False)
            Case Is = "cons_in"
              oComentario = Metodos.ValidaNumero(27, oficina, oProp, False, True, -1, -1)
            Case Is = "cons_out"
              oComentario = Metodos.ValidaNumero(28, oficina, oProp, False, True, -1, -1)
            Case Is = "fec_cont"
              oComentario = Metodos.ValidaFecha(29, oficina, oProp, False)
            Case Is = "lista_conts"
              oComentario = Metodos.ValidaCadena(30, oficina, oProp, False, True, 2147483647)
            Case Is = "fec_tesore"
              oComentario = Metodos.ValidaFecha(31, oficina, oProp, False)
            Case Is = "expediente"
              oComentario = Metodos.ValidaCadena(32, oficina, oProp, False, True, 20)
            Case Is = "ratifija"
              oComentario = Metodos.ValidaNumero(33, oficina, oProp, False, True, -1, -1)
            Case Is = "ratibase"
              oComentario = Metodos.ValidaNumero(34, oficina, oProp, False, True, -1, -1)
            Case Is = "ratimillar"
              oComentario = Metodos.ValidaNumero(35, oficina, oProp, False, True, -1, -1)
            Case Is = "raticalc"
              oComentario = Metodos.ValidaBoleano(36, oficina, oProp, False)
            Case Is = "void"
              oComentario = Metodos.ValidaBoleano(37, oficina, oProp, False)
            Case Is = "u_cliente"
              oComentario = Metodos.ValidaNumero(38, oficina, oProp, True, True, -1, -1)
            Case Is = "u_refer"
              oComentario = Metodos.ValidaNumero(39, oficina, oProp, True, True, -1, -1)
            Case Is = "u_riesgo"
              oComentario = Metodos.ValidaNumero(40, oficina, oProp, True, True, -1, -1)
            Case Is = "u_poliza"
              oComentario = Metodos.ValidaNumero(41, oficina, oProp, True, True, -1, -1)
            Case Is = "u_demanda"
              oComentario = Metodos.ValidaNumero(42, oficina, oProp, True, True, -1, -1)
            Case Is = "u_etapa"
              oComentario = Metodos.ValidaNumero(43, oficina, oProp, True, True, -1, -1)
            Case Is = "u_abogado"
              oComentario = Metodos.ValidaNumero(44, oficina, oProp, True, True, -1, -1)
            Case Is = "u_linea"
              oComentario = Metodos.ValidaNumero(45, oficina, oProp, True, True, -1, -1)
            Case Is = "u_orden"
              oComentario = Metodos.ValidaNumero(46, oficina, oProp, True, True, -1, -1)
            Case Is = "apoderado"
              oComentario = Metodos.ValidaCadena(47, oficina, oProp, True, True, 2147483647)
            Case Is = "testigo1"
              oComentario = Metodos.ValidaCadena(48, oficina, oProp, True, True, 2147483647)
            Case Is = "testigo2"
              oComentario = Metodos.ValidaCadena(49, oficina, oProp, True, True, 2147483647)
            Case Is = "placas"
              oComentario = Metodos.ValidaCadena(50, oficina, oProp, True, True, 2147483647)
            Case Is = "salidas"
              oComentario = Metodos.ValidaCadena(51, oficina, oProp, True, True, 2147483647)
            Case Is = "seguro"
              oComentario = Metodos.ValidaCadena(52, oficina, oProp, True, True, 2147483647)
            Case Is = "notarionum"
              oComentario = Metodos.ValidaNumero(53, oficina, oProp, True, True, -1, -1)
            Case Is = "notarionom"
              oComentario = Metodos.ValidaCadena(54, oficina, oProp, True, True, 2147483647)
            Case Is = "notariociu"
              oComentario = Metodos.ValidaCadena(55, oficina, oProp, True, True, 2147483647)
            Case Is = "jurisdic"
              oComentario = Metodos.ValidaCadena(56, oficina, oProp, True, True, 2147483647)
            Case Is = "serie_ini"
              oComentario = Metodos.ValidaCadena(57, oficina, oProp, True, True, 3)
            Case Is = "serie_ncc"
              oComentario = Metodos.ValidaCadena(58, oficina, oProp, True, True, 3)
            Case Is = "chd_serie"
              oComentario = Metodos.ValidaCadena(59, oficina, oProp, True, True, 3)
            Case Is = "u_notacc"
              oComentario = Metodos.ValidaNumero(60, oficina, oProp, True, True, -1, -1)
            Case Is = "u_numchd"
              oComentario = Metodos.ValidaNumero(61, oficina, oProp, True, True, -1, -1)
            Case Is = "u_folio"
              oComentario = Metodos.ValidaNumero(62, oficina, oProp, True, True, -1, -1)
            Case Is = "com_prepag"
              oComentario = Metodos.ValidaNumero(63, oficina, oProp, True, True, -1, -1)
            Case Is = "cierrecont"
              oComentario = Metodos.ValidaBoleano(64, oficina, oProp, True)
            Case Is = "u_ficha"
              oComentario = Metodos.ValidaNumero(65, oficina, oProp, True, True, -1, -1)
            Case Is = "regional"
              oComentario = Metodos.ValidaNumero(66, oficina, oProp, True, True, -1, -1)
            Case Is = "correo_operativo"
              oComentario = Metodos.ValidaCadena(67, oficina, oProp, True, True, 50)
            Case Is = "u_caratula"
              oComentario = Metodos.ValidaNumero(68, oficina, oProp, True, True, -1, -1)
            Case Is = "id_tren"
              oComentario = Metodos.ValidaNumero(69, oficina, oProp, True, True, -1, -1)
            Case Is = "corto"
              oComentario = Metodos.ValidaCadena(70, oficina, oProp, True, True, 6)
            Case Is = "robot_sync"
              oComentario = Metodos.ValidaFecha(71, oficina, oProp, True)
            Case Is = "difhorario"
              oComentario = Metodos.ValidaNumero(72, oficina, oProp, True, True, -1, -1)
            Case Is = "id_plaza"
              oComentario = Metodos.ValidaNumero(73, oficina, oProp, True, True, -1, -1)
            Case Is = "division"
              oComentario = Metodos.ValidaCadena(74, oficina, oProp, True, True, 4)
            Case Is = "cond_mora"
              oComentario = Metodos.ValidaNumero(75, oficina, oProp, True, True, -1, -1)
            Case Is = "u_credito"
              oComentario = Metodos.ValidaNumero(76, oficina, oProp, True, True, -1, -1)
            Case Is = "u_promotor"
              oComentario = Metodos.ValidaNumero(77, oficina, oProp, True, True, -1, -1)
            Case Is = "u_proveedor"
              oComentario = Metodos.ValidaNumero(78, oficina, oProp, True, True, -1, -1)
            Case Is = "u_factprov"
              oComentario = Metodos.ValidaNumero(79, oficina, oProp, True, True, -1, -1)
            Case Is = "u_cfd"
              oComentario = Metodos.ValidaNumero(80, oficina, oProp, True, True, -1, -1)
            Case Is = "fec_contra"
              oComentario = Metodos.ValidaFecha(81, oficina, oProp, False)
            Case Is = "u_efactura"
              oComentario = Metodos.ValidaNumero(82, oficina, oProp, True, True, -1, -1)
            Case Is = "serie_efac"
              oComentario = Metodos.ValidaCadena(83, oficina, oProp, True, True, 3)
            Case Is = "orden_region"
              oComentario = Metodos.ValidaNumero(84, oficina, oProp, True, True, -1, -1)
            Case Is = "run_process"
              oComentario = Metodos.ValidaBoleano(85, oficina, oProp, True)
            Case Is = "u_interfas"
              oComentario = Metodos.ValidaNumero(97, oficina, oProp, True, False, -1, -1)
            Case Is = "puesto"
              oComentario = Metodos.ValidaCadena(98, oficina, oProp, True, True, 40)
            Case Is = "conomina"
              oComentario = Metodos.ValidaCadena(99, oficina, oProp, True, True, 40)
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

    Public Function Validaoficinas(ByVal oficinas As List(Of oficina)) As Boolean
      Dim bValida As Boolean = True
      For Each oClass As oficina In oficinas
        bValida = bValida And Me.Validaoficina(oClass)
      Next
      Return bValida
    End Function

  End Class

End Namespace
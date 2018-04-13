Imports System
Imports System.Data
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports Negocio.Validaciones
Imports Entidades
Imports Entidades.arrendadora

Namespace arrendadoraBL

  Public Class controlBL
    Inherits arrendadora.control

    Private Campos As System.Collections.Generic.IEnumerable(Of System.Xml.XmlNode)
    Private sConsLlave As List(Of String) = New List(Of String)({"registro"})
    Private schanges As String

    Public Property oNewControlOuBx() As control
    Public Property oOriControlOuBx() As control

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

    Public Overrides Function SelectControl() As control
      Return MyBase.Normaliza(MyBase.SelectControl())
    End Function

    Public Overrides Function GetParametros() As List(Of fdu_ParametrosControl_Result)
      Return MyBase.GetParametros()
    End Function

    Public Overrides Function Submit(ByRef control As control) As Boolean
      Dim bTrans As Boolean = False
      MyBase.Normaliza(control)
      bTrans = MyBase.Submit(control)
      oNewControlOuBx = MyBase.controlDL.oNewControlOuBx
      oOriControlOuBx = MyBase.controlDL.oOriControlOuBx
      Return bTrans
    End Function

    Public Function GeneraOutbox(ByVal oficina As Integer, Optional ByVal campos As String = "") As Boolean
      Dim bTrans As Boolean = False

      Try
        If Not Me.oNewControlOuBx Is Nothing Then MyBase.controlDL.oNewControlOuBx = Me.oNewControlOuBx
        If Not Me.oOriControlOuBx Is Nothing Then MyBase.controlDL.oOriControlOuBx = Me.oOriControlOuBx

        If campos.Trim.Length > 0 Then
          sConsLlave.AddRange(campos.Split(",").ToList.Where(Function(w) Not sConsLlave.Select(Function(s) s.ToLower).ToList.Contains(w.ToLower)).ToList)
        End If

        If Not Me.oNewControlOuBx Is Nothing Then
          MyBase.CargaXML(Me.oNewControlOuBx.GetType().Name)
          Dim oProps = Me.oNewControlOuBx.GetType().GetProperties()
          If oOriControlOuBx Is Nothing Then
            schanges = ""
            For Each prop As System.Reflection.PropertyInfo In oProps
              schanges &= MyBase.GenerarOutbox(prop, Me.oNewControlOuBx)
            Next
          Else
            schanges &= MyBase.ChangesOutbox(oOriControlOuBx, oNewControlOuBx, sConsLlave)
          End If
          bTrans = MyBase.Outbox(oficina, "CONTROL", "REGISTRO", "M.REGISTRO", schanges)
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

    Public Function Validacontrol(ByVal control As control) As Boolean
      Dim bValida As Boolean = False
      Dim oPaqueteVal As New PaqueteValidacion
      Dim oProps = control.GetType().GetProperties()

      With oPaqueteVal
        .Aprovado = True
        .Entidad = control
        For Each oProp As System.Reflection.PropertyInfo In oProps
          Dim oComentario As Comentario = Nothing

          Select Case oProp.Name
            Case Is = "registro"
              oComentario = Metodos.ValidaNumero(1, control, oProp, False, True, -1, -1)
            Case Is = "compania"
              oComentario = Metodos.ValidaCadena(2, control, oProp, False, True, 60)
            Case Is = "razon"
              oComentario = Metodos.ValidaCadena(3, control, oProp, True, True, 200)
            Case Is = "rfc"
              oComentario = Metodos.ValidaCadena(4, control, oProp, False, True, 13)
            Case Is = "domicilio"
              oComentario = Metodos.ValidaCadena(5, control, oProp, False, True, 50)
            Case Is = "colonia"
              oComentario = Metodos.ValidaCadena(6, control, oProp, False, True, 50)
            Case Is = "municipio"
              oComentario = Metodos.ValidaCadena(7, control, oProp, False, True, 50)
            Case Is = "estado"
              oComentario = Metodos.ValidaCadena(8, control, oProp, False, True, 50)
            Case Is = "cp"
              oComentario = Metodos.ValidaNumero(9, control, oProp, False, True, -1, -1)
            Case Is = "telefono"
              oComentario = Metodos.ValidaCadena(10, control, oProp, False, True, 40)
            Case Is = "u_cliente"
              oComentario = Metodos.ValidaNumero(11, control, oProp, False, True, -1, -1)
            Case Is = "tasas"
              oComentario = Metodos.ValidaCadena(12, control, oProp, False, True, 2147483647)
            Case Is = "u_esquema"
              oComentario = Metodos.ValidaNumero(13, control, oProp, False, True, -1, -1)
            Case Is = "serie_fm"
              oComentario = Metodos.ValidaCadena(14, control, oProp, False, True, 3)
            Case Is = "folio_fm"
              oComentario = Metodos.ValidaNumero(15, control, oProp, False, True, -1, -1)
            Case Is = "serie_rta"
              oComentario = Metodos.ValidaCadena(16, control, oProp, False, True, 3)
            Case Is = "folio_rta"
              oComentario = Metodos.ValidaNumero(17, control, oProp, False, True, -1, -1)
            Case Is = "serie_oc"
              oComentario = Metodos.ValidaCadena(18, control, oProp, False, True, 3)
            Case Is = "folio_oc"
              oComentario = Metodos.ValidaNumero(19, control, oProp, False, True, -1, -1)
            Case Is = "serie_la"
              oComentario = Metodos.ValidaCadena(20, control, oProp, False, True, 3)
            Case Is = "folio_la"
              oComentario = Metodos.ValidaNumero(21, control, oProp, False, True, -1, -1)
            Case Is = "folio_poli"
              oComentario = Metodos.ValidaNumero(22, control, oProp, False, True, -1, -1)
            Case Is = "parametros"
              oComentario = Metodos.ValidaCadena(23, control, oProp, False, True, 2147483647)
            Case Is = "filltasas"
              oComentario = Metodos.ValidaCadena(24, control, oProp, False, True, 2147483647)
            Case Is = "fec_cont"
              oComentario = Metodos.ValidaFecha(25, control, oProp, False)
            Case Is = "fec_cobra"
              oComentario = Metodos.ValidaFecha(26, control, oProp, False)
            Case Is = "trustees"
              oComentario = Metodos.ValidaCadena(27, control, oProp, False, True, 2147483647)
            Case Is = "requer"
              oComentario = Metodos.ValidaNumero(28, control, oProp, False, True, -1, -1)
            Case Is = "marca"
              oComentario = Metodos.ValidaNumero(29, control, oProp, False, True, -1, -1)
            Case Is = "cargo"
              oComentario = Metodos.ValidaNumero(30, control, oProp, False, True, -1, -1)
            Case Is = "solicitud"
              oComentario = Metodos.ValidaNumero(31, control, oProp, False, True, -1, -1)
            Case Is = "abogado"
              oComentario = Metodos.ValidaNumero(32, control, oProp, False, True, -1, -1)
            Case Is = "demanda"
              oComentario = Metodos.ValidaNumero(33, control, oProp, False, True, -1, -1)
            Case Is = "etapa"
              oComentario = Metodos.ValidaNumero(34, control, oProp, False, True, -1, -1)
            Case Is = "stop_robot"
              oComentario = Metodos.ValidaBoleano(35, control, oProp, False)
            Case Is = "expand"
              oComentario = Metodos.ValidaBoleano(36, control, oProp, False)
            Case Is = "u_cuenta"
              oComentario = Metodos.ValidaNumero(37, control, oProp, False, True, -1, -1)
            Case Is = "void"
              oComentario = Metodos.ValidaBoleano(38, control, oProp, False)
            Case Is = "u_oficina"
              oComentario = Metodos.ValidaNumero(39, control, oProp, False, True, -1, -1)
            Case Is = "folio_ls"
              oComentario = Metodos.ValidaNumero(40, control, oProp, False, True, -1, -1)
            Case Is = "serie_ls"
              oComentario = Metodos.ValidaCadena(41, control, oProp, False, True, 3)
            Case Is = "folio_ap"
              oComentario = Metodos.ValidaNumero(42, control, oProp, False, True, -1, -1)
            Case Is = "serie_ap"
              oComentario = Metodos.ValidaCadena(43, control, oProp, False, True, 3)
            Case Is = "trusteesfora"
              oComentario = Metodos.ValidaCadena(44, control, oProp, False, True, 2147483647)
            Case Is = "fec_oper"
              oComentario = Metodos.ValidaFecha(45, control, oProp, False)
            Case Is = "cfd_source"
              oComentario = Metodos.ValidaCadena(46, control, oProp, False, True, 2147483647)
            Case Is = "cfd_certificate"
              oComentario = Metodos.ValidaCadena(47, control, oProp, True, True, 2147483646)
            Case Is = "cfd_privatekey"
              oComentario = Metodos.ValidaCadena(48, control, oProp, True, True, 2147483646)
            Case Is = "cfd_password"
              oComentario = Metodos.ValidaCadena(49, control, oProp, True, True, 40)
            Case Is = "u_layclabe"
              oComentario = Metodos.ValidaNumero(50, control, oProp, True, True, -1, -1)
            Case Is = "fax"
              oComentario = Metodos.ValidaCadena(51, control, oProp, True, True, 40)
            Case Is = "homepage"
              oComentario = Metodos.ValidaCadena(52, control, oProp, True, True, 60)
            Case Is = "dominio"
              oComentario = Metodos.ValidaCadena(53, control, oProp, True, True, 60)
            Case Is = "mailserver"
              oComentario = Metodos.ValidaCadena(54, control, oProp, True, True, 2147483647)
            Case Is = "ftpserver"
              oComentario = Metodos.ValidaCadena(55, control, oProp, True, True, 2147483647)
            Case Is = "dias_cont"
              oComentario = Metodos.ValidaCadena(56, control, oProp, True, True, 30)
            Case Is = "rangoaviso"
              oComentario = Metodos.ValidaCadena(57, control, oProp, True, True, 30)
            Case Is = "venceauto"
              oComentario = Metodos.ValidaNumero(58, control, oProp, True, True, -1, -1)
            Case Is = "vencseguro"
              oComentario = Metodos.ValidaNumero(59, control, oProp, True, True, -1, -1)
            Case Is = "pzomaxseg"
              oComentario = Metodos.ValidaNumero(60, control, oProp, True, True, -1, -1)
            Case Is = "mincruzado"
              oComentario = Metodos.ValidaNumero(61, control, oProp, True, True, -1, -1)
            Case Is = "opcongela"
              oComentario = Metodos.ValidaNumero(62, control, oProp, True, True, -1, -1)
            Case Is = "intevfp"
              oComentario = Metodos.ValidaBoleano(63, control, oProp, True)
            Case Is = "interfasnew"
              oComentario = Metodos.ValidaBoleano(64, control, oProp, True)
            Case Is = "exp_pass"
              oComentario = Metodos.ValidaNumero(65, control, oProp, True, True, -1, -1)
            Case Is = "hist_pass"
              oComentario = Metodos.ValidaNumero(66, control, oProp, True, True, -1, -1)
            Case Is = "len_pass"
              oComentario = Metodos.ValidaNumero(67, control, oProp, True, True, -1, -1)
            Case Is = "sens_pass"
              oComentario = Metodos.ValidaBoleano(68, control, oProp, True)
            Case Is = "login_attempts"
              oComentario = Metodos.ValidaNumero(69, control, oProp, True, True, -1, -1)
            Case Is = "op_relevnte"
              oComentario = Metodos.ValidaNumero(70, control, oProp, True, True, -1, -1)
            Case Is = "fira_dias"
              oComentario = Metodos.ValidaNumero(71, control, oProp, True, True, -1, -1)
            Case Is = "dom_border"
              oComentario = Metodos.ValidaCadena(72, control, oProp, True, True, 2147483647)
            Case Is = "col_border"
              oComentario = Metodos.ValidaCadena(73, control, oProp, True, True, 2147483647)
            Case Is = "cp_border"
              oComentario = Metodos.ValidaNumero(74, control, oProp, True, True, -1, -1)
            Case Is = "mpo_border"
              oComentario = Metodos.ValidaCadena(75, control, oProp, True, True, 2147483647)
            Case Is = "edo_border"
              oComentario = Metodos.ValidaCadena(76, control, oProp, True, True, 2147483647)
            Case Is = "noaproba"
              oComentario = Metodos.ValidaNumero(77, control, oProp, True, True, -1, -1)
            Case Is = "anoaproba"
              oComentario = Metodos.ValidaNumero(78, control, oProp, True, True, -1, -1)
            Case Is = "nocertif"
              oComentario = Metodos.ValidaCadena(79, control, oProp, True, True, 20)
            Case Is = "fec_efactu"
              oComentario = Metodos.ValidaFecha(80, control, oProp, True)
            Case Is = "iva_cambio"
              oComentario = Metodos.ValidaFecha(81, control, oProp, True)
            Case Is = "cpgeneral"
              oComentario = Metodos.ValidaCadena(82, control, oProp, True, True, 50)
            Case Is = "cpcedula"
              oComentario = Metodos.ValidaCadena(83, control, oProp, True, True, 10)
            Case Is = "antesquien"
              oComentario = Metodos.ValidaCadena(84, control, oProp, True, True, 50)
            Case Is = "serie_xm"
              oComentario = Metodos.ValidaCadena(85, control, oProp, True, True, 3)
            Case Is = "folio_xm"
              oComentario = Metodos.ValidaNumero(86, control, oProp, True, True, -1, -1)
            Case Is = "cfdi_source"
              oComentario = Metodos.ValidaCadena(87, control, oProp, True, True, 2147483647)
            Case Is = "aviso_privacidad"
              oComentario = Metodos.ValidaCadena(88, control, oProp, True, True, 2147483647)
            Case Is = "adlogon"
              oComentario = Metodos.ValidaBoleano(89, control, oProp, True)
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

  End Class

End Namespace
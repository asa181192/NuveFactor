Imports System
Imports System.Data
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports Negocio.Validaciones
Imports Entidades
Imports Entidades.arrendadora

Namespace arrendadoraBL
  Public Class persoBL
    Inherits arrendadora.perso

    Private Campos As System.Collections.Generic.IEnumerable(Of System.Xml.XmlNode)
    Private sConsLlave As List(Of String) = New List(Of String)({"cliente"})
    Private schanges As String
    Private schangeslst As List(Of String)

    Public Property oNewpersoOuBx() As perso
    Public Property oNewpersosOuBx() As List(Of perso)
    Public Property oOripersoOuBx() As perso
    Public Property oOripersosOuBx() As List(Of perso)

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

    Public Overrides Function Selectperso(ByVal cliente As Integer) As perso
      Return MyBase.Normaliza(MyBase.Selectperso(cliente))
    End Function

    Public Overrides Function Selectpersos(ByVal clientes As List(Of Integer)) As List(Of perso)
      Return MyBase.Normaliza(MyBase.Selectpersos(clientes))
    End Function

    Public Overrides Function obteneraccionistas(ByVal cliente As Integer) As List(Of personalidad_accionista)
      Return MyBase.obteneraccionistas(cliente)
    End Function

    Public Overrides Function obtenerrepresentantes(ByVal cliente As Integer) As List(Of cliente)
      Return MyBase.Normaliza(MyBase.obtenerrepresentantes(cliente))
    End Function

    Public Overrides Function obteneradministradores(ByVal cliente As Integer) As List(Of cliente)
      Return MyBase.Normaliza(MyBase.obteneradministradores(cliente))
    End Function

    Public Overrides Function Submit(ByRef personalidad As perso) As Boolean
      Dim bTrans As Boolean = False
      MyBase.Normaliza(personalidad)
      bTrans = MyBase.Submit(personalidad)
      Me.oNewpersoOuBx = MyBase.persoDL.oNewpersoOuBx
      Me.oOripersoOuBx = MyBase.persoDL.oOripersoOuBx
      Return bTrans
    End Function

    Public Overrides Function Submit(ByRef personalidads As List(Of perso)) As Boolean
      Dim bTrans As Boolean = False
      MyBase.Normaliza(personalidads)
      bTrans = MyBase.Submit(personalidads)
      Me.oNewpersosOuBx = Me.persoDL.oNewpersosOuBx
      Me.oOripersosOuBx = Me.persoDL.oOripersosOuBx
      Return bTrans
    End Function

    Public Function GetPersonalidadAlternativa(ByVal cliente As Integer) As String
      Dim sDatosCliente As String = ""
      Dim oclienteBL As clienteBL = Nothing
      Dim ocliente As cliente = Nothing
      Dim operso As perso = Nothing
      Try
        oclienteBL = New clienteBL()
        ocliente = oclienteBL.Selectcliente(cliente)
        If oclienteBL.hayErr Then Throw oclienteBL.Err
        operso = MyBase.Selectperso(cliente)
        If ocliente.pfisica Then
          sDatosCliente &= ocliente.nombre.Trim
          sDatosCliente &= " que comparece por sus propios derechos, "
          sDatosCliente &= "declara ser de nacionalidad Mexicana, mayor de edad, con registro federal de contribuyentes "
          sDatosCliente &= ocliente.rfc.Trim & ", "
          sDatosCliente &= "y con domicilio en "
          sDatosCliente &= ocliente.domicilio.Trim & ", " & ocliente.colonia.Trim & ", "
          sDatosCliente &= If(ocliente.cp <= 0, "", "C.P. " + ocliente.cp.ToString & ", ")
          sDatosCliente &= ocliente.municipio.Trim & ", "
          sDatosCliente &= ocliente.estado.Trim & "."
        Else
          sDatosCliente &= ocliente.nombre.Trim
          sDatosCliente &= " con domicilio en " & ocliente.domicilio.Trim & " "
          sDatosCliente &= ocliente.colonia.Trim & ", "
          sDatosCliente &= "C.P. " & ocliente.cp.ToString & ", "
          sDatosCliente &= "en la ciudad de " & ocliente.municipio.Trim & ", " & ocliente.estado.Trim & ", "
          sDatosCliente &= "con Registro Federal de Contribuyentes " & ocliente.rfc.Trim & ", "
          sDatosCliente &= "se constituyó mediante Escritura Pública No. "
          sDatosCliente &= If(operso.cliente > 0 And operso.ar_escrit.Trim.Length > 0, operso.ar_escrit.Trim, StrDup(10, "_"))
          sDatosCliente &= " el " & If(operso.cliente > 0 And operso.ar_feccon > New Date(1900, 1, 1), operso.ar_feccon.ToString("dd 'de' MMMM 'de' yyyy", New Globalization.CultureInfo("es-MX")), StrDup(40, "_"))
          sDatosCliente &= " ante la fe del Notario Público No. "
          sDatosCliente &= If(operso.cliente > 0 And operso.ar_notar.Trim.Length > 0, operso.ar_notar.Trim, StrDup(10, "_"))
          sDatosCliente &= " en " & If(operso.cliente > 0 And operso.ar_cd.Trim.Length > 0, operso.ar_cd.Trim, StrDup(40, "_"))
          sDatosCliente &= " y cuyo primer testimonio quedó registrado bajo el No. "
          sDatosCliente &= If(operso.cliente > 0 And operso.ar_numero.Trim.Length > 0, operso.ar_numero.Trim, StrDup(10, "_")) & ", "
          sDatosCliente &= " folio " & If(operso.cliente > 0 And operso.ar_folio.Trim.Length > 0, operso.ar_folio.Trim, StrDup(10, "_"))
          sDatosCliente &= " y volumen " & If(operso.cliente > 0 And operso.ar_volum.Trim.Length > 0, operso.ar_volum.Trim, StrDup(10, "_")) & ", "
          sDatosCliente &= " libro No. " & If(operso.cliente > 0 And operso.ar_libro.Trim.Length > 0, operso.ar_libro.Trim, StrDup(10, "_")) & ", "
          sDatosCliente &= If(operso.cliente > 0 And operso.ar_auxil.Trim.Length > 0, operso.ar_auxil.Trim, StrDup(10, "_"))
          sDatosCliente &= " auxiliar, Escrituras de Sociedades Mercantiles, Sección de Comercio, con fecha "
          sDatosCliente &= If(operso.cliente > 0 And operso.ar_fecha > New Date(1900, 1, 1), operso.ar_fecha.ToString("dd 'de' MMMM 'de' yyyy", New Globalization.CultureInfo("es-mx")), StrDup(30, "_"))
          sDatosCliente &= " en el Registro Público de la Propiedad y del Comercio de este distrito."
          sDatosCliente &= Chr(182) & vbCrLf
          sDatosCliente &= If(operso.cliente > 0, operso.apoderado.Trim, StrDup(40, "_"))
          sDatosCliente &= " comparece(n) como "
          sDatosCliente &= "representante(s) de " & ocliente.nombre.Trim & ", justifica(n) el carácter con el que comparece(n) mediante escritura pública No. "
          sDatosCliente &= If(operso.cliente > 0 And operso.ap_escrit.Trim.Length > 0, operso.ap_escrit.Trim, StrDup(10, "_"))
          sDatosCliente &= " otorgada ante la fe del Notario Público No. "
          sDatosCliente &= If(operso.cliente > 0 And operso.ap_notar.Trim.Length > 0, operso.ap_notar.Trim, StrDup(10, "_"))
          sDatosCliente &= " con ejercicio en la Ciudad de "
          sDatosCliente &= If(operso.cliente > 0 And operso.ap_cd.Trim.Length > 0, operso.ap_cd.Trim, StrDup(40, "_"))
          sDatosCliente &= " y cuyo primer testimonio quedó registrado bajo el No. "
          sDatosCliente &= If(operso.cliente > 0 And operso.ap_numero.Trim.Length > 0, operso.ap_numero.Trim, StrDup(10, "_")) & ", "
          sDatosCliente &= "folio " & If(operso.cliente > 0 And operso.ap_folio.Trim.Length > 0, operso.ap_folio.Trim, StrDup(10, "_"))
          sDatosCliente &= " y volumen " & If(operso.cliente > 0 And operso.ap_volum.Trim.Length > 0, operso.ap_volum.Trim, StrDup(10, "_")) & ", "
          sDatosCliente &= "libro No. " & If(operso.cliente > 0 And operso.ap_libro.Trim.Length > 0, operso.ap_libro.Trim, StrDup(10, "_")) & ", "
          sDatosCliente &= If(operso.cliente > 0 And operso.ap_auxil.Trim.Length > 0, operso.ap_auxil.Trim, StrDup(10, "_"))
          sDatosCliente &= " Auxiliar, Actos y Contratos Diversos, Sección de Comercio, con fecha "
          sDatosCliente &= If(operso.cliente > 0 And operso.ap_fecha > New Date(1900, 1, 1), operso.ap_fecha.ToString("dd 'de' MMMM 'de' yyyy", New Globalization.CultureInfo("es-mx")), StrDup(40, "_"))
          sDatosCliente &= " en el Registro Público de la Propiedad y del Comercio de este distrito."
        End If
        sDatosCliente = sDatosCliente.Replace(Chr(182) & vbCrLf, vbCrLf)
      Catch ex As Exception
        MyBase.hayErr = True
        MyBase.Err = Err
        sDatosCliente = ""
      Finally
        If Not oclienteBL Is Nothing Then oclienteBL.Dispose()
        If Not oclienteBL Is Nothing Then oclienteBL = Nothing
        If Not ocliente Is Nothing Then ocliente = Nothing
        If Not operso Is Nothing Then operso = Nothing
      End Try
      Return sDatosCliente
    End Function

    Public Function GeneraOutbox(ByVal oficina As Integer, Optional ByVal campos As String = "") As Boolean
      Dim bTrans As Boolean = False

      Try
        If Not Me.oNewpersoOuBx Is Nothing Then Me.persoDL.oNewpersoOuBx = Me.oNewpersoOuBx
        If Not Me.oNewpersosOuBx Is Nothing Then Me.persoDL.oNewpersosOuBx = Me.oNewpersosOuBx
        If Not Me.oOripersoOuBx Is Nothing Then Me.persoDL.oOripersoOuBx = Me.oOripersoOuBx
        If Not Me.oOripersosOuBx Is Nothing Then Me.persoDL.oOripersosOuBx = Me.oOripersosOuBx

        If campos.Trim.Length > 0 Then
          sConsLlave.AddRange(campos.Split(",").ToList.Where(Function(w) Not sConsLlave.Select(Function(s) s.ToLower).ToList.Contains(w.ToLower)).ToList)
        End If

        If Not Me.oNewpersoOuBx Is Nothing Then
          MyBase.CargaXML(oNewpersoOuBx.GetType().Name)
          Dim oProps = oNewpersoOuBx.GetType().GetProperties()
          If oOripersoOuBx Is Nothing Then
            schanges = ""
            For Each prop As System.Reflection.PropertyInfo In oProps
              schanges &= MyBase.GenerarOutbox(prop, oNewpersoOuBx)
            Next
          Else
            schanges = MyBase.ChangesOutbox(oOripersoOuBx, oNewpersoOuBx, sConsLlave)
          End If
          bTrans = MyBase.Outbox(oficina, "PERSO", "CLIENTE", "M.CLIENTE", schanges)
          MyBase.LiberaXML()
        End If

        If Not Me.oNewpersosOuBx Is Nothing Then
          MyBase.CargaXML(oNewpersosOuBx.ElementAt(0).GetType().Name)
          Dim oProps = oNewpersosOuBx.ElementAt(0).GetType().GetProperties()
          If Not schangeslst Is Nothing Then schangeslst = Nothing
          schangeslst = New List(Of String)
          If oOripersosOuBx Is Nothing Then
            For Each pers As perso In oNewpersosOuBx
              schanges = ""
              For Each prop As System.Reflection.PropertyInfo In oProps
                schanges &= MyBase.GenerarOutbox(prop, pers)
              Next
              schangeslst.Add(schanges)
            Next
          Else
            For Each Newpers As perso In oNewpersosOuBx
              Dim oOldpers = oOripersosOuBx.Where(Function(w) w.cliente = Newpers.cliente)
              schanges = ""
              If oOldpers.Count() > 0 Then
                schanges = MyBase.ChangesOutbox(oOldpers.Single, Newpers, sConsLlave)
              Else
                For Each prop As System.Reflection.PropertyInfo In oProps
                  schanges &= MyBase.GenerarOutbox(prop, Newpers)
                Next
              End If
              schangeslst.Add(schanges)
            Next
          End If
          bTrans = MyBase.Outbox(oficina, "PERSO", "CLIENTE", "M.CLIENTE", schangeslst)
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

    Public Function Validaperso(ByVal perso As perso) As Boolean
      Dim bValida As Boolean = False
      Dim oPaqueteVal As New PaqueteValidacion
      Dim oProps = perso.GetType().GetProperties()

      With oPaqueteVal
        .Aprovado = True
        .Entidad = perso
        For Each oProp As System.Reflection.PropertyInfo In oProps
          Dim oComentario As Comentario = Nothing

          Select Case oProp.Name
            Case Is = "cliente"
              oComentario = Metodos.ValidaNumero(1, perso, oProp, False, False, -1, -1)
            Case Is = "socios"
              oComentario = Metodos.ValidaCadena(2, perso, oProp, False, True, 2147483647)
            Case Is = "dur_socie"
              oComentario = Metodos.ValidaNumero(3, perso, oProp, False, False, -1, -1)
            Case Is = "capital"
              oComentario = Metodos.ValidaNumero(4, perso, oProp, False, False, -1, -1)
            Case Is = "apoderado"
              oComentario = Metodos.ValidaCadena(5, perso, oProp, False, True, 2147483647)
            Case Is = "ap_escrit"
              oComentario = Metodos.ValidaCadena(6, perso, oProp, False, True, 10)
            Case Is = "ap_notar"
              oComentario = Metodos.ValidaCadena(7, perso, oProp, False, True, 10)
            Case Is = "ap_cd"
              oComentario = Metodos.ValidaCadena(8, perso, oProp, False, True, 2147483647)
            Case Is = "ap_numero"
              oComentario = Metodos.ValidaCadena(9, perso, oProp, False, True, 10)
            Case Is = "ap_folio"
              oComentario = Metodos.ValidaCadena(10, perso, oProp, False, True, 10)
            Case Is = "ap_volum"
              oComentario = Metodos.ValidaCadena(11, perso, oProp, False, True, 10)
            Case Is = "ap_libro"
              oComentario = Metodos.ValidaCadena(12, perso, oProp, False, True, 10)
            Case Is = "ap_auxil"
              oComentario = Metodos.ValidaCadena(13, perso, oProp, False, True, 10)
            Case Is = "ap_fecha"
              oComentario = Metodos.ValidaFecha(14, perso, oProp, False)
            Case Is = "ar_escrit"
              oComentario = Metodos.ValidaCadena(15, perso, oProp, False, True, 10)
            Case Is = "ar_feccon"
              oComentario = Metodos.ValidaFecha(16, perso, oProp, False)
            Case Is = "ar_notar"
              oComentario = Metodos.ValidaCadena(17, perso, oProp, False, True, 10)
            Case Is = "ar_cd"
              oComentario = Metodos.ValidaCadena(18, perso, oProp, False, True, 2147483647)
            Case Is = "ar_numero"
              oComentario = Metodos.ValidaCadena(19, perso, oProp, False, True, 10)
            Case Is = "ar_folio"
              oComentario = Metodos.ValidaCadena(20, perso, oProp, False, True, 10)
            Case Is = "ar_volum"
              oComentario = Metodos.ValidaCadena(21, perso, oProp, False, True, 10)
            Case Is = "ar_libro"
              oComentario = Metodos.ValidaCadena(22, perso, oProp, False, True, 10)
            Case Is = "ar_auxil"
              oComentario = Metodos.ValidaCadena(23, perso, oProp, False, True, 10)
            Case Is = "ar_fecha"
              oComentario = Metodos.ValidaFecha(24, perso, oProp, False)
            Case Is = "login_name"
              oComentario = Metodos.ValidaCadena(25, perso, oProp, False, True, 20)
            Case Is = "generales"
              oComentario = Metodos.ValidaCadena(26, perso, oProp, False, True, 2147483647)
            Case Is = "void"
              oComentario = Metodos.ValidaBoleano(27, perso, oProp, False)
            Case Is = "fec_revi"
              oComentario = Metodos.ValidaFecha(28, perso, oProp, False)
            Case Is = "accionista"
              oComentario = Metodos.ValidaCadena(29, perso, oProp, False, True, 2147483647)
            Case Is = "fec_revacc"
              oComentario = Metodos.ValidaFecha(30, perso, oProp, True)
            Case Is = "porc_menor"
              oComentario = Metodos.ValidaBoleano(31, perso, oProp, True)
            Case Is = "sociedad"
              oComentario = Metodos.ValidaCadena(32, perso, oProp, True, True, 200)
            Case Is = "tiposociedad"
              oComentario = Metodos.ValidaNumero(33, perso, oProp, True, False, -1, -1)
            Case Is = "ar_ciudad"
              oComentario = Metodos.ValidaCadena(34, perso, oProp, True, True, 8)
            Case Is = "ap_ciudad"
              oComentario = Metodos.ValidaCadena(35, perso, oProp, True, True, 8)
            Case Is = "representantes"
              oComentario = Metodos.ValidaCadena(35, perso, oProp, True, True, 2147483647)
            Case Is = "administradores"
              oComentario = Metodos.ValidaCadena(36, perso, oProp, True, True, 2147483647)
          End Select

          If oComentario Is Nothing Then oComentario = New Comentario(0, oProp.PropertyType, oProp, "")

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

    Public Function Validapersos(ByVal persos As List(Of perso)) As Boolean
      Dim bValida As Boolean = True
      For Each oInst As perso In persos
        bValida = bValida And Me.Validaperso(oInst)
      Next
      Return bValida
    End Function

  End Class
End Namespace
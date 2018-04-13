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
  Public Class clienteBL
    Inherits arrendadora.cliente

    Private Campos As System.Collections.Generic.IEnumerable(Of System.Xml.XmlNode)
    Private sConsLlave As List(Of String) = New List(Of String)({"cliente"})
    Private schanges As String
    Private schangeslst As List(Of String)

    Public Property oNewClienteOuBx() As cliente
    Public Property oNewClientesOuBx() As List(Of cliente)
    Public Property oOriClienteOuBx() As cliente
    Public Property oOriClientesOuBx() As List(Of cliente)

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

    Public Overrides Function MotoresDeCredito(ByVal nbrclientecs As Decimal?, ByVal rfc As String) As sp_siclinew_Result
      Return MyBase.MotoresDeCredito(nbrclientecs, rfc)
    End Function

    Public Overrides Function Creditosxcliente(ByVal rfc As String) As List(Of sp_creditosxcliente_Result)
      Return MyBase.Creditosxcliente(rfc)
    End Function

    Public Overrides Function ExisteCliente(ByVal tcRfc As String, ByVal tcNom As String) As Boolean
      Return MyBase.ExisteCliente(tcRfc, tcNom)
    End Function

    Public Overrides Function Selectclientes() As List(Of cliente)
      Dim oclientes As List(Of cliente) = Nothing
      Try
        oclientes = MyBase.Normaliza(MyBase.Selectclientes())
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oclientes = New List(Of cliente)
      End Try
      Return oclientes
    End Function

    Public Overrides Function Selectcliente(ByVal cliente As Decimal) As cliente
      Dim ocliente As cliente = Nothing
      Try
        ocliente = MyBase.Normaliza(MyBase.Selectcliente(cliente))
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        ocliente = New cliente()
      End Try
      Return ocliente
    End Function

    Public Overrides Function Selectclientes(ByVal clientes As List(Of Decimal)) As List(Of cliente)
      Dim oclientes As List(Of cliente) = Nothing
      Try
        oclientes = MyBase.Normaliza(MyBase.Selectclientes(clientes))
      Catch ex As Exception
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oclientes = New List(Of cliente)
      End Try
      Return oclientes
    End Function

    Public Overrides Function Selectclientes(ByVal riesgo As Decimal) As List(Of cliente)
      Dim oclientes As List(Of cliente) = Nothing
      Try
        oclientes = MyBase.Normaliza(MyBase.Selectclientes(riesgo))
      Catch ex As Exception
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oclientes = New List(Of cliente)
      End Try
      Return oclientes
    End Function

    Public Overrides Function SelectclientebyRFC(ByVal pfisica As Boolean, ByVal RFC As String) As cliente
      Dim ocliente As cliente = Nothing
      Try
        ocliente = MyBase.Normaliza(MyBase.SelectclientebyRFC(pfisica, RFC))
      Catch ex As Exception
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        ocliente = New cliente()
      End Try
      Return ocliente
    End Function

    Public Overrides Function Selectclientebynbr(ByVal nbrclientecs As Integer) As cliente
      Dim ocliente As cliente = Nothing
      Try
        ocliente = MyBase.Normaliza(MyBase.Selectclientebynbr(nbrclientecs))
      Catch ex As Exception
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        ocliente = New cliente()
      End Try
      Return ocliente
    End Function

    Public Overrides Function GetCalificacionCarteraPre(ByVal ncliente As Integer) As DataTable
      Return MyBase.GetCalificacionCarteraPre(ncliente)
    End Function

    Public Overrides Function GetInformacionFinancieraCliente(ncliente As Integer) As List(Of InformacionFinancieraCliente_Result)
      Return MyBase.Normaliza(MyBase.GetInformacionFinancieraCliente(ncliente))
    End Function

    Public Overrides Function Clientes_resumen(nOficina As Integer, nCredito As Integer, nCliente As Integer) As sp_clientes_resumen_Result
      Return MyBase.Clientes_resumen(nOficina, nCredito, nCliente)
    End Function

    Public Overrides Function getSaldoInsolutoCliente(ByVal cliente As Integer, SumaIvaInsoluto As Boolean) As Double
      Return MyBase.getSaldoInsolutoCliente(cliente, SumaIvaInsoluto)
    End Function

    Public Overrides Function getSaldoInsolutoContrato(ByVal contrato As Integer, SumaIvaInsoluto As Boolean) As Double
      Return MyBase.getSaldoInsolutoContrato(contrato, SumaIvaInsoluto)
    End Function

    Public Overrides Function SelectclientebyNombrebyNumero(ByVal cliente As Decimal?, Optional ByVal nombre As String = Nothing, Optional ByVal oficinas As String = Nothing) As List(Of sp_clientesBusquedaXNombreXCliente_Result)
      Return MyBase.SelectclientebyNombrebyNumero(cliente, nombre, oficinas)
    End Function

    Public Overrides Function SelectclientebyNombreClienteRiesgo(ByVal cliente As Decimal?, Optional ByVal nombre As String = "{string.value.null}", Optional ByVal oficinas As Decimal() = Nothing) As List(Of ClienteporNombreClienteRiesgo_Result)
      Return MyBase.SelectclientebyNombreClienteRiesgo(cliente, nombre, oficinas)
    End Function

    Public Overrides Function SelectClientesOficina(ByVal cliente As Decimal) As List(Of ClientesOficina_Result)
      Return MyBase.SelectClientesOficina(cliente)
    End Function

    Public Overrides Function SelectClientesOficina(ByVal clientes As List(Of Decimal)) As List(Of ClientesOficina_Result)
      Return MyBase.SelectClientesOficina(clientes)
    End Function

    Public Overrides Function Selectcliente(ByVal ctes As List(Of Decimal)) As List(Of cliente)
      Dim oclientes As List(Of cliente) = Nothing
      Try
        oclientes = MyBase.Normaliza(MyBase.Selectcliente(ctes))
      Catch ex As Exception
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oclientes = New List(Of cliente)
      End Try
      Return oclientes
    End Function

    Public Overrides Function SelectclientebylikeNombrebyCliente(ByVal oficina As Integer, ByVal oficinas As List(Of Decimal), ByVal key As String) As List(Of ClienteporNombreClienteRFC_Result)
      Return MyBase.SelectclientebylikeNombrebyCliente(oficina, oficinas, key)
    End Function

    Public Overrides Function getdigito_bancomer04(sofaclte As String) As String
      Return MyBase.getdigito_bancomer04(sofaclte)
    End Function

    Public Overrides Function getdigito_banamex97(ByVal sofclte As String) As String
      Return MyBase.getdigito_banamex97(sofclte)
    End Function

    Public Overrides Function Submit(ByRef cliente As cliente) As Boolean
      Dim oTrans As Boolean = False
      Try
        Me.NombreCompleto(cliente)
        Me.CamposenMayussinAcento(cliente)
        Me.CamposenMinisculas(cliente)
        Me.ClienteExtranjeto(cliente)
        MyBase.Normaliza(cliente)
        oTrans = MyBase.Submit(cliente)
        Me.oNewClienteOuBx = MyBase.clienteDL.oNewClienteOuBx
        Me.oOriClienteOuBx = MyBase.clienteDL.oOriClienteOuBx
      Catch ex As Exception
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oTrans = False
      End Try
      Return oTrans
    End Function

    Public Overrides Function Submit(ByRef clientes As List(Of cliente)) As Boolean
      Dim oTrans As Boolean = False
      Try
        For Each clie In clientes
          Me.NombreCompleto(clie)
          Me.CamposenMayussinAcento(clie)
          Me.CamposenMinisculas(clie)
          Me.ClienteExtranjeto(clie)
        Next
        MyBase.Normaliza(clientes)
        oTrans = MyBase.Submit(clientes)
        Me.oNewClientesOuBx = Me.clienteDL.oNewClientesOuBx
        Me.oOriClientesOuBx = Me.clienteDL.oOriClientesOuBx
      Catch ex As Exception
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oTrans = False
      End Try
      Return oTrans
    End Function

    Public Overrides Function riesgo_RiesgoDeCliente(ByVal cliente As Integer) As Integer
      Return MyBase.riesgo_RiesgoDeCliente(cliente)
    End Function

    Public Overrides Function riesgo_RiesgoDeCliente2016(cliente As Integer, ByVal pldhist As Boolean) As Integer
      Return MyBase.riesgo_RiesgoDeCliente2016(cliente, pldhist)
    End Function

    Public Overrides Function riesgo_RiesgoDeEdad2016(cliente As Integer, pfisica As Boolean, pfempre As Boolean) As Integer
      Return MyBase.riesgo_RiesgoDeEdad2016(cliente, pfisica, pfempre)
    End Function

    Public Overrides Function riesgo_RiesgoDeSubactividad(cliente As Integer) As Integer
      Return MyBase.riesgo_RiesgoDeSubactividad(cliente)
    End Function

    Public Overrides Function riesgo_RiesgoDeEntidad2016(cliente As Integer) As Integer
      Return MyBase.riesgo_RiesgoDeEntidad2016(cliente)
    End Function

    Public Overrides Function riesgo_RiesgoDePolitico2016(cliente As Integer) As Integer
      Return MyBase.riesgo_RiesgoDePolitico2016(cliente)
    End Function

    Public Overrides Function riesgo_RiesgoDePais(cliente As Integer) As Integer
      Return MyBase.riesgo_RiesgoDePais(cliente)
    End Function

    Public Overrides Function riesgo_RiesgoDeEdad(cliente As Integer) As Integer
      Return MyBase.riesgo_RiesgoDeEdad(cliente)
    End Function

    Public Overrides Function riesgo_RiesgoDeActividad(cliente As Integer) As Integer
      Return MyBase.riesgo_RiesgoDeActividad(cliente)
    End Function

    Public Overrides Function riesgo_RiesgoDeEntidad(cliente As Integer) As Integer
      Return MyBase.riesgo_RiesgoDeEntidad(cliente)
    End Function

    Public Overrides Function riesgo_RiesgoDePolitico(cliente As Integer) As Integer
      Return MyBase.riesgo_RiesgoDePolitico(cliente)
    End Function

    Public Overrides Function riesgo_RiesgoDeExtranjero(cliente As Integer) As Integer
      Return MyBase.riesgo_RiesgoDeExtranjero(cliente)
    End Function

    Public Overrides Function selClientesGruporiesgo(ByVal grupo As Integer) As List(Of sp_selClientesGruporiesgo_Result)
      Return MyBase.selClientesGruporiesgo(grupo)
    End Function

    Public Overrides Function ExisteRFC(ByVal RFC As String, ByVal oficinas As String) As Boolean
      Return MyBase.ExisteRFC(RFC, oficinas)
    End Function

    Public Function GeneraOutbox(ByVal oficina As Integer, Optional ByVal campos As String = "") As Boolean
      Dim bTrans As Boolean = False

      Try
        If Not Me.oNewClienteOuBx Is Nothing Then Me.clienteDL.oNewClienteOuBx = Me.oNewClienteOuBx
        If Not Me.oNewClientesOuBx Is Nothing Then Me.clienteDL.oNewClientesOuBx = Me.oNewClientesOuBx
        If Not Me.oOriClienteOuBx Is Nothing Then Me.clienteDL.oOriClienteOuBx = Me.oOriClienteOuBx
        If Not Me.oOriClientesOuBx Is Nothing Then Me.clienteDL.oOriClientesOuBx = Me.oOriClientesOuBx

        If campos.Trim.Length > 0 Then
          sConsLlave.AddRange(campos.Split(",").ToList.Where(Function(w) Not sConsLlave.Select(Function(s) s.ToLower).ToList.Contains(w.ToLower)).ToList)
        End If

        If Not oNewClienteOuBx Is Nothing Then
          MyBase.CargaXML(oNewClienteOuBx.GetType().Name)
          Dim oProps = oNewClienteOuBx.GetType().GetProperties()
          If oOriClienteOuBx Is Nothing Then
            schanges = ""
            For Each prop As System.Reflection.PropertyInfo In oProps
              schanges &= MyBase.GenerarOutbox(prop, oNewClienteOuBx)
            Next
          Else
            schanges = MyBase.ChangesOutbox(oOriClienteOuBx, oNewClienteOuBx, sConsLlave)
          End If
          bTrans = MyBase.Outbox(oficina, "CLIENTES", "CLIENTE", "M.CLIENTE", schanges)
          MyBase.LiberaXML()
        End If

        If Not oNewClientesOuBx Is Nothing Then
          MyBase.CargaXML(oNewClientesOuBx.ElementAt(0).GetType().Name)
          Dim oProps = oNewClientesOuBx.ElementAt(0).GetType().GetProperties()
          If Not schangeslst Is Nothing Then schangeslst = Nothing
          schangeslst = New List(Of String)
          If oOriClientesOuBx Is Nothing Then
            For Each clie As cliente In oNewClientesOuBx
              schanges = ""
              For Each prop As System.Reflection.PropertyInfo In oProps
                schanges &= MyBase.GenerarOutbox(prop, clie)
              Next
              schangeslst.Add(schanges)
            Next
          Else
            For Each Newclie As cliente In oNewClientesOuBx
              Dim oOldClie = oOriClientesOuBx.Where(Function(w) w.cliente_id = Newclie.cliente_id)
              schanges = ""
              If oOldClie.Count() > 0 Then
                schanges = MyBase.ChangesOutbox(oOldClie.Single, Newclie, sConsLlave)
              Else
                For Each prop As System.Reflection.PropertyInfo In oProps
                  schanges &= MyBase.GenerarOutbox(prop, Newclie)
                Next
              End If
              schangeslst.Add(schanges)
            Next
          End If
          bTrans = MyBase.Outbox(oficina, "CLIENTES", "CLIENTE", "M.CLIENTE", schangeslst)
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

    Public Function Validacliente(ByVal cliente As cliente) As Boolean
      Dim bValida As Boolean = False
      Dim oPaqueteVal As New PaqueteValidacion
      Dim oProps = cliente.GetType().GetProperties()

      With oPaqueteVal
        .Aprovado = True
        .Entidad = cliente
        For Each oProp As System.Reflection.PropertyInfo In oProps
          Dim oComentario As Comentario = Nothing

          Select Case oProp.Name
            Case Is = "origen"
              oComentario = Metodos.ValidaNumero(1, cliente, oProp, False, True, -1, -1)
            Case Is = "cliente_id"
              oComentario = Metodos.ValidaNumero(2, cliente, oProp, False, True, -1, -1)
            Case Is = "pfisica"
              oComentario = Metodos.ValidaBoleano(3, cliente, oProp, False)
            Case Is = "nombre"
              oComentario = Metodos.ValidaCadena(4, cliente, oProp, False, True, 150)
            Case Is = "n"
              If (cliente.pfisica = True) Then
                oComentario = Metodos.ValidaCadena(5, cliente, oProp, False, False, 2147483647)
              End If
            Case Is = "s"
              If (cliente.pfisica = True) Then
                oComentario = Metodos.ValidaCadena(6, cliente, oProp, True, True, 2147483647)
              End If
            Case Is = "p"
              If (cliente.pfisica = True) Then
                oComentario = Metodos.ValidaCadena(7, cliente, oProp, False, False, -1)
              End If
            Case Is = "m"
              If (cliente.pfisica = True) Then
                oComentario = Metodos.ValidaCadena(8, cliente, oProp, True, True, -1)
              End If
            Case Is = "rfc"
              oComentario = Metodos.ValidaRFC(9, cliente, oProp, cliente.pfisica, False)
            Case Is = "domicilio"
              oComentario = Metodos.ValidaCadena(10, cliente, oProp, True, True, 100)
            Case Is = "colonia"
              oComentario = Metodos.ValidaCadena(11, cliente, oProp, True, True, 100)
            Case Is = "cp"
              oComentario = Metodos.ValidaNumero(12, cliente, oProp, False, True, -1, -1)
            Case Is = "municipio"
              oComentario = Metodos.ValidaCadena(13, cliente, oProp, True, True, 100)
            Case Is = "estado"
              oComentario = Metodos.ValidaCadena(14, cliente, oProp, False, True, 40)
            Case Is = "telefono"
              oComentario = Metodos.ValidaCadena(15, cliente, oProp, False, True, 40)
            Case Is = "email"
              If cliente.email.Trim.Length > 0 Then
                oComentario = Metodos.ValidaCorreo(16, cliente, oProp, False)
              End If
            Case Is = "promotor"
              oComentario = Validapromotor(17, cliente, oProp)
            Case Is = "promo_cve"
              oComentario = Metodos.ValidaCadena(18, cliente, oProp, False, True, 6)
            Case Is = "fec_alta"
              oComentario = Metodos.ValidaFecha(19, cliente, oProp, False)
            Case Is = "fec_baja"
              oComentario = Metodos.ValidaFecha(20, cliente, oProp, False)
            Case Is = "cltedesde"
              oComentario = Metodos.ValidaFecha(21, cliente, oProp, False)
            Case Is = "contactos"
              oComentario = Metodos.ValidaCadena(22, cliente, oProp, False, True, 2147483647)
            Case Is = "riesgo"
              oComentario = Metodos.ValidaNumero(23, cliente, oProp, False, True, -1, -1)
            Case Is = "actividad"
              oComentario = Validaactividad(24, cliente, oProp)
              If oComentario.Comentario.Trim.Length = 0 Then
                Me.ValidaCatalogo(24, cliente, oProp)
              End If
            Case Is = "notas"
              oComentario = Metodos.ValidaCadena(25, cliente, oProp, False, True, 2147483647)
            Case Is = "bnc_dump"
              oComentario = Metodos.ValidaCadena(26, cliente, oProp, False, True, 2147483647)
            Case Is = "aval"
              oComentario = Metodos.ValidaBoleano(27, cliente, oProp, False)
            Case Is = "pfempre"
              oComentario = Metodos.ValidaBoleano(28, cliente, oProp, False)
            Case Is = "banx_activ"
              oComentario = Metodos.ValidaNumero(29, cliente, oProp, False, True, -1, -1)
            Case Is = "banx_calif"
              oComentario = Metodos.ValidaCadena(30, cliente, oProp, False, True, 2)
            Case Is = "curp"
              If (cliente.pfisica = True) Then
                oComentario = Metodos.ValidaCURP(31, cliente, oProp, False)
              End If
            Case Is = "pais"
              oComentario = Metodos.ValidaNumero(32, cliente, oProp, False, False, -1, -1)
              If oComentario.Comentario.Trim.Length = 0 Then
                Me.ValidaCatalogo(32, cliente, oProp)
              End If
            Case Is = "extranjero"
              oComentario = Metodos.ValidaBoleano(33, cliente, oProp, False)
            Case Is = "pexpuesto"
              oComentario = Metodos.ValidaBoleano(34, cliente, oProp, False)
            Case Is = "altoriesgo"
              oComentario = Metodos.ValidaBoleano(35, cliente, oProp, False)
            Case Is = "numemp"
              oComentario = Metodos.ValidaNumero(36, cliente, oProp, False, True, -1, -1)
            Case Is = "nip"
              oComentario = Metodos.ValidaNumero(37, cliente, oProp, False, True, -1, -1)
            Case Is = "accionista"
              oComentario = Metodos.ValidaBoleano(38, cliente, oProp, False)
            Case Is = "void"
              oComentario = Metodos.ValidaBoleano(39, cliente, oProp, False)
            Case Is = "id_unico"
              oComentario = Metodos.ValidaCadena(40, cliente, oProp, True, True, 25)
            Case Is = "sepomex"
              oComentario = Metodos.ValidaCadena(41, cliente, oProp, True, True, 25)
            Case Is = "ingresos"
              oComentario = Metodos.ValidaNumero(42, cliente, oProp, True, True, -1, -1)
            Case Is = "numext"
              oComentario = Metodos.ValidaCadena(43, cliente, oProp, True, True, 20)
            Case Is = "numint"
              oComentario = Metodos.ValidaCadena(44, cliente, oProp, True, True, 20)
            Case Is = "activo"
              oComentario = Metodos.ValidaNumero(45, cliente, oProp, True, True, -1, -1)
            Case Is = "pasivo"
              oComentario = Metodos.ValidaNumero(46, cliente, oProp, True, True, -1, -1)
            Case Is = "capital"
              oComentario = Metodos.ValidaNumero(47, cliente, oProp, True, True, -1, -1)
            Case Is = "calle"
              oComentario = Metodos.ValidaCadena(48, cliente, oProp, True, True, 150)
            Case Is = "edocivil"
              If (cliente.pfisica = True) Then
                oComentario = Metodos.ValidaNumero(49, cliente, oProp, False, False, -1, -1)
                If oComentario.Comentario.Trim.Length = 0 Then
                  Me.ValidaCatalogo(49, cliente, oProp)
                End If
              End If
            Case Is = "identificacion"
              If (cliente.pfisica = True) Then
                oComentario = Metodos.ValidaNumero(50, cliente, oProp, False, False, -1, -1)
                If oComentario.Comentario.Trim.Length = 0 Then
                  Me.ValidaCatalogo(50, cliente, oProp)
                End If
              End If
            Case Is = "tipovivienda"
              If (cliente.pfisica = True) Then
                oComentario = Metodos.ValidaNumero(51, cliente, oProp, False, False, -1, -1)
                If oComentario.Comentario.Trim.Length = 0 Then
                  Me.ValidaCatalogo(51, cliente, oProp)
                End If
              End If
            Case Is = "ife"
              oComentario = Metodos.ValidaCadena(52, cliente, oProp, True, True, 13)
            Case Is = "TEL"
              oComentario = Metodos.ValidaCadena(53, cliente, oProp, True, True, 12)
            Case Is = "login_name"
              oComentario = Metodos.ValidaCadena(54, cliente, oProp, True, True, 20)
            Case Is = "xfer"
              oComentario = Metodos.ValidaBoleano(55, cliente, oProp, True)
            Case Is = "nbrclientecs"
              oComentario = Metodos.ValidaNumero(56, cliente, oProp, True, True, -1, -1)
            Case Is = "tiposociedad"
              If (cliente.pfisica = False) Then
                oComentario = Metodos.ValidaNumero(57, cliente, oProp, False, False, -1, -1)
                If oComentario.Comentario.Trim.Length = 0 Then
                  Me.ValidaCatalogo(57, cliente, oProp)
                End If
              End If
            Case Is = "sociedad"
              If (cliente.pfisica = False) Then
                oComentario = Metodos.ValidaCadena(58, cliente, oProp, False, False, 200)
              End If
            Case Is = "subactiv"
              oComentario = Validasubactividad(59, cliente, oProp)
              If oComentario.Comentario.Trim.Length = 0 Then
                Me.ValidaCatalogo(59, cliente, oProp)
              End If
            Case Is = "Riesgopld"
              oComentario = Metodos.ValidaNumero(60, cliente, oProp, True, True, -1, -1)
            Case Is = "fecbalance"
              oComentario = Metodos.ValidaFecha(61, cliente, oProp, True)
            Case Is = "cveprebc"
              oComentario = Metodos.ValidaCadena(62, cliente, oProp, True, True, 64)
            Case Is = "relacion"
              oComentario = Metodos.ValidaBoleano(63, cliente, oProp, True)
            Case Is = "sececo"
              oComentario = Metodos.ValidaNumero(64, cliente, oProp, False, False, -1, -1)
              If oComentario.Comentario.Trim.Length = 0 Then
                Me.ValidaCatalogo(64, cliente, oProp)
              End If
            Case Is = "grupo"
              oComentario = Metodos.ValidaNumero(65, cliente, oProp, True, True, -1, -1)
            Case Is = "bnc_reporte"
              oComentario = Metodos.ValidaFecha(66, cliente, oProp, True)
            Case Is = "bnc_folio"
              oComentario = Metodos.ValidaCadena(67, cliente, oProp, True, True, 60)
            Case Is = "bnc_max_retraso"
              oComentario = Metodos.ValidaNumero(68, cliente, oProp, True, True, -1, -1)
            Case Is = "bnc_max_dias"
              oComentario = Metodos.ValidaNumero(69, cliente, oProp, True, True, -1, -1)
            Case Is = "cnbv_loca"
              oComentario = Metodos.ValidaCadena(70, cliente, oProp, True, True, 12)
            Case Is = "relacion_tipo"
              oComentario = Metodos.ValidaNumero(71, cliente, oProp, True, True, -1, -1)
            Case Is = "relacion_juridico"
              oComentario = Metodos.ValidaNumero(72, cliente, oProp, True, True, -1, -1)
            Case Is = "digito_control"
              oComentario = Metodos.ValidaNumero(73, cliente, oProp, True, True, -1, -1)
            Case Is = "cve_consolida"
              oComentario = Metodos.ValidaNumero(74, cliente, oProp, True, True, -1, -1)
            Case Is = "historia_fecha_max"
              oComentario = Metodos.ValidaFecha(75, cliente, oProp, True)
            Case Is = "historia_vigente_max"
              oComentario = Metodos.ValidaNumero(76, cliente, oProp, True, True, -1, -1)
            Case Is = "historia_vencido_max"
              oComentario = Metodos.ValidaNumero(77, cliente, oProp, True, True, -1, -1)
            Case Is = "fec_edores"
              oComentario = Metodos.ValidaFecha(78, cliente, oProp, True)
            Case Is = "nbrchequera"
              oComentario = Metodos.ValidaCadena(79, cliente, oProp, True, True, 18)
            Case Is = "metpago"
              oComentario = Metodos.ValidaNumero(80, cliente, oProp, True, True, -1, -1)
            Case Is = "patron"
              oComentario = Metodos.ValidaCadena(81, cliente, oProp, True, True, 150)
            Case Is = "etiquetas"
              oComentario = Metodos.ValidaCadena(82, cliente, oProp, True, True, 30)
            Case Is = "desbloqueado"
              oComentario = Metodos.ValidaFecha(83, cliente, oProp, True)
            Case Is = "pagodomici"
              oComentario = Metodos.ValidaBoleano(84, cliente, oProp, True)
            Case Is = "pais_actual"
              oComentario = Metodos.ValidaNumero(85, cliente, oProp, True, True, -1, -1)
            Case Is = "ingre_neto"
              oComentario = Metodos.ValidaNumero(86, cliente, oProp, True, True, -1, -1)
            Case Is = "cnbvloca2016"
              oComentario = Metodos.ValidaCadena(87, cliente, oProp, True, True, 12)
            Case Is = "fecha_variables"
              oComentario = Metodos.ValidaFecha(88, cliente, oProp, True)
            Case Is = "pagos_infonavit"
              oComentario = Metodos.ValidaNumero(89, cliente, oProp, True, True, -1, -1)
            Case Is = "numemp_a1"
              oComentario = Metodos.ValidaNumero(90, cliente, oProp, True, True, -1, -1)
            Case Is = "numemp_a1_total"
              oComentario = Metodos.ValidaNumero(91, cliente, oProp, True, True, -1, -1)
            Case Is = "numemp_a2"
              oComentario = Metodos.ValidaNumero(92, cliente, oProp, True, True, -1, -1)
            Case Is = "numemp_a2_total"
              oComentario = Metodos.ValidaNumero(93, cliente, oProp, True, True, -1, -1)
            Case Is = "numemp_a3"
              oComentario = Metodos.ValidaNumero(94, cliente, oProp, True, True, -1, -1)
            Case Is = "numemp_a3_total"
              oComentario = Metodos.ValidaNumero(95, cliente, oProp, True, True, -1, -1)
            Case Is = "mercado_proveedores"
              oComentario = Metodos.ValidaNumero(96, cliente, oProp, True, True, -1, -1)
            Case Is = "mercado_clientes"
              oComentario = Metodos.ValidaNumero(97, cliente, oProp, True, True, -1, -1)
            Case Is = "edos_finan_auditados"
              oComentario = Metodos.ValidaNumero(98, cliente, oProp, True, True, -1, -1)
            Case Is = "no_agencias_calificadoras"
              oComentario = Metodos.ValidaNumero(99, cliente, oProp, True, True, -1, -1)
            Case Is = "ind_consejo_admon"
              oComentario = Metodos.ValidaNumero(100, cliente, oProp, True, True, -1, -1)
            Case Is = "estructura_org"
              oComentario = Metodos.ValidaNumero(101, cliente, oProp, True, True, -1, -1)
            Case Is = "comp_accionaria"
              oComentario = Metodos.ValidaNumero(102, cliente, oProp, True, True, -1, -1)
            Case Is = "tipoentidad"
              oComentario = Metodos.ValidaNumero(103, cliente, oProp, True, True, -1, -1)
            Case Is = "segm_inst_finan"
              oComentario = Metodos.ValidaNumero(104, cliente, oProp, True, True, -1, -1)
            Case Is = "diversificacion_negocio_financieras"
              oComentario = Metodos.ValidaNumero(105, cliente, oProp, True, True, -1, -1)
            Case Is = "diversificacion_finaciamiento_financieras"
              oComentario = Metodos.ValidaNumero(106, cliente, oProp, True, True, -1, -1)
            Case Is = "top3_acreditados_financieras"
              oComentario = Metodos.ValidaNumero(107, cliente, oProp, True, True, -1, -1)
            Case Is = "consejeros_indep_financieras"
              oComentario = Metodos.ValidaNumero(108, cliente, oProp, True, True, -1, -1)
            Case Is = "consejeros_total_financieras"
              oComentario = Metodos.ValidaNumero(109, cliente, oProp, True, True, -1, -1)
            Case Is = "comp_accionaria_financieras"
              oComentario = Metodos.ValidaNumero(110, cliente, oProp, True, True, -1, -1)
            Case Is = "solvencia_financieras"
              oComentario = Metodos.ValidaNumero(111, cliente, oProp, True, True, -1, -1)
            Case Is = "liquidez_financieras"
              oComentario = Metodos.ValidaNumero(112, cliente, oProp, True, True, -1, -1)
            Case Is = "eficiencia_financiera"
              oComentario = Metodos.ValidaNumero(113, cliente, oProp, True, True, -1, -1)
            Case Is = "calidad_gobierno_financieras"
              oComentario = Metodos.ValidaNumero(114, cliente, oProp, True, True, -1, -1)
            Case Is = "experiencia_funcionarios_financieras"
              oComentario = Metodos.ValidaNumero(115, cliente, oProp, True, True, -1, -1)
            Case Is = "existencia_politicas_financieras"
              oComentario = Metodos.ValidaNumero(116, cliente, oProp, True, True, -1, -1)
            Case Is = "edo_financieros_audit_financieras"
              oComentario = Metodos.ValidaNumero(117, cliente, oProp, True, True, -1, -1)
            Case Is = "metpagocta"
              oComentario = Metodos.ValidaCadena(118, cliente, oProp, True, True, 20)
            Case Is = "bloqvarcual"
              oComentario = Metodos.ValidaCadena(119, cliente, oProp, True, True, 2147483647)
            Case Is = "patron_pais"
              oComentario = Metodos.ValidaNumero(120, cliente, oProp, False, False, -1, -1)
              If oComentario.Comentario.Trim.Length = 0 Then
                Me.ValidaCatalogo(120, cliente, oProp)
              End If
            Case Is = "fecreportado"
              oComentario = Metodos.ValidaFecha(121, cliente, oProp, True)
            Case Is = "ccc_previos"
              oComentario = Metodos.ValidaCadena(122, cliente, oProp, True, True, 50)
            Case Is = "ocupacion"
              oComentario = Metodos.ValidaCadena(123, cliente, oProp, True, True, 2147483647)
            Case Is = "seriefiel"
              oComentario = Metodos.ValidaCadena(124, cliente, oProp, True, True, 2147483647)
            Case Is = "tieneproveedor"
              oComentario = Metodos.ValidaBoleano(125, cliente, oProp, True)
            Case Is = "proveedores"
              oComentario = Metodos.ValidaCadena(126, cliente, oProp, True, True, 2147483647)
            Case Is = "espropietarioreal"
              oComentario = Metodos.ValidaBoleano(127, cliente, oProp, True)
            Case Is = "propietarios"
              oComentario = Metodos.ValidaCadena(128, cliente, oProp, True, True, 2147483647)
            Case Is = "puestopublico"
              oComentario = Metodos.ValidaCadena(129, cliente, oProp, True, True, 2147483647)
            Case Is = "trabajo"
              oComentario = Metodos.ValidaCadena(130, cliente, oProp, True, True, 2147483647)
            Case Is = "padre"
              oComentario = Metodos.ValidaCadena(131, cliente, oProp, True, True, 2147483647)
            Case Is = "madre"
              oComentario = Metodos.ValidaCadena(132, cliente, oProp, True, True, 2147483647)
            Case Is = "hijos"
              oComentario = Metodos.ValidaCadena(133, cliente, oProp, True, True, 2147483647)
            Case Is = "conyugue"
              oComentario = Metodos.ValidaCadena(134, cliente, oProp, True, True, 2147483647)
            Case Is = "hermanos"
              oComentario = Metodos.ValidaCadena(135, cliente, oProp, True, True, 2147483647)
            Case Is = "pexpuestoasimilado"
              oComentario = Metodos.ValidaBoleano(136, cliente, oProp, True)
            Case Is = "pepasimilado"
              oComentario = Metodos.ValidaCadena(137, cliente, oProp, True, True, 2147483647)
            Case Is = "peprelacion"
              oComentario = Metodos.ValidaCadena(138, cliente, oProp, True, True, 2147483647)
            Case Is = "pmfideicomiso"
              oComentario = Metodos.ValidaBoleano(139, cliente, oProp, True)
            Case Is = "enlistas"
              oComentario = Metodos.ValidaCadena(140, cliente, oProp, True, True, 50)
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

    Public Function Validaclientes(ByVal cliente As List(Of cliente)) As Boolean
      Dim bValida As Boolean = True
      For Each clie As cliente In cliente
        bValida = bValida And Me.Validacliente(clie)
      Next
      Return bValida
    End Function

    Private Function ValidaCatalogo(ByVal indice As Integer, ByVal clase As Object, ByVal campo As PropertyInfo) As Negocio.Validaciones.Comentario
      Dim oComentario As New Comentario
      oComentario.Indice = indice
      oComentario.Campo = campo
      oComentario.Tipo = campo.PropertyType

      Select Case campo.Name
        Case Is = "tiposociedad"
          Dim oTSdl = New DataLayer.arrendadoraDL.tiposociedadDL()
          If Not oTSdl.Existetiposociedad(campo.GetValue(clase)) Then
            oComentario.Comentario = String.Format("El valor {0} es incorrecto, revise el catálogo", campo.GetValue(clase))
            Return oComentario
          End If
        Case Is = "pais"
          Dim oPdl = New DataLayer.arrendadoraDL.paiDL()
          If Not oPdl.ExistePais(campo.GetValue(clase)) Then
            oComentario.Comentario = String.Format("El valor {0} es incorrecto, revise el catálogo", campo.GetValue(clase))
            Return oComentario
          End If
        Case Is = "edocivil"
          Dim oECdl = New DataLayer.arrendadoraDL.EstadocivilDL()
          If Not oECdl.ExisteEstadocivil(campo.GetValue(clase)) Then
            oComentario.Comentario = String.Format("El valor {0} es incorrecto, revise el catálogo", campo.GetValue(clase))
            Return oComentario
          End If
        Case Is = "identificacion"
          Dim oTIdl = New DataLayer.arrendadoraDL.TipoidDL()
          If Not oTIdl.ExisteTipoid(campo.GetValue(clase)) Then
            oComentario.Comentario = String.Format("El valor {0} es incorrecto, revise el catálogo", campo.GetValue(clase))
            Return oComentario
          End If
        Case Is = "tipovivienda"
          Dim oTVdl = New DataLayer.arrendadoraDL.TipoviviendaDL()
          If Not oTVdl.ExisteTipovivienda(campo.GetValue(clase)) Then
            oComentario.Comentario = String.Format("El valor {0} es incorrecto, revise el catálogo", campo.GetValue(clase))
            Return oComentario
          End If
        Case Is = "actividad"
          Dim oAdl = New DataLayer.arrendadoraDL.activDL()
          If Not oAdl.Existeactivi(campo.GetValue(clase)) Then
            oComentario.Comentario = String.Format("El valor {0} es incorrecto, revise el catálogo", campo.GetValue(clase))
            Return oComentario
          End If
        Case Is = "subactiv"
          Dim oSAdl = New DataLayer.arrendadoraDL.subactivDL()
          If Not oSAdl.Existesubactiv(campo.GetValue(clase)) Then
            oComentario.Comentario = String.Format("El valor {0} es incorrecto, revise el catálogo", campo.GetValue(clase))
            Return oComentario
          End If
        Case Is = "sececo"
          Dim oSEdl As New DataLayer.arrendadoraDL.sececoDL()
          If Not oSEdl.Existesececo(campo.GetValue(clase)) Then
            oComentario.Comentario = String.Format("El valor {0} es incorrecto, revise el catálogo", campo.GetValue(clase))
            Return oComentario
          End If
      End Select

      Return oComentario
    End Function

    Public Function ValidaRFCyHomoClave(ByVal pfisica As Boolean, ByVal RFC As String) As Boolean
      Dim bValida As Boolean = False

      Dim ocliente As cliente = New cliente()
      Dim oPaqueteVal As New PaqueteValidacion
      ocliente.pfisica = pfisica
      ocliente.rfc = RFC
      Dim props = ocliente.GetType().GetProperties()
      Dim prop = props.Where(Function(s) s.Name = "rfc").Single()

      With oPaqueteVal
        .Aprovado = True
        .Parametros = String.Format("parametros: pfisica:{0}, RFC:{1}", pfisica.ToString, RFC)
        Dim oComentario As Comentario = Nothing
        oComentario = Metodos.ValidaRFC(1, ocliente, prop, pfisica, False)
        If oComentario Is Nothing Then oComentario = New Negocio.Validaciones.Comentario(0, prop.PropertyType, prop, "")

        If oComentario.Comentario.Trim.Length > 0 Then
          oPaqueteVal.Aprovado = False
          If oPaqueteVal.Comentarios Is Nothing Then oPaqueteVal.Comentarios = New List(Of Comentario)
          oPaqueteVal.Comentarios.Add(New Comentario(i:=oComentario.Indice, Tipo:=oComentario.Tipo, Campo:=oComentario.Campo, Cometario:=oComentario.Comentario))
        End If

        oComentario.Dispose()
      End With

      bValida = oPaqueteVal.Aprovado

      If oPaqueteVal.Comentarios Is Nothing Then oPaqueteVal.Comentarios = New List(Of Comentario)
      If Me.PaqueteValidacion Is Nothing Then Me.PaqueteValidacion = New List(Of PaqueteValidacion)
      Me.PaqueteValidacion.Add(New PaqueteValidacion(parametros:=oPaqueteVal.Parametros, Aprovado:=oPaqueteVal.Aprovado, Comentarios:=oPaqueteVal.Comentarios))
      oPaqueteVal.Dispose()
      ocliente = Nothing

      Return bValida
    End Function

    Private Function Validapromotor(ByVal indice As Integer, ByVal clase As Object, ByVal campo As PropertyInfo) As Comentario
      Dim oComentario As New Comentario
      oComentario.Indice = indice
      oComentario.Campo = campo
      oComentario.Tipo = campo.PropertyType

      If campo.GetValue(clase) <= 0 Then
        oComentario.Comentario = "Debe seleccionar a un promotor"
      End If

      Return oComentario
    End Function

    Private Function Validaactividad(ByVal indice As Integer, ByVal clase As Object, ByVal campo As PropertyInfo) As Comentario
      Dim oComentario As New Comentario
      oComentario.Indice = indice
      oComentario.Campo = campo
      oComentario.Tipo = campo.PropertyType

      If campo.GetValue(clase) <= 0 Then
        oComentario.Comentario = "Debe seleccionar una actividad"
      End If

      Return oComentario
    End Function

    Private Function Validasubactividad(ByVal indice As Integer, ByVal clase As Object, ByVal campo As PropertyInfo) As Comentario
      Dim oComentario As New Comentario
      oComentario.Indice = indice
      oComentario.Campo = campo
      oComentario.Tipo = campo.PropertyType

      If campo.GetValue(clase) <= 0 Then
        oComentario.Comentario = "Debe seleccionar una sub actividad"
      End If

      Return oComentario
    End Function

    Private Sub NombreCompleto(ByRef cliente As cliente)
      Dim oTipoSocBL As arrendadoraBL.tiposociedadBL = Nothing
      Dim oTipoSoc As tiposociedad = Nothing
      Try
        If cliente.pfisica = True Then
          cliente.nombre = cliente.n.Trim & IIf(cliente.s.Trim.Length > 0, " " & cliente.s.Trim, "") & " " & cliente.p.Trim & If(cliente.m.Trim.Length > 0, " " & cliente.m.Trim, "")
        Else
          If cliente.sociedad.Trim.Length > 0 Then
            oTipoSocBL = New arrendadoraBL.tiposociedadBL()
            oTipoSoc = oTipoSocBL.Selecttiposociedad(cliente.tiposociedad)
            Dim bfideicomiso = If(cliente.pmfideicomiso IsNot Nothing, cliente.pmfideicomiso.Value, False)
            cliente.nombre = cliente.sociedad.Trim & IIf(oTipoSoc.abreviado.Trim.Length > 0, " " & IIf(bfideicomiso, "", oTipoSoc.abreviado.Trim), "")
          End If
        End If
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
      Finally
        oTipoSoc = Nothing
        oTipoSocBL = Nothing
      End Try
    End Sub

    Private Sub CamposenMayussinAcento(ByRef cliente As cliente)
      Dim props = cliente.GetType().GetProperties()
      Dim n = props.Where(Function(w) w.Name = "n").Single()
      Metodos.aMayusculasSinAcentos(cliente, n)
      n = Nothing
      Dim s = props.Where(Function(w) w.Name = "s").Single()
      Metodos.aMayusculasSinAcentos(cliente, s)
      s = Nothing
      Dim p = props.Where(Function(w) w.Name = "p").Single()
      Metodos.aMayusculasSinAcentos(cliente, p)
      p = Nothing
      Dim m = props.Where(Function(w) w.Name = "m").Single()
      Metodos.aMayusculasSinAcentos(cliente, m)
      m = Nothing
      Dim nombre = props.Where(Function(w) w.Name = "nombre").Single()
      Metodos.aMayusculasSinAcentos(cliente, nombre)
      nombre = Nothing
      Dim rfc = props.Where(Function(w) w.Name = "rfc").Single()
      Metodos.aMayusculasSinAcentos(cliente, rfc)
      rfc = Nothing
      Dim curp = props.Where(Function(w) w.Name = "curp").Single()
      Metodos.aMayusculasSinAcentos(cliente, curp)
      curp = Nothing
      Dim sociedad = props.Where(Function(w) w.Name = "sociedad").Single()
      Metodos.aMayusculasSinAcentos(cliente, sociedad)
      sociedad = Nothing
      props = Nothing
    End Sub

    Private Sub CamposenMinisculas(ByRef cliente As cliente)
      Dim props = cliente.GetType().GetProperties()
      Dim email = props.Where(Function(w) w.Name = "email").Single()
      Metodos.aMinusculas(cliente, email)
      email = Nothing
      props = Nothing
    End Sub

    Private Sub ClienteExtranjeto(ByRef cliente As cliente)
      If If(cliente.pais_actual Is Nothing, 0, cliente.pais_actual.Value) = 0 Then
        cliente.extranjero = False
      Else
        cliente.extranjero = True
      End If
    End Sub

  End Class
End Namespace
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
  Public Class clienteDL
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

    Private _oNewClienteOuBx As cliente
    Public Property oNewClienteOuBx() As cliente
      Get
        Return Me._oNewClienteOuBx
      End Get
      Set(value As cliente)
        If Not Me._oNewClienteOuBx Is Nothing Then Me._oNewClienteOuBx = Nothing
        Me._oNewClienteOuBx = New cliente()
        For Each prop As System.Reflection.PropertyInfo In value.GetType.GetProperties.ToList()
          prop.SetValue(_oNewClienteOuBx, prop.GetValue(value))
        Next
      End Set
    End Property

    Private _oNewClientesOuBx As List(Of cliente)
    Public Property oNewClientesOuBx() As List(Of cliente)
      Get
        Return Me._oNewClientesOuBx
      End Get
      Set(value As List(Of cliente))
        If Not Me._oNewClientesOuBx Is Nothing Then Me._oNewClientesOuBx = Nothing
        Me._oNewClientesOuBx = New List(Of cliente)
        For Each clie As cliente In value
          Dim c As New cliente()
          For Each prop As System.Reflection.PropertyInfo In clie.GetType.GetProperties.ToList()
            prop.SetValue(c, prop.GetValue(clie))
          Next
          Me._oNewClientesOuBx.Add(c)
          c = Nothing
        Next
      End Set
    End Property
    Public WriteOnly Property oNewClientesOuBx_add() As cliente
      Set(ByVal value As cliente)
        If Me._oNewClientesOuBx Is Nothing Then Me._oNewClientesOuBx = New List(Of cliente)
        Me._oNewClientesOuBx.Add(value)
      End Set
    End Property

    Private _oOriClienteOuBx As cliente
    Public Property oOriClienteOuBx() As cliente
      Get
        Return Me._oOriClienteOuBx
      End Get
      Set(value As cliente)
        If Not Me._oOriClienteOuBx Is Nothing Then Me._oOriClienteOuBx = Nothing
        Me._oOriClienteOuBx = New cliente()
        For Each prop As System.Reflection.PropertyInfo In value.GetType.GetProperties.ToList()
          prop.SetValue(_oOriClienteOuBx, prop.GetValue(value))
        Next
      End Set
    End Property

    Private _oOriClientesOuBx As List(Of cliente)
    Public Property oOriClientesOuBx() As List(Of cliente)
      Get
        Return Me._oOriClientesOuBx
      End Get
      Set(value As List(Of cliente))
        If Not Me._oOriClientesOuBx Is Nothing Then Me._oOriClientesOuBx = Nothing
        Me._oOriClientesOuBx = New List(Of cliente)
        For Each clie As cliente In value
          Dim c As New cliente()
          For Each prop As System.Reflection.PropertyInfo In clie.GetType.GetProperties.ToList()
            prop.SetValue(c, prop.GetValue(clie))
          Next
          Me._oOriClientesOuBx.Add(c)
          c = Nothing
        Next
      End Set
    End Property

    Public Function MotoresDeCredito(ByVal nbrclientecs As Decimal?, ByVal rfc As String) As sp_siclinew_Result
      Dim osicclinewresult As sp_siclinew_Result = Nothing
      Try
        MyBase.Start_context()
        osicclinewresult = context.sp_siclinew(nbrclientecs, rfc).SingleOrDefault()
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        osicclinewresult = New sp_siclinew_Result
      End Try
      Return osicclinewresult
    End Function

    Public Function Creditosxcliente(ByVal rfc As String) As List(Of sp_creditosxcliente_Result)
      Dim oCreditosxCliente As List(Of sp_creditosxcliente_Result) = Nothing
      Try
        MyBase.Start_context()
        oCreditosxCliente = context.sp_creditosxcliente(rfc).ToList()
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oCreditosxCliente = New List(Of sp_creditosxcliente_Result)
      End Try
      Return oCreditosxCliente
    End Function

    Public Function ExisteCliente(ByVal tcRfc As String, ByVal tcNom As String) As Boolean
      Dim bExiste As Boolean = False
      Try
        MyBase.Start_context()
        Dim ovar = From c As cliente In context.clientes
                   Where c.nombre = tcNom AndAlso c.rfc = tcRfc
                   Select c

        If ovar.Count > 0 Then
          bExiste = True
        Else
          bExiste = False
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        bExiste = False
      End Try
      Return bExiste
    End Function

    Public Function Selectclientes() As List(Of cliente)
      Dim oCliente As List(Of cliente) = Nothing
      Try
        MyBase.Start_context()
        Dim ovar = From c As cliente In context.clientes
                   Select c

        If ovar.Count > 0 Then
          oCliente = ovar.ToList()
        Else
          oCliente = New List(Of cliente)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oCliente = New List(Of cliente)
      End Try
      Return oCliente
    End Function

    Public Function Selectcliente(ByVal cliente As Decimal) As cliente
      Dim oCliente As cliente = Nothing
      Try
        MyBase.Start_context()
        Dim ovar = From c As cliente In context.clientes
                   Where c.cliente_id = cliente AndAlso c.cliente_id > 0
                   Select c

        If ovar.Count > 0 Then
          oCliente = ovar.Single()
        Else
          oCliente = New cliente()
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oCliente = New cliente()
      End Try
      Return oCliente
    End Function

    Public Function Selectclientes(ByVal clientes As List(Of Decimal)) As List(Of cliente)
      Dim oClientes As List(Of cliente) = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From c In context.clientes
                   Where clientes.Contains(c.cliente_id) AndAlso c.cliente_id > 0
                   Select c

        If oVar.Count() > 0 Then
          oClientes = oVar.ToList()
        Else
          oClientes = New List(Of cliente)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oClientes = New List(Of cliente)
      End Try
      Return oClientes
    End Function

    Public Function Selectclientes(ByVal riesgo As Decimal) As List(Of cliente)
      Dim oclientes As List(Of cliente) = Nothing
      Try
        MyBase.Start_context()
        Dim ovar = From c As cliente In context.clientes
                   Where c.riesgo = riesgo AndAlso c.cliente_id > 0
                   Select c

        If ovar.Count() > 0 Then
          oclientes = ovar.ToList()
        Else
          oclientes = New List(Of cliente)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oclientes = New List(Of cliente)
      End Try
      Return oclientes
    End Function

    Public Function SelectclientebyRFC(ByVal RFC As String) As cliente
      Dim ocliente As cliente = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From clie As cliente In context.clientes
                   Where clie.rfc = RFC AndAlso clie.cliente_id > 0
                   Select clie

        If oVar.Count() > 0 Then
          ocliente = oVar.Single()
        Else
          ocliente = New cliente()
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        ocliente = New cliente
      End Try
      Return ocliente
    End Function

    Public Function Selectclientebynbr(ByVal nbrclientecs As Integer) As cliente
      Dim oCliente As cliente = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From clie As cliente In context.clientes
                   Where clie.nbrclientecs = nbrclientecs AndAlso clie.cliente_id > 0
                   Select clie

        If (oVar.Count > 0) Then
          If (oVar.Count > 1) Then
            oCliente = New cliente
          Else
            oCliente = oVar.Single()
          End If
        Else
          oCliente = New cliente
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oCliente = New cliente
      End Try
      Return oCliente
    End Function

    Public Function getSaldoInsolutoCliente(ByVal cliente As Integer, SumaIvaInsoluto As Boolean) As Double
      Dim nSaldoInsoluto As Double = 0
      Try
        MyBase.Start_context()
        nSaldoInsoluto = context.getSaldoInsolutoCliente(cliente, SumaIvaInsoluto)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        nSaldoInsoluto = 0
      End Try
      Return nSaldoInsoluto
    End Function

    Public Function getSaldoInsolutoContrato(ByVal contrato As Integer, SumaIvaInsoluto As Boolean) As Double
      Dim nSaldoInsoluto As Double = 0
      Try
        MyBase.Start_context()
        nSaldoInsoluto = context.getSaldoInsolutoContrato(contrato, SumaIvaInsoluto)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        nSaldoInsoluto = 0
      End Try
      Return nSaldoInsoluto
    End Function

    Public Function SelectclientebyNombrebyNumero(ByVal cliente As Decimal?, Optional ByVal nombre As String = Nothing, Optional ByVal oficinas As String = Nothing) As List(Of sp_clientesBusquedaXNombreXCliente_Result)
      Dim oClienteporNombreporCliente As List(Of sp_clientesBusquedaXNombreXCliente_Result) = Nothing
      Try
        MyBase.Start_context()
        oClienteporNombreporCliente = context.sp_clientesBusquedaXNombreXCliente(cliente, nombre, oficinas).ToList
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oClienteporNombreporCliente = New List(Of sp_clientesBusquedaXNombreXCliente_Result)
      End Try
      Return oClienteporNombreporCliente
    End Function

    Public Function SelectclientebyNombreClienteRiesgo(ByVal cliente As Decimal?, Optional ByVal nombre As String = "{string.value.null}", Optional ByVal oficinas As Decimal() = Nothing) As List(Of ClienteporNombreClienteRiesgo_Result)
      Dim oClienteporNombreClienteRiesgo As List(Of ClienteporNombreClienteRiesgo_Result) = Nothing
      Dim oVar As System.Linq.IQueryable(Of ClienteporNombreClienteRiesgo_Result) = Nothing
      Try
        MyBase.Start_context()
        If (nombre <> "{string.value.null}") Then
          If (oficinas IsNot Nothing) Then
            oVar = From clie As cliente In context.clientes
                    Where clie.cliente_id = If(cliente IsNot Nothing, cliente, clie.cliente_id) AndAlso SqlMethods.Like(clie.nombre, nombre.Trim + "%") AndAlso oficinas.Contains(clie.origen)
                    Order By clie.nombre
                    Select New ClienteporNombreClienteRiesgo_Result With {.nombre = clie.nombre,
                                                                            .cliente = clie.cliente_id,
                                                                            .riesgo = clie.riesgo
                                                                          }

          Else
            oVar = From clie As cliente In context.clientes
                    Where clie.cliente_id = If(cliente IsNot Nothing, cliente, clie.cliente_id) AndAlso SqlMethods.Like(clie.nombre, nombre.Trim + "%")
                    Order By clie.nombre
                    Select New ClienteporNombreClienteRiesgo_Result With {.nombre = clie.nombre,
                                                                            .cliente = clie.cliente_id,
                                                                            .riesgo = clie.riesgo
                                                                          }

          End If
        Else
          If (oficinas IsNot Nothing) Then
            oVar = From clie As cliente In context.clientes
                    Where clie.cliente_id = If(cliente IsNot Nothing, cliente, clie.cliente_id) AndAlso oficinas.Contains(clie.origen)
                    Order By clie.nombre
                    Select New ClienteporNombreClienteRiesgo_Result With {.nombre = clie.nombre,
                                                                            .cliente = clie.cliente_id,
                                                                            .riesgo = clie.riesgo
                                                                            }

          Else
            oVar = From clie As cliente In context.clientes
                    Where clie.cliente_id = If(cliente IsNot Nothing, cliente, clie.cliente_id)
                    Order By clie.nombre
                    Select New ClienteporNombreClienteRiesgo_Result With {.nombre = clie.nombre,
                                                                            .cliente = clie.cliente_id,
                                                                            .riesgo = clie.riesgo
                                                                          }
          End If
        End If

        If (oVar.Count() > 0) Then
          oClienteporNombreClienteRiesgo = oVar.Take(50).ToList()
        Else
          oClienteporNombreClienteRiesgo = New List(Of ClienteporNombreClienteRiesgo_Result)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oClienteporNombreClienteRiesgo = New List(Of ClienteporNombreClienteRiesgo_Result)
      End Try

      Return oClienteporNombreClienteRiesgo
    End Function

    Public Function Clientes_resumen(nOficina As Integer, nCredito As Integer, nCliente As Integer) As sp_clientes_resumen_Result
      Dim oClientesResumen As sp_clientes_resumen_Result = Nothing
      Try
        MyBase.Start_context()
        oClientesResumen = context.sp_clientes_resumen(nOficina, nCredito, nCliente).Single
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oClientesResumen = New sp_clientes_resumen_Result
      End Try
      Return oClientesResumen
    End Function

    Public Function GetCalificacionCarteraPre(ByVal ncliente As Integer) As DataTable
      Dim odt As DataTable = Nothing
      Dim ocmd As SqlCommand
      Try
        MyBase.Start_context()
        ocmd = New SqlCommand
        ocmd.CommandType = CommandType.StoredProcedure
        ocmd.CommandText = "sp_calificacionDeCarteraSOFOM2014_pre"
        ocmd.Parameters.AddWithValue("@persona", ncliente)
        odt = MyBase.GetTable(ocmd)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        odt = New DataTable("table")
      End Try
      Return odt
    End Function

    Public Function GetInformacionFinancieraCliente(ByVal ncliente As Integer) As List(Of InformacionFinancieraCliente_Result)
      Dim oInfoFinanciera As List(Of InformacionFinancieraCliente_Result) = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = (From clte As cliente In context.clientes
                   Where clte.cliente_id = ncliente
                   Select New InformacionFinancieraCliente_Result With {.fecha_info = clte.fecbalance, _
                                                                          .cliente = clte.cliente_id, _
                                                                          .activo = clte.activo / 1000, _
                                                                          .pasivo = clte.pasivo / 1000, _
                                                                          .capital = clte.capital / 1000, _
                                                                          .ingresos = clte.ingresos / 1000, _
                                                                          .utilidad_neta = 0}).Distinct().OrderByDescending(Function(o) o.fecha_info).ToList()

        If (oVar.Count() > 0) Then
          oInfoFinanciera = oVar.ToList()
        Else
          oInfoFinanciera = New List(Of InformacionFinancieraCliente_Result)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oInfoFinanciera = New List(Of InformacionFinancieraCliente_Result)
      End Try
      Return oInfoFinanciera
    End Function

    Public Function SelectClientesOficina(ByVal cliente As Decimal) As List(Of ClientesOficina_Result)
      Dim oClientesOficina As List(Of ClientesOficina_Result) = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From clie As cliente In context.clientes
                    Join ofi As oficina In context.oficinas On clie.origen Equals ofi.oficina_id
                    Where clie.cliente_id = cliente
                    Select New ClientesOficina_Result With {.origen = clie.origen,
                                                            .cliente = clie.cliente_id,
                                                            .nombre = clie.nombre,
                                                            .riesgo = clie.riesgo,
                                                            .oficina = ofi.nombre}

        If (oVar.Count() > 0) Then
          oClientesOficina = oVar.ToList()
        Else
          oClientesOficina = New List(Of ClientesOficina_Result)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oClientesOficina = New List(Of ClientesOficina_Result)
      End Try
      Return oClientesOficina
    End Function

    Public Function SelectClientesOficina(ByVal clientes As List(Of Decimal)) As List(Of ClientesOficina_Result)
      Dim oClientesOficina As List(Of ClientesOficina_Result) = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From clie As cliente In context.clientes
                    Join ofi As oficina In context.oficinas On clie.origen Equals ofi.oficina_id
                    Where clientes.Contains(clie.cliente_id)
                    Select New ClientesOficina_Result With {.origen = clie.origen,
                                                            .cliente = clie.cliente_id,
                                                            .nombre = clie.nombre,
                                                            .riesgo = clie.riesgo,
                                                            .oficina = ofi.nombre}

        If (oVar.Count() > 0) Then
          oClientesOficina = oVar.ToList()
        Else
          oClientesOficina = New List(Of ClientesOficina_Result)
        End If

      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oClientesOficina = New List(Of ClientesOficina_Result)
      End Try

      Return oClientesOficina
    End Function

    Public Function Selectcliente(ByVal ctes As List(Of Decimal)) As List(Of cliente)
      Dim oCliente As List(Of cliente) = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From clie As cliente In context.clientes
                    Where ctes.Contains(clie.cliente_id)
                    Select clie

        If (oVar.Count() > 0) Then
          oCliente = oVar.ToList()
        Else
          oCliente = New List(Of cliente)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oCliente = New List(Of cliente)
      End Try
      Return oCliente
    End Function

    Public Function SelectclientebylikeNombrebyCliente(ByVal oficina As Integer, ByVal oficinas As List(Of Decimal), ByVal key As String) As List(Of ClienteporNombreClienteRFC_Result)
      Dim oClienteporNombreClienteRFC As List(Of ClienteporNombreClienteRFC_Result) = Nothing
      Try
        MyBase.Start_context()

        If oficina > 1 Then
          If Not IsNumeric(key) Then
            Dim oVar = From c As cliente In context.clientes
                       Where oficinas.Contains(c.origen) AndAlso SqlMethods.Like(c.nombre, "%" + key.Trim + "%")
                       Select New ClienteporNombreClienteRFC_Result With {.nom = "(" + c.cliente_id.ToString() + ")" + c.nombre,
                                                                          .nombre = c.nombre,
                                                                          .cliente = c.cliente_id,
                                                                          .rfc = c.rfc,
                                                                          .pfisica = c.pfisica}

            If oVar.Count > 0 Then
              oClienteporNombreClienteRFC = oVar.ToList()
            Else
              oClienteporNombreClienteRFC = New List(Of ClienteporNombreClienteRFC_Result)
            End If

          Else
            Dim oVar = From c As cliente In context.clientes
                       Where oficinas.Contains(c.origen) AndAlso c.cliente_id = Convert.ToDecimal(key)
                       Select New ClienteporNombreClienteRFC_Result With {.nom = "(" + c.cliente_id.ToString() + ")" + c.nombre,
                                                                          .nombre = c.nombre,
                                                                          .cliente = c.cliente_id,
                                                                          .rfc = c.rfc,
                                                                          .pfisica = c.pfisica}

            If oVar.Count > 0 Then
              oClienteporNombreClienteRFC = oVar.ToList()
            Else
              oClienteporNombreClienteRFC = New List(Of ClienteporNombreClienteRFC_Result)
            End If

          End If

        Else
          If Not IsNumeric(key) Then
            Dim oVar = From c As cliente In context.clientes
                       Where SqlMethods.Like(c.nombre, "%" + key.Trim + "%")
                       Select New ClienteporNombreClienteRFC_Result With {.nom = "(" + c.cliente_id.ToString() + ")" + c.nombre,
                                                                          .nombre = c.nombre,
                                                                          .cliente = c.cliente_id,
                                                                          .rfc = c.rfc,
                                                                          .pfisica = c.pfisica}

            If oVar.Count > 0 Then
              oClienteporNombreClienteRFC = oVar.ToList()
            Else
              oClienteporNombreClienteRFC = New List(Of ClienteporNombreClienteRFC_Result)
            End If

          Else
            Dim oVar = From c As cliente In context.clientes
                       Where c.cliente_id = Convert.ToDecimal(key)
                       Select New ClienteporNombreClienteRFC_Result With {.nom = "(" + c.cliente_id.ToString() + ")" + c.nombre,
                                                                          .nombre = c.nombre,
                                                                          .cliente = c.cliente_id,
                                                                          .rfc = c.rfc,
                                                                          .pfisica = c.pfisica}

            If oVar.Count > 0 Then
              oClienteporNombreClienteRFC = oVar.ToList()
            Else
              oClienteporNombreClienteRFC = New List(Of ClienteporNombreClienteRFC_Result)
            End If

          End If

        End If

      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oClienteporNombreClienteRFC = New List(Of ClienteporNombreClienteRFC_Result)
      End Try
      Return oClienteporNombreClienteRFC
    End Function

    Public Function getdigito_bancomer04(ByVal sofaclte As String) As String
      Dim sdigito_bancomer04 As String = ""
      Try
        MyBase.Start_context()
        sdigito_bancomer04 = context.digito_Bancomer04(sofaclte)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        sdigito_bancomer04 = ""
      End Try
      Return sdigito_bancomer04
    End Function

    Public Function getdigito_banamex97(ByVal sofclte As String) As String
      Dim sdigito_banamex97 As String = ""
      Try
        MyBase.Start_context()
        sdigito_banamex97 = context.digito_Banamex97(sofclte)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        sdigito_banamex97 = ""
      End Try
      Return sdigito_banamex97
    End Function

    Public Function Submit(ByRef pcliente As cliente) As Boolean
      Dim bTrans As Boolean = False
      Try
        Dim dcliente = pcliente.cliente_id
        Dim dorigen = pcliente.origen
        MyBase.Start_context()

        Dim oCliente = From c1 As cliente In context.clientes
                       Where c1.cliente_id = dcliente And c1.cliente_id > 0
                       Select c1

        Me.oNewClienteOuBx = pcliente

        If (oCliente.Count() > 0) Then
          Me.oOriClienteOuBx = oCliente.Single()

          For Each prop In pcliente.GetType.GetProperties.ToList
            prop.SetValue(oCliente.Single(), prop.GetValue(pcliente))
          Next

          context.SaveChanges()
          bTrans = True
        Else
          pcliente.cliente_id = context.sp_Nuevo_Cliente(pcliente.origen).Value
          Me.oNewClienteOuBx.cliente_id = pcliente.cliente_id
          context.clientes.Add(pcliente)
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

    Public Function Submit(ByRef clientes As List(Of cliente)) As Boolean
      Dim bTrans As Boolean = False

      Try
        MyBase.Start_context()

        Dim oLlaves = clientes.Select(Function(s) s.cliente_id).ToList()

        Dim oClientes = From c As cliente In context.clientes
                        Where oLlaves.Contains(c.cliente_id) AndAlso c.cliente_id > 0
                        Select c

        If (oClientes.Count() > 0) Then
          If Not Me._oNewClientesOuBx Is Nothing Then Me._oNewClientesOuBx = Nothing
          Me.oOriClientesOuBx = oClientes.ToList()

          Dim props = clientes.ElementAt(0).GetType().GetProperties()
          Dim oInsert As New List(Of cliente)          

          For Each oUpdate As cliente In oClientes.ToList()
            Dim oclie = clientes.Where(Function(w) w.cliente_id = oUpdate.cliente_id)
            If oclie.Count() > 0 Then
              For Each prop As System.Reflection.PropertyInfo In props.ToList()
                prop.SetValue(oUpdate, prop.GetValue(oclie.Single()))
              Next
            Else
              oInsert.Add(oUpdate)
            End If
          Next

          If (oInsert.Count() > 0) Then
            For Each oclie In oInsert.ToList()
              oclie.cliente_id = context.sp_Nuevo_Cliente(oclie.origen).Value
              Me.oNewClientesOuBx_add = oclie
            Next
            context.clientes.Add(DirectCast(oInsert.ToList(), IEnumerable(Of cliente)))
          End If

          context.SaveChanges()
          bTrans = True

        Else
          For Each oclie In clientes
            oclie.cliente_id = context.sp_Nuevo_Cliente(oclie.origen).Value
          Next
          Me.oNewClientesOuBx = clientes
          context.clientes.Add(DirectCast(clientes, IEnumerable(Of cliente)))
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

    Public Function ExisteRFC(ByVal RFC As String, ByVal oficinas As String) As Boolean
      Dim bExiste As Boolean = False
      Try
        MyBase.Start_context()
        Dim nOficinas = oficinas.Trim.Split(",").Select(Function(s) Convert.ToDecimal(s.Trim)).ToList()
        Dim oVar = From clie As cliente In context.clientes
                    Where clie.rfc = RFC AndAlso nOficinas.Contains(clie.origen)
                    Select clie

        bExiste = oVar.Count > 0
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        bExiste = False
      End Try
      Return bExiste
    End Function

    Public Function riesgo_RiesgoDeCliente(ByVal cliente As Integer) As Integer
      Dim nriesgo As Integer
      Try
        MyBase.Start_context()
        nriesgo = context.riesgo_RiesgoDeCliente(cliente)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        nriesgo = 0
      End Try
      Return nriesgo
    End Function

    Public Function riesgo_RiesgoDeCliente2016(ByVal cliente As Integer, ByVal pldhist As Boolean) As Integer
      Dim nriesgo2016 As Integer
      Try
        MyBase.Start_context()
        nriesgo2016 = context.sp_RiesgoDeClientePLD(cliente, pldhist)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        nriesgo2016 = 0
      End Try
      Return nriesgo2016
    End Function

    Public Function riesgo_RiesgoDeEdad2016(ByVal cliente As Integer, ByVal pfisica As Boolean, ByVal pfempre As Boolean) As Integer
      Dim nriesgoedad2016 As Integer
      Try
        MyBase.Start_context()
        nriesgoedad2016 = context.riesgo_RiesgoDeEdad2016(cliente, pfisica, pfempre)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        nriesgoedad2016 = 0
      End Try
      Return nriesgoedad2016
    End Function

    Public Function riesgo_RiesgoDeSubactividad(ByVal cliente As Integer) As Integer
      Dim nriesgosubactividad As Integer
      Try
        MyBase.Start_context()
        nriesgosubactividad = context.riesgo_RiesgoDeSubActividad(cliente)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        nriesgosubactividad = 0
      End Try
      Return nriesgosubactividad
    End Function

    Public Function riesgo_RiesgoDeEntidad2016(ByVal cliente As Integer) As Integer
      Dim nriesgoentidad2016 As Integer
      Try
        MyBase.Start_context()
        nriesgoentidad2016 = context.riesgo_RiesgoDeEntidad2016(cliente)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        nriesgoentidad2016 = 0
      End Try
      Return nriesgoentidad2016
    End Function

    Public Function riesgo_RiesgoDePolitico2016(ByVal cliente As Integer) As Integer
      Dim nriesgopolitico2016 As Integer
      Try
        MyBase.Start_context()
        nriesgopolitico2016 = context.riesgo_RiesgoDeEntidad2016(cliente)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        nriesgopolitico2016 = 0
      End Try
      Return nriesgopolitico2016
    End Function

    Public Function riesgo_RiesgoDePais(ByVal cliente As Integer) As Integer
      Dim nriesgopais As Integer
      Try
        MyBase.Start_context()
        nriesgopais = context.riesgo_RiesgoDePais(cliente)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        nriesgopais = 0
      End Try
      Return nriesgopais
    End Function

    Public Function riesgo_RiesgoDeEdad(ByVal cliente As Integer) As Integer
      Dim nriesgoedad As Integer
      Try
        MyBase.Start_context()
        nriesgoedad = context.riesgo_RiesgoDeEdad(cliente)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        nriesgoedad = 0
      End Try
      Return nriesgoedad
    End Function

    Public Function riesgo_RiesgoDeActividad(ByVal cliente As Integer) As Integer
      Dim nriesgoactividad As Integer
      Try
        MyBase.Start_context()
        nriesgoactividad = context.riesgo_RiesgoDeActividad(cliente)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        nriesgoactividad = 0
      End Try
      Return nriesgoactividad
    End Function

    Public Function riesgo_RiesgoDeEntidad(ByVal cliente As Integer) As Integer
      Dim nriesgoentidad As Integer
      Try
        MyBase.Start_context()
        nriesgoentidad = context.riesgo_RiesgoDeEntidad(cliente)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        nriesgoentidad = 0
      End Try
      Return nriesgoentidad
    End Function

    Public Function riesgo_RiesgoDePolitico(ByVal cliente As Integer) As Integer
      Dim nriesgopolitico As Integer
      Try
        MyBase.Start_context()
        nriesgopolitico = context.riesgo_RiesgoDePolitico(cliente)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        nriesgopolitico = 0
      End Try
      Return nriesgopolitico
    End Function

    Public Function riesgo_RiesgoDeExtranjero(ByVal cliente As Integer) As Integer
      Dim nriesgoextranjero As Integer
      Try
        MyBase.Start_context()
        nriesgoextranjero = context.riesgo_RiesgoDeExtranjero(cliente)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        nriesgoextranjero = 0
      End Try
      Return nriesgoextranjero
    End Function

    Public Function selClientesGruporiesgo(ByVal grupo As Integer) As List(Of sp_selClientesGruporiesgo_Result)
      Dim oclienesriesgo As List(Of sp_selClientesGruporiesgo_Result) = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = context.clientes.Where(Function(w) w.riesgo = grupo).Select(Function(s) New sp_selClientesGruporiesgo_Result With {.cliente = s.cliente_id, .nombre = s.nombre, .saldo = context.getSaldoInsolutoCliente(s.cliente_id, Nothing)})
        If oVar.Count > 0 Then
          oclienesriesgo = oVar.ToList()
        Else
          oclienesriesgo = New List(Of sp_selClientesGruporiesgo_Result)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oclienesriesgo = New List(Of sp_selClientesGruporiesgo_Result)
      End Try
      Return oclienesriesgo
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
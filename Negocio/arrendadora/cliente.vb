Imports System
Imports System.Data
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports DataLayer
Imports DataLayer.arrendadoraDL
Imports Entidades
Imports Entidades.arrendadora

Namespace arrendadora

  Public MustInherit Class cliente
    Inherits standardization
    Implements IDisposable

    Public Property clienteDL() As clienteDL
    Public Property Err() As Exception
    Public Property hayErr() As Boolean

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
      Me.hayErr = False
      Me.Err = Nothing
      Me.clienteDL = New clienteDL()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="sconn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal sconn As String)
      Me.hayErr = False
      Me.Err = Nothing
      Me.clienteDL = New clienteDL(sconn)
    End Sub

    Public Overridable Function MotoresDeCredito(ByVal nbrclientecs As Decimal?, ByVal rfc As String) As Entidades.arrendadora.sp_siclinew_Result
      Dim osicclinewresult As Entidades.arrendadora.sp_siclinew_Result = Nothing
      Try
        osicclinewresult = Me.clienteDL.MotoresDeCredito(nbrclientecs, rfc)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        osicclinewresult = New Entidades.arrendadora.sp_siclinew_Result
      End Try
      Return osicclinewresult
    End Function

    Public Overridable Function Creditosxcliente(ByVal rfc As String) As List(Of Entidades.arrendadora.sp_creditosxcliente_Result)
      Dim oCreditosxClienteResult As List(Of Entidades.arrendadora.sp_creditosxcliente_Result) = Nothing
      Try
        oCreditosxClienteResult = Me.clienteDL.Creditosxcliente(rfc)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oCreditosxClienteResult = New List(Of Entidades.arrendadora.sp_creditosxcliente_Result)
      End Try
      Return oCreditosxClienteResult
    End Function

    Public Overridable Function Clientes_resumen(nOficina As Integer, nCredito As Integer, nCliente As Integer) As Entidades.arrendadora.sp_clientes_resumen_Result
      Dim oClientesResumen As Entidades.arrendadora.sp_clientes_resumen_Result = Nothing
      Try
        oClientesResumen = Me.clienteDL.Clientes_resumen(nOficina, nCredito, nCliente)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oClientesResumen = New Entidades.arrendadora.sp_clientes_resumen_Result
      End Try
      Return oClientesResumen
    End Function

    Public Overridable Function ExisteCliente(ByVal tcRfc As String, ByVal tcNom As String) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Me.clienteDL.ExisteCliente(tcRfc, tcNom)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        bTrans = False
      End Try
      Return bTrans
    End Function

    Public Overridable Function Selectclientes() As List(Of Entidades.arrendadora.cliente)
      Dim oCliente As List(Of Entidades.arrendadora.cliente) = Nothing
      Try
        oCliente = Me.clienteDL.Selectclientes()
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oCliente = New List(Of Entidades.arrendadora.cliente)
      End Try
      Return oCliente
    End Function

    Public Overridable Function Selectcliente(ByVal cliente As Decimal) As Entidades.arrendadora.cliente
      Dim oCliente As Entidades.arrendadora.cliente = Nothing
      Try
        oCliente = Me.clienteDL.Selectcliente(cliente)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oCliente = New Entidades.arrendadora.cliente
        oCliente.cliente_id = -1
      End Try
      Return oCliente
    End Function

    Public Overridable Function Selectclientes(ByVal clientes As List(Of Decimal)) As List(Of Entidades.arrendadora.cliente)
      Dim oClientes As List(Of Entidades.arrendadora.cliente) = Nothing
      Try
        oClientes = Me.clienteDL.Selectclientes(clientes)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oClientes = New List(Of Entidades.arrendadora.cliente)
      End Try
      Return oClientes
    End Function

    Public Overridable Function Selectclientes(ByVal riesgo As Decimal) As List(Of Entidades.arrendadora.cliente)
      Dim oclientes As List(Of Entidades.arrendadora.cliente) = Nothing
      Try
        oclientes = Me.clienteDL.Selectclientes(riesgo)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oclientes = New List(Of Entidades.arrendadora.cliente)
      End Try
      Return oclientes
    End Function

    Public Overridable Function SelectclientebyRFC(ByVal pfisica As Boolean, ByVal RFC As String) As Entidades.arrendadora.cliente
      Dim ocliente As Entidades.arrendadora.cliente = Nothing
      Try
        ocliente = Me.clienteDL.SelectclientebyRFC(RFC)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        ocliente = New Entidades.arrendadora.cliente
        ocliente.cliente_id = -1
      End Try
      Return ocliente
    End Function

    Public Overridable Function Selectclientebynbr(ByVal nbrclientecs As Integer) As Entidades.arrendadora.cliente
      Dim oCliente As Entidades.arrendadora.cliente = Nothing
      Try
        oCliente = Me.clienteDL.Selectclientebynbr(nbrclientecs)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oCliente = New Entidades.arrendadora.cliente
        oCliente.cliente_id = -1
      End Try
      Return oCliente
    End Function

    Public Overridable Function GetCalificacionCarteraPre(ByVal ncliente As Integer) As DataTable
      Dim odt As DataTable = Nothing
      Try
        odt = Me.clienteDL.GetCalificacionCarteraPre(ncliente)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        odt = New DataTable
      End Try
      Return odt
    End Function

    Public Overridable Function GetInformacionFinancieraCliente(ByVal ncliente As Integer) As List(Of Entidades.arrendadora.InformacionFinancieraCliente_Result)
      Dim oInfoFinanciera As List(Of Entidades.arrendadora.InformacionFinancieraCliente_Result) = Nothing
      Try
        oInfoFinanciera = Me.clienteDL.GetInformacionFinancieraCliente(ncliente)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oInfoFinanciera = New List(Of Entidades.arrendadora.InformacionFinancieraCliente_Result)
      End Try
      Return oInfoFinanciera
    End Function

    Public Overridable Function getSaldoInsolutoCliente(ByVal cliente As Integer, SumaIvaInsoluto As Boolean) As Double
      Dim nSaldoInsoluto As Double = 0
      Try
        nSaldoInsoluto = Me.clienteDL.getSaldoInsolutoCliente(cliente, SumaIvaInsoluto)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        nSaldoInsoluto = 0
      End Try
      Return nSaldoInsoluto
    End Function

    Public Overridable Function getSaldoInsolutoContrato(ByVal contrato As Integer, ByVal SumaIvaInsoluto As Boolean) As Double
      Dim nSaldoInsoluto As Double = 0
      Try
        nSaldoInsoluto = Me.clienteDL.getSaldoInsolutoContrato(contrato, SumaIvaInsoluto)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        nSaldoInsoluto = 0
      End Try
      Return nSaldoInsoluto
    End Function

    Public Overridable Function SelectclientebyNombrebyNumero(ByVal cliente As Decimal?, Optional ByVal nombre As String = Nothing, Optional ByVal oficinas As String = Nothing) As List(Of Entidades.arrendadora.sp_clientesBusquedaXNombreXCliente_Result)
      Dim oClienteporNombreporClienteResult As List(Of Entidades.arrendadora.sp_clientesBusquedaXNombreXCliente_Result) = Nothing
      Try
        oClienteporNombreporClienteResult = Me.clienteDL.SelectclientebyNombrebyNumero(cliente, nombre, oficinas)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oClienteporNombreporClienteResult = New List(Of Entidades.arrendadora.sp_clientesBusquedaXNombreXCliente_Result)
      End Try
      Return oClienteporNombreporClienteResult
    End Function

    Public Overridable Function SelectclientebyNombreClienteRiesgo(ByVal cliente As Decimal?, Optional ByVal nombre As String = "{string.value.null}", Optional ByVal oficinas As Decimal() = Nothing) As List(Of Entidades.arrendadora.ClienteporNombreClienteRiesgo_Result)
      Dim oClienteporNombreClienteRiesgo As List(Of Entidades.arrendadora.ClienteporNombreClienteRiesgo_Result) = Nothing
      Try
        oClienteporNombreClienteRiesgo = Me.clienteDL.SelectclientebyNombreClienteRiesgo(cliente, nombre, oficinas)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oClienteporNombreClienteRiesgo = New List(Of Entidades.arrendadora.ClienteporNombreClienteRiesgo_Result)
      End Try
      Return oClienteporNombreClienteRiesgo
    End Function

    Public Overridable Function SelectClientesOficina(ByVal cliente As Decimal) As List(Of Entidades.arrendadora.ClientesOficina_Result)
      Dim oClientesOficina As List(Of Entidades.arrendadora.ClientesOficina_Result) = Nothing
      Try
        oClientesOficina = Me.clienteDL.SelectClientesOficina(cliente)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oClientesOficina = New List(Of Entidades.arrendadora.ClientesOficina_Result)
      End Try
      Return oClientesOficina
    End Function

    Public Overridable Function SelectClientesOficina(ByVal clientes As List(Of Decimal)) As List(Of Entidades.arrendadora.ClientesOficina_Result)
      Dim oClientesOficina As List(Of Entidades.arrendadora.ClientesOficina_Result) = Nothing
      Try
        oClientesOficina = Me.clienteDL.SelectClientesOficina(clientes)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oClientesOficina = New List(Of Entidades.arrendadora.ClientesOficina_Result)
      End Try
      Return oClientesOficina
    End Function

    Public Overridable Function Selectcliente(ByVal ctes As List(Of Decimal)) As List(Of Entidades.arrendadora.cliente)
      Dim oCliente As List(Of Entidades.arrendadora.cliente) = Nothing
      Try
        oCliente = Me.clienteDL.Selectcliente(ctes)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oCliente = New List(Of Entidades.arrendadora.cliente)
      End Try
      Return oCliente
    End Function

    Public Overridable Function SelectclientebylikeNombrebyCliente(ByVal oficina As Integer, ByVal oficinas As List(Of Decimal), ByVal key As String) As List(Of Entidades.arrendadora.ClienteporNombreClienteRFC_Result)
      Dim oClienteporNombreClienteRFC As List(Of Entidades.arrendadora.ClienteporNombreClienteRFC_Result) = Nothing
      Try
        oClienteporNombreClienteRFC = Me.clienteDL.SelectclientebylikeNombrebyCliente(oficina, oficinas, key)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oClienteporNombreClienteRFC = New List(Of Entidades.arrendadora.ClienteporNombreClienteRFC_Result)
      End Try
      Return oClienteporNombreClienteRFC
    End Function

    Public Overridable Function getdigito_bancomer04(ByVal sofaclte As String) As String
      Dim sdigito_bancomer04 As String = ""
      Try
        sdigito_bancomer04 = Me.clienteDL.getdigito_bancomer04(sofaclte)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        sdigito_bancomer04 = ""
      End Try
      Return sdigito_bancomer04
    End Function

    Public Overridable Function getdigito_banamex97(ByVal sofclte As String) As String
      Dim sdigito_banamex97 As String = ""
      Try
        sdigito_banamex97 = Me.clienteDL.getdigito_banamex97(sofclte)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        sdigito_banamex97 = ""
      End Try
      Return sdigito_banamex97
    End Function

    Public Overridable Function Submit(ByRef cliente As Entidades.arrendadora.cliente) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Me.clienteDL.Submit(cliente)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        bTrans = False
      End Try
      Return bTrans
    End Function

    Public Overridable Function Submit(ByRef clientes As List(Of Entidades.arrendadora.cliente)) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Me.clienteDL.Submit(clientes)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        bTrans = False
      End Try
      Return bTrans
    End Function

    Public Overridable Function ExisteRFC(ByVal RFC As String, ByVal oficinas As String) As Boolean
      Dim bExiste As Boolean = False
      Try
        bExiste = Me.clienteDL.ExisteRFC(RFC, oficinas)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        bExiste = False
      End Try
      Return bExiste
    End Function

    Public Overridable Function riesgo_RiesgoDeCliente(ByVal cliente As Integer) As Integer
      Dim nriesgo As Integer
      Try
        nriesgo = Me.clienteDL.riesgo_RiesgoDeCliente(cliente)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        nriesgo = 0
      End Try
      Return nriesgo
    End Function

    Public Overridable Function riesgo_RiesgoDeCliente2016(ByVal cliente As Integer, ByVal pldhist As Boolean) As Integer
      Dim nriesgo2016 As Integer
      Try
        nriesgo2016 = Me.clienteDL.riesgo_RiesgoDeCliente2016(cliente, pldhist)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        nriesgo2016 = 0
      End Try
      Return nriesgo2016
    End Function

    Public Overridable Function riesgo_RiesgoDeEdad2016(ByVal cliente As Integer, ByVal pfisica As Boolean, ByVal pfempre As Boolean) As Integer
      Dim nriesgoedad2016 As Integer
      Try
        nriesgoedad2016 = Me.clienteDL.riesgo_RiesgoDeEdad2016(cliente, pfisica, pfempre)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        nriesgoedad2016 = 0
      End Try
      Return nriesgoedad2016
    End Function

    Public Overridable Function riesgo_RiesgoDeSubactividad(ByVal cliente As Integer) As Integer
      Dim nriesgosubactividad As Integer
      Try
        nriesgosubactividad = Me.clienteDL.riesgo_RiesgoDeSubactividad(cliente)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        nriesgosubactividad = 0
      End Try
      Return nriesgosubactividad
    End Function

    Public Overridable Function riesgo_RiesgoDeEntidad2016(ByVal cliente As Integer) As Integer
      Dim nriesgoentidad2016 As Integer
      Try
        nriesgoentidad2016 = Me.clienteDL.riesgo_RiesgoDeEntidad2016(cliente)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        nriesgoentidad2016 = 0
      End Try
      Return nriesgoentidad2016
    End Function

    Public Overridable Function riesgo_RiesgoDePolitico2016(ByVal cliente As Integer) As Integer
      Dim nriesgopolitico2016 As Integer
      Try
        nriesgopolitico2016 = Me.clienteDL.riesgo_RiesgoDePolitico2016(cliente)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        nriesgopolitico2016 = 0
      End Try
      Return nriesgopolitico2016
    End Function

    Public Overridable Function riesgo_RiesgoDePais(ByVal cliente As Integer) As Integer
      Dim nriesgopais As Integer
      Try
        nriesgopais = Me.clienteDL.riesgo_RiesgoDePais(cliente)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        nriesgopais = 0
      End Try
      Return nriesgopais
    End Function

    Public Overridable Function riesgo_RiesgoDeEdad(ByVal cliente As Integer) As Integer
      Dim nriesgoedad As Integer
      Try
        nriesgoedad = Me.clienteDL.riesgo_RiesgoDeEdad(cliente)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        nriesgoedad = 0
      End Try
      Return nriesgoedad
    End Function

    Public Overridable Function riesgo_RiesgoDeActividad(ByVal cliente As Integer) As Integer
      Dim nriesgoactividad As Integer
      Try
        nriesgoactividad = Me.clienteDL.riesgo_RiesgoDeActividad(cliente)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        nriesgoactividad = 0
      End Try
      Return nriesgoactividad
    End Function

    Public Overridable Function riesgo_RiesgoDeEntidad(ByVal cliente As Integer) As Integer
      Dim nriesgoentidad As Integer
      Try
        nriesgoentidad = Me.clienteDL.riesgo_RiesgoDeEntidad(cliente)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        nriesgoentidad = 0
      End Try
      Return nriesgoentidad
    End Function

    Public Overridable Function riesgo_RiesgoDePolitico(ByVal cliente As Integer) As Integer
      Dim nriesgopolitico As Integer
      Try
        nriesgopolitico = Me.clienteDL.riesgo_RiesgoDePolitico(cliente)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        nriesgopolitico = 0
      End Try
      Return nriesgopolitico
    End Function

    Public Overridable Function riesgo_RiesgoDeExtranjero(ByVal cliente As Integer) As Integer
      Dim nriesgoextranjero As Integer
      Try
        nriesgoextranjero = Me.clienteDL.riesgo_RiesgoDeExtranjero(cliente)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        nriesgoextranjero = 0
      End Try
      Return nriesgoextranjero
    End Function

    Public Overridable Function selClientesGruporiesgo(ByVal grupo As Integer) As List(Of Entidades.arrendadora.sp_selClientesGruporiesgo_Result)
      Dim oclienesriesgo As List(Of Entidades.arrendadora.sp_selClientesGruporiesgo_Result) = Nothing
      Try
        oclienesriesgo = Me.clienteDL.selClientesGruporiesgo(grupo)
        If Me.clienteDL.hayErr Then Throw Me.clienteDL.Err
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        oclienesriesgo = New List(Of Entidades.arrendadora.sp_selClientesGruporiesgo_Result)
      End Try
      Return oclienesriesgo
    End Function

    Public Function Outbox(ByVal oficina As Integer, ByVal archivo As String, ByVal tag As String, ByVal llave As String, ByVal changes As String) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Me.clienteDL.GeneraOutbox(oficina, archivo, tag, llave, changes)
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        bTrans = False
      End Try
      Return bTrans
    End Function

    Public Function Outbox(ByVal oficina As Integer, ByVal archivo As String, ByVal tag As String, ByVal llave As String, ByVal chageslst As List(Of String)) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Me.clienteDL.GeneraOutbox(oficina, archivo, tag, llave, chageslst)
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        bTrans = False
      End Try
      Return bTrans
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          If Not Me.clienteDL Is Nothing Then Me.clienteDL.Dispose()
          Me.clienteDL = Nothing
          If Not Me.Err Is Nothing Then Me.Err = Nothing
        End If
      End If
      Me.disposedValue = True
    End Sub

    Protected Overrides Sub Finalize()
      Dispose(False)
      MyBase.Finalize()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region

  End Class

End Namespace
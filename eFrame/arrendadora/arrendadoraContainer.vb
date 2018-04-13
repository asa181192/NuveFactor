Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.Core
Imports System.Data.Entity.Core.Objects

Namespace arrendadora
  Public Class Container
    Inherits DbContext

    Public Sub New(ByVal connstr As String)
      MyBase.New(connstr)
    End Sub

    ''' <summary>
    ''' Configuration
    ''' </summary>
    ''' <param name="modelBuilder"></param>
    ''' <remarks>Configure Mapped tables</remarks>
    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
      MyBase.OnModelCreating(modelBuilder)
    End Sub

#Region "MAPPED TABLES"
    Public Overridable Property bitacoras As DbSet(Of bitacora)
    Public Overridable Property controls As DbSet(Of control)
    Public Overridable Property oficinas As DbSet(Of oficina)
    Public Overridable Property outboxs As DbSet(Of outbox)
    Public Overridable Property usuarios As DbSet(Of usuario)
    Public Overridable Property clientes As DbSet(Of cliente)
    Public Overridable Property tiposociedads As DbSet(Of tiposociedad)
    Public Overridable Property activs As DbSet(Of activ)
    Public Overridable Property estadocivils As DbSet(Of estadocivil)
    Public Overridable Property pais As DbSet(Of pai)
    Public Overridable Property sececos As DbSet(Of sececo)
    Public Overridable Property subactivs As DbSet(Of subactiv)
    Public Overridable Property tipoids As DbSet(Of tipoid)
    Public Overridable Property tipoviviendas As DbSet(Of tipovivienda)
    Public Overridable Property sepomexs As DbSet(Of sepomex)
    Public Overridable Property riesgos As DbSet(Of riesgo)
    Public Overridable Property promotors As DbSet(Of promotor)
    Public Overridable Property regions As DbSet(Of region)
    Public Overridable Property contratos As DbSet(Of contrato)
    Public Overridable Property segmentos As DbSet(Of segmento)
    Public Overridable Property metpagos As DbSet(Of metpago)
    Public Overridable Property creditos As DbSet(Of credito)
    Public Overridable Property persos As DbSet(Of perso)
#End Region

#Region "STORED PROCEDURES"
    Public Overridable Function sp_Avisos_AutorizacionesRechazos(ByVal oficinas As String, ByVal fecha As Date, Optional fecha2 As Nullable(Of Date) = Nothing) As DbRawSqlQuery(Of sp_Avisos_AutorizacionesRechazos_Result)
      Dim sqlparams As New List(Of Data.SqlClient.SqlParameter)
      sqlparams.Add(New SqlParameter With {.ParameterName = "@oficinas", .DbType = DbType.String, .Value = oficinas})
      sqlparams.Add(New SqlParameter With {.ParameterName = "@fecha", .DbType = DbType.DateTime, .Value = fecha})
      sqlparams.Add(New SqlParameter With {.ParameterName = "@fecha2", .DbType = DbType.DateTime, .IsNullable = True, .Value = If(fecha2 Is Nothing, DBNull.Value, fecha2.Value)})
      Return Me.Database.SqlQuery(Of sp_Avisos_AutorizacionesRechazos_Result)("EXEC dbo.sp_Avisos_AutorizacionesRechazos @oficinas, @fecha, @fecha2", sqlparams(0), sqlparams(1), sqlparams(2))
    End Function

    Public Overridable Function sp_siclinew(ByVal clientet24 As Decimal, ByVal rfc As String) As DbRawSqlQuery(Of sp_siclinew_Result)
      Dim sqlparams As New List(Of Data.SqlClient.SqlParameter)
      sqlparams.Add(New SqlParameter With {.ParameterName = "@clientet24", .DbType = DbType.Decimal, .Value = clientet24})
      sqlparams.Add(New SqlParameter With {.ParameterName = "@rfc", .DbType = DbType.String, .Value = rfc})
      Return Me.Database.SqlQuery(Of sp_siclinew_Result)("EXEC dbo.sp_siclinew @clientet24, @rfc", sqlparams(0), sqlparams(1))
    End Function

    Public Overridable Function sp_creditosxcliente(ByVal rfc As String) As DbRawSqlQuery(Of sp_creditosxcliente_Result)
      Dim sqlparams As New List(Of Data.SqlClient.SqlParameter)
      sqlparams.Add(New SqlParameter With {.ParameterName = "@rfc", .DbType = DbType.String, .Value = rfc})
      Return Me.Database.SqlQuery(Of sp_creditosxcliente_Result)("EXEC dbo.sp_creditosxcliente @rfc", sqlparams(0))
    End Function

    Public Overridable Function sp_clientesBusquedaXNombreXCliente(ByVal cliente As Integer, ByVal nombre As String, ByVal oficinas As String) As DbRawSqlQuery(Of sp_clientesBusquedaXNombreXCliente_Result)
      Dim sqlparams As New List(Of Data.SqlClient.SqlParameter)
      sqlparams.Add(New SqlParameter With {.ParameterName = "@cliente", .DbType = DbType.Int64, .Value = cliente})
      sqlparams.Add(New SqlParameter With {.ParameterName = "@nombre", .DbType = DbType.String, .Value = nombre})
      sqlparams.Add(New SqlParameter With {.ParameterName = "@oficinas", .DbType = DbType.String, .Value = oficinas})
      Return Me.Database.SqlQuery(Of sp_clientesBusquedaXNombreXCliente_Result)("EXEC dbo.sp_clientesBusquedaXNombreXCliente @cliente, @nombre, @oficinas", sqlparams(0), sqlparams(1), sqlparams(2))
    End Function

    Public Overridable Function sp_clientes_resumen(ByVal oficina As Integer, ByVal credito As Integer, ByVal cliente As Integer) As DbRawSqlQuery(Of sp_clientes_resumen_Result)
      Dim sqlparams As New List(Of Data.SqlClient.SqlParameter)
      sqlparams.Add(New SqlParameter With {.ParameterName = "@oficina", .DbType = DbType.Int32, .Value = oficina})
      sqlparams.Add(New SqlParameter With {.ParameterName = "@credito", .DbType = DbType.Int32, .Value = credito})
      sqlparams.Add(New SqlParameter With {.ParameterName = "@cliente", .DbType = DbType.Int32, .Value = cliente})
      Return Me.Database.SqlQuery(Of sp_clientes_resumen_Result)("EXEC dbo.sp_clientes_resumen @cliente, @credito, @cliente", sqlparams(0), sqlparams(1), sqlparams(2))
    End Function

    Public Overridable Function sp_RiesgoDeClientePLD(ByVal cliente As Integer, ByVal pldhist As Boolean) As Nullable(Of Integer)
      Dim riesgo As Nullable(Of Integer) = Nothing
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("sp_RiesgoDeClientePLD", cnn)          
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@cliente", .DbType = DbType.Int32, .Value = cliente})
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@pldhist", .DbType = DbType.Boolean, .Value = pldhist})
          Using adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Using ds As New DataSet
              adapter.Fill(ds)
              If ds.Tables(0).Rows.Count > 0 Then
                riesgo = ds.Tables(0).Rows(0)(0)
              End If
            End Using
          End Using          
        End Using
      End Using
      Return riesgo
    End Function

    Public Overridable Function sp_Nueva_Solicheq(ByVal oficina As Integer) As Nullable(Of Integer)
      Dim Nueva_Solicheq As Nullable(Of Integer) = Nothing
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("sp_Nueva_Solicheq", cnn)
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@oficina", .DbType = DbType.Int32, .Value = oficina})
          Using adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Using ds As New DataSet
              adapter.Fill(ds)
              If ds.Tables(0).Rows.Count > 0 Then
                Nueva_Solicheq = ds.Tables(0).Rows(0)(0)
              End If
            End Using
          End Using
        End Using
      End Using
      Return Nueva_Solicheq
    End Function

    Public Overridable Function sp_Nuevo_Cliente(ByVal oficina As Integer) As Nullable(Of Decimal)
      Dim Nuevo_cliente As Nullable(Of Decimal) = Nothing
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("sp_Nuevo_Cliente", cnn)          
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@oficina", .DbType = DbType.Int32, .Value = oficina})
          Using adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Using ds As New DataSet
              adapter.Fill(ds)
              If ds.Tables(0).Rows.Count > 0 Then
                Nuevo_cliente = ds.Tables(0).Rows(0)(0)
              End If
            End Using
          End Using
        End Using
      End Using
      Return Nuevo_cliente
    End Function

    Public Overridable Function sp_Nueva_Nota(ByVal oficina As Integer) As Nullable(Of Integer)
      Dim Nueva_Nota As Nullable(Of Integer) = Nothing
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("sp_Nueva_Nota", cnn)
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@oficina", .DbType = DbType.Int32, .Value = oficina})
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@NOTA", .DbType = DbType.Int32, .Direction = ParameterDirection.Output, .IsNullable = True})
          cmd.ExecuteNonQuery()
          Nueva_Nota = CType(cmd.Parameters("@NOTA").Value, Nullable(Of Integer))
        End Using
      End Using
      Return Nueva_Nota
    End Function

    Public Overridable Function sp_Nueva_Cuenta(ByVal oficina As Integer) As Nullable(Of Integer)
      Dim Nueva_cuenta As Nullable(Of Integer) = Nothing
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("sp_Nueva_Cuenta", cnn)
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@tnOficina", .DbType = DbType.Int32, .Value = oficina})
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@Nueva_cuenta", .DbType = DbType.Int32, .Direction = ParameterDirection.Output, .IsNullable = True})
          cmd.ExecuteNonQuery()
          Nueva_cuenta = CType(cmd.Parameters("@Nueva_cuenta").Value, Nullable(Of Integer))
        End Using
      End Using
      Return Nueva_cuenta
    End Function

    Public Overridable Sub sp_Nuevo_Riesgo(ByVal oficina As Integer, ByRef riesgo As Nullable(Of Integer))      
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("sp_Nuevo_Riesgo", cnn)
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@oficina", .DbType = DbType.Int32, .Value = oficina})
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@riesgo", .DbType = DbType.Int32, .Direction = ParameterDirection.Output, .IsNullable = True})
          cmd.ExecuteNonQuery()
          riesgo = CType(cmd.Parameters("@riesgo").Value, Nullable(Of Integer))
        End Using
      End Using
    End Sub

    Public Overridable Function sp_RiesgoBusquedaXNombreXGrupo(ByVal grupo As System.Nullable(Of Long), ByVal nombre As String, ByVal oficina As String) As DbRawSqlQuery(Of sp_RiesgoBusquedaXNombreXGrupo_Result)
      Dim sqlparams As New List(Of Data.SqlClient.SqlParameter)
      sqlparams.Add(New SqlParameter With {.ParameterName = "@grupo", .DbType = DbType.Int32, .Value = grupo})
      sqlparams.Add(New SqlParameter With {.ParameterName = "@nombre", .DbType = DbType.String, .Value = nombre})
      sqlparams.Add(New SqlParameter With {.ParameterName = "@oficina", .DbType = DbType.String, .Value = oficina})
      Return Me.Database.SqlQuery(Of sp_RiesgoBusquedaXNombreXGrupo_Result)("EXEC dbo.sp_RiesgoBusquedaXNombreXGrupo @cliente, @credito, @cliente", sqlparams(0), sqlparams(1), sqlparams(2))
    End Function

    Public Overridable Sub sp_Nuevo_Promotor(ByVal tnOficina As Integer, ByRef Nuevo_promotor As Nullable(Of Integer))
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("sp_Nuevo_Promotor", cnn)
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@tnOficina", .DbType = DbType.Int32, .Value = tnOficina})
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@Nuevo_promotor", .DbType = DbType.Int32, .Direction = ParameterDirection.Output, .IsNullable = True})
          cmd.ExecuteNonQuery()
          Nuevo_promotor = CType(cmd.Parameters("@Nuevo_promotor").Value, Nullable(Of Integer))
        End Using
      End Using
    End Sub

    Public Overridable Function sp_PromotoresBusquedaXNombre(ByVal promotor As Long, ByVal nombre As String, ByVal oficina As String) As DbRawSqlQuery(Of sp_PromotoresBusquedaXNombre_Result)
      Dim sqlparams As New List(Of Data.SqlClient.SqlParameter)
      sqlparams.Add(New SqlParameter With {.ParameterName = "@promotor", .DbType = DbType.Int64, .Value = promotor})
      sqlparams.Add(New SqlParameter With {.ParameterName = "@nombre", .DbType = DbType.String, .Value = nombre})
      sqlparams.Add(New SqlParameter With {.ParameterName = "@oficina", .DbType = DbType.String, .Value = oficina})
      Return Me.Database.SqlQuery(Of sp_PromotoresBusquedaXNombre_Result)("EXEC dbo.sp_PromotoresBusquedaXNombre @promotor, @nombre, @oficina", sqlparams(0), sqlparams(1), sqlparams(2))
    End Function

    Public Overridable Function sp_PromotoresDetalle(ByVal oficinas As String) As DbRawSqlQuery(Of sp_PromotoresDetalle_Result)
      Dim sqlparams As New List(Of Data.SqlClient.SqlParameter)
      sqlparams.Add(New SqlParameter With {.ParameterName = "@oficinas", .DbType = DbType.String, .Value = oficinas})
      Return Me.Database.SqlQuery(Of sp_PromotoresDetalle_Result)("EXEC dbo.sp_PromotoresDetalle @oficinas", sqlparams(0))
    End Function

    Public Overridable Function sp_rpt_colocxm(ByVal ano As Integer, ByVal mes As Integer, ByVal oficina As Integer, ByVal modalidad As Integer, ByVal oficinas As String) As DbRawSqlQuery(Of sp_rpt_colocxm_Result)
      Dim sqlparams As New List(Of Data.SqlClient.SqlParameter)
      sqlparams.Add(New SqlParameter With {.ParameterName = "@ano", .DbType = DbType.Int64, .Value = ano})
      sqlparams.Add(New SqlParameter With {.ParameterName = "@mes", .DbType = DbType.String, .Value = mes})
      sqlparams.Add(New SqlParameter With {.ParameterName = "@oficina", .DbType = DbType.String, .Value = oficina})
      sqlparams.Add(New SqlParameter With {.ParameterName = "@modalidad", .DbType = DbType.String, .Value = modalidad})
      sqlparams.Add(New SqlParameter With {.ParameterName = "@oficinas", .DbType = DbType.String, .Value = oficinas})
      Return Me.Database.SqlQuery(Of sp_rpt_colocxm_Result)("EXEC dbo.sp_rpt_colocxm_Result @ano, @mes, @oficina, @modalidad, @oficinas", sqlparams(0), sqlparams(1), sqlparams(2), sqlparams(3), sqlparams(4))
    End Function

    Public Overridable Function sp_AdeudoClientesXPromotor(ByVal promotor As Integer) As DbRawSqlQuery(Of sp_AdeudoClientesXPromotor_Result)
      Dim sqlparams As New List(Of Data.SqlClient.SqlParameter)
      sqlparams.Add(New SqlParameter With {.ParameterName = "@promotor", .DbType = DbType.Int64, .Value = promotor})
      Return Me.Database.SqlQuery(Of sp_AdeudoClientesXPromotor_Result)("EXEC dbo.sp_AdeudoClientesXPromotor @promotor", sqlparams(0))
    End Function

#End Region

#Region "SCALAR VALUED FUNCTIONS"
    Public Overridable Function digito_Banamex97(ByVal s As String) As String
      Dim digito As String = String.Empty
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("digito_Banamex97", cnn)
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@s", .DbType = DbType.String, .Value = s})
          Using adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Using ds As New DataSet
              adapter.Fill(ds)
              If ds.Tables(0).Rows.Count > 0 Then
                digito = ds.Tables(0).Rows(0)(0)
              End If
            End Using
          End Using
        End Using
      End Using
      Return digito
    End Function

    Public Overridable Function digito_Bancomer04(ByVal s As String) As String
      Dim digito As String = String.Empty
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("digito_Bancomer04", cnn)          
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@s", .DbType = DbType.String, .Value = s})
          Using adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Using ds As New DataSet
              adapter.Fill(ds)
              If ds.Tables(0).Rows.Count > 0 Then
                digito = ds.Tables(0).Rows(0)(0)
              End If
            End Using
          End Using          
        End Using
      End Using
      Return digito
    End Function

    Public Overridable Function riesgo_RiesgoDeCliente(ByVal cliente As Integer) As Nullable(Of Decimal)
      Dim riesgo As Nullable(Of Decimal) = Nothing
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("riesgo_RiesgoDeCliente", cnn)          
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@cliente", .DbType = DbType.Int32, .Value = cliente})
          Using adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Using ds As New DataSet
              adapter.Fill(ds)
              If ds.Tables(0).Rows.Count > 0 Then
                riesgo = ds.Tables(0).Rows(0)(0)
              End If
            End Using
          End Using
        End Using
      End Using
      Return riesgo
    End Function

    Public Overridable Function riesgo_RiesgoDeEdad2016(ByVal cliente As Integer, ByVal pfisica As Boolean, ByVal pfempre As Boolean) As Nullable(Of Integer)
      Dim riesgo As Nullable(Of Integer) = Nothing
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("riesgo_RiesgoDeEdad2016", cnn)
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@cliente", .DbType = DbType.Int32, .Value = cliente})
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@pfisica", .DbType = DbType.Boolean, .Value = pfisica})
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@pfempre", .DbType = DbType.Boolean, .Value = pfempre})
          Using adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Using ds As New DataSet
              adapter.Fill(ds)
              If ds.Tables(0).Rows.Count > 0 Then
                riesgo = ds.Tables(0).Rows(0)(0)
              End If
            End Using
          End Using
        End Using
      End Using
      Return riesgo
    End Function

    Public Overridable Function riesgo_RiesgoDeSubActividad(ByVal cliente As Integer) As Nullable(Of Integer)
      Dim riesgo As Nullable(Of Integer) = Nothing
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("riesgo_RiesgoDeSubActividad", cnn)
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@cliente", .DbType = DbType.Int32, .Value = cliente})
          Using adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Using ds As New DataSet
              adapter.Fill(ds)
              If ds.Tables(0).Rows.Count > 0 Then
                riesgo = ds.Tables(0).Rows(0)(0)
              End If
            End Using
          End Using
        End Using
      End Using
      Return riesgo
    End Function

    Public Overridable Function riesgo_RiesgoDeEntidad2016(ByVal cliente As Integer) As Nullable(Of Integer)
      Dim riesgo As Nullable(Of Integer) = Nothing
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("riesgo_RiesgoDeEntidad2016", cnn)
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@cliente", .DbType = DbType.Int32, .Value = cliente})
          Using adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Using ds As New DataSet
              adapter.Fill(ds)
              If ds.Tables(0).Rows.Count > 0 Then
                riesgo = ds.Tables(0).Rows(0)(0)
              End If
            End Using
          End Using
        End Using
      End Using
      Return riesgo
    End Function

    Public Overridable Function riesgo_RiesgoDePais(ByVal pais As Integer) As Nullable(Of Integer)
      Dim riesgo As Nullable(Of Integer) = Nothing
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("riesgo_RiesgoDePais", cnn)
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@pais", .DbType = DbType.Int32, .Value = pais})
          Using adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Using ds As New DataSet
              adapter.Fill(ds)
              If ds.Tables(0).Rows.Count > 0 Then
                riesgo = ds.Tables(0).Rows(0)(0)
              End If
            End Using
          End Using
        End Using
      End Using
      Return riesgo
    End Function

    Public Overridable Function riesgo_RiesgoDeEdad(ByVal cliente As Integer) As Nullable(Of Integer)
      Dim riesgo As Nullable(Of Integer) = Nothing
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("riesgo_RiesgoDeEdad", cnn)          
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@cliente", .DbType = DbType.Int32, .Value = cliente})
          Using adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Using ds As New DataSet
              adapter.Fill(ds)
              If ds.Tables(0).Rows.Count > 0 Then
                riesgo = ds.Tables(0).Rows(0)(0)
              End If
            End Using
          End Using
        End Using
      End Using
      Return riesgo
    End Function

    Public Overridable Function riesgo_RiesgoDeActividad(ByVal cliente As Integer) As Nullable(Of Integer)
      Dim riesgo As Nullable(Of Integer) = Nothing
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("riesgo_RiesgoDeActividad", cnn)          
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@cliente", .DbType = DbType.Int32, .Value = cliente})
          Using adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Using ds As New DataSet
              adapter.Fill(ds)
              If ds.Tables(0).Rows.Count > 0 Then
                riesgo = ds.Tables(0).Rows(0)(0)
              End If
            End Using
          End Using
        End Using
      End Using
      Return riesgo
    End Function

    Public Overridable Function riesgo_RiesgoDeEntidad(ByVal cliente As Integer) As Nullable(Of Integer)
      Dim riesgo As Nullable(Of Integer) = Nothing
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("riesgo_RiesgoDeEntidad", cnn)          
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@cliente", .DbType = DbType.Int32, .Value = cliente})
          Using adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Using ds As New DataSet
              adapter.Fill(ds)
              If ds.Tables(0).Rows.Count > 0 Then
                riesgo = ds.Tables(0).Rows(0)(0)
              End If
            End Using
          End Using
        End Using
      End Using
      Return riesgo
    End Function

    Public Overridable Function riesgo_RiesgoDePolitico(ByVal cliente As Integer) As Nullable(Of Integer)
      Dim riesgo As Nullable(Of Integer) = Nothing
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("riesgo_RiesgoDePolitico", cnn)
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@cliente", .DbType = DbType.Int32, .Value = cliente})
          Using adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Using ds As New DataSet
              adapter.Fill(ds)
              If ds.Tables(0).Rows.Count > 0 Then
                riesgo = ds.Tables(0).Rows(0)(0)
              End If
            End Using
          End Using
        End Using
      End Using
      Return riesgo
    End Function

    Public Overridable Function riesgo_RiesgoDeExtranjero(ByVal cliente As Integer) As Nullable(Of Integer)
      Dim riesgo As Nullable(Of Integer) = Nothing
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("riesgo_RiesgoDeExtranjero", cnn)
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@cliente", .DbType = DbType.Int32, .Value = cliente})
          Using adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Using ds As New DataSet
              adapter.Fill(ds)
              If ds.Tables(0).Rows.Count > 0 Then
                riesgo = ds.Tables(0).Rows(0)(0)
              End If
            End Using
          End Using
        End Using
      End Using
      Return riesgo
    End Function

    Public Overridable Function getSaldoInsolutoCliente(ByVal cliente As Integer, ByVal SumaIvaInsoluto As Double) As Nullable(Of Decimal)
      Dim saldoins As Nullable(Of Decimal) = Nothing
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("getSaldoInsolutoCliente", cnn)
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@cliente", .DbType = DbType.Int32, .Value = cliente})
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@SumaIvaInsoluto", .DbType = DbType.Boolean, .Value = SumaIvaInsoluto})
          Using adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Using ds As New DataSet
              adapter.Fill(ds)
              If ds.Tables(0).Rows.Count > 0 Then
                saldoins = ds.Tables(0).Rows(0)(0)
              End If
            End Using
          End Using
        End Using
      End Using
      Return saldoins
    End Function

    Public Overridable Function getSaldoInsolutoContrato(ByVal contrato As Integer, ByVal SumaIvaInsoluto As Double) As Nullable(Of Decimal)
      Dim saldoins As Nullable(Of Decimal) = Nothing
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("getSaldoInsolutoContrato", cnn)
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@contrato", .DbType = DbType.Int32, .Value = contrato})
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@SumaIvaInsoluto", .DbType = DbType.Boolean, .Value = SumaIvaInsoluto})
          Using adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Using ds As New DataSet
              adapter.Fill(ds)
              If ds.Tables(0).Rows.Count > 0 Then
                saldoins = ds.Tables(0).Rows(0)(0)
              End If
            End Using
          End Using
        End Using
      End Using
      Return saldoins
    End Function

    Public Overridable Function getSaldoInsolutoRiesgo(ByVal riesgo As Nullable(Of Integer)) As Nullable(Of Decimal)
      Dim nriesgo As Nullable(Of Decimal) = Nothing
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("getSaldoInsolutoRiesgo", cnn)          
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@Riesgo", .DbType = DbType.Int32, .Value = riesgo})
          Using adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Using ds As New DataSet
              adapter.Fill(ds)
              If ds.Tables(0).Rows.Count > 0 Then
                nriesgo = ds.Tables(0).Rows(0)(0)
              End If
            End Using
          End Using
        End Using
      End Using
      Return nriesgo
    End Function

    Public Overridable Function getSaldoInsolutoPromotor(ByVal promotor As Integer, ByVal SumaIvaInsoluto As Boolean) As Nullable(Of Decimal)
      Dim nriesgo As Nullable(Of Decimal) = Nothing
      Using cnn As New SqlConnection(Me.Database.Connection.ConnectionString)
        cnn.Open()
        Using cmd As New SqlCommand("getSaldoInsolutoPromotor", cnn)
          cmd.CommandType = CommandType.StoredProcedure
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@promotor", .DbType = DbType.Int32, .Value = promotor})
          cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@SumaIvaInsoluto", .DbType = DbType.Boolean, .Value = SumaIvaInsoluto})
          Using adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Using ds As New DataSet
              adapter.Fill(ds)
              If ds.Tables(0).Rows.Count > 0 Then
                nriesgo = ds.Tables(0).Rows(0)(0)
              End If
            End Using
          End Using
        End Using
      End Using
      Return nriesgo
    End Function

#End Region

#Region "TABLE VALUED FUNCTIONS"
    Public Overridable Function fdu_ParametrosControl() As DbRawSqlQuery(Of fdu_ParametrosControl_Result)
      Return Me.Database.SqlQuery(Of fdu_ParametrosControl_Result)("SELECT p.* FROM dbo.fdu_ParametrosControl() p")
    End Function
#End Region

  End Class
End Namespace
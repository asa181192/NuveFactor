Imports System.Data.Entity.Infrastructure
Imports System.Data.SqlClient
Imports FactorEntidades
Imports System.Data.Entity
Imports System.Transactions


Public Class ReportesDAL

  Public Function vencimientoFondeoNafin(moneda As Integer, tipo As String, inicio As Date, fin As Date, ByRef model As sp_vencimientosnafin) As Result
    Dim response = New Result(False)
    Dim parameter = New List(Of SqlParameter)

    Using context As New FactorContext

      Try
        parameter.Add(New SqlParameter("@moneda", moneda))
        parameter.Add(New SqlParameter("@tipo", tipo))
        parameter.Add(New SqlParameter("@inicio", inicio))
        parameter.Add(New SqlParameter("@fin", fin))

        model.list = context.Database.SqlQuery(Of sp_vencimientosnafin)("Exec [dbo].[sp_vencimientosnafin]" + "@moneda," + "@tipo," + "@inicio," + "@fin", parameter.ToArray()).ToList()

        response.Ok = True
      Catch ex As Exception
        response.Detalle = ex.InnerException.InnerException.Message
        response.Id_Out = 1
      End Try

    End Using

    Return response
  End Function

  Public Function ConsultaDepositosDAL(fecha As String, idctabanco As Integer, ByRef model As List(Of ReporteDepositos)) As Result
    Dim response = New Result(False)
    Dim fecha1 As Date

    fecha1 = Date.Parse(fecha)

    Using context As New FactorContext

      Try
        Dim values = (From a In context.depositos
                Join b In context.cuentas On a.idctabanco Equals b.idctabanco
           Where a.fecha = fecha1 And a.idctabanco = idctabanco And a.cancelado = 0
           Select New ReporteDepositos With {.folio = a.folio, .contrato = a.contrato, .concepto = a.concepto, .entrada = a.entrada,
                             .capital = a.capital, .general = a.entrada - a.capital, .fecha = a.fecha, .moneda = b.moneda}).ToList()

        For Each item As ReporteDepositos In values

          Dim a As New ReporteDepositos

          a.folio = item.folio
          a.contrato = item.contrato
          a.concepto = item.concepto
          a.entrada = item.entrada
          a.capital = item.capital
          a.general = item.general
          a.fecha = item.fecha

          If item.moneda = 1 Then
            a.divisa = "MXN"
          Else
            a.divisa = "DLLS"
          End If

          model.Add(a)

        Next

        response.Ok = True

      Catch ex As Exception
        response.Detalle = ex.Message
      End Try

    End Using

    Return response
  End Function

  Public Function ConsultaSalidasDAL(fecha1 As String, idctabanco As Integer, ByRef model As List(Of ReporteDepositos)) As Result
    Dim response = New Result(False)
    Dim fecha As Date

    fecha = Date.Parse(fecha1)

    Using context As New FactorContext

      Try

        Dim values = (From a In context.movcuentas
                Join b In context.cuentas On a.idctabanco Equals b.idctabanco
                Where a.fecha = fecha And a.idctabanco = idctabanco And a.salida > 0
                Select New ReporteDepositos With {.moneda = b.moneda, .folio = a.folio, .contrato = a.contrato, .concepto = a.concepto, .salida = a.salida}).ToList()

        For Each item As ReporteDepositos In values

          Dim a = New ReporteDepositos

          If item.moneda = 1 Then
            a.divisa = "MXN"
          Else
            a.divisa = "DLLS"
          End If

          a.folio = item.folio
          a.contrato = item.contrato
          a.concepto = item.concepto
          a.salida = item.salida

          model.Add(a)

        Next

        response.Ok = True
      Catch ex As Exception
        response.Detalle = ex.Message
      End Try
    End Using

    Return response
  End Function

  Public Function ConsultaReportesDAL(ByRef model As List(Of ReporteEntidad)) As Result

    Dim response = New Result(False)
    Using context As New FactorContext

      Try

        Dim values = (From a In context.reporte
                Order By a.modulo
                Select New ReporteEntidad With {.idreporte = a.Idreporte, .modulo = a.modulo, .descripcion = a.descripcion, .url = a.url}).ToList()

        For Each item As ReporteEntidad In values

          Dim a = New ReporteEntidad

          a.idreporte = item.idreporte
          a.modulo = item.modulo
          a.descripcion = item.descripcion
          a.url = item.url
          model.Add(a)

        Next

        response.Ok = True
      Catch ex As Exception
        response.Detalle = ex.Message
      End Try
    End Using

    Return response
  End Function

  Public Function ReportecobranzaDAL(fecha As String, contrato As Integer, ByRef model As List(Of CobranzaEntidad)) As Result


    Dim response = New Result(False)

    Dim dt = Convert.ToDateTime(fecha)
    Dim fecha1 = String.Format("{0:yyyy-MM-dd}", dt)

    ' Dim fecha1 As Date

    '  fecha1 = DateTime.Parse(fecha1str)

    'fecha1 = Date.Parse(fecha, "yyyyMMdd")
    Using context As New FactorContext
      Try

        Dim parameters = New List(Of SqlParameter)
        parameters.Add(New SqlParameter("@contrato", contrato))
        parameters.Add(New SqlParameter("@fecha", fecha1))

        Dim previo = context.Database.SqlQuery(Of CobranzaEntidad)("Exec SP_InformaCobros @fecha,@Contrato",
                   parameters.ToArray()).ToList()

        For Each item In previo


          Dim a = New CobranzaEntidad

          a.contrato = item.contrato
          a.fecha = item.fecha
          a.cesion = item.cesion
          a.docto = item.docto
          a.importe = item.importe
          a.descto = item.descto
          a.neto = item.neto
          a.bonifica = item.bonifica
          a.cobranza = item.cobranza
          a.safectado = item.safectado
          a.scv = item.scv
          a.Nombre = item.Nombre
          a.nombredeudor = item.nombredeudor
          a.deudor = item.deudor
          a.porc_anti = Math.Round(item.porc_anti / 100, 2)
          a.descrip = item.descrip
          a.monedastr = item.monedastr

          model.Add(a)

        Next

        response.Ok = True
      Catch ex As Exception
        response.Detalle = ex.Message
      End Try
    End Using

    Return response
  End Function

  Public Function ReporteaforoDAL(fecha As String, contrato As Integer, ByRef model As List(Of CobranzaEntidad)) As Result


    Dim response = New Result(False)

    Dim dt = Convert.ToDateTime(fecha)
    Dim fecha1 = String.Format("{0:yyyy-MM-dd}", dt)

    ' Dim fecha1 As Date

    '  fecha1 = DateTime.Parse(fecha1str)

    'fecha1 = Date.Parse(fecha, "yyyyMMdd")
    Using context As New FactorContext
      Try

        Dim parameters = New List(Of SqlParameter)
        parameters.Add(New SqlParameter("@contrato", contrato))
        parameters.Add(New SqlParameter("@fecha", fecha1))

        Dim previo = context.Database.SqlQuery(Of CobranzaEntidad)("Exec SP_Reporteaforo @fecha,@Contrato",
                   parameters.ToArray()).ToList()

        For Each item In previo
          Dim a = New CobranzaEntidad

          a.contrato = item.contrato
          a.fecha = item.fecha
          a.cobrado = item.cobrado
          a.aforo = item.aforo
          a.descto = item.descto
          a.bonifica = item.bonifica
          a.pago = item.pago
          a.cobranza = item.cobranza
          a.Nombre = item.Nombre
          a.nombredeudor = item.nombredeudor
          a.deudor = item.deudor
          a.descrip = item.descrip
          a.monedastr = item.monedastr

          model.Add(a)

        Next

        If previo.Count = 0 Then
          response.Ok = False
        Else
          response.Ok = True
        End If

      Catch ex As Exception
        response.Detalle = ex.Message
      End Try
    End Using

    Return response
  End Function

  Public Function ReporteadeudosDAL(moneda As Integer, ByRef model As List(Of adeudosEntidad)) As Result

    Dim Respuesta = New Result(False)
    Dim context As New FactorContext
    '
    Dim movtos = {"NC", "OT", "RN", "RE"}

    Try

      Dim parameters = New List(Of SqlParameter)
      parameters.Add(New SqlParameter("@moneda", moneda))

      Dim values = context.Database.SqlQuery(Of adeudosEntidad)("Exec SP_adeudosxpagar @moneda",
                 parameters.ToArray()).ToList()


      For Each item As adeudosEntidad In values

        Dim a = New adeudosEntidad


        a.Adeudo = item.tipo + "-" + item.docto.Value.ToString("0000000")
        a.docto = item.docto
        a.tipo = item.tipo
        a.serie = item.serie
        a.contrato = item.contrato
        a.Nombre = item.Nombre
        a.fec_alta = item.fec_alta
        a.monto = item.monto
        a.saldo = item.saldo
        a.moneda = item.moneda
        a.monedaStr = item.monedaStr
        a.idadeudo = item.idadeudo
        a.iva = item.iva / 100

        a.impbase = If(movtos.Contains(item.tipo), item.monto / (1 + item.iva), item.monto)
        a.impiva = If(movtos.Contains(item.tipo), item.monto / (1 + item.iva) * item.iva, 0)

        a.salbase = If(movtos.Contains(item.tipo), item.saldo / (1 + item.iva), item.saldo)
        a.saliva = If(movtos.Contains(item.tipo), item.saldo / (1 + item.iva) * item.iva, 0)

        model.Add(a)
      Next

      Respuesta.Ok = True

    Catch ex As Exception
      Respuesta.Detalle = ex.Message

    End Try

    Return Respuesta

  End Function

  'Public Function ReporteadeudosDAL(contrato As Integer, divisa As Integer, ByRef model As List(Of CobranzaEntidad)) As Result


  '  Dim response = New Result(False)

  '  Using context As New FactorContext
  '    Try

  '      Dim parameters = New List(Of SqlParameter)
  '      parameters.Add(New SqlParameter("@contrato", contrato))
  '      parameters.Add(New SqlParameter("@divisa", divisa))

  '      Dim previo = context.Database.SqlQuery(Of CobranzaEntidad)("Exec SP_Reporteaforo @fecha,@Contrato",
  '                         parameters.ToArray()).ToList()

  '      For Each item In previo
  '        Dim a = New CobranzaEntidad

  '        a.contrato = item.contrato
  '        a.fecha = item.fecha
  '        a.cobrado = item.cobrado
  '        a.aforo = item.aforo
  '        a.descto = item.descto
  '        a.bonifica = item.bonifica
  '        a.pago = item.pago
  '        a.cobranza = item.cobranza
  '        a.Nombre = item.Nombre
  '        a.nombredeudor = item.nombredeudor
  '        a.deudor = item.deudor
  '        a.descrip = item.descrip
  '        a.monedastr = item.monedastr

  '        model.Add(a)

  '      Next

  '      If previo.Count = 0 Then
  '        response.Ok = False
  '      Else
  '        response.Ok = True
  '      End If

  '    Catch ex As Exception
  '      response.Detalle = ex.Message
  '    End Try
  '  End Using

  '  Return response
  'End Function

  Function ConsultaHistDocDAL(model As HistoriaDocumento) As Result
    Dim response = New Result(False)
    Using context As New FactorContext
      Try

        response.Ok = True
      Catch ex As Exception
        response.Detalle = ex.Message
      End Try
    End Using

    Return response
  End Function

  Function obtenerSaldosDAL(contrato As Integer, anio As Integer, ByRef listaReportes As List(Of SaldosEntidad)) As Result
    Dim response = New Result(False)
    Using context As New FactorContext
      Try
        Dim parameters = New List(Of SqlParameter)
        parameters.Add(New SqlParameter("@contrato", contrato))
        parameters.Add(New SqlParameter("@anio", anio))

        listaReportes = context.Database.SqlQuery(Of SaldosEntidad)("Exec [dbo].[sp_graficadata] " +
                                          "@contrato, " +
                                          "@anio ", parameters.ToArray()).ToList()

        response.Ok = True
      Catch ex As Exception
        response.Detalle = ex.Message
      End Try
    End Using

    Return response
  End Function

  Function consultaClienteDAL(ByRef _nombre As reporteSaldos, contrato As Integer) As Object
    Dim response = New Result(False)
    Using context As New FactorContext
      Try
        _nombre = (From A In context.contratos
             Join B In context.clientes
             On A.cliente Equals B.cliente
             Join C In context.producto
             On A.producto Equals C.id
             Where A.contrato = contrato
             Select New reporteSaldos With {
                .fec_vence = A.fec_vence,
                .nombre = B.nombre,
                .linea = A.linea,
                .producto = C.producto1,
                .moneda = If(A.moneda = 1, "MXN", "USD")
               }).SingleOrDefault()

        If _nombre IsNot Nothing Then
          response.Ok = True
        End If

      Catch ex As Exception
        response.Detalle = ex.Message
      End Try
    End Using

    Return response

  End Function

  Function obtenerLineasFactor(ByRef lista As List(Of LineasFactor)) As Object
    Dim response = New Result(False)
    Using context As New FactorContext
      Try

        lista = context.Database.SqlQuery(Of LineasFactor)("Exec [dbo].[SP_Lineas_factor]").ToList()

        response.Ok = True
      Catch ex As Exception
        response.Detalle = ex.Message
      End Try
    End Using

    Return response
  End Function

  Function obtenerLineasFactorDAL(opcion As Boolean, contrato As Integer, ByRef lista As List(Of SP_ReporteDocSinDescontar)) As Result
    Dim response = New Result(False)
    Using context As New FactorContext
      Try
        Dim parameters = New List(Of SqlParameter)
        If opcion Then
          parameters.Add(New SqlParameter("@opcion", 1))
        Else
          parameters.Add(New SqlParameter("@opcion", 0))
        End If

        parameters.Add(New SqlParameter("@contrato", contrato))

        lista = context.Database.SqlQuery(Of SP_ReporteDocSinDescontar)("Exec [dbo].[SP_ReporteDocSinDescontar] @opcion,@contrato", parameters.ToArray()).ToList()

        response.Ok = True
      Catch ex As Exception
        response.Detalle = ex.Message
      End Try
    End Using

    Return response
  End Function

  Function ConsultaHistoriaAdeudoDAL(serie As String, docto As String, ByRef detalle As RespHistAdeudo) As Object
    Dim response = New Result(False)
    Dim idadeudo As Integer = Nothing
    Using context As New FactorContext
      Try
        detalle = (From A In context.adeudos
                 Join B In context.contratos
                 On A.contrato Equals B.contrato
                 Join C In context.clientes
                 On B.cliente Equals C.cliente
                 Where A.serie = serie And A.docto = docto
                 Select New RespHistAdeudo With {
                  .contrato = A.contrato,
                  .nombre = C.nombre,
                  .monto = A.monto,
                  .saldo = A.saldo,
                  .fec_alta = A.fec_alta,
                  .idadeudo = A.idadeudo}).SingleOrDefault()

        If detalle IsNot Nothing Then
          idadeudo = detalle.idadeudo
          detalle.pagos = context.pagosadeudos.Where(Function(x) x.idadeudo = idadeudo).Select(Function(x) New pagos With {
                                                              .fecha = x.fecha,
                                                              .importe = x.importe,
                                                        .concepto = x.concepto}).ToList()

        End If
        response.Ok = True
      Catch ex As Exception
        response.Detalle = ex.Message
      End Try
    End Using

    Return response
  End Function

  Function consultarContratoDocumentoDAL(contrato As Integer, documento As String, ByRef docto As doctoentidad, ByRef lista As List(Of Integer), deduor As Integer) As Result
    Dim response = New Result(False)
    Using context As New FactorContext
      Try

        Dim document = (From A In context.doctos
            Join B In context.contratos
            On A.contrato Equals B.contrato
            Join C In context.clientes
            On B.cliente Equals C.cliente
            Join D In context.cesiones
            On A.idcesion Equals D.idcesion
            Where A.contrato = contrato And A.docto.Trim() = documento
            Select New doctoentidad With {
              .iddocto = A.iddocto,
              .deudor = A.deudor,
              .idcesion = A.idcesion,
              .porc_anti = B.porc_anti,
              .nombrecliente = C.nombre,
              .producto = B.producto,
              .divisa = B.moneda,
              .interes = B.interes,
              .tasa = D.tasaoper,
              .fechavencecesion = D.fec_vence,
              .altacesion = D.fec_alta,
              .importe = D.importe,
              .fechaVencedocto = A.fec_vence,
              .saldo = A.saldo
              }).ToList()

        If document IsNot Nothing Then
          If document.Count > 1 Then

            If deduor > 0 Then

              docto = (From A In context.doctos
            Join B In context.contratos
            On A.contrato Equals B.contrato
            Join C In context.clientes
            On B.cliente Equals C.cliente
            Join D In context.cesiones
            On A.idcesion Equals D.idcesion
            Where A.contrato = contrato And A.docto.Trim() = documento And A.deudor = deduor
            Select New doctoentidad With {
              .iddocto = A.iddocto,
              .deudor = A.deudor,
              .idcesion = A.idcesion,
              .porc_anti = B.porc_anti,
              .nombrecliente = C.nombre,
              .producto = B.producto,
              .divisa = B.moneda,
              .interes = B.interes,
              .tasa = D.tasaoper,
              .fechavencecesion = D.fec_vence,
              .altacesion = D.fec_alta,
              .importe = D.importe,
              .fechaVencedocto = A.fec_vence,
              .saldo = A.saldo
              }).SingleOrDefault()

              Dim idd = docto.deudor
              If docto.producto = 1 Then
                docto.nombreproveedor = context.comprador.Where(Function(x) x.deudor = idd).Select(Function(w) w.nombre).SingleOrDefault()
              Else
                docto.nombreproveedor = context.proveedor.Where(Function(x) x.deudor = idd).Select(Function(w) w.nombre).SingleOrDefault()
              End If

              Dim id = docto.iddocto

							docto.historiapagos = (From A In context.cobranza
										Where A.iddocto = id And A.cancelado = False
										Select New historiapagos With {
										.fecha = A.fecha,
										.monto = A.importe
										}).ToList()

            Else
              For Each item As Integer In document.Select(Function(w) w.deudor).ToList()
                lista.Add(item)
              Next
            End If


          Else

            docto = (From A In context.doctos
            Join B In context.contratos
            On A.contrato Equals B.contrato
            Join C In context.clientes
            On B.cliente Equals C.cliente
            Join D In context.cesiones
            On A.idcesion Equals D.idcesion
            Where A.contrato = contrato And A.docto.Trim() = documento
            Select New doctoentidad With {
              .iddocto = A.iddocto,
              .deudor = A.deudor,
              .idcesion = A.idcesion,
              .porc_anti = B.porc_anti,
              .nombrecliente = C.nombre,
              .producto = B.producto,
              .divisa = B.moneda,
              .interes = B.interes,
              .tasa = D.tasaoper,
              .fechavencecesion = D.fec_vence,
              .altacesion = D.fec_alta,
              .importe = D.importe,
              .fechaVencedocto = A.fec_vence,
              .saldo = A.saldo
              }).SingleOrDefault()

            Dim idd = docto.deudor
            If docto.producto = 1 Then
              docto.nombreproveedor = context.comprador.Where(Function(x) x.deudor = idd).Select(Function(w) w.nombre).SingleOrDefault()
            Else
              docto.nombreproveedor = context.proveedor.Where(Function(x) x.deudor = idd).Select(Function(w) w.nombre).SingleOrDefault()
            End If

            Dim id = docto.iddocto

						docto.historiapagos = (From A In context.cobranza
									Where A.iddocto = id And A.cancelado = False
									Select New historiapagos With {
									.fecha = A.fecha,
									.monto = A.importe
									}).ToList()
          End If


        End If

        response.Ok = True

      Catch ex As Exception
        response.Detalle = ex.Message
      End Try
    End Using

    Return response
  End Function

  Function ConsultaOperacionesDAL(tipo As Integer, ByRef lista As List(Of Sp_GraficaOperacion)) As Result
    Dim response = New Result(False)
    Using context As New FactorContext
      Try

        Dim DateTime = Date.Today()
        Dim firstDayOfMonth = New Date(DateTime.Year, DateTime.Month, 1)
        Dim lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1)


        Dim parameters = New List(Of SqlParameter)
        parameters.Add(New SqlParameter("@tipo", tipo))
        parameters.Add(New SqlParameter("@fecini", firstDayOfMonth))
        parameters.Add(New SqlParameter("@fecfin", lastDayOfMonth))

        lista = context.Database.SqlQuery(Of Sp_GraficaOperacion)("Exec [dbo].[SP_Graficaoperacion] @tipo,@fecini,@fecfin", parameters.ToArray()).ToList()

        response.Ok = True
      Catch ex As Exception
        response.Detalle = ex.Message
      End Try
    End Using

    Return response
  End Function

  Function ConsultaCarteraDAL(ByRef lista As List(Of Sp_GraficaCartera)) As Result
    Dim response = New Result(False)
    Using context As New FactorContext
      Try


        lista = context.Database.SqlQuery(Of Sp_GraficaCartera)("Exec [dbo].[Sp_GraficaCartera]").ToList()

        response.Ok = True

      Catch ex As Exception
        response.Detalle = ex.Message
      End Try
    End Using

    Return response
  End Function

  Function consultaColoCbrnzaDAL(ByRef lista As List(Of SP_GraficaColocacion)) As Result
    Dim response = New Result(False)
    Using context As New FactorContext
      Try
        Dim DateTime = Date.Today()
        Dim firstDayOfMonth = New Date(DateTime.Year, DateTime.Month, 1)
        Dim lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1)


        Dim parameters = New List(Of SqlParameter)
        parameters.Add(New SqlParameter("@fecini", firstDayOfMonth))
        parameters.Add(New SqlParameter("@fecfin", lastDayOfMonth))

        lista = context.Database.SqlQuery(Of SP_GraficaColocacion)("Exec [dbo].[sp_colocacobra ] @fecini,@fecfin", parameters.ToArray()).ToList()

        response.Ok = True
      Catch ex As Exception
        response.Detalle = ex.Message
      End Try
    End Using

    Return response


  End Function

  Function RebatemensualDAL(mes As String, anio As String, ByRef model As List(Of Rebate)) As Result
    Dim response = New Result(False)
    Dim fecini As String
    'Dim fecfin As String
    fecini = anio + "-" + mes + "-" + "01"


    Dim fecha1 As Date
    Dim fecha2 As Date

    fecha1 = Date.Parse(fecini)
    Dim DaysInMonth As Integer = Date.DaysInMonth(fecha1.Year, fecha1.Month)
    fecha2 = New Date(fecha1.Year, fecha1.Month, DaysInMonth)


    Using context As New FactorContext
      Try
        Dim parameters = New List(Of SqlParameter)

        parameters.Add(New SqlParameter("@fecha1", fecha1))
        parameters.Add(New SqlParameter("@fecha2", fecha2))

        model = context.Database.SqlQuery(Of Rebate)("Exec [dbo].[SP_calculorebate] @fecha1,@fecha2", parameters.ToArray()).ToList()

        response.Ok = True
      Catch ex As Exception
        response.Detalle = ex.Message
      End Try
    End Using

    Return response
  End Function

End Class

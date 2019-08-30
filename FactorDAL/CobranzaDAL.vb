Imports System.Data.Entity.Infrastructure
Imports System.Data.SqlClient
Imports FactorEntidades
Imports System.Data.Entity
Imports System.Transactions



Public Class CobranzaDAL

#Region "Metodos de Consulta"

  Public Function consultaAdeudos(ByRef model As List(Of adeudosEntidad), contrato As Integer) As Result

    Dim Respuesta = New Result(False)
    Dim context As New FactorContext
    '
    Try
      Dim values = (From a In context.adeudos
          Join b In context.clientes
          On a.id Equals b.cliente
          Where a.saldo > 0 AndAlso a.identidad = 1 And (a.contrato = contrato Or 0 = contrato)
          Order By a.moneda, a.contrato
          Select New adeudosEntidad() With {.docto = a.docto, .tipo = a.tipo, .serie = a.serie,
          .contrato = a.contrato, .Nombre = b.nombre, .fec_alta = a.fec_alta, .monto = a.monto, .saldo = a.saldo, .moneda = a.moneda,
          .monedaStr = If(a.moneda = 1, "MXN", "USD"), .idadeudo = a.idadeudo}).Union(From a In context.adeudos
          Join b In context.proveedor
          On a.id Equals b.deudor
          Where a.saldo > 0 AndAlso a.identidad = 2 And (a.contrato = contrato Or 0 = contrato)
          Order By a.moneda, a.contrato
          Select New adeudosEntidad() With {.docto = a.docto, .tipo = a.tipo, .serie = a.serie,
          .contrato = a.contrato, .Nombre = b.nombre, .fec_alta = a.fec_alta, .monto = a.monto, .saldo = a.saldo, .moneda = a.moneda,
          .monedaStr = If(a.moneda = 1, "MXN", "USD"), .idadeudo = a.idadeudo}).Union(From a In context.adeudos
          Join b In context.comprador
          On a.id Equals b.deudor
          Where a.saldo > 0 AndAlso a.identidad = 3 And (a.contrato = contrato Or 0 = contrato)
          Order By a.moneda, a.contrato
          Select New adeudosEntidad() With {.docto = a.docto, .tipo = a.tipo, .serie = a.serie,
          .contrato = a.contrato, .Nombre = b.nombre, .fec_alta = a.fec_alta, .monto = a.monto, .saldo = a.saldo, .moneda = a.moneda,
          .monedaStr = If(a.moneda = 1, "MXN", "USD"), .idadeudo = a.idadeudo}).ToList()

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

        model.Add(a)
      Next

      Respuesta.Ok = True

    Catch ex As Exception
      Respuesta.Detalle = ex.Message

    End Try

    Return Respuesta

  End Function

  Function ConsultaAdeudosDetalleDAL(idadeudo As Integer, ByRef model As adeudos) As Result

    Dim respuesta = New Result(False)
    Using context As New FactorContext

      Try

        model = (From a In context.adeudos
            Where a.idadeudo = idadeudo).SingleOrDefault()
        If model IsNot Nothing Then
          respuesta.Ok = True
        End If

      Catch e As Exception
        respuesta.Detalle = e.Message
      End Try

    End Using
    Return respuesta
  End Function

  Public Function consultaPagosadeudos(ByRef model As List(Of adeudosEntidad), dfecha As Date) As Result

    Dim Respuesta = New Result(False)
    Dim context As New FactorContext
    '
    Try
      Dim values = (From a In context.pagosadeudos
          Join b In context.clientes
          On a.id Equals b.cliente
          Join c In context.adeudos
          On a.serie Equals c.serie And a.sisfol Equals c.sisfol
      Where a.cancelado = 0 AndAlso a.identidad = 1 AndAlso a.fecha = dfecha
          Order By a.contrato
          Select New adeudosEntidad() With {.fecha = a.fecha, .referencia = a.referencia, .numrec = a.numrec, .docto = a.docto, .tipo = a.tipo, .serie = a.serie,
          .contrato = a.contrato, .Nombre = b.nombre, .importe = a.importe, .moneda = c.moneda, .concepto = a.concepto,
          .monedaStr = If(c.moneda = 1, "MXN", "USD"), .idadeudo = a.idadeudo}).Union(From a In context.pagosadeudos
          Join b In context.proveedor
          On a.id Equals b.deudor
           Join c In context.adeudos
          On a.serie Equals c.serie And a.sisfol Equals c.sisfol
      Where a.cancelado = 0 AndAlso a.identidad = 2 AndAlso a.fecha = dfecha
          Order By a.contrato
          Select New adeudosEntidad() With {.fecha = a.fecha, .referencia = a.referencia, .numrec = a.numrec, .docto = a.docto, .tipo = a.tipo, .serie = a.serie,
          .contrato = a.contrato, .Nombre = b.nombre, .importe = a.importe, .moneda = c.moneda, .concepto = a.concepto,
          .monedaStr = If(c.moneda = 1, "MXN", "USD"), .idadeudo = a.idadeudo}).Union(From a In context.pagosadeudos
          Join b In context.comprador
          On a.id Equals b.deudor
           Join c In context.adeudos
          On a.serie Equals c.serie And a.sisfol Equals c.sisfol
          Where a.cancelado = 0 AndAlso a.identidad = 3 AndAlso a.fecha = dfecha
          Order By a.contrato
          Select New adeudosEntidad() With {.fecha = a.fecha, .referencia = a.referencia, .numrec = a.numrec, .docto = a.docto, .tipo = a.tipo, .serie = a.serie,
          .contrato = a.contrato, .Nombre = b.nombre, .importe = a.importe, .moneda = c.moneda, .concepto = a.concepto,
          .monedaStr = If(c.moneda = 1, "MXN", "USD"), .idadeudo = a.idadeudo}).ToList()

      For Each item As adeudosEntidad In values

        Dim a = New adeudosEntidad

        a.Adeudo = item.tipo + "-" + item.docto.Value.ToString("0000000")
        a.docto = item.docto
        a.tipo = item.tipo
        a.serie = item.serie
        a.contrato = item.contrato
        a.Nombre = item.Nombre
        a.importe = item.importe
        a.moneda = item.moneda
        a.concepto = item.concepto
        a.monedaStr = item.monedaStr
        a.idadeudo = item.idadeudo
        a.numrec = item.numrec
        a.referencia = item.referencia
        a.fecha = item.fecha

        model.Add(a)
      Next

      Respuesta.Ok = True

    Catch ex As Exception
      Respuesta.Detalle = ex.Message

    End Try

    Return Respuesta

  End Function

  Public Function consultaedocuenta(ByRef model As List(Of EdocuentaEntidad), fechaMes As String, fechaAnio As String, contrato As Integer) As Result

    Dim Respuesta = New Result(False)
    Dim context As New FactorContext
    Dim fecini As String

    fecini = "01-" + fechaMes + "-" + fechaAnio
    Dim dt As DateTime = Convert.ToDateTime(fecini)
    '
    Try

      Dim disponible As Decimal = 0
      Dim anticipo As Decimal = 0
      Dim cartera As Decimal = 0
      Dim santicipo As Decimal = 0
      Dim scartera As Decimal = 0
      Dim registro As Decimal = 0

      Dim previo = From res In (From a In context.edocuenta
           Where a.cancelado = 0 AndAlso a.contrato = contrato AndAlso a.fecha < dt
          Group a By keys = New With {Key a.contrato}
          Into gp = Group, asaldo = Sum(a.ant_debe - a.ant_haber), csaldo = Sum(a.car_debe - a.car_haber)
          Select New With {.contrato = keys.contrato, .ant_saldo = asaldo, .car_saldo = csaldo})
          Join b In context.contratos
          On b.contrato Equals res.contrato
          Join c In context.clientes
          On b.cliente Equals c.cliente
          Join p In context.producto
          On b.producto Equals p.id
          Select New With {b.contrato, b.linea, b.producto, .descripcion = p.producto1, b.moneda, res.ant_saldo, res.car_saldo, c.nombre}


      For Each item In previo

        anticipo = item.ant_saldo
        cartera = item.car_saldo


        If contrato > 0 Then

          Dim b = New EdocuentaEntidad
          b.contrato = item.contrato
          b.concepto = "Saldos iniciales..."
          b.nombre = item.nombre
          b.descripcion = item.descripcion
          b.producto = item.producto
          b.linea = item.linea
          b.moneda = item.moneda
          b.monedastr = IIf(item.moneda = 1, "MXN", "USD")
          b.ant_saldo = anticipo
          b.car_saldo = cartera
          b.disponible = item.linea - anticipo
          'b.ant_debe = ""
          'b.ant_haber = ""

          'b.car_debe = ""
          'b.car_haber = ""

          model.Add(b)
        End If
      Next


      'Dim previo = From a In context.edocuenta
      '             Where a.cancelado = 0 AndAlso a.contrato = contrato AndAlso a.fecha < dt
      '              Group a By keys = New With {Key a.contrato}
      '              Into gp = Group, asaldo = Sum(a.ant_debe - a.ant_haber), csaldo = Sum(a.car_debe - a.car_haber)
      '              Select New With {.contrato = keys.contrato, .ant_saldo = asaldo, .car_saldo = csaldo}



      santicipo = anticipo
      scartera = cartera

      Dim values = (From a In context.edocuenta
          Join b In context.contratos
          On a.contrato Equals b.contrato
          Join c In context.clientes
          On b.cliente Equals c.cliente
          Join d In context.producto
          On b.producto Equals d.id
        Where a.cancelado = 0 AndAlso a.contrato = contrato AndAlso a.fecha.Value.Year = fechaAnio AndAlso a.fecha.Value.Month = fechaMes
          Order By a.fecha Ascending
          Select New EdocuentaEntidad() With {.fecha = a.fecha, .contrato = a.contrato, .concepto = a.concepto, .ant_debe = a.ant_debe, .ant_haber = a.ant_haber, .ant_saldo = 0, .id = a.id, .car_debe = a.car_debe,
          .car_haber = a.car_haber, .car_saldo = 0, .nombre = c.nombre, .producto = b.producto, .descripcion = d.producto1, .linea = b.linea, .moneda = b.moneda,
          .monedastr = If(b.moneda = 1, "MXN", "USD")}).ToList()


      For Each item As EdocuentaEntidad In values

        'If registro = 0 And contrato > 0 Then
        '  Dim b = New EdocuentaEntidad
        '  b.contrato = item.contrato
        '  b.concepto = "Saldos iniciales..."
        '  b.nombre = item.nombre
        '  b.descripcion = item.descripcion
        '  b.producto = item.producto
        '  b.linea = item.linea
        '  b.moneda = item.moneda
        '  b.monedastr = IIf(item.moneda = 1, "MXN", "USD")
        '  b.ant_saldo = santicipo
        '  b.car_saldo = scartera

        '  'b.ant_debe = ""
        '  'b.ant_haber = ""

        '  'b.car_debe = ""
        '  'b.car_haber = ""


        '  registro = registro + 1
        '  model.Add(b)
        'End If

        Dim a = New EdocuentaEntidad

        a.fecha = item.fecha
        a.contrato = item.contrato
        a.id = item.id
        a.concepto = item.concepto
        a.movto = item.movto
        a.cancelado = item.cancelado
        a.proveedor = item.proveedor
        a.nombre = item.nombre
        a.descripcion = item.descripcion
        a.producto = item.producto
        a.linea = item.linea
        a.moneda = item.moneda
        a.monedastr = IIf(item.moneda = 1, "MXN", "USD")

        ' Saldos 
        a.anticipo = anticipo
        a.cartera = cartera

        a.ant_debe = item.ant_debe
        a.ant_haber = item.ant_haber

        ' Cartera
        a.cartera = cartera
        a.car_debe = item.car_debe
        a.car_haber = item.car_haber
        santicipo = santicipo + (item.ant_debe - item.ant_haber)
        scartera = scartera + (item.car_debe - item.car_haber)
        a.ant_saldo = santicipo
        a.car_saldo = scartera
        a.disponible = item.linea - santicipo
        registro = registro + 1
        model.Add(a)
      Next

      Respuesta.Ok = True

    Catch ex As Exception
      Respuesta.Detalle = ex.Message

    End Try

    Return Respuesta

  End Function

  Public Function Consultaregistrocobranza(ByRef model As List(Of CobranzaEntidad), fecha As Date, contrato As Integer) As Result

    Dim Respuesta = New Result(False)
    Using context As New FactorContext
      'Dim context As New FactorContext


      Dim timporte As Decimal = 0
      Dim tneto As Decimal = 0
      Dim tbonifica As Decimal = 0
      Dim tdescto As Decimal = 0
      Dim producto = 0
      Dim tadeudo As Decimal = 0
      Dim tmoratorio As Decimal = 0
      Dim tiv As Decimal = 0
      Dim tven As Decimal = 0
      Dim interes As Decimal = 0
      Dim moneda = 0
      Dim tprovision As Decimal = 0

      Dim descrip = ""
      Dim nombre = ""
      Dim previo = New CobranzaEntidad


      Try

        Dim parameters = New List(Of SqlParameter)
        parameters.Add(New SqlParameter("@contrato", contrato))
        parameters.Add(New SqlParameter("@fecha", fecha))

        previo = context.Database.SqlQuery(Of CobranzaEntidad)("Exec SP_totalesegistrocobranza @Contrato,@fecha",
                   parameters.ToArray()).SingleOrDefault()

        Dim cob = New CobranzaEntidad


        If contrato > 0 Then
          timporte = previo.timporte
          tneto = previo.tneto
          tbonifica = previo.tbonifica
          tdescto = previo.tdescto
          producto = previo.producto
          descrip = previo.descrip
          tprovision = previo.tprovision
          nombre = previo.Nombre
          tadeudo = previo.tadeudo
          tmoratorio = previo.tmoratorio
          interes = previo.interes
          moneda = previo.moneda
        End If



        Dim values


        If producto = 1 Then

          values = (From a In context.cobranza
              Join b In context.comprador
              On a.deudor Equals b.deudor
              Where a.cancelado = 0 AndAlso a.contrato = contrato AndAlso DbFunctions.TruncateTime(a.fecha) = fecha
              Order By a.deudor, a.cesion
              Select New CobranzaEntidad() With {.fecha = a.fecha, .idcobranza = a.idcobranza, .contrato = a.contrato, .iddocto = a.iddocto, .deudor = a.deudor,
              .cesion = a.cesion, .pagare = a.pagare, .docto = a.docto, .importe = a.importe, .descto = a.descto, .neto = a.neto, .bonifica = a.bonifica,
                       .saldoanterior = a.saldoanterior, .cobranza = a.cobranza1, .afectado = a.afectado, .cancelado = a.cancelado,
                       .cv = a.cv, .nombredeudor = b.nombre}).ToList()

        Else

          values = (From a In context.cobranza
                 Join b In context.proveedor
                 On a.deudor Equals b.deudor
                 Where a.cancelado = 0 AndAlso a.contrato = contrato AndAlso DbFunctions.TruncateTime(a.fecha) = fecha
                 Order By a.deudor, a.cesion
                 Select New CobranzaEntidad() With {.contrato = a.contrato, .fecha = a.fecha, .pagare = a.pagare, .idcobranza = a.idcobranza, .iddocto = a.iddocto, .deudor = a.deudor,
                        .cesion = a.cesion, .docto = a.docto, .importe = a.importe, .descto = a.descto, .neto = a.neto, .bonifica = a.bonifica,
                        .saldoanterior = a.saldoanterior, .cobranza = a.cobranza1, .afectado = a.afectado, .cancelado = a.cancelado,
                        .cv = a.cv, .nombredeudor = b.nombre}).ToList()



        End If

        'If values.Count() > 0 Then

        For Each item As CobranzaEntidad In values
          Dim a = New CobranzaEntidad

          a.fecha = fecha
          a.contrato = item.contrato
          a.idcobranza = item.idcobranza
          a.iddocto = item.iddocto
          a.deudor = item.deudor
          a.nombredeudor = item.nombredeudor
          a.cesion = item.cesion
          a.pagare = item.pagare
          a.docto = item.docto
          a.importe = item.importe
          a.descto = item.descto
          a.neto = item.neto
          a.bonifica = item.bonifica
          a.saldoanterior = item.saldoanterior
          a.cobranza = item.cobranza
          a.afectado = item.afectado
          a.cancelado = item.cancelado
          a.safectado = IIf(item.afectado = 0, "  ", "AF")
          a.scv = IIf(item.cv = 0, "  ", "CV")

          a.timporte = timporte
          a.tneto = tneto
          a.tbonifica = tbonifica
          a.tdescto = tdescto
          a.producto = producto
          a.descrip = descrip
          a.Nombre = nombre
          a.tadeudo = tadeudo
          a.tmoratorio = tmoratorio
          a.tprovision = tprovision
          a.interes = item.interes
          a.moneda = moneda
          a.monedastr = IIf(moneda = 1, "MXN", "USD")

          model.Add(a)
        Next
        'Else

        'Dim a = New CobranzaEntidad
        'a.timporte = timporte
        'a.tneto = tneto
        'a.tbonifica = tbonifica
        'a.tdescto = tdescto
        'a.producto = producto
        'a.descrip = descrip
        'a.Nombre = nombre
        'a.tadeudo = tadeudo
        'a.tmoratorio = tmoratorio
        'a.tprovision = tprovision
        'a.interes = interes
        'a.moneda = moneda
        'a.monedastr = IIf(moneda = 1, "MXN", "USD")

        'model.Add(a)

        'End If

        Respuesta.Ok = True

      Catch ex As Exception
        Respuesta.Detalle = ex.Message

      End Try
    End Using
    Return Respuesta

  End Function

  Public Function ConsultaCobglobalDAL(ByRef model As List(Of CobranzaEntidad), fecha As Date) As Result

    Dim Respuesta = New Result(False)
    Using context As New FactorContext
      'Dim context As New FactorContext


      Dim timporte As Decimal = 0
      Dim tneto As Decimal = 0
      Dim tbonifica As Decimal = 0
      Dim tdescto As Decimal = 0
      Dim afectado As Integer

      Dim tdeposito As Decimal = 0

      Dim descrip = ""
      Dim nombre = ""
      Dim previo = New CobranzaEntidad


      Try

        Dim parameters = New List(Of SqlParameter)
        'parameters.Add(New SqlParameter("@contrato", contrato))
        parameters.Add(New SqlParameter("@fecha", fecha))

        Dim values = context.Database.SqlQuery(Of CobranzaEntidad)("Exec SP_Cobglobal @fecha",
         parameters.ToArray()).ToList()

        timporte = values.Sum(Function(item) item.importe)
        tdescto = values.Sum(Function(item) item.descto)
        tneto = values.Sum(Function(item) item.neto)
        tbonifica = values.Sum(Function(item) item.bonifica)
        tdeposito = values.Sum(Function(item) item.deposito)
        afectado = values.Sum(Function(item) item.afectado)

        For Each item As CobranzaEntidad In values

          Dim a = New CobranzaEntidad

          'timporte = timporte + item.importe
          'tneto = tneto + item.neto
          'tbonifica = tbonifica + item.bonifica
          'tdescto = tdescto + item.descto
          'tdeposito = tdeposito + item.deposito

          a.fecha = fecha
          a.contrato = item.contrato
          a.Nombre = item.Nombre


          a.importe = item.importe
          a.descto = item.descto
          a.neto = item.neto
          a.bonifica = item.bonifica
          a.deposito = item.deposito
          a.afectado = afectado

          a.saldoanterior = item.saldoanterior
          a.cobranza = item.cobranza
          a.afectado = item.afectado
          a.cancelado = item.cancelado
          a.safectado = item.safectado
          a.monedastr = item.monedastr

          a.timporte = timporte
          a.tneto = tneto
          a.tbonifica = tbonifica
          a.tdescto = tdescto
          a.tdeposito = tdeposito
          a.tdeposito = tdeposito


          model.Add(a)

        Next



        Respuesta.Ok = True

      Catch ex As Exception
        Respuesta.Detalle = ex.Message

      End Try
    End Using
    Return Respuesta

  End Function

  Public Function Obtenerdocumentosxpagar(ByRef model As List(Of CobranzaEntidad), fecha As Date, contrato As Integer) As Result

    Dim Respuesta = New Result(False)
    Using context As New FactorContext
      'Dim context As New FactorContext

      Try



        Dim parameters = New List(Of SqlParameter)
        parameters.Add(New SqlParameter("@contrato", contrato))
        parameters.Add(New SqlParameter("@fecha", fecha))

        Dim values = context.Database.SqlQuery(Of CobranzaEntidad)("Exec SP_documentosporcobrar @Contrato,@fecha",
               parameters.ToArray()).ToList()



        For Each item As CobranzaEntidad In values

          Dim a = New CobranzaEntidad

          a.fecha = fecha
          a.fec_vence = item.fec_vence
          a.saldo = item.saldo
          a.contrato = item.contrato
          a.idcobranza = item.idcobranza
          a.iddocto = item.iddocto
          a.deudor = item.deudor
          a.nombredeudor = item.nombredeudor
          a.cesion = item.cesion
          a.pagare = item.pagare
          a.docto = item.docto
          a.importe = item.importe
          a.descto = item.descto
          a.neto = item.neto
          a.bonifica = item.bonifica
          a.saldoanterior = item.saldoanterior
          a.cobranza = item.cobranza
          a.afectado = item.afectado
          a.cancelado = item.cancelado
          a.moneda = item.moneda
          a.monedastr = IIf(item.moneda = 1, "MXN", "USD")
          a.safectado = IIf(item.afectado = 1, "X", "")
          a.scv = IIf(item.cv = 1, "CV", "  ")

          model.Add(a)
        Next


        Respuesta.Ok = True

      Catch ex As Exception
        Respuesta.Detalle = ex.Message

      End Try
    End Using
    Return Respuesta

  End Function

  Public Function ConsultaAforosLiquidadosDAL(fecha As Date, ByRef model As List(Of AforosLiquidadosEntidad), contrato As Integer) As Result
    Dim respuesta = New Result(False)

    Using context As New FactorContext
      Try

        Dim parameters = New List(Of SqlParameter)
        parameters.Add(New SqlParameter("@fecha", fecha))
        parameters.Add(New SqlParameter("@contrato", contrato))

        model = context.Database.SqlQuery(Of AforosLiquidadosEntidad)("Exec [dbo].[SP_ConsultaAforosLiquidados] " +
                          "@fecha , @contrato", parameters.ToArray()).ToList()

        respuesta.Ok = True
      Catch e As Exception
        respuesta.Detalle = e.Message
      End Try
    End Using

    Return respuesta

  End Function

  Public Function Obtenerpgeaforo(contrato As Integer, ByRef pgeaforo As Decimal) As Result

    Dim respuesta = New Result(False)
    Using context As New FactorContext

      Try

        Dim values = (From a In context.contratos
          Where a.contrato = contrato).SingleOrDefault()

        pgeaforo = (100 - values.porc_anti) / 100
        respuesta.Ok = True
      Catch e As Exception
        respuesta.Detalle = e.Message
      End Try

    End Using

    Return respuesta

  End Function

  Public Function ConsultaAforosPorLiquidarDAL(ByRef model As List(Of AforosPorLiquidar), contrato As Integer) As Result

    Dim respuesta = New Result(False)

    Using context As New FactorContext
      Try
        Dim parameters = New List(Of SqlParameter)
        parameters.Add(New SqlParameter("@contrato", contrato))

        model = context.Database.SqlQuery(Of AforosPorLiquidar)("Exec [dbo].[SP_ConsultaAforos] @contrato", parameters.ToArray()).ToList()

        respuesta.Ok = True
      Catch e As Exception
        respuesta.Detalle = e.Message
      End Try
    End Using

    Return respuesta

  End Function

  Public Function ConsultaCuentaLiquidaAforoDAL(identidad As Integer, id As Integer, moneda As Integer, ByRef lista As List(Of DropDownEntidad)) As Result

    Dim respuesta = New Result(False)

    Using context As New FactorContext
      Try
        lista = (From A In context.ctaprove
          Join B In context.webbancos
          On A.cuentaid Equals B.cuentaid
          Where A.identidad = identidad And A.id = id And A.moneda = moneda And A.activo = True
          Select New DropDownEntidad With {
            .clave = A.numrec,
            .nombre = B.shortname,
            .claveStr = A.cuenta}).ToList()


        respuesta.Ok = True
      Catch e As Exception
        respuesta.Detalle = e.Message
      End Try
    End Using

    Return respuesta

    End Function

    Function obtenerCarteraVencidaDAL(ByRef lista As List(Of SP_Vencidacontrato), contrato As Integer) As Result
        Dim respuesta = New Result(False)

        Using context As New FactorContext
            Try
                Dim parameters = New List(Of SqlParameter)
                parameters.Add(New SqlParameter("@contrato", contrato))

                lista = context.Database.SqlQuery(Of SP_Vencidacontrato)("Exec [dbo].[SP_Vencidacontrato] @contrato", parameters.ToArray()).ToList()

                respuesta.Ok = True
            Catch e As Exception
                respuesta.Detalle = e.Message
            End Try
        End Using

        Return respuesta
    End Function


    Function ConsultaAdeudosxpagarDAL(contrato As Integer, ByRef lista As List(Of AdeudosWzdEntidad))

        Dim Respuesta = New Result(False)
        Dim context As New FactorContext
        '
        Try

            Dim parameters = New List(Of SqlParameter)
            parameters.Add(New SqlParameter("@contrato", contrato))

            lista = context.Database.SqlQuery(Of AdeudosWzdEntidad)("Exec [dbo].[SP_adeudosxpagarcto] @contrato", parameters.ToArray()).ToList()


            ''lista = (From a In context.adeudos
            ''Where a.saldo > 0 AndAlso a.contrato = contrato
            ' ''Order By a.idadeudo
            ''    Select New AdeudosWzdEntidad() With {.void = a.void,
            ''                                      .adeudo = a.docto.Value.ToString("0000000"),
            ''                                      .tipo = a.tipo,
            ''                                      .serie = a.serie,
            ''                                      .contrato = a.contrato,
            ''                                      .monto = a.monto,
            ''                                      .saldo = a.saldo,
            ''                                      .docto = a.docto,
            ''                                      .idadeudo = a.idadeudo}).ToList()


            Respuesta.Ok = True

        Catch ex As Exception
            Respuesta.Detalle = ex.Message

        End Try

        Return Respuesta

    End Function


#End Region


#Region "Métodos transaccionales"

    Function ActualizarAdeudoDAL(ByRef model As adeudosEntidad) As Result

        Dim respuesta = New Result(False)

        Using scope As New TransactionScope

            Using context As New FactorContext()

                Try
                    'Lista de Lista permite almacenar multiples consulta al servicio t24 para generar un solo xml 
                    Dim parameters = New List(Of SqlParameter)
                    parameters.Add(New SqlParameter("@idadeudo", model.idadeudo))
                    parameters.Add(New SqlParameter("@movto", model.movto))
                    parameters.Add(New SqlParameter("@concepto", model.concepto))
                    parameters.Add(New SqlParameter("@importe", model.saldo))

                    context.Database.SqlQuery(Of adeudosEntidad)("Exec [dbo].[SP_Pagoadeudo] " +
                              " @idadeudo, " +
                              " @movto, " +
                              " @concepto , " +
                              " @importe ", parameters.ToArray()).ToList()

                    'Bitacora.Monitor(userid:=,"mensaje")
                    respuesta.Ok = True
                    scope.Complete()

                Catch e As Exception
                    respuesta.Detalle = e.Message

                End Try

            End Using

        End Using

        Return respuesta

    End Function

    Public Function GuardarCobranzaDAL(doctos As List(Of CobranzaEntidad)) As Result
        Dim respuesta = New Result(False)
        Using context As New FactorContext
            Try
                Dim listaCobranza = New List(Of cobranza)

                For Each item As CobranzaEntidad In doctos

                    Dim cobranza = New cobranza()
                    cobranza.contrato = item.contrato
                    cobranza.cesion = item.cesion
                    cobranza.deudor = item.deudor
                    cobranza.docto = item.docto.Trim()
                    cobranza.importe = item.importe
                    cobranza.descto = item.descto
                    cobranza.neto = item.neto
                    cobranza.bonifica = item.bonifica
					cobranza.afectado = 0
                    cobranza.cancelado = 0
                    cobranza.fecha = Date.Now()
                    cobranza.cv = item.cv
                    cobranza.saldoanterior = item.saldo
                    cobranza.iddocto = item.iddocto
                    cobranza.cobranza1 = item.cobranza
                    cobranza.pagare = item.pagare.Trim()

                    listaCobranza.Add(cobranza)

                Next

                context.cobranza.AddRange(listaCobranza)
                context.SaveChanges()
                respuesta.Ok = True

            Catch e As Exception
                respuesta.Detalle = e.Message
            End Try

        End Using

        Return respuesta
    End Function

    Public Function EliminadoctoDAL(idcob As Integer) As Result
        Dim respuesta = New Result(False)

        Using context As New FactorContext

            'eliminar registro
            Try
                Dim lista = context.cobranza.Where(Function(x) x.idcobranza = idcob).SingleOrDefault()

                If lista.afectado = 0 Then
                    lista.cancelado = 1
                    context.SaveChanges()
                    respuesta.Ok = True
                End If

            Catch e As Exception
                respuesta.Detalle = e.InnerException.InnerException.Message
            End Try

        End Using

        Return respuesta
    End Function

    Public Function InicializarAforoDAL(contrato As Integer, id As Integer, identidad As Integer) As Result
        Dim respuesta = New Result(False)

        Using context As New FactorContext

            Try
                Dim lista = context.Aforo.Where(Function(x) x.contrato = contrato And x.id = id And x.identidad = identidad And x.idpago = 0).ToList()

                For Each item As Aforo In lista
                    item.cancelado = 1
                Next

                context.SaveChanges()
                respuesta.Ok = True

            Catch e As Exception
                respuesta.Detalle = e.InnerException.InnerException.Message
            End Try

        End Using

        Return respuesta
    End Function

    Public Function liquidaAforoDAL(model As AforosPorLiquidar) As Result
        Dim respuesta = New Result(False)

        Using context As New FactorContext

            Try
                Dim parameters = New List(Of SqlParameter)
                parameters.Add(New SqlParameter("@contrato", model.contrato))
                parameters.Add(New SqlParameter("@id", model.id))
                parameters.Add(New SqlParameter("@identidad", model.identidad))
                parameters.Add(New SqlParameter("@numrec", model.numrec))
                parameters.Add(New SqlParameter("@cartera", model.cartera))
                context.Database.ExecuteSqlCommand("Exec [dbo].[SP_LiquidarAforo] " +
                               " @contrato ," +
                               " @id," +
                               " @identidad," +
                               " @numrec," +
                               " @cartera", parameters.ToArray())

                respuesta.Ok = True
            Catch e As Exception
                respuesta.Detalle = e.Message
            End Try

        End Using

        Return respuesta
    End Function

    Public Function CancelarAforoDAL(numrec As Integer) As Result
        Dim respuesta = New Result(False)

        Using context As New FactorContext

            Try
                Dim parameters = New List(Of SqlParameter)
                parameters.Add(New SqlParameter("@Numrec", numrec))
                Dim value = context.Database.ExecuteSqlCommand("Exec [dbo].[SP_CancelarAforo] " +
                             " @Numrec", parameters.ToArray())
                respuesta.Ok = True
            Catch e As Exception
                respuesta.Detalle = e.Message
            End Try

        End Using

        Return respuesta
    End Function

    Public Function AfectacobDAL(fecha As Date, contrato As Integer) As Result

        Dim Respuesta = New Result(False)
        Dim previo As String
        Using context As New FactorContext
            'Dim context As New FactorContext

            Try

                Dim parameters = New List(Of SqlParameter)
                parameters.Add(New SqlParameter("@contrato", contrato))
                parameters.Add(New SqlParameter("@fecha", fecha))

                previo = context.Database.SqlQuery(Of String)("Exec SP_AfectaCobranzaV2 @Contrato,@fecha",
                           parameters.ToArray()).SingleOrDefault()


                If previo = "Cobranza afectada" Then
                    Respuesta.DetalleServicio = ""
                    Respuesta.Mensaje = String.Concat("Cobranza del contrato  :", contrato.ToString(), " afectada existosamente")
                Else
                    Respuesta.Mensaje = previo
                End If

                Respuesta.Ok = True

            Catch ex As Exception
                Respuesta.Detalle = ex.Message

            End Try
        End Using
        Return Respuesta
    End Function

    Public Function EliminarcobDAL(fecha As Date, contrato As Integer) As Result

        Dim Respuesta = New Result(False)
        Dim previo As String
        Using context As New FactorContext
            'Dim context As New FactorContext

            Try

                Dim parameters = New List(Of SqlParameter)
                parameters.Add(New SqlParameter("@contrato", contrato))
                parameters.Add(New SqlParameter("@fecha", fecha))

                previo = context.Database.SqlQuery(Of String)("Exec SP_EliminaCobranza @Contrato,@fecha",
                           parameters.ToArray()).SingleOrDefault()


                If previo = "Cobranza eliminada" Then
                    Respuesta.DetalleServicio = ""
                    Respuesta.Mensaje = String.Concat("Cobranza del contrato  :", contrato.ToString(), " eliminada existosamente")
                Else
                    Respuesta.Mensaje = previo
                End If

                Respuesta.Ok = True

            Catch ex As Exception
                Respuesta.Detalle = ex.Message

            End Try
        End Using
        Return Respuesta
    End Function


    Public Function AfectacobglobalDAL(fecha As Date) As Result

        Dim Respuesta = New Result(False)
        Dim previo As String
        Using context As New FactorContext
            'Dim context As New FactorContext

            Try

                Dim parameters = New List(Of SqlParameter)
                parameters.Add(New SqlParameter("@fecha", fecha))

                previo = context.Database.SqlQuery(Of String)("Exec SP_AfectaCobranzaglobal @fecha",
                           parameters.ToArray()).SingleOrDefault()


                If previo = "Cobranza afectada" Then
                    Respuesta.DetalleServicio = ""
                    Respuesta.Mensaje = String.Concat("Cobranza Global del ", fecha.ToString("dd-MM-yyyy HH:mm:ss"), " afectada existosamente")
                Else
                    Respuesta.Mensaje = previo
                End If

                Respuesta.Ok = True

            Catch ex As Exception
                Respuesta.Detalle = ex.Message

            End Try
        End Using
        Return Respuesta

    End Function


    Public Function ReversocobDAL(fecha As Date, contrato As Integer) As Result

        Dim Respuesta = New Result(False)
        Dim previo As String
        Using context As New FactorContext
            'Dim context As New FactorContext

            Try

                Dim parameters = New List(Of SqlParameter)
                parameters.Add(New SqlParameter("@contrato", contrato))
                parameters.Add(New SqlParameter("@fecha", fecha))

                previo = context.Database.SqlQuery(Of String)("Exec SP_ReversoCobranzaV2 @Contrato,@fecha",
                           parameters.ToArray()).SingleOrDefault()


                If previo = "Cobranza Desafectada" Then
                    Respuesta.DetalleServicio = ""
                    Respuesta.Mensaje = String.Concat("Reverso de cobranza del contrato  :", contrato.ToString(), " realizada existosamente")
                Else
                    Respuesta.Mensaje = previo
                End If

                Respuesta.Ok = True

            Catch ex As Exception
                Respuesta.Detalle = ex.Message

            End Try
        End Using
        Return Respuesta
    End Function



    Public Function AccesoriosDAL(ByRef model As List(Of MonitorlineasEntidad)) As Result

        Dim respuesta = New Result(False)

        Using context As New FactorContext
            Try
                model = context.Database.SqlQuery(Of MonitorlineasEntidad)("Exec [dbo].[SP_MonitorLineas]").ToList()

                respuesta.Ok = True
            Catch e As Exception
                respuesta.Detalle = e.Message
            End Try
        End Using

        Return respuesta

    End Function

    Public Function ProvisionDAL(contrato As Integer, tipo As String) As Result

        Dim Respuesta = New Result(False)
        Dim previo As String
        Dim fecini As DateTime
        Dim fecfin As DateTime

        Dim cprovision As String = ""

        Select Case tipo
            Case "IV"
                cprovision = "Int. al Vmto"
            Case "MV"
                cprovision = "Int. Mensual Vencido"
            Case "CM"
                cprovision = "Int. Moratorio"
        End Select

        ' rtn = rtn.AddDays(-rtn.Day + 1) Primer día

        '    rtn = rtn.AddDays(-rtn.Day + 1).AddMonths(1).AddDays(-1)  ultimo día de mes 

        fecfin = Date.Today()
        fecini = fecfin.AddDays(-fecfin.Day + 1)

        Using context As New FactorContext

            Try

                Dim parameters = New List(Of SqlParameter)
                parameters.Add(New SqlParameter("@contrato", contrato))
                parameters.Add(New SqlParameter("@tipo", tipo))

                If tipo = "IV" Then
                    parameters.Add(New SqlParameter("@finicio", fecfin))
                Else
                    parameters.Add(New SqlParameter("@finicio", fecini))
                End If

                parameters.Add(New SqlParameter("@ffin", fecfin))

                previo = context.Database.SqlQuery(Of String)("Exec SP_Facturaprovision @Contrato,@tipo,@finicio,@ffin",
                           parameters.ToArray()).SingleOrDefault()

                If previo = "" Then
                    Respuesta.DetalleServicio = ""
                    Respuesta.Mensaje = String.Concat("Provisión " + cprovision + " del contrato  :", contrato.ToString(), " realizada existosamente")
                Else
                    Respuesta.Mensaje = previo
                End If

                Respuesta.Ok = True

            Catch ex As Exception
                Respuesta.Detalle = ex.Message

            End Try
        End Using
        Return Respuesta
    End Function



#End Region



End Class


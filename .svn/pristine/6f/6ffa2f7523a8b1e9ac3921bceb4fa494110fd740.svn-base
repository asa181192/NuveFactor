Imports FactorEntidades
Imports System.Data.SqlClient
Imports System

Public Class CesionesDAL

#Region "Constructor"

#End Region

#Region "Metodos de consulta"

	Public Function ConsultaCesionesDAL(Contrato As Integer, ByRef model As List(Of CesionEntidad)) As Result

		Dim respuesta = New Result(False)

    Using context As New FactorContext
      Try

        Dim parameters = New List(Of SqlParameter)
        parameters.Add(New SqlParameter("@Contrato", Contrato))
        model = context.Database.SqlQuery(Of CesionEntidad)("Exec [dbo].[SP_ConsultaCesiones] " +
                                     " @Contrato ", parameters.ToArray()).ToList()

        respuesta.Ok = True
      Catch e As Exception
        respuesta.Detalle = e.Message
      End Try

    End Using

    Return respuesta

  End Function

    Public Function ConsultaDoctosDAL(contrato As Integer, cesion As Integer, idtransact As String, ByRef model As List(Of DoctosEntidad)) As Result

        Dim respuesta = New Result(False)

        Using context As New FactorContext
            Try


                Dim producto = context.contratos.Where(Function(x) x.contrato = contrato).Select(Function(x) x.producto).SingleOrDefault()
                Dim ces As Integer = 0

                If cesion = 0 Then

                    Dim con = context.cesiones.Where(Function(x) x.idtransact = idtransact).Select(Function(x) x.cesion).SingleOrDefault()

                    If con IsNot Nothing Then
                        cesion = con
                    End If

               
                End If

                If producto = 1 Then

                    model = (From A In context.doctos
                        From B In context.comprador.Where(Function(w) w.deudor = A.deudor).DefaultIfEmpty()
                        Where A.contrato = contrato And A.cesion = cesion
                        Select New DoctosEntidad With {
                                .iddocto = A.iddocto,
                                .docto = A.docto,
                                .fec_vence = A.fec_vence,
                                .importe = A.importe,
                                .descto = A.descto,
                                .monto = A.monto,
                                .interes = A.interes,
                                .hono = A.hono,
                                .iva = A.iva,
                                .nombreDeudor = B.nombre
                                }).ToList()

                Else

                    model = (From A In context.doctos
                    From B In context.proveedor.Where(Function(w) w.deudor = A.deudor).DefaultIfEmpty()
                    Where A.contrato = contrato And A.cesion = cesion
                    Select New DoctosEntidad With {
                            .iddocto = A.iddocto,
                            .docto = A.docto,
                            .fec_vence = A.fec_vence,
                            .importe = A.importe,
                            .descto = A.descto,
                            .monto = A.monto,
                            .interes = A.interes,
                            .hono = A.hono,
                            .iva = A.iva,
                            .nombreDeudor = B.nombre
                            }).ToList()

                End If


                respuesta.Ok = True
            Catch e As Exception
                respuesta.Detalle = e.Message
            End Try

        End Using

        Return respuesta

    End Function

    Public Function ConsultaGarantiaDAL(contrato As Integer, cesion As Integer, idtransact As String, ByRef model As List(Of GarantiaEntidad)) As Result

        Dim respuesta = New Result(False)

        Using context As New FactorContext
            Try


                Dim ces As cesiones
                If cesion = 0 Then
                    ces = context.cesiones.Where(Function(x) x.idtransact = idtransact).SingleOrDefault()

                    If ces IsNot Nothing Then
                        cesion = ces.cesion
                    Else
                        cesion = 0
                    End If

                Else
                    ces = context.cesiones.Where(Function(x) x.contrato = contrato And x.cesion = cesion).SingleOrDefault()
                End If


                model = (From A In context.garantia
                    Join B In context.tipogarantia
                    On A.tipo Equals B.tipoid
                    Where A.contrato = contrato AndAlso A.cesion = cesion AndAlso A.cancelado = False
                    Select New GarantiaEntidad With {
                              .garantiaid = A.garantiaid,
                              .nombreTipo = B.nombre,
                               .costo = A.costo,
                              .ivacobrado = A.ivacobrado,
                              .cobrado = A.cobrado,
                              .porcentaje = A.porcentaje,
                .valor = A.valor}).ToList()

                    respuesta.Ok = True
            Catch e As Exception
                respuesta.Detalle = e.Message
            End Try

        End Using

        Return respuesta

    End Function


    Public Function ConsultapagosadeudosCtoCesDAL(cesion As Integer, contrato As Integer, idtransact As String, ByRef model As List(Of PagosAdeudosEntidad)) As Result

        Dim respuesta = New Result(False)

        Using context As New FactorContext
            Try

                Dim ces As cesiones
                If cesion = 0 Then
                    ces = context.cesiones.Where(Function(x) x.idtransact = idtransact).SingleOrDefault()
                    cesion = ces.cesion
                Else
                    ces = context.cesiones.Where(Function(x) x.cesion = cesion And x.contrato = contrato).SingleOrDefault()
                End If

                model = (From A In context.pagosadeudos
                       Where A.contrato = contrato AndAlso A.cancelado = 0 AndAlso A.movto = "CE" AndAlso A.concepto = "Se liquido - Cesion " + CStr(cesion).Trim
                    Select New PagosAdeudosEntidad With {
                              .numrec = A.numrec,
                              .serie = A.serie,
                              .tipo = A.tipo,
                              .importe = A.importe,
                              .docto = A.docto
                            }).ToList()

                respuesta.Ok = True
            Catch e As Exception
                respuesta.Detalle = e.Message
            End Try

        End Using

        Return respuesta

    End Function

  Function ConsultaDetalleCesionDAL(cesion As Integer, ByRef model As CesionEntidad, contrato As Integer) As Result

    Dim respuesta = New Result(False)
    Using context As New FactorContext

      Try


				model = (From A In context.cesiones
					 Join B In context.ctaprove
					 On A.numreccta Equals B.numrec
					 From C In context.proveedor.Where(Function(x) x.deudor = A.proveedor).DefaultIfEmpty()
					 Join D In context.contratos
					 On A.contrato Equals D.contrato
					 Where A.cesion = cesion And A.contrato = contrato
							Select New CesionEntidad With {
									  .cesion = A.cesion,
									  .porc_anti = D.porc_anti,
									  .plazo = A.plazo,
									  .fec_vence = A.fec_vence,
									  .fec_alta = A.fec_alta,
									  .doctos = A.doctos,
									  .tasaoper = A.tasaoper,
									  .tasahono = A.tasahono,
									  .importe = A.importe,
									  .interes = A.interes,
									  .honorario = A.honorario,
									  .ivahonorario = A.ivahonorario,
									  .garantnafin = A.garantnafin,
									  .ivaganafin = A.ivaganafin,
									  .totalpagar = A.totalpagar,
									  .impanticipado = A.impanticipado,
									  .proveedor = A.proveedor,
									  .numreccta = A.numreccta,
									  .clabe = B.clabe,
				.proveedorNombre = C.nombre
										}).SingleOrDefault()
        If model IsNot Nothing Then
          respuesta.Ok = True
        End If

      Catch e As Exception
        respuesta.Detalle = e.Message
        respuesta.Id_Out = 1
      End Try

    End Using
    Return respuesta
  End Function

    'contrato, producto, cesion, CesionEntidad
    Function ConsultaCesionWzdDAL(contrato As Integer, producto As Integer, cesion As Integer, ByRef model As CesionWzdEntidad) As Result

        Dim respuesta = New Result(False)
        Using context As New FactorContext

            Try

                'Public Property contrato As Integer
                'Public Property cesion As Integer
                'Public Property moneda As Integer
                'Public Property producto As Integer
                'Public Property porc_anti As Decimal
                'Public Property interes As Decimal
                'Public Property tinter As Integer
                ''
                'Public Property doctos As Integer
                'Public Property fec_alta As Date
                'Public Property fec_vence As Date
                'Public Property importe As Decimal
                'Public Property impanticipado As Decimal
                'Public Property tasaoper As Decimal
                'Public Property plazo As Integer


                If producto = 1 Then

                    model = (From a In context.cesiones
                             Join b In context.contratos
                            On a.contrato Equals b.contrato
                     Where a.cesion = cesion And a.contrato = contrato
                  Select New CesionWzdEntidad With {
                            .contrato = a.contrato,
                            .cesion = a.cesion,
                            .moneda = b.moneda,
                            .producto = b.producto,
                            .porc_anti = b.porc_anti,
                            .interes = a.interes,
                            .tinter = b.interes,
                            .doctos = a.doctos,
                            .fec_vence = a.fec_vence,
                            .fec_alta = a.fec_alta,
                             .importe = a.importe,
                            .impanticipado = a.impanticipado,
                            .tasaoper = a.tasaoper,
                            .idcesion = a.idcesion,
                            .plazo = a.plazo
                              }).SingleOrDefault()

                    'model = (From A In context.cesiones
                    '     Join B In context.ctaprove
                    '     On A.numreccta Equals B.numrec
                    '     Join D In context.contratos
                    '     On A.contrato Equals D.contrato
                    '     Where A.cesion = cesion And A.contrato = contrato
                    '            Select New CesionEntidad With {
                    '                      .cesion = A.cesion,
                    '                      .porc_anti = D.porc_anti,
                    '                      .plazo = A.plazo,
                    '                      .fec_vence = A.fec_vence,
                    '                      .fec_alta = A.fec_alta,
                    '                      .doctos = A.doctos,
                    '                      .tasaoper = A.tasaoper,
                    '                      .tasahono = A.tasahono,
                    '                      .importe = A.importe,
                    '                      .interes = A.interes,
                    '                      .honorario = A.honorario,
                    '                      .ivahonorario = A.ivahonorario,
                    '                      .garantnafin = A.garantnafin,
                    '                      .ivaganafin = A.ivaganafin,
                    '                      .totalpagar = A.totalpagar,
                    '                      .impanticipado = A.impanticipado,
                    '                      .proveedor = A.proveedor,
                    '                      .numreccta = A.numreccta,
                    '                      .clabe = B.clabe,
                    '.proveedorNombre = ""
                    '                        }).SingleOrDefault()

                    'Else

                    '    model = (From A In context.cesiones
                    '             Join B In context.ctaprove
                    '             On A.numreccta Equals B.numrec
                    '             From C In context.proveedor.Where(Function(x) x.deudor = A.proveedor).DefaultIfEmpty()
                    '             Join D In context.contratos
                    '             On A.contrato Equals D.contrato
                    '             Where A.cesion = cesion And A.contrato = contrato
                    '                    Select New CesionEntidad With {
                    '                              .cesion = A.cesion,
                    '                              .porc_anti = D.porc_anti,
                    '                              .plazo = A.plazo,
                    '                              .fec_vence = A.fec_vence,
                    '                              .fec_alta = A.fec_alta,
                    '                              .doctos = A.doctos,
                    '                              .tasaoper = A.tasaoper,
                    '                              .tasahono = A.tasahono,
                    '                              .importe = A.importe,
                    '                              .interes = A.interes,
                    '                              .honorario = A.honorario,
                    '                              .ivahonorario = A.ivahonorario,
                    '                              .garantnafin = A.garantnafin,
                    '                              .ivaganafin = A.ivaganafin,
                    '                              .totalpagar = A.totalpagar,
                    '                              .impanticipado = A.impanticipado,
                    '                              .proveedor = A.proveedor,
                    '                              .numreccta = A.numreccta,
                    '                              .clabe = B.clabe,
                    '                              .proveedorNombre = C.nombre
                    '                                }).SingleOrDefault()


                End If

                If model IsNot Nothing Then
                    respuesta.Ok = True
                End If


            Catch e As Exception
                respuesta.Detalle = e.Message
                respuesta.Id_Out = 1
            End Try

        End Using
        Return respuesta
    End Function



  Function ConsultaDetalleGarantiaDAL(garantiaid As Integer, ByRef model As GarantiaEntidad) As Result

    Dim respuesta = New Result(False)
    Using context As New FactorContext

      Try
        model = context.garantia.Where(Function(x) x.garantiaid = garantiaid).Select(Function(x) New GarantiaEntidad With {
                                                           .codigo = x.codigo,
                                                           .tipo = x.tipo,
                                                           .valor = x.valor,
                                                           .porcentaje = x.porcentaje,
                                                           .costo = x.costo,
                                                           .cobrado = x.cobrado,
                                                           .ivacobrado = x.ivacobrado
                                                           }).SingleOrDefault()

        If model IsNot Nothing Then
          respuesta.Ok = True
        End If

      Catch e As Exception
        respuesta.Detalle = e.Message
        respuesta.Id_Out = 1
      End Try

    End Using
    Return respuesta
  End Function



    Function GuardardoctoDAL(iddocto As Integer, contrato As Integer, cesion As Integer, ByRef model As DoctosEntidad) As Result

        Dim respuesta = New Result(False)
        Using context As New FactorContext

            Try
                model = context.doctos.Where(Function(x) x.iddocto = iddocto).Select(Function(x) New DoctosEntidad With {
                                                                   .iddocto = x.iddocto,
                                                                   .docto = x.docto,
                                                                   .monto = x.monto,
                                                                   .saldo = x.saldo,
                                                                   .fec_vence = x.fec_vence,
                                                                   .deudor = x.deudor
                                                                   }).SingleOrDefault()

                If model IsNot Nothing Then
                    respuesta.Ok = True
                End If

            Catch e As Exception
                respuesta.Detalle = e.Message
                respuesta.Id_Out = 1
            End Try

        End Using
        Return respuesta
    End Function


    Function GuardargarantiaDAL(garantiaid As Integer, contrato As Integer, cesion As Integer, ByRef model As GarantiaEntidad) As Result

        Dim respuesta = New Result(False)
        Using context As New FactorContext


            Try
                'Where a.cesion = cesion And a.contrato = contrato

                model = (From a In context.garantia
                         Join b In context.tipogarantia
                        On a.tipo Equals b.tipoid
                Where a.garantiaid = garantiaid
              Select New GarantiaEntidad With {
                           .garantiaid = a.garantiaid,
                            .tipo = a.tipo,
                            .valor = a.valor,
                            .porcentaje = a.porcentaje,
                            .costo = a.costo,
                            .cobrado = a.cobrado,
                            .ivacobrado = a.ivacobrado,
                            .nombreTipo = b.concepto}).SingleOrDefault()

                If model IsNot Nothing Then
                    respuesta.Ok = True
                End If

            Catch e As Exception
                respuesta.Detalle = e.Message
                respuesta.Id_Out = 1
            End Try

        End Using
        Return respuesta
    End Function

    Public Function EliminagarantiaDAL(garantiaid As Integer) As Result
        Dim respuesta = New Result(False)

        Using context As New FactorContext

            'eliminar registro
            Try
                Dim lista = context.garantia.Where(Function(x) x.garantiaid = garantiaid).SingleOrDefault()

                lista.cancelado = 1
                context.SaveChanges()
                respuesta.Ok = True
                
            Catch e As Exception
                respuesta.Detalle = e.InnerException.InnerException.Message
            End Try

        End Using

        Return respuesta
    End Function

#End Region

#Region "Metodos Transaccionales"
  Public Function ActualizarGarantiaDAL(model As garantia) As Result
    Dim respuesta = New Result(False)

    Using context As New FactorContext

      Try
        Dim garantia = context.garantia.Where(Function(x) x.garantiaid = model.garantiaid).SingleOrDefault()

        If garantia IsNot Nothing Then
          garantia.codigo = model.codigo
          garantia.tipo = model.tipo
          garantia.valor = model.valor
          garantia.porcentaje = model.porcentaje
          garantia.costo = model.costo
          garantia.cobrado = model.cobrado
          garantia.ivacobrado = model.ivacobrado
        End If

        context.SaveChanges()
        respuesta.Ok = True
      Catch e As Exception
        respuesta.Detalle = e.InnerException.InnerException.Message
      End Try

    End Using

    Return respuesta
    End Function


    Public Function ActualizarcesionDAL(model As cesiones) As Result
        Dim respuesta = New Result(False)

        Using context As New FactorContext

            Try
                Dim ces = context.cesiones.Where(Function(x) x.idcesion = model.idcesion).SingleOrDefault()

                If ces IsNot Nothing Then
                    'cesiones.codigo = model.codigo
                    'garantia.tipo = model.tipo
                    'garantia.valor = model.valor
                    'garantia.porcentaje = model.porcentaje
                    'garantia.costo = model.costo
                    'garantia.cobrado = model.cobrado
                    'garantia.ivacobrado = model.ivacobrado
                End If

                context.SaveChanges()
                respuesta.Ok = True
            Catch e As Exception
                respuesta.Detalle = e.InnerException.InnerException.Message
            End Try

        End Using

        Return respuesta
    End Function

    Public Function ActualizarcesionWzdDAL(model As cesiones) As Result
        Dim respuesta = New Result(False)

        Using context As New FactorContext

            Try
                Dim ces = context.cesiones.Where(Function(x) x.cesion = model.cesion And x.contrato = model.contrato).SingleOrDefault()

                If ces IsNot Nothing Then
                    ces.importe = model.importe
                    ces.impanticipado = model.impanticipado
                    ces.fec_vence = model.fec_vence
                    ces.doctos = model.doctos
                End If

                context.SaveChanges()
                respuesta.Ok = True
            Catch e As Exception
                respuesta.Detalle = e.InnerException.InnerException.Message
            End Try

        End Using

        Return respuesta
    End Function


    Public Function AltacesionDAL(model As cesiones) As Result

        Dim respuesta = New Result(False)

        Using context As New FactorContext
            Try

                Dim sGuid As String
                sGuid = System.Guid.NewGuid.ToString()


                model.idtransact = sGuid
                model.proveedor = 0
                model.timestart = Date.Now
                model.impanticipado = model.importe


                context.cesiones.Add(model)
                context.SaveChanges()
                respuesta.Ok = True
            Catch e As Exception
                respuesta.Detalle = e.InnerException.InnerException.Message
            End Try

        End Using

        Return respuesta

    End Function

    Public Function AltacesionWzdDAL(model As cesiones) As Result

        Dim respuesta = New Result(False)

        Using context As New FactorContext
            Try

                'Dim sGuid As String
                'sGuid = System.Guid.NewGuid.ToString()
                'model.idtransact = sGuid
                Dim contrato = context.contratos.Where(Function(x) x.contrato = model.contrato).SingleOrDefault()
                Dim tasas = context.indicadores.Where(Function(x) x.fecha = model.fec_alta).SingleOrDefault()
                Dim util = (From a In context.edocuenta Where a.contrato = model.contrato AndAlso a.cancelado = 0 Select a.ant_debe - a.ant_haber).Sum()

                Dim dispo As Decimal = 0
                If util Is Nothing Then
                    util = 0
                End If

                dispo = contrato.linea - (util + model.impanticipado)
                respuesta.Mensaje = ""

                If dispo < 0 Then
                    respuesta.Detalle = "<br/>-  Cesión presenta presenta sobregiro por " + FormatCurrency(dispo, 2, TriState.True)
                End If

                If contrato.bloqueado = True Then
                    respuesta.Detalle = respuesta.Detalle + "<br/>- Contrato se encuentra bloqueado"
                End If


                If respuesta.Detalle = "" Then



                    'Dim control = context.control.SingleOrDefault()
                    Dim iva2 = context.control.Select(Function(x) x.iva).SingleOrDefault()

                    Dim iva = Decimal.Round(iva2 / 100, 2, MidpointRounding.AwayFromZero)

                    If contrato IsNot Nothing Then
                        contrato.cesiones = contrato.cesiones + 1
                        context.SaveChanges()
                    End If

                    model.tasa_ord = context.contratos.Where(Function(x) x.contrato = model.contrato).Select(Function(x) x.tasa_ord).SingleOrDefault()
                    model.cesion = context.contratos.Where(Function(x) x.contrato = model.contrato).Select(Function(x) x.cesiones).SingleOrDefault()
                    model.sumadoctos = 0
                    model.proveedor = 0
                    model.fec_fondeo = model.fec_alta

                    Dim indica = IIf(contrato.moneda = 1, tasas.tiie, tasas.libor)

                    model.tasaoper = IIf(contrato.interes = 2, 0, contrato.tasa_ord + indica)
                    Dim toper = Decimal.Round(model.tasaoper / 100, 4, MidpointRounding.AwayFromZero)

                    'Calculo de interes
                    If contrato.interes = 1 Then
                        model.interes = Decimal.Round(((model.impanticipado * toper) / 360) * model.plazo, 2, MidpointRounding.AwayFromZero)
                    Else
                        model.interes = 0
                    End If
                    model.ivainteres = 0

                    'Calculo de honorario
                    model.tasahono = IIf(contrato.honorario = 1, Decimal.Round(model.plazo * (contrato.hon_admon / 30), 4, MidpointRounding.AwayFromZero), contrato.hon_admon)
                    If model.tasahono > 0 Then
                        model.honorario = Decimal.Round(model.importe * (model.tasahono / 100), 2, MidpointRounding.AwayFromZero)
                        model.ivahonorario = Decimal.Round(model.honorario * iva, 2, MidpointRounding.AwayFromZero)
                    Else
                        model.tasahono = 0
                        model.honorario = 0
                        model.ivahonorario = 0
                    End If

                    model.tnafin = 0
                    model.cartera = 0
                    model.pagos = 0

                    model.facturado = 0
                    model.pagoprom = 0
                    model.cheque = 0
                    model.idctabanco = 0
                    model.cuenta = ""
                    model.movto = ""
                    model.pagomatriz = 0
                    model.factinte = 0
                    model.acuse = ""
                    model.costonafin = 0

                    model.folioevento = ""
                    model.fira = 0
                    model.numreccta = 0
                    model.timestart = Date.Now
                    model.vbremote = 0
                    model.vboperador = context.usuarios.Where(Function(x) x.userid = model.userid).Select(Function(x) x.id).SingleOrDefault()
                    model.timeoper = Date.Now
                    model.vbsuper = model.vboperador
                    model.timesuper = Date.Now
                    model.vbfirma1 = 0
                    model.vbfirma2 = 0
                    model.tdevengue = 0
                    model.disperfile = ""
                    model.void = 0
                    model.tasaganafin = 0
                    model.garantnafin = 0
                    model.ivaganafin = 0
                    model.imvfacnafin = 0
                    model.gliquida = 0
                    model.glqreccta = 0
                    model.disperstat = 4
                    model.folio = 0
                    model.cfdi = ""
                    model.dsalida = 0
                    model.int_diario = 0

                    model.totalpagar = model.impanticipado - model.cartera - model.cartera - model.pagos - model.interes - model.honorario - model.ivahonorario

                    context.cesiones.Add(model)
                    context.SaveChanges()
                    respuesta.Ok = True

                Else
                    respuesta.Ok = False
                End If
            Catch e As Exception
                respuesta.Detalle = e.InnerException.InnerException.Message
            End Try

        End Using

        Return respuesta

    End Function


    Public Function GuardardoctoUpdDAL(model As doctos) As Result

        Dim respuesta = New Result(False)

        Using context As New FactorContext
            Try


                Dim contrato = context.contratos.Where(Function(x) x.contrato = model.contrato).SingleOrDefault()
                Dim comprador = context.comprador.Where(Function(x) x.deudor = model.deudor).SingleOrDefault()
                Dim cesion = context.cesiones.Where(Function(x) x.contrato = model.contrato And x.cesion = model.cesion).SingleOrDefault()
                Dim doc = context.doctos.Where(Function(x) x.contrato = model.contrato And x.docto = model.docto).SingleOrDefault()

                
                respuesta.Detalle = ""


                'Validar deudor
                If comprador Is Nothing Then
                    respuesta.Detalle = " <br/> - Deudor no fue especificado"
                End If


                'Validar si existe el documento
                If doc IsNot Nothing Then
                    respuesta.Detalle = " <br/> - Documento existente."
                End If

                Dim doccount = Aggregate a In context.doctos Into Count(a.contrato = model.contrato AndAlso a.cesion = model.cesion)

                If doccount + 1 > cesion.doctos Then
                    respuesta.Detalle = respuesta.Detalle + " <br/>- Excede el número de documentos indicado en la operación."
                End If

                Dim docsum = (From a In context.doctos Where a.contrato = model.contrato AndAlso a.cesion = model.cesion Select a.monto).Sum()

                If docsum IsNot Nothing Then
                    docsum = 0
                End If

                If docsum + model.monto > cesion.importe Then
                    respuesta.Detalle = respuesta.Detalle + "<br/>- Excede el importe indicado en la operación."
                End If

                'validar fechas de vencimiento
                If model.fec_vence > cesion.fec_vence Then
                    respuesta.Detalle = respuesta.Detalle + " <br/>- Fecha de vencimiento excede fecha indicada en la operación."
                End If

                'Validar plazo permitido de los documentos
                Dim plazo As Long = DateDiff("d", cesion.fec_alta, model.fec_vence)


                ' validar la cobertura del seguro
                If comprador IsNot Nothing Then

                    If comprador.seguro = True Then

                        docsum = (From a In context.doctos Join b In context.contratos On a.contrato Equals b.contrato Where a.deudor = model.deudor AndAlso b.producto = 1 Select a.saldo).Sum()
                        If docsum + model.monto > comprador.cobertura Then
                            respuesta.Detalle = " <br/> - Monto excede la cobertura de seguro especificada."
                        End If

                        If plazo > comprador.plazo Then
                            respuesta.Detalle = " <br/> - Plazo excede el permitod por la póliza de seguro."
                        End If

                    End If


                End If



                If respuesta.Detalle = "" Then

                    model.referencia = model.docto
                    model.plaza = ""
                    model.plazacob = 1
                    model.saldo = model.monto
                    model.pagare = ""
                    model.importe = model.monto
                    model.interes = 0
                    model.ivainteres = 0
                    model.descto = 0
                    model.pagos = 0
                    model.hono = 0
                    model.iva = 0
                    model.void = False
                    model.factinte = False
                    model.seguro = comprador.seguro
                    model.idcesion = cesion.idcesion
                    model.int_diario = 0
                    model.dsalida = 0
                    model.excento = False


                    context.doctos.Add(model)
                    context.SaveChanges()
                    respuesta.Ok = True
                Else

                    respuesta.Ok = False

                End If


            Catch e As Exception
                respuesta.Detalle = e.InnerException.InnerException.Message
            End Try

        End Using

        Return respuesta

    End Function


    Public Function GuardarGarantiaWzdUpdDAL(model As garantia) As Result

        Dim respuesta = New Result(False)

        Using context As New FactorContext
            Try

                Dim contrato = context.contratos.Where(Function(x) x.contrato = model.contrato).SingleOrDefault()
                Dim cesion = context.cesiones.Where(Function(x) x.contrato = model.contrato And x.cesion = model.cesion).SingleOrDefault()

                respuesta.Detalle = ""

                If respuesta.Detalle = "" Then

                    'model.referencia = model.docto
                    model.fec_alta = cesion.fec_alta
                    model.valor_ant = model.valor * (model.porcentaje / 100)
                    model.saldo = 0


                    context.garantia.Add(model)
                    context.SaveChanges()
                    respuesta.Ok = True
                Else

                    respuesta.Ok = False

                End If


            Catch e As Exception
                respuesta.Detalle = e.InnerException.InnerException.Message
            End Try

        End Using

        Return respuesta

    End Function


    Function GetCesionNumberDAL(cesion As Integer, contrato As Integer, idtransact As String, ByRef cesion_num As Integer) As Result
        Dim resultado = New Result(False)

        Using context As New FactorContext

            Try
                Dim ces = New cesiones
                If cesion = 0 Then
                    ces = context.cesiones.Where(Function(x) x.idtransact = idtransact).Select(Function(x) x).SingleOrDefault()
                Else
                    ces = context.cesiones.Where(Function(x) x.cesion = cesion And x.contrato = contrato).Select(Function(x) x).SingleOrDefault()
                End If

                cesion_num = 0
                If ces IsNot Nothing Then
                    cesion_num = ces.cesion

                End If
                resultado.Ok = True
            Catch ex As Exception
                resultado.Mensaje = ex.Message
            End Try


        End Using

        Return resultado
    End Function

#End Region


End Class



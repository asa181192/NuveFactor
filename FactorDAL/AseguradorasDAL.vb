Imports FactorEntidades
Imports System.Data.Entity

Public Class AseguradorasDAL

    Function ConsultaAseguradorasDAL(ByRef lista As List(Of aseguradora)) As Result
        Dim result = New Result(False)

        Using context As New FactorContext()

            Try
                lista = (From a In context.aseguradora).ToList()

            Catch ex As Exception

            End Try

        End Using

        Return result
    End Function

    Function DetalleAseguradoraDAL(ByRef aseguradora As aseguradora) As Result
        Dim resultado = New Result(False)
        Dim idaseguradora As Integer
        idaseguradora = aseguradora.idaseguradora

        Using context As New FactorContext()

            aseguradora = (From a In context.aseguradora
                           Where a.idaseguradora = idaseguradora).SingleOrDefault()

            resultado.Ok = True

        End Using

        Return resultado
    End Function

    Function ConsultaPolizasDAL(ByRef lista As List(Of PolizasEntidad)) As Result
        Dim result = New Result(False)

        Using context As New FactorContext()

            Try
                lista = (From a In context.polizas
                         Join b In context.aseguradora On a.idaseguradora Equals b.idaseguradora
                        Select New PolizasEntidad With {.idpoliza = a.idpoliza, .nombre = "(" & a.poliza & ") " & b.nombre}).ToList()
                result.Ok = True

            Catch ex As Exception

            End Try

        End Using


        Return result
    End Function

    Function ConsultaPolizaDAL(idpoliza As Integer, ByRef model As PolizasEntidad) As Result
        Dim result = New Result(False)

        Using context As New FactorContext()

            model = (From a In context.polizas
                   Join b In context.aseguradora On a.idaseguradora Equals b.idaseguradora
                   Where a.idpoliza = idpoliza
                   Select New PolizasEntidad With {
                       .idpoliza = a.idpoliza,
                       .idaseguradora = a.idaseguradora,
                       .poliza = a.poliza,
                       .cancelada = a.cancelada,
                       .moneda = a.moneda,
                       .mvigencia = a.mvigencia,
                       .femision = a.femision,
                       .fvigencia1 = a.fvigencia1,
                       .fvigencia2 = a.fvigencia2,
                       .piva = a.piva,
                       .indemnizacion = a.indemnizacion,
                       .facturacion = a.facturacion,
                       .primaperiodos = a.primaperiodos,
                       .primasubtotal = a.primasubtotal,
                       .primaiva = a.primaiva,
                       .primatotal = a.primatotal,
                       .primapdescuento = a.primapdescuento,
                       .primapagar = a.primapagar,
                       .primaminima = a.primaminima,
                       .gecosto = a.gecosto,
                       .geasegurados = a.geasegurados,
                       .geperiodos = a.geperiodos,
                       .gesubtotal = a.gesubtotal,
                       .geiva = a.geiva,
                       .getotal = a.getotal,
                       .gefprimera = a.gefprimera,
                       .deducible = a.deducible,
                       .archivopdf = a.archivopdf,
                       .nombre = b.nombre,
                       .primaasubtotal = a.primaasubtotal,
                       .primaaiva = a.primaaiva,
                       .primaatotal = a.primaatotal,
                       .primaafprimera = a.primaafprimera}).SingleOrDefault()

            result.Ok = True

        End Using

        Return result
    End Function

    Function GuardarAseguradoraDAL(model As aseguradora) As Result
        Dim result = New Result(False)

        Using context As New FactorContext()

            Try
                If model.idaseguradora > 0 Then
                    'Actualiza
                    Dim x = New aseguradora

                    x = (From a In context.aseguradora
                         Where a.idaseguradora = model.idaseguradora).SingleOrDefault()

                    x.calle = model.calle
                    x.colonia = model.colonia
                    x.cp = model.cp
                    x.email = model.email
                    x.estado = model.estado
                    x.municipio = model.municipio
                    x.noext = model.noext
                    x.noint = model.noint
                    x.nombre = model.nombre
                    x.pais = model.pais
                    x.rfc = model.rfc
                    x.telefono = model.telefono

                    context.SaveChanges()

                Else
                    'inserta
                    context.aseguradora.Add(model)
                    context.SaveChanges()

                End If

                result.Ok = True

            Catch ex As Exception

            End Try


        End Using



        Return result
    End Function

    Function GuardarPolizaDAL(model As PolizasEntidad) As Result
        Dim result = New Result(False)

        Using context As New FactorContext()

            Try
                Dim x = New polizas

                If model.idpoliza > 0 Then
                    'Actualiza

                    x = (From a In context.polizas
                         Where a.idpoliza = model.idpoliza).SingleOrDefault()

                    x.idaseguradora = model.idaseguradora
                    x.poliza = model.poliza
                    x.cancelada = model.cancelada
                    x.moneda = model.moneda
                    x.mvigencia = model.mvigencia
                    x.femision = model.femision
                    x.fvigencia1 = model.fvigencia1
                    x.fvigencia2 = model.fvigencia2
                    x.piva = model.piva
                    x.indemnizacion = model.indemnizacion
                    x.facturacion = model.facturacion
                    x.primasubtotal = model.primasubtotal
                    x.primaiva = model.primaiva
                    x.primatotal = model.primatotal
                    x.primapdescuento = model.primapdescuento
                    x.primapagar = model.primapagar
                    x.primaminima = model.primaminima
                    x.primaperiodos = model.primaperiodos
                    x.primaasubtotal = model.primaasubtotal
                    x.primaaiva = model.primaaiva
                    x.primaatotal = model.primaatotal
                    x.primaafprimera = model.primaafprimera
                    x.gecosto = model.gecosto
                    x.geasegurados = model.geasegurados
                    x.geperiodos = model.geperiodos
                    x.gesubtotal = model.gesubtotal
                    x.geiva = model.geiva
                    x.getotal = model.getotal
                    x.geatotal = model.geatotal
                    x.gefprimera = model.gefprimera
                    x.deducible = model.deducible
                    x.archivopdf = model.archivopdf



                Else
                    'inserta
                    x.idaseguradora = model.idaseguradora
                    x.poliza = model.poliza
                    x.cancelada = model.cancelada
                    x.moneda = model.moneda
                    x.mvigencia = model.mvigencia
                    x.femision = model.femision
                    x.fvigencia1 = model.fvigencia1
                    x.fvigencia2 = model.fvigencia2
                    x.piva = model.piva
                    x.indemnizacion = model.indemnizacion
                    x.facturacion = model.facturacion
                    x.primasubtotal = model.primasubtotal
                    x.primaiva = model.primaiva
                    x.primatotal = model.primatotal
                    x.primapdescuento = model.primapdescuento
                    x.primapagar = model.primapagar
                    x.primaminima = model.primaminima
                    x.primaperiodos = model.primaperiodos
                    x.primaasubtotal = model.primaasubtotal
                    x.primaaiva = model.primaaiva
                    x.primaatotal = model.primaatotal
                    x.primaafprimera = model.primaafprimera
                    x.gecosto = model.gecosto
                    x.geasegurados = model.geasegurados
                    x.geperiodos = model.geperiodos
                    x.gesubtotal = model.gesubtotal
                    x.geiva = model.geiva
                    x.getotal = model.getotal
                    x.geatotal = model.geatotal
                    x.gefprimera = model.gefprimera
                    x.deducible = model.deducible
                    x.archivopdf = model.archivopdf

                    context.polizas.Add(x)

                End If

                context.SaveChanges()
                result.Ok = True

            Catch ex As Exception

            End Try


        End Using



        Return result
    End Function

    Function ConsultaIvaDAL() As Decimal
        Dim iva As Decimal

        Using context As New FactorContext()

            Dim sucursal = (From a In context.sucursal
                   Where a.abrev_suc = "MEX").SingleOrDefault()

            iva = sucursal.iva

        End Using

        Return iva
    End Function

    Function InformePolizaGlobalDAL(idpoliza As String, model As ReportePolizaGlobalEntidad) As Result
        Throw New NotImplementedException
    End Function

End Class

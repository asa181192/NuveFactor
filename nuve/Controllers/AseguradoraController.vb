Imports FactorBAL
Imports FactorEntidades
Imports Nelibur.ObjectMapper

Public Class AseguradoraController
    Inherits System.Web.Mvc.Controller


#Region "Vistas"

    Function Index() As ActionResult
        Dim model As New Helpers.Menu

        model.sMenu = "<div class=""BoxFlex"" id="""" >"
        model.sMenu &= "<div class=""BoxFlexShadow"">"
        model.sMenu &= "<label>Regresar</label>"
        model.sMenu &= "<a href=""../Home/Welcome""> <img src=""../Images/regresar_gris.png""/> </a>"
        model.sMenu &= "</div>"
        model.sMenu &= "</div>"

        model.sMenu &= "<div class=""BoxFlex"" id=""dvflexGlobal"" >"
        model.sMenu &= "<div class=""BoxFlexShadow"">"
        model.sMenu &= "<p>Pólizas Globales</p>"
        model.sMenu &= "</div>"
        model.sMenu &= "</div>"

        model.sMenu &= "<div class=""BoxFlex"" id=""dvflexAseguradoras"" >"
        model.sMenu &= "<div class=""BoxFlexShadow"">"
        model.sMenu &= "<p>Aseguradoras</p>"
        model.sMenu &= "</div>"
        model.sMenu &= "</div>"

        Return View(model)
    End Function

    Public Function Aseguradoras() As ActionResult
        Return View()
    End Function

    Public Function PolizasGlobales() As ActionResult
        Return View()
    End Function

#End Region

#Region "Consultas"

    Public Function ConsultaAseguradoras() As ActionResult
        Dim jresult
        Dim result = New Result(False)
        Dim consulta = New AseguradorasBAL()
        Dim lista = New List(Of aseguradora)

        result = consulta.ConsultaAseguradorasBAL(lista)

        jresult = Json(New With {Key .Results = lista}, JsonRequestBehavior.AllowGet)

        Return jresult
    End Function

    Public Function DetalleAseguradora(idaseguradora As String, tipo As String) As ActionResult
        Dim model = New AseguradoraModels.aseguradora
        Dim consulta = New AseguradorasBAL
        Dim aseguradora = New aseguradora
        Dim resultado = New Result(False)

        If tipo = "1" Then

            aseguradora.idaseguradora = Integer.Parse(idaseguradora)
            resultado = consulta.DetalleAseguradora(aseguradora)

            If resultado.Ok Then
                TinyMapper.Bind(Of aseguradora, AseguradoraModels.aseguradora)()
                model = TinyMapper.Map(Of AseguradoraModels.aseguradora)(aseguradora)

            End If

        Else
            model.calle = ""
            model.colonia = ""
            model.cp = 0
            model.email = ""
            model.email = ""
            model.estado = ""
            model.estado = ""
            model.municipio = ""
            model.noext = ""
            model.noint = ""
            model.nombre = ""
            model.pais = ""
            model.rfc = ""
            model.telefono = ""

        End If

        Return PartialView(model)
    End Function

    Public Function ConsultaPolizasGlobal() As ActionResult
        Dim jresult
        Dim result = New Result(False)
        Dim consulta = New AseguradorasBAL()
        Dim lista = New List(Of PolizasEntidad)

        result = consulta.ConsultaPolizasGlobalBAL(lista)

        jresult = Json(New With {Key .Results = lista}, JsonRequestBehavior.AllowGet)

        Return jresult
    End Function

    Public Function ConsultaPoliza(idpoliza As String, tipo As String) As ActionResult
        Dim consulta = New AseguradorasBAL
        Dim model = New AseguradoraModels.poliza
        Dim poliza = New PolizasEntidad
        Dim resultado = New Result(False)

        model.Cargacontroles()

        resultado = consulta.ConsultaPolizaBAL(Integer.Parse(idpoliza), poliza)

        If tipo <> "1" And poliza Is Nothing Then
            model.idpoliza = 0
            model.idaseguradora = 0
            model.poliza = ""
            model.cancelada = False
            model.moneda = 1
            model.mvigencia = 0
            model.femision = Date.Now.ToShortDateString()
            model.fvigencia1 = Date.Now.ToShortDateString()
            model.fvigencia2 = Date.Now.ToShortDateString()
            model.piva = consulta.ConsultaIvaBAL()
            model.indemnizacion = 0
            model.primaperiodos = 0
            model.primasubtotal = 0
            model.primaiva = 0
            model.primatotal = 0
            model.primapdescuento = 0
            model.primapagar = 0
            model.primaminima = 0
            model.gecosto = 0
            model.geasegurados = 0
            model.geperiodos = 0
            model.gesubtotal = 0
            model.geiva = 0
            model.getotal = 0
            model.geatotal = 0
            model.gefprimera = Date.Now.ToShortDateString()
            model.deducible = 0
            model.archivopdf = ""
            model.primaafprimera = Date.Now.ToShortDateString()
            model.primaatotal = 0

            'model.nombre = ""

        Else
            model.idpoliza = poliza.idpoliza
            model.idaseguradora = poliza.idaseguradora
            model.poliza = poliza.poliza
            model.cancelada = poliza.cancelada
            model.moneda = poliza.moneda
            model.mvigencia = poliza.mvigencia
            model.femision = poliza.femision.ToShortDateString()
            model.fvigencia1 = poliza.fvigencia1.ToShortDateString()
            model.fvigencia2 = poliza.fvigencia2.ToShortDateString()
            model.piva = poliza.piva
            model.indemnizacion = poliza.indemnizacion
            model.facturacion = poliza.facturacion
            model.primaperiodos = poliza.primaperiodos
            model.primasubtotal = poliza.primasubtotal
            model.primaiva = poliza.primaiva
            model.primatotal = poliza.primatotal
            model.primapdescuento = poliza.primapdescuento
            model.primapagar = poliza.primapagar
            model.primaminima = poliza.primaminima
            model.gecosto = poliza.gecosto
            model.geasegurados = poliza.geasegurados
            model.geperiodos = poliza.geperiodos
            model.gesubtotal = poliza.gesubtotal
            model.geiva = poliza.geiva
            model.getotal = poliza.getotal
            model.geatotal = poliza.geatotal
            model.gefprimera = poliza.gefprimera.ToShortDateString()
            model.deducible = poliza.deducible
            model.archivopdf = poliza.archivopdf
            model.nombre = poliza.nombre
            model.primaasubtotal = poliza.primaasubtotal
            model.primaaiva = poliza.primaaiva
            model.primaafprimera = poliza.primaafprimera
            model.primaatotal = poliza.primaatotal

        End If

        Return PartialView(model)
    End Function

    'Public Function InformePolizaGlobal(idpoliza As String) As FileResult
    '    Dim resultado = New Result(False)
    '    Dim consulta = New AseguradorasBAL()
    '    Dim archivo As Byte() = Nothing
    '    Dim extension As String = ""

    '    Dim model = New ReportePolizaGlobalEntidad()


    '    resultado = consulta.InformePolizaGlobalBAL(idpoliza, model)


    '    If resultado.Ok And archivo IsNot Nothing Then


    '    Else


    '    End If

    '    Return(archivo,"","")
    'End Function
    
#End Region

#Region "Transacciones"

    Public Function GuardarAseguradora(modelA As AseguradoraModels.aseguradora) As ActionResult
        Dim resultado
        Dim consulta = New AseguradorasBAL()
        Dim concepto As String
        Dim msgResult As String
        Dim proceso As String = ""

        concepto = IIf(modelA.idaseguradora > 0, " dio de alta ", " editó ")
        msgResult = IIf(modelA.idaseguradora > 0, "Se actualizó la aseguradora correctamente.", "La aseguradora se dio de alta correctamente.")


        TinyMapper.Bind(Of AseguradoraModels, aseguradora)()
        Dim model = TinyMapper.Map(Of aseguradora)(modelA)

        If model IsNot Nothing Then
            resultado = consulta.GuardarAseguradoraBAL(model)
            If resultado IsNot Nothing And resultado.ok Then
                Utility.Monitor(Session("userid"), "Se " & concepto & " la aseguradora " & modelA.nombre)
                resultado.tipo = Enumerador.eTipoTransaccion.eActualizar
                resultado.mensaje = msgResult
                proceso = "1"
            Else

                resultado.mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro {0}" + "tipo de error: {1}", Environment.NewLine, resultado.Detalle)

            End If

        End If

        Return Json(New With {Key .mensaje = resultado.mensaje, .proceso = proceso})
    End Function

    Public Function GuardarPoliza(modelA As AseguradoraModels.poliza) As ActionResult
        Dim resultado = New Result(False)
        Dim consulta = New AseguradorasBAL()
        Dim concepto As String
        Dim proceso As String = ""
        Dim msgResult As String

        concepto = IIf(modelA.idpoliza > 0, "Dio de alta la póliza " & modelA.poliza, "Actualizó la póliza " & modelA.poliza)
        msgResult = IIf(modelA.idpoliza > 0, "Se actualizó la póliza correctamente.", "La póliza se dio de alta correctamente.")

        TinyMapper.Bind(Of AseguradoraModels.poliza, PolizasEntidad)()
        Dim model = TinyMapper.Map(Of PolizasEntidad)(modelA)

        If model IsNot Nothing Then
            resultado = consulta.GuardarPolizaBAL(model)
            If resultado IsNot Nothing And resultado.Ok Then
                Utility.Monitor(Session("userid"), concepto)
                resultado.Mensaje = msgResult
                proceso = "1"
            Else
                resultado.Mensaje = String.Format("Ocurrio un error al tratar de actualizar el registro {0}" + "tipo de error: {1}", Environment.NewLine, resultado.Detalle)
            End If
        End If

        Return Json(New With {Key .mensaje = resultado.Mensaje, .proceso = proceso})
    End Function

#End Region





End Class
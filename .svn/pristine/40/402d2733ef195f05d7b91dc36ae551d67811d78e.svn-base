Imports FactorDAL
Imports FactorEntidades

Public Class AseguradorasBAL

    Function ConsultaAseguradorasBAL(ByRef lista As List(Of aseguradora)) As Result
        Dim consulta = New AseguradorasDAL
        Return consulta.ConsultaAseguradorasDAL(lista)
    End Function

    Function DetalleAseguradora(ByRef aseguradora As aseguradora) As Result
        Dim consulta = New AseguradorasDAL
        Return consulta.DetalleAseguradoraDAL(aseguradora)
    End Function

    Function GuardarAseguradoraBAL(model As aseguradora) As Result
        Dim consulta = New AseguradorasDAL
        Return consulta.GuardarAseguradoraDAL(model)
    End Function

    Function ConsultaPolizasGlobalBAL(ByRef lista As List(Of PolizasEntidad)) As Result
        Dim consulta = New AseguradorasDAL
        Return consulta.ConsultaPolizasDAL(lista)
    End Function

    Function ConsultaPolizaBAL(idpoliza As Integer, ByRef model As PolizasEntidad) As Result
        Dim consulta = New AseguradorasDAL
        Return consulta.ConsultaPolizaDAL(idpoliza, model)
    End Function

    Function GuardarPolizaBAL(ByRef model As PolizasEntidad) As Result
        Dim consulta = New AseguradorasDAL
        Return consulta.GuardarPolizaDAL(model)
    End Function

    Function ConsultaIvaBAL() As Decimal
        Dim consulta = New AseguradorasDAL()
        Return consulta.ConsultaIvaDAL()
    End Function

    Function InformePolizaGlobalBAL(idpoliza As String, ByRef model As ReportePolizaGlobalEntidad) As Result
        Dim consulta = New AseguradorasDAL()
        Return consulta.InformePolizaGlobalDAL(idpoliza, model)
    End Function

End Class

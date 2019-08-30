Imports FactorDAL
Imports FactorEntidades

Public Class DropDownBAL

    Function obtenerBancosBAL(ByRef model As List(Of DropDownEntidad)) As Result

        Dim consulta = New DropDownDAL()
        Return consulta.consultaBancosDAL(model)

    End Function

    Function obtenerCuentasBAL(ByRef model As List(Of DropDownEntidad)) As Result

        Dim consulta = New DropDownDAL()
        Return consulta.consultaCuentasDAL(model)

    End Function

    Function obtenerWebBancosBAL(ByRef lista As List(Of DropDownEntidad)) As Result
        Dim consulta = New DropDownDAL()
        Return consulta.consultarWebBancos(lista)
    End Function

End Class

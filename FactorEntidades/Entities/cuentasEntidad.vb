﻿Public Class cuentasEntidad

    Public Property idctabanco As Integer

    Public Property ctabanco As String

    Public Property ctacontable As String

    Public Property banco As String

    Public Property sucbancaria As String

    Public Property slogan As String

    Public Property sucursal As Integer?

    Public Property cheques As Integer?

    Public Property traspasos As Integer?

    Public Property depositos As Integer?

    Public Property cargos As Integer?

    Public Property inversion As Integer?

    Public Property cancelacion As Integer?

    Public Property fichas As Integer?

    Public Property traspactivo As Boolean

    Public Property cobrado As Decimal?

    Public Property fecha As Date

    Public Property entradas As Decimal?

    Public Property salidas As Decimal?

    Public Property saldo As Decimal?

    Public Property saldoInicial As Decimal?

    Public Property moneda As Integer?

    Public Property banda As String

    Public Property codigoseg As String

    Public Property numbanco As String

    Public Property plazacomp As String

    Public Property nosucur As Integer?

    Public Property interbanco As Boolean

    Public Property impbanda As Boolean

    Public Property fondeaoper As Boolean

    Public Property chequesfora As Boolean

    Public Property idbanco As Integer?

    Public Property exporta As Boolean

    Public Property cancelado As Boolean

    Public Property cancel As String

    Public Property void As Boolean

    Public Property divisa As String

    Function consultarSaldosDAL(idctabanco As Integer, model As cuentasEntidad) As Result
        Throw New NotImplementedException
    End Function




End Class

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class cuentas
    <Key>
    Public Property idctabanco As Integer

    <StringLength(15)>
    Public Property ctabanco As String

    <StringLength(20)>
    Public Property ctacontable As String

    <StringLength(35)>
    Public Property banco As String

    <StringLength(35)>
    Public Property sucbancaria As String

    <StringLength(60)>
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

    <Column(TypeName:="numeric")>
    Public Property cobrado As Decimal?

    Public Property fecha As Date?

    <Column(TypeName:="numeric")>
    Public Property entradas As Decimal?

    <Column(TypeName:="numeric")>
    Public Property salidas As Decimal?

    <Column(TypeName:="numeric")>
    Public Property saldo As Decimal?

    Public Property moneda As Integer?

    <StringLength(40)>
    Public Property banda As String

    <StringLength(3)>
    Public Property codigoseg As String

    <StringLength(3)>
    Public Property numbanco As String

    <StringLength(3)>
    Public Property plazacomp As String

    Public Property nosucur As Integer?

    Public Property interbanco As Boolean

    Public Property impbanda As Boolean

    Public Property fondeaoper As Boolean

    Public Property chequesfora As Boolean

    Public Property idbanco As Integer?

    Public Property exporta As Boolean

    Public Property cancelado As Boolean

    Public Property void As Boolean
End Class

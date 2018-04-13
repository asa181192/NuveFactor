Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("linea")>
Partial Public Class linea
    <Key>
    <Column(Order:=0)>
    <StringLength(28)>
    Public Property id_rec As String

    Public Property clientet24 As Integer?

    Public Property cliente As Integer?

    <StringLength(100)>
    Public Property nombre As String

    Public Property rgolinea As Integer?

    <StringLength(21)>
    Public Property lcredito As String

    Public Property producto As Integer?

    <StringLength(100)>
    Public Property ldescrip As String

    Public Property lglobal As Integer?

    Public Property ccc As Integer?

    Public Property moneda As Integer?

    <Column(TypeName:="numeric")>
    Public Property lmonto As Decimal?

    <Column(TypeName:="numeric")>
    Public Property lutilizado As Decimal?

    <Column(TypeName:="numeric")>
    Public Property ldisponibl As Decimal?

    Public Property lvence As Date?

    <Key>
    <Column(Order:=1)>
    Public Property liquida As Boolean

    Public Property numreccta As Integer?

    <Column(TypeName:="numeric")>
    Public Property porcentaje As Decimal?

    <Key>
    <Column(Order:=2)>
    Public Property void As Boolean

    <Key>
    <Column(Order:=3)>
    Public Property cancelado As Boolean

    Public Property actualiza As Date?

    <StringLength(11)>
    Public Property cuenta As String

    <Column(TypeName:="numeric")>
    Public Property adeudo As Decimal?

    <Column(TypeName:="numeric")>
    Public Property vencida As Decimal?

    <Column(TypeName:="numeric")>
    Public Property garantsdo As Decimal?

    <Column(TypeName:="numeric")>
    Public Property garantutl As Decimal?

    <StringLength(10)>
    Public Property idmultiple As String

    <Column(TypeName:="numeric")>
    Public Property lmultiple As Decimal?
End Class

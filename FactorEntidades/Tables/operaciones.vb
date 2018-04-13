Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class operaciones
    <Key>
    <Column(TypeName:="numeric")>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property idoperacion As Decimal

    Public Property folio As Integer?

    Public Property contrato As Integer?

    Public Property proveedor As Integer?

    Public Property doctos As Integer?

    Public Property fecha As Date?

    <Column(TypeName:="numeric")>
    Public Property totalpagar As Decimal?

    <Column(TypeName:="numeric")>
    Public Property importe As Decimal?

    <Column(TypeName:="numeric")>
    Public Property monto As Decimal?

    <Column(TypeName:="numeric")>
    Public Property descto As Decimal?

    <Column(TypeName:="numeric")>
    Public Property interes As Decimal?

    <Column(TypeName:="numeric")>
    Public Property tasaoper As Decimal?

    <Column(TypeName:="numeric")>
    Public Property honorario As Decimal?

    <Column(TypeName:="numeric")>
    Public Property iva As Decimal?

    <Column(TypeName:="numeric")>
    Public Property tasahono As Decimal?

    <StringLength(15)>
    Public Property cuenta As String

    Public Property fpago As Date?

    Public Property void As Boolean

    <Column(TypeName:="numeric")>
    Public Property ivainteres As Decimal?

    <StringLength(30)>
    Public Property cfdi As String

    Public Property notifica As Boolean

    Public Property notiauto As Date?

    Public Property notifolio As Integer?

    <StringLength(20)>
    Public Property transfer As String

    <StringLength(60)>
    Public Property errtransfer As String

    Public Property intcargo As Integer?

    Public Property honcargo As Integer?

    <StringLength(11)>
    Public Property ctafondeo As String

    <Column(TypeName:="numeric")>
    Public Property gnafin As Decimal?

    <Column(TypeName:="numeric")>
    Public Property servnafin As Decimal?

    <Column(TypeName:="numeric")>
    Public Property ivaserv As Decimal?

    <Column(TypeName:="numeric")>
    Public Property adeudos As Decimal?

    <Column(TypeName:="text")>
    Public Property wbresponse As String

    <Column(TypeName:="text")>
    Public Property datasent As String

    <Column(TypeName:="timestamp")>
    <MaxLength(8)>
    <Timestamp>
    Public Property timestamp_column As Byte()
End Class

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class ipolizas
    <Key>
    <Column(Order:=0)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property idipoliza As Integer

    Public Property idpoliza As Integer?

    <StringLength(20)>
    Public Property poliza As String

    <Key>
    <Column(Order:=1)>
    Public Property cancelado As Boolean

    Public Property moneda As Integer?

    Public Property identidad As Integer?

    Public Property id As Integer?

    <StringLength(100)>
    Public Property contratos As String

    Public Property contrato As Integer?

    <Column(TypeName:="numeric")>
    Public Property cobertura As Decimal?

    Public Property plazo As Integer?

    Public Property fvigencia1 As Date?

    Public Property fvigencia2 As Date?

    <Column(TypeName:="numeric")>
    Public Property piva As Decimal?

    <Column(TypeName:="numeric")>
    Public Property primatasa As Decimal?

    <Column(TypeName:="numeric")>
    Public Property primasubtotal As Decimal?

    <Column(TypeName:="numeric")>
    Public Property primaiva As Decimal?

    <Column(TypeName:="numeric")>
    Public Property primatotal As Decimal?

    <Key>
    <Column(Order:=2)>
    Public Property cswpaga As Boolean

    Public Property cidentidad As Integer?

    Public Property cid As Integer?

    Public Property ccontrato As Integer?

    Public Property cforma As Integer?

    Public Property cperiodos As Integer?

    Public Property ccperiodos As Integer?

    Public Property cexigibilidad As Integer?

    <Column(TypeName:="numeric")>
    Public Property csubtotal As Decimal?

    <Column(TypeName:="numeric")>
    Public Property civa As Decimal?

    <Column(TypeName:="numeric")>
    Public Property ctotal As Decimal?

    Public Property cfprimera As Date?

    <Column(TypeName:="text")>
    Public Property comentarios As String

    <Key>
    <Column(Order:=3, TypeName:="timestamp")>
    <MaxLength(8)>
    <Timestamp>
    Public Property timestamp_column As Byte()
End Class

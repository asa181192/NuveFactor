Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("comprador")>
Partial Public Class comprador
    Public Property sucursal As Integer?

    Public Property fec_alta As Date?

    <Key>
    Public Property deudor As Integer

    <StringLength(100)>
    Public Property nombre As String

    <StringLength(50)>
    Public Property domicilio As String

    <StringLength(50)>
    Public Property colonia As String

    <StringLength(50)>
    Public Property municipio As String

    <StringLength(50)>
    Public Property estado As String

    <StringLength(50)>
    Public Property telefono As String

    Public Property cp As Integer?

    Public Property revision As Integer?

    Public Property cobranza As Integer?

    <StringLength(50)>
    Public Property responsable As String

    <StringLength(3)>
    Public Property plaza As String

    Public Property plazacob As Integer?

    <StringLength(50)>
    Public Property giro As String

    <StringLength(15)>
    Public Property rfc As String

    <StringLength(20)>
    Public Property curp As String

    Public Property elaborado As Boolean?

    Public Property firmado As Boolean?

    Public Property rectificado As Boolean?

    Public Property historia As Boolean?

    <Column(TypeName:="text")>
    Public Property notas As String

    Public Property regiva As Integer?

    <Column(TypeName:="numeric")>
    Public Property cobertura As Decimal?

    Public Property plazo As Integer?

    Public Property seguro As Boolean?

    Public Property endoso As Date?

    <StringLength(10)>
    Public Property idmapfre As String

    Public Property void As Boolean?

    <StringLength(50)>
    Public Property calle As String

    <StringLength(15)>
    Public Property noext As String

    <StringLength(15)>
    Public Property noint As String

    <StringLength(50)>
    Public Property email As String

    <Column(TypeName:="numeric")>
    Public Property enviafact As Decimal?

    Public Property fec_update As Date?

    Public Property idipoliza As Integer?

    <StringLength(36)>
    Public Property idtransact As String

    <Column(TypeName:="timestamp")>
    <MaxLength(8)>
    <Timestamp>
    Public Property timestamp_column As Byte()
End Class

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class clientes
    Public Property sucursal As Integer?

    <Key>
    Public Property cliente As Integer

    Public Property pfisica As Boolean?

    Public Property actempres As Boolean?

    <StringLength(100)>
    Public Property nombre As String

    <Column(TypeName:="text")>
    Public Property n As String

    <Column(TypeName:="text")>
    Public Property s As String

    <Column(TypeName:="text")>
    Public Property p As String

    <Column(TypeName:="text")>
    Public Property m As String

    <StringLength(15)>
    Public Property rfc As String

    <StringLength(20)>
    Public Property curp As String

    <StringLength(50)>
    Public Property domicilio As String

    <StringLength(50)>
    Public Property colonia As String

    <StringLength(50)>
    Public Property municipio As String

    <StringLength(50)>
    Public Property estado As String

    Public Property cveedo As Integer?

    Public Property cp As Integer?

    <StringLength(50)>
    Public Property telefono As String

    Public Property promotor As Integer?

    Public Property sectorfina As Integer?

    Public Property cvecd As Integer?

    Public Property cvegiro As Integer?

    Public Property fec_alta As Date?

    Public Property ac_numnot As Integer?

    <StringLength(40)>
    Public Property ac_nombre As String

    Public Property ac_escrit As Integer?

    Public Property ac_fecha As Date?

    <StringLength(40)>
    Public Property ac_localid As String

    <StringLength(10)>
    Public Property ac_numero As String

    <StringLength(10)>
    Public Property ac_folio As String

    <StringLength(10)>
    Public Property ac_libro As String

    <StringLength(10)>
    Public Property ac_auxilia As String

    <StringLength(10)>
    Public Property ac_volumen As String

    Public Property ac_fechare As Date?

    <StringLength(40)>
    Public Property ac_actaloc As String

    Public Property grupoemp As Boolean?

    Public Property clave As Integer?

    <StringLength(50)>
    Public Property fenlace As String

    <StringLength(20)>
    Public Property puesto As String

    Public Property seconomico As Integer?

    <StringLength(10)>
    Public Property password As String

    Public Property sif As Boolean?

    <Column(TypeName:="text")>
    Public Property email As String

    <Column(TypeName:="numeric")>
    Public Property sirac As Decimal?

    Public Property regiva As Integer?

    <Column(TypeName:="text")>
    Public Property path_exped As String

    <StringLength(50)>
    Public Property actividad As String

    Public Property clasifica As Integer?

    Public Property politica As Boolean?

    Public Property empleados As Integer?

    Public Property dataexchan As Boolean?

    <StringLength(50)>
    Public Property inbox As String

    <StringLength(50)>
    Public Property outbox As String

    <StringLength(50)>
    Public Property loaded As String

    <StringLength(15)>
    Public Property filenaming As String

    Public Property autoriza As Boolean?

    <Column(TypeName:="numeric")>
    Public Property epo As Decimal?

    <Column(TypeName:="numeric")>
    Public Property calcliente As Decimal?

    Public Property gpoecono As Integer?

    Public Property void As Boolean?

    Public Property promprod As Integer?

    <StringLength(50)>
    Public Property calle As String

    <StringLength(15)>
    Public Property noext As String

    <StringLength(15)>
    Public Property noint As String

    Public Property fec_update As Date?

    <Column(TypeName:="numeric")>
    Public Property enviafact As Decimal?

    <Column(TypeName:="numeric")>
    Public Property riesgo As Decimal?

    Public Property rgpo As Boolean?

    <Column(TypeName:="numeric")>
    Public Property riesgogpo As Decimal?

    Public Property voboreg As Boolean?

    Public Property vobo As Boolean?

    <Column(TypeName:="numeric")>
    Public Property repeco As Decimal?

    <Column(TypeName:="numeric")>
    Public Property clientet24 As Decimal?

    <StringLength(100)>
    Public Property nombret24 As String

    Public Property idrelevant As Integer?

    Public Property idrelacion As Integer?

    Public Property rgo_indust As Integer?

    Public Property rgo_finan As Integer?

    Public Property exp_pago As Integer?

    <StringLength(8)>
    Public Property consolida As String

    Public Property acreditado As Integer?

    <Column(TypeName:="numeric")>
    Public Property fira_idacr As Decimal?

    <StringLength(12)>
    Public Property idlocalidad As String

    <StringLength(3)>
    Public Property pjuridica As String

    <Column(TypeName:="numeric")>
    Public Property ingresos As Decimal?

    <StringLength(36)>
    Public Property idtransact As String

    <Column(TypeName:="timestamp")>
    <MaxLength(8)>
    <Timestamp>
    Public Property timestamp_column As Byte()
End Class

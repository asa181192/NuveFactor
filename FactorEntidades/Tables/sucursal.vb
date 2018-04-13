Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("sucursal")>
Partial Public Class sucursal
    <Key>
    <Column("sucursal")>
    Public Property sucursal1 As Integer

    <StringLength(2)>
    Public Property cvesuc As String

    <StringLength(3)>
    Public Property abrev_suc As String

    <StringLength(20)>
    Public Property nombre As String

    <StringLength(50)>
    Public Property domicilio As String

    <StringLength(50)>
    Public Property colonia As String

    <StringLength(50)>
    Public Property municipio As String

    <StringLength(50)>
    Public Property estado As String

    Public Property cp As Integer?

    Public Property cvelocal As Integer?

    <StringLength(40)>
    Public Property telefono As String

    <StringLength(100)>
    Public Property apoderado1 As String

    <StringLength(100)>
    Public Property apoderado2 As String

    <StringLength(100)>
    Public Property testigo1 As String

    <StringLength(100)>
    Public Property testigo2 As String

    Public Property u_contrato As Integer?

    Public Property u_cliente As Integer?

    Public Property u_deudor As Integer?

    Public Property u_provee As Integer?

    <StringLength(40)>
    Public Property h_in As String

    <StringLength(40)>
    Public Property h_out As String

    <StringLength(40)>
    Public Property h_loaded As String

    <StringLength(40)>
    Public Property h_sent As String

    <Column(TypeName:="numeric")>
    Public Property iva As Decimal?

    Public Property regional As Integer?

    Public Property void As Boolean
End Class

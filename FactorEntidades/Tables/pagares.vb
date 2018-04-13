Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class pagares
    <Key>
    <Column(TypeName:="numeric")>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property idpagare As Decimal

    Public Property deudor As Integer?

    Public Property contrato As Integer?

    <StringLength(20)>
    Public Property pagare As String

    <StringLength(20)>
    Public Property docto As String

    <StringLength(20)>
    Public Property referencia As String

    Public Property fec_vence As Date?

    <Column(TypeName:="numeric")>
    Public Property monto As Decimal?

    Public Property entrega As Date?

    Public Property importado As Boolean?

    Public Property basket As Boolean?

    Public Property autoriza As Date?

    Public Property envio As Integer?

    Public Property folioauto As Integer?

    <StringLength(20)>
    Public Property refe2 As String

    <StringLength(20)>
    Public Property refe3 As String

    Public Property void As Boolean?

    Public Property timefondeo As Date?

    <StringLength(30)>
    Public Property disperfile As String

    Public Property disperstat As Integer?
End Class

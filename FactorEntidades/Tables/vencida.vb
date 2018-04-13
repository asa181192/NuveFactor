Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("vencida")>
Partial Public Class vencida
    Public Property contrato As Integer?

    Public Property fec_alta As Date?

    Public Property fec_vence As Date?

    <Column("vencida")>
    Public Property vencida1 As Date?

    Public Property deudor As Integer?

    <StringLength(15)>
    Public Property docto As String

    <Column(TypeName:="money")>
    Public Property saldo As Decimal?

    Public Property status As Integer?

    <Key>
    Public Property void As Boolean

    Public Property iddocto As Integer?
End Class

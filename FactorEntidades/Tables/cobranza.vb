Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("cobranza")>
Partial Public Class cobranza
  <Key>
  <Column(Order:=0)>
  <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
  Public Property idcobranza As Integer

  Public Property fecha As Date?

  <Column(TypeName:="numeric")>
  Public Property iddocto As Decimal?

  Public Property contrato As Integer?

  Public Property cesion As Integer?

	<StringLength(20)>
  Public Property pagare As String

	<StringLength(20)>
  Public Property docto As String

  <Column(TypeName:="numeric")>
  Public Property importe As Decimal?

  <Column(TypeName:="numeric")>
  Public Property descto As Decimal?

  <Column(TypeName:="numeric")>
  Public Property neto As Decimal?

  <Column(TypeName:="numeric")>
  Public Property bonifica As Decimal?

  Public Property deudor As Integer?

  <Column(TypeName:="numeric")>
  Public Property saldoanterior As Decimal?

  <Column("cobranza")>
  Public Property cobranza1 As Integer?

  Public Property afectado As Boolean

  Public Property cancelado As Boolean

  Public Property cv As Boolean

  Public Property void As Boolean
End Class

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
  <Serializable()> _
  <DataContractAttribute()> _
  Public Class promotorcontratos_Result
    <DataMemberAttribute()> _
    Public Property oficina() As Decimal
    <DataMemberAttribute()> _
    Public Property linea() As Integer
    <DataMemberAttribute()> _
    Public Property contrato() As String
    <DataMemberAttribute()> _
    Public Property nombre() As String
    <DataMemberAttribute()> _
    Public Property monto_financiado() As Decimal
    <DataMemberAttribute()> _
    Public Property plazo() As Integer
    <DataMemberAttribute()> _
    Public Property fec_inic() As String
    <DataMemberAttribute()> _
    Public Property pcompgda() As Boolean
    <DataMemberAttribute()> _
    Public Property msgcomision() As String
    <DataMemberAttribute()> _
    Public Property comision() As Decimal
    <DataMemberAttribute()> _
    Public Property valor_del_bien() As String
    <DataMemberAttribute()> _
    Public Property seguro() As String
    <DataMemberAttribute()> _
    Public Property paganti() As String
    <DataMemberAttribute()> _
    Public Property pagdife() As String
  End Class
End Namespace
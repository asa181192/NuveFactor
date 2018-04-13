Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
  <Serializable()> _
  <DataContractAttribute()> _
  Partial Public Class sp_AdeudoClientesXPromotor_Result
    <DataMemberAttribute()> _
    Public Property cliente() As Decimal
    <DataMemberAttribute()> _
    Public Property nombre() As String
    <DataMemberAttribute()> _
    Public Property cltedesde() As Date
    <DataMemberAttribute()> _
    Public Property linea() As Integer
    <DataMemberAttribute()> _
    Public Property estado() As Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property fec_canc() As Date
    <DataMemberAttribute()> _
    Public Property tipo() As String
    <DataMemberAttribute()> _
    Public Property folio() As String
    <DataMemberAttribute()> _
    Public Property fecven() As Date
    <DataMemberAttribute()> _
    Public Property atraso() As Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property adeudo() As Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property moratorios() As Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property congelado() As Date
  End Class
End Namespace
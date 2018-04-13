Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
  <Serializable()> _
  <DataContractAttribute()> _
  Partial Public Class sp_rpt_colocxm_Result
    <DataMemberAttribute()> _
    Public Property codigo() As String
    <DataMemberAttribute()> _
    Public Property nombre() As String
    <DataMemberAttribute()> _
    Public Property valor_fin() As Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property valor_com() As Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property total() As Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property comtotal() As Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property totxinternos() As Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property comtotxint() As Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property totxexternos() As Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property comtotxext() As Nullable(Of Decimal)
  End Class
End Namespace
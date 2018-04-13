Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
  <Serializable()> _
  <DataContractAttribute()> _
  Partial Public Class sp_creditosxcliente_Result
    <DataMemberAttribute()> _
    Public Property oficina As System.Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property cliente As System.Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property credito As System.Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property arrendamiento As String
    <DataMemberAttribute()> _
    Public Property solicitado As System.Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property autorizado As System.Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property ejercido As System.Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property disponible As System.Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property fecauto As System.Nullable(Of Date)
    <DataMemberAttribute()> _
    Public Property vigencia As System.Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property fec_ven As System.Nullable(Of Date)
    <DataMemberAttribute()> _
    Public Property tasa As System.Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property margen As System.Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property pcomiape As System.Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property popccomp As System.Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property pro_comi As System.Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property salinsan As System.Nullable(Of Decimal)
  End Class
End Namespace
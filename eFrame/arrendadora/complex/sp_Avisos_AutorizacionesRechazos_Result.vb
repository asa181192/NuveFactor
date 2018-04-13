Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
  <Serializable()> _
  <DataContractAttribute()> _
  Partial Public Class sp_Avisos_AutorizacionesRechazos_Result
    <DataMemberAttribute()> _
    Public Property descripcion() As String
    <DataMemberAttribute()> _
    Public Property documento() As String
    <DataMemberAttribute()> _
    Public Property oficina() As System.Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property folio() As System.Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property cliente() As System.Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property nombre() As String
    <DataMemberAttribute()> _
    Public Property fecha() As System.Nullable(Of Date)
    <DataMemberAttribute()> _
    Public Property tipo() As String
    <DataMemberAttribute()> _
    Public Property corto() As String
  End Class
End Namespace
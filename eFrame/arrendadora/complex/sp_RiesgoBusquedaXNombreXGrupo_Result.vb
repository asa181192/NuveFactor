Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
  <Serializable()> _
  <DataContractAttribute()> _
  Partial Public Class sp_RiesgoBusquedaXNombreXGrupo_Result
    <DataMemberAttribute()> _
    Public Property grupo() As Decimal
    <DataMemberAttribute()> _
    Public Property nombre() As String
    <DataMemberAttribute()> _
    Public Property domicilio() As String
    <DataMemberAttribute()> _
    Public Property colonia() As String
    <DataMemberAttribute()> _
    Public Property municipio() As String
    <DataMemberAttribute()> _
    Public Property estado() As String
    <DataMemberAttribute()> _
    Public Property cp() As Decimal
    <DataMemberAttribute()> _
    Public Property tels() As String
    <DataMemberAttribute()> _
    Public Property socios() As String
    <DataMemberAttribute()> _
    Public Property actividad() As String
    <DataMemberAttribute()> _
    Public Property cltedesde() As Date
    <DataMemberAttribute()> _
    Public Property void() As Boolean
    <DataMemberAttribute()> _
    Public Property oficina() As Nullable(Of Integer)
  End Class
End Namespace
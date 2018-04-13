Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
  <Serializable()> _
  <DataContractAttribute()> _
  Partial Public Class sp_PromotoresBusquedaXNombre_Result
    <DataMemberAttribute()> _
    Public Property promotor() As Integer
    <DataMemberAttribute()> _
    Public Property nombre() As String
    <DataMemberAttribute()> _
    Public Property telefono() As String
    <DataMemberAttribute()> _
    Public Property rfc() As String
    <DataMemberAttribute()> _
    Public Property domicilio() As String
    <DataMemberAttribute()> _
    Public Property colonia() As String
    <DataMemberAttribute()> _
    Public Property municipio() As String
    <DataMemberAttribute()> _
    Public Property estado() As String
    <DataMemberAttribute()> _
    Public Property cp() As Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property id_regi() As Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property name() As String
    <DataMemberAttribute()> _
    Public Property id_segm() As Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property saldoinsoluto() As Decimal
    <DataMemberAttribute()> _
    Public Property curp() As String
    <DataMemberAttribute()> _
    Public Property codigo() As String
    <DataMemberAttribute()> _
    Public Property region() As String
    <DataMemberAttribute()> _
    Public Property segmento() As String
    <DataMemberAttribute()> _
    Public Property oficinaid() As Integer
    <DataMemberAttribute()> _
    Public Property activo() As Boolean
  End Class
End Namespace
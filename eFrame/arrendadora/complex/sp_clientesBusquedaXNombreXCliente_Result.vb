Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
  <Serializable()> _
  <DataContractAttribute()> _
  Partial Public Class sp_clientesBusquedaXNombreXCliente_Result
    <DataMemberAttribute()> _
     Public Property nombre As String
    <DataMemberAttribute()> _
    Public Property cliente As Decimal
    <DataMemberAttribute()> _
    Public Property riesgo As Decimal
    <DataMemberAttribute()> _
    Public Property rfc As String
    <DataMemberAttribute()> _
    Public Property domicilio As String
    <DataMemberAttribute()> _
    Public Property colonia As String
    <DataMemberAttribute()> _
    Public Property cp As Integer
    <DataMemberAttribute()> _
    Public Property municipio As String
    <DataMemberAttribute()> _
    Public Property estado As String
    <DataMemberAttribute()> _
    Public Property telefono As String
    <DataMemberAttribute()> _
    Public Property email As String
    <DataMemberAttribute()> _
    Public Property promotor As String
    <DataMemberAttribute()> _
    Public Property cltedesde As Date
    <DataMemberAttribute()> _
    Public Property nbrclientecs As System.Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property region As String
    <DataMemberAttribute()> _
    Public Property segmento As String
    <DataMemberAttribute()> _
    Public Property oficina As String
    <DataMemberAttribute()> _
    Public Property saldoinsoluto As Decimal
    <DataMemberAttribute()> _
    Public Property curp As String
    <DataMemberAttribute()> _
    Public Property riesgoNombre As String
    <DataMemberAttribute()> _
    Public Property IdPromotor As Integer
    <DataMemberAttribute()> _
    Public Property pfisica As Boolean
    <DataMemberAttribute()> _
    Public Property idOficinaPromotor As Integer
    <DataMemberAttribute()> _
    Public Property origen As Decimal
  End Class
End Namespace
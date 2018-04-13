Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
  <Serializable()> _
  <DataContractAttribute()> _
  Public Class promotorclientes_Result
    <DataMemberAttribute()> _
    Public Property id_regi() As Decimal
    <DataMemberAttribute()> _
    Public Property regional() As String
    <DataMemberAttribute()> _
    Public Property id_segm() As Decimal
    <DataMemberAttribute()> _
    Public Property segmento() As String
    <DataMemberAttribute()> _
    Public Property origen() As Decimal
    <DataMemberAttribute()> _
    Public Property oficina() As String
    <DataMemberAttribute()> _
    Public Property cliente() As Decimal
    <DataMemberAttribute()> _
    Public Property nombre() As String
    <DataMemberAttribute()> _
    Public Property fec_alta() As String
    <DataMemberAttribute()> _
    Public Property telefono() As String
  End Class
End Namespace
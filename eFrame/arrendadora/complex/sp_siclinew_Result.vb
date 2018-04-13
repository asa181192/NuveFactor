Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
  <Serializable()> _
  <DataContractAttribute()> _
  Partial Public Class sp_siclinew_Result
    <DataMemberAttribute()> _
    Public Property SICLINEWARR() As Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property INDREFINANARR() As Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property FECHAPRESTANTIGA() As Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property NUMPRODACTIVOA() As Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property DIASDEIMPAGOM01A() As Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property DIASDEIMPAGOM02A() As Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property DIASDEIMPAGOM03A() As Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property DIASDEIMPAGOM04A() As Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property DIASDEIMPAGOM05A() As Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property DIASDEIMPAGOM06A() As Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property PSIMPPAV12MARR() As Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property SDODISPARR() As Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property PEIMPINICONCARR() As Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property FECHAALTAARR() As Nullable(Of Integer)
  End Class
End Namespace
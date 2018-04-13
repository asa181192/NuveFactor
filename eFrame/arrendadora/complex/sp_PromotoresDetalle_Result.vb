Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
  <Serializable()> _
  <DataContractAttribute()> _
  Partial Public Class sp_PromotoresDetalle_Result
    <DataMemberAttribute()> _
    Public Property promotorid() As Integer
    <DataMemberAttribute()> _
    Public Property promotor() As String
    <DataMemberAttribute()> _
    Public Property regionalid() As Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property regional() As String
    <DataMemberAttribute()> _
    Public Property segmentoid() As Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property segmento() As String
  End Class
End Namespace
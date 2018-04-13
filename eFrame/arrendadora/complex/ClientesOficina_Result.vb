Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
  <Serializable()> _
  <DataContractAttribute()> _
  Public Class ClientesOficina_Result
    <DataMemberAttribute()> _
    Public Property origen() As Decimal
    <DataMemberAttribute()> _
    Public Property cliente() As Decimal
    <DataMemberAttribute()> _
    Public Property nombre() As String
    <DataMemberAttribute()> _
    Public Property riesgo() As Decimal
    <DataMemberAttribute()> _
    Public Property oficina() As String
  End Class
End Namespace
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
  <Serializable()> _
  <DataContractAttribute()> _
  Public Class personalidad_accionista
    <DataMemberAttribute()> _
    Public Property cliente() As Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property rfc() As String
    <DataMemberAttribute()> _
    Public Property nombre() As String
    <DataMemberAttribute()> _
    Public Property porcentaje() As Nullable(Of Decimal)
  End Class
End Namespace

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
  <Serializable()> _
  <DataContractAttribute()> _
  Public Class ClienteporNombreClienteRFC_Result
    <DataMemberAttribute()> _
    Public Property nom() As String
    <DataMemberAttribute()> _
    Public Property nombre() As String
    <DataMemberAttribute()> _
    Public Property cliente() As Decimal
    <DataMemberAttribute()> _
    Public Property rfc() As String
    <DataMemberAttribute()> _
    Public Property pfisica() As Boolean
  End Class
End Namespace
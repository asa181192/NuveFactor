Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
  <Serializable()> _
  <DataContractAttribute()> _
  Public Class municipio
    <DataMemberAttribute()> _
    Public Property idmunicipio() As Integer
    <DataMemberAttribute()> _
    Public Property municipio() As String
  End Class
End Namespace
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
  <Serializable()> _
  <DataContractAttribute()> _
  Public Class estado
    <DataMemberAttribute()> _
    Public Property idestado() As Integer
    <DataMemberAttribute()> _
    Public Property estado() As String
  End Class
End Namespace
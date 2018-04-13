Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
  <Serializable()> _
  <DataContractAttribute()> _
  Public Class GrupoNombre_Result
    <DataMemberAttribute()> _
    Public Property grupo() As Decimal
    <DataMemberAttribute()> _
    Public Property nombre() As String
  End Class
End Namespace
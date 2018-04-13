Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
  <Serializable()> _
  <DataContractAttribute()> _
  Public Class sepomexbyCodigo_Result
    <DataMemberAttribute()> _
    Public Property id_unico() As String
    <DataMemberAttribute()> _
    Public Property d_asenta() As String
    <DataMemberAttribute()> _
    Public Property D_mnpio() As String
    <DataMemberAttribute()> _
    Public Property d_estado() As String
  End Class
End Namespace
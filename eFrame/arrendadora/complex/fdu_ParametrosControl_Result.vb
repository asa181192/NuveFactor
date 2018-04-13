Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
  <Serializable()> _
  <DataContractAttribute()> _
  Partial Public Class fdu_ParametrosControl_Result
    <DataMemberAttribute()> _
    Public Property nombre() As String
    <DataMemberAttribute()> _
    Public Property valor() As String
  End Class
End Namespace
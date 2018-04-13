Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
  <Serializable()> _
  <DataContractAttribute()> _
  Public Class sp_selClientesGruporiesgo_Result
    <DataMemberAttribute()> _
   Public Property cliente As Decimal
    <DataMemberAttribute()> _
   Public Property nombre As String
    <DataMemberAttribute()> _
   Public Property saldo As Nullable(Of Decimal)
  End Class
End Namespace
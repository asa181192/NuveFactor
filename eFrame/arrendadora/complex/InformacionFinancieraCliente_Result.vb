Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
  <Serializable()> _
  <DataContractAttribute()> _
  Public Class InformacionFinancieraCliente_Result
    <DataMemberAttribute()> _
   Public Property fecha_info() As DateTime
    <DataMemberAttribute()> _
   Public Property cliente() As Double
    <DataMemberAttribute()> _
   Public Property activo() As Double
    <DataMemberAttribute()> _
   Public Property pasivo() As Double
    <DataMemberAttribute()> _
   Public Property capital() As Double
    <DataMemberAttribute()> _
   Public Property ingresos() As Double
    <DataMemberAttribute()> _
   Public Property utilidad_neta() As Double
  End Class
End Namespace
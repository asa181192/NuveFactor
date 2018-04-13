Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
  <Serializable()> _
  <DataContractAttribute()> _
  Public Class sp_clientes_resumen_Result
    <DataMemberAttribute()> _
    Public Property oficina As Decimal
    <DataMemberAttribute()> _
    Public Property nomoficina As String
    <DataMemberAttribute()> _
    Public Property cliente As Decimal
    <DataMemberAttribute()> _
    Public Property nomcliente As String
    <DataMemberAttribute()> _
    Public Property rfc As String
    <DataMemberAttribute()> _
    Public Property cltedesde As Date
    <DataMemberAttribute()> _
    Public Property numemp As Decimal
    <DataMemberAttribute()> _
    Public Property credito As Integer
    <DataMemberAttribute()> _
    Public Property solicitado As Integer
    <DataMemberAttribute()> _
    Public Property autorizado As Integer
    <DataMemberAttribute()> _
    Public Property ejercido As Integer
    <DataMemberAttribute()> _
    Public Property plazo As Integer
    <DataMemberAttribute()> _
    Public Property tasa As Integer
    <DataMemberAttribute()> _
    Public Property margen As Integer
    <DataMemberAttribute()> _
    Public Property fecalta As String
    <DataMemberAttribute()> _
    Public Property vigencia As Integer
    <DataMemberAttribute()> _
    Public Property avales As String
    <DataMemberAttribute()> _
    Public Property bnc_reporte As System.Nullable(Of Date)
    <DataMemberAttribute()> _
    Public Property modalidadnom As String
    <DataMemberAttribute()> _
    Public Property promotor As String
    <DataMemberAttribute()> _
    Public Property nopagos As System.Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property nopagosRM As System.Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property nopagosLi As System.Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property nopagosAb As System.Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property dias As System.Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property montorentas As System.Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property montoliquida As System.Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property montoabonos As System.Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property aval1 As Integer
    <DataMemberAttribute()> _
    Public Property aval2 As Integer
    <DataMemberAttribute()> _
    Public Property aval3 As Integer
    <DataMemberAttribute()> _
    Public Property aval4 As Integer
    <DataMemberAttribute()> _
    Public Property aval5 As Integer
    <DataMemberAttribute()> _
    Public Property avalnom1 As String
    <DataMemberAttribute()> _
    Public Property avalnom2 As String
    <DataMemberAttribute()> _
    Public Property avalnom3 As String
    <DataMemberAttribute()> _
    Public Property avalnom4 As String
    <DataMemberAttribute()> _
    Public Property avalnom5 As String
    <DataMemberAttribute()> _
    Public Property pmcltevig As System.Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property pfcltevig As System.Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property pmavalvig1 As Integer
    <DataMemberAttribute()> _
    Public Property pmavalvig2 As Integer
    <DataMemberAttribute()> _
    Public Property pmavalvig3 As Integer
    <DataMemberAttribute()> _
    Public Property pmavalvig4 As Integer
    <DataMemberAttribute()> _
    Public Property pmavalvig5 As Integer
    <DataMemberAttribute()> _
    Public Property pfavalvig1 As Integer
    <DataMemberAttribute()> _
    Public Property pfavalvig2 As Integer
    <DataMemberAttribute()> _
    Public Property pfavalvig3 As Integer
    <DataMemberAttribute()> _
    Public Property pfavalvig4 As Integer
    <DataMemberAttribute()> _
    Public Property pfavalvig5 As Integer
    <DataMemberAttribute()> _
    Public Property pmcltevenc As System.Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property pfcltevenc As System.Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property pmavalvenc1 As Integer
    <DataMemberAttribute()> _
    Public Property pmavalvenc2 As Integer
    <DataMemberAttribute()> _
    Public Property pmavalvenc3 As Integer
    <DataMemberAttribute()> _
    Public Property pmavalvenc4 As Integer
    <DataMemberAttribute()> _
    Public Property pmavalvenc5 As Integer
    <DataMemberAttribute()> _
    Public Property pfavalvenc1 As Integer
    <DataMemberAttribute()> _
    Public Property pfavalvenc2 As Integer
    <DataMemberAttribute()> _
    Public Property pfavalvenc3 As Integer
    <DataMemberAttribute()> _
    Public Property pfavalvenc4 As Integer
    <DataMemberAttribute()> _
    Public Property pfavalvenc5 As Integer
    <DataMemberAttribute()> _
    Public Property maxfecbnc As System.Nullable(Of Date)
    <DataMemberAttribute()> _
    Public Property hist15d As System.Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property hist30d As System.Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property hist60d As System.Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property hist61d As System.Nullable(Of Decimal)
    <DataMemberAttribute()> _
    Public Property nohist15d As System.Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property nohist30d As System.Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property nohist60d As System.Nullable(Of Integer)
    <DataMemberAttribute()> _
    Public Property nohist61d As System.Nullable(Of Integer)
  End Class
End Namespace
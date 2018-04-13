Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Reflection
Imports System.Runtime.Serialization

Namespace arrendadora
#Region "PARA EXPORTAR DBF (INTERFASE CONTABLE)"
  <Serializable()> _
  <DataContractAttribute()> _
  Public Class interfas_contable

    <DataMemberAttribute()> _
    <Column("cuenta", Order:=1)> _
    <DataType("char (20) NULL")> _
    <StringLength(20)> _
    Public Property cuenta() As String

    <DataMemberAttribute()> _
    <Column("concepto", Order:=2)> _
    <DataType("char (50) NULL")> _
    <StringLength(50)> _
    Public Property concepto() As String

    <DataMemberAttribute()> _
    <Column("analisis", Order:=3)> _
    <DataType("int NULL")> _
    Public Property analisis() As Integer

    <DataMemberAttribute()> _
    <Column("referencia", Order:=4)> _
    <DataType("int NULL")> _
    Public Property referencia() As Integer

    <DataMemberAttribute()> _
    <Column("cargos", Order:=5)> _
    <DataType("money NULL")> _
    Public Property cargos() As Decimal

    <DataMemberAttribute()> _
    <Column("creditos", Order:=6)> _
    <DataType("money NULL")> _
    Public Property creditos() As Decimal

    <DataMemberAttribute()> _
    <Column("moneda", Order:=7)> _
    <DataType("int NULL")> _
    Public Property moneda() As Integer

    <DataMemberAttribute()> _
    <Column("generales", Order:=8)> _
    <DataType("text NOT NULL")> _
    <StringLength(8000)> _
    Public Property generales() As String

  End Class
#End Region
End Namespace
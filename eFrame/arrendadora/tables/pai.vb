﻿Imports SystemImports System.Collections.GenericImports System.ComponentModel.DataAnnotationsImports System.ComponentModel.DataAnnotations.SchemaImports System.ReflectionImports System.Runtime.SerializationNamespace arrendadora  <Serializable()> _  <DataContractAttribute()> _  <Table("pais", Schema:="dbo")> _  Partial Public Class pai    <DataMemberAttribute()> _    <Column("folio", Order:=1)> _    <DataType("int NOT NULL")> _    <Key()> _    Public Property folio() As Integer    <DataMemberAttribute()> _    <Column("nombre", Order:=2)> _    <DataType("char (50) NOT NULL")> _    <StringLength(50)> _    Public Property nombre() As String    <DataMemberAttribute()> _    <Column("corto", Order:=3)> _    <DataType("char (10) NOT NULL")> _    <StringLength(10)> _    Public Property corto() As String    <DataMemberAttribute()> _    <Column("cvesiti", Order:=4)> _    <DataType("int NULL")> _    Public Property cvesiti() As Nullable(Of Integer)    <DataMemberAttribute()> _    <Column("paraisofiscal", Order:=5)> _    <DataType("bit NULL")> _    Public Property paraisofiscal() As Nullable(Of Boolean)    <DataMemberAttribute()> _    <Column("riesgo_gafi", Order:=6)> _    <DataType("bit NULL")> _    Public Property riesgo_gafi() As Nullable(Of Boolean)    <DataMemberAttribute()> _    <Column("riesg_shcp", Order:=7)> _    <DataType("bit NULL")> _    Public Property riesg_shcp() As Nullable(Of Boolean)  End ClassEnd Namespace
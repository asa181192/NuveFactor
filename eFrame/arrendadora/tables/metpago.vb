﻿Imports SystemImports System.Collections.GenericImports System.ComponentModel.DataAnnotationsImports System.ComponentModel.DataAnnotations.SchemaImports System.ReflectionImports System.Runtime.SerializationNamespace arrendadora  <Serializable()> _  <DataContractAttribute()> _  <Table("metpagos", Schema:="dbo")> _  Partial Public Class metpago    <DataMemberAttribute()> _    <Column("metpago", Order:=1)> _    <DataType("int NOT NULL")> _    <Key()> _    Public Property metpago_id() As Integer    <DataMemberAttribute()> _    <Column("nombre", Order:=2)> _    <DataType("varchar (50) NOT NULL")> _    <StringLength(50)> _    Public Property nombre() As String    <DataMemberAttribute()> _    <Column("void", Order:=3)> _    <DataType("bit NULL")> _    Public Property void() As Nullable(Of Boolean)    <DataMemberAttribute()> _    <Column("ati", Order:=4)> _    <DataType("char (6) NULL")> _    <StringLength(6)> _    Public Property ati() As String  End ClassEnd Namespace
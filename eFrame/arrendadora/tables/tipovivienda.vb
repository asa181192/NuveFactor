﻿Imports SystemImports System.Collections.GenericImports System.ComponentModel.DataAnnotationsImports System.ComponentModel.DataAnnotations.SchemaImports System.ReflectionImports System.Runtime.SerializationNamespace arrendadora  <Serializable()> _  <DataContractAttribute()> _  <Table("tipovivienda", Schema:="dbo")> _  Partial Public Class tipovivienda    <DataMemberAttribute()> _    <Column("numero", Order:=1)> _    <DataType("int NOT NULL")> _    <Key()> _    Public Property numero() As Integer    <DataMemberAttribute()> _    <Column("tipoviv", Order:=2)> _    <DataType("varchar (20) NOT NULL")> _    <StringLength(20)> _    Public Property tipoviv() As String    <DataMemberAttribute()> _    <Column("void", Order:=3)> _    <DataType("bit NOT NULL")> _    Public Property void() As Boolean  End ClassEnd Namespace
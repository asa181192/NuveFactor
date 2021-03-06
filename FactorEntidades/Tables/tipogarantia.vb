Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("tipogarantia")>
Partial Public Class tipogarantia
	<Key>
	<Column(Order:=0)>
	<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
	Public Property tipoid As Integer

    Public Property codigoid As Integer?

    <StringLength(50)>
    Public Property nombre As String

    Public Property tip_alterno As Integer?

    <StringLength(70)>
    Public Property concepto As String

    <StringLength(15)>
    Public Property conta_cargo As String

    <StringLength(15)>
    Public Property conta_abono As String

	<Column(Order:=1)>
	Public Property void As Boolean
End Class

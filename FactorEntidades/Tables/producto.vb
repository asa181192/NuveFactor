Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("producto")>
Partial Public Class producto
    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property id As Integer

	<Column("producto", Order:=1)>
	<StringLength(30)>
	Public Property producto1 As String
End Class

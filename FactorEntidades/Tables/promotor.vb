Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("promotor")>
Partial Public Class promotor
    <Key>
    <Column("promotor")>
    Public Property promotor1 As Integer

    <StringLength(15)>
    Public Property codigo As String

    <StringLength(50)>
    Public Property nombre As String

    <StringLength(50)>
    Public Property domicilio As String

    <StringLength(50)>
    Public Property colonia As String

	Public Property cp As Integer

    <StringLength(40)>
    Public Property municipio As String

    <StringLength(40)>
    Public Property estado As String

    <StringLength(50)>
    Public Property telefono As String

    <StringLength(17)>
    Public Property rfc As String

    Public Property interno As Boolean

    Public Property activo As Boolean

	<Column(TypeName:="numeric")>
	Public Property tipopromo As Decimal

    Public Property void As Boolean

    Public Property sucursal As Integer?

    <StringLength(15)>
    Public Property cc As String

    <StringLength(15)>
    Public Property empleado As String

    <Column(TypeName:="numeric")>
    Public Property idt24 As Decimal?

    <StringLength(100)>
    Public Property nombret24 As String
End Class

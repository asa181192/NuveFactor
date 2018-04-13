Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class usuarios
    Public Property id As Integer?

    <Key>
    <Column(Order:=0)>
    <StringLength(20)>
    Public Property userid As String

    <StringLength(50)>
    Public Property nombre As String

    <StringLength(50)>
    Public Property puesto As String

    Public Property password As Integer?

    <Key>
    <Column(Order:=1)>
    Public Property activo As Boolean

    <Column(TypeName:="text")>
    Public Property trustees As String

    <StringLength(30)>
    Public Property email As String

    <Column(TypeName:="text")>
    Public Property lista_pass As String

    Public Property fec_pass As Date?

    <Key>
    <Column(Order:=2)>
    Public Property insession As Boolean

    Public Property initsession As Date?

    <Key>
    <Column(Order:=3)>
    Public Property mailext As Boolean

    <Key>
    <Column(Order:=4)>
    Public Property firmante As Boolean

    Public Property perfil As Integer?

    Public Property sucursal As Integer?

    <Key>
    <Column(Order:=5)>
    Public Property agree As Boolean

    <Key>
    <Column(Order:=6)>
    Public Property void As Boolean

    <Key>
    <Column(Order:=7, TypeName:="timestamp")>
    <MaxLength(8)>
    <Timestamp>
    Public Property timestamp_column As Byte()
End Class

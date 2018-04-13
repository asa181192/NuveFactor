Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("usuariosArrend")>
Partial Public Class usuariosArrend
    <Key>
    <Column(Order:=0)>
    Public Property folio As Decimal

    <Key>
    <Column(Order:=1)>
    <StringLength(20)>
    Public Property userid As String

    <Key>
    <Column(Order:=2)>
    <StringLength(50)>
    Public Property nombre As String

    <Key>
    <Column(Order:=3)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property password As Integer

    <Key>
    <Column(Order:=4)>
    Public Property activo As Boolean

    <Key>
    <Column(Order:=5)>
    Public Property supervisor As Boolean

    <Key>
    <Column(Order:=6, TypeName:="text")>
    Public Property trustees As String

    <Key>
    <Column(Order:=7, TypeName:="text")>
    Public Property email As String

    <Key>
    <Column(Order:=8, TypeName:="text")>
    Public Property lista_pass As String

    <Key>
    <Column(Order:=9)>
    Public Property fec_pass As Date

    <Key>
    <Column(Order:=10)>
    <StringLength(50)>
    Public Property jefe As String

    <Key>
    <Column(Order:=11)>
    <StringLength(30)>
    Public Property user_job As String

    <Key>
    <Column(Order:=12)>
    Public Property acepta As Date

    <Key>
    <Column(Order:=13, TypeName:="text")>
    Public Property historia As String

    <Key>
    <Column(Order:=14)>
    Public Property void As Boolean

    <Key>
    <Column(Order:=15)>
    Public Property oficina As Decimal

    <Key>
    <Column(Order:=16, TypeName:="text")>
    Public Property perfil As String

    <Column(TypeName:="text")>
    Public Property sign As String

    Public Property promotor As Integer?

    Public Property fecbaja As Date?

    Public Property regional As Integer?

    <StringLength(15)>
    Public Property id_regi As String

    Public Property ubicacion As Integer?

    <StringLength(200)>
    Public Property oficinas As String

    <Column(TypeName:="text")>
    Public Property session As String

    <Column(TypeName:="text")>
    Public Property token As String

    Public Property last_login As Date?

    <StringLength(20)>
    Public Property userbncfisicas As String

    <StringLength(20)>
    Public Property pwdbncfisicas As String

    <StringLength(20)>
    Public Property userbncmorales As String

    <StringLength(20)>
    Public Property pwdbncmorales As String

    Public Property firma As Byte()
End Class

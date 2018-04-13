Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("wsbitacora")>
Partial Public Class wsbitacora
    <Key>
    Public Property IDrec As Integer

    Public Property fecha As Date?

    <StringLength(255)>
    Public Property metodo As String

    <StringLength(255)>
    Public Property ipcliente As String
End Class

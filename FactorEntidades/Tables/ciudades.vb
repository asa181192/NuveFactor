Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class ciudades
    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property clave As Integer

    <StringLength(50)>
    Public Property ciudad As String

    Public Property void As Boolean?
End Class

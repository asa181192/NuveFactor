Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class envios
    Public Property basketid As Integer?

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property envio As Integer

    Public Property userid As Integer?

    <StringLength(50)>
    Public Property userfile As String

    <StringLength(50)>
    Public Property fcafile As String

    Public Property fecha As Date?

    Public Property procesado As Date?

    Public Property void As Boolean?
End Class

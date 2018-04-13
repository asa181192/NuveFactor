Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("actividad")>
Partial Public Class actividad
    Public Property usuario As Integer?

    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property id As Integer

    <StringLength(50)>
    Public Property descrip As String

    <StringLength(13)>
    Public Property rfc As String

    Public Property void As Boolean?

    Public Property idcnbv As Integer?

    <StringLength(50)>
    Public Property descripcnb As String
End Class

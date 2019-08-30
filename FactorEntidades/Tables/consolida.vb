Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("consolida")>
Partial Public Class consolida
    <Key>
    Public Property idrec As Integer

    Public Property fecha As Date?

    Public Property producto As Integer?

    Public Property archivo As String

    Public Property resultado As String

    Public Property exito As Boolean?

    <StringLength(36)>
    Public Property idtransact As String
End Class

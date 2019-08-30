Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Acceso")>
Partial Public Class Acceso
    <Key>
    Public Property IdAcceso As Integer

    Public Property idPerfil As Integer?

	Public Property IdPermiso As Integer

    Public Property activo As Integer?
End Class

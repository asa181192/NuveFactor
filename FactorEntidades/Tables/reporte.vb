Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("reporte")>
Partial Public Class reporte
  <Key>
  Public Property Idreporte As Integer

  <StringLength(20)>
  Public Property modulo As String

  <StringLength(100)>
  Public Property descripcion As String

  Public Property url As String
End Class

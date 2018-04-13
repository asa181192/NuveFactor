Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class siniestros
    <Key>
    Public Property idsiniestro As Integer

    Public Property idpoliza As Integer?

    Public Property idipoliza As Integer?

    Public Property cancelado As Boolean

    <StringLength(100)>
    Public Property contratos As String

    <Column(TypeName:="numeric")>
    Public Property solicitado As Decimal?

    <Column(TypeName:="numeric")>
    Public Property deducible As Decimal?

    Public Property tipoaviso As Integer?

    Public Property fsolicitud As Date?

    Public Property plazo As Integer?

    Public Property frespuesta As Date?
End Class

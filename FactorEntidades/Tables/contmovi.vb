Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("contmovi")>
Partial Public Class contmovi
    Public Property fecha As Date?

    Public Property contrato As Integer?

    Public Property cliente As Integer?

    Public Property sucursal As Integer?

    Public Property moneda As Integer?

    Public Property movto As Integer?

    <Column(TypeName:="money")>
    Public Property anterior As Decimal?

    <Column(TypeName:="money")>
    Public Property actual As Decimal?

    <Key>
    Public Property void As Boolean
End Class

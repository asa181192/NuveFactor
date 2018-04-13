Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("cifrascontrol")>
Partial Public Class cifrascontrol
    <Column(TypeName:="numeric")>
    Public Property importe As Decimal?

    <Column(TypeName:="numeric")>
    Public Property descto As Decimal?

    <Column(TypeName:="numeric")>
    Public Property neto As Decimal?

    <Column(TypeName:="numeric")>
    Public Property bonifica As Decimal?

    <Key>
    Public Property void As Boolean
End Class

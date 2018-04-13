Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.Core
Imports System.Data.Entity.Core.Objects

Namespace catalogos
  Public Class Container
    Inherits DbContext

    Public Sub New(ByVal connstr As String)
      MyBase.New(connstr)
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
      MyBase.OnModelCreating(modelBuilder)
    End Sub

    Public Overridable Property ipaddr As DbSet(Of ipaddr)

  End Class
End Namespace

Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq

Partial Public Class Model1
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=Model1")        
    End Sub

    Public Overridable Property cesiones As DbSet(Of cesiones)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.sumadoctos) _
            .HasPrecision(20, 0)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.importe) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.impanticipado) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.tasaoper) _
            .HasPrecision(6, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.interes) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.ivainteres) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.tasahono) _
            .HasPrecision(6, 4)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.honorario) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.ivahonorario) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.tnafin) _
            .HasPrecision(8, 5)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.cartera) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.pagos) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.totalpagar) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.cuenta) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.movto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.userid) _
            .IsUnicode(False)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.acuse) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.costonafin) _
            .HasPrecision(6, 4)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.tasa_ord) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.folioevento) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.disperfile) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.tasaganafin) _
            .HasPrecision(6, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.garantnafin) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.ivaganafin) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.imvfacnafin) _
            .HasPrecision(6, 4)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.gliquida) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.cfdi) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.plazo) _
            .HasPrecision(5, 0)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.int_diario) _
            .HasPrecision(14, 4)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.idtransact) _
            .IsFixedLength() _
            .IsUnicode(False)
    End Sub
End Class

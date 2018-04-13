Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data.Linq.SqlClient
Imports Entidades
Imports Entidades.arrendadora

Namespace arrendadoraDL

  Public Class outboxDL
    Inherits ConnClassDL

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      MyBase.New()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="scnn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal scnn As String)
      MyBase.New(scnn)
    End Sub

    Public Function Submit(ByRef outbx As outbox) As Boolean
      Dim bTrans As Boolean = True
      Try
        MyBase.Start_context()
        Dim noficina = Convert.ToDecimal(outbx.office)
        Dim origen = (From o As oficina In context.oficinas
                      Where o.oficina_id = noficina
                      Select New With {.ori = Convert.ToInt32(o.origen)}).Single().ori
        outbx.office = origen
        context.outboxs.Add(outbx)
        context.SaveChanges()
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        bTrans = False
      End Try
      Return bTrans
    End Function

    Public Function Submit(ByRef outbxLst As List(Of outbox)) As Boolean
      Dim bTrans As Boolean = True
      Try
        MyBase.Start_context()
        Dim noficina = Convert.ToDecimal(outbxLst.ElementAt(0).office)
        Dim origen = (From o As oficina In context.oficinas
                      Where o.oficina_id = noficina
                      Select New With {.ori = Convert.ToInt32(o.origen)}).Single().ori
        For Each out In outbxLst
          out.office = origen
        Next
        context.outboxs.AddRange(DirectCast(outbxLst, IEnumerable(Of outbox)))
        context.SaveChanges()
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        bTrans = False
      End Try
      Return bTrans
    End Function

  End Class

End Namespace
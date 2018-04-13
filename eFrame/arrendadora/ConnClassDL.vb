Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data.Entity

Namespace arrendadora
  Public MustInherit Class ConnClassDL
    Implements IDisposable

    Private cnnstr As String
    Private oDataset As DataSet
    Private oCnn As SqlConnection
    Public context As arrendadora.Container
    Public Property Err() As Exception
    Public Property hayErr() As Boolean

    ''' <summary>
    ''' Arrendadora
    ''' </summary>    
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      Dim type = GetType(System.Data.Entity.SqlServer.SqlProviderServices)
      Me.cnnstr = "SQLSTRINGCONFORME"
      Me.hayErr = False
      Me.Err = Nothing
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="sconn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal sconn As String)
      Dim type = GetType(System.Data.Entity.SqlServer.SqlProviderServices)
      Me.cnnstr = sconn
      Me.hayErr = False
      Me.Err = Nothing
    End Sub

    Public Sub Start_context()
      If Not Me.context Is Nothing Then Me.context.Dispose()
      Me.context = Nothing
      Me.context = New Container(Me.cnnstr)
    End Sub

    Public Function GetTable(ByVal cmd As SqlCommand) As DataTable
      oCnn = New SqlConnection(context.Database.Connection.ConnectionString)
      Return Metodos.GetTable(oDataset, oCnn, cmd)
    End Function

    Public Sub ExecuteNonQuery(ByRef cmd As SqlCommand)
      If oCnn Is Nothing Then
        oCnn = New SqlConnection(context.Database.Connection.ConnectionString)
        If oCnn.State = ConnectionState.Closed Then oCnn.Open()
      End If
      cmd.Connection = oCnn
      cmd.ExecuteNonQuery()
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          If Not Me.context Is Nothing Then Me.context.Dispose()
          If Not Me.context Is Nothing Then Me.context = Nothing
          If Not Me.Err Is Nothing Then Me.Err = Nothing
          If Not Me.oDataset Is Nothing Then Me.oDataset.Dispose()
          If Not Me.oDataset Is Nothing Then Me.oDataset = Nothing
          If Not Me.oCnn Is Nothing Then
            If Me.oCnn.State = ConnectionState.Open Then Me.oCnn.Close()
          End If
          If Not Me.oCnn Is Nothing Then Me.oCnn.Dispose()
          If Not Me.oCnn Is Nothing Then Me.oCnn = Nothing
        End If
      End If
      Me.disposedValue = True
    End Sub

    Protected Overrides Sub Finalize()
      Dispose(False)
      MyBase.Finalize()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region

    Public Function ConvertToDataTable(Of T)(data As IList(Of T)) As DataTable
      Return Metodos.ConvertToDataTable(data:=data)
    End Function

    Public Function fillobjecwithTable(ByVal typeitem As Object, ByVal table As System.Data.DataTable) As Object
      Return Metodos.fillobjecwithTable(typeitem, table)
    End Function

    Public Function AppendItem(ByVal typeitem As Object, ByVal item As System.Data.DataRow) As Object
      Return Metodos.AppendItem(typeitem, item)
    End Function

    Public Function strupdate(ByRef modelo As Object, ByRef contexto As Object, ByRef tabla As String, ByRef indice As Integer, ByRef llaves As List(Of String), ByRef params As Data.SqlClient.SqlParameterCollection) As String
      Dim sreturn As String = " UPDATE t SET {0} FROM dbo.{1} t WHERE {2}; "
      Dim sset As String = ""
      Dim sfrom As String = ""
      Dim swhere As String = ""

      Dim ofieldslst As New List(Of l_update)
      Dim ofieldskeyslst As New List(Of l_update)

      For Each prop As System.Reflection.PropertyInfo In modelo.GetType().GetProperties
        If Not llaves.Contains(prop.Name.ToLower()) Then
          If prop.GetValue(contexto) <> prop.GetValue(modelo) Then
            ofieldslst.Add(New l_update With {.field = prop.Name, .value = prop.GetValue(modelo)})
          End If
        End If
        If llaves.Contains(prop.Name.ToLower()) Then
          ofieldskeyslst.Add(New l_update With {.field = prop.Name, .value = prop.GetValue(modelo)})
        End If
      Next

      For Each elem As l_update In ofieldslst
        If ofieldslst.IndexOf(elem) = ofieldslst.Count - 1 Then
          sset += " t." & elem.field & " = @" & elem.field & "_" & indice.ToString
        Else
          sset += " t." & elem.field & " = @" & elem.field & "_" & indice.ToString & " ,"
        End If
        If elem.value IsNot Nothing Then
          params.AddWithValue("@" + elem.field & "_" & indice.ToString, elem.value)
        Else
          params.AddWithValue("@" + elem.field & "_" & indice.ToString, DBNull.Value)
        End If
      Next

      If sset.Trim.Length > 0 Then
        For Each elem As l_update In ofieldskeyslst
          If ofieldskeyslst.IndexOf(elem) = ofieldskeyslst.Count - 1 Then
            swhere += " t." & elem.field & " = @" & elem.field & "_" & indice.ToString
          Else
            swhere += " t." & elem.field & " = @" & elem.field & "_" & indice.ToString & " AND "
          End If
          If elem.value IsNot Nothing Then
            params.AddWithValue("@" + elem.field & "_" & indice.ToString, elem.value)
          Else
            params.AddWithValue("@" + elem.field & "_" & indice.ToString, DBNull.Value)
          End If
        Next
      End If

      sfrom = tabla

      If sset.Trim.Length > 0 Then
        sreturn = String.Format(sreturn, sset, sfrom, swhere)
      Else
        sreturn = ""
      End If

      ofieldslst.Clear()
      ofieldslst = Nothing
      ofieldskeyslst.Clear()
      ofieldskeyslst = Nothing

      Return sreturn
    End Function

    Private Class l_update
      Public Property field As String
      Public Property value As Object
    End Class

  End Class
End Namespace
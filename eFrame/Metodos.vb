Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.ComponentModel

Module Metodos
  Private tiposTexto As List(Of String) = New List(Of String)({"Char", "String"})
  Private tiposNumero As List(Of String) = New List(Of String)({"Int16", "Int32", "Int64", "UInt16", "UInt32", "UInt64", "Decimal", "Byte", "Single", "SByte", "Double", "Integer", "Long", "Short", "UInteger", "ULong", "UShort"})
  Private tiposFecha As List(Of String) = New List(Of String)({"Date", "DateTime"})

  ''' <summary>
  ''' Convierte List(Of Type) en DataTable
  ''' </summary>
  ''' <typeparam name="T">Type</typeparam>
  ''' <param name="data">List(of Type)</param>
  ''' <returns>DataTable</returns>
  ''' <remarks>Convierte List(Of Type) en DataTable</remarks>
  Public Function ConvertToDataTable(Of T)(data As IList(Of T)) As DataTable
    Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(GetType(T))
    Dim table As New DataTable(GetType(T).Name)
    For Each prop As PropertyDescriptor In properties
      table.Columns.Add(prop.Name, If(Nullable.GetUnderlyingType(prop.PropertyType), prop.PropertyType))
    Next
    For Each item As T In data
      Dim row As DataRow = table.NewRow()
      For Each prop As PropertyDescriptor In properties
        row(prop.Name) = If(prop.GetValue(item), DBNull.Value)
      Next
      table.Rows.Add(row)
    Next
    Return table
  End Function

  Public Function GetTable(ByRef ds As DataSet, ByRef cnn As SqlConnection, ByRef cmd As SqlCommand) As DataTable
    Dim oTable As DataTable = Nothing
    cnn.Open()
    cmd.Connection = cnn
    ds = New DataSet
    oTable = New DataTable("table")
    ds.Tables.Add(oTable)
    Dim oDR = cmd.ExecuteReader
    ds.Tables("table").Load(oDR)
    cnn.Close()
    Return oTable
  End Function

  Public Function fillobjecwithTable(ByVal typeitem As Object, ByVal table As System.Data.DataTable) As Object
    Dim listType = GetType(List(Of ))
    Dim constructedListType = listType.MakeGenericType(Type.GetType(typeitem.GetType.ToString()))
    Dim instance = Activator.CreateInstance(constructedListType)
    If table.Rows.Count > 0 Then
      For Each row As System.Data.DataRow In table.Rows
        Dim oPaso = Activator.CreateInstance(Type.GetType(typeitem.GetType.ToString()))
        instance.Add(AppendItem(oPaso, row))
      Next
    End If
    Return instance
  End Function

  Public Function AppendItem(ByVal typeitem As Object, ByVal item As System.Data.DataRow) As Object
    Dim oPaso = Activator.CreateInstance(Type.GetType(typeitem.GetType.ToString()))
    Dim oProps = oPaso.GetType().GetProperties
    For Each oprop In oProps
      If oprop.PropertyType.Name.Contains("Nullable") Then
        If tiposNumero.Contains(Nullable.GetUnderlyingType(oprop.PropertyType).Name) Then
          If (IsDBNull(item(oprop.Name))) Then
            oprop.SetValue(oPaso, Nothing)
          Else
            oprop.SetValue(oPaso, item(oprop.Name))
          End If
        End If
        If tiposFecha.Contains(Nullable.GetUnderlyingType(oprop.PropertyType).Name) Then
          If (IsDBNull(item(oprop.Name))) Then
            oprop.SetValue(oPaso, Nothing)
          Else
            oprop.SetValue(oPaso, item(oprop.Name))
          End If
        End If
        If Nullable.GetUnderlyingType(oprop.PropertyType).Name = "Boolean" Then
          If (IsDBNull(item(oprop.Name))) Then
            oprop.SetValue(oPaso, Nothing)
          Else
            oprop.SetValue(oPaso, item(oprop.Name))
          End If
        End If
        If tiposTexto.Contains(oprop.PropertyType.Name) Then
          If (IsDBNull(item(oprop.Name))) Then
            If oprop.PropertyType.Name = "Char" Then
              oprop.SetValue(oPaso, " "c)
            Else
              oprop.SetValue(oPaso, "")
            End If
          Else
            oprop.SetValue(oPaso, item(oprop.Name))
          End If
        End If
      Else
        If tiposNumero.Contains(oprop.PropertyType.Name) Then
          If (IsDBNull(item(oprop.Name))) Then
            oprop.SetValue(oPaso, 0)
          Else
            oprop.SetValue(oPaso, item(oprop.Name))
          End If
        End If
        If tiposFecha.Contains(oprop.PropertyType.Name) Then
          If (IsDBNull(item(oprop.Name))) Then
            oprop.SetValue(oPaso, New Date(1900, 1, 1))
          Else
            oprop.SetValue(oPaso, item(oprop.Name))
          End If
        End If
        If oprop.PropertyType.Name = "Boolean" Then
          If (IsDBNull(item(oprop.Name))) Then
            oprop.SetValue(oPaso, False)
          Else
            oprop.SetValue(oPaso, item(oprop.Name))
          End If
        End If
        If tiposTexto.Contains(oprop.PropertyType.Name) Then
          If (IsDBNull(item(oprop.Name))) Then
            If oprop.PropertyType.Name = "Char" Then
              oprop.SetValue(oPaso, " "c)
            Else
              oprop.SetValue(oPaso, "")
            End If
          Else
            oprop.SetValue(oPaso, item(oprop.Name))
          End If
        End If
      End If
    Next
    Return oPaso
  End Function
End Module

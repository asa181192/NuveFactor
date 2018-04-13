Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Collections
Imports System.DirectoryServices

Public Class LdapAuth

  Public oException As Exception

  Public Sub New()

  End Sub

  Public Function IsAuthenticated(username As String, pwd As String) As Boolean
    IsAuthenticated = False
    Try
      Dim domainAndUsername As String = My.Settings.domain & "\" & username
      Dim root As New System.directoryservices.DirectoryEntry("GC://RootDSE")
      Dim entry = New DirectoryEntry("GC://" & root.Properties("rootDomainNamingContext")(0).ToString, domainAndUsername, pwd, AuthenticationTypes.Secure)

      'Bind to the native AdsObject to force authentication.
      Dim obj As Object = entry.NativeObject
      Dim search = New DirectorySearcher(entry)
      search.Filter = "(SAMAccountName=" & username & ")"
      search.PropertiesToLoad.Add("cn")
      Dim result As SearchResult = search.FindOne()
      If result IsNot Nothing Then
        IsAuthenticated = True
      End If

    Catch ex As Exception
      oException = ex
    End Try

  End Function

End Class
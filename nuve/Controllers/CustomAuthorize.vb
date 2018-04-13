Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Public Class CustomAuthorize
  Inherits AuthorizeAttribute

  Protected Overrides Function AuthorizeCore(httpContext As HttpContextBase) As Boolean
    Dim authorized = MyBase.AuthorizeCore(httpContext)
    If Not authorized Then
      Return False
    End If
    Dim myvar = httpContext.Session("USERID")
    If myvar Is Nothing Then
      Return False
    End If
    Return True
  End Function
End Class

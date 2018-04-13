Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace arrendadora
  Public Enum tipoXML
    Ninguno = 0
    CFD = 1
    CFDI = 2
  End Enum

  Public Class archivoXML
    Public Property tipo() As tipoXML
    Public Property Version() As String

    Public Property serie() As String
    Public Property folio() As String
    Public Property Expedicion() As String
    Public Property moneda() As String
    Public Property Fecha() As String
    Public Property Total() As String
    Public Property Subtotal() As String
    Public Property MetodoPago() As String

    Public Property Emisor() As String
    Public Property RFC() As String

    Public Property UUID() As String
    Public Property FechaTimbre() As String
  End Class
End Namespace
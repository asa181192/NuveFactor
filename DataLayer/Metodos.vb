Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data.Linq.SqlClient
Imports System.ComponentModel
Imports DataLayer.arrendadoraDL
Imports Entidades
Imports Entidades.arrendadora

Public Module Metodos
  Public Function GeneraOutbox(ByVal oficina As Integer, ByVal archivo As String, ByVal tag As String, ByVal llave As String, ByVal changes As String) As Boolean
    Dim bTrans As Boolean = False
    Dim oOuBxDL As outboxDL = Nothing
    Dim oOuBx As outbox = Nothing
    Try
      oOuBxDL = New outboxDL()
      oOuBx = New outbox()
      oOuBx.office = oficina
      oOuBx.archivo = archivo
      oOuBx.tag = tag
      oOuBx.llave = llave
      oOuBx.changes = changes
      oOuBx.fecalta = Now
      oOuBx.fecxfer = New Date(1900, 1, 1)
      oOuBx.consfile = ""
      oOuBx.void = False
      bTrans = oOuBxDL.Submit(oOuBx)
      If oOuBxDL.hayErr Then Throw oOuBxDL.Err
      oOuBxDL.Dispose()
      oOuBxDL = Nothing
      oOuBx = Nothing
    Catch ex As Exception
      oOuBxDL.Dispose()
      oOuBxDL = Nothing
      oOuBx = Nothing
      Throw New Exception("Error datos", ex)
    End Try
    Return bTrans
  End Function

  Public Function GeneraOutbox(ByVal oficina As Integer, ByVal archivo As String, ByVal tag As String, ByVal llave As String, ByVal chageslst As List(Of String)) As Boolean
    Dim bTrans As Boolean = False
    Dim oOuBxDL As outboxDL = Nothing
    Dim oOuBxLst As List(Of outbox) = Nothing
    Dim oOuBx As outbox = Nothing
    Try
      oOuBxDL = New outboxDL()
      oOuBxLst = New List(Of outbox)
      Dim nsec As Integer = 1
      For Each changes As String In chageslst
        oOuBx = New outbox()
        oOuBx.office = oficina
        oOuBx.archivo = archivo
        oOuBx.tag = tag
        oOuBx.llave = llave
        oOuBx.changes = changes
        oOuBx.fecalta = Now.AddSeconds(nsec)
        oOuBx.fecxfer = New Date(1900, 1, 1)
        oOuBx.consfile = ""
        oOuBx.void = False
        oOuBxLst.Add(oOuBx)
        oOuBx = Nothing
        nsec += 1
      Next
      bTrans = oOuBxDL.Submit(oOuBxLst)
      If oOuBxDL.hayErr Then Throw oOuBxDL.Err
      oOuBxDL.Dispose()
      oOuBxDL = Nothing
      oOuBxLst = Nothing
    Catch ex As Exception
      oOuBxDL.Dispose()
      oOuBxDL = Nothing
      oOuBxLst = Nothing
      Throw New Exception("Error datos", ex)
    End Try
    Return bTrans
  End Function

#Region "  Para las facturas (XML) "
  Public Function VerInfoFacturaXML(sxml As String) As archivoXML
    Dim oReturn As archivoXML = Nothing
    Dim oxml As Xml.XmlDocument = Nothing
    Try
      oxml = New Xml.XmlDocument
      oxml.LoadXml(sxml)
      Dim nodo = From n As Xml.XmlNode In oxml.ChildNodes
                 Where n.Name <> "xml"
                 Select n

      If nodo IsNot Nothing Then
        Dim n = nodo.ElementAt(0)
        If (n.Prefix.ToLower = "cfdi") Then
          oReturn = CargaInfoCFDI(n)
        Else
          oReturn = CargaInfoCFD(n)
        End If
      Else
        oReturn = New archivoXML With {.tipo = tipoXML.Ninguno}
      End If
    Catch ex As Exception
      oReturn = New archivoXML With {.tipo = tipoXML.Ninguno}
    End Try
    If oxml IsNot Nothing Then oxml = Nothing
    Return oReturn
  End Function

  Private Function CargaInfoCFD(Nodo As Xml.XmlNode, Optional ByRef oArchivoXML As archivoXML = Nothing) As archivoXML
    If oArchivoXML Is Nothing Then oArchivoXML = New archivoXML()
    oArchivoXML.tipo = tipoXML.CFD
    If Nodo.Attributes IsNot Nothing Then
      For Each a As Xml.XmlAttribute In Nodo.Attributes
        If Nodo.LocalName.ToLower = "comprobante" Then
          Select Case a.LocalName.ToLower
            Case Is = "version"
              oArchivoXML.Version = a.Value
            Case Is = "serie"
              oArchivoXML.serie = a.Value
            Case Is = "folio"
              oArchivoXML.folio = a.Value
            Case Is = "lugarexpedicion"
              oArchivoXML.Expedicion = a.Value
            Case Is = "moneda"
              oArchivoXML.moneda = a.Value
            Case Is = "fecha"
              oArchivoXML.Fecha = a.Value.Trim.ToLower.Replace("t", " ")
            Case Is = "total"
              oArchivoXML.Total = String.Format("{0:C2}", Convert.ToDouble(a.Value.Trim))
            Case Is = "subtotal"
              oArchivoXML.Subtotal = String.Format("{0:C2}", Convert.ToDouble(a.Value.Trim))
            Case Is = "metododepago"
              oArchivoXML.MetodoPago = a.Value
          End Select
        End If
        If Nodo.LocalName.ToLower = "emisor" Then
          Select Case a.LocalName.ToLower
            Case Is = "nombre"
              oArchivoXML.Emisor = a.Value
            Case Is = "rfc"
              oArchivoXML.RFC = a.Value
          End Select
        End If
      Next
    End If
    If Nodo.HasChildNodes Then
      For Each n As Xml.XmlNode In Nodo.ChildNodes
        CargaInfoCFD(n, oArchivoXML)
      Next
    End If
    Return oArchivoXML
  End Function

  Private Function CargaInfoCFDI(Nodo As Xml.XmlNode, Optional ByRef oArchivoXML As archivoXML = Nothing) As archivoXML
    If oArchivoXML Is Nothing Then oArchivoXML = New archivoXML()
    oArchivoXML.tipo = tipoXML.CFDI
    If Nodo.Attributes IsNot Nothing Then
      For Each a As Xml.XmlAttribute In Nodo.Attributes
        If Nodo.LocalName.ToLower = "comprobante" Then
          Select Case a.LocalName.ToLower
            Case Is = "version"
              oArchivoXML.Version = a.Value
            Case Is = "serie"
              oArchivoXML.serie = a.Value
            Case Is = "folio"
              oArchivoXML.folio = a.Value
            Case Is = "lugarexpedicion"
              oArchivoXML.Expedicion = a.Value
            Case Is = "moneda"
              oArchivoXML.moneda = a.Value
            Case Is = "fecha"
              oArchivoXML.Fecha = a.Value.Trim.ToLower.Replace("t", " ")
            Case Is = "total"
              oArchivoXML.Total = String.Format("{0:C2}", Convert.ToDouble(a.Value.Trim))
            Case Is = "subtotal"
              oArchivoXML.Subtotal = String.Format("{0:C2}", Convert.ToDouble(a.Value.Trim))
            Case Is = "metododepago"
              oArchivoXML.MetodoPago = a.Value
          End Select
        End If
        If Nodo.LocalName.ToLower = "emisor" Then
          Select Case a.LocalName.ToLower
            Case Is = "nombre"
              oArchivoXML.Emisor = a.Value
            Case Is = "rfc"
              oArchivoXML.RFC = a.Value
          End Select
        End If
        If Nodo.LocalName.ToLower = "timbrefiscaldigital" Then
          Select Case a.LocalName.ToLower
            Case Is = "uuid"
              oArchivoXML.UUID = a.Value
            Case Is = "fechatimbrado"
              oArchivoXML.FechaTimbre = a.Value.Trim.ToLower.Replace("t", " ")
          End Select
        End If
      Next
    End If
    If Nodo.HasChildNodes Then
      For Each n As Xml.XmlNode In Nodo.ChildNodes
        CargaInfoCFDI(n, oArchivoXML)
      Next
    End If
    Return oArchivoXML
  End Function
#End Region

End Module

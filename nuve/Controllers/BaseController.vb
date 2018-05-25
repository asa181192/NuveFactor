Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports nuve.Helpers
Imports System.IO
Imports System.Runtime.Serialization.Json
Imports System.Globalization

Public Class BaseController
  Inherits Controller

  Public Const PASSWORD_MINLENGTH As Integer = 8 ' 0 if doesn't apply
  Public Const PASSWORD_HISTORY As Integer = 4   ' 0 if doesn't apply
  Public Const PASSWORD_EXPIRES As Integer = 90  ' 0 if doesn't apply
  Public Const PASSWORD_NOTIFY As Integer = 15  ' 0 if doesn't apply
  Public Const PASSWORD_COMPLEX As Boolean = True
  Public Const PASSWORD_CAPS As Boolean = True
  Public Const PASSWORD_SMALLCAPS As Boolean = True
  Public Const PASSWORD_NUMBERS As Boolean = True
  Public Const PASSWORD_SPECHARS As Boolean = False

  Public Shared Function PasswordComplexity(ByVal s As String) As Boolean
    Dim result As Boolean = False
    If Len(s) >= PASSWORD_MINLENGTH Then
      result = True
    End If
    If PASSWORD_COMPLEX = True Then
      Dim HAS_CAPS As Boolean = False
      Dim HAS_SMALLCAPS As Boolean = False
      Dim HAS_NUMBERS As Boolean = False
      Dim HAS_SPECHARS As Boolean = False
      For i As Integer = 1 To Len(s)
        Dim c As Integer = Asc(Mid(s, i, 1))
        If c >= 65 And c <= 90 Then ' "A" <= c <= "Z"
          HAS_CAPS = True
        ElseIf c >= 97 And c <= 122 Then ' "a" <= c <= "z"
          HAS_SMALLCAPS = True
        ElseIf c >= 48 And c <= 57 Then ' "0" <= c <= "9"
          HAS_NUMBERS = True
        Else
          HAS_SPECHARS = True
        End If
      Next
      If PASSWORD_CAPS = True Then
        If HAS_CAPS = True Then
          result = True
        Else
          result = False
        End If
      End If
      If PASSWORD_SMALLCAPS = True Then
        If HAS_SMALLCAPS = True Then
          result = True
        Else
          result = False
        End If
      End If
      If PASSWORD_NUMBERS = True Then
        If HAS_NUMBERS = True Then
          result = True
        Else
          result = False
        End If
      End If
      If PASSWORD_SPECHARS = True Then
        If HAS_SPECHARS = True Then
          result = True
        Else
          result = False
        End If
      End If
    End If
    PasswordComplexity = result
  End Function

  Public Shared Function format_leading_zeros(ByVal n As Double, ByVal l As Integer) As String
    If n.ToString.Length < l Then
      format_leading_zeros = New String("0", l - n.ToString.Length) & n.ToString
    Else
      format_leading_zeros = n.ToString
    End If
  End Function

  Public Shared Function formatEmail(ByVal msg As String) As String
    Dim h As String = ""
    h += "<HTML><HEAD><STYLE type=text/css>.lightblue {	BACKGROUND-COLOR: #f0f0ff}.heading {FONT-SIZE: 10px; COLOR: #333E48; FONT-FAMILY: Arial, Helvetica, sans-serif}.bodyheading {	FONT-WEIGHT: bold; FONT-SIZE: 10px; COLOR: #333E48; FONT-FAMILY: Arial, Helvetica, sans-serif}BODY {MARGIN: 0px 10px}.bodytext {	FONT-SIZE: 10px; COLOR: #333E48; FONT-FAMILY: Arial, Helvetica, sans-serif} A {FONT: 10px Arial,Helvetica,sans-serif; COLOR: #333E48; TEXT-DECORATION: underline}FORM {PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; FONT: 10px arial; PADDING-TOP: 0px}SELECT {	PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; FONT: 10px arial; PADDING-TOP: 0px}INPUT {	PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; FONT: 10px arial; PADDING-TOP: 0px}A:link {}A:visited {}A:active {}A:hover {    Text(-DECORATION) : underline()}IMG {	BORDER-TOP-WIDTH: 0px; PADDING-RIGHT: 0px; PADDING-LEFT: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-TOP: 0px; BORDER-RIGHT-WIDTH: 0px}LI {    LIST(-Style - Type) : none()}#main .doc {FONT-FAMILY: Arial, Helvetica, sans-serif; BORDER-RIGHT: #e0e0e0 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #e0e0e0 1px solid; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; BORDER-LEFT: #e0e0e0 1px solid; PADDING-TOP: 5px; BORDER-BOTTOM: #e0e0e0 0px}#main .lastdoc {FONT-FAMILY: Arial, Helvetica, sans-serif; BORDER-RIGHT: #e0e0e0 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #e0e0e0 1px solid; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; BORDER-LEFT: #e0e0e0 1px solid; PADDING-TOP: 5px; BORDER-BOTTOM: #e0e0e0 1px solid}#main .enddoc {	BORDER-RIGHT: #e0e0e0 0px; PADDING-RIGHT: 5px; BORDER-TOP: #e0e0e0 1px solid; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; BORDER-LEFT: #e0e0e0 0px; PADDING-TOP: 5px; BORDER-BOTTOM: #e0e0e0 0px}#main .tablebar {FONT-FAMILY: Arial, Helvetica, sans-serif; BACKGROUND-COLOR: #f4f4f4; TEXT-ALIGN: center}#main .tablebartext {FONT-FAMILY: Arial, Helvetica, sans-serif; PADDING-RIGHT: 5px; PADDING-LEFT: 5px; FONT-SIZE: 14px; PADDING-BOTTOM: 5px; COLOR: #333E48; PADDING-TOP: 5px; FONT-STYLE: normal; FONT-FAMILY: Arial, Helvetica, sans-serif}.headingname {	FONT-WEIGHT: normal; FONT-SIZE: 18px; PADDING-BOTTOM: 7px; COLOR: #333E48; LINE-HEIGHT: normal; FONT-STYLE: normal; FONT-FAMILY: Arial, Helvetica, sans-serif}.wizcit {	FONT-SIZE: 8px; COLOR: #333333; FONT-STYLE: normal; FONT-FAMILY: Arial, Helvetica, sans-serif}#content {	FONT-SIZE: 10px; COLOR: #333E48; FONT-FAMILY: Arial, Helvetica, sans-serif}#content TD {	PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; MARGIN: 5px; PADDING-TOP: 5px}#content TD.subheading {	BACKGROUND: #e0e0e0}#content TD.subheading-selected-ASC {	BACKGROUND: url(/images/asc.gif) #c0c0c0 no-repeat right center}#content TD.subheading-selected-DESC {	BACKGROUND: url(/images/desc.gif) #c0c0c0 no-repeat right center} #content TR.odd {	BACKGROUND: #f4f4f4} #content .search {	WIDTH: 240px}.ll {	BORDER-LEFT: #e0e0e0 1px solid}.lr {	BORDER-RIGHT: #e0e0e0 1px solid}.lt {	BORDER-TOP: #e0e0e0 1px solid}.lb {	BORDER-BOTTOM: #e0e0e0 1px solid}.headResumen { background-color: #333E48; font-weight: bold; font-size: 16px; text-align: left; padding-top: 4px; padding-bottom: 4px; text-transform: uppercase; color: #ffffff; margin-bottom: 5px; }.tdbodyhead { color: #333E48; background-color: #ffffff; font-weight: bold; text-align: center; border-bottom-width: 1px; border-bottom-style: solid; border-bottom-color: #C4D600; padding-right: 5px; padding-left: 5px; }</STYLE></HEAD>"
    h += "<BODY><BR>"
    h += "<TABLE cellSpacing=0 cellPadding=0 width=700 align=center border=0>"
    h += "  <TBODY>"
    h += "    <TR>"
    h += "      <TD vAlign=center align=middle height=40 style=""border-bottom: #C4D600 4px solid;"">"
    h += getHeaderForEmail()
    h += "      </TD>"
    h += "    </TR>"
    h += "  <TR>"
    h += "    <TD vAlign=top align=middle style=""border-bottom: #C4D600 1px solid;""><BR><BR>"
    h += "      <TABLE id=main cellSpacing=0 cellPadding=0 width=700 border=0>"
    h += "        <TBODY>"
    h += "          <TR><TD class=""doc tablebartext"">" & My.Resources.Nombre & "</TD></TR>"
    h += "          <TR><TD class=""doc tablebar tablebartext"">&nbsp;</TD></TR>"
    h += "          <TR><TD class=""doc bodytext"" align=left><BR>" & msg & "<BR>&nbsp;</TD></TR>"
    h += "          <TR><TD class=""doc tablebar tablebartext"">&nbsp;</TD></TR>"
    h += "          <TR><TD class=enddoc>&nbsp;</TD></TR>"
    h += "        </TBODY>"
    h += "      </TABLE>"
    h += "    </TD>"
    h += "  </TR>"
    h += "  </TBODY>"
    h += "</TABLE>"
    h += "</BODY></HTML>"
    Return h
  End Function

  Public Shared Function getHeaderForEmail() As String
    Dim h As String = ""
    h += "<TABLE cellSpacing=0 cellPadding=0 width=""100%"" border=0>"
    h += "  <TBODY>"
    h += "    <TR>"      
    h += "      <TD class=headingname vAlign=bottom>" & Microsoft.VisualBasic.StrConv(My.Resources.Empresa, VbStrConv.Uppercase) & "</TD>"
    h += "      <TD class=headingname vAlign=bottom align=right width=250>"
    h += "        <IMG src=""http://www.arrvepormas.com.mx/images/cube.gif""></TD>"
    h += "    </TR>"
    h += "  </TBODY>"
    h += "</TABLE>"
    Return h
  End Function

  Public Shared Function rndUpper() As String
    Randomize()
    Return Chr(Int(Rnd() * 26) + Asc("A"))
  End Function

  Public Shared Function rndLower() As String
    Randomize()
    Return Chr(Int(Rnd() * 26) + Asc("a"))
  End Function

  Public Shared Function rndNumber() As String
    Randomize()
    Return Chr(Int(Rnd() * 10) + Asc("0"))
  End Function

  Public Shared Function setPassWord() As String
    Return rndUpper() & rndUpper() & rndLower() & rndLower() & rndUpper() & rndLower() & rndNumber() & rndNumber()
  End Function

  Public Shared Sub BitacoraError(ByVal s As Exception, ByVal user As String, ByVal remote_addr As String, Optional ByVal smodel As String = "")
    Dim sAccion As String = ""
    Try
      If s.InnerException Is Nothing Then
        If smodel.Trim.Length > 0 Then
          sAccion = String.Format("ERR: {0}, MODELO: {1}", s.StackTrace, smodel)
        Else
          sAccion = String.Format("ERR: {0}", s.StackTrace)
        End If
      Else
        If smodel.Trim.Length > 0 Then
          sAccion = String.Format("ERR: {0}" & vbCrLf & "Origen: {1}" & vbCrLf & "Método:{2}" & vbCrLf & "Detalle: {3}, MODELO: {4}", s.InnerException.Message, s.InnerException.Source, s.InnerException.TargetSite.ToString, s.InnerException.StackTrace, smodel)
        Else
          sAccion = String.Format("ERR: {0}" & vbCrLf & "Origen: {1}" & vbCrLf & "Método:{2}" & vbCrLf & "Detalle: {3}", s.InnerException.Message, s.InnerException.Source, s.InnerException.TargetSite.ToString, s.InnerException.StackTrace)
        End If
      End If
      Bitacora(sAccion, remote_addr, user)
    Catch ex As Exception
    End Try
  End Sub

  Public Shared Sub Bitacora(ByVal accion As String, ByVal maquina As String, ByVal usuario As String, Optional ByVal folio As String = "")
    Dim bitBL As New bitacoraBL()
    Dim bit As bitacora = New bitacora()

    bit.usuario = usuario
    bit.maquina = maquina
    bit.fecha = Now
    bit.accion = accion
    bit.folio = folio
    bit.corte = New Date(1900, 1, 1)
    bit.llave = Left(accion, 3)
    bit.void = False

    Try
      bitBL.CreaBitacora(bit)
      If bitBL.hayErr Then Throw bitBL.Err
    Catch ex As Exception
      Throw ex
    Finally
      If bitBL IsNot Nothing Then bitBL.Dispose()
      If bitBL IsNot Nothing Then bitBL = Nothing
      If bit IsNot Nothing Then bit = Nothing
    End Try
  End Sub

  Public Shared Function CRC(ByVal Str As String) As Object
    Dim nPowers(7) As Object
    Dim nCRC = &HFFFF
    For i As Integer = 0 To 7
      nPowers(i) = 2 ^ i
    Next
    For i As Integer = 1 To Len(Str)
      Dim nByte = Asc(Mid(Str, i, 1))
      For j As Integer = 7 To 0 Step -1
        Dim nBit = CBool((nCRC And 32768) = 32768) Xor ((nByte And nPowers(j)) = nPowers(j))
        nCRC = (nCRC And 32767) * 2
        If nBit Then
          nCRC = nCRC Xor 4129
        End If
      Next
    Next
    CRC = nCRC
  End Function

  Public Shared Function SerializaJSon(Of Tipo)(ByVal objeto As Tipo) As String
    Dim stream As New MemoryStream()
    Dim ds As New DataContractJsonSerializer(GetType(Tipo))
    ds.WriteObject(stream, objeto)
    Dim jsonString As String = Encoding.UTF8.GetString(stream.ToArray())
    stream.Close()
    Return jsonString
  End Function

  Public Shared Function GlobalSerializationSettings() As Newtonsoft.Json.JsonSerializerSettings
    Return Negocio.GlobalSerializationSettings
  End Function

  Public Sub Success(ByVal message As String, Optional ByVal dismisable As Boolean = False)
    AddAlert(AlertStyles.Success, message, dismisable)
  End Sub

  Public Sub Success(ByVal message As String, ByVal parm1 As Object, Optional ByVal dismisable As Boolean = False)
    AddAlert(AlertStyles.Success, String.Format(message, parm1.ToString), dismisable)
  End Sub

  Public Sub Success(ByVal message As String, ByVal parm1 As Object, ByVal parm2 As Object, Optional ByVal dismisable As Boolean = False)
    AddAlert(AlertStyles.Success, String.Format(message, parm1.ToString, parm2.ToString), dismisable)
  End Sub

  Public Sub Success(ByVal message As String, ByVal parm1 As Object, ByVal parm2 As Object, ByVal parm3 As Object, Optional ByVal dismisable As Boolean = False)
    AddAlert(AlertStyles.Success, String.Format(message, parm1.ToString, parm2.ToString, parm3.ToString), dismisable)
  End Sub

  Public Sub Success(ByVal message As String, ByVal parms() As Object, Optional ByVal dismisable As Boolean = False)
    For Each obj In parms
      message = String.Format(message, obj.ToString)
    Next
    AddAlert(AlertStyles.Success, message, dismisable)
  End Sub

  Public Sub Information(ByVal message As String, Optional ByVal dismisable As Boolean = False)
    AddAlert(AlertStyles.Information, message, dismisable)
  End Sub

  Public Sub Information(ByVal message As String, ByVal parm1 As Object, Optional ByVal dismisable As Boolean = False)
    AddAlert(AlertStyles.Information, String.Format(message, parm1.ToString), dismisable)
  End Sub

  Public Sub Information(ByVal message As String, ByVal parm1 As Object, ByVal parm2 As Object, Optional ByVal dismisable As Boolean = False)
    AddAlert(AlertStyles.Information, String.Format(message, parm1.ToString, parm2.ToString), dismisable)
  End Sub

  Public Sub Information(ByVal message As String, ByVal parm1 As Object, ByVal parm2 As Object, ByVal parm3 As Object, Optional ByVal dismisable As Boolean = False)
    AddAlert(AlertStyles.Information, String.Format(message, parm1.ToString, parm2.ToString, parm3.ToString), dismisable)
  End Sub

  Public Sub Information(ByVal message As String, ByVal parms() As Object, Optional ByVal dismisable As Boolean = False)
    For Each obj In parms
      message = String.Format(message, obj.ToString)
    Next
    AddAlert(AlertStyles.Information, message, dismisable)
  End Sub

  Public Sub Warning(ByVal message As String, Optional ByVal dismisable As Boolean = False)
    AddAlert(AlertStyles.Warning, message, dismisable)
  End Sub

  Public Sub Warning(ByVal message As String, ByVal parm1 As Object, Optional ByVal dismisable As Boolean = False)
    AddAlert(AlertStyles.Warning, String.Format(message, parm1.ToString), dismisable)
  End Sub

  Public Sub Warning(ByVal message As String, ByVal parm1 As Object, ByVal parm2 As Object, Optional ByVal dismisable As Boolean = False)
    AddAlert(AlertStyles.Warning, String.Format(message, parm1.ToString, parm2.ToString), dismisable)
  End Sub

  Public Sub Warning(ByVal message As String, ByVal parm1 As Object, ByVal parm2 As Object, ByVal parm3 As Object, Optional ByVal dismisable As Boolean = False)
    AddAlert(AlertStyles.Warning, String.Format(message, parm1.ToString, parm2.ToString, parm3.ToString), dismisable)
  End Sub

  Public Sub Warning(ByVal message As String, ByVal parms() As Object, Optional ByVal dismisable As Boolean = False)
    For Each obj In parms
      message = String.Format(message, obj.ToString)
    Next
    AddAlert(AlertStyles.Warning, message, dismisable)
  End Sub

  Public Sub Danger(ByVal message As String, Optional ByVal dismisable As Boolean = False)
    AddAlert(AlertStyles.Danger, message, dismisable)
  End Sub

  Public Sub Danger(ByVal message As String, ByVal parm1 As Object, Optional ByVal dismisable As Boolean = False)
    AddAlert(AlertStyles.Danger, String.Format(message, parm1.ToString), dismisable)
  End Sub

  Public Sub Danger(ByVal message As String, ByVal parm1 As Object, ByVal parm2 As Object, Optional ByVal dismisable As Boolean = False)
    AddAlert(AlertStyles.Danger, String.Format(message, parm1.ToString, parm2.ToString), dismisable)
  End Sub

  Public Sub Danger(ByVal message As String, ByVal parm1 As Object, ByVal parm2 As Object, ByVal parm3 As Object, Optional ByVal dismisable As Boolean = False)
    AddAlert(AlertStyles.Danger, String.Format(message, parm1.ToString, parm2.ToString, parm3.ToString), dismisable)
  End Sub

  Public Sub Danger(ByVal message As String, ByVal parms() As Object, Optional ByVal dismisable As Boolean = False)
    For Each obj In parms
      message = String.Format(message, obj.ToString)
    Next
    AddAlert(AlertStyles.Danger, message, dismisable)
  End Sub

  Private Sub AddAlert(ByVal alertStyle As String, ByVal message As String, ByVal dismissable As Boolean)
    Dim alerts = If(TempData.ContainsKey(Alert.TempDataKey), _
                    DirectCast(TempData(Alert.TempDataKey),  _
                      List(Of Alert)), New List(Of Alert)())

    alerts.Add(New Alert With
              {
                .AlertStyle = alertStyle,
                .Message = message,
                .Dismissable = dismissable
              })

    TempData(Alert.TempDataKey) = alerts
  End Sub

End Class
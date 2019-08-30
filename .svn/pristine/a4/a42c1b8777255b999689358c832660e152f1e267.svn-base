Imports FactorEntidades
Imports System.Net.Mail
Imports System.IO

Namespace mail

	Public Class sendMail

		Public Function enviarMail(mailTo As String(), subject As String, mailBody As String, Optional ByVal priority As System.Net.Mail.MailPriority = Net.Mail.MailPriority.Normal, Optional ByVal cc As String() = Nothing, Optional ByVal bcc As String() = Nothing, Optional ByVal attachments As String() = Nothing, Optional ByVal attch As Dictionary(Of String, Byte()) = Nothing) As Result

			Dim response = New Result(False)
			Dim correo As New System.Net.Mail.MailMessage
			Dim attach As System.Net.Mail.Attachment
			Dim params As parametros
			Dim credentials As String()

			Using context As New FactorContext

				params = (From a In context.parametros
						  Where a.clave = "MailCredentials"
						  Select a).SingleOrDefault()

			End Using

			credentials = params.ruta.Split("|")


			Dim smtp As New System.Net.Mail.SmtpClient(credentials(2))


			With smtp
				.Credentials = New System.Net.NetworkCredential(credentials(0), credentials(1))
				.Host = credentials(2)
				.Port = credentials(3)

				'.EnableSsl = False
			End With

			With correo
				.From = New System.Net.Mail.MailAddress(credentials(0))

				'Destinatarios
				For Each item As String In mailTo
					If item.Trim() = "" Then
						response.Mensaje = "No cuenta con correo electrónico."
						response.Ok = False
						Return response
					Else
						.To.Add(item)
					End If
				Next

				'Copia de mail
				If cc IsNot Nothing Then
					For Each item As String In cc
						.CC.Add(item)
					Next
				End If

				'Copia oculta
				If bcc IsNot Nothing Then
					For Each Item As String In bcc
						.Bcc.Add(Item)
					Next
				End If

				.Subject = subject
				.Body = mailBody
				.IsBodyHtml = True
				.Priority = priority

				'Archivos adjuntos con path 
				If attachments IsNot Nothing Then
					For Each item As String In attachments
						attach = New Attachment(item)
						.Attachments.Add(attach)
					Next
				End If

				'adjuntos en memoria 
				If attch IsNot Nothing Then
					For Each item In attch
						Dim ms = New MemoryStream(item.Value)
						attach = New Attachment(ms, item.Key)
						.Attachments.Add(attach)
					Next
				End If

			End With

			Try
				smtp.Send(correo)
				response.Ok = True
			Catch ex As Exception
				response.Detalle = ex.InnerException.InnerException.ToString()
				response.Mensaje = "Error al enviar el correo"
			End Try

			Return response
		End Function

	End Class

End Namespace
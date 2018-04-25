Imports Microsoft.AspNet.SignalR


Public Class NotificationHub
	Inherits Hub

	Public Function Activate() As String
		Return "Aguien mas se conecto a esta vista"
	End Function

	Public Sub SendMess(msg As String)
		Dim context = GlobalHost.ConnectionManager.GetHubContext(Of NotificationHub)()
		context.Clients.All.sendMessage(msg)
	End Sub

	Public Function test(msg As String) As String
		Return msg
	End Function

End Class

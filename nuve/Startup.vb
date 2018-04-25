Imports Microsoft.Owin
Imports Owin

<Assembly: OwinStartupAttribute(GetType(Startup))> 
Partial Public Class Startup
  Public Sub Configuration(ByVal app As IAppBuilder)
		ConfigureAuth(app)
		app.MapSignalR()
	End Sub

End Class

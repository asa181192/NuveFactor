Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Optimization
Imports System.Web.Routing

Public Class MvcApplication
    Inherits System.Web.HttpApplication

  Sub Application_Start()
    AreaRegistration.RegisterAllAreas()
    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
    RouteConfig.RegisterRoutes(RouteTable.Routes)
		BundleConfig.RegisterBundles(BundleTable.Bundles)

		ClientDataTypeModelValidatorProvider.ResourceClassKey = "Messages"
		DefaultModelBinder.ResourceClassKey = "Messages"

  End Sub

End Class

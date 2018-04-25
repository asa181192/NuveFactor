Imports System.Web
Imports System.Web.Optimization

Public Class BundleConfig
    ' For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
  Public Shared Sub RegisterBundles(ByVal bundles As BundleCollection)

		' **************** SCRIPTS BUNDLES ****************
		bundles.Add(New ScriptBundle("~/bundles/monthpicker").Include(
			"~/Scripts/MonthPicker.js"))

		bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
				   "~/Scripts/jquery-1.12.4.js"))

		bundles.Add(New ScriptBundle("~/bundles/priceformat").Include(
						"~/Scripts/bootstrap/js/jquery.price_format-2.0.js"))


		bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
						"~/Scripts/bootstrap/js/bootstrap-3.3.7.js"))

		bundles.Add(New ScriptBundle("~/bundles/datetimepicker").Include(
						"~/Scripts/moment.js",
						"~/Scripts/bootstrap-datetimepicker.js"))

		bundles.Add(New ScriptBundle("~/bundles/datatables").Include("~/Scripts/datatables.js"))

		bundles.Add(New ScriptBundle("~/bundles/jquery-ui").Include(
			"~/Scripts/jquery-ui-1.11.4.js"))

		bundles.Add(New ScriptBundle("~/bundles/configDataTable").Include(
			  "~/Scripts/DatatableGlobalConfig.js"))

		bundles.Add(New ScriptBundle("~/bundles/jqueryLoading").Include(
			"~/Scripts/jquery.loading.js"))

		bundles.Add(New ScriptBundle("~/bundles/validation").Include(
			"~/Scripts/jquery.validate.js",
			"~/Scripts/jquery.validate.unobtrusive.js",
			"~/Scripts/jquery.validate.messages_es.js",
			"~/Scripts/jquery.validate.mvc.js"))



    ' Use the development version of Modernizr to develop with and learn from. Then, when you're
    ' ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
		bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
					"~/Scripts/modernizr-*"))
    ' **************** SCRIPTS BUNDLES ****************


    ' **************** STYLES BUNDLES ****************
		bundles.Add(New StyleBundle("~/Content/css").Include("~/Content/site.css"))

		bundles.Add(New StyleBundle("~/Content/bootstrap").Include(
					"~/Content/bootstrap.css",
					"~/Content/bootstrap-theme.css"))

        bundles.Add(New StyleBundle("~/Content/datetimepicker").Include("~/Content/bootstrap-datetimepicker.css"))

		bundles.Add(New StyleBundle("~/Content/flexbox").Include("~/Content/flexbox/flexboxgrid-6.3.1/css/flexboxgrid.css"))

		bundles.Add(New StyleBundle("~/Content/datatables").Include("~/Content/datatables.css"))

		bundles.Add(New StyleBundle("~/Content/monthpicker").Include("~/Content/MonthPicker.css"))

		bundles.Add(New StyleBundle("~/Content/jquery-ui").Include("~/Content/jquery-ui.css"))

		bundles.Add(New StyleBundle("~/Content/responsiveDataTable").Include("~/Content/responsive.dataTables.css"))

		bundles.Add(New StyleBundle("~/Content/jqueryLoading").Include("~/Content/jquery.loading.css"))


    ' **************** STYLES BUNDLES ****************

  End Sub
End Class
@ModelType nuve.Helpers.Menu

@Code
    ViewData("Title") = "Administracion"
End Code

@section Scripts
    <script src="~/Scripts/AdminScripts/Index.js"></script>
End Section

<h2>Administracion</h2>

<div class="lead">
    <div class="ContenedorFlexbox">
        @Html.Raw(Model.sMenu)
    </div>     
</div>
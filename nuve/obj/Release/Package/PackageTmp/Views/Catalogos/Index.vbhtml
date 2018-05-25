@ModelType nuve.Helpers.Menu

@Code
    ViewData("Title") = "Catalogos"
End Code

@section Scripts
    <script src="~/Scripts/CatalogosScripts/Index.js"></script>
End Section
<h2>Catalogos</h2>

<div class="lead">
    <div class="ContenedorFlexbox">
        @Html.Raw(Model.sMenu)
    </div>
     
</div>
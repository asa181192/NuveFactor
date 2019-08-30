@ModelType nuve.Helpers.Menu

@Code
  ViewData("Title") = "Promoción"
End Code

@section scripts
    <script src="~/Scripts/PromocionScripts/Index.js"></script>
End Section

 <div class="head">
  <div class="headForma">
    <div class="headFormaContenido">
    </div>
  </div>
</div>

<h1>Promoción</h1>

<div class="lead">
    <div class="ContenedorFlexbox">
        @Html.Raw(Model.sMenu)
    </div>     
</div>

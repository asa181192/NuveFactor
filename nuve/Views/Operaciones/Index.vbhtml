@ModelType nuve.Helpers.Menu

@Code
  ViewData("Title") = "Operaciones"
End Code

@section scripts
    <script src="~/Scripts/OperacionesScripts/Index.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
End Section

 <div class="head">
  <div class="headForma">
    <div class="headFormaContenido">
    </div>
  </div>
</div>

<h1>Operaciones</h1>

<div class="lead">
    <div class="ContenedorFlexbox">
        @Html.Raw(Model.sMenu)
    </div>     
</div>



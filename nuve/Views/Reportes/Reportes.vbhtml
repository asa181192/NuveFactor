﻿@ModelType nuve.Helpers.Menu


@section Scripts
    <script src="~/Scripts/Reportes/index.js"></script>
End Section

<div class="head">
  <div class="headForma">
    <div class="headFormaContenido">
      <span>@ViewData("welcome")</span>
       
    </div>
  </div>
</div>

<h1>Factoraje</h1>

<div class="lead">   
    <div class="ContenedorFlexbox">
         @Html.Raw(Model.sMenu)
    </div> 
</div>

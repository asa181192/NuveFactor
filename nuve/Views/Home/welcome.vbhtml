﻿@ModelType nuve.Helpers.Menu


@section Scripts
    <script src="~/Scripts/HomeScripts/welcome.js"></script>
End Section

<div class="head">
  <div class="headForma">
    <div class="headFormaContenido">
      <span>@ViewData("welcome")</span>
       
    </div>
  </div>
</div>

<div class="lead">   
    <div class="ContenedorFlexbox">
         @Html.Raw(Model.sMenu)
    </div> 
</div>




   
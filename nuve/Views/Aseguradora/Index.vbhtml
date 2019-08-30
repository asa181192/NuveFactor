@ModelType nuve.Helpers.Menu


@section Scripts
    <script src="~/Scripts/Aseguradora/Index.js?v=@String.Concat(Today.Day,Today.Month,Today.Year,TimeOfDay.Hour,TimeOfDay.Minute,TimeOfDay.Second)"></script>
End Section

<div class="head">
  <div class="headForma">
    <div class="headFormaContenido">
      <span>@ViewData("welcome")</span>
       
    </div>
  </div>
</div>

<h1>Seguro de Crédito</h1>

<div class="lead">   
    <div class="ContenedorFlexbox">
         @Html.Raw(Model.sMenu)
    </div> 
</div>




   
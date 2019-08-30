@ModelType nuve.Models.ModeloInformes

@Code
  ViewData("Title") = "Factor - Informes"
End Code

@Section Scripts
  <script src="~/Scripts/Reportes/Informes.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
End Section

<div class="head">
  <div class="headForma">
    <div class="headFormaContenido">
      <a href="~/Home/Welcome">
        <img src="~/Images/menu/menuregresar.png" /></a>
      <span>Informes</span>
    </div>
  </div>
</div>

<div id="tableContainer" class="tableContainer">

  <div class="panel-body">
    <div class="jumbotron">
      <div class="table-responsive">
        <table id="table" class="table cell-border compact hover" style="width: 100%">

          <thead>
            <tr>
              <th>
                @Html.DisplayNameFor(Function(model) model.modulo)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.descripcion)
              </th>
              <th>
              </th>
            </tr>
          </thead>
        </table>
      </div>
    </div>
  </div>
</div>


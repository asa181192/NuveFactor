@ModelType nuve.Models.ModeloConsolida

@Code
  ViewData("Title") = "Bitácora"
End Code

@Section Scripts
    <script src="~/Scripts/ConsolidaScripts/bitacora.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
    <script src="~/Scripts/duDatepicker.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/js-cookie@2/src/js.cookie.min.js"></script>
End Section

@Section Css
    <link rel="stylesheet" href="~/Content/duDatepicker.css" />
End Section

<div class="head">
  <div class="headForma">
    <div class="headFormaContenido">
      <a href="~/Operaciones/Index">
        <img src="~/Images/menu/menuregresar.png" /></a>
      <span>Bitácora de Consolidaciones</span>
    </div>
  </div>
</div>


<div id="tableContainer" class="tableContainer">
  <div class="panel-heading">
    <div class="topmargin">
      <div class="form-inline">
        <div class="form-group">

          @Html.Label("Seleccionar fecha : ", New With {.class = "control-label"})
          <div class="form-group materail-input-block materail-input-block_primary">
            <input id="fecha" class='materail-input' type="text" autocomplete="off" />
          </div>

          <input type="button" id="Actualizar" value="Actualizar" class="btn bold" style="margin-right: 10px" />
        </div>

   @*     <div class="form-group">
          
          <input type="button" value="Descargar" class="excel btn material-btn main-container__column" style="margin-left: 600px" />
        </div>*@

      </div>

    </div>
  </div>
  <div class="panel-body">
    <div class="">
      <div class="table-responsive">
        <table id="table" class="table cell-border compact hover" style="width: 100%">
          <thead>
            <tr>
              <th>@Html.DisplayNameFor(Function(model) model.tfecha)
              </th>
              <th>@Html.DisplayNameFor(Function(model) model.archivo)
              </th>
              <th>@Html.DisplayNameFor(Function(model) model.resultado)
              </th>
              <th>@Html.DisplayNameFor(Function(model) model.exito)
              </th>
            </tr>
          </thead>
        </table>
      </div>
    </div>
  </div>
</div>
<div id="dialog-confirm" title="" style="display: none">
    <p>
        <span class="glyphicon glyphicon-remove" style="float: left; margin: 12px 12px 20px 0;"></span>
    </p>
</div>

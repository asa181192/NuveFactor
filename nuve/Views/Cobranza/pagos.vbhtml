﻿@ModelType nuve.Models.Modeloadeudos

@Code
  ViewData("Title") = "Factoraje - Pagos de adeudos"
End Code

@Section Scripts
  <script src="~/Scripts/CobranzaScripts/pagos.js"></script>
End Section

<div class="head">
  <div class="headForma">
    <div class="headFormaContenido">
      <a href="~/Cobranza/Index">
        <img src="~/Images/menu/menuregresar.png" /></a>
      <span>Pagos de adeudos</span>
    </div>
  </div>
</div>

<div id="tableContainer" class="tableContainer">
  <div class="panel-heading">
    <div class="topmargin">
      <div class="form-inline">
        <div class="form-group">
          @Html.Label("Fecha:")
          <input id="fecInicio" class='form-control' type="text" />
        </div>

@*        <div class="form-group">
          <button id="btnConsultar" type="button" class="btn bold">Consultar</button>
        </div>*@

        @*<button id="btnConsultar" type="button" class="btn bold">Consultar</button>*@
      </div>
      <p>
        @*@Html.ActionLink("Nuevo Registro", "GuardarParidad", New With {.fecha = Nothing},New With{.Class="popup btn bold"})*@
      </p>

    </div>
  </div>
  <div class="panel panel-default material-panel">
    <div class="panel-body material-panel__body">
      <div class="table-responsive">
        <table id="tablaprincipal" class="table cell-border compact hover" style="width: 100%">
          <thead>
            <tr>
                <th>
                @Html.DisplayNameFor(Function(model) model.fecha)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.numrec)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.Adeudo)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.monedaStr)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.movto)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.contrato)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.Nombre)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.concepto)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.importe)
              </th>
              <th>
               @Html.DisplayNameFor(Function(model) model.referencia)
              </th>

            </tr>
          </thead>
        </table>
      </div>
    </div>
  </div>
</div>

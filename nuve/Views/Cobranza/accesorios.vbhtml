﻿@ModelType nuve.Models.ModeloMonitorlineas

@Code
  ViewData("Title") = "Factoraje - Accesorios"
End Code


@Section Scripts
   @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.COBRANZA_ACTUALIZAR) Then
    @<script src="~/Scripts/CobranzaScripts/Accesorios.js"></script>
     Else
     @<script src="~/Scripts/CobranzaScripts/AccesoriosRonly.js"></script>
     End If 
End Section


<div class="head">
  <div class="headForma">
    <div class="headFormaContenido">
      <a href="~/Cobranza/Index">
        <img src="~/Images/menu/menuregresar.png" /></a>
      <span>Accesorios</span>
    </div>
  </div>
</div>

<div id="tableContainer" class="tableContainer">
  <div class="panel-heading">
    <div class="topmargin">
      <div class="form-inline">
        <div class="form-group">
          @*@Html.Label("Seleccionar mes : ")*@
          @*<input id="month" class='month-year-input' type="text"/>*@
        </div>
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
        <table id="tabla" class="table cell-border compact hover" style="width: 100%">
          <thead>
            <tr>
              <th>
                @Html.DisplayNameFor(Function(model) model.contrato)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.nombre)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.Tinteres)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.producto)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.divisa)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.linea)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.cartera)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.vencida)
              </th>

              <th>
                @Html.DisplayNameFor(Function(model) model.adeudo)
              </th>

              <th>
                @Html.DisplayNameFor(Function(model) model.moratorio)
              </th>
              
                
                @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.COBRANZA_ACTUALIZAR) Then
                @<th>
              </th>
                End If 


              <th>
                @Html.DisplayNameFor(Function(model) model.iv)
              </th>

                              @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.COBRANZA_ACTUALIZAR) Then
                @<th>
              </th>
                End If 

              <th>
                @Html.DisplayNameFor(Function(model) model.imv)
              </th>
              
              @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.COBRANZA_ACTUALIZAR) Then
              @<th>
              </th>
              End If 

              <th>
                @Html.DisplayNameFor(Function(model) model.total)
              </th>

            </tr>
          </thead>
        </table>
      </div>
    </div>
  </div>
</div>

@*<div id="dialog-confirm" title="" style="display: none">
  <p>
    <span class="glyphicon glyphicon-remove" style="float: left; margin: 12px 12px 20px 0;"></span>
  </p>
</div>*@


<div id="dialog-confirm" title="" style="display: none">
  <p>
    <span class="glyphicon glyphicon-remove" style="float: left; margin: 12px 12px 20px 0;"></span>
  </p>
</div>

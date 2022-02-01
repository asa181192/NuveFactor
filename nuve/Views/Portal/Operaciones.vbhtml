﻿@ModelType nuve.portal.operacionesModel

@Code
    ViewData("Title") = "Operaciones"
End Code

@Section Scripts
    <script src="~/Scripts/PortalScripts/operaciones.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
    <script src="~/Scripts/duDatepicker.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/js-cookie@2/src/js.cookie.min.js"></script>
End Section

@Section Css
    <link rel="stylesheet" href="~/Content/duDatepicker.css" />
End Section

<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="@Request.UrlReferrer.ToString()">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Operaciones</span>
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
        </div>
          <input type="button" value="Descargar" class="excel btn material-btn main-container__column" style="margin-left: 600px" />
        </div>

        </div>
    </div>
    <div class="panel-body">
        <div class="jumbotron">
            <div class="table-responsive">
                <table id="table" class="table cell-border compact hover" style="width: 100%">
                    <thead>
                        <tr>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.folio)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.fecha)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.contrato)
                            </th>
                            <th>Beneficiario
                            </th>
                            <th>Cálculo
                            </th>
                            <th>CFDI
                            </th>
                            <th>Pagado
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
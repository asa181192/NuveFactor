﻿@ModelType nuve.Models.Contrato_Cliente

@Code
    ViewData("Title") = "Contratos"
End Code

@Section Scripts
    <script src="~/Scripts/CatalogosScripts/Contratos.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
End Section

<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="@Request.UrlReferrer.ToString()">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Contratos @Model.Cliente.nombre (@Model.Contrato.cliente)</span>
        </div>
    </div>
</div>

@Html.HiddenFor(Function(model) model.Contrato.cliente)

<div id="tableContainer" class="tableContainer">
    <div class="panel-heading">
        <div class="topmargin">
            @Html.ActionLink("Nuevo Registro", "GuardarContrato", New With {.contratoId = 0, .clienteId = Model.Contrato.cliente}, New With {.Class = "popup btn bold"})
            @Html.ActionLink("Anexo", "Anexo", New With {.contrato = "_contrato", .producto = "_producto", .nombrecte = Model.Cliente.nombre}, New With {.Class = "popup btn bold disabled", .id = "anexo"})
            @Html.ActionLink("Cesiones", "Cesiones", New With {.contrato = "_contrato", .producto = "_producto", .clienteNombre = Model.Cliente.nombre,.cliente=Model.Cliente.cliente}, New With {.Class = "btn bold disabled", .id = "cesion"})
            @Html.ActionLink("Aforos", "Aforos", "Cobranza", New With {.contrato = "_contrato"}, New With {.Class = "btn bold disabled", .id = "aforo"})
            @Html.ActionLink("Adeudos", "adeudos", "Cobranza", New With {.contrato = "_contrato"}, New With {.Class = "btn bold disabled", .id = "adeudo"})
            @Html.ActionLink("Edo. Cuenta", "estadocta", "Cobranza", New With {.contrato = "_contrato"}, New With {.Class = "btn bold disabled", .id = "cuenta"})
            @Html.ActionLink("Cartera vencida", "carteravencida", "Cobranza", New With {.contrato = "_contrato" , .cliente = Model.Cliente.nombre}, New With {.Class = "btn bold disabled", .id = "cartera"})
        </div>
    </div>
    <div class="panel-body">
        <div class="jumbotron">
            <div class="table-responsive">
                <table id="table" class="table cell-border compact hover" style="width: 100%">
                    <thead>
                        <tr>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Contrato.contrato)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Contrato.producto)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Contrato.moneda)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Contrato.linea)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Contrato.altalinea)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Contrato.vencelinea)
                            </th>
                            <th>Estatus
                            </th>
                            <th>Baja
                            </th>
                            <th>Consulta
                            </th>
                            <th>id
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

﻿@ModelType nuve.Models.Modeloedocuenta

@Code
    ViewData("Title") = "Factoraje - Estado de cuenta"
End Code

@Section Scripts
    <script src="~/Scripts/CobranzaScripts/estadocta.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.5.2/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.36/pdfmake.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.36/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.5.2/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/fixedheader/3.1.5/js/dataTables.fixedHeader.min.js"></script>
End Section


<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="~/Cobranza/Index">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Estado de cuenta</span>
        </div>
    </div>
</div>

<div id="tableContainer" class="tableContainer">
    <div class="panel-heading">
        <div class="topmargin">


            <div class="form-inline" style="width: 100%">

                @If Model.contrato > 0 Then
                    @<div class="form-group" style="visibility: hidden">
                        @Html.Label("Contrato:")
                        <input id="contrato" value="@Model.contrato" class='contrato form-control' type="text" />
                    </div>
                    @<br />
                Else
                    @<div class="form-group">
                        @Html.Label("Contrato:")
                        <input value="0" class='contrato form-control' type="text" />
                    </div>
                End If

                <div class="form-group" )>
                    @Html.Label("Seleccionar mes : ", New With {.class = "control-label"})
                    <input id="month" class='month-year-input form-control' type="text" autocomplete="off" />
                </div>
                <div class="form-group">
                    <button id="btnConsultar" type="button" class="btn bold">Consultar</button>
                </div>
            </div>


            <br>
        </div>
    </div>
    <div class="panel panel-default material-panel">
        <div class="panel-body material-panel__body">
            <div class="table-responsive">
                <table id="tablaprincipal" class="table cell-border compact hover" style="width: 100%">

                    <thead>

                        <tr>
                            <div class="form-inline">
                                <div class="form-group">
                                    <label>Contrato: </label>
                                    <label id="cont" />
                                </div>

                                <div class="form-group">
                                    <label id="nom" />
                                </div>

                            </div>

                            <div class="form-inline">
                                <div class="form-group">
                                    <label>Línea: </label>
                                    <label id="linea" />
                                </div>

                                <div class="form-group">
                                    <label id="monedastr" />
                                </div>

                            </div>

                        </tr>
                        <tr>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.fecha)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.concepto)
                            </th>
                            <th style="text-align: right">
                                @Html.DisplayNameFor(Function(model) model.ant_debe)
                            </th>
                            <th style="text-align: right">
                                @Html.DisplayNameFor(Function(model) model.ant_haber)
                            </th>
                            <th style="text-align: right">
                                @Html.DisplayNameFor(Function(model) model.ant_saldo)
                            </th>
                            <th style="text-align: right">
                                @Html.DisplayNameFor(Function(model) model.car_debe)
                            </th>
                            <th style="text-align: right">
                                @Html.DisplayNameFor(Function(model) model.car_haber)
                            </th>
                            <th style="text-align: right">
                                @Html.DisplayNameFor(Function(model) model.car_saldo)
                            </th>


                        </tr>
                    </thead>

                    <tfoot>
                        <tr>
                            <th colspan="4" style="text-align: right">Disponible: </th>

                            <th style="text-align: right">
                                <label id="dispo" />
                            </th>

                            <th colspan="3"></th>

                        </tr>

                    </tfoot>
                </table>
            </div>
        </div>
    </div>
</div>


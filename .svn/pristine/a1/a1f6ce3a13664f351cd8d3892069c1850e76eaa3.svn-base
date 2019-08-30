@modeltype nuve.Facturacion.FacturacionModel

@Code
    ViewData("Title") = "Complementos"
End Code


@Section Scripts
    <script src="~/Scripts/OperacionesScripts/Complemento.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)">></script>  
    <script src="~/Scripts/dataTables.rowGroup.min.js"></script>
End Section

<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="~/Facturacion/Index">
                <img src="~/Images/menu/menuregresar.png" />
            </a>
            <span>Complementos fiscales</span>
        </div>
    </div>
</div>

<div id="tableContainer" class="tableContainer">
    <div class="panel-heading">
        <div class="topmargin">
            <div class="form-inline">

                <div class="form-group">
                    <div class="form-group">
                        <label class="bold">Fecha de inicio:</label>
                        @Html.TextBoxFor(Function(model) model.fecha, New With {.class = "form-control", .style = "width:78px;"})
                    </div>
                    <div class="form-group">
                        @code
                            Dim lista = New List(Of SelectListItem)({
                                                                    New SelectListItem() With {.Text = "Complemento pago", .Value = 1},
                                                                    New SelectListItem() With {.Text = "Complemento cartera", .Value = 2}
                                                                    }).ToList()
                        End Code


                        @Html.DropDownListFor(Function(model) model.serie, lista, New With {.Class = "form-control dropdown", .style = "width:200px"})
                    </div>
                </div>
                 <a id="btnMasivo" href="../Facturacion/EnvioMasivo" style="float:right" class="btn material-btn main-container__column">Envio masivo</a>
            </div>
        </div>
        <div class="panel-body material-panel__body">
            <div class="">
                <div class="table-responsive">
                    <table id="table" class="table cell-border compact hover" style="width: 100%">
                        <thead>
                            <tr>
                                <th>
                                    @Html.DisplayNameFor(Function(model) model.fecha)
                                </th>
                                <th>
                                    @Html.DisplayNameFor(Function(model) model.idfiscalpf)
                                </th>
                                <th>
                                    @Html.DisplayNameFor(Function(model) model.ssat)
                                </th>
                                <th>
                                    @Html.DisplayNameFor(Function(model) model.sat)
                                </th>
                                <th>
                                    @Html.DisplayNameFor(Function(model) model.contrato)
                                </th>
                                <th>
                                    @Html.DisplayNameFor(Function(model) model.nombre)
                                </th>
                                 <th>
                                    @Html.DisplayNameFor(Function(model) model.email)
                                </th>
                                <th>
                                    @Html.DisplayNameFor(Function(model) model.importe)
                                </th>
                                <th>
                                    @Html.DisplayNameFor(Function(model) model.divisa)
                                </th>
                                <th>
                                    @Html.Label("PDF", New With {.class = "bold"})
                                </th>
                                <th>
                                    @Html.Label("XML", New With {.class = "bold"})
                                </th>
                                  <th>
                                     @Html.Label("Enviado", New With {.class = "bold"})
                                </th>
                                   <th>
                                     @Html.Label("Enviar", New With {.class = "bold"})
                                </th>
                            </tr>
                        </thead>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>
<div id="dialog-confirm" title="" style="display: none">
    <p>
        <span class="glyphicon glyphicon-warning-sign" style="float: left; margin: 12px 12px 20px 0;"></span>
        <label id="mensaje"></label>
    </p>
</div>
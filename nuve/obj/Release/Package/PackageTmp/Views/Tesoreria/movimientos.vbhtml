@modeltype nuve.TesoreriaModel.MovimientosModels

@Code
    ViewData("Title") = "movimientos"
End Code

<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="~/Tesoreria/index">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Movimientos</span>
        </div>
    </div>
</div>

@section scripts
    <script src="~/Scripts/TesoScripts/movimientos.js"></script>
End Section

<div id="tableContainer" class="tableContainer">
    <div class="panel-heading">
        <div class="topmargin">
            <div class="form-inline">
                <div class="form-group">
                    @Html.Label("Fecha de inicio:")
                    <input id="fecInicio" class='form-control' type="text"/>
                </div>
                &nbsp;
                <div class="form-group">
                    @Html.Label("Cuenta:")
                    @Html.DropDownListFor(Function(Model) Model.idctabanco, Model.cuentasDropDownList, New With {.Class = "form-control dropdown"})
                </div>
                &nbsp;
                <div class="form-group">
                   <button id="btnConsultar" type="button" class="btn bold">Consultar</button>
                </div>                
            </div>
            <br />
            <div class="form-inline">
                <div class="form-group">
                    <a>
                        @Html.ActionLink("Traspasos", "ObtenerDetalleMovimiento", New With {.numrec = 0, .folio = 0, .tipo = "TR"}, New With {.Class = "popup btn bold", .id = "btnTraspaso"})
                    </a>
                </div>
                <div class="form-group">
                    <a>
                        @Html.ActionLink("Cargos", "ObtenerDetalleMovimiento", New With {.numrec = 0, .folio = 0, .tipo = "CA"}, New With {.Class = "popup btn bold", .id = "btnCargos"})
                    </a>
                </div>
                <div class="form-group">
                    <a>
                        @Html.ActionLink("Depositos", "ObtenerDetalleMovimiento", New With {.numrec = 0, .folio = 0, .tipo = "DE"}, New With {.Class = "popup btn bold", .id = "btnDepositos"})
                    </a>
                </div>
            </div>
        </div>
    </div>
    <div class="panel-body">
        <div class="jumbotron">
            <div class="table-responsive">
                <table id="tableMovimientos" class="table cell-border compact hover" style="width: 100%">
                    <thead>
                        <tr>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.fecha)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.folio)
                            </th>
                            <th>                                
                                @Html.DisplayNameFor(Function(model) model.tipo)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.beneficiario)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.concepto)
                            </th>
                            <th>                                
                                @Html.DisplayNameFor(Function(model) model.entrada)
                            </th>
                            <th>                                
                                @Html.DisplayNameFor(Function(model) model.salida)
                            </th>
                            <th>                                
                                @Html.DisplayNameFor(Function(model) model.saldo)
                            </th>
                            <th>
                               @Html.DisplayNameFor(Function(model) model.cancel)
                            </th>
                            <th>
                                Consultar
                            </th>
                            <th>
                                Cancelar
                            </th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
</div>

<div id="dialog-confirm" title="Cancelar Movimiento" style="display:none">
  <p><span class="glyphicon glyphicon-warning-sign" style="float:left; margin:12px 12px 20px 0;"></span>¿Desea cancelar el movimiento?</p>
</div>

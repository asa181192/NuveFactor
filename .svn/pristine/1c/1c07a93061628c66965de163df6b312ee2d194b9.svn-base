@modeltype nuve.Reportes.ReporteDepModel

@section scripts
    <script src="~/Scripts/Reportes/Tesoreria/ReporteDepositos.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
End Section

<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="~/Tesoreria/index">
                <img src="~/Images/menu/menuregresar.png" />                
            </a>
            <span>Reporte de depósitos</span>
        </div>
    </div>
</div>

<div id="tableContainer" class="tableContainer">
    <div class="panel-heading">
        <div class="topmargin">
            <div class="form-inline">
                <div class="form-group">
                    <label class="bold">Fecha</label>
                    @Html.TextBoxFor(Function(x) x.fecha, New With {.class = "form-control", .autocomplete = "off"})&nbsp;
                    <label class="bold">Cuenta</label>
                    @Html.DropDownListFor(Function(model) model.idctabanco, Model.cuentasDropDownList, New With {.Class="form-control dropdown"})
                    <a id="btnConsultar" class="btn glyphicon glyphicon-search form-inline"></a>
                </div>
            </div>
        </div>
    </div>
    <div class="panel-body">
        <div class="jumbotron">
            <div class="table-responsive">
                <table id="tableDepositos" class="table cell-border compact hover" style="width: 100%">
                    <thead>
                        <tr>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.divisa)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.folio)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.contrato)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.concepto)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.entrada)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.capital)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.general)
                            </th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th  style="text-align:right">Totales : </th>
                            <th>:</th>
                            <th></th>
                            <th></th>
                        </tr>
                    </tfoot>
                </table>
            </div>
        </div>
    </div>
</div>

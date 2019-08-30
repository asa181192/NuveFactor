@ModelType nuve.TesoreriaModel.CuentasModel

@Code
    ViewData("Title") = "Cuentas"
End Code

@Section Scripts
    <script src="~/Scripts/TesoScripts/cuentas.js"></script>
End Section


<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="~/Tesoreria/cuentasBancos">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Cuentas</span>
        </div>
    </div>
</div>

<div id="tableContainer" class="tableContainer">
    <div class="panel-heading">
        <div class="topmargin">
            <div class="form-inline">
                            

                <div class="form-group">

                    <p>
                        @Html.ActionLink("Nueva Cuenta", "ObtenerDetalleCuenta", New With {.ctaid = 0}, New With {.Class = "popup btn bold"})
                    </p>



                </div>
                &nbsp;
                <div class="form-group">
                    <label class="chBox">
                        @Html.CheckBoxFor(Function(model) model.cancelado, New With {.Class = "form-check-input checked"})
                        <span class="checkmark"></span>
                    </label>
                    @Html.Label("Cuentas cerradas")
                    @Html.ValidationMessageFor(Function(model) model.cancelado)
                </div>

            </div>
        </div>
    </div>
    <div class="panel-body">
        <div class="jumbotron">
            <div class="table-responsive">
                <table id="tableCuentas" class="table cell-border compact hover" style="width: 100%">

                    <thead>
                        <tr>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.ctabanco)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.banco)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.saldo)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.divisa)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.cancel)
                            </th>
                            <th>Editar
                            </th>

                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
</div>



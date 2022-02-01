﻿@modeltype nuve.TesoreriaModel.RegistroCuentasModel

@Code
    ViewData("Title") = "Registro de cuentas bancarias"
End Code

@section scripts
    <script src="~/Scripts/TesoScripts/RegistrosContables.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
End Section

@Html.HiddenFor(Function(model) model.deudor, New With {.values = Model.deudor})
@Html.HiddenFor(Function(model) model.identidad, New With {.values = Model.identidad})


<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="~/Tesoreria/index">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Registro de Cuentas Bancarias - [<label id="cliente" class=""></label>]</span>
        </div>
    </div>
</div>

<div id="tableContainer" class="tableContainer">
    
    <div class="panel-heading">
        <div class="topmargin">              
            <div class="form-inline">
                <div class="form-group">
                    <a>
                        @Html.ActionLink("Nueva Cuenta", "consultarCuentaBancariaDetalle", New With {.numrec = 0}, New With {.Class = "popup btn bold", .id = "btnTraspaso"})
                    </a>
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
                                @Html.DisplayNameFor(Function(model) model.id)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.cuenta)
                            </th>
                            <th>                                
                                @Html.DisplayNameFor(Function(model) model.nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.divisa)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.status)
                            </th>
                                <th>
                                @Html.DisplayNameFor(Function(model) model.clabe)
                            </th>
                            <th>                                
                                Consulta
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
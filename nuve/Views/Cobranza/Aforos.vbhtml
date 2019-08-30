@ModelType nuve.Models.ModeloAforos

@Code
    ViewData("Title") = "Aforos"
End Code

@Section Scripts
    @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.COBRANZA_ACTUALIZAR) Then
        @<script src="~/Scripts/CobranzaScripts/aforos.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
    Else
        @<script src="~/Scripts/CobranzaScripts/aforosRonly.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
    End If
    <script src="https://cdn.jsdelivr.net/npm/js-cookie@2/src/js.cookie.min.js"></script>
End Section

@Html.HiddenFor(Function(x) x.contrato)

<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="~/Cobranza/Index">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Aforos Liquidados</span>
        </div>
    </div>
</div>

<div id="tableContainer" class="tableContainer">
    <div class="panel-heading">
        <div class="topmargin">
            <div class="form-inline" style="width: 100%">
                <div class="form-group">

                    @Html.Label("Seleccionar fecha : ", New With {.class = "control-label"})
                    <div class='input-group date' id='ac_fechaDataTime'>
                        <input id="month" class='month-year-input form-control' type="text" autocomplete="off" />
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-search"></span>
                        </span>
                    </div>

                </div>

            </div>

            <div class="form-inline" style="width: 100%">
                @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.COBRANZA_ACTUALIZAR) Then
                    @Html.ActionLink("Liquidar", "AforosPorLiquidar", New with {.contrato = Model.contrato } , New With {.Class = "popup btn bold", .style = "margin-top:15px"})
                    
                End If
            </div>

        </div>
    </div>


    <div class="                                                                                                  ">
        <div class="panel-body material-panel__body">
            <div class="table-responsive">
                <table id="table" class="table cell-border compact hover" style="width: 100%">
                    <thead>
                        <tr>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.contrato)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.benef)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.importe)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.pago)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Cuenta)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.folio)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Moneda)
                            </th>
                            @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.COBRANZA_ACTUALIZAR) Then
                                @<th>Cancelar Aforo
                                </th>
                            End If
                            <th>Cálculo
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

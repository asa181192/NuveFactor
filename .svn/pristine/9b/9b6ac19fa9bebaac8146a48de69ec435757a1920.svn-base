@ModelType nuve.Models.ModeloCesion

@Code
    ViewData("Title") = "Contratos"
End Code

@Section Scripts
    <script src="~/Scripts/CatalogosScripts/Cesiones.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
End Section

<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="@Request.UrlReferrer.ToString()">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Cesiones - Contrato (@Model.contrato)  @Model.clienteNombre  @Model.cliente </span><a href="~/Scripts/DataTables-1.10.16/">~/Scripts/DataTables-1.10.16/</a>
        </div>
    </div>
</div>

@Html.HiddenFor(Function(model) model.contrato)
@Html.HiddenFor(Function(model) model.producto)
@Html.HiddenFor(Function(model) model.clienteNombre)
@Html.HiddenFor(Function(model) model.cliente)
<div id="tableContainer" class="tableContainer">
    <div class="panel-heading">
        <div class="topmargin">



            @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.CATALOGOS_ACTUALIZAR) Then
                
                @If Model.producto = 1 Then
                    @Html.ActionLink("Nueva Cesión", "CesionWzd", New With {.contrato = Model.contrato, .producto = Model.producto, .cesion = 0, .cliente = Model.cliente,.nombre = Model.clienteNombre}, New With {.Class = "popup btn bold"})           
                End If 
            End If
            
            
            
            @* @Html.ActionLink("Nuevo Registro", "GuardarContrato", New With {.contratoId = 0, .clienteId = Model.Contrato.cliente}, New With {.Class = "popup btn bold"})*@
        </div>
    </div>
    <div class="panel-body">
        <div class="">
            <div class="table-responsive">
                <table id="table" class="table cell-border compact hover" style="width: 100%">
                    <thead>
                        <tr>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.cesion)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.fec_alta)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.fec_vence)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.importe)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.totalpagar)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.cheque)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.cuenta)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.movto)
                            </th>
                            <th>Consulta
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

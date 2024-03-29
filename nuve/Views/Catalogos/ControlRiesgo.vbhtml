﻿@ModelType nuve.Models.ModeloControlRiesgo
@Code
    ViewData("Title") = "ControlRiesgo"
End Code

@Section Scripts
    <script src="~/Scripts/CatalogosScripts/ControlRiesgo.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
    <script src="~/Scripts/jquery.multi-select.js"></script>
    <script src="~/Scripts/dataTables.rowGroup.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/js-cookie@2/src/js.cookie.min.js"></script>
End Section

@Section css
    <link rel="stylesheet" href="~/Content/multi-select.css" />
End Section

<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="~/Catalogos/Clientes">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>@Model.propCliente.nombre ( @Model.propCliente.cliente ) </span>
        </div>
    </div>
</div>


<div id="tableContainer" class="tableContainer">
    @Using Html.BeginForm("GuardarControlCliente", "Catalogos", FormMethod.Post, New With {.id = "ControlRiesgoForm"})
        @Html.HiddenFor(Function(model) model.propCliente.cliente)    
        @<div class="panel-heading">
            <div class="topmargin">
                <div class="row">
                    <div class="form-inline" style="width: 100%">
                        <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                            <div class="form-group">
                                @Html.LabelFor(Function(x) x.propCliente.riesgo, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(x) x.propCliente.riesgo, "{0:N}", New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.propCliente.riesgo)
                                <span>MXN</span>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                            <div class="form-group">
                                <label class="chBox">
                                    @Html.CheckBoxFor(Function(model) model.propCliente.rgpo, New With {.Class = "form-check-input checked"})
                                    <span class="checkmark"></span>
                                </label>
                                @Html.LabelFor(Function(model) model.propCliente.rgpo, New With {.class = "form-check-label"})
                                @Html.ValidationMessageFor(Function(model) model.propCliente.rgpo)
                            </div>
                            <div class="form-group">
                                @Html.TextBoxFor(Function(x) x.propCliente.riesgogpo, "{0:N}", New With {.Class = "form-control"})
                                <span>MXN</span>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                            <div class="form-group" style="padding-right: 30px">
                                <label class="chBox">
                                    @Html.CheckBoxFor(Function(model) model.propCliente.voboreg, New With {.Class = "form-check-input checked"})
                                    <span class="checkmark"></span>
                                </label>
                                @Html.LabelFor(Function(model) model.propCliente.voboreg, New With {.class = "form-check-label"})
                                @Html.ValidationMessageFor(Function(model) model.propCliente.voboreg)
                            </div>
                            @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.CATALOGOS_CLIENTES_MESADECONTROL) Then
                                @<div class="form-group" style="padding-right: 30px">
                                    <label class="chBox">
                                        @Html.CheckBoxFor(Function(model) model.propCliente.vobo, New With {.Class = "form-check-input checked"})
                                        <span class="checkmark"></span>
                                    </label>
                                    @Html.LabelFor(Function(model) model.propCliente.vobo, New With {.class = "form-check-label"})
                                    @Html.ValidationMessageFor(Function(model) model.propCliente.vobo)
                                </div>
        End If
                        </div>
                        <div class="col-xs-12">
                            @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.CATALOGOS_ACTUALIZAR) Then
                                @<button class="btn btn-sm" style="margin-top: 20px"><b>Guardar Cambios</b></button>         
        End If
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-top: 20px">

                    @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.CATALOGOS_ACTUALIZAR) Then
                        @<div class="form-inline" style="width: 100%">
                            <div class="col-xs-12">
                                <div class="form-group" id="buttons">

                                    <a class="btn btn-default btn-sm" href="@String.Concat("../Catalogos/GuardarAsociarLineas/?ClienteId=", Model.propCliente.cliente)" role="button">Relacionar Lineas</a>
                                    <a class="btn btn-default btn-sm actualiza" href="#" role="button">Actualizar Lineas</a>
                                    <a class="btn btn-default btn-sm gliquida" href="@String.Concat("../Catalogos/GuardarGarantiaLiquida/")" role="button">Garantia Liquida</a>
                                    <a class="btn btn-default btn-sm" href="@String.Concat("../Catalogos/GuardarClienteLineas/?ClienteId=", Model.propCliente.cliente)" role="button">Agregar Cliente</a>
                                    <a class="btn btn-default btn-sm cancela" href="@String.Concat("../Catalogos/CancelarLinea/")" type="submit" role="button" >Cancelar Linea</a>
                                    <a class="btn btn-default btn-sm" href="@String.Concat("../Catalogos/DesasociarLineas/?ClienteId=", Model.propCliente.cliente)" type="submit" role="button">Desasociar Lineas</a>

                                </div>
                            </div>
                        </div>
        End If
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            @Html.Label("Tipo de cambio : ", New With {.class = "control-label" , .Style="padding-top:20px"})
                            <span class="cambio">0.0000</span>
                        </div>
                    </div>
                </div>
            </div>

        </div> 
    End Using
    <div class="panel-body" style="margin-top: -20px">
        <div class="jumbotron">
            <div class="table-responsive">
                <table id="table" class="table cell-border compact hover" style="width: 100% ">
                    <thead>
                        <tr>
                            <th>Cliente Linea
                            </th>
                            <th>DIV
                            </th>
                            <th>Infolinea
                            </th>
                            <th>Id. T24
                            </th>
                            <th>Riesgo
                            </th>
                            <th>Nombre
                            </th>
                            <th>Descripción
                            </th>
                            <th>idLM
                            </th>
                            <th>Monto
                            </th>
                            <th>Utilizado
                            </th>
                            <th>Disponible
                            </th>
                            <th>Vence
                            </th>
                            <th>MtomLM
                            </th>
                            <th>GL
                            </th>
                            <th>%
                            </th>
                            <th>Adeudo
                            </th>
                            <th>Vencida
                            </th>
                            <th>Cta. Garantia
                            </th>
                            <th>Cta. GarSdo
                            </th>
                            <th>Util Garantia
                            </th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
        <a id="Reporte" class="btn btn-default btn-sm" style="float:right" href="@Url.Action("ReporteCtrlRiesgo", "Catalogos", New With {.idcliente = Model.propCliente.cliente, .nombre = Model.propCliente.nombre})" type="file" role="button">Exportar PDF</a>
    </div>
</div>


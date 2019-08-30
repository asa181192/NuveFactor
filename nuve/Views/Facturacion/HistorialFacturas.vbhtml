﻿@modeltype nuve.Facturacion.FacturacionModel



@Section Scripts

  @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.FACTURACION_ACTUALIZAR) Then
    @<script src="~/Scripts/OperacionesScripts/FacturacionScript.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)">></script>
  Else
        @<script src="~/Scripts/OperacionesScripts/FacturacionScriptRonly.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)">></script>
  End If
    
      <script src="~/Scripts/dataTables.rowGroup.min.js"></script>
End Section

<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="~/Operaciones/Index">
                <img src="~/Images/menu/menuregresar.png" />
            </a>
            <span>Histórico de documentos fiscales</span>
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
                        @Html.TextBoxFor(Function(model) model.fecha, New With {.class = "form-control", .style="width:78px;"})
                    </div>
                    <div class="form-group">
                        @Html.DropDownListFor(Function(model) model.serie, Model.serieDropDownList, New With {.Class = "form-control dropdown", .style = "width:180px"})
                    </div>
                    <div class="form-group">
                        <button id="btnConsultar" type="button" class="btn bold">Consultar</button>
                    </div>

                  
                  @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.FACTURACION_ACTUALIZAR) Then
                    @<div class="form-group">
                        <a>
                            @Html.ActionLink("Nueva", "NuevaFactura", New With {.tipo = ""}, New With {.Class = "popup btn bold", .id = "btnNueva"})
                        </a>
                    </div>
                  End If

                </div>

               @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.FACTURACION_ACTUALIZAR) Then
                    @<div class="form-group">
                <div class="form-group pull-right">
                    <div class="form-inline panel-default">
                        <div class="panel-heading">
                            <label class="bold">Facturación Electrónica</label>
                            <div class="form-group">
                                <label class="bold">Fecha</label>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                @Html.TextBoxFor(Function(model) model.fecha1, New With {.class = "form-control", .style = "width:100px;"})
                            </div>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="form-group">
                                @Html.ActionLink("Generar log", "Generar", New With {.fecha = Model.fecha1}, New With {.Class = "btn bold", .id = "btnGenerar"})                                
                            </div>
                        </div>

                    </div>
                </div>

            </div>
               End If
                
            <br />
            <div class="form-inline">
            </div>
        </div>
    </div>
    <div class="panel-body material-panel__body">
        <div class="">
            <div class="table-responsive">
                <table id="table" class="table cell-border compact hover" style="width: 100%">
                    <thead>
                        <tr>
                            <th>
                                @Html.Label("Detalle", New With {.class = "bold"})
                            </th>
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
                                @Html.DisplayNameFor(Function(model) model.folio)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.sisfol)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.contrato)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.importe)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.cancel)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.generated)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.divisa)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.sustituir)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.distrib)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.emision)
                            </th>
                            <th>
                                @Html.Label("PDF", New With {.class = "bold"})
                            </th>
                            <th>
                                @Html.Label("XML", New With {.class = "bold"})
                            </th>

                          @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.FACTURACION_ACTUALIZAR) Then
                            @<th>
                                @Html.Label("Cancelar", New With {.class = "bold"})
                            </th>
                          End if                          

                          @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.FACTURACION_ACTUALIZAR) Then
                            @<th>
                                @Html.Label("Sustituir", New With {.class = "bold"})
                            </th>
                          End If 

                        </tr>
                    </thead>
                </table>
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

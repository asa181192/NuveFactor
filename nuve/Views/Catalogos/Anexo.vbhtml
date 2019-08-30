﻿@ModelType nuve.Models.ModeloAnexoVM

@Code
    ViewData("Title") = "Anexo"
End Code

@Section Scripts
    <script src="~/Scripts/CatalogosScripts/Anexo.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
    <script src="https://cdn.jsdelivr.net/npm/js-cookie@2/src/js.cookie.min.js"></script>
End Section

<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="@(Request.UrlReferrer.ToString())">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Anexo -  Contrato (@Model.Anexo.contrato) @Model.nombrecte  </span>
        </div>
    </div>
</div>

@Html.HiddenFor(Function(model) model.Producto)
@Html.HiddenFor(Function(model) model.Anexo.contrato)

<div id="tableContainer" class="tableContainer">
    <div class="panel-heading">
        <div class="topmargin">
            @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.CATALOGOS_ACTUALIZAR) Then
                @Html.ActionLink("Nuevo Registro", "GuardarAnexo", New With {.Deudor = 0 ,.Producto =  model.Producto , .contrato = Model.Anexo.contrato}, New With {.Class = "popup btn bold"})           
            End If
        
            <a id="Reporte" class="btn bold" style="float:right" href="@Url.Action("PrintAnexo", "Catalogos", New With {.contrato = Model.Anexo.contrato})" type="file" role="button">Anexo</a>

@*            @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.CATALOGOS_ACTUALIZAR) Then
                @Html.ActionLink("Imprimir", "PrintAnexo", New With {.contrato = Model.Anexo.contrato}, New With {.Class = "popup btn bold"})           
            End If*@
        
          </div>
    </div>


    <div class="panel-body">
        <div class="">
            <div class="table-responsive">
                <table id="table" class="table cell-border compact hover" style="width: 100%">
                    <thead>
                        <tr>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Anexo.deudor)
                            </th>
                            <th>
                                Nombre
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Anexo.activo)
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



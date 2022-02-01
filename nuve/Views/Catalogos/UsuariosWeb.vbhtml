﻿@ModelType nuve.Models.ModeloUsuarioWeb

@Code
    ViewData("Title") = "Usuarios Web"
End Code

@Section Scripts
    <script src="~/Scripts/CatalogosScripts/UsuarioWeb.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
    <script src="~/Scripts/duDatepicker.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.5.2/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.36/pdfmake.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.36/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.5.2/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/fixedheader/3.1.5/js/dataTables.fixedHeader.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/js-cookie@2/src/js.cookie.min.js"></script>
End Section

@Section Css
    <link rel="stylesheet" href="~/Content/duDatepicker.css" />
End Section

<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="~/Catalogos/Index">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>
                @If (Model.identidad = 1) Then
                    @("Cliente " + Model.nombre + " (" + Model.Clave.ToString() + ")")
               
                Else
                    @("Proveedor " + Model.nombre + " (" + Model.Clave.ToString() + ")")
                End If
            </span>
        </div>
    </div>
</div>

@Html.HiddenFor(Function(model) model.identidad)
@Html.HiddenFor(Function(model) model.Clave)


<div id="tableContainer" class="tableContainer">
    <div class="panel-heading">
        <div class="topmargin">
            <p>
                @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.CATALOGOS_ACTUALIZAR) Then
                    @Html.ActionLink("Nuevo Registro", "GuardarUsuarioWeb", New With {.folio = Model.folio, .id = Model.Clave, .identidad = Model.identidad}, New With {.Class = "popup btn material-btn main-container__column"})
                End If

                <a id="Reporte" class="btn" style="float:right" href="@Url.Action("PrintUsersWeb", "Catalogos", New With {.id = Model.Clave, .identidad = Model.identidad})" type="file" role="button">Solicitud</a>     
            </p>

        </div>
    </div>
    <div class="panel-body">
        <div class="jumbotron">
            <div class="table-responsive">
                <table id="table" class="table cell-border compact hover" style="width: 100%">

                    <thead>
                        <tr>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.username)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.activo)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.fec_alta)
                            </th>
                            <th>Consulta
                            </th>
                            <th>Password
                            </th>
                            <th>Bitacora
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
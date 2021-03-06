﻿@ModelType nuve.AdminModels.ModeloUsuario

@Code
    ViewData("Title") = "Clientes"
End Code

@Section Scripts
    <script src="~/Scripts/AdminScripts/Usuarios.js?v=@String.Concat(Today.Day,Today.Month,Today.Year,TimeOfDay.Hour,TimeOfDay.Minute,TimeOfDay.Second)"></script>
End Section

<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="~/Admin/Index">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Usuarios</span>
        </div>
    </div>
</div>

<div id="tableContainer" class="tableContainer">
    <div class="panel-heading">
        <div class="topmargin">
            @Html.ActionLink("Nuevo Registro", "GuardarUsuario", New With {.id = 0}, New With {.Class = "popup btn bold"})
        </div>
    </div>
    <div class="panel-body">
        <div class="jumbotron">
            <div class="table-responsive">
                <table id="table" class="table cell-border compact hover" style="width: 100%">
                    <thead>
                        <tr>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.userid)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.puesto)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.activo)
                            </th>
                            <th>Reset PW
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



<div id="dialog-confirm" title="" style="display: none">
    <p>
        <span class="glyphicon glyphicon-remove" style="float: left; margin: 12px 12px 20px 0;"></span>
    </p>
</div>

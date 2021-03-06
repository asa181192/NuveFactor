﻿@Code
    ViewData("Title") = "Soporte del Sistema"
End Code

@section scripts

    <script src="~/Scripts/HomeScripts/version.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
    <script src="~/Scripts/duDatepicker.js"></script>
End Section
@Section Css
    <link rel="stylesheet" href="~/Content/duDatepicker.css" />
End Section
<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="../home/welcome">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Actualizaciones</span>
        </div>
    </div>
</div>
<div class="container topmargin">
    @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.ADMINISTRACION_ACTUALIZAR) Then
        @<a href="../home/guardarVersion" class="versionPopUp btn material-btn main-container__column " style="margin-bottom: 20px">Agregar Version</a>
    End If
    <div class="panel panel-default material-panel">
        <div class="panel-body material-panel__body">
            <div class="main-container__column">
                <div class="panel-body">
                    <div class="table-responsive">
                        <table id="table" class="table cell-border compact hover" style="width: 100%">
                            <thead>
                                <tr>
                                    <th>Version
                                    </th>
                                    <th>Fecha
                                    </th>
                                    <th>Revisar
                                    </th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>


@Code
    ViewData("Title") = "carteravencida"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@Section Scripts
    <script src="~/Scripts/CobranzaScripts/carteravencida.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
    <script src="~/Scripts/jquery.multi-select.js"></script>
    <script src="~/Scripts/dataTables.rowGroup.min.js"></script>
End Section

@Html.Hidden("contrato", ViewBag.contrato)

<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="@(Request.UrlReferrer.ToString())">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>CARTERA VENCIDA - @ViewBag.nombre (@ViewBag.contrato) </span>
        </div>
    </div>
</div>


<div id="tableContainer" class="tableContainer">
    <div class="panel panel-default material-panel">
        <div class="panel-body material-panel__body">
            <div class="main-container__column">
            </div>
        </div>
    </div>


    <div class="panel-body">
        @Html.ActionLink("PDF", "ReporteCarteraVencida", "Reportes", New With {.tipo = "pdf", .contrato = ViewBag.contrato, .nombre = ViewBag.nombre}, New With {.class = "btn bold"})
        @Html.ActionLink("EXCEL", "ReporteCarteraVencida", "Reportes", New With {.tipo = "excel", .contrato = ViewBag.contrato, .nombre = ViewBag.nombre}, New With {.class = "btn bold"})
        <div class="jumbotron" style="margin-top: 20px">
            <div class="table-responsive">
                <table id="table" class="table cell-border compact hover" style="width: 100%">
                    <thead>
                        <tr>
                            <th>Contrato 
                            </th>
                            <th>Deudor 
                            </th>
                            <th>Nombre
                            </th>
                            <th>Docto
                            </th>
                            <th>Saldo
                            </th>
                            <th>Vecimiento 
                            </th>
                            <th>Plazo
                            </th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
</div>

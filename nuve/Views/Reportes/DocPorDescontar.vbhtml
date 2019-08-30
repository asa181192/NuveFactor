@Code
    ViewData("Title") = "ReporteDocPorDescontar"
End Code


@section scripts
        <script src="~/Scripts/Reportes/DocsPorDescontar.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
        <script src="https://cdn.jsdelivr.net/npm/js-cookie@2/src/js.cookie.min.js"></script>
End Section


<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="~/Reportes/Informes">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Documentos por descontar</span>
        </div>
    </div>
</div>



<div class="panel panel-default">
    <div class="panel-body">

        <div>
            <div>
                <label class="rdButton" />
                <input id="global" class="form-check-input" type="radio" name="reporte" value="GLOBAL" checked="checked" /><label>Todos los contratos</label><br />
                <input id="rango" class="form-check-input" type="radio" name="reporte" value="" /><label> Contrato especifico: </label>
            </div>
        </div>

        <div class="form-froup col-sm-12" id="rangoFechas">

            <div class="form-inline col-sm-12">     
                  <label class="col-sm-1">clave contrato : </label>          
                <input id="contrato" class="col-sm-2 form-control" readonly="true" autocomplete="off" />
                <label class="col-sm-9"></label>
            </div>

            <div class="form-inline col-sm-12">
                <label class="col-sm-1">Nombre : </label>
                <input id="nombre" class="col-sm-2 form-control" readonly="true" autocomplete="off" />
                <label class="col-sm-9"></label>
            </div>


        </div>

        <a class="btn btn-default btn-sm" style="float: left" href="" type="file" role="button" id="descargar" target="_blank">Exportar PDF</a>

    </div>
</div>

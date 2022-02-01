﻿@Code
  ViewData("Title") = "Informescob"
End Code

<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="~/Cobranza/Index">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Información de cobranza</span>
        </div>
    </div>
</div>

@section scripts
    <script src="~/Scripts/Reportes/Tesoreria/VencimientosNafin.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
    <script src="https://cdn.jsdelivr.net/npm/js-cookie@2/src/js.cookie.min.js"></script>
End Section



    <div class="panel panel-default">
        <div class="panel-body">

            <div>
                <div>
                    <label class="rdButton">
                    <input id="global" class="form-check-input" type="radio" name="reporte" value="GLOBAL" checked="checked" /><label>Todos los vencimientos</label><br />
                    <input id="rango" class="form-check-input" type="radio" name="reporte" value="" /><label>Rango de fechas</label>
                </div>
            </div>

            <div class="form-froup col-sm-12" id="rangoFechas">

                <div class="form-inline col-sm-12">
                    <label class="col-sm-1">Fecha incio</label>
                    <input id="FechaInicio" class="col-sm-2 form-control" readonly="true" autocomplete="off"/>
                    <label class="col-sm-9"></label>
                </div>

                <div class="form-inline col-sm-12">
                    <label class="col-sm-1">Fecha fin</label>
                    <input id="FechaFin" class="col-sm-2 form-control" readonly="true" autocomplete="off"/>
                    <label class="col-sm-9"></label>
                </div>

                <div class="form-inline col-sm-12">
                    <label class="col-sm-1">Divisa</label>
                    <select name="divisa" id="divisa" class="col-sm-3 form-control">                        
                        <option value="1">MXN</option>
                        <option value="2">DLLS</option>
                    </select>
                    <label class="col-sm-8"></label>
                </div>

            </div>            
            
            <a class="btn btn-default btn-sm" style="float:left" href="" type="file" role="button" id="descargar">Exportar PDF</a>  

        </div>
    </div>       
    


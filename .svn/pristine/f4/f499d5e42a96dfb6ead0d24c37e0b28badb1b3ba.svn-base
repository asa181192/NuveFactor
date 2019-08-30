@ModelType nuve.AseguradoraModels

@Code
    ViewData("Title") = "PolizasGlobales"
End Code

<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="~/Aseguradora/Index">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Polizas Globales</span>
        </div>
    </div>
</div>

@section scripts
    <script src="~/Scripts/Aseguradora/PolizasGlobales.js?v=@String.Concat(Today.Day,Today.Month,Today.Year,TimeOfDay.Hour,TimeOfDay.Minute,TimeOfDay.Second)"></script>
End Section

<div id="tableContainer" class="tableContainer">
    <div class="panel-heading">
        <div class="topmargin">
            <div class="form-inline">                
                <div class="form-group">
                   <a id="btnNuevo" href="../Aseguradora/ConsultaPoliza?idpoliza=0&tipo=2" class="btn bold">Nueva Póliza</a>
                </div>                
            </div>                        
        </div>
    </div>
    <div class="panel-body">
        <div class="">
            <div class="table-responsive">
                <table id="tableAseguradoras" class="table cell-border compact hover" style="width: 100%">
                    <thead>                        
                        <tr>
                            <th>
                                Nombre
                            </th>
                            <th>
                                Consultar
                            </th>
                            <th>
                                Informe
                            </th>
                            <th>
                                Asegurados(Póliza Individual)
                            </th>
                            <th>
                                Siniestros
                            </th>
                            <th>
                                Cobro de Seguro
                            </th>
                        </tr>                        
                    </thead>                    
                </table>
            </div>
        </div>
    </div>
</div>
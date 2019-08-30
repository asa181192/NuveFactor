@ModelType nuve.Helpers.Menu

@Code
    ViewData("Title") = "Aseguradoras"
End Code

@section scripts
    <script src="~/Scripts/Aseguradora/Aseguradora.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
End Section

<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="~/Aseguradora/Index">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Aseguradoras</span>
        </div>
    </div>
</div>

<div id="tableContainer" class="tableContainer">
    <div class="panel-heading">
        <div class="topmargin">
            <div class="form-inline">

                <div class="form-group">                    
                    <a id="btnNuevo" href="../Aseguradora/DetalleAseguradora?idaseguradora=0&tipo=2" class="btn form-inline bold">Nuevo</a>                    
                    <a id="btnCatalogo" class="btn form-inline bold">Catalógo</a>
                </div>
            </div>
        </div>
    </div>
    <div class="panel-body">
        <div class="">
            <div class="table-responsive">
                <table id="tablaAseguradoras" class="table cell-border compact hover" style="width: 100%">
                    <thead>
                        <tr>
                            <th>
                                Numero
                            </th>                            
                            <th>
                                Nombre
                            </th>
                            <th>
                                Consultar
                            </th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
</div>

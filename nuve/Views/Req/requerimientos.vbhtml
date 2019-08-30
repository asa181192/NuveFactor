@Code
    ViewData("Title") = "requerimientos"
End Code


<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="~/Catalogos/Index">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Requerimientos</span>
        </div>
    </div>
</div>

<div id="tableContainer" class="tableContainer">
    <div class="panel-heading">
        <div class="topmargin" >            
                   @Html.ActionLink("Nuevo Registro", "GuardarCliente", New With {.clienteId = 0},New With{.Class="popup btn bold"})        
        </div>
    </div> 
    <div class="panel-body">
            <div class="jumbotron">     
                <div class="table-responsive">        
                   <table id="table"  class ="table cell-border compact hover" style="width:100%" > 
                           <thead>
                              <tr>
                                    <th>
                                       Fecha
                                    </th>
                                    <th>
                                        N.Requerimiento
                                    </th>
                                    <th>
                                        Usuario
                                    </th>   
                                    <th>
                                        Modulo
                                    </th>   
                                    <th>
                                        Detalle 
                                    </th>   
                                    <th>
                                        Responsable
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

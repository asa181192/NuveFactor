﻿@ModelType nuve.Models.ModeloPar
                        
@Code
    ViewData("Title") = "Paridad Cambiaria"
End Code

@Section Scripts
    <script src="~/Scripts/CatalogosScripts/ParidadCambiaria.js"></script>
End Section

<div class="head">
    <div class="headForma">
      <div class="headFormaContenido">
       <a href="~/Catalogos/Index"><img src="~/Images/menu/menuregresar.png"/></a>
        <span>Paridad Cambiaria</span>
      </div>       
    </div>  
  </div>

<div id="tableContainer" class="tableContainer">
    <div class="panel-heading">
        <div class="topmargin" >
            <div class="form-inline">
                  <div class="form-group">
                    @Html.Label("Seleccionar mes : "  ,new with {.class = "control-label"})
                    <input id="month" class='month-year-input form-control' type="text" autocomplete="off"/>
                  </div>
                 @* <button id="btnConsultar" type="button" class="btn bold">Consultar</button>*@
            </div>
            <p>
                @Html.ActionLink("Nuevo Registro", "GuardarParidad", New With {.fecha = Nothing},New With{.Class="popup btn bold" , .style="margin-top:15px"})
            </p>

        </div>
    </div>
    <div class="panel-body">
            <div class="jumbotron">     
                <div class="table-responsive">        
                   <table id="tableParidad"  class ="table cell-border compact hover" style="width:100%" > 
                           <thead>
                              <tr>
                                    <th>
                                        @Html.DisplayNameFor(Function(model) model.fecha)
                                    </th>
                                    <th>
                                        @Html.DisplayNameFor(Function(model) model.paridad1)
                                    </th>
                                    <th>
                                        @Html.DisplayNameFor(Function(model) model.udis)
                                    </th> 
                                    <th>
                                        Editar
                                    </th>                                   
                              </tr>
                             </thead>
                    </table>
                 </div>     
            </div>
    </div>
</div>


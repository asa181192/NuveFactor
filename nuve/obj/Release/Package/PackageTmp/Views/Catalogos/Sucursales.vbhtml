﻿@ModelType nuve.Models.ModeloSucursal
                        
@Code
    ViewData("Title") = "Sucursales"
End Code

@Section Scripts
    <script src="~/Scripts/CatalogosScripts/Sucursal.js"></script>
End Section

<div class="head">
    <div class="headForma">
      <div class="headFormaContenido">
       <a href="~/Catalogos/Index"><img src="~/Images/menu/menuregresar.png"/></a>
        <span>Sucursales</span>
      </div>       
    </div>  
  </div>

<div id="tableContainer" class="tableContainer">
    <div class="panel-heading">
        <div class="topmargin" >
          
            <p>
                @Html.ActionLink("Nuevo Registro", "GuardarSucursal", New With {.suc = 0},New With{.Class="popup btn bold"})
            </p>

        </div>
    </div>
    <div class="panel-body">
            <div class="jumbotron">     
                <div class="table-responsive">        
                   <table id="table"  class ="table cell-border compact hover" style="width:100%" > 

                           <thead>
                              <tr>
                                    <th>
                                        @Html.DisplayNameFor(Function(model) model.sucursal1)
                                    </th>
                                    <th>
                                        @Html.DisplayNameFor(Function(model) model.abrev_suc)
                                    </th>
                                    <th>
                                        @Html.DisplayNameFor(Function(model) model.nombre)
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

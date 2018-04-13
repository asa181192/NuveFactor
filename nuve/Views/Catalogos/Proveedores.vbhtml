@ModelType nuve.Models.ModeloProveedor


@Code
    ViewData("Title") = "Proveedores"
End Code


@Section Scripts 
      <script src="/Scripts/CatalogosScripts/Proveedor.js"></script>
End Section 

<div class="head">
    <div class="headForma">
      <div class="headFormaContenido">
       <a href="~/Catalogos/Index"><img src="~/Images/menu/menuregresar.png"/></a>
        <span>Proveedores</span>
      </div>       
    </div>  
  </div>
<div id="tableContainer">
    <div class="panel-heading">
        <div class="topmargin" >
            <div class="form-inline">
                  <div class="form-group">
                       <p>
                        @Html.ActionLink("Nuevo Proveedor", "GuardarProveedor", New With {.deudor = 0},New With{.Class="popup btn bold"})
                       </p>
                  </div>
            </div>
        </div>
    </div>
    <div class="panel-body">
            <div class="jumbotron">     
                <div class="table-responsive">        
                    <table id="tableProveedor"  class ="table cell-border compact" style="width:100%">
                       <thead>
                             <tr>
                                <th>
                                    @Html.DisplayNameFor(Function(model) model.deudor)
                                </th>
                                <th>
                                    @Html.DisplayNameFor(Function(model) model.nombre)
                                </th>                          
                                <th></th>
                            </tr>
                       </thead>
                    </table>
                 </div>     
            </div>
    </div>
</div>








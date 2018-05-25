@ModelType nuve.Models.ModeloFinanciero
                        
@Code
    ViewData("Title") = "Indicadores Financieros"
End Code

@Section Scripts
    <script src="~/Scripts/CatalogosScripts/EstadosFinancieros.js"></script>
End Section

<div class="head">
    <div class="headForma">
      <div class="headFormaContenido">
       <a href="~/Catalogos/Index"><img src="~/Images/menu/menuregresar.png"/></a>
        <span>Indicadores Financieros</span>
      </div>       
    </div>  
  </div>

<div id="tableContainer" class="tableContainer">
    <div class="panel-heading">
        <div class="topmargin" >
            <div class="form-inline">
                  <div class="form-group">
                    @Html.Label("Seleccionar mes : ")
                   <input id="month" class='month-year-input' type="text"/>
                  </div>
                  <button id="btnConsultar" type="button" class="btn bold">Consultar</button>
            </div>
            <p>
                @Html.ActionLink("Nuevo Registro", "GuardarFinanciero", New With {.fecha = Nothing},New With{.Class="popup btn bold"})
            </p>

        </div>
    </div>
    <div class="panel-body">
            <div class="jumbotron">     
                <div class="table-responsive">        
                   <table id="tableFinanciero"  class ="table cell-border compact hover" style="width:100%" > 

                           <thead>
                              <tr>
                                    <th>
                                        @Html.DisplayNameFor(Function(model) model.fecha)
                                    </th>
                                    <th>
                                        @Html.DisplayNameFor(Function(model) model.cetes28)
                                    </th>
                                    <th>
                                        @Html.DisplayNameFor(Function(model) model.cetes91)
                                    </th> 
                                    <th>
                                        @Html.DisplayNameFor(Function(model) model.cpp)
                                    </th>
                                    <th>
                                        @Html.DisplayNameFor(Function(model) model.tiie)
                                    </th> 
                                    <th>
                                        @Html.DisplayNameFor(Function(model) model.tiie91)
                                    </th> 
                                    <th>
                                        @Html.DisplayNameFor(Function(model) model.tiip)
                                    </th> 
                                    <th>
                                        @Html.DisplayNameFor(Function(model) model.fondeo)
                                    </th>  
                                   <th>
                                        @Html.DisplayNameFor(Function(model) model.libor)
                                    </th>  
                                   <th>
                                        @Html.DisplayNameFor(Function(model) model.libor3m)
                                    </th>  
                                   <th>
                                        @Html.DisplayNameFor(Function(model) model.libor6m)
                                    </th>  
                                   <th>
                                        @Html.DisplayNameFor(Function(model) model.libor12m)
                                   </th>  
                                   <th>
                                        @Html.DisplayNameFor(Function(model) model.fondeousd)
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


@ModelType nuve.Models.ModeloTipoGarantia
                        
@Code
    ViewData("Title") = "Tipos de Garantia"
End Code

@Section Scripts
    <script src="~/Scripts/AdminScripts/TipoGarantia.js"></script>
End Section

<div class="head">
    <div class="headForma">
      <div class="headFormaContenido">
       <a href="~/Admin/Index"><img src="~/Images/menu/menuregresar.png"/></a>
        <span>Tipos de Garantia</span>
      </div>       
    </div>  
  </div>

<div id="tableContainer" class="tableContainer">
    <div class="panel-heading">
        <div class="topmargin" >
            <p>
                @Html.ActionLink("Nuevo Registro", "GuardarTipoGarantia", New With {.tipoid = 0},New With{.Class="popup btn bold"})
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
                                        @Html.DisplayNameFor(Function(model) model.tipoid)
                                    </th>
                                    <th>
                                        @Html.DisplayNameFor(Function(model) model.nombre)
                                    </th>
                                    <th>
                                        @Html.DisplayNameFor(Function(model) model.tip_alterno)
                                    </th>  
                                   <th>
                                        @Html.DisplayNameFor(Function(model) model.concepto)
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


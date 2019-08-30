@ModelType nuve.Models.ModeloApoderado
                        
@Code
    ViewData("Title") = "Apoderado"
End Code

@Section Scripts
    <script src="~/Scripts/CatalogosScripts/Apoderado.js?v=@String.Concat(Today.Day,Today.Month,Today.Year,TimeOfDay.Hour,TimeOfDay.Minute,TimeOfDay.Second)"></script>
    <script src="~/Scripts/chosen.jquery.js"></script>
End Section

@Section css
    <link rel="stylesheet" href="~/Content/chosen.css" />
End Section

<div class="head">
    <div class="headForma">
      <div class="headFormaContenido">
       <a href="~/Catalogos/clientes"><img src="~/Images/menu/menuregresar.png"/></a>
        <span>Apoderados Registrados De Cliente (@Model.cliente)</span>
      </div>       
    </div>  
  </div>

@Html.HiddenFor(Function(model) model.cliente)

<div id="tableContainer" class="tableContainer">
    <div class="panel-heading">
        <div class="topmargin" >            
              @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.CATALOGOS_ACTUALIZAR) Then
                   @Html.ActionLink("Nuevo Registro", "GuardarApoderado", New With {.clienteId = Model.cliente},New With{.Class="popup btn bold"})           
              End If 
        </div>
    </div> 
    <div class="panel-body">
            <div class="jumbotron">     
                <div class="table-responsive">        
                   <table id="table"  class ="table cell-border compact hover" style="width:100%" > 
                           <thead>
                              <tr>
                                    <th>
                                        @Html.DisplayNameFor(Function(model) model.apoderado)
                                    </th>
                                    <th>
                                        @Html.DisplayNameFor(Function(model) model.esapoderado)
                                    </th>
                                    <th>
                                        @Html.DisplayNameFor(Function(model) model.esobligado)
                                    </th>  
                                   <th>
                                        @Html.DisplayNameFor(Function(model) model.esaccion)
                                    </th>  
                                   <th>
                                        @Html.DisplayNameFor(Function(model) model.esdeposita)
                                    </th>  
                                    <th>
                                        Consultar
                                    </th>
                                    <th>
                                        Cancelar
                                    </th>                                                                     
                              </tr>
                             </thead>
                    </table>
                 </div>     
            </div>
    </div>
</div>


  <div id="dialog-confirm" title="Cancelar Apoderado" style="display: none">
        <p><span class="glyphicon glyphicon-warning-sign" style="float: left; margin: 12px 12px 20px 0;"></span>¿Desea cancelar el apoderado?</p>
    </div>
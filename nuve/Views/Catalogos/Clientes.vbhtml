﻿@ModelType nuve.Models.ModeloClientes
                        
@Code
    ViewData("Title") = "Clientes"
End Code

@Section Scripts
    <script src="~/Scripts/CatalogosScripts/Clientes.js?v=@String.Concat(Today.Day,Today.Month,Today.Year,TimeOfDay.Hour,TimeOfDay.Minute,TimeOfDay.Second)"></script>
End Section


<div class="head">
    <div class="headForma">
      <div class="headFormaContenido">
       <a href="~/Catalogos/Index"><img src="~/Images/menu/menuregresar.png"/></a>
        <span>Clientes</span>
      </div>       
    </div>  
  </div>

<div id="tableContainer" class="tableContainer">
    <div class="panel-heading">
        <div class="topmargin" >            
              @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.CATALOGOS_ACTUALIZAR) Then
                   @Html.ActionLink("Nuevo Registro", "GuardarCliente", New With {.clienteId = 0},New With{.Class="popup btn bold"})           
              End If  
              @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.CATALOGOS_CLIENTES) Then
                  @Html.ActionLink("Apoderado", "Apoderado", Nothing ,New With{.Class="popup btn bold disabled" , .id="Apoderado"})       
              End If
              @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.CATALOGOS_CLIENTES) Then
                  @Html.ActionLink("Contratos", "Contratos" , "Catalogos", Nothing ,New With{.Class="popup btn bold disabled" , .id="Contrato"})       
              End If
                         
              @Html.ActionLink("Ctrl. Riesgo","ControlRiesgo",Nothing,New With{.Class="btn bold disabled",.id="CtrlRiesgo"})

        </div>
    </div> 
    <div class="panel-body">
            <div class="jumbotron">     
                <div class="table-responsive">        
                   <table id="table"  class ="table cell-border compact hover" style="width:100%" > 
                           <thead>
                              <tr>
                                    <th>
                                        @Html.DisplayNameFor(Function(model) model.cliente)
                                    </th>
                                    <th>
                                        @Html.DisplayNameFor(Function(model) model.nombre)
                                    </th>
                                    <th>
                                        @Html.DisplayNameFor(Function(model) model.rfc)
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



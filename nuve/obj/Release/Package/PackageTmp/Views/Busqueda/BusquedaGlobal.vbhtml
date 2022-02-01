﻿@ModelType nuve.Models.ModeloBusqueda
@Code
    ViewData("Title") = "BusquedaGlobal"
    
End Code


@Code
    Dim value = 0
    Dim title = "Ver coincidencias"
End Code

<div style="padding-bottom:50px">
    
<div class="head">
    <div class="headForma">
      <div class="headFormaContenido">
        <span>Busqueda</span>
      </div>       
    </div>  
  </div>

<div class="EncabezadoBusquedasCl">
<label>Clientes</label>
<span class="TotalCoincidencias">@Model.ListaClientes.Count Coincidencia(s)</span>
  <a href="../Catalogos/GuardarCliente?clienteid=0">
     <img class="btnimgaclientes" src="~/Images/nuevo_verde.png"/>
 </a>
</div>

@If Model.ListaClientes.Count = 0 Then
         @<div>Sin Coincidencias</div>
ElseIf Model.ListaClientes.Count > 10 then 
   @<div class="panel-group" id="clientes" role="tablist" aria-multiselectable="true">
  <div class="panel panel-default">
    <div class="panel-heading" role="tab" id="headingcliente">
      <h4 class="panel-title">
        <a role="button" data-toggle="collapse" data-parent="#clientes" href="#clientesCollapse" aria-expanded="false" aria-controls="collapseOne">
           @title
        </a>
      </h4>
    </div>
    <div id="clientesCollapse" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingcliente">
      <div class="panel-body">
        @For Each item In Model.ListaClientes
    value = value + 1
               @<div style="padding-bottom:20px">   
                     <div>    
                        <span>
                            #@value
                            (<b>@item.cliente</b>)
                         </span> 
                        <a href="../Catalogos/GuardarCliente?clienteid=@(item.cliente)" >
                           <span class="buscarNombreClt">@item.nombre</span>
                        </a>
                        <span>R.F.C : </span>
                        <label>
                            <b>@item.rfc</b>
                         </label>
                    </div>
                    <div class="linkCobranza">
                        <a>Apoderados</a>
                        <span class="separador">·</span>
                        <a href="../Catalogos/ControlRiesgo?clienteid=@(item.cliente)&nombre=@(item.nombre)" >Control de riesgo</a>
                        <span class="separador">·</span>
                        <a>Contratos</a>
                        <span class="separador">·</span>
                        <a>Usuarios Web</a>
                    </div>
                </div>
            Next
      </div>
    </div>
  </div>
  </div>
Else
       @For Each item In Model.ListaClientes
    value = value + 1
               @<div style="padding-bottom:20px">   
                    <div>    
                        <span>
                            #@value
                            (<b>@item.cliente</b>)
                         </span> 
                        <a href="../Catalogos/GuardarCliente?clienteid=@(item.cliente)" >
                           <span class="buscarNombreClt">@item.nombre</span>
                        </a>
                        <span>R.F.C : </span>
                        <label>
                            <b>@item.rfc</b>
                        </label>
                    </div>
                    <div class="linkCobranza">
                        <a>Apoderados</a>
                        <span class="separador">·</span>
                        <a href="../Catalogos/ControlRiesgo?clienteid=@(item.cliente)&nombre=@(item.nombre)" >Control de riesgo</a>
                        <span class="separador">·</span>
                        <a>Contratos</a>
                        <span class="separador">·</span>
                        <a>Usuarios Web</a>
                    </div>
                </div>
            Next
End If
@Code
     value = 0
End Code
<hr class="separadorbusqueda"/>
<div class="EncabezadoBusquedasCl">
<label>Proveedores</label>
<span class="TotalCoincidencias">@Model.ListaProveedor.Count Coincidencia(s)</span>
  <a href="../Catalogos/GuardarProveedor?deudor=0" >
     <img class="btnimgaclientes" src="~/Images/nuevo_verde.png"/>
 </a>
</div>
@If Model.ListaProveedor.Count = 0 Then
         @<div>Sin Coincidencias</div>
ElseIf Model.ListaProveedor.Count > 10 then 
       @<div class="panel-group" id="proveedor" role="tablist" aria-multiselectable="true">
  <div class="panel panel-default">
    <div class="panel-heading" role="tab" id="headingProveedor">
      <h4 class="panel-title">
        <a role="button" data-toggle="collapse" data-parent="#proveedor" href="#proveedorCollapse" aria-expanded="false" aria-controls="collapseOne">
            @title
        </a>
      </h4>
    </div>
    <div id="proveedorCollapse" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingProveedor">
      <div class="panel-body">
        @For Each item In Model.ListaProveedor
            value = value+1
               @<div style="padding-bottom:20px">   
                     <div>    
                        <span>
                            #@value
                            (<b>@item.deudor</b>)
                         </span> 
                        <a href="../Catalogos/GuardarProveedor?deudor=@(item.deudor)" >
                            <span class="buscarNombreClt">@item.nombre</span>
                        </a>
                        <span>R.F.C : </span>
                        <label>
                            <b>@item.rfc</b>
                         </label>
                    </div>
                </div>
            Next
      </div>
    </div>
  </div>
</div>
Else
    @For Each item In Model.ListaProveedor
    value = value + 1
               @<div style="padding-bottom:20px">   
                     <div>    
                        <span>
                            #@value
                            (<b>@item.deudor</b>)
                         </span> 
                        <a href="../Catalogos/GuardarProveedor?deudor=@(item.deudor)" >
                            <span class="buscarNombreClt">@item.nombre</span>
                        </a>
                        <span>R.F.C : </span>
                        <label>
                            <b>@item.rfc</b>
                         </label>
                    </div>
                </div>
            Next
End If
@Code
     value = 0
End Code
<hr class="separadorbusqueda"/>
<div class="EncabezadoBusquedasCl">
<label>Compradores</label>
<span class="TotalCoincidencias">@Model.ListaComprador.Count Coincidencia(s)</span>
  <a href="../Catalogos/GuardarComprador?deudor=0">
     <img class="btnimgaclientes" src="~/Images/nuevo_verde.png"/>
 </a>
</div>
@If Model.ListaComprador.Count = 0 Then
         @<div>Sin Coincidencias</div>
Elseif Model.ListaComprador.Count > 10 then 
      @<div class="panel-group" id="Comprador" role="tablist" aria-multiselectable="true">
  <div class="panel panel-default">
    <div class="panel-heading" role="tab" id="headingComprador">
      <h4 class="panel-title">
        <a role="button" data-toggle="collapse" data-parent="#Comprador" href="#CompradorCollapse" aria-expanded="false" aria-controls="collapseOne">
             @title
        </a>
      </h4>
    </div>
    <div id="CompradorCollapse" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingComprador">
      <div class="panel-body">
            @For Each item In Model.ListaComprador
                    value = value + 1
                        @<div style="padding-bottom:20px">   
                             <div>    
                                <span>
                                    #@value
                                    (<b>@item.deudor</b>)
                                 </span> 
                                <a href="../Catalogos/GuardarComprador?deudor=@(item.deudor)" >
                                    <span class="buscarNombreClt">@item.nombre</span>
                                </a>
                                <span>R.F.C : </span>
                                <label>
                                   <b>@item.rfc</b>
                                 </label>
                            </div>
                        </div>
             Next
      </div>
    </div>
  </div>
</div>
Else
     @For Each item In Model.ListaComprador
         value = value + 1
                        @<div style="padding-bottom:20px">   
                             <div>    
                                <span>
                                    #@value
                                    (<b>@item.deudor</b>)
                                 </span> 
                                <a href="../Catalogos/GuardarComprador?deudor=@(item.deudor)" >
                                    <span class="buscarNombreClt">@item.nombre</span>
                                </a>
                                <span>R.F.C : </span>
                                <label>
                                   <b>@item.rfc</b>
                                 </label>
                            </div>
                        </div>
             Next  
End If
@Code
     value = 0
End Code
<hr class="separadorbusqueda"/>
<div class="EncabezadoBusquedasCl">
<label>Promotores</label>
<span class="TotalCoincidencias">@Model.ListaPromotor.Count Coincidencia(s)</span>
  <a href="../Catalogos/GuardarPromotor?clave=0">
     <img class="btnimgaclientes" src="~/Images/nuevo_verde.png"/>
 </a>
</div>
 @If Model.ListaPromotor.Count = 0 Then
         @<div>Sin Coincidencias</div>
 ElseIf Model.ListaPromotor.Count > 10 then
      @<div class="panel-group" id="Promotor" role="tablist" aria-multiselectable="true">
  <div class="panel panel-default">
    <div class="panel-heading" role="tab" id="headingPromotor">
      <h4 class="panel-title">
        <a role="button" data-toggle="collapse" data-parent="#Promotor" href="#PromotorCollapse" aria-expanded="false" aria-controls="collapseOne">
             @title
        </a>
      </h4>
    </div>
    <div id="PromotorCollapse" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingPromotor">
      <div class="panel-body">
            @For Each item In Model.ListaPromotor
                value = value+1
               @<div style="padding-bottom:20px">   
                     <div>    
                        <span>
                            #@value
                            (<b>@item.promotor</b>)
                         </span> 
                        <a href="../Catalogos/GuardarPromotor?clave=@(item.promotor)" >
                            <span class="buscarNombreClt">@item.nombre</span>
                        </a>
                        <span>R.F.C : </span>
                        <label>
                            <b>@item.rfc</b>
                         </label>
                    </div>
                </div>
            Next
      </div>
    </div>
  </div>
</div>
 Else
        @For Each item In Model.ListaPromotor
     value = value + 1
               @<div style="padding-bottom:20px">   
                     <div>    
                        <span>
                            #@value
                            (<b>@item.promotor</b>)
                         </span> 
                        <a href="../Catalogos/GuardarPromotor?clave=@(item.promotor)" >
                            <span class="buscarNombreClt">@item.nombre</span>
                        </a>
                        <span>R.F.C : </span>
                        <label>
                            <b>@item.rfc</b>
                         </label>
                    </div>
                </div>
            Next
 End If

</div>
﻿@ModelType nuve.Models.ModeloClientes

@Code
    
If ViewBag.Layout Then
        Layout = "~/Views/Shared/_Layout.vbhtml"
        @<div class="head">
            <div class="headForma">
              <div class="headFormaContenido">
                 <a href="~/Catalogos/Clientes"><img src="~/Images/menu/menuregresar.png"/></a>                
                <span>@(IIf(Model.cliente > 0,String.Concat(Model.nombre,"(",Model.cliente.ToString(),")"),"Nuevo Registro")) </span>
              </div>       
            </div>  
        </div>  
Else
    
    @<head>
    <meta charset="utf-8" />
    <title>@ViewData("Title")</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="shortcut icon" href="/Images/favicon.ico" type="image/x-icon">
    <link rel="icon" href="~/Images/favicon.ico" type="image/x-icon">   
    <meta name="viewport" content="width=device-width" />   
    <link href="https://fonts.googleapis.com/css?family=News+Cycle" rel="stylesheet">
    </head>
    
End If

End Code

@Section Scripts
     <script src="~/Scripts/CatalogosScripts/GuardarCliente.js"></script>
End Section


@Using Html.BeginForm("GuardarCliente", "Catalogos", FormMethod.Post ,New With {.id="clienteForm"} )

@<div class="panel panel-default" style="font-family:'News Cycles';font-size:14px">
    <div class="panel-body highlight">
      
            @Html.ValidationSummary(True)
            
            @If Model IsNot Nothing And Model.cliente > 0 Then
                    @Html.HiddenFor(Function(model) model.cliente)
            End If             
              <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active"><a href="#Basicos" class="nav-link" aria-controls="Basicos" role="tab" data-toggle="tab">Básicos</a></li>
                <li role="presentation" class="nav-item" ><a href="#Domicilio" class="nav-link" aria-controls="Domicilio" role="tab" data-toggle="tab">Domicilio</a></li>
                <li role="presentation" class="nav-item"><a href="#Acta" class="nav-link" aria-controls="Acta" role="tab" data-toggle="tab">Acta constitutiva</a></li>
                <li role="presentation" class="nav-item"><a href="#Otros" class="nav-link" aria-controls="Otros" role="tab" data-toggle="tab">Otros datos</a></li>
                <input type="submit" value="Guardar" class="btn bold" style="float:right" id="submit" />
              </ul>             
              <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="Basicos">                    
                 <div class="row">
                     <div class="col-xs-6">
                        <div class="row">
                        <div class="col-xs-12">
                                    <div class="form-group">                                  
                                        @Html.LabelFor(Function(model) model.sucursal , new with {.class = "control-label"} )                                    
                                        @Html.DropDownListFor(Function(model) model.sucursal, Model.SucursalDropDown , "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                        @Html.ValidationMessageFor(Function(model) model.sucursal)                                    
                                   </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-4">
                                 <div class="form-group">
                                        @Html.LabelFor(Function(model) model.pfisica, New With{.class="form-check-label"})                                                                                 
                                        <label class="rdButtton">
                                          @Html.RadioButtonFor(Function(model) model.pfisica, true ,New With {.Class = "form-check-input " , .id="pfisica1"})
                                          <span class="radiomark"></span>
                                        </label>
                                              
                                        @Html.ValidationMessageFor(Function(model) model.pfisica)                                 
                                </div>
                            </div>
                            <div class="col-xs-5">
                                   <div class="form-group">                                           
                                        <label class="chBox">
                                          @Html.CheckBoxFor(Function(model) model.actempres,New With {.Class = "form-check-input checked"})
                                          <span class="checkmark"></span>
                                        </label>
                                        @Html.LabelFor(Function(model) model.actempres , new with {.class = "form-check-label"}) 
                                        @Html.ValidationMessageFor(Function(model) model.actempres) 
                                   </div>
                            </div> 
                            <div class="col-xs-3">
                                   <div class="form-group">                                        
                                       <label class="chBox">
                                          @Html.CheckBoxFor(Function(model) model.repeco,New With {.Class = "form-check-input checked"})
                                          <span class="checkmark"></span>
                                       </label>
                                       @Html.LabelFor(Function(model) model.repeco, New With{.class="form-check-label"})                                                          
                                       @Html.ValidationMessageFor(Function(model) model.repeco)
                                   </div>
                            </div>                      
                        </div>                    
                        <div class="row" id="GroupPF">
                            <div class="col-xs-6">
                                <div class="form-group"  >                                   
                            
                                     @Html.LabelFor(Function(model) model.n)
                                     @Html.TextBoxFor(Function(model) model.n ,New With {.Class = "form-control"})
                                     @Html.ValidationMessageFor(Function(model) model.n)
                                      
                                     @Html.LabelFor(Function(model) model.s)                                       
                                     @Html.TextBoxFor(Function(model) model.s, New With {.Class = "form-control"})
                                     @Html.ValidationMessageFor(Function(model) model.s )                                

                                </div>
                            </div>
                            <div class="col-xs-6">
                                <div class="form-group" >
                                                              
                                     @Html.LabelFor(Function(model) model.p, New With {.class = "control-label"})                                   
                                     @Html.TextBoxFor(Function(model) model.p, New With {.class = "form-control"} )
                                     @Html.ValidationMessageFor(Function(model) model.p )                                    
                          
                                     @Html.LabelFor(Function(model) model.m, New With {.class = "control-label"})                                   
                                     @Html.TextBoxFor(Function(model) model.m, New With {.class = "form-control"} )
                                     @Html.ValidationMessageFor(Function(model) model.m )   
                                 
                                </div>
                            </div>
                        </div>     
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-group">
                                            @Html.LabelFor(Function(model) model.pfisica,"Persona Moral", New With{.class="form-check-label"})
                                            <label class="rdButtton">
                                                  @Html.RadioButtonFor(Function(model) model.pfisica, false ,New With {.Class = "form-check-input "})
                                                  <span class="radiomark"></span>
                                            </label>    
                                            @Html.ValidationMessageFor(Function(model) model.pfisica) 
                                </div>
                                <div class="form-group" id="GroupPM">
                                            @Html.LabelFor(Function(model) model.nombre)                                       
                                            @Html.TextBoxFor(Function(model) model.nombre, New With {.Class = "form-control"})
                                            @Html.ValidationMessageFor(Function(model) model.nombre ) 
                                </div>
                            </div>
                        
                        </div>    
                     </div>
                     <div class="col-xs-6">
                         <div class="row">
                             <div class="col-xs-6">
                                 <div class="form-group">
                                     @Html.LabelFor(Function(model) model.rfc)                                       
                                     @Html.TextBoxFor(Function(model) model.rfc, New With {.Class = "form-control"})
                                     @Html.ValidationMessageFor(Function(model) model.rfc ) 
                                 </div>
                             </div>
                             <div class="col-xs-6">
                                 <div class="form-group">
                                     @Html.LabelFor(Function(model) model.curp)                                       
                                     @Html.TextBoxFor(Function(model) model.curp, New With {.Class = "form-control"})
                                     @Html.ValidationMessageFor(Function(model) model.curp ) 
                                 </div>
                             </div>
                         </div>
                         <div class="row">
                             <div class="col-xs-12">
                                  <div class="form-group">
                                     @Html.LabelFor(Function(model) model.promotor)                                       
                                     @Html.DropDownListFor(Function(model) model.promotor, Model.PromotorDropDown , "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                     @Html.ValidationMessageFor(Function(model) model.promotor ) 
                                 </div>
                                 <div class="form-group">
                                     @Html.LabelFor(Function(model) model.promprod)                                       
                                     @Html.DropDownListFor(Function(model) model.promprod, Model.PromProdDropDown , "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                     @Html.ValidationMessageFor(Function(model) model.promprod) 
                                 </div>
                             </div>
                         </div>
                         <div class="row">
                             <div class="col-xs-12">
                                 <div class="form-group">
                                        <label class="chBox">
                                          @Html.CheckBoxFor(Function(model) model.grupoemp,New With {.Class = "form-check-input checked"})
                                        <span class="checkmark"></span>
                                        </label>
                                        @Html.LabelFor(Function(model) model.grupoemp , new with {.class = "form-check-label"})                             
                                        @Html.ValidationMessageFor(Function(model) model.grupoemp) 
                                 </div>
                                 <div class="form-group">
                                        @Html.DropDownListFor(Function(model) model.clave, Model.GrupoEmpresarialDropDown , "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                        @Html.ValidationMessageFor(Function(model) model.clave) 
                                 </div>
                                 <div class="form-group">
                                        @Html.LabelFor(Function(model) model.clientet24)                                       
                                        @Html.TextBoxFor(Function(model) model.clientet24, New With {.Class = "form-control"})
                                        @Html.ValidationMessageFor(Function(model) model.clientet24 ) 
                                 </div>
                                 <div class="form-group">
                                        @Html.LabelFor(Function(model) model.nombret24)                                       
                                        @Html.TextBoxFor(Function(model) model.nombret24, New With {.Class = "form-control"})
                                        @Html.ValidationMessageFor(Function(model) model.nombret24 ) 
                                 </div>
                             </div>
                         </div>
                     </div>
                 </div>                                 
                </div>
                <div role="tabpanel" class="tab-pane" id="Domicilio">
                    <div class="row">
                        <div class="col-xs-6">
                            <div class="form-group">                                
                                @If Model.fec_alta.Equals(Nothing) Then
                                       @Html.LabelFor(Function(model) model.fec_alta, new with {.class = "control-label"})
                                       @Html.TextBoxFor(Function(model) model.fec_alta,"{0:dd/MM/yyyy}", New With {.class = "form-control",.Value = Today.Date.ToShortDateString(),.ReadOnly = True})
                                       @Html.ValidationMessageFor(Function(model) model.fec_alta)                                        
                                Else
                                       @Html.LabelFor(Function(model) model.fec_alta, new with {.class = "control-label"})
                                       @Html.TextBoxFor(Function(model) model.fec_alta,"{0:dd/MM/yyyy}", New With {.class = "form-control",.ReadOnly = True})
                                       @Html.ValidationMessageFor(Function(model) model.fec_alta)
                                End If                                    
                            </div>
                            <div class="form-group">
                                   @Html.LabelFor(Function(model) model.domicilio, new with {.class = "control-label"})
                                   @Html.TextBoxFor(Function(model) model.domicilio, New With {.Class = "form-control"})
                                   @Html.ValidationMessageFor(Function(model) model.domicilio)
                            </div>
                            <div class="form-group">
                                   @Html.LabelFor(Function(model) model.noext, new with {.class = "control-label"})
                                   @Html.TextBoxFor(Function(model) model.noext, New With {.Class = "form-control"})
                                   @Html.ValidationMessageFor(Function(model) model.noext) 
                            </div>
                            <div class="form-group">
                                   @Html.LabelFor(Function(model) model.noint, new with {.class = "control-label"})
                                   @Html.TextBoxFor(Function(model) model.noint, New With {.Class = "form-control"})
                                   @Html.ValidationMessageFor(Function(model) model.noint)
                            </div>
                            <div class="form-group">
                                   @Html.LabelFor(Function(model) model.cp, New With {.class = "control-label"})
                                   @Html.TextBoxFor(Function(model) model.cp, New With {.Class = "form-control"})
                                   @Html.ValidationMessageFor(Function(model) model.cp)
                            </div>
                            <div class="form-group">
                                   @Html.LabelFor(Function(model) model.puesto, new with {.class = "control-label"})
                                   @Html.TextBoxFor(Function(model) model.puesto, New With {.Class = "form-control"})
                                   @Html.ValidationMessageFor(Function(model) model.puesto)
                            </div>
                        </div>          
                        <div class="col-xs-6">
                            <div class="form-group">
                                   @Html.LabelFor(Function(model) model.colonia, new with {.class = "control-label"})
                                   @Html.TextBoxFor(Function(model) model.colonia, New With {.Class = "form-control"})
                                   @Html.ValidationMessageFor(Function(model) model.colonia)
                            </div>
                            <div class="form-group">
                                   @Html.LabelFor(Function(model) model.cvecd, new with {.class = "control-label"})
                                   @Html.DropDownListFor(Function(model) model.cvecd, Model.CiudadDropDown, "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                   @Html.ValidationMessageFor(Function(model) model.cvecd)
                            </div>
                            <div class="form-group">
                                   @Html.LabelFor(Function(model) model.cveedo, new with {.class = "control-label"})
                                @Html.DropDownListFor(Function(model) model.cveedo, Model.EstadoDropDown, "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                   @Html.ValidationMessageFor(Function(model) model.cveedo)
                            </div>
                            <div class="form-group">
                                   @Html.LabelFor(Function(model) model.telefono, new with {.class = "control-label"})
                                   @Html.TextBoxFor(Function(model) model.telefono, New With {.Class = "form-control"})
                                   @Html.ValidationMessageFor(Function(model) model.telefono)
                            </div>
                            <div class="form-group">
                                   @Html.LabelFor(Function(model) model.fenlace, new with {.class = "control-label"})
                                   @Html.TextBoxFor(Function(model) model.fenlace, New With {.Class = "form-control"})
                                   @Html.ValidationMessageFor(Function(model) model.fenlace)
                            </div>
                             
                        </div>           
                    </div>   
                    <div class="row">
                      <div class="col-xs-6">
                          <div class="form-group">
                                 @Html.LabelFor(Function(model) model.seconomico, New With {.class = "control-label"})
                                 @Html.DropDownListFor(Function(model) model.seconomico, Model.SectorEconomicoDropDown, "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                 @Html.ValidationMessageFor(Function(model) model.seconomico)
                          </div>

                          <div class="form-group">
                                 @Html.LabelFor(Function(model) model.cvegiro, New With {.class = "control-label"})
                                 @Html.DropDownListFor(Function(model) model.cvegiro, Model.GiroDropDown, "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                 @Html.ValidationMessageFor(Function(model) model.cvegiro)
                          </div>

                      </div>
                      <div class="col-xs-6">
                          <div class="form-group">
                                 @Html.LabelFor(Function(model) model.sectorfina, New With {.class = "control-label"})
                                 @Html.DropDownListFor(Function(model) model.sectorfina, Model.SectorFinancieroDropDown, "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                 @Html.ValidationMessageFor(Function(model) model.sectorfina)
                          </div>
                          <div class="form-group">
                                 @Html.LabelFor(Function(model) model.actividad, New With {.class = "control-label"})
                                 @Html.TextBoxFor(Function(model) model.actividad, New With {.Class = "form-control"})
                                 @Html.ValidationMessageFor(Function(model) model.actividad)
                          </div>
                      </div>
                    </div> 
                                             
                </div>                
                <div role="tabpanel" class="tab-pane" id="Acta">
                        <div class="row">
                            <div class="col-xs-6">
                                    <div class="form-group">
                                        @Html.LabelFor(Function(model) model.ac_numnot)                                       
                                        @Html.TextBoxFor(Function(model) model.ac_numnot, New With {.Class = "form-control"})
                                        @Html.ValidationMessageFor(Function(model) model.ac_numnot )  
                                    </div>
                                    <div class="form-group">
                                        @Html.LabelFor(Function(model) model.ac_nombre)                                       
                                        @Html.TextBoxFor(Function(model) model.ac_nombre, New With {.Class = "form-control"})
                                        @Html.ValidationMessageFor(Function(model) model.ac_nombre )  
                                    </div>                                    
                                    <div class="form-group"> 
                                        @Html.LabelFor(Function(model) model.ac_escrit)                                       
                                        @Html.TextBoxFor(Function(model) model.ac_escrit, New With {.Class = "form-control"})
                                        @Html.ValidationMessageFor(Function(model) model.ac_escrit )    
                                    </div>
                                    <div class="form-group"> 
                                        @Html.LabelFor(Function(model) model.ac_fecha , new with {.class = "control-label"})   
                                        <div class="form-inline">                         
                                                     <div class='input-group date' id='ac_fechaDataTime'>
                                                         @Html.TextBoxFor(Function(model) model.ac_fecha,"{0:dd/MM/yyyy}", New With {.class = "form-control" , .readonly = true})
                                                         <span class="input-group-addon">
                                                            <span class="glyphicon glyphicon-calendar"></span>
                                                         </span>                                               
                                                    </div>
                                        </div> 
                                    </div>
                                    <div class="form-group">
                                        @Html.LabelFor(Function(model) model.ac_localid)                                       
                                        @Html.TextBoxFor(Function(model) model.ac_localid, New With {.Class = "form-control"})
                                        @Html.ValidationMessageFor(Function(model) model.ac_localid ) 
                                    </div>
                            </div>
                            <div class="col-xs-6">  
                                <div class="row">                                                    
                                    <div class="col-xs-6">
                                        <div class="form-group">
                                            @Html.LabelFor(Function(model) model.ac_numero)                                       
                                            @Html.TextBoxFor(Function(model) model.ac_numero, New With {.Class = "form-control"})
                                            @Html.ValidationMessageFor(Function(model) model.ac_numero )  
                                        </div>
                                        <div class="form-group">
                                            @Html.LabelFor(Function(model) model.ac_folio)                                       
                                            @Html.TextBoxFor(Function(model) model.ac_folio, New With {.Class = "form-control"})
                                            @Html.ValidationMessageFor(Function(model) model.ac_folio )  
                                        </div>
                                        <div class="form-group">
                                            @Html.LabelFor(Function(model) model.ac_volumen)                                       
                                            @Html.TextBoxFor(Function(model) model.ac_volumen, New With {.Class = "form-control"})
                                            @Html.ValidationMessageFor(Function(model) model.ac_volumen )  
                                        </div>
                                        <div class="form-group">
                                        @Html.LabelFor(Function(model) model.ac_fechare , new with {.class = "control-label"})
                                        <div class="form-inline">                        
                                            <div class='input-group date' id='ac_fechareDataTime'>
                                                @Html.TextBoxFor(Function(model) model.ac_fechare,"{0:dd/MM/yyyy}", New With {.class = "form-control" , .readonly = True })                                          
                                                <span class="input-group-addon">
                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                </span>
                                            </div>    
                                            </div>
                                        </div>


                                    </div>
                                    <div class="col-xs-6">
                                        <div class="form-group">
                                            @Html.LabelFor(Function(model) model.ac_libro)                                       
                                            @Html.TextBoxFor(Function(model) model.ac_libro, New With {.Class = "form-control"})
                                            @Html.ValidationMessageFor(Function(model) model.ac_libro )  
                                        </div>
                                        <div class="form-group">
                                            @Html.LabelFor(Function(model) model.ac_auxilia)                                       
                                            @Html.TextBoxFor(Function(model) model.ac_auxilia, New With {.Class = "form-control"})
                                            @Html.ValidationMessageFor(Function(model) model.ac_auxilia )  
                                        </div>
                                        <div class="form-group">
                                            @Html.LabelFor(Function(model) model.ac_actaloc)                                       
                                            @Html.TextBoxFor(Function(model) model.ac_actaloc, New With {.Class = "form-control"})
                                            @Html.ValidationMessageFor(Function(model) model.ac_actaloc )  
                                        </div>
                                                                                
                                    </div> 
                                </div>    
                            </div>
                        </div>
                </div>
                <div role="tabpanel" class="tab-pane" id="Otros">
                    <div class="row">
                        <div class="col-xs-6">
                            <div class="form-group">           
                                @Html.LabelFor(Function(model) model.idrelacion , new with {.class = "control-label"} )                                    
                                @Html.DropDownListFor(Function(model) model.idrelacion, Model.RelacionadoDropDown , "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                @Html.ValidationMessageFor(Function(model) model.idrelacion) 
                            </div>
                            <div class="form-group">           
                                @Html.LabelFor(Function(model) model.idrelevant , new with {.class = "control-label"} )                                    
                                @Html.DropDownListFor(Function(model) model.idrelevant, Model.RelevanteDropDown, "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                @Html.ValidationMessageFor(Function(model) model.idrelevant) 
                            </div>
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.email)
                                @Html.TextBoxFor(Function(model) model.email ,New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.email)
                           </div> 
                            <div class="form-group">
                               <div class="row" style="display:flex;align-items:center">                                   
                                       <div class="col-md-6">
                                           <div class="form-group"> 
                                               @Html.LabelFor(Function(model) model.password)
                                               @Html.PasswordFor(Function(model) model.password ,New With {.Class = "form-control"})
                                               @Html.ValidationMessageFor(Function(model) model.password)
                                           </div>
                                       </div>
                                       <div class="col-md-6">
                                           <div class="form-group" style="padding-top:20px">                                                   
                                                <label class="chBox">
                                                  @Html.CheckBoxFor(Function(model) model.sif,New With {.Class = "form-check-input checked"})
                                                  <span class="checkmark"></span>
                                                </label>
                                                @Html.LabelFor(Function(model) model.sif , new with {.class = "form-check-label"}) 
                                                @Html.ValidationMessageFor(Function(model) model.sif) 
                                            </div>
                                       </div>                                  
                                </div>
                           </div>
                            <div class="form-group">           
                                @Html.LabelFor(Function(model) model.enviafact, New With {.class = "control-label"})                                    
                                @Html.DropDownListFor(Function(model) model.enviafact, Model.FelectronicaDropDown, "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                @Html.ValidationMessageFor(Function(model) model.enviafact) 
                            </div>
                        </div>
                        <div class="col-xs-6">   
                            <div class="row">
                                <div class="col-xs-6">
                                    <div class="form-group">
                                        @Html.LabelFor(Function(model) model.sirac ,new with {.class = "control-label"})
                                        @Html.TextBoxFor(Function(model) model.sirac ,New With {.Class = "form-control"})
                                        @Html.ValidationMessageFor(Function(model) model.sirac)
                                      </div> 
                                    <div class="form-group">
                                        @Html.LabelFor(Function(model) model.regiva , new with {.class = "control-label"} )                                    
                                        @Html.DropDownListFor(Function(model) model.regiva, Model.RegimenDropDown , "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                        @Html.ValidationMessageFor(Function(model) model.regiva)
                                      </div>
                                    <div class="form-group">
                                        @Html.LabelFor(Function(model) model.clasifica , new with {.class = "control-label"} )                                    
                                        @Html.DropDownListFor(Function(model) model.clasifica, Model.ClasificaDropDown , "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                        @Html.ValidationMessageFor(Function(model) model.clasifica)
                                      </div>
                                    <div class="form-group">
                                        @Html.LabelFor(Function(model) model.gpoecono, New With {.class = "control-label"})
                                        @Html.TextBoxFor(Function(model) model.gpoecono, New With {.Class = "form-control"})
                                        @Html.ValidationMessageFor(Function(model) model.gpoecono)
                                    </div>
                                    <div class="form-group">           
                                        @Html.LabelFor(Function(model) model.calcliente , new with {.class = "control-label"} )                                    
                                        @Html.DropDownListFor(Function(model) model.calcliente, Model.CalClienteDropDown, "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                        @Html.ValidationMessageFor(Function(model) model.calcliente) 
                                    </div>
                                    <div class="form-group">           
                                        @Html.LabelFor(Function(model) model.rgo_finan , new with {.class = "control-label"} )                                    
                                        @Html.DropDownListFor(Function(model) model.rgo_finan, Model.CalClienteDropDown, "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                        @Html.ValidationMessageFor(Function(model) model.rgo_finan) 
                                    </div>
                                </div>
                                <div class="col-xs-6">
                                    <div class="form-group">
                                        @Html.LabelFor(Function(model) model.epo, New With {.class = "control-label"})
                                        @Html.TextBoxFor(Function(model) model.epo, New With {.Class = "form-control"})
                                        @Html.ValidationMessageFor(Function(model) model.epo)
                                    </div>
                                    <div class="form-group">
                                        @Html.LabelFor(Function(model) model.fira_idacr, New With {.class = "control-label"})
                                        @Html.TextBoxFor(Function(model) model.fira_idacr, New With {.Class = "form-control"})
                                        @Html.ValidationMessageFor(Function(model) model.fira_idacr)
                                    </div>
                                    <div class="form-group">
                                        @Html.LabelFor(Function(model) model.empleados, New With {.class = "control-label"})
                                        @Html.TextBoxFor(Function(model) model.empleados, New With {.Class = "form-control"})
                                        @Html.ValidationMessageFor(Function(model) model.empleados)
                                    </div>
                                    <div class="form-group" style="margin-top:36px">                                         
                                        <label class="chBox">
                                          @Html.CheckBoxFor(Function(model) model.politica,New With {.Class = "form-check-input checked"})
                                          <span class="checkmark"></span>
                                       </label> 
                                        @Html.LabelFor(Function(model) model.politica , new with {.class = "form-check-label"})  
                                        @Html.ValidationMessageFor(Function(model) model.politica) 
                                    </div>
                                    <div class="form-group">           
                                        @Html.LabelFor(Function(model) model.rgo_indust, New With {.class = "control-label"})                                    
                                        @Html.DropDownListFor(Function(model) model.rgo_indust, Model.CalClienteDropDown, "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                        @Html.ValidationMessageFor(Function(model) model.rgo_indust) 
                                    </div>
                                    <div class="form-group">           
                                        @Html.LabelFor(Function(model) model.exp_pago, New With {.class = "control-label"})                                    
                                        @Html.DropDownListFor(Function(model) model.exp_pago, Model.CalClienteDropDown, "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                        @Html.ValidationMessageFor(Function(model) model.exp_pago) 
                                    </div>
                                </div>
                            </div>                             
                        </div>                          
                   </div>                              
                </div>
              </div>       
       
    </div>
</div>
    
End Using

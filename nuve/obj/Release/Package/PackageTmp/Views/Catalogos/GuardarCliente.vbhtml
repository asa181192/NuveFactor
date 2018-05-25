@ModelType nuve.Models.ModeloClientes

@Code
    If ViewBag.Layout Then
        Layout = "~/Views/Shared/_Layout.vbhtml"
        @<div class="head">
            <div class="headForma">
              <div class="headFormaContenido">                
                <span>@(IIf(Model.cliente > 0,String.Concat(Model.nombre,"(",Model.cliente.ToString(),")"),"Nuevo Registro")) </span>
              </div>       
            </div>  
        </div>        
    End If
End Code


@Using Html.BeginForm("GuardarCliente", "Catalogos", FormMethod.Post ,New With {.id="popupForm"} )

@<div class="panel panel-default">
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
                <li role="presentation" class="nav-item"><a href="#Acta" class="nav-link" aria-controls="Acta" role="tab" data-toggle="tab">Acta constitutiva</a></li>
                <li role="presentation" class="nav-item"><a href="#Otros" class="nav-link" aria-controls="Otros" role="tab" data-toggle="tab">Otros datos</a></li>
              </ul>             
              <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="Basicos">                    
                 <div class="row">
                     <div class="col-md-6">
                        <div class="row">
                        <div class="col-md-12">
                                    <div class="form-group">                                  
                                        @Html.LabelFor(Function(model) model.sucursal , new with {.class = "control-label"} )                                    
                                        @Html.DropDownListFor(Function(model) model.sucursal, Model.SucursalDropDown , "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                        @Html.ValidationMessageFor(Function(model) model.sucursal)                                    
                                   </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                 <div class="form-group">  
                                        @Html.LabelFor(Function(model) model.pfisica, "Persona Fisica", New With{.class="form-check-label"})                             
                                        @Html.RadioButtonFor(Function(model) model.pfisica, true ,New With {.Class = "form-check-input"})
                                        @Html.ValidationMessageFor(Function(model) model.pfisica) 
                                 
                                </div>
                            </div>
                            <div class="col-md-4">
                                   <div class="form-group">
                                        @Html.LabelFor(Function(model) model.actempres , new with {.class = "form-check-label"})                                
                                        @Html.CheckBoxFor(Function(model) model.actempres, New With {.Class = "form-check-input"})
                                        @Html.ValidationMessageFor(Function(model) model.actempres) 
                                   </div>
                            </div> 
                            <div class="col-md-4">
                                   <div class="form-group">
                                        @Html.LabelFor(Function(model) model.repeco, New With{.class="form-check-label"})                             
                                        @Html.CheckBoxFor(Function(model) model.repeco,New With {.Class = "form-check-input"})
                                        @Html.ValidationMessageFor(Function(model) model.repeco)
                                   </div>
                            </div>                      
                        </div>                    
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">                                   
                            
                                                @Html.LabelFor(Function(model) model.n)
                                                @Html.TextBoxFor(Function(model) model.n ,New With {.Class = "form-control"})
                                                @Html.ValidationMessageFor(Function(model) model.n)
                                      
                                                @Html.LabelFor(Function(model) model.m)                                       
                                                @Html.TextBoxFor(Function(model) model.m, New With {.Class = "form-control"})
                                                @Html.ValidationMessageFor(Function(model) model.m )                                

                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                                              
                                            @Html.LabelFor(Function(model) model.s, New With {.class = "control-label"})                                   
                                            @Html.TextBoxFor(Function(model) model.s, New With {.class = "form-control"} )
                                            @Html.ValidationMessageFor(Function(model) model.s )                                    
                          
                                            @Html.LabelFor(Function(model) model.m, New With {.class = "control-label"})                                   
                                            @Html.TextBoxFor(Function(model) model.m, New With {.class = "form-control"} )
                                            @Html.ValidationMessageFor(Function(model) model.m )   
                                 
                                </div>
                            </div>
                        </div>     
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                            @Html.LabelFor(Function(model) model.pfisica,"Persona Moral", New With{.class="form-check-label"})                             
                                            @Html.RadioButtonFor(Function(model) model.pfisica,false ,New With {.Class = "form-check-input"})
                                            @Html.ValidationMessageFor(Function(model) model.pfisica) 
                                </div>
                                <div class="form-group">
                                            @Html.LabelFor(Function(model) model.nombre)                                       
                                            @Html.TextBoxFor(Function(model) model.nombre, New With {.Class = "form-control"})
                                            @Html.ValidationMessageFor(Function(model) model.nombre ) 
                                </div>
                            </div>
                        
                                   
                        </div>    
                     </div>
                     <div class="col-md-6">
                         <div class="row">
                             <div class="col-md-6">
                                 <div class="form-group">
                                     @Html.LabelFor(Function(model) model.rfc)                                       
                                     @Html.TextBoxFor(Function(model) model.rfc, New With {.Class = "form-control"})
                                     @Html.ValidationMessageFor(Function(model) model.rfc ) 
                                 </div>
                             </div>
                             <div class="col-md-6">
                                 <div class="form-group">
                                     @Html.LabelFor(Function(model) model.curp)                                       
                                     @Html.TextBoxFor(Function(model) model.curp, New With {.Class = "form-control"})
                                     @Html.ValidationMessageFor(Function(model) model.curp ) 
                                 </div>
                             </div>
                         </div>
                         <div class="row">
                             <div class="col-md-12">
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
                             <div class="col-md-12">
                                 <div class="form-group">
                                        @Html.LabelFor(Function(model) model.grupoemp , new with {.class = "form-check-label"})                                
                                        @Html.CheckBoxFor(Function(model) model.grupoemp, New With {.Class = "form-check-input"})
                                        @Html.ValidationMessageFor(Function(model) model.grupoemp) 
                                 </div>
                                 <div class="form-group">
                                        @Html.LabelFor(Function(model) model.clave , new with {.class = "control-label"})                                
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
                        <div class="col-md-6">
                            <div class="form-group">
                                   @Html.LabelFor(Function(model) model.fec_alta, new with {.class = "control-label"})
                                   @Html.TextBoxFor(Function(model) model.fec_alta,"{0:dd/MM/yyyy}", New With {.class = "form-control",.ReadOnly = True})
                                   @Html.ValidationMessageFor(Function(model) model.fec_alta)    
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
                        <div class="col-md-6">
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
                        <div class="col-md-6">
                            <div class="form-group">
                                   @Html.LabelFor(Function(model) model.colonia, new with {.class = "control-label"})
                                   @Html.TextBoxFor(Function(model) model.colonia, New With {.Class = "form-control"})
                                   @Html.ValidationMessageFor(Function(model) model.colonia)
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                   @Html.LabelFor(Function(model) model.colonia, new with {.class = "control-label"})
                                   @Html.TextBoxFor(Function(model) model.colonia, New With {.Class = "form-control"})
                                   @Html.ValidationMessageFor(Function(model) model.colonia)
                            </div>
                        </div>
                    </div> 
                                             
                </div>                
           @*     <div role="tabpanel" class="tab-pane" id="Acta">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    @Html.LabelFor(Function(model) model.responsable  , new with {.class = "control-label"})
                                    @Html.TextBoxFor(Function(model) model.responsable ,New With {.Class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.responsable)                   

                                    @Html.LabelFor(Function(model) model.plaza, new with {.class = "control-label"})
                                    @Html.TextBoxFor(Function(model) model.plaza,New With {.Class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.plaza)
                 
                                    @Html.LabelFor(Function(model) model.plazacob, new with {.class = "control-label"})
                                    @Html.DropDownListFor(Function(model) model.plazacob, Model.SucursalDropDown, "-- Seleccione --", New With {.Class = "form-control dropdown"})                                    
                                    @Html.ValidationMessageFor(Function(model) model.plazacob)
                   
                                </div>
                            </div>
                        </div>
                </div>
                <div role="tabpanel" class="tab-pane" id="Otros">
                    <div class="row">
                        <div class="col-md-6">

                                @Html.LabelFor(Function(model) model.repeco  , new with {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.repeco ,New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.repeco)                   

                        </div>
                        <div class="col-md-6">
                                @Html.LabelFor(Function(model) model.regiva, new with {.class = "control-label"})                                
                                @Html.DropDownListFor(Function(model) model.regiva, Model.RegimenDropDown, "-- Seleccione --", New With {.Class = "form-control dropdown"})                                    
                                @Html.ValidationMessageFor(Function(model) model.regiva)
                 
                        </div>                          
                   </div>
                    <div class="row">
                        <div class="col-md-12">
                             <div class="form-group">

                                
                                @Html.LabelFor(Function(model) model.notas, new with {.class = "control-label"})
                                @Html.TextAreaFor(Function(model) model.notas, 5, Nothing, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.notas)
                   
                            </div>
                        </div>
                          
                    </div>                                   
                </div>*@
              </div>       
       
    </div>
</div>

    @<p>
        <input type="submit" value="Guardar" class="btn bold" />
    </p>  
    
End Using

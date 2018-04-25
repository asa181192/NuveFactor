﻿@ModelType nuve.Models.ModeloComprador


@Using Html.BeginForm("GuardarComprador", "Catalogos", FormMethod.Post ,New With {.id="popupForm"} )

@<div class="panel panel-default">
    <div class="panel-body highlight">
      
            @Html.ValidationSummary(True)
            
            @If Model IsNot Nothing And Model.deudor > 0 Then
                    @Html.HiddenFor(Function(model) model.deudor)
            End If             
              <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active"><a href="#General" class="nav-link" aria-controls="Generales" role="tab" data-toggle="tab">Generales</a></li>
                <li role="presentation" class="nav-item" ><a href="#Domicilio" class="nav-link" aria-controls="Domicilio" role="tab" data-toggle="tab">Domicilio</a></li>
                <li role="presentation" class="nav-item"><a href="#Contacto" class="nav-link" aria-controls="Contacto" role="tab" data-toggle="tab">Contacto</a></li>
                <li role="presentation" class="nav-item"><a href="#Notas" class="nav-link" aria-controls="Notas" role="tab" data-toggle="tab">Notas</a></li>
                <li role="presentation" class="nav-item"><a href="#Seguro" class="nav-link" aria-controls="Seguro" role="tab" data-toggle="tab">Seguro de Credito</a></li>
                <li role="presentation" class="nav-item"><a href="#Linea" class="nav-link" aria-controls="Linea" role="tab" data-toggle="tab">Línea </a></li>
              </ul>             
              <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="General" style="margin-top:50px">                    
                    <div class="row">
                        <div class="col-md-6">                             
                            <div class="form-group">       
                                 @Html.LabelFor(Function(model) model.fec_alta ,new with {.class = "control-label"}) 
                                 <div class='input-group date'>                                    
                                        @If Not Model.fec_alta.Equals(Nothing)  Then
                                                @Html.TextBoxFor(Function(model) model.fec_alta,"{0:dd/MM/yyyy}", New With {.class = "form-control",.ReadOnly = True})
                                                @<span class="input-group-addon">
                                                    <span class="glyphicon glyphicon-calendar"></span>
			                                      </span>
                                                @Html.ValidationMessageFor(Function(model) model.fec_alta)
                                            Else
                                                @Html.TextBoxFor(Function(model) model.fec_alta,"{0:dd/MM/yyyy}", New With {.class = "form-control", .Value = Today.Date.ToShortDateString(), .ReadOnly = True})
                                                @<span class="input-group-addon">
                                                    <span class="glyphicon glyphicon-calendar"></span>
			                                      </span>
                                                @Html.ValidationMessageFor(Function(model) model.fec_alta)
                                            End If
                                 </div> 

                            </div>                                       
                        </div>
                        <div class="col-md-6">
                                <div class="form-group">
                                  
                                            @Html.LabelFor(Function(model) model.sucursal , new with {.class = "control-label"} )                                    
                                            @Html.DropDownListFor(Function(model) model.sucursal, Model.SucursalDropDown , "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                            @Html.ValidationMessageFor(Function(model) model.sucursal)
                                    
                               </div>
                        </div>
                    </div>
                    <div class="row" style="margin-top:10px">
                        <div class="col-md-6">
                             <div class="form-group">
                                    @Html.LabelFor(Function(model) model.nombre , new with {.class = "control-label"})                                
                                    @Html.TextBoxFor(Function(model) model.nombre, New With {.Class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.nombre)
                               
                            </div>
                        </div>
                        <div class="col-md-6">
                               <div class="form-group">
                                    @Html.LabelFor(Function(model) model.giro)                             
                                    @Html.TextBoxFor(Function(model) model.giro ,New With {.Class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.giro)
                               </div>
                        </div>                      
                    </div>                    
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">    
                                            @Html.LabelFor(Function(model) model.rfc)
                                            @Html.TextBoxFor(Function(model) model.rfc ,New With {.Class = "form-control"})
                                            @Html.ValidationMessageFor(Function(model) model.rfc)
                                      
                            </div>
                        </div>
                        <div class="col-md-6">
                                            @Html.LabelFor(Function(model) model.curp)                                       
                                            @Html.TextBoxFor(Function(model) model.curp, New With {.Class = "form-control"})
                                            @Html.ValidationMessageFor(Function(model) model.curp )    
                        </div>
                    </div>                                                    
                </div>
                <div role="tabpanel" class="tab-pane" id="Domicilio">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">

                                  @Html.LabelFor(Function(model) model.calle, new with {.class = "control-label"})
                                  @Html.TextBoxFor(Function(model) model.calle,New With {.Class = "form-control"})
                                  @Html.ValidationMessageFor(Function(model) model.calle)   
                                                                                                
                                    
                            </div>
                        </div>                     
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                               <div class="form-group">
                                  @Html.LabelFor(Function(model) model.noext, new with {.class = "control-label"})
                                  @Html.TextBoxFor(Function(model) model.noext ,New With {.Class = "form-control"})
                                  @Html.ValidationMessageFor(Function(model) model.noext) 
                                   
                                  @Html.LabelFor(Function(model) model.colonia, new with {.class = "control-label"})
                                  @Html.TextBoxFor(Function(model) model.colonia,New With {.Class = "form-control"})
                                  @Html.ValidationMessageFor(Function(model) model.colonia)
                                   
                                  @Html.LabelFor(Function(model) model.estado, new with {.class = "control-label"})
                                  @Html.TextBoxFor(Function(model) model.estado,New With {.Class = "form-control"})
                                  @Html.ValidationMessageFor(Function(model) model.estado) 
                                   
                                  @Html.LabelFor(Function(model) model.telefono ,new with {.class = "control-label"})
                                  @Html.TextBoxFor(Function(model) model.telefono,New With {.Class = "form-control"})
                                  @Html.ValidationMessageFor(Function(model) model.telefono)
                                      
                                
                               </div>
                        </div>

                        <div class="col-md-6">
                                <div class="form-group">
                                                                        
                                  @Html.LabelFor(Function(model) model.noint, new with {.class = "control-label"})
                                  @Html.TextBoxFor(Function(model) model.noint,New With {.Class = "form-control"})
                                  @Html.ValidationMessageFor(Function(model) model.noint)  

                                  @Html.LabelFor(Function(model) model.municipio, new with {.class = "control-label"})
                                  @Html.TextBoxFor(Function(model) model.municipio,New With {.Class = "form-control"})
                                  @Html.ValidationMessageFor(Function(model) model.municipio) 
                                    
                                  @Html.LabelFor(Function(model) model.cp, new with {.class = "control-label"})
                                  @Html.TextBoxFor(Function(model) model.cp,New With {.Class = "form-control number"})
                                    
                                  @Html.LabelFor(Function(model) model.email, new with {.class = "control-label"})
                                  @Html.TextBoxFor(Function(model) model.email,New With {.Class = "form-control"})
                                  @Html.ValidationMessageFor(Function(model) model.email)  

                                </div>
                        </div>
                    </div>                   
      
                    </div>                
                <div role="tabpanel" class="tab-pane" id="Contacto">
                   
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
                <div role="tabpanel" class="tab-pane" id="Notas">

                    <div class="row">
                        <div class="col-md-6">

                              
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
                                   
                </div>
                <div role="tabpanel" class="tab-pane" id="Seguro">...</div>
                <div role="tabpanel" class="tab-pane" id="Linea">...</div>
              </div>       
       
    </div>
</div>

    @<p>
        <input type="submit" value="Guardar" class="btn bold" />
    </p>  
    
End Using
  
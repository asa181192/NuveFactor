@ModelType nuve.Models.ModeloProveedor

@*<div class="head">
    <div class="headForma">
      <div class="headFormaContenido">
        <span>Guardar Proveedor</span>
      </div>
    </div>
  </div>*@


@Using Html.BeginForm("GuardarProveedor", "Catalogos", FormMethod.Post ,New With {.id="popupForm"} )

@<div class="panel panel-default">
    <div class="panel-body highlight">
      
            @Html.ValidationSummary(True)
            
            @If Model IsNot Nothing And Model.deudor > 0 Then
                    @Html.HiddenFor(Function(model) model.deudor)
            End If

              <!--NAV-->
              <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active"><a href="#General" class="nav-link" aria-controls="Generales" role="tab" data-toggle="tab">Generales</a></li>
                <li role="presentation" class="nav-item" ><a href="#Domicilio" class="nav-link" aria-controls="Domicilio" role="tab" data-toggle="tab">Domicilio</a></li>
                <li role="presentation" class="nav-item"><a href="#Contacto" class="nav-link" aria-controls="Contacto" role="tab" data-toggle="tab">Contacto</a></li>
                <li role="presentation" class="nav-item"><a href="#Notas" class="nav-link" aria-controls="Notas" role="tab" data-toggle="tab">Notas</a></li>
                <li role="presentation" class="nav-item"><a href="#Seguro" class="nav-link" aria-controls="Seguro" role="tab" data-toggle="tab">Seguro de Credito</a></li>
                <li role="presentation" class="nav-item"><a href="#Linea" class="nav-link" aria-controls="Linea" role="tab" data-toggle="tab">Línea </a></li>
              </ul>

              <!-- Tab panes -->
               <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="General" style="margin-top:50px">
                    
                    <div class="row">
                        <div class="col-md-6">                             
                            <div class="form-group">       
                                @Html.LabelFor(Function(model) model.fec_alta ,new with {.class = "control-label"}) 
                                 <div class='input-group date' id='dpcltedesde'>                                    
                                    
                                      @code                                      
                                          @<input name="fec_alta" class="form-control" id="fec_alta" type="text"  data-val-required="El campo Cliente desde es obligatorio." data-val="true" data-val-date="El campo Cliente desde debe ser una fecha.">
			                                    @<span class="input-group-addon">
				                                    <span class="glyphicon glyphicon-calendar"></span>
			                                    </span>
                                      End Code
                              
                                     @* @Html.ValidationMessageFor(Function(model) model.fec_alta)*@
                                 </div> 

                            </div>                                       
                        </div>
                        <div class="col-md-6">
                                <div class="form-group">
                                            @Html.LabelFor(Function(model) model.sucursal , new with {.class = "control-label"} )                                    
                                            @Html.TextBoxFor(Function(model) model.sucursal , New With {.Class = "form-control"})
                                            @Html.ValidationMessageFor(Function(model) model.sucursal)
                                    
                               </div>
                        </div>
                    </div>
                    <div class="row" style="margin-top:10px">
                        <div class="col-md-6">
                             <div class="form-group">
                                    @Html.LabelFor(Function(model) model.nombre , new with {.class = "control-label"})                                
                                    @Html.TextBoxFor(Function(model) model.nombre ,New With {.Class = "form-control"})
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
                                      
                                            @Html.LabelFor(Function(model) model.curp)                                       
                                            @Html.TextBoxFor(Function(model) model.curp, New With {.Class = "form-control"})
                                            @Html.ValidationMessageFor(Function(model) model.curp )                                

                                      
                                            @Html.LabelFor(Function(model) model.sirac)
                                            @Html.TextBoxFor(Function(model) model.sirac ,New With {.Class = "form-control"})
                                            @Html.ValidationMessageFor(Function(model) model.sirac)
                                        
                                            @Html.LabelFor(Function(model) model.fira_idcon)
                                            @Html.TextBoxFor(Function(model) model.fira_idcon ,New With {.Class = "form-control"})
                                            @Html.ValidationMessageFor(Function(model) model.fira_idcon)
                                 
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group" style="padding-top:40px">
                                <div class="form-check">                                    
                                        @Html.LabelFor(Function(model) model.elaborado, New With {.class = "form-check-label"})                                   
                                        @Html.CheckBoxFor(Function(model) model.elaborado, New With {.class = "form-check-input"} )
                                        @Html.ValidationMessageFor(Function(model) model.elaborado )                                    
                                </div>                                
                                <div class="form-check">                                    
                                        @Html.LabelFor(Function(model) model.firmado,New With {.class = "form-check-label"})
                                        @Html.CheckBoxFor(Function(model) model.firmado,New With {.class = "form-check-input"})
                                        @Html.ValidationMessageFor(Function(model) model.firmado)
                                 
                                </div>                                  
                                <div class="form-check">                                        
                                        @Html.LabelFor(Function(model) model.rectificado,New With {.class = "form-check-label"})                                    
                                        @Html.CheckBoxFor(Function(model) model.rectificado,New With {.class = "form-check-input"})
                                        @Html.ValidationMessageFor(Function(model) model.rectificado)                                    
                                </div>
                                 

                                 
                            </div>
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
                                   
                                  @Html.LabelFor(Function(model) model.password, new with {.class = "control-label"})
                                  @Html.PasswordFor(Function(model) model.password,New With {.Class = "form-control"})
                                  @Html.ValidationMessageFor(Function(model) model.password)        
                                
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
                                  @Html.TextBoxFor(Function(model) model.cp,New With {.Class = "form-control"})
                                  @Html.ValidationMessageFor(Function(model) model.cp)  
                                    
                                  @Html.LabelFor(Function(model) model.email, new with {.class = "control-label"})
                                  @Html.TextBoxFor(Function(model) model.email,New With {.Class = "form-control"})
                                  @Html.ValidationMessageFor(Function(model) model.email)  
                                    
                                  @Html.LabelFor(Function(model) model.internet, new with {.class = "control-label"})
                                  @Html.CheckBoxFor(Function(model) model.internet,False)
                                  @Html.ValidationMessageFor(Function(model) model.internet)  
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
                                    @Html.TextBoxFor(Function(model) model.plazacob,New With {.Class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.plazacob)
                   
                                </div>
                            </div>
                        </div>

                       
                </div>
                <div role="tabpanel" class="tab-pane" id="Notas">

                    <div class="row">
                        <div class="col-md-6">

                                @Html.LabelFor(Function(model) model.repeco  , new with {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.repeco ,New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.repeco)                   

                        </div>
                        <div class="col-md-6">
                                @Html.LabelFor(Function(model) model.regiva, new with {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.regiva,New With {.Class = "form-control"})
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
        <input type="submit" value="Guardar" class="btn btn-default" />
    </p>  
    
End Using
  

@*  <fieldset>    
              
        <div class="editor-label">
            @Html.LabelFor(Function(model) model.historia)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.historia)
            @Html.ValidationMessageFor(Function(model) model.historia)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.sirac)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.sirac)
            @Html.ValidationMessageFor(Function(model) model.sirac)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.promotor)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.promotor)
            @Html.ValidationMessageFor(Function(model) model.promotor)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.void)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.void)
            @Html.ValidationMessageFor(Function(model) model.void)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.enviafact)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.enviafact)
            @Html.ValidationMessageFor(Function(model) model.enviafact)
        </div>

      
        <div class="editor-label">
            @Html.LabelFor(Function(model) model.fec_update)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.fec_update)
            @Html.ValidationMessageFor(Function(model) model.fec_update)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.folio_envio)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.folio_envio)
            @Html.ValidationMessageFor(Function(model) model.folio_envio)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.updaterec)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.updaterec)
            @Html.ValidationMessageFor(Function(model) model.updaterec)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.modifica)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.modifica)
            @Html.ValidationMessageFor(Function(model) model.modifica)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.idtransact)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.idtransact)
            @Html.ValidationMessageFor(Function(model) model.idtransact)
        </div>

       
    </fieldset>

*@

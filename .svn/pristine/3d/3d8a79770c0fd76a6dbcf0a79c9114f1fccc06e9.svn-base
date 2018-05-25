@ModelType nuve.AdminModels.ModeloUsuario

@Using Html.BeginForm("GuardarUsuario", "Admin", FormMethod.Post ,New With {.id="popupForm"} )

@<div class="panel panel-default">
    <div class="panel-body highlight">
      
            @Html.ValidationSummary(True)
            
            @If Model IsNot Nothing And Model.id > 0 Then
                    @Html.HiddenFor(Function(model) model.id)
            End If             
              <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active"><a href="#Generales" class="nav-link" aria-controls="Basicos" role="tab" data-toggle="tab">Generales</a></li>
                <li role="presentation" class="nav-item" ><a href="#Accesos" class="nav-link" aria-controls="Domicilio" role="tab" data-toggle="tab">Accesos</a></li>
                   <li role="presentation" class="nav-item" ><a href="#Password" class="nav-link" aria-controls="Domicilio" role="tab" data-toggle="tab">Password</a></li>
              </ul>             
              <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="Generales">                    
                 <div class="row">
                     <div class="col-md-6">
                         <div class="form-group">
                             @Html.LabelFor(Function(model) model.userid, new with {.class = "control-label"})
                             @Html.TextBoxFor(Function(model) model.userid, New With {.Class = "form-control"})
                             @Html.ValidationMessageFor(Function(model) model.userid)
                         </div>                        
                     </div>
                     <div class="col-md-6">
                         <div class="form-group">
                           
                         </div>
                     </div>
                 </div>    
                 <div class="row">
                     <div class="col-md-12">
                         <div class="form-group">

                             @Html.LabelFor(Function(model) model.nombre, new with {.class = "control-label"})
                             @Html.TextBoxFor(Function(model) model.nombre, New With {.Class = "form-control"})
                             @Html.ValidationMessageFor(Function(model) model.nombre)

                             @Html.LabelFor(Function(model) model.puesto, new with {.class = "control-label"})
                             @Html.TextBoxFor(Function(model) model.puesto, New With {.Class = "form-control"})
                             @Html.ValidationMessageFor(Function(model) model.puesto)

                         </div>
                     </div>
                 </div>       
                 <div class="row">
                     <div class="col-md-6">
                         <div class="form-group">
                              @Html.LabelFor(Function(model) model.perfil, new with {.class = "control-label"})
                              @Html.DropDownListFor(Function(model) model.perfil, Model.PerfilesDropDown, "-- Seleccione --", New With {.Class = "form-control dropdown"})
                              @Html.ValidationMessageFor(Function(model) model.perfil)

                              @Html.LabelFor(Function(model) model.email, new with {.class = "control-label"})
                              @Html.TextBoxFor(Function(model) model.email, New With {.Class = "form-control"})                         
                              @Html.ValidationMessageFor(Function(model) model.email)
                         </div>
                     </div>
                     <div class="col-md-6">
                              @Html.LabelFor(Function(model) model.sucursal, new with {.class = "control-label"})
                              @Html.DropDownListFor(Function(model) model.sucursal, Model.SucursalDropDown, "-- Seleccione --", New With {.Class = "form-control dropdown"})
                              @Html.ValidationMessageFor(Function(model) model.sucursal)

                              @Html.LabelFor(Function(model) model.activo, New With {.class = "form-check-label"})                                   
                              @Html.CheckBoxFor(Function(model) model.activo, New With {.class = "form-check-input"} )
                              @Html.ValidationMessageFor(Function(model) model.activo )  
                            
                              @Html.LabelFor(Function(model) model.firmante, New With {.class = "form-check-label"})                                   
                              @Html.CheckBoxFor(Function(model) model.firmante, New With {.class = "form-check-input"} )
                              @Html.ValidationMessageFor(Function(model) model.firmante ) 
                         
                     </div>
                 </div>                      
                </div>
                <div role="tabpanel" class="tab-pane" id="Accesos">                    
                              @Html.LabelFor(Function(model) model.trustees, new with {.class = "control-label"})
                              @Html.TextAreaFor(Function(model) model.trustees, New With {.cols="50",.rows="14", .Class = "form-control"})                         
                              @Html.ValidationMessageFor(Function(model) model.trustees)
                </div>   
                <div role="tabpanel" class="tab-pane" id="Password">                     
                             @Html.LabelFor(Function(model) model.Pass1, new with {.class = "control-label"})
                             @Html.PasswordFor(Function(model) model.Pass1, New With {.Class = "form-control"})
                             @Html.ValidationMessageFor(Function(model) model.Pass1)                   
                              
                             @Html.LabelFor(Function(model) model.Pass2, new with {.class = "control-label"})
                             @Html.PasswordFor(Function(model) model.Pass2, New With {.Class = "form-control"})
                             @Html.ValidationMessageFor(Function(model) model.Pass2)

                </div>                      
              </div>      
    </div>
</div>

    @<p>
        <input type="submit" value="Guardar" class="btn bold" id="submit" />
    </p>  
    
End Using

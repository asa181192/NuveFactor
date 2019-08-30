@ModelType nuve.Models.ModeloControlRiesgo



@Using Html.BeginForm("GuardarGarantiaLiquida", "Catalogos", FormMethod.Post ,New With {.id="popupForm" } )
    @Html.ValidationSummary(true, "", new with{ .class = "text-danger" })
    
    @Html.HiddenFor(Function(model) model.id_rec)
    
    @<div class="row">      
            <div class="col-xs-12 col-md-12">                    
                     <div class="form-group"> 
                        @Html.LabelFor(Function(model) model.cuenta, New With {.class = "control-label"})                                   
                        @Html.TextBoxFor(Function(model) model.cuenta, New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.cuenta)   
                     </div>
                     <div class="form-group">
                        @Html.LabelFor(Function(model) model.porcentaje, New With {.class = "control-label"})                                   
                        @Html.TextBoxFor(Function(model) model.porcentaje, New With {.class = "form-control" } )
                        @Html.ValidationMessageFor(Function(model) model.porcentaje )                       
                     </div>
                     <div class="form-group">                                           
                     <label class="chBox">
                        @Html.CheckBoxFor(Function(model) model.liquida,New With {.Class = "form-check-input checked"})
                     <span class="checkmark"></span>
                     </label>
                        @Html.LabelFor(Function(model) model.liquida , new with {.class = "form-check-label"}) 
                        @Html.ValidationMessageFor(Function(model) model.liquida) 
                    </div>  
                    <div class="form-group">
                        <button class="btn btn-default btn-sm" style="margin-top:5px">Guardar</button>
                    </div>        
            </div>        
        </div>   
End Using

@ModelType nuve.Models.ModeloControlRiesgo



@Using Html.BeginForm("GuardarAsociarLineas", "Catalogos", FormMethod.Post ,New With {.id="popupForm" } )
    @Html.ValidationSummary(true, "", new with{ .class = "text-danger" })
    
    @Html.HiddenFor(Function(model) model.propCliente.cliente)
    
    @<div class="row">      
            <div class="col-xs-12 col-md-6">
                <div class="form-group"> 
                    @Html.LabelFor(Function(model) model.idmultiple, New With {.class = "control-label"})                                   
                    @Html.TextBoxFor(Function(model) model.idmultiple, New With {.class = "form-control" } )
                    @Html.ValidationMessageFor(Function(model) model.idmultiple )   
                </div>         
            </div>
            <div class="col-xs-12 col-md-6">
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.lmultiple, New With {.class = "control-label"})                                   
                    @Html.TextBoxFor(Function(model) model.lmultiple, New With {.class = "form-control" } )
                    @Html.ValidationMessageFor(Function(model) model.lmultiple )                       
                </div>               
            </div>          
        </div>   
    @<div class="row">
        <div class="col-xs-12">
           @* @Html.Label("Seleccione las los contratos a asociar" , New With {.class = "control-label"})*@
            @Html.DropDownListFor(Function(model) model.claves  , Model.RelacionLineas ,  New With {.Class = "form-control my_select_box" , .multiple="multiple"})
        </div> 
        <div class="col-xs-2">
                 <div class="form-group">
                     <button class="btn btn-default btn-sm" style="margin-top:5px">Guardar</button>
                </div>
        </div>
    </div>
     
   
    
    
End Using

@ModelType nuve.Models.ModeloControlRiesgo



@Using Html.BeginForm("GuardarClienteLineas", "Catalogos", FormMethod.Post, New With {.id = "popupForm"})
   
    @Html.HiddenFor(Function(model) model.propCliente.cliente)
    
    @<div class="row">      
            <div class="col-xs-12 col-md-12">
                <div class="form-group"> 
                    @Html.LabelFor(Function(model) model.propCliente.clientet24, New With {.class = "control-label"})                                   
                    @Html.TextBoxFor(Function(model) model.propCliente.clientet24, New With {.class = "form-control" } )
                    @Html.ValidationMessageFor(Function(model)  model.propCliente.clientet24 )   
                </div>         
            </div>              
        </div>   
    @<div class="row">       
        <div class="col-xs-2">
                 <div class="form-group">
                     <button class="btn btn-default btn-sm" style="margin-top:5px" type="submit">Guardar</button>
                </div>
        </div>
    </div>
     
   
    
    
End Using
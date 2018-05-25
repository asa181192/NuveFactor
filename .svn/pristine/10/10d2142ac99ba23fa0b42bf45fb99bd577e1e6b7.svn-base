@ModelType nuve.Models.ModeloCodigoGarantia

@Using Html.BeginForm("GuardarCodigoGarantia", "Catalogos", FormMethod.Post ,New With {.id="popupForm"} )
            @Html.ValidationSummary(True)
            
            @If Model IsNot Nothing And Model.codigoid > 0 Then
                    @Html.HiddenFor(Function(model) model.codigoid)
            End If               
            @<div class="form-group">       
                                    @Html.LabelFor(Function(model) model.nombre , new with {.class = "control-label"} )                                    
                                    @Html.TextBoxFor(Function(model) model.nombre, New With {.Class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.nombre)
                                     
                                    @Html.LabelFor(Function(model) model.cod_alterno , new with {.class = "control-label"} )                                    
                                    @Html.TextBoxFor(Function(model) model.cod_alterno, New With {.Class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.cod_alterno)
            </div>                                                    
     @<p>
        <input type="submit" value="Guardar" class="btn bold" />
    </p>  
    
End Using

@ModelType nuve.Models.ModeloTipoGarantia   

<head>
    <meta charset="utf-8" />
    <title>@ViewData("Title")</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="shortcut icon" href="/Images/favicon.ico" type="image/x-icon">
    <link rel="icon" href="~/Images/favicon.ico" type="image/x-icon">   
    <meta name="viewport" content="width=device-width" />   
   <link href="https://fonts.googleapis.com/css?family=News+Cycle" rel="stylesheet">
     </head>

  <style>
    .form-group, input {
        font-size:12px
    } 
    </style>

@Using Html.BeginForm("GuardarTipoGarantia", "Catalogos", FormMethod.Post ,New With {.id="popupForm"} )
            @Html.ValidationSummary(True)
            
            @If Model IsNot Nothing And Model.tipoid > 0 Then
                    @Html.HiddenFor(Function(model) model.tipoid)
            End If               
            @<div class="form-group">                                     
                                     
                                    @Html.LabelFor(Function(model) model.codigoid, New With {.class = "control-label"})                                    
                                    @Html.DropDownListFor(Function(model) model.codigoid, Model.CodigoGarantiaDropDown , "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                    @Html.ValidationMessageFor(Function(model) model.codigoid)
                
                                    @Html.LabelFor(Function(model) model.nombre , new with {.class = "control-label"} )                                    
                                    @Html.TextBoxFor(Function(model) model.nombre, New With {.Class = "form-control"})    
                                    @Html.ValidationMessageFor(Function(model) model.nombre)

                                    @Html.LabelFor(Function(model) model.tip_alterno , new with {.class = "control-label"} )                                    
                                    @Html.TextBoxFor(Function(model) model.tip_alterno, New With {.Class = "form-control"})    
                                    @Html.ValidationMessageFor(Function(model) model.tip_alterno)
                                        
                                    @Html.LabelFor(Function(model) model.concepto , new with {.class = "control-label"} )                                    
                                    @Html.TextBoxFor(Function(model) model.concepto, New With {.Class = "form-control"})    
                                    @Html.ValidationMessageFor(Function(model) model.concepto)
                                        
                                    @Html.LabelFor(Function(model) model.conta_cargo , new with {.class = "control-label"} )                                    
                                    @Html.TextBoxFor(Function(model) model.conta_cargo, New With {.Class = "form-control"})    
                                    @Html.ValidationMessageFor(Function(model) model.conta_cargo)

                                      @Html.LabelFor(Function(model) model.conta_abono , new with {.class = "control-label"} )                                    
                                    @Html.TextBoxFor(Function(model) model.conta_abono, New With {.Class = "form-control"})    
                                    @Html.ValidationMessageFor(Function(model) model.conta_abono)


            </div>                                                    
     @<p>
        <input type="submit" value="Guardar" class="btn bold" />
    </p>  
    
End Using

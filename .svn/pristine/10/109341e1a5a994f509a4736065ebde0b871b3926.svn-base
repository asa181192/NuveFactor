@ModelType nuve.Models.ModeloCodigoGarantia

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

@Using Html.BeginForm("GuardarCodigoGarantia", "Admin", FormMethod.Post ,New With {.id="popupForm"} )
            
            @If Model IsNot Nothing And Model.codigoid > 0 Then
                    @Html.HiddenFor(Function(model) model.codigoid)
            End If      
    
            @<div class="form-group">       
                                    @Html.LabelFor(Function(model) model.nombre , new with {.class = "control-label"} )                                    
                                    @Html.TextBoxFor(Function(model) model.nombre, New With {.Class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.nombre)
            </div>                    
           @<div class="form-group">  
                                    @Html.LabelFor(Function(model) model.cod_alterno , new with {.class = "control-label"} )                                    
                                    @Html.TextBoxFor(Function(model) model.cod_alterno, New With {.Class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.cod_alterno)
          </div>                                                  
     @<p>
        <input type="submit" value="Guardar" class="btn bold" />
    </p>  
    
End Using

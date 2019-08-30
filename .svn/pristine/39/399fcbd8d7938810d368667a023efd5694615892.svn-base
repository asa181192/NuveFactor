    @ModelType nuve.Models.Modelocobranza

    
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


@Using Html.BeginForm("Obtenerdocumentosxpagar", "Cobranza", FormMethod.Post, New With {.id = "popupForm"})
    @Html.ValidationSummary(true)
  
     
    @<div class="form-group">

        @Html.LabelFor(Function(model) model.fec_vence, New With {.class = "control-label"}) 
     
        @Html.LabelFor(Function(model) model.docto, New With {.class = "control-label"}) 

        
    
  </div>                    
  
    @<div>
        <input type="submit" value="Guardar" class="btn bold" />
    </div>

End Using



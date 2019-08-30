    @ModelType nuve.Models.Modeloadeudos

    
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


@Using Html.BeginForm("GuardarAdeudo", "Cobranza", FormMethod.Post, New With {.id = "popupForm"})
    @Html.ValidationSummary(true)
  
    @Html.HiddenFor(Function(model) model.idadeudo )
    @Html.HiddenFor(Function(model) model.SaldoPago)
    @Html.HiddenFor(Function(model) model.movto)
      
    @<div class="form-group">

        @Html.LabelFor(Function(model) model.idadeudo, New With {.class = "control-label"}) 
        @Html.TextBoxFor(Function(model) model.idadeudo, New With {.Class = "form-control", .ReadOnly = True , .style="width:100px"})   
        @Html.ValidationMessageFor(Function(model) model.idadeudo)
     
        @Html.LabelFor(Function(model) model.Adeudo, New With {.class = "control-label"}) 
        @Html.TextBoxFor(Function(model) model.Adeudo, New With {.Class = "form-control", .ReadOnly = True, .style = "width:100px"})   
        @Html.ValidationMessageFor(Function(model) model.Adeudo)    
        
      @If Model.movto = "BA" Then
         @Html.LabelFor(Function(model) model.saldo, New With {.class = "control-label"}) 
         @Html.TextBoxFor(Function(model) model.saldo, New With {.Class = "form-control", .ReadOnly = True})   
         @Html.ValidationMessageFor(Function(model) model.saldo)
      Else
         @Html.LabelFor(Function(model) model.saldo, New With {.class = "control-label"}) 
         @Html.TextBoxFor(Function(model) model.saldo, New With {.Class = "form-control"})   
         @Html.ValidationMessageFor(Function(model) model.saldo)
        
      End If
           
         @Html.LabelFor(Function(model) model.concepto, New With {.class = "control-label"}) 
         @Html.TextAreaFor(Function(model) model.concepto, New With {.Class = "form-control"})   
         @Html.ValidationMessageFor(Function(model) model.concepto)
    
  </div>                    
  
    @<div>
        <input type="submit" value="Guardar" class="btn bold" />
    </div>

End Using



@ModelType nuve.TesoreriaModel.CuentasModel


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
        font-size: 12px;
    }
</style>





@Using Html.BeginForm("GuardarCuenta", "Tesoreria", FormMethod.Post, New With {.id = "popupForm"})
    @Html.ValidationSummary(True)
        
   @Html.HiddenFor(Function(model) model.idctabanco)
   @Html.HiddenFor(Function(model) model.fecha)
   @Html.HiddenFor(Function(model) model.banco) 
   
    @<div class="form-group">
        
        @Html.LabelFor(Function(model) model.ctabanco, New With {.class = "control-label"})                                    
        @Html.TextBoxFor(Function(model) model.ctabanco, New With {.Class = "form-control"})    
        @Html.ValidationMessageFor(Function(model) model.ctabanco)

        @Html.LabelFor(Function(model) model.numbanco, New With {.class = "control-label"})                                    
        @Html.TextBoxFor(Function(model) model.numbanco, New With {.Class = "form-control"})    
        @Html.ValidationMessageFor(Function(model) model.numbanco)

        @Html.LabelFor(Function(model) model.nosucur, New With {.class = "control-label"})                                    
        @Html.TextBoxFor(Function(model) model.nosucur, New With {.Class = "form-control"})    
        @Html.ValidationMessageFor(Function(model) model.nosucur)

        @Html.LabelFor(Function(model) model.banco, New With {.class = "control-label"})                                    
        @Html.DropDownListFor(Function(model) model.idbanco, Model.bancosDropDownList, "<-- Seleccione -->", New With {.Class = "form-control dropdown"})

        @Html.LabelFor(Function(model) model.sucbancaria, New With {.class = "control-label"})                                    
        @Html.TextBoxFor(Function(model) model.sucbancaria, New With {.Class = "form-control"})    
        @Html.ValidationMessageFor(Function(model) model.sucbancaria)

        @Html.LabelFor(Function(model) model.slogan, New With {.class = "control-label"})                                    
        @Html.TextBoxFor(Function(model) model.slogan, New With {.Class = "form-control"})    
        @Html.ValidationMessageFor(Function(model) model.slogan)

        @Html.LabelFor(Function(model) model.ctacontable, New With {.class = "control-label"})                                    
        @Html.TextBoxFor(Function(model) model.ctacontable, New With {.Class = "form-control"})    
        @Html.ValidationMessageFor(Function(model) model.ctacontable)
        
        @Html.LabelFor(Function(model) model.saldo, New With {.class = "control-label"}) 
        @Html.ValidationMessageFor(Function(model) model.saldo)
        @Html.TextBoxFor(Function(model) model.saldo, "{0:N}", New With {.Class = "form-control"})

        @Html.LabelFor(Function(model) model.divisa, New With {.class = "control-label"})                                    
        @Html.DropDownListFor(Function(model) model.moneda, Model.DivisaDropDownList, "<-- Seleccione -->", New With {.Class = "form-control dropdown"})
                      
        <div class="form-group">
            <br />                                           
            <label class="chBox">
                @Html.CheckBoxFor(Function(model) model.cancelado, New With {.Class = "form-check-input checked", .id = "cancelado2"})
            <span class="checkmark"></span>
            </label>
            @Html.Label("Cerrar cuenta") 
            @Html.ValidationMessageFor(Function(model) model.cancelado) 
        </div>
        
        <br>
        <p>
            <input type="submit" value="Guardar" class="btn bold" />
        </p>  
        
    </div>
      

    
End Using



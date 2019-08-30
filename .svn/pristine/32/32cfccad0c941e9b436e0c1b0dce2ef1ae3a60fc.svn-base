@ModelType nuve.Models.ModeloAforos


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

@Using Html.BeginForm("GuardarParidad", "Cobranza", FormMethod.Post, New With {.id = "popupForm"})
    @Html.ValidationSummary(True)

    @<div class="form-group">
        @Html.LabelFor(Function(model) model.contrato, New With {.class = "control-label"})
        @Html.TextBoxFor(Function(model) model.contrato, New With {.Class = "form-control"})
        @Html.ValidationMessageFor(Function(model) model.contrato)
    </div>
    @<div class="form-group">
        @Html.LabelFor(Function(model) model.producto, New With {.class = "control-label"})
        @Html.DropDownListFor(Function(model) model.producto, Model.FelectronicaDropDown, New With {.Class = "form-control dropdown"})
        @Html.ValidationMessageFor(Function(model) model.producto)
    </div>
    
    If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.CATALOGOS_ACTUALIZAR) Then
    @<div>
        <input type="submit" value="Guardar" class="btn bold" />
    </div>
    End If
  

    
End Using

﻿@ModelType nuve.Models.ModeloPar


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

@Using Html.BeginForm("GuardarParidad", "Catalogos", FormMethod.Post, New With {.id = "popupForm"})
    @Html.ValidationSummary(True)
        
    If Model.fecha.Equals(Nothing) Then
    @Html.HiddenFor(Function(model) model.add, New With {.Value = True})     
    @<div class="form-group">
        <label>Fecha</label>
        @Html.TextBoxFor(Function(model) model.fecha, "{0:dd/MM/yyyy}", New With {.class = "form-control", .Value = Today.Date.ToShortDateString(), .ReadOnly = True})
        @Html.ValidationMessageFor(Function(model) model.fecha)
    </div>    
    Else
    @Html.HiddenFor(Function(model) model.add, New With {.Value = False}) 
    @<div class="form-group">
        <label>Fecha</label>
        @Html.TextBoxFor(Function(model) model.fecha, "{0:dd/MM/yyyy}", New With {.class = "form-control", .ReadOnly = True})
        @Html.ValidationMessageFor(Function(model) model.fecha)

    </div>
    End If

    @<div class="form-group">
        @Html.LabelFor(Function(model) model.paridad1, New With {.class = "control-label"})
        @Html.TextBoxFor(Function(model) model.paridad1, "{0:0.0000}", New With {.Class = "form-control"})
        @Html.ValidationMessageFor(Function(model) model.paridad1)

    </div>
    @<div class="form-group">
        @Html.LabelFor(Function(model) model.udis, New With {.class = "control-label"})
        @Html.TextBoxFor(Function(model) model.udis, "{0:000.00000000}", New With {.Class = "form-control"})
        @Html.ValidationMessageFor(Function(model) model.udis)
    </div>
    
    If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.CATALOGOS_ACTUALIZAR) Then
    @<div>
        <input type="submit" value="Guardar" class="btn bold" />
    </div>
    End If
  

    
End Using



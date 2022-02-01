﻿@modeltype nuve.Facturacion.fiscalPfModel

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

@Using Html.BeginForm("GuardarRemisiones", "Facturacion", FormMethod.Post, New With {.id = "popupForm"})
    
    @Html.HiddenFor(Function(model) model.serie, New With {.Value = Model.serie})
    @Html.HiddenFor(Function(model) model.remark)
    @Html.HiddenFor(Function(model) model.seguro)
    @Html.HiddenFor(Function(model) model.ivaseguro)


    
    @<div class="form-group">
        <div class="form-group">
            <div class="form-inline">
                <label>Contrato</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                @Html.TextBoxFor(Function(x) x.contrato, New With {.Class = "form-control", .style = "width:80px", .autocomplete = "off"})
                @Html.ValidationMessageFor(Function(model) model.contrato)
                <input type="text" id="txtContrato" class="form-control" disabled style="width: 410px" />
            </div>
        </div>
        <div class="form-group">
            <div class="form-inline">
                @Html.DropDownListFor(Function(model) model.identidad, Model.identidadDropDownList, New With {.Class = "form-group form-control", .style = "width:118px;"})
                @Html.TextBoxFor(Function(model) model.id, New With {.Class = "form-control", .style = "width:80px", .autocomplete = "off"})
                @Html.ValidationMessageFor(Function(model) model.id)
                <input type="text" id="txtDeudorNombre" class="form-control" disabled style="width: 410px" />
            </div>
        </div>
        <hr />
        <div class="form-group">
            <div class="form-inline">
                <label>Concepto</label>&nbsp;&nbsp;&nbsp;&nbsp;
                @Html.DropDownListFor(Function(model) model.tipo, Model.conceptoDropDownList, New With {.Class = "form-group form-control"})
                <div class="form-group">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <label>Moratoria</label>
                    <label class="rdButtton">
                        @*@Html.RadioButtonFor(Function(model) model.remark, "RE", New With{.checked="checked"})*@
                        <input id="rbMoratorio" type="radio" name="type" value="RE" checked />
                        <span class="radiomark"></span>
                    </label>

                    &nbsp;
                    <label>Nota de cargo</label>
                    <label class="rdButtton">

                        @*@Html.RadioButtonFor(Function(model) model.remark, "RN")*@
                        <input id="rbCargo" type="radio" name="type" value="RN" />
                        <span class="radiomark"></span>
                    </label>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="form-inline">
                <label>Comentario</label>
                @Html.TextAreaFor(Function(model) model.txtConcepto, New With {.Class = "form-control", .Style = "width:530px; max-width:530px; min-width:530px; max-height:70px; min-height:70px;"})
                @Html.ValidationMessageFor(Function(model) model.txtConcepto)

            </div>
        </div>

        <div class="form-group" style="margin-left: 460px;">
            <div class="form-inline">
                <label>Importe</label>
                @Html.TextBoxFor(Function(model) model.base, New With {.Class = "form-control", .style = "width:95px;"})
                @Html.ValidationMessageFor(Function(model) model.base)
            </div>
        </div>
        <div class="form-group" style="margin-left: 430px;">
            <div class="form-inline">
                <label class="chBox">
                    @Html.CheckBoxFor(Function(model) model.ivaBool, New With {.class = "b-form-checkbox", .id = "ivaBool", .autocomplete = "off"})
                    <span class="checkmark"></span>
                </label>
                <label>I.V.A.</label>&nbsp;&nbsp;&nbsp;&nbsp;
                @Html.TextBoxFor(Function(model) model.iva, New With {.Class = "form-control", .style = "width:95px;", .readonly = "readonly"})
            </div>
        </div>
        <div class="form-group" style="margin-left: 460px;">
            <div class="form-inline">
                <label>Total</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                @Html.TextBoxFor(Function(model) model.importe, New With {.Class = "form-control", .style = "width:95px;", .readonly = "readonly"})
            </div>
        </div>
        <div class="form-group" style="margin-left: 532px;">
            <div class="form-inline">
                <button id="btnGuardar" class="btn bold">Guardar</button>
            </div>
        </div>
    </div>
    
End Using
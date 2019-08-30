@ModelType nuve.TesoreriaModel.RegistroCuentasModel

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



@Using Html.BeginForm("GuardarCuentaBancaria", "Tesoreria", FormMethod.Post, New With {.id = "popupForm"})
    @Html.ValidationSummary(True)

    @Html.HiddenFor(Function(model) model.numrec)
    @Html.HiddenFor(Function(model) model.identidad, New With {.value = Model.identidad})
    @Html.HiddenFor(Function(model) model.id, New With {.value = Model.id})
    @Html.HiddenFor(Function(model) model.deudor, New With {.value = Model.deudor})

    @<div>

        <div class="form-group">

            @Html.LabelFor(Function(model) model.cuenta, New With {.class = "control-label"})
            @Html.TextBoxFor(Function(model) model.cuenta, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.cuenta)

            @Html.LabelFor(Function(model) model.divisa, New With {.class = "control-label"})
            @Html.DropDownListFor(Function(model) model.moneda, Model.dropDownDivisa, "<-- Seleccione -->", New With {.Class = "form-control dropdown"})


            @Html.LabelFor(Function(model) model.sucursal, New With {.class = "control-label"})
            @Html.TextBoxFor(Function(model) model.sucursal, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.sucursal)

            @Html.LabelFor(Function(model) model.cuentaid, New With {.class = "control-label"})
            @Html.DropDownListFor(Function(model) model.cuentaid, Model.dropDownBancos, "<-- Seleccione -->", New With {.Class = "form-control dropdown", .id = "inputlg"})

            @Html.LabelFor(Function(model) model.plaza, New With {.class = "control-label"})
            @Html.TextBoxFor(Function(model) model.plaza, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.plaza)

            @Html.LabelFor(Function(model) model.clabe, New With {.class = "control-label"})
            @Html.TextBoxFor(Function(model) model.clabe, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.clabe)

        </div>

        <div class="form-group">

            <div class="form-inline">
                <label class="chBox">
                    @Html.CheckBoxFor(Function(model) model.activo, New With {.Class = "form-check-input checked", .id = "cancelado2"})
                    <span class="checkmark"></span>
                </label>
                @Html.Label("Cuenta Activa")
                @Html.ValidationMessageFor(Function(model) model.activo)

                <label class="chBox">
                    @Html.CheckBoxFor(Function(model) model.garantia, New With {.Class = "form-check-input checked", .id = "cancelado2"})
                    <span class="checkmark"></span>
                </label>
                @Html.Label("Garantía")
                @Html.ValidationMessageFor(Function(model) model.garantia)

            </div>

        </div>

        <div class="form-group">
            <br />
            <input type="submit" value="Guardar" class="btn bold" />
        </div>

    </div>

End Using

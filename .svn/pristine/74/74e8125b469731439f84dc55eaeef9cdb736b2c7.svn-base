@ModelType nuve.ModeloVersion


@Code
    ViewData("Title") = "Parametros"
    Layout = Nothing
End Code

@Using Html.BeginForm("GuardarVersion", "Home", FormMethod.Post, New With {.id = "popupForm"})

    @<div class="row">
        <div class="col-xs-12 col-sm-12 col-md-12">
            <div class="form-group">
                @Html.LabelFor(Function(model) model.version, New With {.class = "control-label"})
                <div class="form-group materail-input-block materail-input-block_primary">
                    @Html.TextBoxFor(Function(model) model.version, New With {.style = "background:white;", .class = "form-control materail-input"})
                </div>
                @Html.ValidationMessageFor(Function(model) model.version)
            </div>
            <div class="form-group">

                @Html.LabelFor(Function(model) model.fecha, New With {.class = "control-label"})
                @Html.TextBoxFor(Function(model) model.fecha, New With {.style = "background:white;", .class = "form-control materail-input"})
                @Html.ValidationMessageFor(Function(model) model.fecha)

            </div>
            <div class="form-group">

                @Html.LabelFor(Function(model) model.notas, New With {.class = "control-label"})
                <div class="form-group materail-input-block materail-input-block_primary">
                    @Html.TextAreaFor(Function(model) model.notas, 15, 10, New With {.style = "background:white;", .class = "form-control materail-input"})
                </div>
                @Html.ValidationMessageFor(Function(model) model.notas)

            </div>
        </div>
    </div>
    @<button class="btn material-btn main-container__column ">Guardar</button>   
    
    
End Using
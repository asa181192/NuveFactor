@ModelType nuve.Models.ModeloUsuarioWeb

<style>
    .form-group, input {
        font-size: 12px;
    }
</style>

@Using Html.BeginForm("GuardarUsuarioWeb", "Catalogos", FormMethod.Post, New With {.id = "popupForm"})
    @Html.ValidationSummary(True)
  
    @Html.HiddenFor(Function(model) model.identidad)
    @Html.HiddenFor(Function(model) model.id)
    
    
    @<div class="row">
        <div class="col-xs-6">
            <div class="form-group">
                @Html.LabelFor(Function(model) model.username, New With {.class = "control-label"})
                @Html.TextBoxFor(Function(model) model.username, New With {.Class = "form-control", .readonly = True})
                @Html.ValidationMessageFor(Function(model) model.username)
            </div>
        </div>
        <div class="col-xs-6">
            <div class="form-group">
                @Html.LabelFor(Function(model) model.folio, New With {.class = "control-label"})
                @Html.TextBoxFor(Function(model) model.folio, New With {.Class = "form-control", .ReadOnly = True})
                @Html.ValidationMessageFor(Function(model) model.folio)
            </div>
        </div>
    </div>
    @<div class="form-group">
        @Html.LabelFor(Function(model) model.nombre, New With {.class = "control-label"})
        @Html.TextBoxFor(Function(model) model.nombre, New With {.Class = "form-control"})
        @Html.ValidationMessageFor(Function(model) model.nombre)
    </div>
    @<div class="form-group">
        @Html.LabelFor(Function(model) model.email, New With {.class = "control-label"})
        @Html.TextBoxFor(Function(model) model.email, New With {.Class = "form-control"})
        @Html.ValidationMessageFor(Function(model) model.email)
    </div> 
    
    If Model.identidad = 1 Then
    @<div class="row">
        <div class="col-xs-5">
            <div class="form-group">
                @Html.LabelFor(Function(model) model.tipo, "Operador", New With {.class = "form-check-label"})
                <label class="rdButtton">
                    @Html.RadioButtonFor(Function(model) model.tipo, 1, New With {.Class = "form-check-input "})
                    <span class="radiomark"></span>
                </label>
                @Html.ValidationMessageFor(Function(model) model.tipo)
            </div>
        </div>
        <div class="col-xs-5">
            <div class="form-group">
                @Html.LabelFor(Function(model) model.tipo, "Administrador", New With {.class = "form-check-label"})
                <label class="rdButtton">
                    @Html.RadioButtonFor(Function(model) model.tipo, 2, New With {.Class = "form-check-input "})
                    <span class="radiomark"></span>
                </label>
                @Html.ValidationMessageFor(Function(model) model.tipo)
            </div>
        </div>
    </div>
    End If
    

    @<div class="form-group">
        @Html.LabelFor(Function(model) model.notas, New With {.class = "control-label"})
        @Html.TextAreaFor(Function(model) model.notas, 7, Nothing, New With {.Class = "form-control"})
        @Html.ValidationMessageFor(Function(model) model.notas)
    </div>
    
    @<div>
        <input type="submit" value="Guardar" class="btn material-btn main-container__column topmargin" />
    </div> 
       
End Using



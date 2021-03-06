﻿@ModelType nuve.AdminModels.ModeloUsuario

@Using Html.BeginForm("GuardarUsuario", "Admin", FormMethod.Post, New With {.id = "popupForm"})

    @<div class="panel panel-default">
        <div class="panel-body highlight">

            @Html.ValidationSummary(True)

            @If Model IsNot Nothing And Model.id > 0 Then
                @Html.HiddenFor(Function(model) model.id)
    End If
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active"><a href="#Generales" class="nav-link" aria-controls="Basicos" role="tab" data-toggle="tab">Generales</a></li>
                <li role="presentation" class="nav-item"><a href="#Accesos" class="nav-link" aria-controls="Domicilio" role="tab" data-toggle="tab">Perfil</a></li>
            </ul>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="Generales">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                @Html.Label("User Id", New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.userid, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.userid)
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label">Nombre</label>
                                @Html.TextBoxFor(Function(model) model.nombre, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.nombre)
                            </div>
                            <div class="form-group">
                                <label class="control-label">Puesto</label>
                                @Html.TextBoxFor(Function(model) model.puesto, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.puesto)
                            </div>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                              <label class="control-label">Correo</label>
                                @Html.TextBoxFor(Function(model) model.email, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.email)
                            </div>
                            <div class="form-group">
                              <label class="control-label">Activo</label>
                                <label class="chBox">
                                    @Html.CheckBoxFor(Function(model) model.activo, New With {.Class = "form-check-input checked"})
                                    <span class="checkmark"></span>
                                </label>
                                @Html.ValidationMessageFor(Function(model) model.activo)
                            </div>
                            <div class="form-group">
                                <label class="control-label">Firmante</label>
                                <label class="chBox">
                                    @Html.CheckBoxFor(Function(model) model.firmante, New With {.Class = "form-check-input checked"})
                                    <span class="checkmark"></span>
                                </label>
                                @Html.ValidationMessageFor(Function(model) model.firmante)
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Sucursal</label>
                                @Html.DropDownListFor(Function(model) model.sucursal, Model.SucursalDropDown, "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                @Html.ValidationMessageFor(Function(model) model.sucursal)
                            </div>

                        </div>
                    </div>
                </div>
                <div role="tabpanel" class="tab-pane" id="Accesos">
                    <div class="form-group">
                        <label class="control-label">Perfil</label>
                        @Html.DropDownListFor(Function(model) model.perfil, Model.PerfilesDropDown, "-- Seleccione Perfil --", New With {.Class = "form-control dropdown"})
                    </div>
                </div>
            </div>
        </div>
    </div>

    @<p>
        <input type="submit" value="Guardar" class="btn bold" id="submit" />
    </p>  
    
End Using

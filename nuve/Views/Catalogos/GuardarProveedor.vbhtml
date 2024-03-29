﻿@ModelType nuve.Models.ModeloProveedor

@Code
    If ViewBag.Layout Then
    @<script src="~/Scripts/CatalogosScripts/GuardarProveedor.js"></script>
        Layout = "~/Views/Shared/_Layout.vbhtml"
    @<div class="head">
        <div class="headForma">
            <div class="headFormaContenido">
                <span>@(IIf(Model.deudor > 0, String.Concat(Model.nombre, "(", Model.deudor.ToString(), ")"), "Nuevo Registro")) </span>
            </div>
        </div>
    </div>       
    End If
End Code




@Using Html.BeginForm("GuardarProveedor", "Catalogos", FormMethod.Post, New With {.id = "popupForm"})

    @<div class="panel panel-default">
        <div class="panel-body highlight">

            @Html.ValidationSummary(True)
            @Html.HiddenFor(Function(model) model.deudor)
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active"><a href="#General" class="nav-link" aria-controls="General" role="tab" data-toggle="tab">Generales</a></li>
                <li role="presentation" class="nav-item"><a href="#Domicilio" class="nav-link" aria-controls="Domicilio" role="tab" data-toggle="tab">Domicilio</a></li>
                <li role="presentation" class="nav-item"><a href="#Contacto" class="nav-link" aria-controls="Contacto" role="tab" data-toggle="tab">Contacto</a></li>
                <li role="presentation" class="nav-item"><a href="#Notas" class="nav-link" aria-controls="Notas" role="tab" data-toggle="tab">Notas</a></li>
            </ul>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="General">
                    <div class="row">
                        <div class="col-xs-6">
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.fec_alta, New With {.class = "control-label"})
                                @If Not Model.fec_alta.Equals(Nothing) Then
                                    @Html.TextBoxFor(Function(model) model.fec_alta, "{0:dd/MM/yyyy}", New With {.class = "form-control", .ReadOnly = True})                                           
                                    @Html.ValidationMessageFor(Function(model) model.fec_alta)
    Else
                                    @Html.TextBoxFor(Function(model) model.fec_alta, "{0:dd/MM/yyyy}", New With {.class = "form-control", .Value = Today.Date.ToShortDateString(), .ReadOnly = True})
                                    @Html.ValidationMessageFor(Function(model) model.fec_alta)
    End If
                            </div>
                        </div>
                        <div class="col-xs-6">
                            <div class="form-group">
                                @Code
                                    If Model.sucursal = 0 Then
                                        Model.sucursal = 2
                                    End If
                                    
                                End Code

                                @Html.LabelFor(Function(model) model.sucursal, New With {.class = "control-label"})
                                @Html.DropDownListFor(Function(model) model.sucursal, Model.SucursalDropDown, New With {.Class = "form-control dropdown"})
                                @Html.ValidationMessageFor(Function(model) model.sucursal)

                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-6">
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.nombre, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.nombre, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.nombre)

                            </div>
                        </div>
                        <div class="col-xs-6">
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.giro)
                                @Html.TextBoxFor(Function(model) model.giro, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.giro)
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-6">
                            <div class="form-group">

                                @Html.LabelFor(Function(model) model.rfc)
                                @Html.TextBoxFor(Function(model) model.rfc, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.rfc)

                                @Html.LabelFor(Function(model) model.curp)
                                @Html.TextBoxFor(Function(model) model.curp, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.curp)


                                @Html.LabelFor(Function(model) model.sirac)
                                @Html.TextBoxFor(Function(model) model.sirac, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.sirac)

                                @Html.LabelFor(Function(model) model.fira_idcon)
                                @Html.TextBoxFor(Function(model) model.fira_idcon, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.fira_idcon)

                            </div>
                        </div>
                        <div class="col-xs-6">
                          @*  <div class="form-group">
                                <div class="form-check">
                                    <label class="chBox">
                                        @Html.CheckBoxFor(Function(model) model.elaborado, New With {.Class = "form-check-input checked"})
                                        <span class="checkmark"></span>
                                    </label>
                                    @Html.LabelFor(Function(model) model.elaborado, New With {.class = "form-check-label"})
                                    @Html.ValidationMessageFor(Function(model) model.elaborado)
                                </div>
                            </div>*@
                            <div class="form-group">
                                <div class="form-check">
                                    <label class="chBox">
                                        @Html.CheckBoxFor(Function(model) model.firmado, New With {.Class = "form-check-input checked"})
                                        <span class="checkmark"></span>
                                    </label>
                                    @Html.LabelFor(Function(model) model.firmado, New With {.class = "form-check-label"})
                                    @Html.ValidationMessageFor(Function(model) model.firmado)
                                </div>
                            </div>
                        @*    <div class="form-group">
                                <div class="form-check">
                                    <label class="chBox">
                                        @Html.CheckBoxFor(Function(model) model.rectificado, New With {.Class = "form-check-input checked"})
                                        <span class="checkmark"></span>
                                    </label>
                                    @Html.LabelFor(Function(model) model.rectificado, New With {.class = "form-check-label"})
                                    @Html.ValidationMessageFor(Function(model) model.rectificado)
                                </div>
                            </div>*@
                        </div>
                    </div>
                </div>
                <div role="tabpanel" class="tab-pane" id="Domicilio">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.calle, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.calle, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.calle)

                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-6">
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.noext, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.noext, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.noext)
                            </div>
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.colonia, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.colonia, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.colonia)
                            </div>

                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.estado, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.estado, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.estado)
                            </div>

                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.telefono, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.telefono, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.telefono)
                            </div>

                            @*  <div class="form-group">
                                @Html.LabelFor(Function(model) model.password, New With {.class = "control-label"})
                                @Html.PasswordFor(Function(model) model.password, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.password)
                            </div>*@



                        </div>

                        <div class="col-xs-6">
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.noint, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.noint, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.noint)
                            </div>
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.municipio, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.municipio, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.municipio)
                            </div>
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.cp, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.cp, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.cp)
                            </div>
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.email, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.email, New With {.Class = "form-control", .PlaceHolder = "Correo@mail.com"})
                                @Html.ValidationMessageFor(Function(model) model.email)
                            </div>
                            @*  <div class="form-group">

                                <label class="chBox">
                                    @Html.CheckBoxFor(Function(model) model.internet, New With {.Class = "form-check-input checked"})
                                    <span class="checkmark"></span>
                                </label>
                                @Html.LabelFor(Function(model) model.internet, New With {.class = "control-label"})
                                @Html.ValidationMessageFor(Function(model) model.internet)
                            </div>*@
                        </div>
                    </div>

                </div>
                <div role="tabpanel" class="tab-pane" id="Contacto">

                    <div class="row">
                        <div class="col-xs-6">
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.responsable, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.responsable, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.responsable)
                            </div>
                          @*  <div class="form-group">
                                @Html.LabelFor(Function(model) model.plaza, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.plaza, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.plaza)
                            </div>*@
                        </div>
                        <div class="col-xs-6">
@*                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.plazacob, New With {.class = "control-label"})
                                @Html.DropDownListFor(Function(model) model.plazacob, Model.SucursalDropDown, New With {.Class = "form-control dropdown"})
                                @Html.ValidationMessageFor(Function(model) model.plazacob)
                            </div>*@

                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.enviafact, New With {.class = "control-label"})
                                @Html.DropDownListFor(Function(model) model.enviafact, Model.FelectronicaDropDown, New With {.Class = "form-control dropdown"})
                                @Html.ValidationMessageFor(Function(model) model.enviafact)
                            </div>

                        </div>
                    </div>
                </div>
                <div role="tabpanel" class="tab-pane" id="Notas">

                    <div class="row">
                        <div class="col-xs-6">
                            <div class="form-group">
                                @code
                                     Model.RegimenDropDown(3).Selected = True
                                End Code
                                @Html.LabelFor(Function(model) model.regiva, New With {.class = "control-label"})
                                @Html.DropDownListFor(Function(model) model.regiva, Model.RegimenDropDown, New With {.Class = "form-control dropdown"})
                                @Html.ValidationMessageFor(Function(model) model.regiva)
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.notas, New With {.class = "control-label"})
                                @Html.TextAreaFor(Function(model) model.notas, 7, Nothing, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.notas)
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.CATALOGOS_ACTUALIZAR) Then
                @<input type="submit" value="Guardar" class="btn bold" style="margin-top: 20px" id="submit" />    
    End If

        </div>

    </div>


    
End Using

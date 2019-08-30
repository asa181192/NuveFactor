@ModelType nuve.Models.ModeloApoderado

@Code
    
    If ViewBag.Layout Then
        Layout = "~/Views/Shared/_Layout.vbhtml"
    @<div class="head">
        <div class="headForma">
            <div class="headFormaContenido">
                <a href="~/Catalogos/Apoderado?clienteId=@(Model.cliente)">
                    <img src="~/Images/menu/menuregresar.png" />
                </a>
                <span>@(IIf(Model.cliente > 0, Model.apoderado, "Nuevo Registro")) </span>
            </div>
        </div>
    </div>  
    End If

End Code

@Section Scripts
    <script src="~/Scripts/CatalogosScripts/GuardarCliente.js"></script>
End Section

<style>
    .ui-dialog {
        height: auto !important;
    }
</style>

@Using Html.BeginForm("GuardarApoderado", "Catalogos", FormMethod.Post, New With {.id = "popupForm"})
    
    @Html.HiddenFor(Function(model) model.id)
    @Html.HiddenFor(Function(model) model.cliente)
    
    @<div class="panel panel-default" style="font-family: 'News Cycles'; font-size: 14px">
        <div class="panel-body highlight">

            @Html.ValidationSummary(True)

            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active"><a href="#Apoderado" class="nav-link" aria-controls="Apoderado" role="tab" data-toggle="tab">Apoderado / Obligado Solidario</a></li>
                <li role="presentation" class="nav-item"><a href="#Domiclio" class="nav-link" aria-controls="Domiclio" role="tab" data-toggle="tab">Datos</a></li>
                <li role="presentation" class="nav-item"><a href="#Poder" class="nav-link" aria-controls="Poder" role="tab" data-toggle="tab">Poder</a></li>
                <li role="presentation" class="nav-item"><a href="#Facultades" class="nav-link" aria-controls="Facultades" role="tab" data-toggle="tab">Facultades</a></li>

            </ul>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="Apoderado">
                    <div class="form-group" style="margin-top: 15px">
                        @Html.LabelFor(Function(model) model.pfisica, New With {.class = "form-check-label"})
                        <label class="rdButtton">
                            @Html.RadioButtonFor(Function(model) model.pfisica, True, New With {.Class = "form-check-input ", .id = "pfisica1"})
                            <span class="radiomark"></span>
                        </label>
                        @Html.ValidationMessageFor(Function(model) model.pfisica)
                    </div>
                    <div class="row" id="GroupPF">
                        <div class="col-xs-6">
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.n)
                                @Html.TextBoxFor(Function(model) model.n, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.n)
                            </div>
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.p, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.p, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.p)
                            </div>
                        </div>
                        <div class="col-xs-6">
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.s)
                                @Html.TextBoxFor(Function(model) model.s, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.s)
                            </div>
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.m, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.m, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.m)
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.pfisica, "Persona Moral", New With {.class = "form-check-label"})
                        <label class="rdButtton">
                            @Html.RadioButtonFor(Function(model) model.pfisica, False, New With {.Class = "form-check-input "})
                            <span class="radiomark"></span>
                        </label>
                        @Html.ValidationMessageFor(Function(model) model.pfisica)
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="form-group" id="GroupPM">
                                @Html.LabelFor(Function(model) model.apoderado, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.apoderado, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.apoderado)
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-6">
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.rfc, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.rfc, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.rfc)
                            </div>
                        </div>
                        <div class="col-xs-6">
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.curp, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.curp, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.curp)
                            </div>
                        </div>
                    </div>
                </div>
                <div role="tabpanel" class="tab-pane" id="Domiclio">
                    <div class="row">
                        <div class="col-xs-6">
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.ap_domicilio, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.ap_domicilio, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.ap_domicilio)
                            </div>
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.ap_estado, New With {.class = "control-label"})
                                @Html.DropDownListFor(Function(model) model.ap_estado, Model.EstadoDropDown, New With {.Class = "form-control dropdown"})
                                @Html.ValidationMessageFor(Function(model) model.ap_estado)
                            </div>
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.ap_cp, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.ap_cp, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.ap_cp)
                            </div>
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.ap_ecivil, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.ap_ecivil, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.ap_ecivil)
                            </div>
                        </div>
                        <div class="col-xs-6">
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.ap_colonia, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.ap_colonia, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.ap_colonia)
                            </div>
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.ap_ciudad, New With {.class = "control-label"})
                                @Html.DropDownListFor(Function(model) model.ap_ciudad, Model.CiudadDropDown, New With {.Class = "form-control dropdown"})
                                @Html.ValidationMessageFor(Function(model) model.ap_ciudad)
                            </div>
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.telefono, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.telefono, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.telefono)
                            </div>
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.ap_ocupa, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.ap_ocupa, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.ap_ocupa)
                            </div>
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.ap_fnac, New With {.class = "control-label"})
                                <div class="form-inline">
                                    <div class='input-group date ap_fechaDataTime'>
                                        @Html.TextBoxFor(Function(model) model.ap_fnac, "{0:dd/MM/yyyy}", New With {.class = "form-control"})
                                        <span class="input-group-addon">
                                            <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                </div>
                                @Html.ValidationMessageFor(Function(model) model.ap_fnac)
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3">
                            <div class="form-group">
                                <label class="chBox">
                                    @Html.CheckBoxFor(Function(model) model.esapoderado, New With {.Class = "form-check-input checked"})
                                    <span class="checkmark"></span>
                                </label>
                                @Html.LabelFor(Function(model) model.esapoderado, New With {.class = "form-check-label"})
                                @Html.ValidationMessageFor(Function(model) model.esapoderado)
                            </div>
                        </div>
                        <div class="col-xs-3">
                            <div class="form-group">
                                <label class="chBox">
                                    @Html.CheckBoxFor(Function(model) model.esobligado, New With {.Class = "form-check-input checked"})
                                    <span class="checkmark"></span>
                                </label>
                                @Html.LabelFor(Function(model) model.esobligado, New With {.class = "form-check-label"})
                                @Html.ValidationMessageFor(Function(model) model.esobligado)
                            </div>
                        </div>
                        <div class="col-xs-3">
                            <div class="form-group">
                                <label class="chBox">
                                    @Html.CheckBoxFor(Function(model) model.esaccion, New With {.Class = "form-check-input checked"})
                                    <span class="checkmark"></span>
                                </label>
                                @Html.LabelFor(Function(model) model.esaccion, New With {.class = "form-check-label"})
                                @Html.ValidationMessageFor(Function(model) model.esaccion)
                            </div>
                        </div>
                        <div class="col-xs-3">
                            <div class="form-group">
                                <label class="chBox">
                                    @Html.CheckBoxFor(Function(model) model.esdeposita, New With {.Class = "form-check-input checked"})
                                    <span class="checkmark"></span>
                                </label>
                                @Html.LabelFor(Function(model) model.esdeposita, New With {.class = "form-check-label"})
                                @Html.ValidationMessageFor(Function(model) model.esdeposita)
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-6">
                            <div class="form-group">
                                <label class="chBox">
                                    @Html.CheckBoxFor(Function(model) model.politica, New With {.Class = "form-check-input checked"})
                                    <span class="checkmark"></span>
                                </label>
                                @Html.LabelFor(Function(model) model.politica, New With {.class = "form-check-label"})
                                @Html.ValidationMessageFor(Function(model) model.politica)
                            </div>
                        </div>
                        <div class="col-xs-6">
                            <div class="form-inline">
                                <div class="form-group">
                                    @Html.LabelFor(Function(model) model.porcentaje, New With {.class = "control-label"})
                                    @Html.TextBoxFor(Function(model) model.porcentaje, New With {.class = "form-control", .style = "width:30%"})
                                    <span>%</span>
                                    @Html.ValidationMessageFor(Function(model) model.porcentaje)
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div role="tabpanel" class="tab-pane" id="Poder">
                    <div class="row">
                        <div class="col-xs-6">
                            @Html.Label("Escritura del Poder")
                            <div class="row">
                                <div class="col-xs-4">
                                    <div class="form-group">
                                        @Html.LabelFor(Function(model) model.ep_numnot, New With {.class = "control-label"})
                                        @Html.TextBoxFor(Function(model) model.ep_numnot, New With {.class = "form-control"})
                                        @Html.ValidationMessageFor(Function(model) model.ep_numnot)
                                    </div>
                                </div>
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        @Html.LabelFor(Function(model) model.ep_nombre, New With {.class = "control-label"})
                                        @Html.TextBoxFor(Function(model) model.ep_nombre, New With {.class = "form-control"})
                                        @Html.ValidationMessageFor(Function(model) model.ep_nombre)
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        @Html.LabelFor(Function(model) model.ep_localidad, New With {.class = "control-label"})
                                        @Html.TextBoxFor(Function(model) model.ep_localidad, New With {.class = "form-control"})
                                        @Html.ValidationMessageFor(Function(model) model.ep_localidad)
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-6">
                                    <div class="form-group">
                                        @Html.LabelFor(Function(model) model.ep_fecha, New With {.class = "control-label"})
                                        <div class="form-inline">
                                            <div class='input-group date ap_fechaDataTime'>
                                                @Html.TextBoxFor(Function(model) model.ep_fecha, "{0:dd/MM/yyyy}", New With {.class = "form-control"})
                                                <span class="input-group-addon">
                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                </span>
                                            </div>
                                        </div>
                                        @Html.ValidationMessageFor(Function(model) model.ep_fecha)
                                    </div>
                                </div>
                                <div class="col-xs-6">
                                    <div class="form-group">
                                        @Html.LabelFor(Function(model) model.ep_escrit, New With {.class = "control-label"})
                                        @Html.TextBoxFor(Function(model) model.ep_escrit, New With {.class = "form-control"})
                                        @Html.ValidationMessageFor(Function(model) model.ep_escrit)
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="col-xs-6">
                            @Html.Label("Inscripcion del poder")
                            <div class="row">
                                <div class="col-xs-6">
                                    <div class="form-group">
                                        @Html.LabelFor(Function(model) model.ep_numero, New With {.class = "control-label"})
                                        @Html.TextBoxFor(Function(model) model.ep_numero, New With {.class = "form-control"})
                                        @Html.ValidationMessageFor(Function(model) model.ep_numero)
                                    </div>
                                    <div class="form-group">
                                        @Html.LabelFor(Function(model) model.ep_folio, New With {.class = "control-label"})
                                        @Html.TextBoxFor(Function(model) model.ep_folio, New With {.class = "form-control"})
                                        @Html.ValidationMessageFor(Function(model) model.ep_folio)
                                    </div>
                                </div>
                                <div class="col-xs-6">
                                    <div class="form-group">
                                        @Html.LabelFor(Function(model) model.ep_libro, New With {.class = "control-label"})
                                        @Html.TextBoxFor(Function(model) model.ep_libro, New With {.class = "form-control"})
                                        @Html.ValidationMessageFor(Function(model) model.ep_libro)
                                    </div>
                                    <div class="form-group">
                                        @Html.LabelFor(Function(model) model.ep_auxiliar, New With {.class = "control-label"})
                                        @Html.TextBoxFor(Function(model) model.ep_auxiliar, New With {.class = "form-control"})
                                        @Html.ValidationMessageFor(Function(model) model.ep_auxiliar)
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        @Html.LabelFor(Function(model) model.ep_poderlocal, New With {.class = "control-label"})
                                        @Html.TextBoxFor(Function(model) model.ep_poderlocal, New With {.class = "form-control"})
                                        @Html.ValidationMessageFor(Function(model) model.ep_poderlocal)
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-6">
                                    <div class="form-group">
                                        @Html.LabelFor(Function(model) model.ep_fechareg, New With {.class = "control-label"})
                                        <div class="form-inline">
                                            <div class='input-group date ap_fechaDataTime'>
                                                @Html.TextBoxFor(Function(model) model.ep_fechareg, "{0:dd/MM/yyyy}", New With {.class = "form-control"})
                                                <span class="input-group-addon">
                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                </span>
                                            </div>
                                        </div>
                                        @Html.ValidationMessageFor(Function(model) model.ep_fechareg)
                                    </div>
                                </div>
                                <div class="col-xs-6">
                                    <div class="form-group">
                                        @Html.LabelFor(Function(model) model.ep_volumen, New With {.class = "control-label"})
                                        @Html.TextBoxFor(Function(model) model.ep_volumen, New With {.class = "form-control"})
                                        @Html.ValidationMessageFor(Function(model) model.ep_volumen)
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div role="tabpanel" class="tab-pane" id="Facultades">
                    <div class="row">
                        <div class="col-xs-12">
                            <div style="padding: 30px 10px">
                                <div class="form-group">
                                    <label class="chBox">
                                        @Html.CheckBoxFor(Function(model) model.dominio, New With {.Class = "form-check-input checked"})
                                        <span class="checkmark"></span>
                                    </label>
                                    @Html.LabelFor(Function(model) model.dominio, New With {.class = "form-check-label"})
                                    @Html.ValidationMessageFor(Function(model) model.dominio)
                                </div>
                                <div class="form-group" style="margin-top: 15px">
                                    @Html.LabelFor(Function(model) model.dfacultad, New With {.class = "form-check-label"})
                                    <label class="rdButtton">
                                        @Html.RadioButtonFor(Function(model) model.dfacultad, True, New With {.Class = "form-check-input ", .id = "dfacultad1"})
                                        <span class="radiomark"></span>
                                    </label>
                                    @Html.ValidationMessageFor(Function(model) model.dfacultad)

                                    @Html.LabelFor(Function(model) model.dfacultad, "Mancomunado", New With {.class = "form-check-label"})
                                    <label class="rdButtton">
                                        @Html.RadioButtonFor(Function(model) model.dfacultad, False, New With {.Class = "form-check-input "})
                                        <span class="radiomark"></span>
                                    </label>
                                    @Html.ValidationMessageFor(Function(model) model.dfacultad)

                                </div>
                                <div class="form-group">
                                    <label class="chBox">
                                        @Html.CheckBoxFor(Function(model) model.admon, New With {.Class = "form-check-input checked"})
                                        <span class="checkmark"></span>
                                    </label>
                                    @Html.LabelFor(Function(model) model.admon, New With {.class = "form-check-label"})
                                    @Html.ValidationMessageFor(Function(model) model.admon)
                                </div>
                                <div class="form-group" style="margin-top: 15px">
                                    @Html.LabelFor(Function(model) model.afacultad, New With {.class = "form-check-label"})
                                    <label class="rdButtton">
                                        @Html.RadioButtonFor(Function(model) model.afacultad, True, New With {.Class = "form-check-input ", .id = "afacultad1"})
                                        <span class="radiomark"></span>
                                    </label>
                                    @Html.ValidationMessageFor(Function(model) model.afacultad)

                                    @Html.LabelFor(Function(model) model.afacultad, "Mancomunado", New With {.class = "form-check-label"})
                                    <label class="rdButtton">
                                        @Html.RadioButtonFor(Function(model) model.afacultad, False, New With {.Class = "form-check-input "})
                                        <span class="radiomark"></span>
                                    </label>
                                    @Html.ValidationMessageFor(Function(model) model.afacultad)

                                </div>
                                <div class="form-group">
                                    <label class="chBox">
                                        @Html.CheckBoxFor(Function(model) model.endoso, New With {.Class = "form-check-input checked"})
                                        <span class="checkmark"></span>
                                    </label>
                                    @Html.LabelFor(Function(model) model.endoso, New With {.class = "form-check-label"})
                                    @Html.ValidationMessageFor(Function(model) model.endoso)
                                </div>
                                <div class="form-group" style="margin-top: 15px">
                                    @Html.LabelFor(Function(model) model.efacultad, New With {.class = "form-check-label"})
                                    <label class="rdButtton">
                                        @Html.RadioButtonFor(Function(model) model.efacultad, True, New With {.Class = "form-check-input ", .id = "efacultad1"})
                                        <span class="radiomark"></span>
                                    </label>
                                    @Html.ValidationMessageFor(Function(model) model.efacultad)

                                    @Html.LabelFor(Function(model) model.efacultad, "Mancomunado", New With {.class = "form-check-label"})
                                    <label class="rdButtton">
                                        @Html.RadioButtonFor(Function(model) model.efacultad, False, New With {.Class = "form-check-input "})
                                        <span class="radiomark"></span>
                                    </label>
                                    @Html.ValidationMessageFor(Function(model) model.efacultad)

                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.CATALOGOS_ACTUALIZAR) Then
    @<input type="submit" value="Guardar" class="btn bold" id="submit" />  
    End If

End Using

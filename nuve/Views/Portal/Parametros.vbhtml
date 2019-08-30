﻿@ModelType nuve.portal.ParametrosModel


@Code
    ViewData("Title") = "Parametros"
End Code

@Section Scripts
    <script src="~/Scripts/PortalScripts/parametros.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
    <script src="~/Scripts/mdtimepicker.js"></script>
End Section

@Section Css
    <link rel="stylesheet" href="~/Content/mdtimepicker.css" />
End Section

<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="@Request.UrlReferrer.ToString()">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Administracion de parametros</span>
        </div>
    </div>
</div>

@Using Html.BeginForm("GuardarParametros", "Portal", FormMethod.Post, New With {.id = "popupForm"})
    @<div class="container topmargin">
        <div class="panel panel-default material-panel">
            <div class="panel-body material-panel__body">
                <div class="main-container__column">
                    <div class="row">
                        <div class="col-xs-12 col-sm-12 col-md-12">
           @*                 <div class="form-group">
                                @Html.LabelFor(Function(model) model.tasa, New With {.class = "control-label"})
                                 <div class="form-group materail-input-block materail-input-block_primary">
                                    @Html.TextBoxFor(Function(model) model.tasa, New With {.Class = "form-control materail-input"})
                                </div>
                                @Html.ValidationMessageFor(Function(model) model.tasa)

                            </div>
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.tasadlls , New With {.class = "control-label"})
                                <div class="form-group materail-input-block materail-input-block_primary">
                                    @Html.TextBoxFor(Function(model) model.tasadlls, New With {.Class = "form-control materail-input"})
                                </div>
                                @Html.ValidationMessageFor(Function(model) model.tasadlls)

                            </div>*@

                           @*<div class="form-group">
                                @Html.LabelFor(Function(model) model.mailserver , New With {.class = "control-label"})
                              <div class="form-group materail-input-block materail-input-block_primary">
                                    @Html.TextBoxFor(Function(model) model.mailserver, New With {.Class = "form-control materail-input"})
                                </div>
                                @Html.ValidationMessageFor(Function(model) model.mailserver)

                            </div>*@
                            
                          
@*                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.dominio , New With {.class = "control-label"})
                               <div class="form-group materail-input-block materail-input-block_primary">
                                    @Html.TextBoxFor(Function(model) model.dominio, New With {.Class = "form-control materail-input"})
                                </div>
                                @Html.ValidationMessageFor(Function(model) model.dominio)

                            </div>*@
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.timeend , New With {.class = "control-label"})
                                <div class="form-group materail-input-block materail-input-block_primary">
                                    @Html.TextBoxFor(Function(model) model.timeend, New With {.style = "background:white;", .class = "form-control materail-input", .readonly = True})
                                </div>
                                @Html.ValidationMessageFor(Function(model) model.timeend)
                            </div>
                            <div class="form-group">

                                @Html.LabelFor(Function(model) model.timecte , New With {.class = "control-label"})
                               <div class="form-group materail-input-block materail-input-block_primary">
                                    @Html.TextBoxFor(Function(model) model.timecte, New With {.style = "background:white;", .class = "form-control materail-input", .readonly = True})
                                </div>
                                @Html.ValidationMessageFor(Function(model) model.timecte)

                            </div>
                            <div class="form-group topmargin">
                                <label class="chBox">
                                    @Html.CheckBoxFor(Function(model) model.online, New With {.Class = "form-check-input checked"})
                                    <span class="checkmark"></span>
                                </label>
                                @Html.LabelFor(Function(model) model.online, New With {.class = "form-check-label"})
                            </div>
                        </div>
                    </div>
                    <button class="btn material-btn main-container__column ">Guardar</button>
                </div>
            </div>
        </div>
    </div>
    
    
    
End Using
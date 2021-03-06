﻿@ModelType nuve.contrasena_cambio

@Code
    ViewData("Title") = "Recuperar Contraseña"
    Layout = Nothing
End Code



<!DOCTYPE html>

<html>

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Factor</title>
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @Scripts.Render("~/bundles/jquery-ui")
    @Scripts.Render("~/bundles/validation")
      @Scripts.Render("~/bundles/jqueryLoadingLogin")  

    @Styles.Render("~/Content/flexbox")
    @Styles.Render("~/Content/bootstrap")
    @Styles.Render("~/Content/css")
    @Styles.Render("~/Content/jquery-ui")
      @Styles.Render("~/Content/jqueryLoadingLogin")
</head>

<body id="test" class="bodyback">

    <div class="loginWrapper">

        <div class="container v-center">
            <div class="row">
                <div class="col-xs-12">
                    <div style="text-align: center">
                        <img src="~/Images/vepormas.png" alt="BX+" style="margin: 5px auto;" class="hidden-xs" />
                        <img src="~/Images/vepormas.png" alt="BX+" style="margin: 5px auto; margin-top: 30px" class="visible-xs" />
                    </div>
                </div>
            </div>
            @code
                Html.RenderPartial("_Alerts")
            End Code


            <div class="loginBox middle-xs">
                <div class="row">
                    <div class="col-xs-12">

                        <div class="ca logingUp loginShow active" style="margin-top: 10px; padding: 0px 0px 0px 0px;">
                            @Using Html.BeginForm("ReiniciarPassword", "Account", New With {.ReturnUrl = ViewData("ReturnUrl"), .Class = "form-signin"}, FormMethod.Post, New With {.id = "loginform"})
                                @Html.AntiForgeryToken()
                                @Html.HiddenFor(Function(model) model.userid)
                                @Html.HiddenFor(Function(model) model.username)
                                @<div class="vi_log">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <h5 style="text-align: center">Favor de ingresar una nueva contraseña</h5>
                                        </div>
                                    </div>
                                    <div class="form-group row form-group-sm">
                                        <div class="col-sm-12">
                                            @Html.PasswordFor(Function(m) m.nueva, New With {.Class = "form-control", .placeholder = "Contraseña nueva", .type = "password"})
                                        </div>
                                        @Html.ValidationMessageFor(Function(model) model.nueva)
                                    </div>
                                    <div class="form-group row form-group-sm">
                                        <div class="col-sm-12">
                                            @Html.PasswordFor(Function(m) m.confirmacion, New With {.Class = "form-control", .placeholder = "Confirmar contraseña nueva", .type = "password"})
                                        </div>
                                        @Html.ValidationMessageFor(Function(model) model.confirmacion)
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-6">
                                            <input type="submit" value="Actualizar" class="btn btn-black btn-sm" style="width: 100px" />

                                        </div>
                                        <div class="col-sm-6">
                                            <button type="button" style="float: right" class="help btn btn-black btn-sm">Ayuda</button>
                                        </div>

                                    </div>
                                </div>
                                @<div class="form-group">
                                    <h6>
                                        <small>
                                            @Html.ValidationSummary(True)
                                        </small>
                                    </h6>
                                </div>            
                            End Using
                        </div>
                        <div class="logingUp">
                            <h4 style="text-align: center">Formato de contraseña</h4>
                            <ul>
                                <li>De 8 a 10 dígitos de longitud</li>
                                <li>Debe de tener por lo menos una letra mayúscula</li>
                                <li>Debe de contener por lo menos una letra minúscula</li>
                                <li>Debe de incluir por lo menos un número</li>
                                <li>Debe de contar por lo menos con uno de los siguientes caracteres especiales:\+*/:_.{}[],</li>
                            </ul>
                            <div class="containerFlex col-sm-12">
                                <input type="button" value="Volver" class="back btn btn-black btn-sm" style="width: 100px" />
                            </div>
                        </div>


                    </div>
                </div>
            </div>

            <br />

            <div style="margin: 10px auto 0px auto; text-align: center; color: #ffffff;">
                <strong style="color: #3BB0C9">Advertencia</strong><br />
                Este sistema es para el uso exclusivo de usuarios autorizados. Los usuarios pueden ser monitoreados.<br />
                Al utilizar este sistema consienten expresamente a este monitoreo, y se les advierte que si el monitoreo revela 
			    posibles actividades criminales, el personal de seguridad puede proveer la evidencia de dicho monitoreo a los 
			    oficiales que apliquen la ley.
            </div>

            <div style="margin: 0px auto 0px auto; text-align: center; margin-top: 20px;">
                <span style="color: #ffffff;">Sistema Integral de Factoraje</span>
            </div>
        </div>

        <div id="notSupportedBrowser" style="display: none; width: 100%; margin-top: 100px; text-align: center; font-size: 12px; font-weight: bold;">
            La versión del navegador que está utilizando es inferior a la 8.0 y no está soportada por BX+ Banca
		    en Línea.<br />
            Para consulta comuníquese sin costo 01 800 823 5534 en donde con gusto le atenderemos.
        </div>

    </div>

</body>
</html>

<script type="text/javascript">
    window.history.forward();
    window.location.hash = 'no-back-button';
    window.location.hash = 'Again-No-back-button';
    window.onhashchange = function () { window.location.hash = 'no-back-button'; };



    $(document).submit(function (e) {

        e.preventDefault();

        $('body').loading({
            message: 'Cargando...',
            theme: 'dark',
            onStart: function (loading) {
                loading.overlay.slideDown(1200);
            }
        });

        var url = $('#loginform')[0].action;
        $.ajax({
            type: "POST",
            url: url,
            data: $('#loginform').serialize(),
            beforeSend: function () {
                //$.Loading(true);
            },
            success: function (json) {
                if (json.Result) {
                    window.location.href= json.url
                }
                else {
                    mensajemodal(json.Text, "warning", data.titulo);
                }

            },
            error: function () {
                //mensajemodal('Ocurrio un error al consultar la informacion favor de intentar de nuevo!!', 'warning');
            },
            complete: function () {
                //$.Loading(false);
            }

        });

    });

    $(document).ready(function () {


        $(".help").click(function (e) {
            e.preventDefault()

            $(".active").fadeOut('slow', function () {
                $(this).removeClass('active').next().fadeIn('slow', function () {
                    $(this).addClass("active")
                });
            });

        });

        $(".back").click(function (e) {
            e.preventDefault()

            $(".active").fadeOut('slow', function () {
                $(this).removeClass('active').prev().fadeIn('slow', function () {
                    $(this).addClass("active")
                });
            });

        });


        $(document).tooltip({
            items: ".input-validation-error",
            content: function () {
                return $("[data-valmsg-for='" + $(this).attr('id') + "']").text();
            }
        });

    });

    $("#loginform").tooltip({
        items: ".input-validation-error",
        content: function () {
            return $("[data-valmsg-for='" + $(this).attr('id') + "']").text();
        }
    });
</script>


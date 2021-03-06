﻿//Inicializacion de variables
var tabla;
var title;
var data =
{
    inicializarTabla: function () {

        tabla = $('#table')
            .DataTable({
                ajax: {
                    "url": "../Admin/ObtenerListaUsuarios/", // url del controlador a consultar 
                    "Type": "GET",
                    "data": function (d) { }, // parametros a enviar al controlador 
                    "dataSrc": function (json) {
                        if (typeof (json.Mensaje) != 'undefined') {
                            //mensajemodal(json.Mensaje, 'warning');
                            return {};
                        } else {
                            return json.Results;
                        }
                    }
                },
                initComplete: function (settings, json) {
                    $.Loading(false);
                },
                //dom: "lfrtBip",
                //buttons: [
                //      'excel', 'pdf', 'print' // permiten agregar botones para exportar a excel 
                //],
                paging: true, // permite la paginacion en la tabla .
                lengthMenu: [10, 20, 30], // Cantidad de registros mostrados por pantalla 
                searching: true, // genera cuadro de busqueda
                ordering: false, // genera ordenamiento de columnas 
                order: [[0, 'desc']], // ordena la primer columna
                responsive: true, // realiza la tabla responsiva en moviles
                destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
                columns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 
           { data: "userid" },
           { data: "nombre" },
           { data: "puesto" },
           { data: "activo" },
            {
                data: "id", "width": "50px", "render": function (data) {
                    return '<a class="pass" href="../Admin/resetPassword?id=' + data + '" add="true" ><button type="button" class="btn glyphicon glyphicon-envelope"></button></a>';
                }, orderable: false
            },
           {
               data: "id", "width": "50px", "render": function (data) {
                   return '<a class="popup" href="../Admin/GuardarUsuario?id=' + data + '" add="true" ><button type="button" class="btn glyphicon glyphicon-pencil"></button></a>';
               }, orderable: false
           }
                ],
                "columnDefs": [
                    { "className": "dt-body-center", "targets": [4] } // permite centrar botones de edicion 
                ]
            });


    }, //Funcion que inicializa la tabla 
    openPopUp: function (pageUrl) {
        var $pageContent = $('<div>');

        $pageContent.load(pageUrl, function () {

            $pageContent.dialog({
                width: '600', // overcomes width:'auto' and maxWidth bug
                height: 'auto',
                modal: true,
                show: 'fade',
                title: title == null ? "Nuevo Registro" : "Actualizar registro",
                hide: 'fade',
                fluid: true, //new option
                resizable: false,
                create: function (event, ui) { //permite inicializar parametros o campos dentro de el popup creado


                    //permite reiniciar el validado de informacion al despelgar una ventana modal
                    var form = $("#popupForm").closest("form");
                    form.removeData('validator');
                    form.removeData('unobtrusiveValidation');
                    $.validator.unobtrusive.parse(form);

                    // Validacion de tool tip 
                    $pageContent.tooltip({
                        items: ".input-validation-error",
                        content: function () {
                            return $("[data-valmsg-for='" + $(this).attr('id') + "']").text();
                        }
                    });

                    data.validacionCampos();

                    $("#submit").click(function (e) {
                        e.preventDefault();
                        if ($("#Pass1").val() != $("#Pass2").val()) {
                            $("#Pass2").addClass("input-validation-error");
                            $("[data-valmsg-for='Pass2']").removeClass("field-validation-valid")
                            $("[data-valmsg-for='Pass2']").addClass("field-validation-error")
                            $("[data-valmsg-for='Pass2']").html("<span>Las contraseñas deben coincidir.</span>")
                        }
                        else {
                            $("#popupForm").submit();
                        }

                    });


                    // propiedades para el maximo y mino de anchura                   
                    //$(this).css("minWidth", "400px");
                },
                close: function () {
                    $pageContent.dialog('destroy').remove();
                }
            });
        });

        $pageContent.on('submit',
           '#popupForm',
           function (e) {
               var url = $('#popupForm')[0].action;
               $.ajax({
                   type: "POST",
                   url: url,
                   data: $('#popupForm').serialize(),
                   beforeSend: function () {
                       $.Loading(true);
                   },
                   success: function (data) {
                       if (data.Result) {
                           mensajemodal(data.Text, 'success');
                           tabla.ajax.reload(null, false);
                       } else {
                           mensajemodal(data.Text, 'warning');
                       }
                       $pageContent.dialog('close');
                   },
                   error: function () {
                       mensajemodal('Ocurrio un error al consultar la informacion favor de intentar de nuevo!!', 'warning');

                   },
                   complete: function () {
                       $.Loading(false);
                   }
               });

           });
    },
    fluidDialog: function () {
        var $visible = $(".ui-dialog:visible");
        // each open dialog
        $visible.each(function () {
            var $this = $(this);
            var dialog = $this.find(".ui-dialog-content").data("ui-dialog");
            // if fluid option == true
            if (dialog.options.fluid) {
                var wWidth = $(window).width();
                // check window width against dialog width
                if (wWidth < (parseInt(dialog.options.maxWidth) + 50)) {
                    // keep dialog from filling entire screen
                    $this.css("max-width", "90%");
                } else {
                    // fix maxWidth bug
                    $this.css("max-width", dialog.options.maxWidth + "px");
                }
                //reposition dialog
                dialog.option("position", dialog.options.position);
            }
        });

    },
    validacionCampos: function () {

        jQuery.validator.addMethod(
            'date',
            function (value, element, params) {
                if (this.optional(element)) {
                    return true;
                };
                var result = false;
                try {
                    $.datepicker.parseDate("dd/mm/yy", value);
                    result = true;
                } catch (err) {
                    result = false;
                }
                return result;
            },
            ''
        );
    },// validacion de campos 
    inicializarObjetos: function () {
        data.inicializarTabla();
    },
    ajax: function (url, tipo, data) {
        $.ajax({
            type: tipo,
            url: url,
            beforeSend: function () {
                $.Loading(true);
            },
            success: function (data) {
                if (data.Result) {
                    mensajemodal(data.Text, data.color, data.titulo);
                    //if (tabla !== undefined) {
                    //    tabla.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar
                    //}
                } else {
                    mensajemodal(data.Text, data.color, data.titulo);
                }
            },
            error: function () {
                mensajemodal('Ocurrio un error al realizar la accion favor de intentar de nuevo !!', 'warning');
            },
            complete: function () {
                $.Loading(false);
            }

        });
    }

}

$(document).ready(function (e) {

    data.inicializarObjetos();


    //Eventos 
    $("#tableContainer").on('click', 'a.popup',
        function (e) {
            e.preventDefault();
            title = $(this).attr("add") // set the title for popup
            data.openPopUp($(this).attr('href'));
        });


    $(window).resize(function () {
        data.fluidDialog();
    });

    tabla.on('click', 'a.pass', function (e) {
        $('#dialog-confirm').text("Se reiniciara el password , ¿Desea continuar?")
        var url = $(this).attr("href")
        $('#dialog-confirm').dialog({
            resizable: false,
            height: "auto",
            title: "Password temporal",
            width: 400,
            modal: true,
            buttons: {
                "Aceptar": function () {
                    data.ajax(url, "POST", null)
                    $(this).dialog('close')
                },
                "Cancelar": function () {
                    $(this).dialog('close')
                }
            }
        })
        e.preventDefault()
    });
});
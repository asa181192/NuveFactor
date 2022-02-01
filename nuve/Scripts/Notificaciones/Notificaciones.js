﻿var fecha = $('#fecha')
var tablaFinanciero;

$.ajaxSetup({
    // Disable caching of AJAX responses For IE !!!
    cache: false
});

Noti = {
    inicializaTabla: function (fecha) {

        tablaFinanciero = $('#tableNotificaciones')
            .DataTable({

                ajax: {
                    "url": "../Notificaciones/ConsultaNotificaciones",
                    "contentType": "application/json",
                    "Type": "GET",
                    "data": function (d) { d.fecha = fecha }, // parametros a enviar al controlador 
                    "dataSrc": function (json) {
                        if (typeof (json.Mensaje) != 'undefined') {
                            return {};
                        } else {
                            return json.Results;
                        }
                    }
                },
                initComplete: function (settings, json) {
                    $.Loading(false);
                },
                "dom": 'lfrtip',
                "lengthMenu": [25, 50, 75], // Cantidad de registros mostrados por pantalla                 
                paging: true, // permite la paginacion en la tabla .                
                searching: true, // genera cuadro de busqueda
                ordering: false, // genera ordenamiento de columnas 
                order: [[0, 'desc']], // ordena la primer columna
                responsive: true, // realiza la tabla responsiva en moviles
                destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva .                 
                columns: [ // permite saber que columnas se usaran del json retornado desde el servidor .                     

           { data: "idrec", orderable: false },

           { data: "contrato", orderable: false },
           { data: "nombre", orderable: false },
           { data: "deudor", orderable: false },
           { data: "deudorname", orderable: false },

           { data: "envio", orderable: false },
           { data: "descrip", orderable: false },
           {
               data: "idrec", "render": function (data) {
                   return '<a href="../Notificaciones/DescargarArchivo?idrec=' + data + '" ><button name="detail" type=button" class="btn glyphicon glyphicon-search "></button></a>';
               }
           },
           {
               data: "idrec", "render": function (data) {
                   return '<a class="popup" id="' + data + '"><button name="detail" type=button" class="btn glyphicon glyphicon-envelope"></button></a>';
               }
           }
                ],
                columnDefs: [
                    { "width": "500px", "className": "dt-body-left", "targets": [2, 4, 5] },
                    { "width": "auto", "className": "dt-body-center dt-head-center", "targets": [0, 1, 2, 3, 4, 5, 6, 7, 8] }
                    //{ "width": "auto", "className": "dt-body-left", "targets": [3,5,7] }                    
                ]
            });
    }, //Funcion que inicializa la tabla 
    openPopUp: function (pageUrl, tipo) {
        var $pageContent = $('<div>');

        $pageContent.load(pageUrl, function () {

            $pageContent.dialog({
                width: '500', // overcomes width:'auto' and maxWidth bug
                height: 'auto',
                modal: true,
                show: 'fade',
                title: title,
                hide: 'fade',
                fluid: true, //new option
                resizable: false,
                create: function (event, ui) { //permite inicializar parametros o campos dentro de el popup creado

                    //permite reiniciar el validado de informacion al despelgar una ventana modal
                    var form = $("#popupForm").closest("form");
                    form.removeData('validator');
                    form.removeData('unobtrusiveValidation');
                    $.validator.unobtrusive.parse(form);

                    form.keypress(function (e) {
                        if (e.which == 13) {
                            return false;
                        }
                    });

                    $pageContent.tooltip({
                        items: ".input-validation-error",
                        content: function () {
                            return $("[data-valmsg-for='" + $(this).attr('id') + "']").text();
                        }
                    });
                },
                close: function () {
                    $pageContent.dialog('destroy').remove();
                }
            });
        });

        $pageContent.on('click', '#btnGuardar',
           function (e) {
               e.preventDefault()

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
                           mensajemodal(data.Text, 'success', 'Movimientos');

                           tablaFinanciero.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar


                       } else {
                           mensajemodal(data.Text, 'warning');
                       }
                       $pageContent.dialog('close');


                   },
                   error: function () {
                       mensajemodal('Ocurrio un error al consultar la informacion favor de intentar de nuevo!!', 'warning', 'Error Ajax 404');

                   },
                   complete: function () {
                       $.Loading(false);
                   },
               });
               e.preventDefault();
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
    }, // validacion de campos
    generarNotificaciones: function () {

        var data = {
            'fecha': fecha.val()
        }

        $.ajax({
            url: "../Notificaciones/Notificar",
            data: data,
            type: "POST",
            success: function (response) {

                mensajemodal(response, 'success', 'Notificaciones')
                $.Loading(false);
                Noti.inicializaTabla(fecha.val())

            }, error: function (response) {
                $.Loading(false);
                console.log(response)

                mensajemodal(response, 'warning', 'Ajax 404')

            }
        })
    },
    cargaDatepicker: function () {
        $('#fecha').datepicker({ dateFormat: 'dd/mm/yy' }).datepicker("setDate", new Date())
        $('#fecha').keypress(function () { return false })
    },
    reenviarNotificacion: function (idrec) {

        data = {
            "idrec": idrec
        }

        $.ajax({
            url: "../Notificaciones/ReenvioMail",
            data: data,
            type: "POST",
            dataType: "JSON",
            success: function (response) {
                mensajemodal(response.Mensaje, 'success', 'Reenvío de Notificaciones')
            },
            error: function () {
                mensajemodal('Error AJAX(404)', 'warning', 'Error')
            }
        })
    }
}

$(document).ready(function () {

    Noti.cargaDatepicker()
    Noti.inicializaTabla(fecha.val())

    $('#btnConsultar').click(function () {
        Noti.inicializaTabla(fecha.val())
    })

    $('#notificar').click(function () {

        $('#lblFecha').text($('#fecha').val())

        $(function () {

            $('#dialog-confirm').dialog({
                resizable: true,
                height: "auto",
                width: 400,
                modal: true,
                buttons: {
                    "Generar notificaciones": function () {
                        $.Loading(true);
                        Noti.generarNotificaciones()


                        $(this).dialog('close')
                    },
                    Cancel: function () {
                        $(this).dialog('close')
                    }
                }
            })
        })
    })

    $('#tableContainer').on('click', 'a.popup', function (e) {

        idrec = $(this).attr('id')


        email = $(this).parents("tr").find("td")[5].innerHTML;


        console.log(email)


        if ($.trim(email) != "") {
            Noti.reenviarNotificacion(idrec)
        } else {
            mensajemodal( 'Actualice el correo electrónico.', 'warning', 'Reenvío de factura.')
        }


        


    })

})
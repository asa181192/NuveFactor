//Inicializacion de variables
var tabla;
var title;
var nombre; 
var data =
{
    inicializarTabla: function (cliente) {

        tabla = $('#table')
            .DataTable({
                ajax: {
                    "url": "../Catalogos/ObtenerApoderados/", // url del controlador a consultar 
                    "Type": "GET",
                    "data": function (d) { d.cliente = cliente }, // parametros a enviar al controlador 
                    "dataSrc": function (json) {
                        if (typeof (json.Mensaje) != 'undefined') {
                            mensajemodal(json.Mensaje, 'warning');
                            return {};
                        } else {
                            return json.Results;
                        }
                    }
                },
                initComplete: function (settings, json) {
                    $.Loading(false);
                },
                paging: false, // permite la paginacion en la tabla .               
                ordering: false, // genera ordenamiento de columnas 
                order: [[0, 'desc']], // ordena la primer columna
                responsive: true, // realiza la tabla responsiva en moviles
                destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
                columns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 
           {
               data: "apoderado", orderable: false, "render": function (data) {
                   nombre = data
                   return data
               }
           },
           {
               data: "esapoderado", "render": function (data) {
                 return data == true ?  'SI' :  'NO'
               }
           },
           {
                data: "esobligado", "render": function (data) {
                    return data == true ?  'SI' :  'NO'
                }
           },
           {
                data: "esaccion", "render": function (data) {
                    return data == true ?  'SI' :  'NO'
                }
           },
           {
                data: "esdeposita", "render": function (data) {
                    return data == true ?  'SI' :  'NO'
                }
           },
           {
               data: "id", "width": "50px", "render": function (data) {
                   return '<a class="popup" href="../Catalogos/GuardarApoderado?clienteid=' + data + '" add=' + data + '  nombre="' + nombre + '"  ><button type="button" class="btn glyphicon glyphicon-pencil"></button></a>';
               }
           },
           {
               data: "id", "width": "50px", "render": function (data) {
                   return '<a class="cancel" href="../Catalogos/CancelarApoderado?clienteid=' + data + '" add="true" ><button type="submit" class="btn glyphicon glyphicon-remove"></button></a>';
               }
           }
                ],
                "columnDefs": [
                    { "className": "dt-center", "targets": [1,2,3,4,5,6] } // permite centrar botones de edicion 
                ]
            });


    }, //Funcion que inicializa la tabla 
    openPopUp: function (pageUrl) {
        var $pageContent = $('<div>');

        $pageContent.load(pageUrl, function () {

            $pageContent.dialog({
                width: '720', // overcomes width:'auto' and maxWidth bug
                height: 'auto',
                modal: true,
                show: 'fade',
                title: title == null ? "Nuevo Registro" : nombre ,
                hide: 'fade',
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
                    data.inicializarObjetos();
                    data.eventos();
                    data.validacionCampos();
                }
                ,
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
                           mensajemodal(data.Text, 'success', data.titulo);
                           if (tabla !== undefined) {
                               tabla.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar
                           }
                       } else {
                           mensajemodal(data.Text, 'warning', data.titulo);
                       }
                       if (data.Tipo == 1 || data.Tipo == 2) {
                           $pageContent.dialog('close');
                       }
                   },
                   error: function () {
                       mensajemodal('Ocurrio un error al consultar la informacion favor de intentar de nuevo!!', 'warning');

                   },
                   complete: function () {
                       $.Loading(false);
                   }
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
    },// validacion de campos 
    inicializarObjetos: function () {
        if ($("#pfisica1").is(':checked')) {
            $("#GroupPM :input").val("")
            $("#GroupPM :input").prop('disabled', true);
        }
        else {
            $("#GroupPF :input").prop('disabled', true);
            $("#GroupPF :input").val("")
        }    
        $(".ap_fechaDataTime").datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            ignoreReadonly: true,
            widgetPositioning: {
                horizontal: 'left',
                vertical: 'top'
            }
        }).keydown(function () { return false });
        $('#porcentaje').mask('000.00', { reverse: true });
        $("#popupForm").find(':input').each(function () {

            var value = $(this).val()
            $(this).val(value.trim())

        });
        $("#ap_ciudad").chosen({
            width: "100%",
            no_results_text: "Ningun Resultado !"

        });
    },
    eventos : function(){
        $("#pfisica1").change(function (e) {
            $("#GroupPF :input").prop('disabled', false);
            $("#apoderado").val("")
            $("#GroupPM :input").prop('disabled', true);
        });

        $("#pfisica").change(function (e) {
            $("#GroupPF :input").prop('disabled', true);
            $("#GroupPF :input").val("")
            $("#GroupPM :input").prop('disabled', false);
        });
    }
}

$(document).ready(function (e) {
    //Esto nos permite Abrir modal dentro de modal . 
    $.fn.modal.Constructor.prototype.enforceFocus = function () { };

    data.inicializarTabla($("#cliente").val())

    $("#tableContainer").on('click', 'a.popup',
       function (e) {
           e.preventDefault();
           title = $(this).attr("add") // set the title for popup
           nombre = $(this).attr("nombre")
           data.openPopUp($(this).attr('href'));

       });

    $("#tableContainer").on('click', 'a.cancel',
       function (e) {
           e.preventDefault();
           href =  $(this).attr('href') 
           $(function () {
               $("#dialog-confirm").dialog({
                   resizable: false,
                   height: "auto",
                   width: 400,
                   modal: true,
                   buttons: {
                       "Cancelar Apoderado": function () {

                           $.ajax({
                               url: href,
                               type: 'POST',
                               datatype: 'JSON',
                               contentType: 'application/json',
                               success: function (data) {

                                   if (data.Result) {
                                       mensajemodal(data.Text, 'success');
                                       if (data.Tipo == 2) {
                                           tabla.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar
                                       }
                                   } else {
                                       mensajemodal(data.Text, 'warning');
                                   }
                                   $('#dialog-confirm').dialog("close");
                               }
                           })

                       },
                       Cancel: function () {

                           $(this).dialog("close");

                       }
                   }
               })
           })

       });

    $(window).resize(function () {
        data.fluidDialog();
    });
});
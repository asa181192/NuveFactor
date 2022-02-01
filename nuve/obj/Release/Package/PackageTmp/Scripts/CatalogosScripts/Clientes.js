﻿//Inicializacion de variables
var tabla;
var title;
var CtrlRiesgoLiga = $("#CtrlRiesgo").attr('href')
var btnCtrlRiesgo = $("#CtrlRiesgo")
var data =
{
    inicializarTabla: function () {

        tabla = $('#table')
            .DataTable({
                ajax: {
                    "url": "../Catalogos/ObtenerListaClientes/", // url del controlador a consultar 
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
                paging: true, // permite la paginacion en la tabla .
                lengthMenu: [10, 20, 30], // Cantidad de registros mostrados por pantalla 
                searching: true, // genera cuadro de busqueda
                ordering: false, // genera ordenamiento de columnas 
                order: [[0, 'desc']], // ordena la primer columna
                responsive: true, // realiza la tabla responsiva en moviles
                destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
                columns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 
           { data: "cliente" },
           { data: "nombre" },
           { data: "rfc" },
           {
               data: "cliente", "width": "50px", "render": function (data) {
                   return '<a class="popup" href="../Catalogos/GuardarCliente?clienteid=' + data + '" add="true" ><button type="button" class="btn glyphicon glyphicon-pencil"></button></a>';
               }, orderable: false
           }
                ],
                "columnDefs": [
                    { "className": "dt-body-center", "targets": [3] } // permite centrar botones de edicion 
                ]
            });


    }, //Funcion que inicializa la tabla 
    openPopUp: function (pageUrl) {
        var $pageContent = $('<div>');

        $pageContent.load(pageUrl, function () {

            $pageContent.dialog({
                width: 'auto', // overcomes width:'auto' and maxWidth bug
                height: 'auto' ,
                modal: true,
                show: 'fade',
                title: title == null ? "Nuevo Registro" : "Actualizar registro",
                hide: 'fade',
                fluid: true, //new option
                resizable: false,   
                create: function (event, ui) { //permite inicializar parametros o campos dentro de el popup creado
                        
                    $("#ac_fechaDataTime").datetimepicker({
                        format: 'DD/MM/YYYY',
                        locale: 'es',
                        widgetPositioning: {
                            horizontal: 'left',
                            vertical: 'top'
                        }
                    });
                    $("#ac_fechareDataTime").datetimepicker({
                        format: 'DD/MM/YYYY',
                        locale: 'es',
                        widgetPositioning: {
                            horizontal: 'left',
                            vertical: 'top'
                        }
                    });
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
                           mensajemodal(data.Text, 'success');
                           if (data.Tipo == 2) {
                               tabla.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar
                           }
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
        data.inicializarTabla(); // Realiza consulta al mes actual y año actual al carga la pagina pro primera vez 
        btnCtrlRiesgo.addClass("disabled")
    }
}

$(document).ready(function (e) {

    data.inicializarObjetos(); 

    tabla.on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
            btnCtrlRiesgo.addClass("disabled")
        }
        else {            
            tabla.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
            btnCtrlRiesgo.removeClass('disabled');
            btnCtrlRiesgo.removeAttr("href")
            btnCtrlRiesgo.attr("href", CtrlRiesgoLiga + "?clienteid=" + tabla.row('.selected').data()['cliente'] + '&nombre=' + tabla.row('.selected').data()['nombre'])
        }
    });

    $(window).resize(function () {
        data.fluidDialog();
    });



});
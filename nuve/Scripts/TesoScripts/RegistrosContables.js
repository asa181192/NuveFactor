﻿//Inicializacion de variables
var tablaFinanciero;
var btnConsulta = $('#btnConsultar');
var identidad = $('#identidad');
var deudor = $('#deudor');
var cuenta = $('#cuenta');

var registro = 1
//var ddlCuenta = $('#ddlCuentas').val()
var title;

$.ajaxSetup({
    // Disable caching of AJAX responses For IE !!!
    cache: false
});

var reg =
{
    inicializarTabla: function (deudor, identidad) {
        
        tablaFinanciero = $('#tableCuentas')
            .DataTable({
                ajax: {
                    "url": "../Tesoreria/consultaCuentasBancarias", // url del controlador a consultar 
                    "contentType": "application/json",
                    "Type": "GET",
                    "data": function (d) { d.deudor = deudor, d.identidad = identidad }, // parametros a enviar al controlador 
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
                dom: "Bfrtip",
                buttons: [
                      'excel', 'pdf', 'print' // permiten agregar botones para exportar a excel 
                ],
                paging: true, // permite la paginacion en la tabla .
                lengthMenu: [10], // Cantidad de registros mostrados por pantalla 
                searching: true, // genera cuadro de busqueda
                ordering: true, // genera ordenamiento de columnas 
                order: [[0, 'desc']], // ordena la primer columna
                responsive: true, // realiza la tabla responsiva en moviles
                destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
                columns: [ // permite saber que columnas se usaran del json retornado desde el servidor .                     

           { data: "numrec", orderable: false },
           { data: "cuenta", orderable: false },
           { data: "nombre", orderable: false },
           { data: "divisa", orderable: false },
           { data: "status", orderable: false },
           { data: "clabe","width": "150px", orderable: false },
           {
               data: "numrec", "width": "50px", "render": function (data) {
                   return '<a class="popup" href="../Tesoreria/consultarCuentaBancariaDetalle?numrec=' + data + '" ><button name="cancel" type="submit" class="btn glyphicon glyphicon-pencil"></button></a>';
               }, orderable: false, className: 'dt-body-center'
           },
                ],
                "columnDefs": [
                    { "className": "dt-body-center", "targets": [5] } // permite centrar botones de edicion 
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
                    
                    $pageContent.tooltip({
                        items: ".input-validation-error",
                        content: function () {
                            return $("[data-valmsg-for='" + $(this).attr('id') + "']").text();
                        }
                    });

                    $("#popupForm").find(':input').each(function () {

                        var value = $(this).val()
                        $(this).val(value.trim())

                    })
                    
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

                           tablaFinanciero.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar

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
    consultacliente: function () {

        datos = {
            'deudor' : deudor.val(),
            'identidad' : identidad.val()
        }       

        $.ajax({
            type: 'GET',
            datatype: "JSON",
            contentType: "application/json; charset=utf-8",
            url: '../Tesoreria/consultaDeudor',
            data: datos,
            success: function (response) {

                if (response.nombre) {
                    $('#cliente').text(response.nombre)
                } else {

                    $('#cliente').text('No se encontró el deudor')
                }
            },
            error: function () {

                mensajemodal('Ocurrio un error al consultar al deudor, intente nuevamente.', 'warning')

            }


        })
        

    }
}

$(document).ready(function (e) {

    //Esto nos permite Abrir modal dentro de modal . 
    $.fn.modal.Constructor.prototype.enforceFocus = function () { };

    reg.validacionCampos();

    reg.inicializarTabla(deudor.val(), identidad.val())

    $("#tableContainer").on('click', 'a.popup', function (e) {
        e.preventDefault();
                
        result = $(this).attr('href') 
        result = result + '&id=' + deudor.val() + '&identidad=' + identidad.val()
        if ($(this).attr('id') == 'btnTraspaso') {
            title = "Registro de cuentas bancarias - Alta"
        } else {
            title = "Registro de cuentas bancarias - Actualizar"
        }
        reg.openPopUp(result);
    });
    
    reg.consultacliente()
});
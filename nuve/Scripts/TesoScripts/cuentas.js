﻿//Inicializacion de variables
var tablaFinanciero;
var btnConsulta = $('#btnConsultar');
var fecha = $('#month');
var title;
cancel = $('#cancelado').prop('checked')


$.ajaxSetup({
    // Disable caching of AJAX responses For IE !!!
    cache: false
});

var cuentas =
{
    inicializarTabla: function (cancelado) {
        
        
        tablaFinanciero = $('#tableCuentas')
            .DataTable({
                
                ajax: {
                    "url": "../Tesoreria/ObtenerCuentasBanco", // url del controlador a consultar 
                    "Type": "GET",
                    "data": function (d) { d.cancelado = cancelado }, // parametros a enviar al controlador 
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
           { data: "ctabanco", orderable: false },
           { data: "banco", orderable: true },           
           { data: "saldo", render: $.fn.dataTable.render.number(',', '.', '2', '$'), orderable: false, className: 'dt-body-right' },
           { data: "divisa", orderable: false },
           { data: "cancel", orderable: false },
           {
               data: "idctabanco", "width": "50px", "render": function (data) {
                   return '<a class="popup" href="../Tesoreria/ObtenerDetalleCuenta?ctaid=' + data + '" add="' + data + '" ><button type="button" class="btn glyphicon glyphicon-pencil"></button></a>';
               }, orderable: false
           },          
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
                width: '400', // overcomes width:'auto' and maxWidth bug
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

                    cuentas.validacionCampos();
                },
                close: function () {
                    $pageContent.dialog('destroy').remove();
                }
            });
        });

        $pageContent.on('submit',
           '#popupForm',
           function (e) {



               if ($('#cancelado2').prop('checked') && $('#saldo').val() != 0) {
                                      
                   mensajemodal("Para cancelar el saldo debe ser igual a cero.", 'danger');

               } else {
                   
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
                           //$pageContent.dialog('close');                      


                       },
                       error: function () {
                           mensajemodal('Ocurrio un error al consultar la informacion favor de intentar de nuevo!!', 'warning');

                       },
                       complete: function () {
                           $.Loading(false);
                       },

                   });

               }

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
    } // validacion de campos 
}




$(document).ready(function (e) {
   

    
    
    $('#cancelado').click(function () {
        
        if ($('#cancelado').prop('checked')) {
            cancel = true
        } else {
            cancel = false
        }

        cuentas.inicializarTabla(cancel)

    })


    cuentas.inicializarTabla(cancel)

    title = $(this).attr("add") // set the title for popup

    $("#tableContainer").on('click', 'a.popup',
        function (e) {
            e.preventDefault();
            title = $(this).attr("add") // set the title for popup
            cuentas.openPopUp($(this).attr('href'));
            
            

        });

});
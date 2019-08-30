﻿//Inicializacion de variables
var title;
var dropdownSucursal = $("#dropdownSucursal");
var tablaComprador;
var proveedor =
{
    inicializarTabla: function (sucursal) {

        tablaComprador = $('#tableComprador')// Evento se dispara cuando se ha cargado la taba con la informacion de ajax y se na inicializado 
              .DataTable({
                  ajax: {
                      "url": "../Catalogos/ObtenerListaCompradores/", // url del controlador a consultar 
                      "Type": "GET",
                      "data": function (d) { d.sucursal = sucursal }, // parametros a enviar al controlador 
                      "dataSrc": function (json) {
                          if (typeof (json.Mensaje) != 'undefined') {
                              $.Loading(false);
                              return {};
                          } else {
                              return json.Results;
                          }
                      }
                  },
                  dom: "lfrtBip", //cambia el order de los controles en el datatable 
                  buttons: [
                        'excel', 'pdf', 'print' // permiten agregar botones para exportar a excel 
                  ],
                  deferRender: true,
                  paging: true, // permite la paginacion en la tabla .
                  lengthMenu: [10, 15, 30], // Cantidad de registros mostrados por pantalla 
                  searching: true, // genera cuadro de busqueda
                  ordering: true, // genera ordenamiento de columnas 
                  //order: [[0, 'desc']], // ordena la primer columna
                  responsive: true, // realiza la tabla responsiva en moviles
                  destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
                  columns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 
             { data: "nombre", orderable: true },
             { data: "deudor" },
             {
                 data: "deudor", "width": "50px", "render": function (data) {
                     return '<a class="popup" href="../Catalogos/GuardarComprador?deudor=' + data + '" valor="' + data + '" ><button type="button" class="btn glyphicon glyphicon-pencil"></button></a>';
                 }, orderable: false
             } // Hace referencia al boton de Editar
                  ],
                  "columnDefs": [
                      { "className": "dt-body-center", "targets": [2] } // permite centrar botones de edicion 
                  ]
              });


    }, //Funcion que inicializa la tabla 
    openPopUp: function (pageUrl) {
        var $pageContent = $('<div>');

        $pageContent.load(pageUrl,
            function () {
                $pageContent.dialog({
                    width: 'auto', // overcomes width:'auto' and maxWidth bug
                    height: 'auto',
                    modal: true,
                    show: 'fade',
                    title: title == null ? "Nuevo Registro" : "Actualizar registro",
                    hide: 'fade',
                    fluid: true, //new option
                    resizable: false,   
                    create: function (event, ui) { // setea elementos internos del popup 

                        var form = $("#popupForm").closest("form");
                        form.removeData(
                            'validator'); //permite reiniciar el validado de informacion al despelgar una ventana modal
                        form.removeData('unobtrusiveValidation');
                        $.validator.unobtrusive.parse(form);

                        $pageContent.tooltip({
                            items: ".input-validation-error",
                            content: function () {
                                return $("[data-valmsg-for='" + $(this).attr('id') + "']").text();
                            }
                        }); 

                        // Inicializacion de elementos monetarios 
                        $('#cobertura').mask('000,000,000,000,000.00', { reverse: true });

                        //Inicializacion de fecha 
                        $("#endoso").datetimepicker({
                            format: 'DD/MM/YYYY',
                            locale: 'es',
                            ignoreReadonly: true,
                            widgetPositioning: {
                                horizontal: 'left',
                                vertical: 'top'
                            }
                        });
                        
                        proveedor.validacionCampos();
                    },
                    open: function (event, ui) {
                        
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
                            if (tablaComprador !== undefined) {
                                tablaComprador.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar
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

    }, // popup
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

    }, //popup responsivo
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

   
    proveedor.inicializarTabla(dropdownSucursal.val());
    dropdownSucursal.change(function (e) {
        proveedor.inicializarTabla(dropdownSucursal.val());
    });

    $("#tableContainer").on('click', 'a.popup',
        function (e) {
            e.preventDefault();
            title = $(this).attr("valor") // set the title for popup
            proveedor.openPopUp($(this).attr('href'));

        });
    $(window).resize(function () {
        proveedor.fluidDialog();
    });


});


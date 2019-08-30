﻿//Inicializacion de variables

var dropdownSucursal = $("#dropdownSucursal");
var tablaPromotor;
var nombre; 
var promotor =
{
    inicializarTabla: function (sucursal) {

        tablaPromotor = $('#table')// Evento se dispara cuando se ha cargado la taba con la informacion de ajax y se na inicializado 
              .DataTable({
                  ajax: {
                      "url": "../Catalogos/ObtenerListaPromotor/", // url del controlador a consultar 
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
                  deferRender: true,
                  paging: true, // permite la paginacion en la tabla .
                  lengthMenu: [10, 15, 30], // Cantidad de registros mostrados por pantalla 
                  searching: true, // genera cuadro de busqueda
                  ordering: false, // genera ordenamiento de columnas 
                  //order: [[0, 'desc']], // ordena la primer columna
                  responsive: true, // realiza la tabla responsiva en moviles
                  destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
                  columns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 
             { data: "promotor" },
             {
                 data: "nombre", orderable: false, "render": function (data) {
                     nombre = data
                     return data
                 }
             },
             { data: "activo1", orderable: false  },
             { data: "idt24", orderable: false },
             {                 
                 data: "promotor", "width": "50px", "render": function (data) {
                     return '<a class="popup" href="../Catalogos/GuardarPromotor?clave=' + data + '" add=' + data +' nombre="'+ nombre +'"><button type="button" class="btn glyphicon glyphicon-pencil"></button></a>';
                 }, orderable: false
             } // Hace referencia al boton de Editar
                  ],
                  "columnDefs": [
                      { "className": "dt-body-center", "targets": [4] } // permite centrar botones de edicion 
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
                    title: title == null ? "Nuevo Registro" :  nombre+" (" + title + ")",
                    hide: 'fade',
                    fluid: true, //new option
                    resizable: false,
                    create: function (event, ui) { // setea elementos internos del popup 

                        var form = $("#popupForm")
                        form.removeData('validator'); //permite reiniciar el validado de informacion al despelgar una ventana modal
                        form.removeData('unobtrusiveValidation');
                        $.validator.unobtrusive.parse(form);
                       
                        if ($("#interno").is(':checked')) {
                            $("#tipopromo").prop('disabled', false);
                        } else {
                            $("#tipopromo").prop('disabled', true);
                        }

                        $("#popupForm").find(':input').each(function () {

                            var value = $(this).val()
                            $(this).val(value.trim())

                        });

                        $('#rfc').keyup(function () {
                            $(this).val($(this).val().toUpperCase());
                        });
                      
                        // Validacion de tool tip 
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
        
        //Eventos
                  
        $pageContent.on('click', '#interno', function (e) {
            if ($(this).is(':checked')) {
                $("#tipopromo").prop('disabled', false);
            } else {
                $("#tipopromo").prop('disabled', true);
                $("#tipopromo").val("")
            }
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
                            if (tablaPromotor !== undefined) {
                                tablaPromotor.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar
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

    //Esto nos permite Abrir modal dentro de modal . 
    $.fn.modal.Constructor.prototype.enforceFocus = function () { };

    promotor.validacionCampos();
    promotor.inicializarTabla(dropdownSucursal.val())
    dropdownSucursal.change(function (e) {
        promotor.inicializarTabla(dropdownSucursal.val());
    });

    $("#tableContainer").on('click', 'a.popup',
        function (e) {
            e.preventDefault();
            title = $(this).attr("add") // set the title for popup
            nombre = $(this).attr("nombre")
            promotor.openPopUp($(this).attr('href'));         
        });
    $(window).resize(function () {
        promotor.fluidDialog();
    });


});


﻿//Inicializacion de variables

var table;
var bitacora;
var data =
{
    inicializarTabla: function (identidad, id) {

        table = $('#table')// Evento se dispara cuando se ha cargado la taba con la informacion de ajax y se na inicializado 
              .DataTable({
                  ajax: {
                      "url": "../Catalogos/ObtenerUsuariosWeb/", // url del controlador a consultar 
                      "Type": "GET",
                      "data": function (d) { d.id = id, d.identidad = identidad }, // parametros a enviar al controlador 
                      "dataSrc": function (json) {
                          if (typeof (json.Mensaje) != 'undefined') {
                              $.Loading(false);
                              mensajemodal(json.Mensaje, json.Color, json.titulo);
                              return {};
                          } else {
                              return json.Results;
                          }
                      }
                  },
                  paging: true, // permite la paginacion en la tabla .
                  lengthMenu: [10, 15, 30], // Cantidad de registros mostrados por pantalla 
                  searching: true, // genera cuadro de busqueda
                  ordering: false, // genera ordenamiento de columnas 
                  responsive: true, // realiza la tabla responsiva en moviles
                  destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
                  aoColumns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 
             { data: "username", "width": "100px" },
             { data: "nombre" },
             {
                 data: "activo", "render": function (data) {
                     return data == true ? "ACTIVO" : "BLOQUEADO"
                 }
             },
             { data: "fec_alta" },
             {
                 data: function (data, type, dataToSet) {
                     return '<a class="popup" href="../Catalogos/GuardarUsuarioWeb?folio=' + data.folio + '&id=' + $("#Clave").val() + '&identidad=' + $("#identidad").val() + ' " add="true" ><button type="button" class="btn glyphicon glyphicon-search"></button></a>';
                 }, "width": "50px"
             },
             {
                 data: function (data, type, dataToSet) {
                     return '<a class="pass" href="../Catalogos/GenerarPassword?folio=' + data.folio + '" add="true" ><button type="button" class="btn glyphicon glyphicon-envelope"></button></a>';
                 }, "width": "50px"
             }
             ,
             {
                 data: function (data, type, dataToSet) {
                     return '<a class="popup" href="../Catalogos/WebMonitor?username=' + data.username + '&nombre=' + encodeURIComponent(data.nombre) + '" bitacora="true" ><button type="button" class="btn glyphicon glyphicon-eye-open"></button></a>';
                 }, "width": "50px"
             }
             // Hace referencia al boton de Editar
                  ],
                  "columnDefs": [
                      { "className": "dt-center", "targets": [0, 2, 3, 4, 5, 6] } // permite centrar botones de edicion 
                  ]
              });


    }, //Funcion que inicializa la tabla 
    inicializarTablaDetalle: function (username, fechaini, fechafin) {

        tableDetalle = $('#tableDetalle')// Evento se dispara cuando se ha cargado la taba con la informacion de ajax y se na inicializado 
              .DataTable({
                  ajax: {
                      "url": "../Catalogos/ConsultaDetalleBitacora/", // url del controlador a consultar 
                      "Type": "GET",
                      "data": function (d) { d.username = username, d.fechaini = fechaini, d.fechafin = fechafin }, // parametros a enviar al controlador 
                      "dataSrc": function (json) {
                          if (typeof (json.Mensaje) != 'undefined') {
                              $.Loading(false);
                              mensajemodal(json.Mensaje, json.Color, json.titulo);
                              return {};
                          } else {
                              return json.Results;
                          }
                      }
                  },
                  dom: 'Bfrtip',
                  buttons: [
                                          {
                                              text: 'PDF', // Nuevo Botón personalizado en PDF 
                                              title: 'Bitacora del ' + fechaini + ' al ' + fechafin,
                                              header: true,
                                              footer: true,
                                              extend: 'pdfHtml5',
                                              message: function () {
                                                  return '[' + username + '] ' + $("#nombre").val()
                                              },
                                              orientation: 'portrait',
                                              exportOptions: {
                                                  columns: ':visible',
                                                  columns: [0,1]
                                              },
                                              pageSize: 'A4',
                                              customize: function (doc) {
                                                  doc.content.splice(1, 0, {
                                                      margin: [0, 0, 0, 12],
                                                      alignment: 'left',
                                                      width: 80,
                                                      height: 30,
                                                      image: 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAPAAAABVCAYAAAB3hGnPAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAAZdEVYdFNvZnR3YXJlAEFkb2JlIEltYWdlUmVhZHlxyWU8AAADJGlUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4gPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS4zLWMwMTEgNjYuMTQ1NjYxLCAyMDEyLzAyLzA2LTE0OjU2OjI3ICAgICAgICAiPiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPiA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtbG5zOnhtcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIiB4bWxuczpzdFJlZj0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL3NUeXBlL1Jlc291cmNlUmVmIyIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ1M2IChNYWNpbnRvc2gpIiB4bXBNTTpJbnN0YW5jZUlEPSJ4bXAuaWlkOjRDRjJEQUJFN0E3NTExRTU4RkI0OThBMjE1NEFCRTgxIiB4bXBNTTpEb2N1bWVudElEPSJ4bXAuZGlkOjRDRjJEQUJGN0E3NTExRTU4RkI0OThBMjE1NEFCRTgxIj4gPHhtcE1NOkRlcml2ZWRGcm9tIHN0UmVmOmluc3RhbmNlSUQ9InhtcC5paWQ6QzcxQzhCQ0Q3QTc0MTFFNThGQjQ5OEEyMTU0QUJFODEiIHN0UmVmOmRvY3VtZW50SUQ9InhtcC5kaWQ6QzcxQzhCQ0U3QTc0MTFFNThGQjQ5OEEyMTU0QUJFODEiLz4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4g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'
                                                  });
                                                  doc.styles['td:nth-child(1)'] = {
                                                      width: '100%',
                                                      'max-width': '100%'
                                                  }
                                                  doc.pageMargins = [30, 30, 30, 30]; //left,top,right,bottom
                                                  doc.defaultStyle.fontSize = 8;
                                                  doc.styles.tableHeader.fontSize = 8;
                                                  doc.styles.title.fontSize = 8;
                                                  doc.content[0].text = doc.content[0].text.trim();  // Remove spaces around page title
                                                  // Create a footer
                                                  doc['footer'] = (function (page, pages) {
                                                      return {
                                                          columns: [
                                                              'Factoraje',
                                                              {
                                                                  // This is the right column
                                                                  alignment: 'right',
                                                                  text: ['page ', { text: page.toString() }, ' of ', { text: pages.toString() }]
                                                              }
                                                          ],
                                                          margin: [10, 0]
                                                      }
                                                  });
                                                  // Styling the table: create style object
                                                  var objLayout = {};
                                                  // Horizontal line thickness
                                                  objLayout['hLineWidth'] = function (i) { return .5; };
                                                  // Vertikal line thickness
                                                  objLayout['vLineWidth'] = function (i) { return .5; };
                                                  // Horizontal line color
                                                  objLayout['hLineColor'] = function (i) { return '#aaa'; };
                                                  // Vertical line color
                                                  objLayout['vLineColor'] = function (i) { return '#aaa'; };
                                                  // Left padding of the cell
                                                  objLayout['paddingLeft'] = function (i) { return 4; };
                                                  // Right padding of the cell
                                                  objLayout['paddingRight'] = function (i) { return 4; };
                                                  // Inject the object in the document
                                                  doc.content[1].layout = objLayout;
                                              }
                                          }
                                          ,'excel'
                  ],
                  paging: true, // permite la paginacion en la tabla .
                  lengthMenu: [10, 15, 30], // Cantidad de registros mostrados por pantalla 
                  searching: true, // genera cuadro de busqueda
                  ordering: false, // genera ordenamiento de columnas 
                  responsive: true, // realiza la tabla responsiva en moviles
                  destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
                  aoColumns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 
                 { data: "fecha", "width": "100px" },
                 { data: "action" },
                  ],
                  "columnDefs": [
                      { "className": "dt-center", "targets": [0] } // permite centrar botones de edicion 
                  ]
              });


    },
    openPopUp: function (pageUrl) {
        var $pageContent = $('<div>');

        $pageContent.load(pageUrl,
            function () {
                $pageContent.dialog({
                    width: bitacora != null ? "1400" : '500', // overcomes width:'auto' and maxWidth bug
                    height: bitacora != null ? "800" :  'auto',
                    title: bitacora != null ? "Consulta Bitacora" : (title == null ? "Nuevo Registro" : "Actualizar Registro"),
                    modal: true,
                    show: 'fade',
                    hide: 'fade',
                    fluid: true, //new option
                    resizable: false,
                    create: function (event, ui) { // setea elementos internos del popup 
                        
                        $('#fechaini').duDatepicker({ format: 'dd/mm/yyyy' })
                        $('#fechafinal').duDatepicker({ format: 'dd/mm/yyyy' })
                        data.inicializarTablaDetalle($("#username").val(), moment().format('DD/MM/YYYY'), moment().format('DD/MM/YYYY'))
                        $('#btnconsulta').click(function (e) {
                            data.inicializarTablaDetalle($("#username").val(), $("#fechaini").val(), $("#fechafinal").val())
                        });
                        $("#popupForm").find(':input').each(function () {

                            var value = $(this).val()
                            $(this).val(value.trim())

                        });


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
                            mensajemodal(data.Text, data.color, data.titulo);
                            if (table !== undefined) {
                                table.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar
                            }
                        } else {
                            mensajemodal(data.Text, data.color, data.titulo);
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

        // Este codigo permite desabilitar la funcion de KeyUp
        jQuery.validator.setDefaults({
            onkeyup: function () {
                var originalKeyUp = $.validator.defaults.onkeyup;
                var customKeyUp = function (element, event) {
                    if ($("#rfc")[0] === element) {
                        return false;
                    }
                    else {
                        return originalKeyUp.call(this, element, event);
                    }
                }
                return customKeyUp;
            }(),
            ignore: ""
        });

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

    //Esto nos permite Abrir modal dentro de modal . 
    $.fn.modal.Constructor.prototype.enforceFocus = function () { };

    $('#Reporte').click(function (e) {
      $.Loading(true)
      Cookies.remove('reporte');
      Cookies.set('reporte', 'FALSE');
      var time = setInterval(function () {
        if (Cookies.get('reporte') == 'OK') {
          $.Loading(false)
          clearInterval(time);
          Cookies.remove('reporte');
        }
      }, 1000)
    })


    data.inicializarTabla($("#identidad").val(), $("#Clave").val());
    data.validacionCampos();

    $("#tableContainer").on('click', 'a.popup',
        function (e) {
            e.preventDefault();
            title = $(this).attr("add") // set the title for popup
            bitacora = $(this).attr("bitacora")
            data.openPopUp($(this).attr('href'));

        });


    table.on('click', 'a.pass', function (e) {
        $('#dialog-confirm').text("Se generara un password temporal, ¿Desea continuar?")
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

    $(window).resize(function () {
        data.fluidDialog();
    });


});


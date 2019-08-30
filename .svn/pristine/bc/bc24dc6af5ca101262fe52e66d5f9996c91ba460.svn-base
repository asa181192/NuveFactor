//Inicializacion de variables

var dropdownComp = $("#serie");
var fecha = $("#fecha");
var tabla;
var nombre;
var data =
{
    inicializarTabla: function (tipo, fecha) {

        tabla = $('#table')// Evento se dispara cuando se ha cargado la taba con la informacion de ajax y se na inicializado 
              .DataTable({
                  ajax: {
                      "url": "../Facturacion/consultaComplemento/", // url del controlador a consultar 
                      "Type": "GET",
                      "data": function (d) { d.tipo = tipo, d.fecha = fecha }, // parametros a enviar al controlador 
                      "dataSrc": function (json) {
                          if (typeof (json.Mensaje) != 'undefined') {
                              $.Loading(false);
                              mensajemodal(json.Mensaje, 'warning', json.titulo);
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
                  responsive: true, // realiza la tabla responsiva en moviles
                  destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
                  aoColumns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 
              {
                  data: "fecha", orderable: false, "render": function (value) {
                      if (value === null) return "";

                      //Formato de fechas
                      var pattern = /Date\(([^)]+)\)/;
                      var results = pattern.exec(value);
                      var dt = new Date(parseFloat(results[1]))
                      var valMonth = (dt.getMonth().toString().length > 1 ? "" : "0")

                      mes = dt.getMonth() + 1
                      var adMonth = (mes.toString().length > 1 ? "" : "0")

                      var valDay = (dt.getDate().toString().length > 1 ? "" : "0")

                      return valDay + (dt.getDate()) + "/" + adMonth + (dt.getMonth() + 1) + "/" + dt.getFullYear();

                  }
              },
           { data: "id", orderable: true },
           { data: "serie", orderable: false },
           { data: "sat", orderable: false },
           { data: "contrato", orderable: false },
           { data: "nombre", orderable: false },
           { data: "email", orderable: false },
           { data: "importe", render: $.fn.dataTable.render.number(',', '.', '2', '$'), orderable: false },
           {
               data: function (data, type, dataToSet) {
                   return data.divisa == 1 ? "MXN" : "DLS"
               }
           },
           {
               data: function (data, type, dataToSet) {
                   return '<a class="archivo" href="../Facturacion/GetFileFactura?factura=BVM951002LX0_' + data.serie + '_' + data.sat + '&tipo=1" target="_blank" style="cursor:pointer"><img src="../Images/pdf.png"></button></a>';
                   //return '<a class="archivo" id=' + data + ' name="1"><img src="../Images/pdf.png"></button></a>';
               }, orderable: false, className: "dt-body-center", "width": "40px"
           },
           {
               data: function (data, type, dataToSet) {
                   return '<a class="archivo" href="../Facturacion/GetFileFactura?factura=BVM951002LX0_' + data.serie + '_' + data.sat + '&tipo=2" target="_blank" style="cursor:pointer"><img src="../Images/xml.png"></button></a>';
                   //return '<a class="archivo" id=' + data + ' name="2"><img src="../Images/xml.png"></button></a>';                   
               }, orderable: false, className: "dt-body-center", "width": "40px"
           },
           {
               data: function (data, type, dataToSet) {
                   return data.envio == true ? '<img src="../Images/checked.png">' : null                         
               }, orderable: false, className: "dt-body-center", "width": "40px"
               
           },
           {
             data: function (data, type, dataToSet) {
                   return '<a class="email" href="../Facturacion/EnviarFactura?factura=BVM951002LX0_' + data.serie + '_' + data.sat + '&identidad=' + data.identidad + '&id=' + data.id + '&numrec=' + data.numrec + '&tipo=' + $("#serie").val() + '" style="cursor:pointer"><img class="email" src="../Images/mail.png"></a>';
                  //return '<a class="archivo" id=' + data + ' name="2"><img src="../Images/xml.png"></button></a>';                   
                   }, orderable: false, className: "dt-body-center", "width": "40px"
           }
           ],
             "columnDefs": [
              { "className": "dt-center", "targets": [0, 1, 2, 3, 4, 7, 8] } // permite centrar botones de edicion 
                  ]
              });


    }, //Funcion que inicializa la tabla 
    openPopUp: function (pageUrl) {
        var $pageContent = $('<div>');

        $pageContent.load(pageUrl,
            function () {
                $pageContent.dialog({
                    width: '700', // overcomes width:'auto' and maxWidth bug
                    height: 'auto',
                    title: title == null ? "Nuevo Registro" : nombre + " (" + title + ")",
                    modal: true,
                    show: 'fade',
                    hide: 'fade',
                    fluid: true, //new option
                    resizable: false,
                    create: function (event, ui) { // setea elementos internos del popup 

                        var form = $("#popupForm")
                        form.removeData('validator'); //permite reiniciar el validado de informacion al despelgar una ventana modal
                        form.removeData('unobtrusiveValidation');
                        $.validator.unobtrusive.parse(form);

                        $("#popupForm").find(':input').each(function () {

                            var value = $(this).val()
                            $(this).val(value.trim())

                        });

                        $('#rfc').keyup(function () {
                            $(this).val($(this).val().toUpperCase());
                        });

                        $("#submit").click(function () {
                            if (!$("#popupForm").valid()) {
                                var message = ""
                                $("input.input-validation-error").each(function (index) {
                                    if (!$("[data-valmsg-for='" + $("input.input-validation-error")[index].getAttribute("id") + "']").text() == "") {
                                        message = message + "- " + $("[data-valmsg-for='" + $("input.input-validation-error")[index].getAttribute("id") + "']").text() + "<br/>"
                                    }
                                });
                                mensajemodal(message, "warning", "Revisar los siguientes campos !!");
                            }
                        })

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
                            if (tableProveedor !== undefined) {
                                tableProveedor.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar
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
    },// validacion de campos 
    obtenerFecha: function () {

        var d = new Date()
        var mes = d.getMonth()
        var anio = d.getFullYear()

        mes = parseFloat(mes) + 1

        mes = String(mes).length > 1 ? mes : '0' + mes
        return mes + '/' + anio


    },
    ajax: function (url, tipo, data) {
        $.ajax({
            type: tipo,
            url: url,
            data: data,
            beforeSend: function () {
                $.Loading(true);
            },
            success: function (data) {
                if (data.ok) {
                    mensajemodal(data.mensaje, "green", "Envio completo");
                } else {
                    mensajemodal(data.mensaje, "red", "Error al enviar");
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

    fecha.val(data.obtenerFecha())
    fecha.MonthPicker({ Button: false })
    //Esto nos permite Abrir modal dentro de modal . 
    $.fn.modal.Constructor.prototype.enforceFocus = function () { };

    data.inicializarTabla(dropdownComp.val(), '01/' + fecha.val());
    data.validacionCampos();
    dropdownComp.change(function (e) {
        data.inicializarTabla(dropdownComp.val(), '01/' + fecha.val());
    });

    $("#btnMasivo").click(function (e) {
        e.preventDefault();
        data.ajax($(this).attr("href"), "POST", { fecha: '01/' + fecha.val(), tipo: dropdownComp.val() })
    })

    tabla.on('click', 'a.email', function (e) {
        $('#dialog-confirm').text("Se enviara la factura por correo, ¿Desea continuar?")
        var url = $(this).attr("href")
        $('#dialog-confirm').dialog({
            resizable: false,
            height: "auto",
            title: "Envio de factura",
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

    fecha.focusout(function (e) {
        data.inicializarTabla(dropdownComp.val(), '01/' + fecha.val());
    });

});


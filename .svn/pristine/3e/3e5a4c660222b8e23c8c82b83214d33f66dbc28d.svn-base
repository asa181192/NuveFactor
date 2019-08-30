//Inicializacion de variables
var tablaFinanciero;
var btnConsulta = $('#btnConsultar');
var fecha = $('#fecInicio');
var idcta = $('#idctabanco');
var tipo = $('#tipo');
var entradas = ['DE', 'TC', 'CC']
var salidas = ['CA', 'DC', 'TR']
var registro = 1
//var ddlCuenta = $('#ddlCuentas').val()
var title;

$.ajaxSetup({
    // Disable caching of AJAX responses For IE !!!
    cache: false
});

var mov =
{
    inicializarTabla: function (fecIni, idcta) {



        tablaFinanciero = $('#tableMovimientos')
            .DataTable({

                ajax: {
                    "url": "../Tesoreria/consultaMovimientos", // url del controlador a consultar 
                    "contentType": "application/json",
                    "Type": "GET",
                    "data": function (d) { d.fecIni = fecIni, d.idcta = idcta }, // parametros a enviar al controlador 
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
           {
               data: "fecha", orderable: false,
               "render": function (value) {
                   if (value === null) return "";
                   //Formato de fechas
                   var pattern = /Date\(([^)]+)\)/;
                   var results = pattern.exec(value);
                   var dt = new Date(parseFloat(results[1]))

                   var valMonth = (dt.getMonth().toString().length < 2 ? "0" : "")
                   var valDay = (dt.getDate().toString().length < 2 ? "0" : "")

                   return valDay + (dt.getDate()) + "/" + (dt.getMonth().toString().length == 1 ? "0" : "") + (dt.getMonth() + 1) + "/" + dt.getFullYear();
               }
           }
           ,
           { data: "folio", orderable: false },
           { data: "tipo", orderable: false },
           { data: "beneficiario", orderable: false },
           { data: "concepto", orderable: false },
           { data: "entrada", render: $.fn.dataTable.render.number(',', '.', '2', '$'), orderable: false, className: 'dt-body-right', defaultContent: '$0.00' },
           { data: "salida", render: $.fn.dataTable.render.number(',', '.', '2', '$'), orderable: false, className: 'dt-body-right', defaultContent: '$0.00' },
           { data: "saldo", render: $.fn.dataTable.render.number(',', '.', '2', '$'), orderable: false, className: 'dt-body-right' },
           { data: "cancel", orderable: false },
           {
               data: "numrec", "width": "40px", "render": function (data) {
                   return '<a class="popup" href="../Tesoreria/ObtenerDetalleMovimiento?numrec=' + data + '" ><button name="detail" type="button" class="btn glyphicon glyphicon-pencil"></button></a>';

               }, orderable: false, className: 'dt-body-center'
           },
           {
               data: "numrec", "width": "50px", "render": function (data) {
                   return '<a class="cancel" href="../Tesoreria/cancelarMovimiento?numrec=' + data + '" ><button name="cancel" type="submit" class="btn glyphicon glyphicon-remove"></button></a>';

               }, orderable: false, className: 'dt-body-center'
           },
                ],
                "columnDefs": [
                    { "className": "dt-body-center", "targets": [10] } // permite centrar botones de edicion 

                ]

            });


    }, //Funcion que inicializa la tabla 
    openPopUp: function (pageUrl, tipo) {
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

                    mov.deshabilitarElementos()
                    mov.entradaSalidaVal(tipo)

                    $('#contrato').blur(function () {
                        mov.consultaContrato()
                    })

                    $pageContent.tooltip({
                        items: ".input-validation-error",
                        content: function () {
                            return $("[data-valmsg-for='" + $(this).attr('id') + "']").text();
                        }
                    });

                    mov.calculoDepositos()


                },
                close: function () {
                    $pageContent.dialog('destroy').remove();
                }
            });
        });

        $pageContent.on('submit',
           '#popupForm',
           function (e) {

               if ($('#capital').val() > 0 && $('#contrato').val() == 0) {
                   mensajemodal('Favor de capturar el contrato.', 'warning')
                   e.preventDefault()
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
                           $pageContent.dialog('close');


                       },
                       error: function () {
                           mensajemodal('Ocurrio un error al consultar la informacion favor de intentar de nuevo!!', 'warning');

                       },
                       complete: function () {
                           $.Loading(false);
                       },

                   });


                   mov.deshabilitarElementos()

                   e.preventDefault();
               }
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
    titleDefinition: function (registro, tipo) {


        titulo = (registro == 1 ? "Nuevo " : "Actualizar ")

        switch (tipo) {
            case 'TR':
                title = titulo + "Traspaso"
                break;
            case 'CA':
                title = titulo + "Cargo"
                break;
            case 'DE':
                title = titulo + "Depósito"
                break;
            case 'TR':
                title = titulo + "Traspaso"
                break;
            case 'CA':
                title = titulo + "Cargo"
                break;
            case 'DE':
                title = titulo + "Depósito"
                break;
            case 'CC':
                title = "Cargo Cancelado"
                break;
            case 'DC':
                title = "Depósito Cancelado"
                break;
            case 'TC':
                title = "Traspaso Cancelado"
                break;
        }
    },
    deshabilitarElementos: function () {


        $('#popupForm').find(':input').each(function () {

            idObject = $(this)

            if (idObject.attr('id') == 'numrec' && idObject.val() == 0) {
                return false;
            } else {
                if (idObject.val() == 'DC' || idObject.val() == 'TC' || idObject.val() == 'CC') {
                    $('#concepto').attr('readonly', true)

                } else if (idObject.attr('id') != 'concepto' && idObject.attr('id') != 'btnGuardar') {
                    $(this).attr('readonly', true)

                }
            }
        })
    },
    entradaSalidaVal: function (tipo) {

        if ($.inArray(tipo, entradas) != -1) {
            //$('#salida').hide()
            //$('#entrada').show()           

        } else {
            //$('#entrada').hide()
            //$('#salida').show()
        }

        if (tipo == 'CA' || tipo == 'DE') {
            //$('#cargos').hide()
        }

        if (tipo == 'DE') {
            $('.depositos').show()
        }

    },
    calculoDepositos: function () {

        $('#entrada').focusout(function () {
            if ($('#tipo').val() == "DE") {
                $('#generales').val($('#entrada').val())
            }
        })

        $('#generales').focusout(function () {

            importe = $('#entrada').val()
            generales = $('#generales').val()
            capital = $('#capital')

            if (parseFloat(importe) > parseFloat(generales)) {
                capital.val(importe - generales)
            } else {
                mensajemodal("C. generales no puede ser mayor a importe.", 'warning');
                $('#generales').val(importe)
            }
        })
    },
    consultaContrato: function () {

        var contrato = { "contrato": $('#contrato').val() };

        $.ajax({
            type: 'GET',
            datatype: "JSON",
            contentType: "application/json; charset=utf-8",
            url: '../Tesoreria/consultaContrato',
            data: contrato,
            success: function (response) {

                if (response.nombre) {
                    $('#nombre').val(response.nombre)
                } else {

                    mensajemodal(response.Mensaje, 'warning')
                    $('#contrato').val(0)
                }
            },
            error: function () {

                mensajemodal('Ocurrio un error al consultar el contrato, intente nuevamente.', 'warning')

            }


        })

    },
    returnUrl: function (element) {

        var folio = 0;
        var tipo = '';
        var id = element.attr('id')
        var result = element.attr('href')

        if (id == 'btnTraspaso' || id == 'btnCargos' || id == 'btnDepositos') {
            registro = 1
            switch (id) {
                case 'btnTraspaso':
                    tipo = 'TR'
                    break;
                case 'btnCargos':
                    tipo = 'CA'
                    break;
                case 'btnDepositos':
                    tipo = 'DE'
                    break;
            }

        } else {
            registro = 2
            folio = element.parents("tr").find("td")[1].innerHTML;
            tipo = element.parents("tr").find("td")[2].innerHTML;
        }

        mov.titleDefinition(registro, tipo)
        result = result + '&folio=' + folio + '&tipo=' + tipo + '&idcta=' + idcta.val()

        return result
    }

}

$(document).ready(function (e) {

    //Esto nos permite Abrir modal dentro de modal . 
    $.fn.modal.Constructor.prototype.enforceFocus = function () { };

    mov.validacionCampos();

    fecha.datepicker({ dateFormat: 'dd/mm/yy', language: 'es', locale: 'es' }).datepicker("setDate", "0")
    fecha.keydown(function () { return false })

    btnConsulta.click(function () {
        mov.inicializarTabla(fecha.val(), idcta.val())
    })

    mov.inicializarTabla(fecha.val(), idcta.val())

    $("#tableContainer").on('click', 'a.popup', function (e) {
        e.preventDefault();

        var folio = 0;
        var tipo = '';
        var id = $(this).attr('id')
        var result = $(this).attr('href')

        if (id == 'btnTraspaso' || id == 'btnCargos' || id == 'btnDepositos') {
            registro = 1
            switch (id) {
                case 'btnTraspaso':
                    tipo = 'TR'
                    break;
                case 'btnCargos':
                    tipo = 'CA'
                    break;
                case 'btnDepositos':
                    tipo = 'DE'
                    break;
            }

        } else {
            registro = 2
            folio = $(this).parents("tr").find("td")[1].innerHTML;
            tipo = $(this).parents("tr").find("td")[2].innerHTML;
        }

        result = result + '&folio=' + folio + '&tipo=' + tipo + '&idcta=' + idcta.val()

        mov.titleDefinition(registro, tipo)

        mov.openPopUp(result, tipo);
    });

    $("#tableContainer").on('click', 'a.cancel', function (e) {

        tipo = $(this).parents("tr").find("td")[2].innerHTML;
        status = $(this).parents("tr").find("td")[8].innerHTML;
        Element = $(this)

        e.preventDefault()
        if (tipo.substring(1, 2) == 'C' || status == 'Cancelado') {
            mensajemodal('El movimiento ya está cancelado.', 'warning')
        } else {

            $(function () {
                $("#dialog-confirm").dialog({
                    resizable: false,
                    height: "auto",
                    width: 400,
                    modal: true,
                    buttons: {
                        "Cancelar Movimiento": function () {

                            $.ajax({
                                url: mov.returnUrl(Element),
                                type: 'POST',
                                datatype: 'JSON',
                                contentType: 'application/json charset=utf-8',
                                success: function (json) {

                                    $('#dialog-confirm').dialog("close");

                                    mensajemodal(json.mensaje, 'success')
                                    mov.inicializarTabla(fecha.val(), idcta.val())

                                }
                            })

                        },
                        Cancel: function () {

                            $(this).dialog("close");

                        }
                    }
                })
            })
        }
    })
});
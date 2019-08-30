﻿//Inicializacion de variables
var tablaFinanciero;
var btnConsulta = $('#btnConsultar');
var fecha = $('#fecInicio');
var idcta = $('#idctabanco');
var tipo = $('#tipo');
var entradas = ['DE', 'TC', 'CC']
var salidas = ['CA', 'DC', 'TR']
var registro = 1
var title;
var a = /,/g //Regex para quitar comas de montos de moneda

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
                "dom": 'lfrtBip',
                "lengthMenu": [25, 50, 75], // Cantidad de registros mostrados por pantalla                 
                buttons: [
                    {
                        extend: 'excelHtml5',
                        exportOptions: {
                            columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                        }
                    },
                    {
                        text: 'PDF', // Nuevo Botón personalizado en PDF 
                        title: 'Movimientos ' + $('select[name="idctabanco"] option:selected').text() + ' ' + $('#fecInicio').val(),
                        extend: 'pdfHtml5', footer: true,
                        orientation: 'landscape',
                        header: true,
                        exportOptions: {
                            columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                        },
                        customize: function (doc) {
                            doc.content.splice(1, 0, {
                                margin: [0, -28, 0, 5],
                                alignment: 'left',
                                width: 80,
                                height: 28,
                                image: 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAPAAAABVCAYAAAB3hGnPAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAAZdEVYdFNvZnR3YXJlAEFkb2JlIEltYWdlUmVhZHlxyWU8AAADJGlUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4gPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS4zLWMwMTEgNjYuMTQ1NjYxLCAyMDEyLzAyLzA2LTE0OjU2OjI3ICAgICAgICAiPiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPiA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtbG5zOnhtcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIiB4bWxuczpzdFJlZj0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL3NUeXBlL1Jlc291cmNlUmVmIyIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ1M2IChNYWNpbnRvc2gpIiB4bXBNTTpJbnN0YW5jZUlEPSJ4bXAuaWlkOjRDRjJEQUJFN0E3NTExRTU4RkI0OThBMjE1NEFCRTgxIiB4bXBNTTpEb2N1bWVudElEPSJ4bXAuZGlkOjRDRjJEQUJGN0E3NTExRTU4RkI0OThBMjE1NEFCRTgxIj4gPHhtcE1NOkRlcml2ZWRGcm9tIHN0UmVmOmluc3RhbmNlSUQ9InhtcC5paWQ6QzcxQzhCQ0Q3QTc0MTFFNThGQjQ5OEEyMTU0QUJFODEiIHN0UmVmOmRvY3VtZW50SUQ9InhtcC5kaWQ6QzcxQzhCQ0U3QTc0MTFFNThGQjQ5OEEyMTU0QUJFODEiLz4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4g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'
                            });
                            doc.pageMargins = [10, 10, 10, 20]; //left,top,right,bottom
                            doc.defaultStyle.fontSize = 8;
                            doc.styles.tableHeader.fontSize = 10;
                            doc.styles.title.fontSize = 10;
                            doc.content[0].text = doc.content[0].text.trim();  // Remove spaces around page title

                            // Create a footer
                            doc['footer'] = (function (page, pages) {
                                return {
                                    columns: [
                                        'Factoraje-Movimientos',
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
                ],
                paging: true, // permite la paginacion en la tabla .                
                searching: true, // genera cuadro de busqueda
                ordering: true, // genera ordenamiento de columnas 
                order: [[0, 'desc']], // ordena la primer columna
                responsive: true, // realiza la tabla responsiva en moviles
                destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
                columns: [ // permite saber que columnas se usaran del json retornado desde el servidor .                     
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
           { data: "folio", orderable: false },
           { data: "tipo", orderable: false },
           { data: "beneficiario", orderable: false },
           { data: "concepto", orderable: false },
           { data: "entrada", render: $.fn.dataTable.render.number(',', '.', '2', '$'), orderable: false, defaultContent: '$0.00' },
           { data: "salida", render: $.fn.dataTable.render.number(',', '.', '2', '$'), orderable: false, defaultContent: '$0.00' },
           { data: "saldo", render: $.fn.dataTable.render.number(',', '.', '2', '$'), orderable: false },
           { data: "cancel", orderable: false },
           {
               data: "numrec", "width": "40px", "render": function (data) {
                   return '<a class="popup" href="../Tesoreria/ObtenerDetalleMovimiento?numrec=' + data + '" ><button name="detail" type="button" class="btn glyphicon glyphicon-pencil"></button></a>';
               }, orderable: false, className: 'dt-body-center'
           },
           {
               data: "numrec", "width": "40px", "render": function (data) {
                   return '<a class="cancel" href="../Tesoreria/cancelarMovimiento?numrec=' + data + '" ><button name="cancel" type="submit" class="btn glyphicon glyphicon-remove"></button></a>';
               }, orderable: false, className: 'dt-body-center'
           },
                ],
                "columnDefs": [
                    { "width": "auto", "className": "dt-head-center dt-body-center", "targets": [0, 1, 2, 5, 6, 7, 8, 9, 10] },
                    { "width": "auto", "className": "dt-head-center dt-body-left", "targets": [3, 4] }
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

                    $('#entrada').mask('000,000,000,000,000.00', { reverse: true })
                    $('#salida').mask('000,000,000,000,000.00', { reverse: true })
                    $('#generales').mask('000,000,000,000,000.00', { reverse: true })

                    $('#capital').on('change', function () {

                        mov.campoContrato()

                    })

                    $('#docto').keyup(function (e) {
                        this.value = (this.value + '').replace(/[^0-9]/g, '');
                    })

                },
                close: function () {
                    $pageContent.dialog('destroy').remove();
                }
            });
        });

        $pageContent.on('submit', '#popupForm',
           function (e) {

               console.log(e)
               e.preventDefault()

               cap = $('#capital').val().replace(a, '')
               if (cap > 0 && $('#contrato').val() == 0) {
                   mensajemodal('Favor de capturar el contrato.', 'warning', 'Advertencia')
                   $('#contrato').focus()
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
                               mensajemodal(data.Text, 'success', 'Movimientos');

                               tablaFinanciero.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar
                               mov.saldosCuenta()

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

                   mov.deshabilitarElementos()

                   e.preventDefault();
               }
               mov.saldosCuenta()



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

        if (tipo == 'DE') {
            $('.depositos').show()
        }

    },
    calculoDepositos: function () {

        $('#entrada').focusout(function () {
            if ($('#tipo').val() == "DE") {

                $('#generales').val($('#entrada').val())
                $('#capital').val(0)

            }
        })

        $('#generales').focusout(function () {

            importe = $('#entrada').val()
            generales = $('#generales').val()
            capital = $('#capital')

            importe = importe.replace(a, '')
            generales = generales.replace(a, '')

            if (parseFloat(importe) >= parseFloat(generales)) {

                cap = importe - generales

                $('#capital').val($.fn.dataTable.render.number(',', '.', 2).display(cap))

                if (parseFloat(capital.val()) < 1) {
                    $('#contrato').val(0)
                    $('#nombre').val('')
                }

            } else {
                mensajemodal("C. generales no puede ser mayor a importe.", 'warning');
                $('#generales').val(importe)
            }
        })

        $('#generales').mask('000,000,000,000,000.00', { reverse: true })



    },
    consultaContrato: function () {

        var contrato = { "contrato": $('#contrato').val() };

        if ($('#contrato').val() > 0) {
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
        }

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
    },
    saldosCuenta: function () {

        data = { 'idctabanco': $('#idctabanco').val() }

        $.ajax({
            url: '../Tesoreria/obtenerSaldosCuenta',
            contentType: 'application/json',
            type: 'GET',
            data: data,
            success: function (response) {

                var saldo = $.fn.dataTable.render.number(',', '.', 2, '$').display(response.saldo)
                var saldoIni = $.fn.dataTable.render.number(',', '.', 2, '$').display(response.saldoInicial)

                $('#saldoInicial').text(saldoIni)
                $('#saldoActual').text(saldo)
            }, error: function () {
                mensajemodal('Ocurrió un error al consultar el saldo de la cuenta.(AJAX)', 'danger')
            }
        })
    },
    campoContrato: function () {

        if (parseFloat(capital) > 0) {

            $('#contrato').attr('readonly', false)
        } else {

            $('#contrato').attr('readonly', true)
        }
    },

}

$(document).ready(function (e) {

    mov.saldosCuenta()
    //Esto nos permite Abrir modal dentro de modal . 
    $.fn.modal.Constructor.prototype.enforceFocus = function () { };

    mov.validacionCampos();

    fecha.datepicker({ dateFormat: 'dd/mm/yy', language: 'es', locale: 'es' }).datepicker("setDate", "0")

    fecha.keydown(function () { return false })

    btnConsulta.click(function () {
        mov.inicializarTabla(fecha.val(), idcta.val())
        mov.saldosCuenta()
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
                                contentType: 'application/json',
                                success: function (response) {

                                    mensajemodal(response.Text, 'success', 'Cancelación de Movimientos')
                                    mov.inicializarTabla(fecha.val(), idcta.val())
                                    mov.saldosCuenta()

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
        }
    })


});
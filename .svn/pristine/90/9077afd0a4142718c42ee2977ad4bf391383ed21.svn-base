var a = /,/g //Regex para quitar comas de montos de moneda

$.ajaxSetup({
    cache: false
})

polizas = {

    inicializarTabla: function () {
        tablaPolizas = $('#tableAseguradoras').DataTable({

            ajax: {
                "url": "../Aseguradora/ConsultaPolizasGlobal",
                "contentType": "application/json",
                "Type": "GET",
                "dataSrc": function (json) {
                    if (typeof (json.Mensaje) != 'undefined') {
                        return {};
                    } else {
                        return json.Results;
                    }
                }
            },
            initComplete: function (settings, json) {
                $.Loading(false)
            },
            "dom": "lfrtip",
            "lengthMenu": [10],
            paging: true,
            searching: true,
            ordering: false,
            order: [[0, 'desc']],
            responsive: true,
            destroy: true,
            columns: [
                { data: 'nombre', orderable: true },
                {
                    data: "idpoliza", "render": function (data) {
                        return '<a class="popup edit" href="../Aseguradora/ConsultaPoliza?idpoliza=' + data + '&tipo=1" id="' + data + '"><img src="../Images/Aseguradora/consulta.png"></a>';
                    }
                },
                {
                    data: "idpoliza", "render": function (data) {
                        return '<a class="popup edit" href="../Aseguradora/DetalleAseguradora?idaseguradora=' + data + '&tipo=1" id="' + data + '"><img src="../Images/Aseguradora/informe.png"></a>';
                    }
                },
                {
                    data: "idpoliza", "render": function (data) {
                        return '<a class="popup edit" href="../Aseguradora/DetalleAseguradora?idaseguradora=' + data + '&tipo=1" id="' + data + '"><img src="../Images/Aseguradora/poliza.png"></a>';
                    }
                },
                {
                    data: "idpoliza", "render": function (data) {
                        return '<a class="popup edit" href="../Aseguradora/DetalleAseguradora?idaseguradora=' + data + '&tipo=1" id="' + data + '"><img src="../Images/Aseguradora/siniestro.png"></a>';
                    }
                },
                {
                    data: "idpoliza", "render": function (data) {
                        return '<a class="popup edit" href="../Aseguradora/DetalleAseguradora?idaseguradora=' + data + '&tipo=1" id="' + data + '"><img src="../Images/Aseguradora/seguro.png"></a>';
                    }
                }
            ],
            columnsDefs: [
                { "width": "200px", 'class': 'dt-head-center dt-body-center', 'target': [1] },
                { "width": "200px", 'class': 'dt-head-center dt-body-center', 'target': [2] },
                { "width": "200px", 'class': 'dt-head-center dt-body-center', 'target': [3] }
            ]
        })
    },//termina datatable
    openPopUp: function (pageUrl, titulo) {
        var $pageContent = $('<div>');

        $pageContent.load(pageUrl, function () {

            $pageContent.dialog({
                width: '800px',
                height: 'auto',
                modal: true,
                show: 'fade',
                title: titulo,
                fluid: true,
                resizable: false,
                create: function (event, ui) {

                    $('#fvigencia1').datepicker({ dateFormat: 'dd/mm/yy' })
                    $('#fvigencia2').datepicker({ dateFormat: 'dd/mm/yy' })
                    $('#femision').datepicker({ dateFormat: 'dd/mm/yy' })
                    $('#gefprimera').datepicker({ dateFormat: 'dd/mm/yy' })
                    $('#primaafprimera').datepicker({ dateFormat: 'dd/mm/yy' })

                    var form = $('#popupForm').closest('form')
                    form.removeData('validator')
                    form.removeData('validator')
                    $.validator.unobtrusive.parse(form)

                    $(this).width(300)

                    $('.inah').css('pointer-events', 'none')

                    $('.change').change(function () {
                        polizas.calculo()
                    })

                    $('.calc').blur(function () {
                        polizas.calculo()
                    })

                    $('.mon').click(function () {
                        $(this).val($(this).val().replace(a, ''))
                        $(this).select()
                    })

                    $('.mon').focusout(function () {
                        $(this).val($.fn.dataTable.render.number(',', '.', 2).display($(this).val()))
                    })

                    $('.mon').keypress(function (e) {

                        var c = e.keyCode || e.which,
                            key = String.fromCharCode(c),
                            chars = "0123456789."

                        return chars.search(key) !== -1


                    })

                    $('.date').keypress(function () {
                        return false;
                    })

                    $('#geasegurados').click(function () {
                        $(this).select()

                    })

                    polizas.formatoMoneda()

                    $pageContent.tooltip({
                        items: '.input-validation-error',
                        content: function () {
                            return $('[data-valmsg-for="' + $(this).attr('id') + '"]').text()
                        }
                    })

                },
                close: function () {
                    $pageContent.dialog('destroy').remove()
                }

            })

            $pageContent.on('submit',
           '#popupForm',
           function (e) {
               e.preventDefault();
               polizas.quitarFormato()
               polizas.validacionCampos()

               console.log($('#geasegurados').val())

               var url = $('#popupForm')[0].action;

               $.ajax({
                   type: "POST",
                   url: url,
                   data: $('#popupForm').serialize(),
                   beforeSend: function () {
                       $.Loading(true);
                   },
                   success: function (response) {

                       if (response.proceso == "1") {
                           mensajemodal(response.mensaje, 'success', 'Poliza Global')
                           tablaPolizas.ajax.reload(null, false);

                       } else {
                           mensajemodal(response.mensaje, 'success', 'Poliza Global')

                       }

                       $pageContent.dialog('close');

                   },
                   error: function () {
                       mensajemodal('Ocurrio un error al consultar la informacion favor de intentar de nuevo!!', 'warning', 'Error Ajax 404');

                   },
                   complete: function () {
                       $.Loading(false);
                   }
               });

               e.preventDefault();

           })


        })

    },
    validacionCampos: function () {



        jQuery.validator.addMethod('mayorcero', function (value, element, params) {
            if (parseFloat($(".zero").val().replace(a, '')) > 0.0) {
                return true
            }
            else {
                console.log('error')
                return false
            }
        }, '');

        jQuery.validator.unobtrusive.adapters.add('mayorcero', function (options) {
            options.rules['mayorcero'] = {};
            options.messages['mayorcero'] = options.message;
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
    },
    calculo: function () {

        polizas.quitarFormato()

        var iva = $('#piva').val() / 100
        var subtot = $('#primasubtotal').val()
        var primaiva = subtot * iva
        var primatot = Number(primaiva) + Number(subtot)
        var descto = $('#primapdescuento').val() / 100
        var primapagar = 0
        var vigencia = $('#mvigencia option:selected').val()
        var primaperiodo = $('#primaperiodos option:selected').val()
        var primaasub = 0
        var primaatot = 0
        var primaaiva = 0
        var gecosto = $('#gecosto').val()
        var geaseg = $('#geasegurados').val()
        var gesubtotal = Number(gecosto) * Number(geaseg)
        var getotal = Number(gesubtotal) * (1 + Number(iva))
        var geiva = Number(getotal) - Number(gesubtotal)
        var geatotal = 0
        var geperiodos = $('#geperiodos option:selected').val()

        primapagar = Number(subtot) * (1 - Number(descto))

        if (Number(vigencia) > 0 && Number(primaperiodo) > 0 && (Number(vigencia) / Number(primaperiodo) >= 1)) {
            primaasub = (Number(primapagar) / Number(vigencia)) * Number(primaperiodo)
            primaatot = (Number(primaasub) * (1 + Number(iva)))
            primaaiva = Number(primaatot) - Number(primaasub)
        }

        if (Number(vigencia) > 0 && Number(geperiodos) > 0 && (Number(vigencia) / Number(geperiodos)) >= 1) {
            geatotal = (Number(getotal) / Number(vigencia) * Number(geperiodos))
        }

        //Prima a pagar
        $('#primaiva').val(primaiva)
        $('#primatotal').val(primatot)
        $('#primapagar').val(primapagar)
        $('#primaminima').val(primapagar)

        //Anticipo de prima a pagar
        $('#primaasubtotal').val(primaasub)
        $('#primaaiva').val(primaaiva)
        $('#primaatotal').val(primaatot)

        //Gastos de estudio a pagar
        $('#gesubtotal').val(gesubtotal)
        $('#geiva').val(geiva)
        $('#getotal').val(getotal)
        $('#geatotal').val(geatotal)

        polizas.formatoMoneda()

    },
    formatoMoneda: function () {
        $('.mon').each(function () {
            $(this).val($.fn.dataTable.render.number(',', '.', 2).display($(this).val()))

        })
    },
    quitarFormato: function () {
        $('.mon').each(function () {
            $(this).val($(this).val().replace(a, ''))

        })
    }
}

$(document).ready(function () {

    polizas.validacionCampos()

    polizas.inicializarTabla()

    //Esto nos permite Abrir modal dentro de modal . 
    $.fn.modal.Constructor.prototype.enforceFocus = function () { };

    $('#tableContainer').on('click', 'a.edit', function (e) {
        e.preventDefault()
        url = $(this).attr('href')
        polizas.openPopUp(url, 'Consultar póliza global')
    })


    $('#btnNuevo').click(function (e) {
        e.preventDefault()
        url = $(this).attr('href')
        polizas.openPopUp(url, 'Nueva póliza global')

    })



})
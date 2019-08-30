//Inicializacion de variables

var title;
var tablaGar
var nombre;
var data =
{
    inicializarTabla: function (cesion, contrato) {
        var tabla;
        tabla = $('#table').DataTable({
            ajax: {
                "url": "../Catalogos/ObtenerDoctos/", // url del controlador a consultar 
                "Type": "GET",
                "data": function (d) { d.cesion = cesion, d.Contrato = contrato }, // parametros a enviar al controlador 
                "dataSrc": function (json) {
                    if (typeof (json.Mensaje) != 'undefined') {
                        mensajemodal(json.Mensaje, 'warning', json.titulo);
                        return {};
                    } else {
                        return json.Results;
                    }
                }
            },
            initComplete: function (settings, json) {
                $.Loading(false);
                if ($("#producto").val() != 1) {
                    var column = tabla.column(3);
                    column.visible(!column.visible());
                }
            },
            paging: true, // permite la paginacion en la tabla . 
            lengthMenu: [25],
            "dom": 'frtip',
            "bInfo": false,
            ordering: false, // genera ordenamiento de columnas 
            responsive: true, // realiza la tabla responsiva en moviles
            destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
            aoColumns:  [ // permite saber que columnas se usaran del json retornado desde el servidor . 

                                {
                                    data: "iddocto",
                                },
                               {
                                   data: "docto"
                               },
                               {
                                   data: "fec_vence"
                               },
                               {
                                   data: "nombreDeudor"
                               },
                               {
                                   data: "monto", render: $.fn.dataTable.render.number(',', '.', 2, '')
                               },
                               {
                                   data: "importe", render: $.fn.dataTable.render.number(',', '.', 2, '')
                               },
                               {
                                   data: "descto", render: $.fn.dataTable.render.number(',', '.', 2, '')
                               },
                               {
                                   data: "interes", render: $.fn.dataTable.render.number(',', '.', 2, '')
                               },
                               {
                                   data: "hono", render: $.fn.dataTable.render.number(',', '.', 2, '')
                               },
                               {
                                   data: "iva", render: $.fn.dataTable.render.number(',', '.', 2, '')
                               }
                    ]
            ,"columnDefs": [
                {
                    "className": "dt-center", "targets": [0, 1, 2, 4, 5, 6, 7, 8,9]
                }
            ]
        });


    }, //Funcion que inicializa la tabla 
    inicializarTabla2: function (cesion, contrato) {
           tablaGar = $('#table2').DataTable({
            ajax: {
                "url": "../Catalogos/ObtenerGarantias/", // url del controlador a consultar 
                "Type": "GET",
                "data": function (d) { d.cesion = cesion, d.Contrato = contrato }, // parametros a enviar al controlador 
                "dataSrc": function (json) {
                    if (typeof (json.Mensaje) != 'undefined') {
                        mensajemodal(json.Mensaje, 'warning', json.titulo);
                        return {};
                    } else {
                        return json.Results;
                    }
                }
            },
            initComplete: function (settings, json) {
                $.Loading(false);
                if ($("#producto").val() != 1) {
                    var column = tabla.column(3);
                    column.visible(!column.visible());
                }
            },
            paging: false, // permite la paginacion en la tabla .
            "bInfo": false,
            ordering: false, // genera ordenamiento de columnas 
            responsive: true, // realiza la tabla responsiva en moviles
            destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
            aoColumns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 

                                {
                                    data: "nombreTipo", "width": "500px"
                                },
                               {
                                   data: "valor", render: $.fn.dataTable.render.number(',', '.', 2, '') , "width": "200px"
                               },
                               {
                                   data: "porcentaje", render: function (data, type, row) {
                                       return data+'%'
                                   }
                                   , "width": "200px"
                               },
                               {
                                   data: "costo", render: $.fn.dataTable.render.number(',','.', 2, '' ), "width": "200px"
                               },
                               {
                                   data: "cobrado", render: $.fn.dataTable.render.number(',', '.', 2, ''), "width": "200px"
                               },
                               {
                                   data: function (data, type, dataToSet) {
                                       return '<a class="popup" href="../Catalogos/GuardarGarantia?garantiaid=' + data.garantiaid + '&contrato=' + $("#Cesion_contrato").val() + '&cesion=' + $("#Cesion_cesion").val() + '" add=' + data.garantiaid + '><button type="button" class="btn glyphicon glyphicon-search"></button></a>';
                                   }, "width": "40px"
                               }
            ]
            , "columnDefs": [
                {
                    "className": "dt-center", "targets": [1, 2, 3, 4 , 5]
                }
            ]
        });


    },
    openPopUp: function (pageUrl) {
        var $pageContent = $('<div>');

        $pageContent.load(pageUrl,
            function () {
                $pageContent.dialog({
                    width: '400px', // overcomes width:'auto' and maxWidth bug
                    height: 'auto',
                    title: title == null ? "Nuevo Registro" : "Actualizar Registro",
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
                                              
                        $('#costo').mask('0,000.00', { reverse: true });
                        $('#valor').mask('000,000,000,000.00', { reverse: true });
                        $('#porcentaje').mask('000.00', { reverse: true });
                        $('#cobrado').mask('000,000,000,000.00', { reverse: true });
                        $('#ivacobrado').mask('000,000,000,000.00', { reverse: true });
                        //$("#submit").click(function () {
                        //    if (!$("#popupForm").valid()) {
                        //        var message = ""
                        //        $("input.input-validation-error").each(function (index) {
                        //            if (!$("[data-valmsg-for='" + $("input.input-validation-error")[index].getAttribute("id") + "']").text() == "") {
                        //                message = message + "- " + $("[data-valmsg-for='" + $("input.input-validation-error")[index].getAttribute("id") + "']").text() + "<br/>"
                        //            }
                        //        });
                        //        mensajemodal(message, "warning", "Revisar los siguientes campos !!");
                        //    }
                        //})

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
                            if (tablaGar !== undefined) {
                                tablaGar.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar
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
    eventos: function () {
        tabla.on('click', 'a.cancelar', function (e) {
            $('#dialog-confirm').text("Se dara de baja el contrato : " + $(this).attr("contrato"))
            var url = $(this).attr("href")
            $('#dialog-confirm').dialog({
                resizable: true,
                height: "auto",
                title: "Baja de contrato",
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
        tabla.on('click', 'tr', function () {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
                btnAnexo.addClass("disabled")
                btnCesion.addClass("disabled")
            }
            else {
                tabla.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
                btnAnexo.removeClass('disabled');
                btnCesion.removeClass('disabled');
                btnAnexo.attr("href", btnAnexoLiga.replace("_contrato", tabla.row('.selected').data()["Contratos"].contrato).replace("_producto", tabla.row('.selected').data()["Producto"].id))
                btnCesion.attr("href", btnCesionLiga.replace("_contrato", tabla.row('.selected').data()["Contratos"].contrato).replace("_producto", tabla.row('.selected').data()["Producto"].id))
            }
        });
    },
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
                    if (tabla !== undefined) {
                        tabla.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar
                    }
                } else {
                    mensajemodal(data.Text, data.color, data.titulo);
                }
            },
            error: function () {
                mensajemodal('Ocurrio un error al consultar la informacion favor de intentar de nuevo!!', 'warning');
            },
            complete: function () {
                $.Loading(false);
            }

        });
    },
    InicializarControl : function(){
        $('#Cesion_importe').mask('000,000,000,000.00', { reverse: true });
        $('#Cesion_impanticipado').mask('000,000,000,000.00', { reverse: true });
        $('#Cesion_honorario').mask('000,000,000,000.00', { reverse: true });
        $('#Cesion_totalpagar').mask('000,000,000,000.00', { reverse: true });
        $('#Cesion.garantnafin').mask('000,000,000,000.00', { reverse: true });
        $('#Cesion_ivaganafin').mask('000,000,000,000.00', { reverse: true });
        $('#Cesion_interes').mask('000,000,000,000.00', { reverse: true });
    }
}

$(document).ready(function (e) {
    //Esto nos permite Abrir modal dentro de modal . 
    $.fn.modal.Constructor.prototype.enforceFocus = function () { };

    data.InicializarControl()
    data.inicializarTabla($("#Cesion_cesion").val(), $("#Cesion_contrato").val())

    if ($("#producto").val() == 1) {
        data.inicializarTabla2($("#Cesion_cesion").val(), $("#Cesion_contrato").val())
    }

    $("#tableContainer1").on('click', 'a.popup',
      function (e) {
          e.preventDefault();
          title = $(this).attr("add") // set the title for popup
          nombre = $(this).attr("nombre")
          data.openPopUp($(this).attr('href'));

      });
   
    //data.eventos();
});
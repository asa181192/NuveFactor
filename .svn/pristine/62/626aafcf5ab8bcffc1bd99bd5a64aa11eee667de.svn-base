//Inicializacion de variables
var tabla;
var gliquida = $(".gliquida").attr('href')
var cancela = $(".cancela").attr('href')
var data =
{
    inicializarTabla: function () {

      
        tabla = $('#table')
            .on('preXhr.dt', function (e, settings, data) {
                 $(this).dataTable().api().clear();
                 settings.iDraw = 0;   //Setearlo a 0 ,  lo que significa "initial draw"lo que mostrata el loading para la tabla de nuevo .
                 $(this).dataTable().api().draw();
                 $("tfoot tr td").remove();
             })
            .DataTable({
                ajax: {
                    "url": "../Catalogos/obtenerListaRiesgo/", // url del controlador a consultar 
                    "Type": "GET",
                    "data": function (d) { d.clienteId = $('#propCliente_cliente').val() }, // parametros a enviar al controlador 
                    "dataSrc": function (json) {
                        if (typeof (json.Mensaje) != 'undefined') {
                            mensajemodal(json.Mensaje, 'warning');
                            $.Loading(false); 
                            return {}
                        } else {
                            $("#propCliente_rgpo").prop('checked', json.cliente.rgpo)
                            $("#propCliente_voboreg").prop('checked', json.cliente.voboreg)
                            $("#propCliente_vobo").prop('checked', json.cliente.vobo)
                            $("#propCliente_riesgogpo").val((json.cliente.riesgogpo).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,'))
                            $("#propCliente_riesgo").val((json.cliente.riesgo).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,'))
                            $(".cambio").text(json.cliente.Paridad)
                            data.inicializacionControles();
                            mensajemodal("Proceso trerminado", 'success');
                            return json.Results;
                        }
                    }
                },
                rowGroup: {
                    startRender: null,
                    endRender: function (rows, group) {
                        var lmontoTot = 0
                        var lutilizadoTot = 0
                        var ldispinibleTot = 0
                        var ladeudosTot = 0
                        var lvencidaTot = 0
                        for (var i = 0 ; i < rows.data().count() ; i++) {
                            lmontoTot = lmontoTot + rows.data()[i].lmonto
                            lutilizadoTot = lutilizadoTot + rows.data()[i].lutilizado
                            ldispinibleTot = ldispinibleTot + rows.data()[i].ldisponibl
                            ladeudosTot = ladeudosTot + rows.data()[i].adeudo
                            lvencidaTot = lvencidaTot + rows.data()[i].vencida
                        }

                       
                        lmontoTot = $.fn.dataTable.render.number(',', '.', 2, '$').display(lmontoTot);
                        lutilizadoTot = $.fn.dataTable.render.number(',', '.', 2, '$').display(lutilizadoTot);
                        ldispinibleTot = $.fn.dataTable.render.number(',', '.', 2, '$').display(ldispinibleTot);
                        ladeudosTot = $.fn.dataTable.render.number(',', '.', 2, '$').display(ladeudosTot);
                        lvencidaTot = $.fn.dataTable.render.number(',', '.', 2, '$').display(lvencidaTot);

                        //Se deben contar las posiciones empiezan desde 0 
                        return $('<tr/>')
                                .append('<td  colspan="8"> Montos en Moneda Nacional </td>')
                                .append('<td>' + lmontoTot + '</td>')
                                .append('<td>' + lutilizadoTot + '</td>')
                                .append('<td>' + ldispinibleTot + '</td>')                               
                                .append('<td/>').append('<td/>').append('<td/>').append('<td/>')
                                .append('<td>' + ladeudosTot + '</td>')
                                .append('<td>' + lvencidaTot + '</td>')
                                .append('<td/>').append('<td/>').append('<td/>')

                    },
                    dataSrc: 'clientet24'
                },              
                initComplete: function (settings, json) {
                    $.Loading(false);
                },
                paging: true, // permite la paginacion en la tabla .
                lengthMenu: [20], // Cantidad de registros mostrados por pantalla 
                searching: false, // genera cuadro de busqueda
                ordering: false, // genera ordenamiento de columnas                 
                responsive: false , // realiza la tabla responsiva en moviles
                destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva .                
                autoWidth: false,
                columns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 
                   { data: "id_rec"},
                   { data: "Div"},
                   { data: "Infolinea" },
                   { data: "clientet24" },
                   { data: "RgoDesc" },
                   { data: "nombre" },
                   { data: "ldescrip"},
                   { data: "idmultiple" },
                   { data: "lmonto", render: $.fn.dataTable.render.number(',', '.', 2, '$') },
                   { data: "lutilizado", render: $.fn.dataTable.render.number(',', '.', 2, '$') },
                   { data: "ldisponibl", render: $.fn.dataTable.render.number(',', '.', 2, '$') },
                   { data: "lvence" },
                   { data: "lmultiple", render: $.fn.dataTable.render.number(',', '.', 2, '$') },
                   { data: "gliq"  },
                   { data: "porcentaje", render: $.fn.dataTable.render.number('', '.', 2, '', '%') },
                   { data: "adeudo", render: $.fn.dataTable.render.number(',', '.', 2, '$') },
                   { data: "vencida", render: $.fn.dataTable.render.number(',', '.', 2, '$') },
                   { data: "cuenta" },
                   { data: "garantsdo", render: $.fn.dataTable.render.number(',', '.', 2, '$') },
                   { data: "garantutl", render: $.fn.dataTable.render.number(',', '.', 2, '$') }         
                ],
                fnFooterCallback: function (nRow, aaData, iStart, iEnd, aiDisplay) {
                    var table = this;
                    var api = table.api();
                    var gliquidaTot = 0;
                    var addText = ""
                    $("tfoot tr td").remove();

                    var result = aaData.reduce(function (acc, x) {
                        var id = acc[x.cuenta]
                        if (id) {
                            id.garantutl += x.garantutl
                        } else {
                            acc[x.cuenta] = x
                            delete x.cuenta
                        }
                        return acc
                    }, {})
                    
                    this.find('tfoot').length ? this.find('tfoot') :  $('<tfoot>').insertBefore($(this).find('tbody'));
                    
                    for (var key in result) {
                        if (key != "") {                          
                            $('tfoot').append('<tr><td/><td/><td/><td/><td/><td/><td/><td/><td/><td/><td/><td/><td/><td/><td/><td/><td/><td> Cuenta: ' + key + '</td><td>Saldo: ' + $.fn.dataTable.render.number(',', '.', 2, '$').display(result[key].garantsdo) + '</td> <td> Total Garantia Liquida: ' + $.fn.dataTable.render.number(',', '.', 2, '$').display(result[key].garantutl) + '</td></tr>');
                        }
                    }
                }
            });
        

    }, //Funcion que inicializa la tabla 
    openPopUp: function (pageUrl,header) {
        var $pageContent = $('<div>');

        $pageContent.load(pageUrl, function () {

            $pageContent.dialog({
                width: 600, // overcomes width:'auto' and maxWidth bug
                height: 'auto',
                modal: true,
                show: 'fade',
                title: header,
                hide: 'fade',
                fluid: true, //new option
                resizable: false,
                create: function (event, ui) { //permite inicializar parametros o campos dentro de el popup creado

                    //permite reiniciar el validado de informacion al despelgar una ventana modal
                    var form = $("#popupForm").closest("form");
                    form.removeData('validator');
                    form.removeData('unobtrusiveValidation');
                    $.validator.unobtrusive.parse(form);

                    $('.my_select_box').multiSelect({
                        cssClass: "fullwidth",
                        selectableHeader: "<div class='custom-header'>Seleccione Lineas</div>",
                        selectionHeader: "<div class='custom-header'>Lineas a Asociar</div>"
                    });
                    
                    $('#porcentaje').mask('000.00', { reverse: true });

                    $("#lmultiple").mask('000,000,000,000,000.00', { reverse: true });

                    // Validacion de tool tip 
                    $pageContent.tooltip({
                        items: ".input-validation-error",
                        content: function () {
                            return $("[data-valmsg-for='" + $(this).attr('id').replace("_",".") + "']").text();
                        }
                    });

                    data.validacionCampos();
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
                           if (data.Tipo == 2) {
                               tabla.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar

                           }
                           $pageContent.dialog('close');
                       } else {
                           mensajemodal(data.Text, 'warning');
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
    } ,// validacion de campos 
    inicializacionControles:function(){
        if ($("#propCliente_rgpo").is(':checked')) {
            $("#propCliente_riesgogpo").prop('disabled', false);
        } else {
            $("#propCliente_riesgogpo").prop('disabled', true);
            $("#propCliente_riesgogpo").val("");
        }
        $(".gliquida").addClass("disabled")
        $(".cancela").addClass("disabled")
    },
    ajax: function (url,tipo,data) {
        $.ajax({
            type: "POST",
            url: url,
            data: data,
            beforeSend: function () {
                $.Loading(true);
            },
            success: function (data) {
                if (data.Result) {
                    mensajemodal(data.Text, 'success');
                    if (data.Tipo == 2) {
                        tabla.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar
                    }                   
                } else {
                    mensajemodal(data.Text, 'warning');
                }

            },
            error: function () {
                mensajemodal('Ocurrio un error al consultar la informacion favor de intentar de nuevo!!', 'warning');
            },
            complete: function () {
                $.Loading(false);
            }

        });
    }
}

$(document).ready(function (e) {

    data.inicializarTabla(); // Realiza por primera vez 
    //Agregamos tamaños al data table para las columnas 
    //Valores exactos empiezan desde 1 
    $('thead > tr> th:nth-child(6)').css({ 'min-width': '250px', 'max-width': '250px' });
    $('thead > tr> th:nth-child(7)').css({ 'min-width': '400px', 'max-width': '400px' });
    //
    //
    $('thead > tr> th:nth-child(20)').css({ 'min-width': '150px', 'max-width': '150px' });

    $('#propCliente_riesgo').mask('000,000,000,000,000.00', { reverse: true });
    $('#propCliente_riesgogpo').mask('000,000,000,000,000.00', { reverse: true });
 
    
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
        }, 1000 )
    })


    $("#buttons").on('click',
        'a.btn',
        function (e) {
            e.preventDefault();
            if ($(this).attr('type') == 'submit') {
                data.ajax($(this).attr('href'), 'POST', {});
            }
            else if ($(this).attr("class").indexOf("actualiza") !== -1) {
                data.inicializarTabla();
            }
            else {                
                data.openPopUp($(this).attr('href'), $(this).text())
            }
        })

    tabla.on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
            $(".gliquida").addClass("disabled")
            $(".cancela").addClass("disabled")
        }
        else {
            tabla.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
            $(".gliquida").removeClass('disabled');
            $(".gliquida").removeAttr("href");
            $(".cancela").removeClass('disabled');
            $(".cancela").removeAttr("href")
            $(".gliquida").attr("href", gliquida + "?idRec=" + tabla.row('.selected').data()['id_rec'])
            $(".cancela").attr("href", cancela + "?idRec=" + tabla.row('.selected').data()['id_rec'])
        }
    });

    $(window).resize(function () {
        data.fluidDialog();
    });

    $(document).on('submit',
         '#ControlRiesgoForm',
         function (e) {
             e.preventDefault();
             var url = $('#ControlRiesgoForm')[0].action;
             data.ajax(url, 'POST', $('#ControlRiesgoForm').serialize());
         });    

    $("#propCliente_rgpo").click(function () {
        //check if checkbox is checked
        if ($(this).is(':checked')) {
            $("#propCliente_riesgogpo").prop('disabled', false);
        } else {
            $("#propCliente_riesgogpo").prop('disabled', true);
            $("#propCliente_riesgogpo").val("");
        }
    });

    $(document).tooltip({
        items: ".input-validation-error",
        content: function () {
            return $("[data-valmsg-for='" + $(this).attr('id').replace("_", ".") + "']").text();
        }
    });
    
});
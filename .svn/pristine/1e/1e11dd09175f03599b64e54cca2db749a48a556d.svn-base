/// <reference path="Contratos.js" />
var tabla;
var tadexpagar
var title;
var nombre;
var tgarantia = $('#tgarantia');
var data =
{

inicializarTabla: function (cesion,contrato, idtransact) {

    tabla = $('#table').DataTable({
        ajax: {
            "url": "../Catalogos/Obtenerdoctos/", // url del controlador a consultar 
            "Type": "GET",
            "data": function (d) { d.cesion = cesion, d.Contrato = contrato , d.idtransact = idtransact}, // parametros a enviar al controlador 
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
            //if ($("#producto").val() == 1)
            //{
            //    var column = tabla.column(2);
            //    column.visible(!column.visible());
            //}
        },
        searching:false,
        paging: true, // permite la paginacion en la tabla .      
        blengthMenu: false,
        //lengthMenu: [15,20],
        ordering: false, // genera ordenamiento de columnas 
        responsive: true, // realiza la tabla responsiva en moviles
        destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
        aoColumns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 
   {
       data: "iddocto", "width": "60px"
   },
   {
       data: "docto", "width": "100px"
   },
    {
        data: "fec_vence", "width": "100px"
    },
   {
       data: "monto", render: $.fn.dataTable.render.number(',', '.', 2, '')
   },
   {
       data: "interes", render: $.fn.dataTable.render.number(',', '.', 2, '')
   },
   {
       data: "hono", render: $.fn.dataTable.render.number(',', '.', 2, '')
   },
   {
       data: "iva", render: $.fn.dataTable.render.number(',', '.', 2, '')
   },
   {
     data: "nombreDeudor"
}
           ],
        "columnDefs": [
            {
                "className": "dt-right", "targets": [7],
                "className": "dt-left", "targets": [0, 1, 2, 3,4, 5 ]
            }
        ]
    });


}, //Funcion que inicializa la tabla 
inicializacionControles: function () {

    //$("#ContratoForm").find(':input').each(function () {

    //    var value = $(this).val()
    //    $(this).val(value.trim())

    //});

    //if ($("input[name='Contrato.interes']:checked").val() == 1) {
    //    $(".radios").hide();
    //}

    //if ($("#Contrato_rebate").is(':checked')) {
    //    $("#Contrato_rebatepts").prop("disabled", false)
    //} else {
    //    $("#Contrato_rebatepts").prop("disabled", true);
    //    $("#Contrato_rebatepts").val("0.00")
    //}

    //if ($("#Contrato_seguro").is(':checked')) {
    //    $("#Contrato_endoso").prop("disabled", false)
    //    $("#Contrato_cobertura").prop("disabled", false)
    //    $("#Contrato_idmapfre").prop("disabled", false)
    //    $("#Contrato_plazo").prop("disabled", false)
    //} else {
    //    $("#Contrato_endoso").prop("disabled", true)
    //    $("#Contrato_cobertura").prop("disabled", true)
    //    $("#Contrato_idmapfre").prop("disabled", true)
    //    $("#Contrato_plazo").prop("disabled", true)
    //}

    //$('#Contrato_linea').mask('000,000,000,000.00', { reverse: true });
    //$('#Contrato_tasa_ord').mask('000.00', { reverse: true });
    //$('#Contrato_tasa_ext').mask('000.00', { reverse: true });
    //$('#Contrato_porc_anti').mask('000.00', { reverse: true });
    //$('#Contrato_dispercom').mask('0,000,000,000,000.00', { reverse: true });
    //$('#Contrato_com_cont').mask('000.00', { reverse: true });
    //$('#Contrato_hon_admon').mask('000.00', { reverse: true });
    //$('#Contrato_rebatepts').mask('000.00', { reverse: true });

    //$('#Contrato_cobertura').mask('0,000,000,000,000.00', { reverse: true });

    //$("#Contrato_endoso").datepicker({
    //    dateFormat: 'dd/mm/yy', language: 'es', locale: 'es'
    //})

    $("#fec_alta").datepicker({
        dateFormat: 'dd/mm/yy', language: 'es', locale: 'es'
    })

    $("#fec_vence").datepicker({
        dateFormat: 'dd/mm/yy', language: 'es', locale: 'es'
    })

       //$("#Contrato_vencelinea").datepicker({
    //    dateFormat: 'dd/mm/yy', language: 'es', locale: 'es'
    //})

    //$("#Contrato_fec_alta").datepicker({
    //    dateFormat: 'dd/mm/yy', language: 'es', locale: 'es'
    //})

    //$("#Contrato_fec_vence").datepicker({
    //    dateFormat: 'dd/mm/yy', language: 'es', locale: 'es'
    //})
},
inicializarpagosadeudos: function (cesion,contrato) {

    tadeudo = $('#tpadeudo').DataTable({
        ajax: {
            "url": "../Catalogos/ObtenerpagosadeudosCtoCes/", // url del controlador a consultar 
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
            //if ($("#producto").val() == 1)
            //{
            //    var column = tabla.column(2);
            //    column.visible(!column.visible());
            //}
        },
        searching: false,
        paging: false, // permite la paginacion en la tabla .      
        //lengthMenu: [15, 20],
        ordering: false, // genera ordenamiento de columnas 
        autoWidth: false,
        responsive: true, // realiza la tabla responsiva en moviles
        destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
        aoColumns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 
     {
         data: "numrec", "width": "50px",  "className": "dt-left"
     },
     {
         data: "serie", "width": "20px", "className": "dt-left"
   },
   {
       data: "tipo", "width": "20px", "className": "dt-left"
   },
   {
       data: "docto",  "width": "20px", "className": "dt-left"
   },
   {
       data: "importe", render: $.fn.dataTable.render.number(',', '.', 2, '') , "width": "80px", "className": "dt-right"
   },
   {
       data: function (data, type, dataToSet) {
           return '<a class="cancelar" href="../Catalogos/CancelargarantiaWzd?garantiaid=' + data.garantiaid + '" ><button type="submit" class="btn glyphicon glyphicon-remove"></button></a>';
       }, "width": "10px", "className": "dt-center"
   },
   {
       data: function (data, type, dataToSet) {
           return '<a class="cancelar" href="../Catalogos/CancelargarantiaWzd?garantiaid=' + data.garantiaid + '" ><button type="submit" class="btn glyphicon glyphicon-remove"></button></a>';
       }, "width": "10px", "className": "dt-center"
   }
        ],
        "columnDefs": [
            {
                "className": "dt-left", "targets": [0, 1,2,3],
                "className": "dt-center", "targets": [6, 7],
                "className": "dt-rigth", "targets": [4],
                "width":"20px", "targets": [0]
            }
        ]
    });


}, //Funcion que inicializa la tabla 
inicializargarantia: function (cesion, contrato, idtransact) {

    tgarant = $('#tgarantia').DataTable({
        ajax: {
            "url": "../Catalogos/ObtenergarantiaCto/", // url del controlador a consultar 
            "Type": "GET",
            "data": function (d) { d.cesion = cesion, d.Contrato = contrato, d.idtransact = idtransact }, // parametros a enviar al controlador 
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
            //if ($("#producto").val() == 1)
            //{
            //    var column = tabla.column(2);
            //    column.visible(!column.visible());
            //}
        },
        searching: false,
        paging: false, // permite la paginacion en la tabla .      
        //lengthMenu: [15, 20],
        ordering: false, // genera ordenamiento de columnas 
        responsive: true, // realiza la tabla responsiva en moviles
        destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
        aoColumns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 
   {
       data: "garantiaid", "width": "50px"
   },
   {
       data: "nombreTipo", "width": "40px"
   },
   {
       data: "valor", render: $.fn.dataTable.render.number(',', '.', 2, ''), "className": "dt-right"
   },
   {
       data: "costo", render: $.fn.dataTable.render.number(',', '.', 2, ''), "className": "dt-right"
   },
   {
       data: "cobrado", render: $.fn.dataTable.render.number(',', '.', 2, ''), "className": "dt-right"
   },
   {
       data: "ivacobrado", render: $.fn.dataTable.render.number(',', '.', 2, ''), "className": "dt-right"
   },
   {
       data: function (data, type, dataToSet) {
           return '<a class="popup" href="../Catalogos/GuardarGarantiaWzd?garantiaid=' + data.garantiaid + '&contrato=' + $("#contrato").val() + '&producto=' + $("#producto").val() + '&cesion=' + $("#cesion").val() + '" add=' + data.garantiaid + ' ><button type="button" class="btn glyphicon glyphicon-search"></button></a>';
       }, "width": "10px", "className": "dt-center"
   },

   {
       data: function (data, type, dataToSet) {
           return '<a class="cancelar" href="../Catalogos/CancelargarantiaWzd?garantiaid=' + data.garantiaid + '" ><button type="submit" class="btn glyphicon glyphicon-remove"></button></a>';
       }, "width": "10px", "className": "dt-center"
   }


],
        "columnDefs": [
            {
                "className": "dt-left", "targets": [0, 1],
                "className": "dt-center", "targets": [6, 7],
                "className": "dt-rigth", "targets": [2,3,4,5]
                
            }
        ]
    });


}, //Funcion que inicializa la tabla 
inicializaradexpagar: function (contrato) {

    //e.preventDefault();

    tadexpagar = $('#tadexpagar').DataTable({
        ajax: {
            "url": "../Catalogos/Adeudosporpagar/", // url del controlador a consultar 
            "Type": "GET",
            "data": function (d) { d.Contrato = contrato }, // parametros a enviar al controlador 
            "dataSrc": function (json) {
                if (typeof (json.Mensaje) != 'undefined') {
                    mensajemodal(json.Mensaje, 'warning', json.titulo);
                    return {};
                } else {
                    return json.Data;
                }
            }
        },
        initComplete: function (settings, json) {
            $.Loading(false);
            
        },
        searching: false,
        paging: false, // permite la paginacion en la tabla .      
        //lengthMenu: [15, 20],
        ordering: false, // genera ordenamiento de columnas 
        responsive: true, // realiza la tabla responsiva en moviles
        destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
        aoColumns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 
   {
       data: "void", "width": "50px"
   },
   {
       data: "idadeudo", "width": "50px"
   },
   {
       data: "serie", "width": "40px"
   },
   {
       data: "tipo", "width": "40px"
   },
   {
       data: "docto", "width": "40px"
   },
   {
       data: "monto", render: $.fn.dataTable.render.number(',', '.', 2, ''), "className": "dt-right"
   },
   {
       data: "saldo", render: $.fn.dataTable.render.number(',', '.', 2, ''), "className": "dt-right"
   }
           ],
        "columnDefs": [
            {
                "className": "dt-left", "targets": [0, 1],
                "className": "dt-center", "targets": [6],
                "className": "dt-rigth", "targets": [2, 3, 4, 5]

            }
        ]
    });


}, //Funcion que inicializa la tabla 
openPopUpAde: function (pageUrl) {
    var $pageContent = $('<div>');

    $pageContent.load(pageUrl, function () {

        $pageContent.dialog({
            width: '1400', // overcomes width:'auto' and maxWidth bug
            height: '800',
            modal: true,
            show: 'fade',
            hide: 'fade',
            title: "Adeudos por liquidar",
            fluid: true, //new option
            resizable: false,
            create: function (event, ui) { //permite inicializar parametros o campos dentro de el popup creado
                data.inicializaradexpagar($("#contrato").val());
                },
            close: function () {
                $pageContent.dialog('destroy').remove();
            }
        });
    });

    $pageContent.on('submit',
       '#popupAdeForm',
       function (e) {
           var url = $('#popupAdeForm')[0].action;
           $.ajax({
               type: "POST",
               url: url,
               data: $('#popupAdeForm').serialize(),
               beforeSend: function () {
                   $.Loading(true);
               },
               success: function (data) {
                   if (data.Result) {
                       mensajemodal(data.Text, 'success');
                       if (tadexpagar !== undefined) {
                           tadexpagar.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar
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

    //$dialog.dialog('open');


},
openPopUp: function (pageUrl) {
    var $pageContent = $('<div>');
    $pageContent.load(pageUrl, function () {

        $pageContent.dialog({
            width: '500px', // overcomes width:'auto' and maxWidth bug
            height: 'auto',
            modal: true,
            show: 'fade',
            title: title == null ? "Nuevo Registro" : "Actualizar Registro",
            hide: 'fade',
            fluid: true, //new option
            resizable: true,
            create: function (event, ui) { //permite inicializar parametros o campos dentro de el popup creado

                data.inicializaradexpagar($("#contrato").val());

                $("#popupWin").find(':input').each(function () {

                    var value = $(this).val()
                    $(this).val(value.trim())

                });

                //permite reiniciar el validado de informacion al despelgar una ventana modal
                var form = $("#popupWin").closest("form");
                form.removeData('validator');
                form.removeData('unobtrusiveValidation');
                $.validator.unobtrusive.parse(form);

                $('#dmonto').mask('000,000,000,000.00', { reverse: true });
                $('#costo').mask('000,000,000,000.00', { reverse: true });
                $('#valor').mask('000,000,000,000.00', { reverse: true });
                $('#cobrado').mask('000,000,000,000.00', { reverse: true });
                $('#ivacobrado').mask('000,000,000,000.00', { reverse: true });


                $("#dfec_vence").datepicker({
                    dateFormat: 'dd/mm/yy', language: 'es', locale: 'es'
                })


                //$("#dfec_vence").change(function (e) {

                //    d = $("#dfec_vence").val()
                //    $("#fec_vence").val(d);

                //});


                $("#dmonto").change(function (e) {

                    d = parseFloat($("#dmonto").val().replace(/,/g, ''))
                    $("#monto").val(d);

                });



                $("#valor").change(function (e) {

                    var porc = $("#porcentaje").val() / 100;
                    var impanti = parseFloat($("#impanticipado").val().replace(/,/g, ''))
                    var plazo = $("#plazo").val()
                    var costo = ($("#costo").val() / 100) / 360;
                    var cob = (impanti * costo) * plazo
                    var ivacob = cob * .16

                    $("#cobrado").val($.fn.dataTable.render.number(',', '.', 2, '').display(cob));
                    $("#ivacobrado").val($.fn.dataTable.render.number(',', '.', 2, '').display(ivacob));

                });


                $("#porcentaje").change(function (e) {

                    var porc = $("#porcentaje").val() / 100;
                    var impanti = parseFloat($("#impanticipado").val().replace(/,/g, ''))
                    var plazo = $("#plazo").val()
                    var costo = ($("#costo").val() / 100) / 360;
                    var cob = (impanti * costo) * plazo
                    var ivacob = cob * .16

                    $("#cobrado").val($.fn.dataTable.render.number(',', '.', 2, '').display(cob));
                    $("#ivacobrado").val($.fn.dataTable.render.number(',', '.', 2, '').display(ivacob));

                });


                $("#costo").change(function (e) {

                    var porc = $("#porcentaje").val() / 100;
                    var impanti = parseFloat($("#impanticipado").val().replace(/,/g, ''))
                    var plazo = $("#plazo").val()
                    var costo = ($("#costo").val() / 100) / 360;
                    var cob = (impanti * costo) * plazo
                    var ivacob = cob * .16


                    $("#cobrado").val($.fn.dataTable.render.number(',', '.', 2, '').display(cob));
                    $("#ivacobrado").val($.fn.dataTable.render.number(',', '.', 2, '').display(ivacob));

                });





                // Validacion de tool tip 
                $pageContent.tooltip({
                    items: ".input-validation-error",
                    content: function () {
                        return $("[data-valmsg-for='" + $(this).attr('id').replace("_", ".") + "']").text();
                    }
                });
            }
            ,
            close: function () {
                $pageContent.dialog('destroy').remove();
            }
        });



    });

    $pageContent.on('submit',
       '.popupWin',
       function (e) {
           var url = $('.popupWin')[0].action;
           $.ajax({
               type: "POST",
               url: url,
               data: $('.popupWin').serialize(),
               beforeSend: function () {
                   //$.Loading(true);
                   //alert("antes de enviar")
               },
               success: function (data) {
                   if (data.Result) {
                       //mensajemodal(data.Text, 'success');
                       if (data.Tipo == 2) {
                           tabla.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar
                           tgarant.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar
                       }
                   } else {
                       mensajemodal(data.Text, 'warning');
                   }
                   //$pageContent.dialog('close');
               },
               error: function () {
                   mensajemodal('Ocurrio un error al consultar la informacion favor de intentar de nuevo!!', 'warning');

               },
               complete: function () {
                   //$.Loading(false);
               }
           });

           e.preventDefault();

       });


},
ajax: function (url, tipo, data) {
    $.ajax({
        type: tipo,
        url: url,
        beforeSend: function () {
            //$.Loading(true);
        },
        success: function (data) {
            if (data.Result) {
                //mensajemodal(data.Text, data.color, data.titulo);
        
                if (data.Tipo == 2) {
                    tgarant.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar
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
            //$.Loading(false);
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


     jQuery.validator.addMethod('mayorcero', function (value, element, params) {
         if (parseFloat($("#importe").val().replace(/,/g, '')) > 0.0) {
             return true
         }
         else {
             return false
         }

         if (parseFloat($("#impanticipado").val().replace(/,/g, '')) > 0.0) {
             return true
         }
         else {
             return false
         }

         if (parseFloat($("#monto").val().replace(/,/g, '')) > 0.0) {
             return true
         }
         else {
             return false
         }

     }, '');

     jQuery.validator.unobtrusive.adapters.add('mayorcero', function (options) {
         options.rules['mayorcero'] = {};
         options.messages['mayorcero'] = options.message;
     });


    
     
}

}

data.validacionCampos();

$(document).ready(function () {
    //Initialize tooltips  
    
    $('#importe').mask('000,000,000,000.00', { reverse: true });
    $('#impanticipado').mask('000,000,000,000.00', { reverse: true });
    $('#porcentaje').mask('000.00', { reverse: true });
    var d = $('#doc').val( );
    $('#doctos').val(d );


    $('.nav-tabs > li a[title]').tooltip();

    //Wizard
    $('a[data-toggle="tab"]').on('show.bs.tab', function (e) {

        var $target = $(e.target);

        if ($target.parent().hasClass('disabled')) {

            return false;
        }
    });

    $(".next-step").click(function (e) {

        var $active = $('.wizard .nav-tabs li.active');
        $active.next().removeClass('disabled');
        nextTab($active);

     });

    $(".prev-step").click(function (e) {

        var $active = $('.wizard .nav-tabs li.active');
        prevTab($active);

    });

    data.inicializacionControles()
    data.inicializarTabla($("#cesion").val(), $("#contrato").val(), $("#idtransact").val())
    data.inicializargarantia($("#cesion").val(), $("#contrato").val(), $("#idtransact").val())
    data.inicializarpagosadeudos($("#cesion").val(), $("#contrato").val())


    $('.popupForm').tooltip({
        items: ".input-validation-error",
        content: function () {
            return $("[data-valmsg-for='" + $(this).attr('id').replace("_", ".") + "']").text();
        }
    });


    $(".container").on('click', 'a.popup',
      function (e) {
          e.preventDefault();
          title = $(this).attr("add") // set the title for popup
          op = $(this).attr('href')

          

          if (op.indexOf("GuardaradeudosWzd") > 0) {
              data.openPopUpAde($(this).attr('href'));
          }
          else {
              data.openPopUp($(this).attr('href'));
          }




      });
   
});

//".container"

//$(document).on('submit',

//Botones en el Formulario 

$(".container").on('submit',
        '.popupForm',
        function (e) {
            var url = $('.popupForm')[0].action;
            $.ajax({
                type: "POST",
                url: url,
                data: $('.popupForm').serialize(),
                beforeSend: function () {
                    //$.Loading(true);

                                   },
                success: function (data) {
                    if (data.Result) {

                        var $active = $('.wizard .nav-tabs li.active');
                        $active.next().removeClass('disabled');
                        nextTab($active);

                        //$(elem).next().find('a[data-toggle="tab"]').click();

                       $("#cesion").val(data.cesion)
                        //mensajemodal(data.Text, 'success');

                     
                        if (data.Tipo == 2) {
                            tabla.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar
                            tgarant.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar
                        }
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
                    }
            
            })
         e.preventDefault()
        });



$("#fec_vence").change(function (e) {
 

    var startDateString = $("#fec_alta").val();
    var endDateString = $("#fec_vence").val();

    var startDate = moment(startDateString, "DD/M/YYYY");
    var endDate = moment(endDateString, "DD/M/YYYY");

    var diffInDays = endDate.diff(startDate, 'days');
    $("#plazo").val(diffInDays);
   
});

$("#importe").change(function (e) {


    var porc = $("#porc_anti").val() / 100 ;
    var importe = parseFloat($("#importe").val().replace(/,/g, ''))
    var anti = importe * porc

    $("#impanticipado").val($.fn.dataTable.render.number(',', '.', 2, '').display(anti));
    
    //$("#importe").val(importe);
    //$("#impanticipado").val(anti);


});

function nextTab(elem) {
    $(elem).next().find('a[data-toggle="tab"]').click();
}

function prevTab(elem) {
    $(elem).prev().find('a[data-toggle="tab"]').click();
}


$(".container").on('click', 'a.cancelar',
   function (e) {

       e.preventDefault();
             

       var doc = $(this).parents("tr").find("td")[0].innerHTML;
       var url = $(this).attr("href");


       $('#dialog-confirm').text("Se eliminará garantía con ID " + doc + " , ¿Desea continuar?")

           $('#dialog-confirm').dialog({
               resizable: true,
               height: "auto",
               title: "Eliminar registro",
               width: 400,
               modal: true,
               buttons: {
                   "Aceptar": function () {
                       data.ajax(url, "POST", null);
                       $('#dialog-confirm').dialog("close");
                   },
                   "Cancelar": function () {
                       $('#dialog-confirm').dialog("close");

                   }
               }
           })

   });

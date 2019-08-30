//Inicializacion de variables
var tablaFinanciero;
var btnConsulta = $('#btnConsultar');
var fecha = $('#fecha');
var title;
var a = /,/g //Regex para quitar comas de montos de moneda

$.ajaxSetup({
    // Disable caching of AJAX responses For IE !!!
    cache: false
});


var fact =
{
    inicializarTabla: function (serie, fecha) {

        $.Loading(true)

        tablaFinanciero = $('#table')
            .DataTable({

                ajax: {
                    "url": "../Facturacion/ConsultaFacturas", // url del controlador a consultar 
                    "contentType": "application/json",
                    "Type": "GET",
                    "data": function (d) { d.serie = serie, d.fecha = fecha }, // parametros a enviar al controlador 
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
                "dom": 'lfrtip',
                "lengthMenu": [25, 50, 75], // Cantidad de registros mostrados por pantalla                 
                
                paging: true, // permite la paginacion en la tabla .                
                searching: true, // genera cuadro de busqueda
                ordering: false, // genera ordenamiento de columnas                 
                responsive: true, // realiza la tabla responsiva en moviles
                destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
                columns: [ // permite saber que columnas se usaran del json retornado desde el servidor .                     
           { data: "fecha", orderable: false, "render": function (value) {
                   if (value === null) return "";
                   //Formato de fechas
                   var pattern = /Date\(([^)]+)\)/;
                   var results = pattern.exec(value);
                   var dt = new Date(parseFloat(results[1]))

                   var valMonth = (dt.getMonth().toString().length < 2 ? "0" : "")
                   var valDay = (dt.getDate().toString().length < 2 ? "0" : "")

                   return valDay + (dt.getDate()) + "/" + (dt.getMonth().toString().length == 1 ? "0" : "") + (dt.getMonth() + 1) + "/" + dt.getFullYear();
               } },
           { data: "idfiscalpf", orderable: false },
           { data: "ssat", orderable: false },
           { data: "sat", orderable: false },
           { data: "folio", orderable: false },
           { data: "sisfol",  orderable: false },
           { data: "contrato", orderable: false},
           { data: "nombre",  orderable: false},
           { data: "importe", render: $.fn.dataTable.render.number(',', '.', '2', '$'), orderable: false },
           { data: "cancel", orderable: false },
           { data: "generated", orderable: false },
           { data: "divisa", orderable: false },
           { data: "impresiones", orderable: false },
           { data: "distrib", orderable: false },
           { data: "emision", orderable: false, "render": function (value) {
                   if (value === null) return "";
                   //Formato de fechas
                   var pattern = /Date\(([^)]+)\)/;
                   var results = pattern.exec(value);
                   var dt = new Date(parseFloat(results[1]))

                   var valMonth = (dt.getMonth().toString().length < 2 ? "0" : "")
                   var valDay = (dt.getDate().toString().length < 2 ? "0" : "")

                   return valDay + (dt.getDate()) + "/" + (dt.getMonth().toString().length == 1 ? "0" : "") + (dt.getMonth() + 1) + "/" + dt.getFullYear();
               } }
           ],
             "columnDefs": [
             { "width": "auto", "className": "dt-body-center ", "targets": [0, 1, 2, 3, 4, 5, 6, 8, 9, 10, 11, 12, 13, 14] },
             { "width": "auto", "className": "dt-head-center ", "targets": [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14] },
             { "width": "auto", "className": "dt-body-left ", "targets": [7] }
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

    }
    

}

$(document).ready(function () {    

      

    fecha.MonthPicker({ Button: false })
    
    fact.inicializarTabla('A', '01/01/2018')

   $('#btnConsultar').click(function () {
       console.log(fecha.val())
       fact.inicializarTabla('A', '01/01/2018')
   })

   

   

});
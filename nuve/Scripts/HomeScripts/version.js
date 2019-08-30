
var version =
{
    inicializarTabla: function () {
        tabla = $('#table')
            .DataTable({
                ajax: {
                    "url": "../home/obtenerVersiones", // url del controlador a consultar 
                    "data": function (d) { },
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
                    $.Loading(false);
                },
                dom: "frtip",
                paging: false, // permite la paginacion en la tabla .
                lengthMenu: [15], // Cantidad de registros mostrados por pantalla 
                searching: true, // genera cuadro de busqueda
                ordering: false, // genera ordenamiento de columnas 
                responsive: true, // realiza la tabla responsiva en moviles
                destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
                columns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 
           { data: "version" },
           { data: "fecha" },
           {
               data: "id", "width": "30px", "render": function (data) {
                   return '<a class="popup" href="../home/consultarVersion?id=' + data + '"   ><button type="button" class="btn glyphicon glyphicon-eye-open"></button></a>';
               }
           }
                ],
                "columnDefs": [
                    { "className": "dt-center", "targets": [0, 1, 2] } // permite centrar botones de edicion 
                ]
            });


    },
    openPopUp: function (pageUrl, titulo) {
        var $pageContent = $('<div>');

        $pageContent.load(pageUrl, function () {

            $pageContent.dialog({
                width: '50%', // overcomes width:'auto' and maxWidth bug
                height: 'auto',
                modal: true,
                show: 'fade',
                title: titulo,
                hide: 'fade',
                resizable: false,
                create: function (event, ui) {
                    $('#fecha').duDatepicker({ format: 'dd/mm/yyyy' });
                }
                ,
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
                   success: function (data) {
                       if (data.Result) {
                           mensajemodal(data.Text, 'success');                         
                               tabla.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar                           
                       } else {
                           mensajemodal(data.Text, 'warning');
                       }
                       $pageContent.dialog('close');
                   },
                   error: function () {
                       $.alert({
                           title: "Error",
                           type: 'red',
                           content: "Ocurrio un error favor de volver a intentar!!",
                           animateFromElement: false
                       });
                   }
       });

       e.preventDefault();
   });
    }
}


$(document).ready(function (e) {
    $.fn.modal.Constructor.prototype.enforceFocus = function () { };
    version.inicializarTabla(); // Realiza consulta al mes actual y año actual al carga la pagina pro primera vez 
    $(".container").on('click', 'a.popup',
            function (e) {
                e.preventDefault();
                version.openPopUp($(this).attr('href'), "Detalle de version");
            }
    );

    $(".versionPopUp").on('click', function (e) {
        e.preventDefault();
        version.openPopUp($(this).attr('href'), "Alta de version");
    }
 );
});
$.Loading(true);
//Inicializacion de variables
var tablaParidad;
var proveedor =
{
    inicializarTabla: function () {

        tablaParidad = $('#tableProveedor').
            on('init.dt', function () {
                $.Loading(false);
            })// Evento se dispara cuando se ha cargado la taba con la informacion de ajax y se na inicializado 
            .DataTable({
                "ajax": {
                    "url": "/Catalogos/ObtenerListaProveedores/", // url del controlador a consultar 
                    "Type": "GET",
                    "data": "", // parametros a enviar al controlador 
                    "dataSrc": function (json) {
                        if (typeof (json.Mensaje) != 'undefined') {
                            $.Loading(false);
                            return {};
                        } else {
                            return json.Results;
                        }
                    }
                },
                dom: "lfrtBip",
                buttons: [
                      'excel', 'pdf', 'print' // permiten agregar botones para exportar a excel 
                ],
                paging: true, // permite la paginacion en la tabla .
                lengthMenu: [10,15,30], // Cantidad de registros mostrados por pantalla 
                searching: true, // genera cuadro de busqueda
                ordering: true, // genera ordenamiento de columnas 
                order: [[0, 'desc']], // ordena la primer columna
                responsive: true, // realiza la tabla responsiva en moviles
                destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
                columns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 
           { data: "deudor" },
           { data: "nombre", orderable: false },
           {
               data: "deudor", "width": "50px", "render": function (data) {
                   return '<a class="popup" href="/Catalogos/GuardarProveedor?deudor=' + data + '"><button type="button" class="btn glyphicon glyphicon-pencil"></button></a>';
               }, orderable: false
           } // Hace referencia al boton de Editar
                ],
                "columnDefs": [
                    { "className": "dt-body-center", "targets": [2] } // permite centrar botones de edicion 
                ]
            });


    }, //Funcion que inicializa la tabla 
    openPopUp: function (pageUrl) {
        var $pageContent = $('<div>');
        $pageContent.load(pageUrl,
            function() {
                $pageContent.dialog({
                    width: 'auto',
                    height: 'auto',
                    modal: true,
                    show: 'fade',
                    title : 'prueba',
                    hide: 'fade',
                    fluid: true, //new option
                    resizable: false,
                    create: function( event, ui ) {
                        // Seteat elementos internos del popup
                        var form = $("#popupForm").closest("form");
                        form.removeData(
                            'validator'); //permite reiniciar el validado de informacion al despelgar una ventana modal
                        form.removeData('unobtrusiveValidation');
                        $.validator.unobtrusive.parse(form);

                        $("#fec_alta").datetimepicker({ locale: 'es', format: 'DD/MM/YYYY' });
                        //  Setear anchura minima y maxima 
                        $(this).css("maxWidth", "1200px");
                        $(this).css("minWidth", "400px");
                    },
                    close: function () {
                        $pageContent.dialog('destroy').remove();
                    }
                });

            });
        $('.popupWindow').on('submit',
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
                            tablaParidad.ajax.reload();
                        } else {
                            mensajemodal(data.Text, 'warning');
                        }
                        $dialog.dialog('close');
                    }
                });

                e.preventDefault();
            });

        //$dialog = $('<div class="popupWindow" style="overflow:auto"></div>').html($pageContent);
     

        //$dialog.dialog({
        //        width: 'auto', // overcomes width:'auto' and maxWidth bug
        //        height: 'auto',
        //        modal: true,
        //        maxWidth: 1200,
        //        show: 'fade',   
        //        hide: 'fade',
        //        fluid: true, //new option
        //        resizable: false,
        //        close: function () {
        //            $dialog.dialog('destroy').remove();
        //        }
        //    });

       

        //$pageContent.dialog('open');
        

    },
    fluidDialog:function() {
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

$(document).ready(function (e) {

    proveedor.inicializarTabla();

    

    $("#tableContainer").on('click', 'a.popup',
        function (e) {
            e.preventDefault();
            proveedor.openPopUp($(this).attr('href'));

        });

    $(window).resize(function () {
         proveedor.fluidDialog();
      
    });


});


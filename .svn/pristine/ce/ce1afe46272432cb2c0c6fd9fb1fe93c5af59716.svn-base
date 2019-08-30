

$.ajaxSetup({
    cache: false
})

aseguradora = {

    inicializaTabla: function () {

        tablaAseg = $('#tablaAseguradoras')
        .DataTable({

            ajax: {
                "url": "../Aseguradora/ConsultaAseguradoras",
                "contentType" : "application/json",
                "Type" : "GET",                
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
                { data: 'idaseguradora', orderable: true },
                { data: 'nombre', orderable: false },
                {
                    data: "idaseguradora", "render": function (data) {
                        return '<a class="popup edit" href="../Aseguradora/DetalleAseguradora?idaseguradora='+ data +'&tipo=1" id="' + data + '"><button name="detail" type=button" class="btn glyphicon glyphicon-pencil"></button></a>';
                    }
                }
            ],
            columnDefs: [
                 { 'class': 'dt-head-center', "targets": [1] },
                 { 'width': '35px', 'class': 'dt-head-center dt-body-center', "targets": [0, 2] }
            ]
        })
    },
    openPopUp: function (pageUrl, titulo) {
        var $pageContent = $('<div>');

        $pageContent.load(pageUrl, function () {

            var ancho = (titulo == 'Factura Electrónica.' ? '420' : '670')

            $pageContent.dialog({
                width: ancho, // overcomes width:'auto' and maxWidth bug
                height: 'auto',
                modal: true,
                show: 'fade',
                title: titulo,
                hide: 'fade',
                fluid: true, //new option
                resizable: false,
                create: function (event, ui) { //permite inicializar parametros o campos dentro de el popup creado

                    //permite reiniciar el validado de informacion al despelgar una ventana modal
                    var form = $("#popupForm").closest("form");
                    form.removeData('validator');
                    form.removeData('unobtrusiveValidation');
                    $.validator.unobtrusive.parse(form);

                    $(this).width(300)

                    $('input:text').each(function () {

                        $(this).val($(this).val().trim())
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
               
               e.preventDefault();

               var url = $('#popupForm')[0].action;
               
               $.ajax({
                   type: "POST",
                   url: url,
                   data: $('#popupForm').serialize(),
                   beforeSend: function () {
                       $.Loading(true);
                   },
                   success: function (response) {

                       if (response.proceso = "1") {
                           mensajemodal(response.mensaje, 'success', 'Aseguradoras')
                           tablaAseg.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar
                       } else {
                           mensajemodal(response.mensaje, 'success', 'Aseguradoras')
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

               e.preventDefault();
               
           });
    }
}





$(document).ready(function(){

    aseguradora.inicializaTabla()


    $('#tableContainer').on('click', 'a.edit', function (e) {
        e.preventDefault()
        url = $(this).attr('href')
        aseguradora.openPopUp(url,'Editar Aseguradora')
        
    })

    $('#btnNuevo').click(function (e) {
        e.preventDefault()
        url = $(this).attr('href')
        aseguradora.openPopUp(url, 'Nueva Aseguradora')
        
    })

})
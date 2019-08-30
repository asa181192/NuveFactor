var fecha = $('#fecha')
var idctabanco = $('#idctabanco')

var sal = {
    inicializarTabla: function (fecha, idctabanco) {

        tablaFinanciero = $('#tableSalidas')
            .DataTable({
                ajax: {
                    "url": "../Reportes/ConsultaSalidas", // url del controlador a consultar 
                    "contentType": "application/json",
                    "Type": "GET",
                    "data": function (d) { d.fecha = fecha, d.idctabanco = idctabanco }, // parametros a enviar al controlador 
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
                dom: "lfrtBip",
                buttons: [
                      {
                          extend: 'excelHtml5',
                          title: 'Salidas al ' + fecha,
                          message: 'Cuenta ' + $('select[name="idctabanco"] option:selected').text()

                      },

                ],
                paging: true, // permite la paginacion en la tabla .
                lengthMenu: [15, 25, 50, 75], // Cantidad de registros mostrados por pantalla 
                searching: true, // genera cuadro de busqueda
                ordering: false, // genera ordenamiento de columnas                 
                responsive: true, // realiza la tabla responsiva en moviles
                destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
                columns: [ // permite saber que columnas se usaran del json retornado desde el servidor .                     
           { data: "divisa", orderable: false },
           { data: "folio", orderable: false },
           { data: "contrato", orderable: false },
           { data: "concepto", orderable: false },          
           { data: "salida", orderable: false, render: $.fn.dataTable.render.number(',', '.', '2', '') }           
                ],
                "columnDefs": [
                    { "className": "dt-head-center dt-body-center", "targets": [0, 1, 2, 4] },
                    //{ "className": "dt-body-center", "targets": [0, 1, 2, 3, 4, 5] },
                    { "className": "dt-footer-center", "targets": [0, 1, 2, 3, 4] },
                    { "width": "auto", "targets": [0, 1, 2, 3, 4]}
                ],
                "footerCallback": function (row, data, start, end, display) {

                    var api = this.api(), data;


                    var intVal = function (i) {
                        return typeof i === 'string' ?
                            i.replace(/[\$,]/g, '') * 1 :
                            typeof i === 'number' ?
                            i : 0;
                    };

                    // Total over all pages
                    salidas = api
                        .column(4)
                        .data()
                        .reduce(function (a, b) {
                            return intVal(a) + intVal(b);
                        }, 0);
                    

                    // Update footer
                    $(api.column(4).footer()).html(
                         $.fn.dataTable.render.number(',', '.', 2, '').display(salidas)
                    );

                   

                }
            });
    }
}
$(document).ready(function () {

    fecha.keydown(function () {
        return false
    })

    fecha.datepicker({ dateFormat: 'dd/mm/yy', language: 'es', locale: 'es' }).datepicker("setDate", "0")

    sal.inicializarTabla(fecha.val(), idctabanco.val())

    $('#btnConsultar').click(function () {
        sal.inicializarTabla(fecha.val(), idctabanco.val())
    })

})
﻿
var vencida =
{
    inicializarTabla: function (contrato) {

        tablaAdeudos = $('#table')
            .DataTable({
                ajax: {
                    "url": "../Cobranza/obtenerCarteraVencida", // url del controlador a consultar 
                    "data": function (d) { d.contrato = contrato },
                    "Type": "GET",
                    "dataSrc": function (json) {
                        if (typeof (json.Mensaje) != 'undefined') {
                            
                            return {};
                        } else {
                            return json.Results;
                        }
                    }
                },
                rowGroup: {
                    startRender: null,
                    endRender: function (rows, group) {
                        var saldo = 0                      
                        for (var i = 0 ; i < rows.data().count() ; i++) {
                            saldo = saldo + rows.data()[i].saldo
                        }


                        var lmontoTot = $.fn.dataTable.render.number(',', '.', 2, '$').display(saldo);

                        //Se deben contar las posiciones empiezan desde 0 
                        return $('<tr/>')
                                .append('<td  colspan="4">  </td>')
                                .append('<td style="text-align:center">' + lmontoTot + '</td>')
                                .append('<td></td><td></td>')
                  
                    },
                    dataSrc: 'contrato'
                },
                initComplete: function (settings, json) {
                    $.Loading(false);
                },
                dom: "frtip",              
                paging: true, // permite la paginacion en la tabla .
                lengthMenu: [15], // Cantidad de registros mostrados por pantalla 
                searching: true, // genera cuadro de busqueda
                ordering: true, // genera ordenamiento de columnas 
                order: [[1, 'desc']], // ordena la primer columna
                responsive: true, // realiza la tabla responsiva en moviles
                destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
                columns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 
           { data: "contrato", orderable: true },
           { data: "deudor" },
           { data: "deunombre" },
           { data: "docto", orderable: true },
           { data: "saldo",render: $.fn.dataTable.render.number(',', '.', '2', ''), orderable: true },
           { data: "fec_vence" },
           { data: "plazo", },
                ],
                "columnDefs": [
                    { "className": "dt-center", "targets": [0,1,4,5,6] } // permite centrar botones de edicion 
                ]
            });


    }
}

$(document).ready(function (e) {
    vencida.inicializarTabla($("#contrato").val()); // Realiza consulta al mes actual y año actual al carga la pagina pro primera vez 
      

});
//Inicializacion de variables
var tabla;
var a = /,/g //Regex para quitar comas de montos de moneda

$.ajaxSetup({
  // Disable caching of AJAX responses For IE !!!
  cache: false
});

var target =
{
  inicializarTabla: function () {

    tabla = $('#tabla')
        .DataTable({
          ajax: {
            "url": "../Cobranza/obtenerMonitorlineas", // url del controlador a consultar 
            "Type": "GET",
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
          dom: "Bfrtip",
          buttons: [
                'excel' // permiten agregar botones para exportar a excel 
          ],
          paging: true, // permite la paginacion en la tabla .
          lengthMenu: [15], // Cantidad de registros mostrados por pantalla 
          searching: true, // genera cuadro de busqueda
          ordering: true, // genera ordenamiento de columnas 
          order: [[1, 'desc']], // ordena la primer columna
          responsive: true, // realiza la tabla responsiva en moviles
          destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
          columns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 
     { data: "contrato", "width": "30px", orderable: false },
     { data: "nombre", "width": "350px", orderable: true },
     { data: "Tinteres", "width": "40px", orderable: false },
     { data: "producto", orderable: false },
     { data: "divisa", "width": "20px", orderable: false },
     { data: "linea", render: $.fn.dataTable.render.number(',', '.', '2', ''), orderable: false, className: 'dt-body-right', "width": "80px" },
     { data: "cartera", render: $.fn.dataTable.render.number(',', '.', '2', ''), orderable: false, className: 'dt-body-right' },
     { data: "vencida", render: $.fn.dataTable.render.number(',', '.', '2', ''), orderable: false, className: 'dt-body-right' },
     { data: "adeudo", render: $.fn.dataTable.render.number(',', '.', '2', ''), orderable: false, className: 'dt-body-right' },

     { data: "moratorio", render: $.fn.dataTable.render.number(',', '.', '2', ''), orderable: false, className: 'dt-body-right' },
     { data: "iv", render: $.fn.dataTable.render.number(',', '.', '2', ''), orderable: false, className: 'dt-body-right' },
     { data: "imv", render: $.fn.dataTable.render.number(',', '.', '2', ''), orderable: false, className: 'dt-body-right' },
     { data: "total", render: $.fn.dataTable.render.number(',', '.', '2', ''), orderable: false, className: 'dt-body-right' },
          ],
          "columnDefs": [
              { "className": "dt-body-center", "targets": [2,3,4] } // permite centrar botones de edicion 
          ]
        });


  }, //Funcion que inicializa la tabla 


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

}

$(document).ready(function (e) {

  target.inicializarTabla(); // Realiza consulta al mes actual y año actual al carga la pagina pro primera vez 

 
  $(window).resize(function () {
    target.fluidDialog();
  });

});
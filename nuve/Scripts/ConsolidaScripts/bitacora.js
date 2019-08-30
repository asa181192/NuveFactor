//Inicializacion de variables
var tabla;
var title;
var fecha = $('#fecha');
var nombre;
var data =
{
  inicializarTabla: function (fecha) {

    tabla = $('#table')
        .DataTable({
          ajax: {
            "url": "../Consolidaciones/Obtenermovtos/", // url del controlador a consultar 
            "Type": "GET",
            "data": function (d) { d.fecha = fecha }, // parametros a enviar al controlador 
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
          },
          buttons: ['excel'
          ],
          paging: true, // permite la paginacion en la tabla .   
          lengthMenu: [30],
          "dom": 'frtip',
          searching: true, // genera cuadro de busqueda
          ordering: false, // genera ordenamiento de columnas 
          order: [[0, 'desc']], // ordena la primer columna
          responsive: true, // realiza la tabla responsiva en moviles
          destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
          aoColumns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 
     {
       data: "tfecha", "width": "40px"
     },
     {
       data: "archivo", "width": "120px"
     },
     {
       data: "resultado", "width": "500px"
     },
     {
       data: function (data, type, dataToSet) {
         return data.exito == true ? '<img src="../Images/checked.png">' : '<img src="../Images/cross.png">'
       }, "width": "40px"
     },
          ],
          "columnDefs": [
              { "className": "dt-center", "targets": [3] },
              { "className": "dt-left", "targets": [0, 1, 2] }
          ]
        });


  }, //Funcion que inicializa la tabla 
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
  }
}

$(document).ready(function (e) {
  //Esto nos permite Abrir modal dentro de modal . 
  $.fn.modal.Constructor.prototype.enforceFocus = function () { };

  fecha.val(moment().format('DD/MM/YYYY'))
  data.inicializarTabla(moment().format('DD/MM/YYYY'))
  
  $('#fecha').duDatepicker({ format: 'dd/mm/yyyy' }).on('datechanged', function (e) {
    data.inicializarTabla(e.date)
  });

  //$(".excel").on("click", function () {
  //  tabla.button('.buttons-excel').trigger();
  //});


  $("#Actualizar").on("click", function () {
         data.inicializarTabla(fecha.val())
  });

  $("#tableContainer").on('click', 'a.file', function (e) {
    $.Loading(true)
    Cookies.remove('reporte');
    Cookies.set('reporte', 'FALSE');
    var time = setInterval(function () {
      if (Cookies.get('reporte') == 'OK') {
        $.Loading(false)
        clearInterval(time);
        Cookies.remove('reporte');
      }
    }, 1000)
  });

});
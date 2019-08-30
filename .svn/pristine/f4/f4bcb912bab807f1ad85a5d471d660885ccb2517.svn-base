//Inicializacion de variables
var tabla;
var title;
var nombre;
var data =
{
  inicializarTabla: function (fecha) {

    tabla = $('#table')
        .DataTable({
          ajax: {
            "url": "../Cobranza/ObtenerAforosLiquidados/", // url del controlador a consultar 
            "Type": "GET",
            "data": function (d) { d.fecha = fecha }, // parametros a enviar al controlador 
            "dataSrc": function (json) {
              if (typeof (json.Mensaje) != 'undefined') {
                mensajemodal(json.Mensaje, 'warning');
                return {};
              } else {
                return json.Results;
              }
            }
          },
          initComplete: function (settings, json) {
            $.Loading(false);
          },
          paging: false, // permite la paginacion en la tabla .               
          ordering: false, // genera ordenamiento de columnas 
          order: [[0, 'desc']], // ordena la primer columna
          responsive: true, // realiza la tabla responsiva en moviles
          destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
          aoColumns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 
     {
       data: "contrato", "width": "50px"
     },
     {
       data: "nombre", "width": "350px"
     },
     {
       data: "benef", "width": "400px"
     },
     {
       data: "importe", render: $.fn.dataTable.render.number(',', '.', 2, ''), "width": "100px"
     },
     {
       data: "pago", render: $.fn.dataTable.render.number(',', '.', 2, ''), "width": "100px"
     },
     {
       data: "Cuenta", "width": "100px"
     },
     {
       data: "folio", "width": "100px"
     },
     {
       data: "Moneda", "width": "100px"
     },
     {
       data: function (data, type, dataToSet) {
         return '<a class="Reporte" href="../Cobranza/ReporteCalculoAforo?fecha=' + fecha + '&contrato=' + data.contrato + '&id=' + data.id + '&identidad=' + data.identidad + '"><button type="submit" class="btn glyphicon glyphicon-download-alt"></button></a>';
       }, "width": "50px"
     }
          ],
          "columnDefs": [
              { "className": "dt-center", "targets": [0, 5, 6, 7, 8] } // permite centrar botones de edicion 
          ]
        });


  }, //Funcion que inicializa la tabla 
  openPopUp: function (pageUrl) {
    var $pageContent = $('<div>');

    $pageContent.load(pageUrl, function () {

      $pageContent.dialog({
        width: '720', // overcomes width:'auto' and maxWidth bug
        height: 'auto',
        modal: true,
        show: 'fade',
        title: title == null ? "Nuevo Registro" : nombre,
        hide: 'fade',
        resizable: false,
        create: function (event, ui) { //permite inicializar parametros o campos dentro de el popup creado

          //permite reiniciar el validado de informacion al despelgar una ventana modal
          var form = $("#popupForm").closest("form");
          form.removeData('validator');
          form.removeData('unobtrusiveValidation');
          $.validator.unobtrusive.parse(form);

          // Validacion de tool tip 
          $pageContent.tooltip({
            items: ".input-validation-error",
            content: function () {
              return $("[data-valmsg-for='" + $(this).attr('id') + "']").text();
            }
          });
          data.inicializarObjetos();
          data.eventos();
          data.validacionCampos();
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
           beforeSend: function () {
             $.Loading(true);
           },
           success: function (data) {
             if (data.Result) {
               mensajemodal(data.Text, 'success', data.titulo);
               if (tabla !== undefined) {
                 tabla.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar
               }
             } else {
               mensajemodal(data.Text, 'warning', data.titulo);
             }
             if (data.Tipo == 1 || data.Tipo == 2) {
               $pageContent.dialog('close');
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
  },// validacion de campos 
  inicializarObjetos: function () {
  },
  eventos: function () {
  
  tabla.on('click', 'a.Reporte', function (e) {
      $.Loading(true)
      Cookies.remove('reporte');
      Cookies.set('reporte', 'FALSE');
      var time = setInterval(function () {
        if (Cookies.get('reporte') == 'OK') {
          $.Loading(false)
          clearInterval(time);
          Cookies.remove('reporte');
        }
      }, 1000);
    });

  },
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




  $("#month").datepicker({
    dateFormat: 'dd/mm/yy', language: 'es', locale: 'es',
    onSelect: function (e, obj) {
      data.inicializarTabla(e);
    }
  }).datepicker("setDate", new Date())
  data.inicializarTabla($("#month").val());
  data.eventos();
});
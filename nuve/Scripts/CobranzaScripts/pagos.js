﻿//Inicializacion de variables
var tablaprincipal;
var btnConsulta = $('#btnConsultar');
var fecha = $('#fecInicio');

$.ajaxSetup({
  // Disable caching of AJAX responses For IE !!!
  cache: false
});

var pagoadeudos =
{
  inicializarTabla: function (dfecha) {

    tablaprincipal = $('#tablaprincipal')
        .DataTable({
          ajax: {
            "url": "../Cobranza/obtenerListapagosadeudos", // url del controlador a consultar 
            "Type": "GET",
            "data": function (d) { d.dfecha = dfecha }, // parametros a enviar al controlador 
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
                'excel', 'pdf', 'print' // permiten agregar botones para exportar a excel 
          ],
          paging: true, // permite la paginacion en la tabla .
          lengthMenu: [31], // Cantidad de registros mostrados por pantalla 
          searching: true, // genera cuadro de busqueda
          ordering: true, // genera ordenamiento de columnas 
          order: [[1, 'desc']], // ordena la primer columna
          responsive: true, // realiza la tabla responsiva en moviles
          destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
          columns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 
     { data: "fecha" },
     { data: "numrec", orderable: true },
     { data: "monedaStr" },
     { data: "Adeudo" },
     { data: "movto" },
     { data: "contrato", orderable: true },
     { data: "Nombre", orderable: true },
     { data: "concepto"},
     { data: "importe", render: $.fn.dataTable.render.number(',', '.', '2', ''), orderable: false, className: 'dt-body-right' },
     { data: "referencia",  className: 'dt-body-right' },
          ],
          "columnDefs": [
              { "className": "dt-body-center", "targets": [8] } // permite centrar botones de edicion 
          ]
        });


  }, //Funcion que inicializa la tabla 


  openPopUp: function (pageUrl) {
    var $pageContent = $('<div>');

    $pageContent.load(pageUrl, function () {

      $pageContent.dialog({
        width: 'auto', // overcomes width:'auto' and maxWidth bug
        height: 'auto',
        modal: true,
        show: 'fade',
        hide: 'fade',
        title: title == null ? "Baja de adeudo" : "Pago de adeudo",
        fluid: true, //new option
        resizable: true,
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

          $("#saldo").focusout(function () {
            if (parseFloat($("#saldo").val()) > parseFloat($("#SaldoAux").val())) {
              alert("El saldo no debe ser mayor ")
              //$("#saldo").addClass("input-validation-error");
              //$("#saldo-error").html("El monto no debe ser mayor al saldo.")
            }
          });

          // propiedades para el maximo y mino de anchura
          $(this).css("maxWidth", "1200px");
          $(this).css("minWidth", "400px");
        },
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
               mensajemodal(data.Text, 'success');
               if (data.Tipo == 2) {
                 tablaprincipal.ajax.reload(null, true); // False- permite quedarte en la misma pagina despues de actualizar
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

    //este codigo permite mostrar el mensaje personalizado para validacion .
    jQuery.validator.addMethod('valida', function (value, element, params) {
      if (parseFloat($("#saldo").val()) <= parseFloat($("#SaldoPago").val()))
      { return true }
      else {
        return false
      }
    }, '');

    jQuery.validator.unobtrusive.adapters.add('valida', function (options) {
      options.rules['valida'] = {};
      options.messages['valida'] = options.message;
    });


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
  } // validacion de campos 
}

$(document).ready(function (e) {

  fecha.datepicker({
    dateFormat: 'dd/mm/yy', language: 'es', locale: 'es',
    onSelect: function (e, obj) {
      pagoadeudos.inicializarTabla(e);
    }
  }).datepicker("setDate", "0");
  fecha.keydown(function () { return false })

  //fecha.focusout(function (e) {
  //  e.preventDefault();
  //  pagoadeudos.inicializarTabla(fecha.val());
  //});
  
  
 // pagoadeudos.validacionCampos();
  pagoadeudos.inicializarTabla(fecha.val()); // Realiza consulta al mes actual y año actual al carga la pagina pro primera vez 

  $("#tableContainer").on('click', 'a.popup',
      function (e) {
        e.preventDefault();
        title = $(this).attr("add") // set the title for popup
        pagoadeudos.openPopUp($(this).attr('href'));
      });

  $(window).resize(function () {
    pagoadeudos.fluidDialog();
  });

});
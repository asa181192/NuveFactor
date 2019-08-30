//Inicializacion de variables
var tablaprincipal;
var btnConsulta = $('#btnConsultar');
var fecha = $('#month');
var contrato = $('.contrato');

$.ajaxSetup({
  // Disable caching of AJAX responses For IE !!!
  cache: false
});


var formulario =
{
  inicializarTabla: function (fechaMes, fechaAnio, contrato) {
    tablaprincipal = $('#tablaprincipal')
        .DataTable({
          ajax: {
            "url": "../Cobranza/obtenerListaedocuenta", // url del controlador a consultar 
            "Type": "GET",
            "data": function (d) { d.fechaMes = fechaMes, d.fechaAnio = fechaAnio, d.contrato = contrato }, // parametros a enviar al controlador 
            "dataSrc": function (json) {
              if (typeof (json.Mensaje) != 'undefined') {
                //mensajemodal(json.Mensaje, 'warning');
                return {};
              } else {
                $("#nom").text(json.nombre)
                $("#cont").text(json.cont)
                $("#linea").text($.fn.dataTable.render.number(',', '.', 2, '$').display(json.lineacto))
                $("#monedastr").text(json.monedastr)
                $("#dispo").text($.fn.dataTable.render.number(',', '.', 2, '$').display(json.disponible))

                return json.Results;
              }
            }
          },
          initComplete: function (settings, json) {
            $.Loading(false);
          },
          dom: "Bfrtip",
          buttons: [
                //'Excel', 'PDF', 'Print', // permiten agregar botones para exportar a excel 
                                {
                  text: 'PDF', // Nuevo Botón personalizado en PDF 
                  title: 'Estado de cuenta ' ,
                  extend: 'pdfHtml5',
                  message: function() {
                    return 'CONTRATO (' + $(".contrato").val() + ') ' + $("#nom").text() + ' Línea ' + $("#linea").text() + ' ' + $("#monedastr").text()
                  } , 
                  orientation: 'portrait',
                  header:true,
                  exportOptions: {
                    columns: ':visible'
                  },
                  customize: function (doc) {
                        doc.content.splice( 1, 0, {
                        margin: [ 0, 0, 0, 12 ],
                        alignment: 'left',
                        width:80,
                        height:30,
                        image: 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAPAAAABVCAYAAAB3hGnPAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAAZdEVYdFNvZnR3YXJlAEFkb2JlIEltYWdlUmVhZHlxyWU8AAADJGlUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4gPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS4zLWMwMTEgNjYuMTQ1NjYxLCAyMDEyLzAyLzA2LTE0OjU2OjI3ICAgICAgICAiPiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPiA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtbG5zOnhtcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIiB4bWxuczpzdFJlZj0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL3NUeXBlL1Jlc291cmNlUmVmIyIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ1M2IChNYWNpbnRvc2gpIiB4bXBNTTpJbnN0YW5jZUlEPSJ4bXAuaWlkOjRDRjJEQUJFN0E3NTExRTU4RkI0OThBMjE1NEFCRTgxIiB4bXBNTTpEb2N1bWVudElEPSJ4bXAuZGlkOjRDRjJEQUJGN0E3NTExRTU4RkI0OThBMjE1NEFCRTgxIj4gPHhtcE1NOkRlcml2ZWRGcm9tIHN0UmVmOmluc3RhbmNlSUQ9InhtcC5paWQ6QzcxQzhCQ0Q3QTc0MTFFNThGQjQ5OEEyMTU0QUJFODEiIHN0UmVmOmRvY3VtZW50SUQ9InhtcC5kaWQ6QzcxQzhCQ0U3QTc0MTFFNThGQjQ5OEEyMTU0QUJFODEiLz4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4g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'
                      } );
                    doc.pageMargins = [10, 5, 10, 10]; //left,top,right,bottom
                    doc.defaultStyle.fontSize = 8;
                    doc.styles.tableHeader.fontSize = 10;
                    doc.styles.title.fontSize = 10;
                    doc.content[0].text = doc.content[0].text.trim();  // Remove spaces around page title

                    // Create a header object with 3 columns
                    //doc['header'] = (function () {
                    //  return {
                    //    columns: [
                    //              //This is left column
                    //        {

                    //          alignment: 'left',
                    //          image: 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAPAAAABVCAYAAAB3hGnPAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAAZdEVYdFNvZnR3YXJlAEFkb2JlIEltYWdlUmVhZHlxyWU8AAADJGlUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4gPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS4zLWMwMTEgNjYuMTQ1NjYxLCAyMDEyLzAyLzA2LTE0OjU2OjI3ICAgICAgICAiPiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPiA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtbG5zOnhtcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIiB4bWxuczpzdFJlZj0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL3NUeXBlL1Jlc291cmNlUmVmIyIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ1M2IChNYWNpbnRvc2gpIiB4bXBNTTpJbnN0YW5jZUlEPSJ4bXAuaWlkOjRDRjJEQUJFN0E3NTExRTU4RkI0OThBMjE1NEFCRTgxIiB4bXBNTTpEb2N1bWVudElEPSJ4bXAuZGlkOjRDRjJEQUJGN0E3NTExRTU4RkI0OThBMjE1NEFCRTgxIj4gPHhtcE1NOkRlcml2ZWRGcm9tIHN0UmVmOmluc3RhbmNlSUQ9InhtcC5paWQ6QzcxQzhCQ0Q3QTc0MTFFNThGQjQ5OEEyMTU0QUJFODEiIHN0UmVmOmRvY3VtZW50SUQ9InhtcC5kaWQ6QzcxQzhCQ0U3QTc0MTFFNThGQjQ5OEEyMTU0QUJFODEiLz4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4g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',
                    //          width: 80,
                    //          height: 30,
                    //          text: 'hgkasdygausdgasyudgasyudgasyudgasudgsa',
                    //          margin: [0,10]
                    //        },
                    //        //This is middle column(but still appears at left side)
                    //        //{

                    //        //  alignment: 'center',
                    //        //  image: 'Too large to include',
                    //        //  width: 50,
                    //        //  height: 50
                    //        //},
                    //        {
                    //          // This is the right column
                    //          alignment: 'center',
                    //          text: 'rotNo',//dynamic variable
                    //          fontSize: 12

                    //        }
                    //    ],
                    //    margin: [10, 0]
                    //  }
                    //});



                    // Create a footer
                    doc['footer'] = (function (page, pages) {
                      return {
                        columns: [
                            'Factoraje',
                            {
                              // This is the right column
                              alignment: 'right',
                              text: ['page ', { text: page.toString() }, ' of ', { text: pages.toString() }]
                            }
                        ],
                        margin: [10, 0]
                      }
                    });
                    // Styling the table: create style object
                    var objLayout = {};
                    // Horizontal line thickness
                    objLayout['hLineWidth'] = function (i) { return .5; };
                    // Vertikal line thickness
                    objLayout['vLineWidth'] = function (i) { return .5; };
                    // Horizontal line color
                    objLayout['hLineColor'] = function (i) { return '#aaa'; };
                    // Vertical line color
                    objLayout['vLineColor'] = function (i) { return '#aaa'; };
                    // Left padding of the cell
                    objLayout['paddingLeft'] = function (i) { return 4; };
                    // Right padding of the cell
                    objLayout['paddingRight'] = function (i) { return 4; };
                    // Inject the object in the document
                    doc.content[1].layout = objLayout;
                  }
                }

              ],
          paging: true, // permite la paginacion en la tabla .
          lengthMenu: [31], // Cantidad de registros mostrados por pantalla 
          searching: true, // genera cuadro de busqueda
          ordering: false, // genera ordenamiento de columnas 
          order: [[0, 'desc']], // ordena la primer columna
           responsive: true, // realiza la tabla responsiva en moviles
          destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
          columns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 
     { data: "fecha" },
     { data: "concepto" },
     { data: "ant_debe", render: $.fn.dataTable.render.number(',', '.', '2', ''), orderable: false, className: 'dt-body-right' },
     { data: "ant_haber", render: $.fn.dataTable.render.number(',', '.', '2', ''), orderable: false, className: 'dt-body-right' },
     { data: "ant_saldo", render: $.fn.dataTable.render.number(',', '.', '2', ''), orderable: false, className: 'dt-body-right' },
     { data: "car_debe", render: $.fn.dataTable.render.number(',', '.', '2', ''), orderable: false, className: 'dt-body-right' },
     { data: "car_haber", render: $.fn.dataTable.render.number(',', '.', '2', ''), orderable: false, className: 'dt-body-right' },
     { data: "car_saldo", render: $.fn.dataTable.render.number(',', '.', '2', ''), orderable: false, className: 'dt-body-right' },
          ],
          "columnDefs": [
              { "className": "dt-body-center", "targets": [7] } // permite centrar botones de edicion 
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
        title: title == null ? "Nuevo Registro" : "Actualizar registro",
        fluid: true, //new option
        resizable: false,
        create: function (event, ui) { //permite inicializar parametros o campos dentro de el popup creado

          //permite reiniciar el validado de informacion al despelgar una ventana modal
          var form = $("#popupForm").closest("form");
          form.removeData('validator');
          form.removeData('unobtrusiveValidation');
          $.validator.unobtrusive.parse(form);

          $('#contrato').mask('0000000', { reverse: true });
          
          // Validacion de tool tip 
          $pageContent.tooltip({
            items: ".input-validation-error",
            content: function () {
              return $("[data-valmsg-for='" + $(this).attr('id') + "']").text();
            }
          });

          formulario.validacionCampos();
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
               if (tablaprincipal !== undefined) {
                 tabla.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar
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

 
  fecha.MonthPicker({ Button: false });

  $("#month").keydown(function () {
    return false;
  });

  //$("#month").focusout(function (e) {
  //  e.preventDefault();
  //  var split = fecha.val().split(/\//g);
  //  var fechaMes = split[0];
  //  var fechaAnio = split[1];
  //  formulario.inicializarTabla(fechaMes, fechaAnio, contrato.val());
  //});

  var date = new Date();
  formulario.inicializarTabla(date.getMonth() + 1, date.getFullYear(), contrato.val()); // Realiza consulta al mes actual y año actual al carga la pagina pro primera vez 

  btnConsulta.click(function (e) {
    e.preventDefault();
    var split = fecha.val().split(/\//g);
    var fechaMes = split[0];
    var fechaAnio = split[1];
    formulario.inicializarTabla(fechaMes, fechaAnio, contrato.val());
  });


  $("#tableContainer").on('click', 'a.popup',
      function (e) {
        e.preventDefault();

        title = $(this).attr("add") // set the title for popup
        formulario.openPopUp($(this).attr('href'));
      });

  $(window).resize(function () {
    formulario.fluidDialog();
  });

 

});
﻿//Inicializacion de variables
var tablaFinanciero;
var btnConsulta = $('#btnConsultar');
var fecha = $('#fecha');
var title;
var html;
var ddlSerie = $('#serie').val();
var ivaBool = $('#ivaBool')
var a = /,/g //Regex para quitar comas de montos de moneda

$.ajaxSetup({
  // Disable caching of AJAX responses For IE !!!
  cache: false
});

var Fact =
{
  inicializarTabla: function (serie, fecha) {

    $.Loading(true);

    tablaFinanciero = $('#table')
        .DataTable({

          ajax: {
            "url": "../Facturacion/ConsultaFacturas", // url del controlador a consultar 
            "Type": "GET",
            "data": function (d) { d.serie = serie, d.fecha = fecha }, // parametros a enviar al controlador 
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

          ],
          paging: true, // permite la paginacion en la tabla .
          lengthMenu: [10], // Cantidad de registros mostrados por pantalla 
          searching: true, // genera cuadro de busqueda
          ordering: true, // genera ordenamiento de columnas 
          order: [[1, 'asc']], // ordena la primer columna
          responsive: true, // realiza la tabla responsiva en moviles
          destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
          columns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 

     {
       data: "idfiscalpf", "width": "auto", "render": function (data) {
         //return '<a class="popup"  ><button name="detail" type="button" class="detail"></button></a>';
         return '<img src="../Images/plus.png">'
       }, orderable: false
     },
     {
       data: "fecha", orderable: false, "render": function (value) {
         if (value === null) return "";

         //Formato de fechas
         var pattern = /Date\(([^)]+)\)/;
         var results = pattern.exec(value);
         var dt = new Date(parseFloat(results[1]))
         var valMonth = (dt.getMonth().toString().length > 1 ? "" : "0")

         mes = dt.getMonth() + 1
         var adMonth = (mes.toString().length > 1 ? "" : "0")

         var valDay = (dt.getDate().toString().length > 1 ? "" : "0")

         return valDay + (dt.getDate()) + "/" + adMonth + (dt.getMonth() + 1) + "/" + dt.getFullYear();

       }
     },
     { data: "idfiscalpf", orderable: true },
     { data: "ssat", orderable: false },
     { data: "sat", orderable: false },
     { data: "folio", orderable: false },
     { data: "sisfol", orderable: false },
     { data: "contrato", orderable: false },
     { data: "nombre", orderable: false },
     { data: "importe", render: $.fn.dataTable.render.number(',', '.', '2', '$'), orderable: false },
     { data: "cancel", orderable: false },
     { data: "generated", orderable: false },
     { data: "divisa", orderable: false },
     { data: "sustituir", orderable: false },
     { data: "distrib", orderable: false },
     {
       data: "emision", orderable: false, "render": function (value) {
         if (value === null) return "";

         //Formato de fechas
         var pattern = /Date\(([^)]+)\)/;
         var results = pattern.exec(value);
         var dt = new Date(parseFloat(results[1]))

         var valMonth = (dt.getMonth().toString().length > 1 ? "" : "0")

         mes = dt.getMonth() + 1
         var adMonth = (mes.toString().length > 1 ? "" : "0")

         var valDay = (dt.getDate().toString().length > 1 ? "" : "0")


         return valDay + (dt.getDate()) + "/" + adMonth + (dt.getMonth() + 1) + "/" + dt.getFullYear();
       }
     },
     {
       data: "sat", "width": "40px", "render": function (data) {
         return '<a class="archivo" href="../Facturacion/GetFileFactura?factura=BVM951002LX0_BF_' + data + '&tipo=1" target="_blank" style="cursor:pointer"><img src="../Images/pdf.png"></button></a>';
         //return '<a class="archivo" id=' + data + ' name="1"><img src="../Images/pdf.png"></button></a>';
       }, orderable: false, className: "dt-body-center"
     },
     {
       data: "sat", "width": "40px", "render": function (data) {
         return '<a class="archivo" href="../Facturacion/GetFileFactura?factura=BVM951002LX0_BF_' + data + '&tipo=2" target="_blank" style="cursor:pointer"><img src="../Images/xml.png"></button></a>';
         //return '<a class="archivo" id=' + data + ' name="2"><img src="../Images/xml.png"></button></a>';                   
       }, orderable: false, className: "dt-body-center"
     }

          ],
          "columnDefs": [

              { "width": "auto", "className": "dt-head-center dt-body-center  ", "targets": [1, 2, 3, 4, 5, 6, 7, 9, 10, 11, 12, 13, 14, 15, 16, 17] },
              { "width": "auto", "className": "dt-head-center dt-body-left", "targets": [8] },
              { "width": "auto", "className": "dt-head-center dt-body-center details ", "targets": [0] }
          ],
          buttons: [
              {
                extend: 'excelHtml5',
                title: $('#serie option:selected').text(),
                exportOptions: {
                  columns: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
                }
              }
          ]
        });

  }, //Funcion que inicializa la tabla 
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

          //Inicializa en 0 los importes
          $('#base').val(0)
          $('#iva').val(0)
          $('#importe').val(0)

          Fact.iva()
          //Fact.GetContrato()
          Fact.GetId()
          Fact.FormatoMoneda()

          $('#contrato').blur(function () { Fact.GetContrato() })

          $('#contrato').focus(function () { Fact.CleanContrato() })

          $('#id').blur(function () { Fact.GetId() })

          $('#identidad').change(function () { Fact.GetId() })

          $('#sisfol').blur(function () {
            if ($('#sisfol').val() > 0) {
              Fact.GetDocto()
            } else {
              $('#sisfol').focus()
            }
          })

          $('#serie2').change(function () {
            if ($().val() > 0) {
              Fact.GetDocto()
            } else {
              $('#sisfol').focus()
              return false
            }

          })

          //'Nueva Remisión'   
          $('#remark').val('RE')

          $('#serie2').css('pointer-events', 'none')

          $('input:radio[name=type]').on('click', function () {

            tipo = $(this).val()

            if (tipo == 'RE') {
              $('#tipo').attr('readonly', true)
              $("#tipo option:first").prop('selected', true)

              $('#tipo').css('pointer-events', 'none')

            } else {
              $('#tipo').attr('readonly', false)
              $('#tipo').css('pointer-events', 'auto')
            }

            $('#remark').val(tipo)

          })

          if ($('#rbMoratorio').length > 0) {
            $('#tipo').attr('readonly', true)
            $('#tipo').css('pointer-events', 'none')
          }

          $('#tipo').change(function () {

            //if (texto == 'Seguros') {
            Fact.calcSeguro()
            //}

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

         var total = $('#importe').val().replace(a, '')

         if (total > 0) {

           $('#importe').val(total)

           iva = $('#iva').val().replace(a, '')

           $('#iva').val(iva)

           var url = $('#popupForm')[0].action;
           $.ajax({
             type: "POST",
             url: url,
             data: $('#popupForm').serialize(),
             beforeSend: function () {
               $.Loading(true);
             },
             success: function (response) {

               if (response.Ok) {

                 if (response.process) {

                   mensajemodal(response.Mensaje, 'success', title)

                   Fact.inicializarTabla(ddlSerie, '01/' + fecha.val())

                   $pageContent.dialog('close');
                 } else {
                   mensajemodal(response.Mensaje, 'warning', title)
                 }

               } else {
                 mensajemodal(response.Mensaje, 'warning', title)
               }

             },
             error: function () {
               mensajemodal('Ocurrio un error al consultar la informacion favor de intentar de nuevo!!', 'warning');

             },
             complete: function () {
               $.Loading(false);
             },

           });

         } else {
           mensajemodal('El documento debe ser mayor a 0', 'warning', title)
         }

         e.preventDefault();
       });
  },
  calcSeguro: function () {
    texto = $('#tipo option:selected').text().trim()

    if (texto == 'Seguros') {
      $('#seguro').val($('#base').val().replace(a, ''))
      $('#ivaseguro').val($('#iva').val())
    } else {
      $('#seguro').val(0)
      $('#ivaseguro').val(0)
    }

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
  },
  obtenerFecha: function () {

    var d = new Date()
    var mes = d.getMonth()
    var anio = d.getFullYear()

    mes = parseFloat(mes) + 1

    mes = String(mes).length > 1 ? mes : '0' + mes
    return mes + '/' + anio


  },
  format: function (d) {

    data = { "sisfol": d.sisfol, "serie": ddlSerie }

    $.ajax({

      type: "GET",
      async: false,
      url: "../Facturacion/ConsultaDetalle",
      dataType: "JSON",
      contentType: "application/json",
      data: data,
      success: function (response) {

        html = "<table cellspacing='0' border='0' style='padding-left:50px;background-color:#E4EED5'>"

        if (response.Mensaje == "0") {

          html += "<tr>"
          html += "<td>Sin partidas adicionales</td>"
          html += "</tr>"

        } else {

          $.each(response, function () {

            $.each(this, function (index, name) {

              monto = $.fn.dataTable.render.number(',', '.', 2, '$').display(name.monto)

              html += "<tr>"
              html += "<td style='border:0px;'>&#9899 " + String(name.concepto) + "</td>"
              html += "<td style='width:100px;border:0px;' align='right'>" + String(monto) + "</td>"
              html += "</tr>"

            })
          })
        }
        html += "</table>"
      }
    })

    return html

  },
  GetContrato: function () {

    contrato = $('#contrato').val()

    data = { "contrato": contrato }

    if (contrato > 0) {

      $.ajax({
        url: '../Facturacion/GetContrato',
        contentType: 'application/json',
        type: 'GET',
        data: data,
        success: function (response) {

          if (response.Mensaje == "0") {
            $('#txtContrato').val(response.nombre)
            $('#id').val(response.cliente)
            $('#txtDeudorNombre').val(response.nombre)

          } else {
            mensajemodal(response.Mensaje, 'warning', 'Facturacion')
            $('#contrato').val('').focus()


          }
        }
      })
    } else {
      $('#contrato').focus()
    }
  },
  CleanContrato: function () {

    $('#txtContrato').val('')
    $('#contrato').val('')

  },
  GetId: function () {

    //$('#id').blur(function () {



    deudor = $('#id').val()
    id = $('#identidad').val()
    identidad = $('#identidad').text()

    if (deudor > 0) {

      data = {
        'deudor': deudor,
        'id': id,
        'identidad': identidad
      }

      $.ajax({
        url: '../Facturacion/GetId',
        contentType: 'application/json',
        data: data,
        type: 'GET',
        success: function (response) {

          if (response.Mensaje == "0") {
            if (response.nombre != null) {
              $('#txtDeudorNombre').val(response.nombre)
            } else {
              $('#id').val('').focus()
              $('#txtDeudorNombre').val('')
              mensajemodal('No se encontró el Id', 'warning', title)

            }

          } else {
            mensajemodal(response.Mensaje, 'warning', title)
          }
        },
        error: function () {
          $('#id').val('').focus()
          $('#txtDeudorNombre').val('')
          mensajemodal('Ajax(404)', 'warning', title)
        }
      })
    } else {
      $('#id').val('').focus()
    }
    //})



  },
  GetPorcentaje: function (Contrato) {
    var porc

    data = {
      'contrato': Contrato
    }

    $.ajax({
      url: "../Facturacion/GetPorcentaje",
      data: data,
      type: "GET",
      dataType: "JSON",
      async: false,
      success: function (response) {

        porc = response.porcentaje



      }
    })

    return porc

  },
  FormatoMoneda: function () {
    base = $('#base').val()
    iva = $('#iva').val()
    importe = $('#importe').val()

    $('#base').val($.fn.dataTable.render.number(',', '.', 2).display(base))
    $('#iva').val($.fn.dataTable.render.number(',', '.', 2).display(iva))
    $('#importe').val($.fn.dataTable.render.number(',', '.', 2).display(importe))


  },
  iva: function () {

    $('#base').blur(function () {
      base = $('#base').val().replace(a, '')

      $('#iva').val(0)
      $('#importe').val(base)
      $('#base').val(base)
      $('#ivaBool').removeAttr('checked')


      Fact.calcSeguro()
      Fact.FormatoMoneda()



    })

    $('#ivaBool').click(function () {

      base = $('#base').val().replace(a, '')
      iva = $('#iva').val().replace(a, '')
      importe = $('#importe').val().replace(a, '')


      if ($('#ivaBool').prop('checked')) {
        if (base > 0) {

          porcentaje = Fact.GetPorcentaje($('#contrato').val())

          iva = base * parseFloat(porcentaje * .01)
          $('#iva').val(iva.toFixed(2))

          $('#base').val(base)
          $('#importe').val(parseFloat(base) + parseFloat(iva))
        }
      } else {

        $('#base').val(base)
        $('#importe').val(parseFloat(importe) - parseFloat(iva))
        $('#iva').val(0)

      }
      Fact.calcSeguro()
      Fact.FormatoMoneda()
    })

  },
  GetDocto: function () {

    sisfol = $('#sisfol').val()
    serie = $('#serie2').val()

    if (sisfol > 0 || sisfol != '') {

      data = {
        'sisfol': sisfol,
        'serie': serie
      }

      $.ajax({
        url: '../Facturacion/ValidDoctos',
        data: data,
        contentType: 'application/json',
        type: 'GET',
        success: function (response) {

          if (response.Mensaje != "0") {

            mensajemodal(response.Mensaje, 'warning', title)

            $('#saldo').val('')
            $('#contrato').val('')
            $('#txtContrato').val('')
            $('#id').val('')
            $('#aplicarFactura').val('')
            $('#aplicarAdeudo').val('')
            $('#folio').val('')
            $('#txtDeudorNombre').val('')


            $('#sisfol').val('').focus()



          } else {


            //saldo = $('#saldo').val(response.saldo)
            $('#saldo').val($.fn.dataTable.render.number(',', '.', 2).display(response.saldo))

            $('#contrato').val(response.contrato)
            $('#aplicarFactura').val(response.aplicarFactura)
            $('#aplicarAdeudo').val(response.aplicarAdeudo)
            $('#folio').val(response.folio)

            Fact.GetContrato()
          }
        }
      })

    } else {
      $('#sisfol').focus()
    }
  }


}

$(document).ready(function (e) {

  //Esto nos permite Abrir modal dentro de modal . 
  $.fn.modal.Constructor.prototype.enforceFocus = function () { };

  Fact.validacionCampos()

  fecha.val(Fact.obtenerFecha())

  Fact.inicializarTabla(ddlSerie, '01/' + Fact.obtenerFecha())

  fecha.MonthPicker({ Button: false })

  $('#btnConsultar').click(function () {
    ddlSerie = $('#serie').val()
    Fact.inicializarTabla(ddlSerie, '01/' + fecha.val())

  })

  fecha.keydown(function () {
    return false
  })

  $('#tableContainer').on('click', 'td.details', function (e) {

    e.preventDefault()

    var tr = $(this).closest('tr');
    var row = tablaFinanciero.row(tr);

    if (row.child.isShown()) {
      // This row is already open - close it
      row.child.hide();
      tr.removeClass('shown');
    }
    else {
      // Open this row            
      row.child(Fact.format(row.data())).show();
      tr.addClass('shown');
    }
  })

  $('#tableContainer').on('click', 'a.popup', function (e) {

    e.preventDefault()

    var result = $(this).attr('href') + '?tipo=' + $('#serie').val()

    serie = $('#serie').val()

    if (serie == 'C') {
    } else {
      switch (serie) {
        case 'A':
          title = "Nueva Factura"
          break;
        case 'B':
          title = "Nueva Nota de crédito"
          break;
        case 'C':
          title = "Nueva Nota de cargo"
          break;
        case 'D':
          title = "Nueva Remisión"
          break;
      }

      Fact.openPopUp(result, title)
    }
  })

 
  $('#serie').change(function () {

    if ($('#serie').val() == 'C') {
      $('#btnNueva').attr('disabled', true)
    } else {
      $('#btnNueva').attr('disabled', false)
    }

    ddlSerie = $('#serie').val()
    Fact.inicializarTabla(ddlSerie, '01/' + fecha.val())


  })

  $('#fecha1').datepicker({}).datepicker("setDate", "0")

  $('#btnGenerar').click(function (e) {
    e.preventDefault()

    $.Loading(true);

    data = {
      'fecha': $('#fecha1').val()
    }

    
    $.ajax({
      url: '../Facturacion/Generar',
      data: JSON.stringify(data),
      dataType: "JSON",
      type: "POST",
      contentType: "application/json;",
      success: function (response) {

        console.log(response.process)

        if (response.process == "1") {
          mensajemodal(response.Mensaje, 'success', 'Generación de Log')
        } else {
          mensajemodal(response.Mensaje, 'warning', 'Generación de Log')
        }

        $.Loading(false);
      },
      error: function () {
        $.Loading(false);
      }
    })
  })
});
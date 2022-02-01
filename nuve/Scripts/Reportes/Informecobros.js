﻿var fecha = $('#sfecha');
var rval  = '1'
var repo  = '1'

var informe = {

  controles: function (a) {

    if ($(a).val() == '1') {

      rval = '1'
      $('#contrato').val('0')
      $('#contrato').attr('readonly', true)
 
    } else {
      //$('#contrato').val('0')
      rval = '2'
      $('#contrato').attr('readonly', false)

    }
  },
  reportes: function (a) {

    if ($(a).val() == '1') {
      repo = '1'
    } else {
      //$('#contrato').val('0')
      repo = '2'
    }
  },
  loadGif: function () {
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
  },
  consultacontrato: function () {

    var contrato = { "contrato": $('#contrato').val() };

    if ($('#contrato').val() > 0) {
      $.ajax({
        type: 'GET',
        datatype: "JSON",
        contentType: "application/json; charset=utf-8",
        url: '../Tesoreria/consultaContrato',
        data: contrato,
        success: function (response) {

          if (response.nombre) {
            $('#nombre').val(response.nombre)
          } else {

            mensajemodal(response.Mensaje, 'warning')
            $('#contrato').val(0)
          }
        },
        error: function () {
          mensajemodal('Ocurrio un error al consultar el contrato, intente nuevamente.', 'warning')
        }

      })
    }

  }


}





$(document).ready(function (e) {

  informe.controles($('input:radio[name="info"]'));

  //$.fn.modal.Constructor.prototype.enforceFocus = function () { };
  $('#nombre').attr('readonly', true)
  //formulario.inicializacionControles();
  $("#sfecha").datepicker({
    dateFormat: 'dd/mm/yy', language: 'es', locale: 'es'
  }).datepicker("setDate", new Date())
  
   
  $('input:radio[name="info"]').change(function () {
    informe.controles( $(this)  );
  });
    
  //$('input:radio[name="reporte"]').change(function () {
  //  informe.reportes($(this));
  //});


  $("#contrato").change(function (e) {
    e.preventDefault();
    informe.consultacontrato( $("#contrato").val()); // Realiza consulta al mes actual y año actual al carga la pagina pro primera vez       
  });


  $('#descargar').click(function (e) {

  
    if ( $("input:radio[name='info']:checked").val() == "2" && $("#contrato").val() == "0" ) {
      mensajemodal('Es necesario capturar contrato', 'warning', 'Advertencia')
      return false
    } else {

      
      informe.loadGif()

      if ( $("input:radio[name='reporte']:checked").val() == "1" ) {
        url = $("#descargar").attr("href", '../Reportes/Reportecobranza?fecha=' + $("#sfecha").val() + '&contrato=' + $("#contrato").val())
      } else {

        url = $("#descargar").attr("href", '../Reportes/Reporteaforo?fecha=' + $("#sfecha").val() + '&contrato=' + $("#contrato").val())
      }

      ////url = '../Informes/Informecobros?fecha=' + $("#sfecha").val() + '&contrato=' + $("#contrato").val()
      //url = "..Informes/Informecobros?fecha='" + $("#sfecha").val() + "'&contrato=" + $("#contrato").val()
      //url = $("#descargar").attr("href", '../Informes/Reportecobranza?fecha=' + $("#sfecha").val() + '&contrato=' + $("#contrato").val())
      

      //url = $('#descargar').attr('href')
 //     alert(url)
      return url
    }
  }).submit()




});
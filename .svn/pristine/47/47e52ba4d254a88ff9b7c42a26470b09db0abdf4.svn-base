var rval = '1';
var repo = '1';
var moneda = $('#divisa option:selected').val();
var url = '';
var tipo = 'PDF';

var informe = {

  controles: function (a) {

    if ($(a).val() == '1') {

      rval = '1'
      //$('#contrato').val('0')
      //$('#contrato').attr('readonly', true)
      //$('#divisa').attr('readonly', false)

    } else {
      //$('#contrato').val('0')
      rval = '2'
      //$('#contrato').attr('readonly', false)
      //$('#divisa').attr('readonly', true)
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

  //informe.controles($('input:radio[name="info"]'));

  //$('#nombre').attr('readonly', true)
 
  //$('input:radio[name="info"]').change(function () {
  //  informe.controles($(this));
  //});



  //$("#contrato").change(function (e) {
  //  e.preventDefault();
  //  informe.consultacontrato($("#contrato").val()); // Realiza consulta al mes actual y año actual al carga la pagina pro primera vez       
  //});


  $('#pdf').click(function (e) {


    if ($("input:radio[name='info']:checked").val() == "2" && $("#contrato").val() == "0") {
      mensajemodal('Es necesario capturar contrato', 'warning', 'Advertencia')
      return false
    } else {

      moneda = $('#divisa option:selected').val();
      tipo = 'PDF'
      informe.loadGif()

      url = $("#pdf").attr("href", '../Reportes/Reporteadeudos?moneda=' + moneda + '&tipo=' + tipo)

      //if ($("input:radio[name='info']:checked").val() == "1") {
      //  url = $("#pdf").attr("href", '../Reportes/Reporteadeudos?moneda=' + moneda + '&tipo=' + tipo)
      //} else {

      //  url = $("#pdf").attr("href", '../Reportes/Reporteadeudos?moneda=0' + '&tipo=' + tipo )
      //}
      return url
    }
  }).submit()

  $('#xls').click(function (e) {


    if ($("input:radio[name='info']:checked").val() == "2" && $("#contrato").val() == "0") {
      mensajemodal('Es necesario capturar contrato', 'warning', 'Advertencia')
      return false
    } else {


      informe.loadGif()
      moneda = $('#divisa option:selected').val();
      tipo = 'XLS' 

      url = $("#xls").attr("href", '../Reportes/Reporteadeudos?moneda=' + moneda + '&tipo=' + tipo)

      //if ($("input:radio[name='info']:checked").val() == "1") {
      //  url = $("#xls").attr("href", '../Reportes/Reporteadeudos?moneda=' + moneda + '&tipo=' + tipo  )
      //} else {

      //  url = $("#xls").attr("href", '../Reportes/Reporteadeudos?contrato=' + $("#contrato").val() + '&moneda=0' + '&tipo='  & tipo )
      //}

      
      return url
    }
  }).submit()



});
var fecha = $('#month');


$(document).ready(function (e) {
  
  fecha.MonthPicker({ Button: false });

  $("#month").keydown(function () {
    return false;
  });

  
  $('#descargar').click(function (e) {

    fec = fecha.val()

    if (fec == '') {

      $.alert({
        title: 'Mensaje',
        type: 'red',
        content: 'Es necesario seleccionar Mes y año',
        animateFromElement: false
      });

      //mensajemodal('Es necesario seleccionar Mes y año', 'warning', 'Advertencia')
    }
    else {

      var split = fecha.val().split(/\//g);
      var fechaMes = split[0];
      var fechaAnio = split[1];
      
      url = $('#descargar').attr('href', '../Reportes/ObtenerRebatemensual?mes=' + fechaMes + '&anio=' + fechaAnio)
      return url
    }
    ////inicio = $('#contrato').val()
    ////console.log(inicio + ',' + fin)

    ////if (tipo != 'GLOBAL' && (inicio == '' || fin == '')) {
    ////  mensajemodal('Es necesario capturar un contrato', 'warning', 'Advertencia')
    ////  return false
    ////} else {
    ////  NAF.loadGif()
    ////  url = $('#descargar').attr('href', '../Reportes/Rebatemensual?fecha=' + $("#global").is(":checked") + '&contrato=' + $('#contrato').val())
    ////  console.log(url)
    ////  return url
    //}
  }).submit()


  //var date = new Date();
  //formulario.inicializarTabla(date.getMonth() + 1, date.getFullYear(), contrato.val()); // Realiza consulta al mes actual y año actual al carga la pagina pro primera vez 

  //btnConsulta.click(function (e) {
  //  e.preventDefault();
  //  var split = fecha.val().split(/\//g);
  //  var fechaMes = split[0];
  //  var fechaAnio = split[1];
  //  formulario.inicializarTabla(fechaMes, fechaAnio, contrato.val());
  //});


  //$("#tableContainer").on('click', 'a.popup',
  //    function (e) {
  //      e.preventDefault();

  //      title = $(this).attr("add") // set the title for popup
  //      formulario.openPopUp($(this).attr('href'));
  //    });

  $(window).resize(function () {
    formulario.fluidDialog();
  });



});
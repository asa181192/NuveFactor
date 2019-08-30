var tipo = 'GLOBAL';
var inicio;
var fin;
var moneda = $('#divisa option:selected').val();


var NAF = {
    activarRango: function (a) {

        if ($(a).val() == 'GLOBAL') {

            tipo = 'GLOBAL'

            $('#FechaInicio').val('')
            $('#FechaInicio').attr('readonly', true)
            $('#FechaInicio').datepicker('destroy')

            $('#FechaFin').val('')
            $('#FechaFin').attr('readonly', true)
            $('#FechaFin').datepicker('destroy')

        } else {
            tipo = ''            
            $('#FechaInicio').datepicker({ dateFormat: 'dd/mm/yy' }).attr('readonly', false)
            $('#FechaFin').datepicker({ dateFormat: 'dd/mm/yy' }).attr('readonly', false)

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
    }
}

$(document).ready(function () {

    $(':radio').click(function () {
        NAF.activarRango($(this))
        console.log(tipo)
    })

    $('#descargar').click(function (e) {
        
        inicio = $('#FechaInicio').val()
        fin = $('#FechaFin').val()

        console.log(inicio + ',' + fin)

        if (tipo != 'GLOBAL' && (inicio == '' || fin == '')) {
            mensajemodal('Es necesario capturar fecha de inicio y fecha de fin.', 'warning', 'Advertencia')
            return false
        } else {
            NAF.loadGif()
            url = $('#descargar').attr('href', '../Reportes/ReporteVencimientosNAFIN?moneda=' + moneda + '&tipo=' + tipo + '&inicio1=' + inicio + '&fin1=' + fin)
            console.log(url)
            return url
        }        
    }).submit()

})
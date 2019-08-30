var tipo = 'GLOBAL';
var inicio;
var fin;



var NAF = {
    activarRango: function (a) {

        if ($(a).val() == 'GLOBAL') {

            tipo = 'GLOBAL'

            $('#contrato').val('')
            $('#contrato').attr('readonly', true)

            $('#nombre').val('')

        } else {
            tipo = ''
            $('#contrato').attr('readonly', false)
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

    $("#contrato").focusout(function () {
        $.ajax({
            type: "GET",
            url: "../Reportes/Obtenercliente",
            data: { contrato: $(this).val() },          
            success: function (data) {
                if (data.result) {
                    $("#nombre").val(data.reporte.nombre)
                   
                }
                else {
                    $("#nombre").val('')
                }
            },
            error: function () {
               
            }
        });
    })




    $('#descargar').click(function (e) {  
        inicio = $('#contrato').val()
        console.log(inicio + ',' + fin)

        if (tipo != 'GLOBAL' && (inicio == '' || fin == '')) {
            mensajemodal('Es necesario capturar un contrato', 'warning', 'Advertencia')
            return false
        } else {
            NAF.loadGif()
            url = $('#descargar').attr('href', '../Reportes/ReporteDocPorDescontar?opcion=' + $("#global").is(":checked") + '&contrato=' + $('#contrato').val())
            console.log(url)
            return url
        }
    }).submit()

})
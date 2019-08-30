


var data = {
    consulta: function (url,tipo,data) {
        $.ajax({
            method: tipo,
            url:url,
            data: data,
            beforeSend: function () {
                $.Loading(true);
            },
            success: function (data) {
                if (data.result) {
                    if (data.detalle != null) {

                        var notas = ""; 

                        $("#contrato").val(data.detalle.contrato)
                        $("#nombre").val(data.detalle.nombre)
                        $("#fec_alta").val(data.detalle.fec_alta)
                        $("#importe").val(data.detalle.monto)
                        $("#saldo").val(data.detalle.saldo)

                        data.detalle.pagos.forEach(function (e) { notas  +=  "Fecha : "+e.fecha + ' Importe: $' + e.importe + ' Concepto : ' + e.concepto +"\n" })
                        $("#notas").val(notas)
                       
                     
                    }
                    else {
                        $("#contrato").val("")
                        $("#nombre").val("")
                        $("#fec_alta").val("")
                        $("#importe").val("")
                        $("#saldo").val("")
                        $("#notas").val("No hay pagos registrados")
                    }
                    }                  
            }
        }).done(function (msg) {
            $.Loading(false);
        });
    }
}

$(document).ready(function () {

    $(".consulta").click(function (e) {
        e.preventDefault();
        var values = {serie : $("#serie").val(),docto : $("#docto").val()} 
        data.consulta($(this).attr("href"), "GET", values)
    })
})
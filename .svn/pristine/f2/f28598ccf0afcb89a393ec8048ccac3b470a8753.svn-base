String.prototype.toShortFormat = function (date) {

    var month_names = ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"]

    var dateParts = date.split("/");
    var day = dateParts[0];
    var month = dateParts[1];
    var year = dateParts[2];

    return "" + day + "-" + month_names[parseInt(month - 1)] + "-" + year;
}


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
                        $("#fec_alta").val(String.prototype.toShortFormat(data.detalle.fec_alta))
                        $("#importe").val($.fn.dataTable.render.number(',', '.', 2, '$').display(data.detalle.monto))
                        $("#saldo").val($.fn.dataTable.render.number(',', '.', 2, '$').display(data.detalle.saldo))

                        data.detalle.pagos.forEach(function (e) { notas  +=  "Fecha : "+e.fecha + ' Importe: $' + $.fn.dataTable.render.number(',', '.', 2, '$').display(e.importe) + ' Concepto : ' + e.concepto +"\n" })
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

String.prototype.toShortFormat = function (date) {

    var month_names = ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"]

    var dateParts = date.split("/");
    var day = dateParts[0];
    var month = dateParts[1];
    var year = dateParts[2];

    return "" + day + "-" + month_names[parseInt(month-1)] + "-" + year;
}



var data = {
    consulta: function (url, tipo, data) {
        $.ajax({
            method: tipo,
            url: url,
            data: data,
            beforeSend: function () {
                $.Loading(true);
            },
            success: function (data) {

                $("#nombreCliente").val("")
                $("#producto").val("")
                $("#divisa").val("")
                $("#docto").val("")
                $("#cesion").val("")
                $("#Tasaoper").val("")
                $("#fec_alta").val("")
                $("#porcanti").val("")
                $("#fec_vence").val("")
                $("#importe").val("")
                $("#fecvencedocto").val("")
                $("#saldo").val("")

                if (data.resp) {

                    if (data.docto != null) {
                        if (data.docto.nombrecliente != null) {
                            var notas = "";
                            $("#nombreCliente").val(data.docto.nombrecliente)
                            $("#producto").val(data.docto.producto)
                            $("#divisa").val(data.docto.divisa)
                            $("#docto").val(data.docto.nombreproveedor)
                            $("#cesion").val(data.docto.idcesion)
                            $("#Tasaoper").val(data.docto.tasa)
                            $("#fec_alta").val(data.docto.altacesion)
                            $("#porcanti").val(data.docto.porc_anti)
                            $("#fec_vence").val(String.prototype.toShortFormat(data.docto.fechavencecesion))
                            $("#importe").val($.fn.dataTable.render.number(',', '.', 2, '$').display(data.docto.importe))
                            $("#fecvencedocto").val(data.docto.fechaVencedocto)
                            $("#saldo").val($.fn.dataTable.render.number(',', '.', 2, '$').display(data.docto.saldo))

                            data.docto.historiapagos.forEach(function (e) { notas += "Fecha : " + e.fecha + '      Importe:' + $.fn.dataTable.render.number(',', '.', 2, '$').display(e.monto) + "\n" })
                            $("#pagos").val(notas)
                        }

                    }

                    if (data.lista.length > 0) {
                        $(".proveedor").attr("hidden", false);

                        $.each(data.lista, function (i, obj) {
                            var div_data = "<option value=" + data.lista[i].Value + ">" + data.lista[i].Text + "</option>";
                            $(div_data).appendTo('#proveedor');
                        });
                    }
                    else {
                        $(".proveedor").attr("hidden", true);
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
        var values = { contrato: $("#contrato").val(), documento: $("#nombreDocumento").val() }
        data.consulta($(this).attr("href"), "GET", values)
    })

    $("#proveedor").change(function (e) {
        var values = { contrato: $("#contrato").val(), documento: $("#nombreDocumento").val(), deudor: $("#proveedor").val() }
        data.consulta("../Reportes/consultarContratoDocumento/", "GET", values)
    })

})
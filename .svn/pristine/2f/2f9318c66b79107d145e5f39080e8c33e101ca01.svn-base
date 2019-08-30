@Code
    ViewData("Title") = "ReporteSaldos"
End Code

<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.5.3/jspdf.debug.js"></script>

<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="~/Tesoreria/index">
                <img src="~/Images/menu/menuregresar.png" />
            </a>
            <span>Reporte de Saldos</span>
        </div>
    </div>
</div>

<div class="form-inline text-center" style="margin: 50px auto">
    <div class="form-group">
        <label>Contrato</label>
        <input type="text" class="form-control" id="contrato" style="width:100px">
        <input type="text" class="form-control" id="nombre"  style="width:400px">
    </div>
</div>

<div class="form-inline text-center" style="margin: 0px 0px 30px 0px">
    <div class="form-group">
        <label>Ultimos 12 meses</label>
        <label class="rdButtton">
            <input type="radio" id="all" name="rango" value="0"
                >
            <span class="radiomark"></span>
        </label>
    </div>
    <div class="form-group">
        <label>Año</label>
        <label class="rdButtton">
            <input type="radio" id="anio" name="rango" value="1" checked>
            <span class="radiomark"></span>
        </label>
        <select class="form-control dropdown" id="lista">
        </select>
    </div>
    <button type="submit" class="btn material-btn main-container__column">Graficar</button>
    <button  class="btn material-btn main-container__column save" >Generar PDF</button>
</div>

<div id="curve_chart" style="width: 1500px; height: 500px; margin: 50px auto"></div>

<script type="text/javascript">

    var chart = null;
    var producto;
    var moneda;
    var linea;
    var fec_vence;

    $(document).ready(function () {
        for (var i = (new Date()).getFullYear() - 4 ; i <= (new Date()).getFullYear() ; i++) {
            $("#lista").append(new Option(i, i));
        }

        $("input[name='rango']").click(function (e) {
            if ($(this).val() == "1") {
                $('#lista').prop('disabled', false);
            }
            else {
                $('#lista').prop('disabled', true);
                $('#lista').val("0")
            }
        })

        $(".save").on('click', function (e) {
            var doc = new jsPDF({
                orientation: 'landscape',
            });
            var width = doc.internal.pageSize.getWidth();
            var height = doc.internal.pageSize.getHeight();
            doc.addImage(chart.getImageURI(), 'JPEG', 0 , 40, width, height - 100);
            doc.save('chart.pdf');
        });

        $("#contrato").focusout(function (e) {
            $.ajax({
                type: 'GET',
                dataType: 'json',
                contentType: 'application/json',
                url: '../Reportes/Obtenercliente',
                data: { contrato: $("#contrato").val()},
                success: function (json) {

                    if (json.result) {
                        $("#nombre").val(json.reporte.nombre)
                        linea = json.reporte.linea
                        moneda = json.reporte.moneda
                        producto = json.reporte.producto
                        fec_vence = json.reporte.fec_vence
                    }
                    else {
                        alert("Contrato no existe")
                    }
                   
                },
                error: function () {
                    alert("Error loading data! Please try again.");
                }
            });
        });
    });


    google.charts.load('current', { 'packages': ['corechart'] }).then(function (e) {
        $(".btn").on('click', function () {
            $.ajax({
                type: 'GET',
                dataType: 'json',
                contentType: 'application/json',
                url: '../Reportes/obtenerSaldos',
                data: { contrato: $("#contrato").val(), anio: $("#lista").val() },
                success: function (response) {


                    var data = new google.visualization.DataTable();

                    data.addColumn('string', 'mes');
                    data.addColumn('number', 'saldo');
                    data.addColumn('number', 'promedio');

                    for (var i = 0; i < response.Results.length; i++) {
                        data.addRow([response.Results[i].mes, response.Results[i].saldo, response.Results[i].promedio]);
                    }

                    var options = {
                        title: "[" + $("#contrato").val() + "] " + $("#nombre").val() + " Línea: " + $.fn.dataTable.render.number(',', '.', 2, '').display(linea) + " " + moneda + " Vence: " + fec_vence + " " + producto,
                        animation: {
                            duration: 1500,
                            startup: true,
                            easing: 'out'//This is the new option,

                        },
                        series: {
                            0: { color: '#5cc9f3' },
                            1: { color: '#0d904f' },
                        }
                    };

                    chart = new google.visualization.LineChart(document.getElementById('curve_chart'));

                    chart.draw(data, options);

                },
                error: function () {
                    alert("Error loading data! Please try again.");
                }
            });
        });
    }
);
</script>

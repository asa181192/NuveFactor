@code
    Layout = Nothing
End Code
<p style="text-align:center">Montos en moneda nacional</p>
<div id="piechartCarteraPOP" style="height: 99%"></div>

<script>

    var meses = ["Enero", "Febrero", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Nomviembre", "Diciembre"]

    google.charts.load('current', { 'packages': ['corechart'] }).then(function (e) {
        $.ajax({
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json',
            url: '../Reportes/consultaCartera',
            success: function (response) {

                var data = new google.visualization.DataTable();

                data.addColumn('string', 'tipo');
                data.addColumn('number', 'saldo');

                for (var i = 0; i < response.Results.length; i++) {
                    data.addRow(
                        [
                            response.Results[i].tipo,
                            response.Results[i].saldo
                        ]);
                }


                var options = {
                    title: "Distribución de cartera al momento",
                    slices: {
                        0: { color: '#C4D600' },
                        1: { color: '#3BB0C9' },
                        2: { color: '#343E48' },
                    }
                };

                chart = new google.visualization.PieChart(document.getElementById('piechartCarteraPOP'));

                chart.draw(data, options);

            },
            error: function () {
                alert("Error loading data! Please try again.");
            }
        });
    }
);
</script>

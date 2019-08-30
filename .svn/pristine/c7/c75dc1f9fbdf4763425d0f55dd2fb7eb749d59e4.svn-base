@code
    Layout = Nothing
End Code

<p style="text-align:center">Montos en moneda nacional</p>
<div id="combocharPop" style="height: 99%"></div>
<script>

    var meses = ["Enero", "Febrero", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Nomviembre", "Diciembre"]
    google.charts.load('current', { 'packages': ['corechart'] }).then(function (e) {
        $.ajax({
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json',
            url: '../Reportes/consultaColoCbrnza',
            beforeSend: function () {
                $("#combocharPop").html('<div class="lds-ring" style="top:35%"><div></div><div></div><div></div><div></div></div>');
            },
            success: function (response) {

                var data = new google.visualization.DataTable();

                data.addColumn('string', 'Fecha');
                data.addColumn('number', 'Colcacion');
                data.addColumn('number', 'Cobranza');

                for (var i = 0; i < response.Results.length; i++) {
                    data.addRows([
                        [response.Results[i].fecha.substr(0,2), response.Results[i].coloca, response.Results[i].cobra
                        ]
                    ]);
                }

                var options = {
                    title: "Colocacion vs Cobranza, " + meses[new Date().getMonth() - 1] + " " + new Date().getFullYear(),
                    animation: {
                        duration: 1500,
                        startup: true,
                        easing: 'out'//This is the new option,

                    },
                    seriesType: 'bars',
                    series: {
                        0: { color: '#C4D600' },
                        1: { color: '#3BB0C9' },
                        2: { color: '#343E48' },
                        3: { color: '#43459d' },
                    }
                };

                chart = new google.visualization.ComboChart(document.getElementById('combocharPop'));

                chart.draw(data, options);

            },
            error: function () {
                alert("Error loading data! Please try again.");
            }
        });
    }
      );
</script>

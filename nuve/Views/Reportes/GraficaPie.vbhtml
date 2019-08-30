
@code
    Layout = Nothing
End Code
<p style="text-align:center">Montos en moneda nacional</p>
  <div id="piechartPOP" style="height: 99%" ></div>

  <script>
      var meses = ["Enero", "Febrero", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Nomviembre", "Diciembre"]

      google.charts.load('current', { 'packages': ['corechart'] }).then(function (e) {
          $.ajax({
              type: 'GET',
              dataType: 'json',
              contentType: 'application/json',
              url: '../Reportes/ConsultaOperaciones',
              data: { tipo: 1 },
              success: function (response) {

                  var data = new google.visualization.DataTable();

                  data.addColumn('string', 'descrip');
                  data.addColumn('number', 'Importe');

                  for (var i = 0; i < response.Results.length; i++) {
                      data.addRow(
                          [
                              response.Results[i].descrip,
                              response.Results[i].importe
                          ]);
                  }


                  var options = {
                      title: "Operación mensual por producto, " + meses[new Date().getMonth() - 1] + " " + new Date().getFullYear(),
                      slices: {
                          0: { color: '#C4D600' },
                          1: { color: '#3BB0C9' },
                          2: { color: '#343E48' },
                      }
                  };

                  chart = new google.visualization.PieChart(document.getElementById('piechartPOP'));

                  chart.draw(data, options);

              },
              error: function () {
                  alert("Error loading data! Please try again.");
              }
          });
      }
);
  </script>
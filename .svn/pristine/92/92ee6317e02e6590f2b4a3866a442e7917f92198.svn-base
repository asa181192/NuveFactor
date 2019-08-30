
@code
    Layout = Nothing
End Code
<p style="text-align:center">Montos en moneda nacional</p>
  <div id="curve_chartPOP" style="height: 99%"></div>

  <script>

      var meses = ["Enero", "Febrero", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Nomviembre", "Diciembre"]

      google.charts.load('current', { 'packages': ['corechart'] }).then(function (e) {
          $.ajax({
              type: 'GET',
              dataType: 'json',
              contentType: 'application/json',
              url: '../Reportes/ConsultaOperaciones',
              data: { tipo: 2 },
              success: function (response) {

                  var data = new google.visualization.DataTable();

                  var PEN = response.Results.filter(function (x) { return x.producto === 13 })
                  var PEF = response.Results.filter(function (x) { return x.producto === 17 })
                  var FCR = response.Results.filter(function (x) { return x.producto === 1 })
                  var FPE = response.Results.filter(function (x) { return x.producto === 11 })
                  console.log(PEN)

                  data.addColumn('string', 'fecha');
                  data.addColumn('number', 'PAGO ELECTRONICO NAFIN');
                  data.addColumn({ type: 'string', role: 'tooltip' });
                  data.addColumn('number', 'PAGO ELECTRONICO FIRA');
                  data.addColumn({ type: 'string', role: 'tooltip' });
                  data.addColumn('number', 'FACTORAJE CON RECURSO');
                  data.addColumn({ type: 'string', role: 'tooltip' });
                  data.addColumn('number', 'FACTORAJE A PROVEEDORES ELECTRONICO');
                  data.addColumn({ type: 'string', role: 'tooltip' });

                  for (var i = 0; i < PEN.length; i++) {
                      data.addRows([
                          [PEN[i].fecha.substr(0, 2),
                                PEN[i].importe, PEN[i].fecha + " Importe: " + $.fn.dataTable.render.number(',', '.', 2, '').display(PEN[i].importe) + " Operaciones: " + PEN[i].oper
                              , PEF[i].importe, PEF[i].fecha + " Importe: " + $.fn.dataTable.render.number(',', '.', 2, '').display(PEF[i].importe) + " Operaciones: " + PEF[i].oper
                              , FCR[i].importe, FCR[i].fecha + " Importe: " + $.fn.dataTable.render.number(',', '.', 2, '').display(FCR[i].importe) + " Operaciones: " + FCR[i].oper
                              , FPE[i].importe, FPE[i].fecha + " Importe: " + $.fn.dataTable.render.number(',', '.', 2, '').display(FPE[i].importe) + " Operaciones: " + FPE[i].oper
                          ]
                      ]);
                  }

                  var options = {
                      title: "Operaciones diarias por producto, " + meses[new Date().getMonth() - 1] + " " + new Date().getFullYear(),
                      animation: {
                          duration: 1500,
                          startup: true,
                          easing: 'out'//This is the new option,

                      },
                      series: {
                          0: { color: '#C4D600' },
                          1: { color: '#3BB0C9' },
                          2: { color: '#343E48' },
                          3: { color: '#43459d' },
                      }
                  };

                  chart = new google.visualization.LineChart(document.getElementById('curve_chartPOP'));

                  chart.draw(data, options);

              },
              error: function () {
                  alert("Error loading data! Please try again.");
              }
          });
      }
 );
  </script>
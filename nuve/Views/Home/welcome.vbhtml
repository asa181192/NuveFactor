﻿@ModelType nuve.Helpers.Menu


@section Scripts
    <script src="~/Scripts/HomeScripts/welcome.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>

End Section

<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>


<script type="text/javascript">

    var meses = ["Enero","Febrero", "Abril" , "Mayo" , "Junio" , "Julio" , "Agosto" , "Septiembre" , "Nomviembre" , "Diciembre" ]

    google.charts.load('current', { 'packages': ['corechart'] }).then(function (e) {
        $.ajax({
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json',
            url: '../Reportes/ConsultaOperaciones',
            beforeSend: function () {
                $("#curve_chart").html('<div class="lds-ring" style="top:35%"><div></div><div></div><div></div><div></div></div>');
            },
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

                chart = new google.visualization.LineChart(document.getElementById('curve_chart'));

                chart.draw(data, options);

            },
            error: function () {
                alert("Error loading data! Please try again.");
            }
        });
    }
    );

    google.charts.load('current', { 'packages': ['corechart'] }).then(function (e) {
        $.ajax({
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json',
            url: '../Reportes/ConsultaOperaciones',
            beforeSend: function () {
                $("#piechart").html('<div class="lds-ring" style="top:35%"><div></div><div></div><div></div><div></div></div>');
            },
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

                chart = new google.visualization.PieChart(document.getElementById('piechart'));

              
                chart.draw(data, options);

            },
            error: function () {
                alert("Error loading data! Please try again.");
            }
        });
    }
    );

    google.charts.load('current', { 'packages': ['corechart'] }).then(function (e) {
        $.ajax({
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json',
            url: '../Reportes/consultaCartera',
            beforeSend: function () {
                $("#piechartCartera").html('<div class="lds-ring" style="top:35%"><div></div><div></div><div></div><div></div></div>');
            },
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

                chart = new google.visualization.PieChart(document.getElementById('piechartCartera'));


                chart.draw(data, options);

            },
            error: function () {
                alert("Error loading data! Please try again.");
            }
        });
    }
  );

    google.charts.load('current', { 'packages': ['corechart'] }).then(function (e) {
        $.ajax({
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json',
            url: '../Reportes/consultaColoCbrnza',
            beforeSend: function () {
                $("#combochart").html('<div class="lds-ring" style="top:35%"><div></div><div></div><div></div><div></div></div>');
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
                    }
                };

                chart = new google.visualization.ComboChart(document.getElementById('combochart'));

                chart.draw(data, options);

            },
            error: function () {
                alert("Error loading data! Please try again.");
            }
        });
    }
  );

    
    var not =
   {
       openPopUp: function (pageUrl, titulo) {
           var $pageContent = $('<div>');

           $pageContent.load(pageUrl, function () {

               $pageContent.dialog({
                   width: '80%', // overcomes width:'auto' and maxWidth bug
                   height: '550',
                   modal: true,
                   show: 'fade',
                   title: titulo,
                   hide: 'fade',
                   resizable: false,
                   create: function (event, ui) {

                   }
                   ,
                   close: function () {
                       $pageContent.dialog('destroy').remove();
                   }
               });
           });

           $pageContent.on('submit',
              '#popupForm',
              function (e) {
                  var url = $('#popupForm')[0].action;
                  $.ajax({
                      type: "POST",
                      url: url,
                      data: $('#popupForm').serialize(),
                      success: function (data) {
                          $pageContent.dialog('close');
                      },
                      error: function () {

                          $.alert({
                              title: "Error",
                              type: 'red',
                              content: "Ocurrio un error favor de volver a intentar!!",
                              animateFromElement: false
                          });
                      }
                  });

                  e.preventDefault();
              });
       }
   }

    $(document).ready(function (e) {
        $(".grafica").click(function (e) {
            not.openPopUp($(this).attr("ref"), "")
        })
    });



</script>



<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <span>@ViewData("welcome")</span>
        </div>
    </div>
</div>

<h1>Factoraje</h1>

<div class="lead">
    <div class="row">
        <div class="col-md-6">
            @Html.Raw(Model.sMenu)
        </div>
        <div class="col-xs-12 col-md-6">
            <div class="clearfix"></div>
            <div class="col-md-6">
                <div class="BoxFlexShadow grafica" style="width: 100%" ref="../Reportes/GraficaLinea">
                    <div id="curve_chart" style="height: 99%"></div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="BoxFlexShadow grafica" style="width: 100%" ref="../Reportes/GraficaPie">                     
                    <div id="piechart" style="height: 99%"></div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="BoxFlexShadow grafica" style="width: 100%" ref="../Reportes/GraficaCartera">                     
                    <div id="piechartCartera" style="height: 99%"></div>
                </div>
            </div>
               <div class="col-md-6">
                <div class="BoxFlexShadow grafica" style="width: 100%" ref="../Reportes/GraficaBarra">                     
                    <div id="combochart" style="height: 99%"></div>
                </div>
            </div>
        </div>
    </div>
</div>


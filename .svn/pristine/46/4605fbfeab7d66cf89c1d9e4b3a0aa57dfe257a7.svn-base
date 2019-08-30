@Code
    ViewData("Title") = "ReporteLineasFactor"
End Code
<script src="https://cdn.jsdelivr.net/npm/js-cookie@2/src/js.cookie.min.js"></script>
<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="~/Reportes/Informes">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Lineas Factor</span>
        </div>
    </div>
</div>

<div class="panel panel-default">
    <div class="panel-body">
        <div class="form-inline">
            <label>Fecha</label>
            <input type="text" class="form-control" id="date" style="width: 100px" readonly="true">
        </div>
        <a class="Reporte btn material-btn main-container__column" style="margin-top:50px" href="@Url.Action("ReporteLineasFactorDesc", "Reportes",New With{.tipo="pdf"})" type="file" role="button">Exportar PDF</a>
        <a class="Reporte btn material-btn main-container__column" style="margin-top:50px" href="@Url.Action("ReporteLineasFactorDesc", "Reportes",New With{.tipo="excel"})" type="file" role="button">Exportar EXCEL</a>
    </div>
</div>


<script>
    $(document).ready(function (e) {
       $('#date').val(moment().format('DD/MM/YYYY'))
        $('.Reporte').click(function (e) {
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
        })
    })

</script>

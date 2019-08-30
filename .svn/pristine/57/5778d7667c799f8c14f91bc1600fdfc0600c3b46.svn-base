@Code
  ViewData("Title") = "Rebate mensual"
End Code


@section scripts
        <script src="~/Scripts/Reportes/Rebatemensual.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
End Section


<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="~/Reportes/Informes">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Rebate Mensual</span>
        </div>
    </div>
</div>

<div class="row">
  <div class="col-md-2">
    &nbsp;
  </div>
</div>


<div class="panel panel-default">
    <div class="panel-body">


        <div class="row">
        <div class="col-md-2">
          &nbsp;
        </div>
      </div>

      <div class="form-inline" style="width: 100%">
        <div class="form-group">
          @Html.Label("Mes de : ", New With {.class = "control-label"})
          <input id="month" class='month-year-input form-control' style="width: 100px" type="text" autocomplete="off" width="100px" />
        </div>


        <div class="form-group">
          <a class="btn material-btn main-container__column" style="float: right" href="" type="file" role="button" id="descargar">Descargar</a>
        </div>
      </div>

      <div class="row">
        <div class="col-md-2">
          &nbsp;
        </div>
      </div>


    </div>
</div>

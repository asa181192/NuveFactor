@ModelType nuve.Models.Modelocobranza

@Code
  ViewData("Title") = "Adeudos por liquidar"
End Code

<div class="head">
  <div class="headForma">
    <div class="headFormaContenido">
      <a href="~/Reportes/Informes">
        <img src="~/Images/menu/menuregresar.png" /></a>
      <span>Adeudos por liquidar</span>
    </div>
  </div>
</div>

</br>

@Section Scripts
  <script src="~/Scripts/Reportes/Adeudosxliquidar.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/js-cookie@2/src/js.cookie.min.js"></script>
End Section


<style>
  .form-group, input {
    font-size: 12px;
  }
</style>



<div class="panel panel-default">
  <div class="panel-body">

    <div class="form-inline">

      <div class="form-group">
        @Html.Label("Divisa", New With {.class = "control-label"})
      </div>

      <div class="form-group">
        <select name="divisa" id="divisa" class='form-control' style="width: 160px">
          <option value="1">Moneda Nacional</option>
          <option value="2">Dólares</option>
        </select>
        @*<label class="col-sm-8"></label>*@
      </div>
    </div>
    
    <br>

@*    <div class="form-inline">
      <div class="form-group">
        <label class="rdButton">
          <input id="todo" class="form-check-input" type="radio" name="info" value="1" checked="checked" /><label>Todos los contratos</label><br />
          <input id="algun" class="form-check-input" type="radio" name="info" value="2" /><label>Algún contrato</label>
      </div>
    </div>

     <div class="form-inline">
      <div class="form-group">
        @Html.Label("Contrato:")
        <input id="contrato" value="0" class='form-control' type="text" style="width: 90px" />
        <input id="nombre" class='form-control' type="text" autocomplete="off" style="width: 400px" />
      </div>
    </div>*@

    <hr />
    
    <hr />
    

    <div class="form-inline">
      <div class="form-group">
        <a class="btn material-btn main-container__column" style="float: left" href="" type="file" role="button" id="pdf">PDF</a>&nbsp;&nbsp;
      </div>

      <div class="form-group">
        <a class="btn material-btn main-container__column" style="float: left" href="" type="file" role="button" id="xls">Excel</a>
      </div>
    </div>


  </div>


@ModelType nuve.Models.Modelocobranza

@Code
    ViewData("Title") = "Información de cobros"
End Code

<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="~/Reportes/Informes">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Información de cobros y aforos</span>
        </div>
    </div>
</div>

</br>

@Section Scripts
  <script src="~/Scripts/Reportes/Informecobros.js"></script>
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

        @Html.Label("Fecha : ", New With {.class = "control-label"})
        <div class='input-group date' id='ac_fechaDataTime'>
          <input id="sfecha" class='month-year-input form-control' type="text" autocomplete="off" style="width:120px"/>
          <span class="input-group-addon">
            <span class="glyphicon glyphicon-search"></span>
          </span>
        </div>

      </div>
    </div>

    <br>

    <div class="form-inline">
      <div class="form-group">
        <label class="rdButton">
          <input id="cobro" class="form-check-input" type="radio" name="reporte" value="1" checked="checked" /><label>Información de cobros</label><br />
          <input id="aforo" class="form-check-input" type="radio" name="reporte" value="2" /><label>Liquidación de aforos</label>
      </div>
    </div>

    <br>

    <div class="form-inline">
      <div class="form-group">
        <label class="rdButton">
          <input id="todo" class="form-check-input" type="radio" name="info" value="1" checked="checked" /><label>Todos los contratos</label><br />
          <input id="algun" class="form-check-input" type="radio" name="info" value="2" /><label>Algún contrato</label>
      </div>
    </div>

    <br>

    <div class="form-inline">
      <div class="form-group">
        @Html.Label("Contrato:")
        <input id="contrato" value="0" class='form-control' type="text" style="width:90px" />
        <input id="nombre" class='form-control' type="text" autocomplete="off" style="width:400px" />
      </div>
    </div>

    <hr />


   
     <a class="btn btn-default btn-sm" style="float:left" href="" type="file" role="button" id="descargar">Exportar PDF</a>  
    @*<input type="submit" value="PDF" id="descargar" class="btn bold" style="float: left" href="" />*@
    
  </div>

  @*<div class="panel-body">*@

    @*<div class="jumbotron">*@
    @*     <span>Todos:</span>
      <label class='chBox'>
        <input type='checkbox' id="test" class='form-check-input checked' />
        <span class='checkmark'></span>
      </label>
   *@
    @*</div>*@

  @*</div>*@
</div>




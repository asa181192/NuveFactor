@ModelType nuve.Models.Modelocobranza

@Code
  ViewData("Title") = "Factoraje - Cobranza Global"
End Code

@Section Scripts
  <script src="~/Scripts/CobranzaScripts/Cobglobal.js"></script>
  <script src="//cdnjs.cloudflare.com/ajax/libs/x-editable/1.5.0/bootstrap3-editable/js/bootstrap-editable.min.js"></script>
End Section

@Section css
  <link href="//cdnjs.cloudflare.com/ajax/libs/x-editable/1.5.0/bootstrap3-editable/css/bootstrap-editable.css" rel="stylesheet" />
End Section

<div class="head">
  <div class="headForma">
    <div class="headFormaContenido">
      <a href="~/Cobranza/Index">
        <img src="~/Images/menu/menuregresar.png" /></a>
      <span>Cobranza Global</span>
    </div>
  </div>
</div>

   @Html.HiddenFor(Function(x) x.afectado)

<div id="tableContainer" class="tableContainer">
  <div class="panel-heading">
    <div class="topmargin">
      <div class="form-inline" style="width: 100%">


          @Html.Label("Fecha : ", New With {.class = "control-label"})
          <div class='input-group date' id='ac_fechaDataTime'>
            <input id="sfecha" class='month-year-input form-control' type="text" autocomplete="off" />
            <span class="input-group-addon">
              <span class="glyphicon glyphicon-search"></span>
            </span>
          </div>
 
        @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.COBRANZA_ACTUALIZAR) Then
 
         @<div class="form-group pull-right">
          <button id="btnafectar" type="button" class="btn bold">Afectar cobranza</button>
         </div>
 
         End If 
 

      </div>

     
    </div>

  </div>
</div>

<div class="panel panel-default material-panel">
  <div class="panel-body material-panel__body">
    <div class="table-responsive">
      <table id="tablaprincipal" class="table cell-border compact hover" style="width: 100%">

        <thead>

@*          <tr>

            <div class="form-inline">
              <div class="form-group">
                <label>Contrato: </label>
                <label id="cont" />
              </div>

              <div class="form-group">
                <label id="nom" />
              </div>

              <div class="form-group">
                <label id="monedastr" />
              </div>


            </div>

          </tr>

          <tr>
            <div class="form-inline">
              <div class="form-group">
                <label>Producto: </label>
              </div>
              <div class="form-group">
                <label id="descrip" />
              </div>
            </div>
          </tr>

          <tr>
            <div class="form-inline">

              <div class="form-group">
                <label>Adeudos: </label>
              </div>
              <div class="form-group">
                <label id="ade" />
              </div>
              &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                  
                  <div class="form-group">
                    <label>Provisión: </label>
                  </div>
              <div class="form-group">
                <label id="prov" />
              </div>
              &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                
                  <div class="form-group">
                    <label>Moratorios: </label>
                  </div>
              <div class="form-group">
                <label id="moras" />
              </div>

            </div>
          </tr>*@


          <tr>
            <th>
              @Html.DisplayNameFor(Function(model) model.safectado)
            </th>
            <th>
              @Html.DisplayNameFor(Function(model) model.contrato)
            </th>
            <th>
              @Html.DisplayNameFor(Function(model) model.Nombre)
            </th>
            <th>
              @Html.DisplayNameFor(Function(model) model.monedastr)
            </th>
            <th style="text-align:right">
              @Html.DisplayNameFor(Function(model) model.deposito)
            </th>
            <th style="text-align:right">
              @Html.DisplayNameFor(Function(model) model.importe)
            </th>
            <th style="text-align:right">
              @Html.DisplayNameFor(Function(model) model.descto)
            </th>
            <th style="text-align:right">
              @Html.DisplayNameFor(Function(model) model.neto)
            </th>
            <th style="text-align:right">
              @Html.DisplayNameFor(Function(model) model.bonifica)
            </th>
            
          </tr>
        </thead>

        <tfoot>
          <tr>

            <th colspan="3">
            </th>


            <th>Totales.-
            </th>

            <th style="text-align:right">
              <label id="deposito" />
            </th>

            <th style="text-align:right">
              <label id="importe" />
            </th>

            <th style="text-align:right">
              <label id="descto" />
            </th>

            <th style="text-align:right">
              <label id="neto" />
            </th>

            <th style="text-align:right">
              <label id="bonifica" />
            </th>

            
          </tr>
        </tfoot>
      </table>
    </div>
  </div>
</div>
@*</div>*@

<div id="dialog-confirm" title="" style="display: none">
  <p>
    <span class="glyphicon glyphicon-remove" style="float: left; margin: 12px 12px 20px 0;"></span>
  </p>
</div>

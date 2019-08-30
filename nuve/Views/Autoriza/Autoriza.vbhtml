@ModelType nuve.Models.Modeloautoriza

@Code
  ViewData("Title") = "Factoraje - Autorizaciones"
  
 
  Dim DropDown = New List(Of SelectListItem)
  DropDown.Add(New SelectListItem With {.Value = 1, .Text = "Todas (Solo Lectura)"})
  DropDown.Add(New SelectListItem With {.Value = 2, .Text = "Proveedores electrónico (Solo Lectura)"})
  DropDown.Add(New SelectListItem With {.Value = 3, .Text = "Nafin (Solo Lectura)"})
  DropDown.Add(New SelectListItem With {.Value = 4, .Text = "Fira (Solo Lectura)"})
  DropDown.Add(New SelectListItem With {.Value = 5, .Text = "Con Recurso (Solo Lectura)"})
  DropDown.Add(New SelectListItem With {.Value = 6, .Text = "Para Fondeo"})

End Code

@Section Scripts
  <script src="~/Scripts/AutorizaScripts/Autoriza.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
     <script src="~/Scripts/duDatepicker.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/js-cookie@2/src/js.cookie.min.js"></script>

End Section

@Section Css
    <link rel="stylesheet" href="~/Content/duDatepicker.css" />
End Section



<div class="head">
  <div class="headForma">
    <div class="headFormaContenido">
      <a href="~/Operaciones/Index">
        <img src="~/Images/menu/menuregresar.png" /></a>
      <span>Autorizaciones</span>
    </div>
  </div>
</div>

   
<div id="tableContainer" class="tableContainer">
  <div class="panel-heading">
    <div class="topmargin">
      <div class="form-inline" style="width: 100%">


         @Html.Label("Fecha : ", New With {.class = "control-label"})
        <div class="form-group materail-input-block materail-input-block_primary">
          <input id="sfecha" class='materail-input' type="text" autocomplete="off" />
        </div>


        <div class="form-group">

          @Html.Label(" ", New With {.class = "control-label"})
          @Html.DropDownList("movto", DropDown, New With {.Class = "form-control dropdown", .style = "width:300px"})

        </div>

        <div class="form-group pull-right">
          <button id="btnpago" type="button" class="btn bold">Pagar</button>
        </div>
      </div>

      <div class="form-inline" style="width: 100%">

         <div class="form-group pull-right">
          @*<button id="btnafectar" type="button" class="btn bold">Afectar cobranza</button>*@

          @*<button id="btnreverso" type="button" class="btn bold">Reverso cobranza</button>*@
        </div>
     
      </div>

      <div class="row">
        
      
        </div>



    </div>

  </div>
</div>

<div class="panel-body">
  <div >
    <div class="table-responsive">


      <table id="tablaprincipal" class="table cell-border compact hover" style="width: 100%">

        <thead>

        
          <tr>
            <th style="text-align:center">
              <label class='chBox' id="chb">
                <input type='checkbox' id="todos" class='form-check-input checked' />
                <span class='checkmark'></span>
              </label>

            </th>
            <th style="text-align:center">
              @Html.DisplayNameFor(Function(model) model.oper)
            </th>
            <th style="text-align:center">
              @Html.DisplayNameFor(Function(model) model.timestart)
            </th>
            <th style="text-align:center">
              @Html.DisplayNameFor(Function(model) model.timefondeo)
            </th>
            <th>
              @Html.DisplayNameFor(Function(model) model.contname)
            </th>
            
            <th style="text-align:left">
              @Html.DisplayNameFor(Function(model) model.descrip)
            </th>

            <th style="text-align:center">
              @Html.DisplayNameFor(Function(model) model.moneda)
            </th>
            <th style="text-align:right">
              @Html.DisplayNameFor(Function(model) model.pago)
            </th>
            <th style="text-align:center">
              @Html.DisplayNameFor(Function(model) model.stat)
            </th>
            <th style="text-align:left">
              @Html.DisplayNameFor(Function(model) model.benefi)
            </th>
            <th style="text-align:left">
              @Html.DisplayNameFor(Function(model) model.clabe)
            </th>
            <th style="text-align:left">
              @Html.DisplayNameFor(Function(model) model.shortname)
            </th>
           <th style="text-align:left">
              @Html.DisplayNameFor(Function(model) model.disperfile)
            </th>
          </tr>
        </thead>

        <tfoot>
          <tr>

            <th colspan="13">
            </th>


   @*         <th>
            </th>

            <th style="text-align:right">
              <label id="importe" />
            </th>

            <th colspan="6">
            </th>*@

            
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

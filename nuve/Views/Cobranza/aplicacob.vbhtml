﻿@ModelType nuve.Models.Modelocobranza


@Section Scripts
  <script src="~/Scripts/CobranzaScripts/aplicacob.js"></script>
  
End Section



@Code
  Layout = Nothing
  
  Dim DropDown = New List(Of SelectListItem)
  DropDown.Add(New SelectListItem With {.Value = 1, .Text = "Cobranza al 100%"})
  DropDown.Add(New SelectListItem With {.Value = 2, .Text = "Porcentaje de Aforo " + Convert.ToInt16((Model.porc_aforo * 100)).ToString() + "%"})
  DropDown.Add(New SelectListItem With {.Value = 3, .Text = "Cancelación de cartera"})
 
End Code

<style>
  .form-group, input {
    font-size: 12px;
  }
</style>

@Html.HiddenFor(Function(m) m.fecha)
@Html.HiddenFor(Function(m) m.contrato)
@Html.HiddenFor(Function(m) m.porc_aforo)

@*@Using Html.BeginForm("Obtenerdocumentosxpagar", "Cobranza", FormMethod.Post, New With {.id = "popupForm"})
  @Html.ValidationSummary(True)
  
     
  @<div class="form-group">
  </div>                    
  
  @<div>
    <input type="submit" value="Guardar" class="btn bold" />
  </div>

End Using*@


<div id="tableContainer" class="tableContainer">
  <div class="panel-heading">
    <div class="form-inline">
      <div class="form-group">

        @Html.Label("Aplicar : ", New With {.class = "control-label"})
        @Html.DropDownList("prueba", DropDown, New With {.Class = "form-control dropdown", .style = "width:200px"})
        
      </div>
      <input type="submit"  value="Guardar" id="Guardar" class="btn bold" style="float:right"/>
    </div>
  </div>

  <div class="panel panel-default material-panel">
    <div class="panel-body material-panel__body">
      <span>Todos:</span>
      <label class='chBox'>
        <input type='checkbox' id="test" class='form-check-input checked' />
        <span class='checkmark'></span>
      </label>
      <div class="table-responsive">
        <table id="table" class="table cell-border compact hover" style="width: 100%">
          <thead>
            <tr>
              <th>
                @Html.DisplayNameFor(Function(model) model.void)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.iddocto)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.docto)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.cesion)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.fec_vence)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.saldo)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.deudor)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.importe)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.descto)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.neto)
              </th>
              <th>
                @Html.DisplayNameFor(Function(model) model.bonifica)
              </th>

            </tr>
          </thead>
        </table>
      </div>
    </div>
  </div>
</div>



@ModelType nuve.Models.Contrato_Cliente

@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
    ViewData("Title") = "GuardarContrato"
End Code

@Section Scripts
    <script src="~/Scripts/CatalogosScripts/GuardarContrato.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
    <script src="~/Scripts/chosen.jquery.js"></script>
End Section


@Section css
    <link rel="stylesheet" href="~/Content/chosen.css" />
End Section

<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="~/Catalogos/Contratos?clienteid=@Model.Cliente.cliente&nombre=@Model.Cliente.nombre">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>@IIf(Model.Contrato.contrato > 0, String.Concat("CONTRATO (", Model.Contrato.contrato.ToString(), ") ", Model.Cliente.nombre), "Nuevo Contrato") </span>
        </div>
    </div>
</div>

<div class="head">
  &nbsp;
</div>


@Using Html.BeginForm("GuardarContrato", "Catalogos", FormMethod.Post, New With {.id = "ContratoForm"})

    @<div class="panel panel-default" style="font-family: 'News Cycles'; font-size: 14px">
        <div class="panel-body highlight">

          @*<div class="panel-body highlight">*@
            @Html.ValidationSummary(True)

            @If Model IsNot Nothing And Model.Contrato.contrato > 0 Then
                @Html.HiddenFor(Function(model) model.Contrato.contrato)
            End If
            <ul class="nav nav-tabs" role="tablist" id="tabs">
                <li role="presentation" class="active"><a href="#generales" class="nav-link" aria-controls="generales" role="tab" data-toggle="tab">GENERALES</a></li>
                <li role="presentation" class="nav-item"><a href="#parametros" class="nav-link" aria-controls="Domicilio" role="tab" data-toggle="tab">PARAMETROS</a></li>
                <li role="presentation" class="nav-item"><a href="#notas" class="nav-link" aria-controls="Acta" role="tab" data-toggle="tab">NOTAS</a></li>
            </ul>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="generales">

                    <div class="row">
                    <div class="col-md-2">
                      &nbsp;
                    </div>
                  </div>

                    <div class="row">

          
                      <div class="col-md-1">
                        <div class="form-group">
                          @Html.LabelFor(Function(model) model.Cliente.cliente, New With {.class = "control-label"})
                          @Html.TextBoxFor(Function(model) model.Cliente.cliente, New With {.Class = "form-control", .Style = "pointer-events : none;  width : 100px", .ReadOnly = True})
                          @Html.ValidationMessageFor(Function(model) model.Cliente.cliente)
                        </div>
                      </div>

                      <div class="col-md-3">
                        <div class="form-group">
                          @Html.LabelFor(Function(model) model.Cliente.nombre, New With {.class = "control-label"})
                          @Html.TextBoxFor(Function(model) model.Cliente.nombre, New With {.Class = "form-control", .Style = "pointer-events : none", .ReadOnly = True})
                          @Html.ValidationMessageFor(Function(model) model.Cliente.nombre)
                        </div>
                      </div>

                      <div class="col-md-2">
                        <div class="form-group">
                          @Html.LabelFor(Function(model) model.Contrato.sucursal, New With {.class = "control-label"})
                          @Html.DropDownListFor(Function(model) model.Cliente.sucursal, Model.Contrato.SucursalDropDown, New With {.Class = "form-control dropdown", .Style = "pointer-events : none", .ReadOnly = True})
                          @Html.ValidationMessageFor(Function(model) model.Contrato.sucursal)
                        </div>
                      </div>

                      <div class="col-md-1">
                        <div class="form-group">
                          @Html.LabelFor(Function(model) model.Cliente.fec_alta, New With {.class = "control-label"})
                          @Html.TextBoxFor(Function(model) model.Cliente.fec_alta, New With {.Class = "form-control", .Style = "pointer-events : none ; width : 90px", .ReadOnly = True})
                          @Html.ValidationMessageFor(Function(model) model.Cliente.fec_alta)
                        </div>
                      </div>

                      <div class="col-md-4">
                      <div class="form-group">
                        <label class="chBox">
                          @Html.CheckBoxFor(Function(model) model.Cliente.pfisica, New With {.Class = "form-check-input checked", .disabled = True})
                          <span class="checkmark"></span>
                        </label>
                        @Html.LabelFor(Function(model) model.Cliente.pfisica, New With {.class = "form-check-label"})
                        @Html.ValidationMessageFor(Function(model) model.Cliente.pfisica)
                      </div>

                        @*   </div>
                        
                        <div class="col-md-6">*@

                        <div class="form-group">
                          <label class="chBox">
                            @Html.CheckBoxFor(Function(model) model.Cliente.actempres, New With {.Class = "form-check-input checked", .disabled = True})
                            <span class="checkmark"></span>
                          </label>
                          @Html.LabelFor(Function(model) model.Cliente.actempres, New With {.class = "form-check-label"})
                          @Html.ValidationMessageFor(Function(model) model.Cliente.actempres)
                        </div>
                     
                    </div>


                    </div>

                  <hr>

                    <div class="row">

                      <div class="col-md-4">
                        <div class="form-group">
                          @Html.LabelFor(Function(model) model.Cliente.promotor, New With {.class = "control-label"})
                          @Html.DropDownListFor(Function(model) model.Cliente.promotor, Model.Contrato.PromotorDropDown, New With {.Class = "form-control dropdown", .Style = "pointer-events : none; width: 450px", .ReadOnly = True})
                          @Html.ValidationMessageFor(Function(model) model.Cliente.promotor)
                        </div>
                      </div>

                      <div class="col-md-2">
                        <div class="form-group">
                          @Html.LabelFor(Function(model) model.Cliente.promprod, New With {.class = "control-label"})
                          @Html.DropDownListFor(Function(model) model.Cliente.promprod, Model.Cliente.PromProdDropDown, New With {.Class = "form-control dropdown", .Style = "pointer-events : none; width: 450px", .ReadOnly = True})
                          @Html.ValidationMessageFor(Function(model) model.Cliente.promprod)
                        </div>
                      </div>

                    </div>
                  
                    
                    <div class="row">
                      <div class="col-md-4">
                        <div class="form-group">
                          @Html.LabelFor(Function(model) model.Cliente.fenlace, New With {.class = "control-label"})
                          @Html.TextBoxFor(Function(model) model.Cliente.fenlace, New With {.Class = "form-control", .Style = "pointer-events : none; width: 450px", .ReadOnly = True})
                          @Html.ValidationMessageFor(Function(model) model.Cliente.fenlace)
                        </div>
                      </div>

                      <div class="col-md-4">
                        <div class="form-group">
                          @Html.LabelFor(Function(model) model.Cliente.puesto, New With {.class = "control-label"})
                          @Html.TextBoxFor(Function(model) model.Cliente.puesto, New With {.Class = "form-control", .Style = "pointer-events : none; width: 450px", .ReadOnly = True})
                          @Html.ValidationMessageFor(Function(model) model.Cliente.puesto)
                        </div>
                      </div>

                      <div class="col-md-2">
                        <div class="form-group">
                          @Html.LabelFor(Function(model) model.Cliente.telefono, New With {.class = "control-label"})
                          @Html.TextBoxFor(Function(model) model.Cliente.telefono, New With {.Class = "form-control", .Style = "pointer-events : none; width: 450px", .ReadOnly = True})
                          @Html.ValidationMessageFor(Function(model) model.Cliente.telefono)
                        </div>
                      </div>

                    </div>

       <hr>
                  <div class="row">

                    <div class="col-md-2">
                      <div class="form-group">
                        @Html.LabelFor(Function(model) model.Contrato.infolinea, New With {.class = "control-label"})
                        @Html.TextBoxFor(Function(model) model.Contrato.infolinea, New With {.Class = "form-control", .Style = " width : 100px"})
                        @Html.ValidationMessageFor(Function(model) model.Contrato.infolinea)
                      </div>
                    </div>

                    <div class="col-md-3">
                      <div class="form-group">
                        <label class="chBox">
                          @Html.CheckBoxFor(Function(model) model.Contrato.bloqueado, New With {.Class = "form-check-input checked"})
                          <span class="checkmark"></span>
                        </label>
                        @Html.LabelFor(Function(model) model.Contrato.bloqueado, New With {.class = "form-check-label"})
                        @Html.ValidationMessageFor(Function(model) model.Contrato.bloqueado)
                      </div>

       @*             </div>

                    <div class="col-md-2">*@
                      <div class="form-group">
                        <label class="chBox">
                          @Html.CheckBoxFor(Function(model) model.Contrato.edoiva, New With {.Class = "form-check-input checked"})
                          <span class="checkmark"></span>
                        </label>
                        @Html.LabelFor(Function(model) model.Contrato.edoiva, New With {.class = "form-check-label"})
                        @Html.ValidationMessageFor(Function(model) model.Contrato.edoiva)
                      </div>
                    </div>

                  </div>

         
                </div>

                <div role="tabpanel" class="tab-pane" id="parametros">

                <div class="row">
                    <div class="col-md-2">
                      &nbsp;
                    </div>
                  </div>

                <div class="row">

                  <div class="col-md-4">

                      @code
                        Dim DropDown = New List(Of SelectListItem)
                        DropDown.Add(New SelectListItem With {.Value = 1, .Text = "FACTORAJE CON RECURSO"})
                        DropDown.Add(New SelectListItem With {.Value = 11, .Text = "FACTORAJE A PROVEEDORES ELECTRONICO"})
                        DropDown.Add(New SelectListItem With {.Value = 13, .Text = "PAGO ELECTRONICO NAFIN"})
                        DropDown.Add(New SelectListItem With {.Value = 17, .Text = "PAGO ELECTRONICO FIRA"})
                      End Code

            
                    <div class="form-group">
                      @Html.LabelFor(Function(model) model.Contrato.producto, New With {.class = "control-label"})
                     @If Model IsNot Nothing And Model.Contrato.contrato > 0 Then
                      @Html.DropDownListFor(Function(model) model.Contrato.producto, DropDown, New With {.Class = "form-control dropdown", .Style = "pointer-events : none; width : 350px", .Readonly = True})
                     Else
                      @Html.DropDownListFor(Function(model) model.Contrato.producto, DropDown, New With {.Class = "form-control dropdown", .Style = " width : 350px"})
                     End If
                        @Html.ValidationMessageFor(Function(model) model.Contrato.producto)
                    </div>

                  </div>

                  <div class="col-md-2">
                    <div class="form-group">
                      @Html.LabelFor(Function(model) model.Contrato.linea, New With {.class = "control-label"})
                      @Html.TextBoxFor(Function(model) model.Contrato.linea, New With {.Class = "form-control", .Style = " width : 150px"})
                      @Html.ValidationMessageFor(Function(model) model.Contrato.linea)
                    </div>
                  </div>


                  <div class="col-md-2">
                    <div class="form-group">
                       @Html.LabelFor(Function(model) model.Contrato.moneda, New With {.class = "control-label"})
                      @If Model IsNot Nothing And Model.Contrato.contrato > 0 Then
                      @Html.DropDownListFor(Function(model) model.Contrato.moneda, Model.Contrato.DivisaDropDown, New With {.Class = "form-control dropdown", .Style = "pointer-events : none; width : 130px", .Readonly = True})
                      Else
                      @Html.DropDownListFor(Function(model) model.Contrato.moneda, Model.Contrato.DivisaDropDown, New With {.Class = "form-control dropdown", .Style = " width : 130px"})
                      End If
                      @Html.ValidationMessageFor(Function(model) model.Contrato.moneda)
                    </div>
                  </div>
                    
                  <div class="col-md-2">
                    <div class="form-group">
                      @Html.LabelFor(Function(model) model.Contrato.porc_anti, New With {.class = "control-label"})
                       @If Model IsNot Nothing And Model.Contrato.contrato > 0 Then
                          @Html.TextBoxFor(Function(model) model.Contrato.porc_anti, New With {.Class = "form-control", .Style = "pointer-events : none; width : 80px", .Readonly = True})
                       Else
                          @Html.TextBoxFor(Function(model) model.Contrato.porc_anti, New With {.Class = "form-control", .Style = " width : 80px"})
                       End If
                      @Html.ValidationMessageFor(Function(model) model.Contrato.porc_anti)
                    </div>
                  </div>

                </div>


                <div class="row">
                        <div class="col-md-2">
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.Contrato.altalinea, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.Contrato.altalinea, "{0:dd/MM/yyyy}", New With {.class = "form-control", .Style = " width : 150px"})
                                @Html.ValidationMessageFor(Function(model) model.Contrato.altalinea)
                            
                             </div>
                          </div>
                    
                        <div class="col-md-2">
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.Contrato.vencelinea, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.Contrato.vencelinea, "{0:dd/MM/yyyy}", New With {.class = "form-control", .Style = " width : 150px"})
                                @Html.ValidationMessageFor(Function(model) model.Contrato.vencelinea)
                            </div>
                       </div>

                        <div class="col-md-2">
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.Contrato.fec_alta, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.Contrato.fec_alta, "{0:dd/MM/yyyy}", New With {.class = "form-control", .Style = " width : 150px"})
                                @Html.ValidationMessageFor(Function(model) model.Contrato.fec_alta)
                            </div>
                        </div>

                      <div class="col-md-2">
                          <div class="form-group">
                                @Html.LabelFor(Function(model) model.Contrato.fec_vence, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.Contrato.fec_vence, "{0:dd/MM/yyyy}", New With {.class = "form-control", .Style = " width : 150px"})
                                @Html.ValidationMessageFor(Function(model) model.Contrato.fec_vence)
                            </div>
                       </div>
                    </div>
   
                 <hr>

                  <div class="row">

                    <div class="col-md-2">
                      <div class="form-group">
                        @Html.LabelFor(Function(model) model.Contrato.tasa_ord, New With {.class = "control-label"})
                        @Html.TextBoxFor(Function(model) model.Contrato.tasa_ord, New With {.Class = "form-control", .Style = " width : 80px"})
                        @Html.ValidationMessageFor(Function(model) model.Contrato.tasa_ord)
                      </div>
       @*             </div>

                    <div class="col-md-2">*@
                      <div class="form-group">
                        @Html.LabelFor(Function(model) model.Contrato.tasa_ext, New With {.class = "control-label"})
                        @Html.TextBoxFor(Function(model) model.Contrato.tasa_ext, New With {.Class = "form-control", .Style = " width : 80px"})
                        @Html.ValidationMessageFor(Function(model) model.Contrato.tasa_ext)
                      </div>
@*                    </div>

                    <div class="col-md-2">*@
               
                    </div>

                    <div class="col-md-2">
                       <div class="form-group">
                        @Html.LabelFor(Function(model) model.Contrato.com_cont, New With {.class = "control-label"})
                        @Html.TextBoxFor(Function(model) model.Contrato.com_cont, New With {.Class = "form-control", .Style = "width : 80px"})
                        @Html.ValidationMessageFor(Function(model) model.Contrato.com_cont)
                      </div>

                       <div class="form-group">
                        @Html.LabelFor(Function(model) model.Contrato.hon_admon, New With {.class = "control-label"})
                        @Html.TextBoxFor(Function(model) model.Contrato.hon_admon, New With {.Class = "form-control", .Style = " width : 80px"})
                        @Html.ValidationMessageFor(Function(model) model.Contrato.hon_admon)
                      </div>
                     </div>

                     <div class="col-md-2">
                      <div class="form-group">
                        @Html.LabelFor(Function(model) model.Contrato.com_prom, New With {.class = "control-label"})
                        @Html.TextBoxFor(Function(model) model.Contrato.com_prom, New With {.Class = "form-control", .Style = "pointer-events : none ; width : 80px"})
                        @Html.ValidationMessageFor(Function(model) model.Contrato.com_prom)
                      </div>
                    </div>
                              
                    
                    <div class="col-md-4">

                      @Html.Label("Tipo de Interes", New With {.class = "form-check-label", .Style = "font-weight:bold"})
                      <div class="form-group">
                        @Html.LabelFor(Function(model) model.Contrato.interes, "Anticipado", New With {.class = "form-check-label"})
                        <label class="rdButtton">
                          @Html.RadioButtonFor(Function(model) model.Contrato.interes, 1, New With {.Class = "form-check-input "})
                          <span class="radiomark"></span>
                        </label>

                        @Html.LabelFor(Function(model) model.Contrato.interes, "Mensual Vencido", New With {.class = "form-check-label"})
                        <label class="rdButtton">
                          @Html.RadioButtonFor(Function(model) model.Contrato.interes, 2, New With {.Class = "form-check-input", .id = "Contrato.interes2"})
                          <span class="radiomark"></span>
                        </label>

                        @Html.LabelFor(Function(model) model.Contrato.interes, "Al vencimiento", New With {.class = "form-check-label"})
                        <label class="rdButtton">
                          @Html.RadioButtonFor(Function(model) model.Contrato.interes, 3, New With {.Class = "form-check-input ", .id = "Contrato.interes3"})
                          <span class="radiomark"></span>
                        </label>
                        @Html.ValidationMessageFor(Function(model) model.Contrato.interes)
                      </div>

                      @*  </div>

                    <div class="col-md-2">*@
                      @If Not Model.Contrato.producto = 1 Or Model.Contrato.producto = 13 Or Model.Contrato.producto = 17 Or Model.Contrato.producto Is Nothing Then
                        @Html.Label("Con cargo al", New With {.class = "form-check-label", .Style = "font-weight:bold"})
                        @<div class="form-group">
                          @Html.LabelFor(Function(model) model.Contrato.cargo, "Emisor", New With {.class = "form-check-label"})
                          <label class="rdButtton">
                            @Html.RadioButtonFor(Function(model) model.Contrato.cargo, 1, New With {.Class = "form-check-input"})
                            <span class="radiomark"></span>
                          </label>

                          @Html.LabelFor(Function(model) model.Contrato.cargo, "Proveedor", New With {.class = "form-check-label"})
                          <label class="rdButtton">
                            @Html.RadioButtonFor(Function(model) model.Contrato.cargo, 2, New With {.Class = "form-check-input", .id = "Contrato.cargo2"})
                            <span class="radiomark"></span>
                          </label>
                          @Html.ValidationMessageFor(Function(model) model.Contrato.cargo)
                        </div>   
                      End If

                    </div>

                    <div class="col-md-2">

                      @Html.Label("Cobro Honorario", New With {.class = "form-check-label", .Style = "font-weight:bold"})
                      <div class="form-group">
                        @Html.LabelFor(Function(model) model.Contrato.honorario, "Mensual", New With {.class = "form-check-label"})
                        <label class="rdButtton">
                          @Html.RadioButtonFor(Function(model) model.Contrato.honorario, 1, New With {.Class = "form-check-input "})
                          <span class="radiomark"></span>
                        </label>

                        @Html.LabelFor(Function(model) model.Contrato.honorario, "Fijo P/Operación", New With {.class = "form-check-label"})
                        <label class="rdButtton">
                          @Html.RadioButtonFor(Function(model) model.Contrato.honorario, 2, New With {.Class = "form-check-input", .id = "Contrato.honorario2"})
                          <span class="radiomark"></span>
                        </label>
                        @Html.ValidationMessageFor(Function(model) model.Contrato.honorario)
                      </div>

                      @If Not Model.Contrato.producto = 1 Or Model.Contrato.producto = 13 Or Model.Contrato.producto = 17 Or Model.Contrato.producto Is Nothing Then
                        @Html.Label("Con cargo al", New With {.class = "form-check-label", .Style = "font-weight:bold"})
                        @<div class="form-group">
                          @Html.LabelFor(Function(model) model.Contrato.honocargo, "Emisor", New With {.class = "form-check-label"})
                          <label class="rdButtton">
                            @Html.RadioButtonFor(Function(model) model.Contrato.honocargo, 1, New With {.Class = "form-check-input"})
                            <span class="radiomark"></span>
                          </label>

                          @Html.LabelFor(Function(model) model.Contrato.honocargo, "Proveedor", New With {.class = "form-check-label"})
                          <label class="rdButtton">
                            @Html.RadioButtonFor(Function(model) model.Contrato.honocargo, 2, New With {.Class = "form-check-input", .id = "Contrato.honocargo2"})
                            <span class="radiomark"></span>
                          </label>
                          @Html.ValidationMessageFor(Function(model) model.Contrato.honocargo)
                        </div>   
                      End If

                    </div>

                  </div>
                                   
                  <hr>

                  <div class="row">
                    <div class="col-sm-2">
                      <div class="form-group" style="padding-top: 1px">
                        <label class="chBox">
                          @Html.CheckBox("Plazo Ilimitado", False, New With {.Class = "form-check-input checked"})
                          <span class="checkmark"></span>
                        </label>
                        @Html.Label("Plazo Ilimitado", New With {.class = "form-check-label"})
                      </div>
         
                      <div class="form-group">
                        @Html.LabelFor(Function(model) model.Contrato.plazoopera, New With {.class = "control-label"})
                        @Html.TextBoxFor(Function(model) model.Contrato.plazoopera, New With {.Class = "form-control", .Style = " width : 80px"})
                        @Html.ValidationMessageFor(Function(model) model.Contrato.plazoopera)
                      </div>
                    </div>

         @*           <div class="col-sm-2">
                      <div class="form-group" style="padding-top: 25px">
                        <label class="chBox">
                          @Html.CheckBoxFor(Function(model) model.Contrato.dispersion, New With {.Class = "form-check-input checked"})
                          <span class="checkmark"></span>
                        </label>
                        @Html.LabelFor(Function(model) model.Contrato.dispersion, New With {.class = "form-check-label"})
                        @Html.ValidationMessageFor(Function(model) model.Contrato.dispersion)
                      </div>
                    
                         <div class="form-group">
                        @Html.LabelFor(Function(model) model.Contrato.dispercom, New With {.class = "control-label"})
                        @Html.TextBoxFor(Function(model) model.Contrato.dispercom, New With {.Class = "form-control", .Style = " width : 80px"})
                        @Html.ValidationMessageFor(Function(model) model.Contrato.dispercom)
                      </div>
                    </div>*@

                       <div class="col-sm-2">
                      <div class="form-group" style="padding-top: 1px">
                        <label class="chBox">
                          @Html.CheckBoxFor(Function(model) model.Contrato.rebate, New With {.Class = "form-check-input checked"})
                          <span class="checkmark"></span>
                        </label>
                        @Html.LabelFor(Function(model) model.Contrato.rebate, New With {.class = "form-check-label"})
                        @Html.ValidationMessageFor(Function(model) model.Contrato.rebate)
                      </div>
                    
                         <div class="form-group">
                        @Html.LabelFor(Function(model) model.Contrato.rebatepts, New With {.class = "control-label"})
                        @Html.TextBoxFor(Function(model) model.Contrato.rebatepts, New With {.Class = "form-control", .Style = " width : 80px"})
                        @Html.ValidationMessageFor(Function(model) model.Contrato.rebatepts)
                      </div>
                    </div>


                    <div class="col-md-4">

                      <div class="form-group" style="padding-top: 1px">
                        <label class="chBox">
                          @Html.CheckBoxFor(Function(model) model.Contrato.mancobranza, New With {.Class = "form-check-input checked"})
                          <span class="checkmark"></span>
                        </label>
                        @Html.LabelFor(Function(model) model.Contrato.mancobranza, New With {.class = "form-check-label"})
                        @Html.ValidationMessageFor(Function(model) model.Contrato.mancobranza)
                      </div>
                      
                      @If (Model.Contrato.producto = 11 Or Model.Contrato.producto Is Nothing) Then
                      @<div class="form-group" style="padding-top: 1px">
                        <label class="chBox">
                          @Html.CheckBoxFor(Function(model) model.Contrato.tasadif, New With {.Class = "form-check-input checked"})
                          <span class="checkmark"></span>
                        </label>
                        @Html.LabelFor(Function(model) model.Contrato.tasadif, New With {.class = "form-check-label"})
                        @Html.ValidationMessageFor(Function(model) model.Contrato.tasadif)
                      </div>
                      End If

                    </div>
                  </div>


                  </div>

                <div role="tabpanel" class="tab-pane" id="notas">

                  <div class="row">
                    <div class="col-md-2">
                      &nbsp;
                    </div>
                  </div>


                  <div class="row">

                    <div class="col-md-2">
                      <div class="form-group" style="padding-top: 25px">
                        <label class="chBox">
                          @Html.CheckBoxFor(Function(model) model.Contrato.seguro, New With {.Class = "form-check-input checked"})
                          <span class="checkmark"></span>
                        </label>
                        @Html.LabelFor(Function(model) model.Contrato.seguro, New With {.class = "form-check-label"})
                        @Html.ValidationMessageFor(Function(model) model.Contrato.seguro)
                      </div>

                    </div>

                    <div class="col-md-2">
                      <div class="form-group">
                            @Html.LabelFor(Function(model) model.Contrato.endoso, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Contrato.endoso, "{0:dd/MM/yyyy}", New With {.Class = "form-control", .Style = "width : 150px"})
                            @Html.ValidationMessageFor(Function(model) model.Contrato.endoso)
                          </div>
                          <div class="form-group">
                            @Html.LabelFor(Function(model) model.Contrato.cobertura, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Contrato.cobertura, New With {.Class = "form-control", .Style = "width : 150px"})
                            @Html.ValidationMessageFor(Function(model) model.Contrato.cobertura)
                          </div>
                      </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            @Html.LabelFor(Function(model) model.Contrato.idmapfre, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Contrato.idmapfre, New With {.Class = "form-control", .Style = "width : 100px"})
                            @Html.ValidationMessageFor(Function(model) model.Contrato.idmapfre)
                          </div>
                          <div class="form-group">
                            @Html.LabelFor(Function(model) model.Contrato.plazo, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Contrato.plazo, New With {.Class = "form-control", .Style = "width : 100px"})
                            @Html.ValidationMessageFor(Function(model) model.Contrato.plazo)
                          </div>
                      </div> 


                      <div class="col-md-2">
                      <div class="form-group">
                        @Html.LabelFor(Function(model) model.Contrato.cve_garant, New With {.class = "control-label"})
                        @Html.DropDownListFor(Function(model) model.Contrato.cve_garant, Model.Contrato.GarantiasDropDown, New With {.Class = "form-control dropdown", .Style = "width : 200px"})
                        @Html.ValidationMessageFor(Function(model) model.Contrato.cve_garant)
                      </div>

                    </div>
                  </div>


                  <div class="row">
                  


                  </div>

                   <div class="row">
                    <div class="col-md-2">
                      &nbsp;
                    </div>
                  </div>


                  <div class="row">
                        <div class="col-xs-12 col-md-12">
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.Contrato.notas, New With {.class = "control-label"})
                                @Html.TextAreaFor(Function(model) model.Contrato.notas, 10, Nothing, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.Contrato.notas)
                            </div>
                        </div>
                    </div>


                </div>
            </div>

        </div>

    '</div>
    If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.CATALOGOS_ACTUALIZAR) Then
    @<input type="submit" value="Guardar" class="btn bold" id="submit" />  
    End If
   
End Using
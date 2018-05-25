@ModelType nuve.clientesModels.cliente

@Code
    ViewData("Title") = "consulta"
End Code

@Using Html.BeginForm(New With {.ReturnUrl = ViewData("ReturnUrl"), .Class = "form-group"})
    
  @<div class="head">
    <div class="headForma">
      <div class="headFormaContenido">
        <span>@ViewData("lblsuperior")</span>
      </div>
    </div>
  </div>

  @<br />

  @<form class="form-inline">
	  <button id="btngrupo" type="submit" class="btn btn-bxmas">Grupo</button>
	  <button id="btnpersonalidad" type="submit" class="btn btn-bxmas">Personalidad</button>
  </form>

  @<br />

  @<div class="panel panel-default">

    <div class="panel-body highlight">  

      @Html.AntiForgeryToken()
      @Html.ValidationSummary(true)

      <ul class="nav nav-tabs" id="pills-tab" role="tablist">
        <li class="nav-item">
          <a class="nav-link" id="nav-basicos-tab" data-toggle="tab" href="#nav-basicos" role="tab" aria-controls="nav-basicos" aria-expanded="true">B&aacute;sicos</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" id="nav-domicilio-tab" data-toggle="tab" href="#nav-domicilio" role="tab" aria-controls="nav-domicilio">Domicilio</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" id="nav-contactos-tab" data-toggle="tab" href="#nav-contactos" role="tab" aria-controls="nav-contactos">Contactos</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" id="nav-varios-tab" data-toggle="tab" href="#nav-varios" role="tab" aria-controls="nav-varios">Varios</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" id="nav-kyc-tab" data-toggle="tab" href="#nav-kyc" role="tab" aria-controls="nav-kyc">KYC</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" id="nav-infcontable-tab" data-toggle="tab" href="#nav-infcontable" role="tab" aria-controls="nav-infcontable">Info. Contable</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" id="nav-infpersonal-tab" data-toggle="tab" href="#nav-infpersonal" role="tab" aria-controls="nav-infpersonal">Info. Personal</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" id="nav-bnc-tab" data-toggle="tab" href="#nav-bnc" role="tab" aria-controls="nav-bnc">BNC</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" id="nav-variables-tab" data-toggle="tab" href="#nav-variables" role="tab" aria-controls="nav-variables">Variables</a>
        </li>
      </ul>

      <div class="tab-content" id="pills-tabContent">

			  <div class="row">
          <div class="form-inline">
            <div class="col-md-7"></div>
				    <div class="col-md-1">
					    <button id="btnriesgopld" type="submit" class="btn btn-bxmas">Riesgo PLD: @Model.Riesgopld </button>
				    </div>
				    <div class="col-md-1">
					    <button id="btnclientevxmas" type="submit" class="btn btn-bxmas">Cliente BX+</button>
				    </div>
				    <div class="col-md-3">
              <div class="form-group">
                @Html.TextBoxFor(Function(n) n.nbrclientecs, New With {.Class = "form-control", .placeholder = "0", .style = "width: 35px;"}) 
						    <div class="checkbox">
							    <label>
								    @Html.CheckBoxFor(Function(m) m.aval, New With {.class = "form-check-input"}) @Html.LabelFor(Function(m) m.aval, New With {.class = "form-check-label"})
								    @Html.CheckBoxFor(Function(m) m.accionista, New With {.class = "form-check-input"}) @Html.LabelFor(Function(m) m.accionista, New With {.class = "form-check-label"})
							    </label>
						    </div>
					    </div>
				    </div>
          </div>				
			  </div>

        <!-- BASICOS -->
        <div class="tab-pane fade" id="nav-basicos" role="tabpanel" aria-labelledby="nav-basicos-tab">
                          
          <div class="row">
            <div class="col-md-4">
              <div class="form-check">
                @Html.RadioButtonFor(Function(m) m.pfisica, True, New With {.id = "rbpfisica"})
                @Html.LabelFor(Function(m) m.rbpfisica, New With {.class = "form-check-label"})              
              </div>
            </div>
            <div class="col-md-4">
              <div class="form-check">
                @Html.CheckBoxFor(Function(m) m.pfempre, New With {.class = "form-check-input"})
                @Html.LabelFor(Function(m) m.pfempre, New With {.class = "form-check-label"})              
              </div>
            </div>
            <div class="col-md-4">
              <div class="form-inline">
                <div class="form-group">
                  @Html.LabelFor(Function(m) m.cltedesde, New With {.class = "control-label"})
                  <div class='input-group date' id='dpcltedesde' style="width: 200px;">
                    @code
                      Dim scltedesde = Model.cltedesde.ToString("dd/MM/yyyy", New System.Globalization.CultureInfo("es-mx"))
                      @<input name="cltedesde" class="form-control" id="cltedesde" type="text" value="@scltedesde" data-val-required="El campo Cliente desde es obligatorio." data-val="true" data-val-date="El campo Cliente desde debe ser una fecha.">
			                @<span class="input-group-addon">
				                <span class="glyphicon glyphicon-calendar"></span>
			                </span>
                    End Code
                  </div>
                  @Html.ValidationMessageFor(Function(m) m.cltedesde)
                </div>
              </div>
            </div>
          </div>

          <div class="row">
            <div class="col-md-6">
              <div class="form-group">            
                @Html.LabelFor(Function(m) m.n, New With {.class = "control-label"})
                <div >              
                  @Html.TextBoxFor(Function(m) m.n, New With {.Class = "form-control", .style = "width: 300px;"})
                </div>
              </div>
            </div>          
            <div class="col-md-6">
              <div class="form-group">            
                @Html.LabelFor(Function(m) m.s, New With {.class = "control-label"})
                <div >              
                  @Html.TextBoxFor(Function(m) m.s, New With {.Class = "form-control", .style = "width: 300px;"})
                </div>
              </div>
            </div>
          </div>
         
          <div class="row">
            <div class="col-md-6">
              <div class="form-group">
                @Html.LabelFor(Function(m) m.p, New With {.class = "control-label"})
                <div >
                  @Html.TextBoxFor(Function(m) m.p, New With {.Class = "form-control", .style = "width: 300px;"})
                </div>
              </div>
            </div>
            <div class="col-md-6">
              <div class="form-group">
                @Html.LabelFor(Function(m) m.m, New With {.class = "control-label"})
                <div >
                  @Html.TextBoxFor(Function(m) m.m, New With {.Class = "form-control", .style = "width: 300px;"})
                </div>
              </div>
            </div>
          </div>
        
          <hr style="border: 1px outset rgb(89, 89, 85); border-image: none;" />

          <div class="row">
            <div class="col-md-4">
              <div class="form-check">
                @Html.RadioButtonFor(Function(m) m.pfisica, False, New With {.id = "rbpmoral"})
                @Html.LabelFor(Function(m) m.rbpmoral, New With {.class = "form-check-label"})
              </div>
            </div>
            <div class="col-md-4">
              <div class="form-check">
                @Html.CheckBoxFor(Function(m) m.pmfideicomiso, New With {.class = "form-check-input"})
                @Html.LabelFor(Function(m) m.pmfideicomiso, New With {.class = "form-check-label"})
              </div>
            </div>
            <div class="col-md-4"></div>
          </div>
        
          <div class="row">
            <div class="col-md-4">
              <div class="form-inline">
                <div class="form-group">
                  @Html.LabelFor(Function(m) m.nombre, New With {.class = "control-label"})
                  @Html.TextBoxFor(Function(m) m.nombre, New With {.Class = "form-control", .style = "width: 300px;"})              
                </div>
              </div>            
            </div>
            <div class="col-md-4">
              <div class="form-inline">
                <div class="form-group">
                  @Html.LabelFor(Function(m) m.sociedad, New With {.class = "control-label"})
                  @Html.TextBoxFor(Function(m) m.sociedad, New With {.Class = "form-control", .style = "width: 300px;"})              
                </div>
              </div>            
            </div>
            <div class="col-md-4"></div>
          </div>
        
          <hr style="border: 1px outset rgb(89, 89, 85); border-image: none;" />
        
          <div class="row">          
            <div class="col-md-4">
              <div class="form-inline">
                <div class="form-group">
                  @Html.LabelFor(Function(m) m.tiposociedad, New With {.class = "control-label"})
                  @Html.DropDownListFor(Function(m) m.tiposociedad, Model.tiposSociedad, New With {.class = "form-control dropdown", .style = "min-width: 300px;"})
                </div>
              </div>
            </div>
            <div class="col-md-4">
              <div class="form-inline">
                <div class="form-group">
                  @Html.LabelFor(Function(m) m.rfc, New With {.class = "control-label"})
                  @Html.TextBoxFor(Function(m) m.rfc, New With {.Class = "form-control", .style = "width: 300px;"})
                </div>
              </div>
            </div>
            <div class="col-md-4">
              <div class="form-inline">
                <div class="form-group">
                  @Html.LabelFor(Function(m) m.curp, New With {.class = "control-label"})
                  @Html.TextBoxFor(Function(m) m.curp, New With {.class = "form-control", .style = "width: 300px;"})
                </div>
              </div>
            </div>
          </div>
        
        </div>

        <!-- DOMICILIO -->
        <div class="tab-pane fade" id="nav-domicilio" role="tabpanel" aria-labelledby="nav-domicilio-tab">

          <div class="row">
            <div class="col-md-6">
              <div class="form-inline">
                <div class="form-group">            
                  @Html.LabelFor(Function(m) m.calle, New With {.class = "control-label"})
                  @Html.TextBoxFor(Function(m) m.calle, New With {.Class = "form-control", .style = "width: 300px;"})
                </div>
              </div>            
            </div>
            <div class="col-md-6"></div>
          </div>

          <br />
          <div class="row">
            <div class="col-md-6">
              <div class="form-inline">
                <div class="form-group">            
                  @Html.LabelFor(Function(m) m.numext, New With {.class = "control-label"})
                  @Html.TextBoxFor(Function(m) m.numext, New With {.Class = "form-control", .style = "width: 300px;"})
                </div>
              </div>            
            </div>
            <div class="col-md-6">
              <div class="form-inline">
                <div class="form-group">            
                  @Html.LabelFor(Function(m) m.numint, New With {.class = "control-label"})
                  @Html.TextBoxFor(Function(m) m.numint, New With {.Class = "form-control", .style = "width: 300px;"})
                </div>
              </div>            
            </div>
          </div>

          <br />
          <div class="row">
            <div class="col-md-6">
              <div class="form-inline">
                <div class="form-group">            
                  @Html.LabelFor(Function(m) m.domicilio, New With {.class = "control-label"})
                  @Html.TextBoxFor(Function(m) m.domicilio, New With {.Class = "form-control", .style = "width: 300px;"})
                </div>
              </div>            
            </div>
            <div class="col-md-6"></div>
          </div>

          <br />
          <div class="row">
            <div class="col-md-4">
              <div class="form-inline">
                <div class="form-group">            
                  @Html.LabelFor(Function(m) m.cp, New With {.class = "control-label"})                
                  @Html.TextBoxFor(Function(m) m.cp, New With {.class = "form-control", .style = "width: 300px;"})
                </div>
              </div>            
            </div>
            <div class="col-md-4">
              <div class="form-inline">
                <div class="form-group">            
                  @Html.LabelFor(Function(m) m.colonia, New With {.class = "control-label"})
                  <select id="colonias" class="form-control dropdown" style="min-width: 300px"></select>
                </div>
              </div>            
            </div>
            <div class="col-md-4">
              @Html.TextBoxFor(Function(m) m.colonia, New With {.class = "form-control", .style = "width: 300px;"})
            </div>
          </div>

          <br />
          <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4">
              @Html.TextBoxFor(Function(m) m.estado, New With {.class = "form-control", .style = "width: 300px;"})
            </div>
            <div class="col-md-4">
              @Html.TextBoxFor(Function(m) m.municipio, New With {.class = "form-control", .style = "width: 300px;"})
            </div>
          </div>

          <br />
          <div class="row">
            <div class="col-md-6">
              <div class="form-inline">
                <div class="form-group">            
                  @Html.LabelFor(Function(m) m.telefono, New With {.class = "control-label"})
                  @Html.TextBoxFor(Function(m) m.telefono, New With {.Class = "form-control", .style = "width: 300px;"})
                </div>
              </div>            
            </div>
            <div class="col-md-6"></div>
          </div>

          <br />
          <div class="row">
            <div class="col-md-6">
              <div class="form-inline">
                <div class="form-group">            
                  @Html.LabelFor(Function(m) m.email, New With {.class = "control-label"})
                  @Html.TextBoxFor(Function(m) m.email, New With {.Class = "form-control", .style = "width: 300px;"})
                </div>
              </div>            
            </div>
            <div class="col-md-6"></div>
          </div>

        </div>

        <!-- CONTACTOS -->
        <div class="tab-pane fade" id="nav-contactos" role="tabpanel" aria-labelledby="nav-kyc-tab">

          <div class="row">
            <div class="col-md-8">
              <div class="form-inline">
                <div class="form-group">
                  @Html.TextAreaFor(Function(m) m.contactos, New With {.Class = "form-control", .style = "width: 705px; height: 117px; rows: 2; cols: 20;"})
                </div>
              </div>
            </div>
            <div class="col-md-4"></div>
          </div>
        
        </div>

        <!-- VARIOS -->
        <div class="tab-pane fade" id="nav-varios" role="tabpanel" aria-labelledby="nav-varios-tab">

          <div class="row">
            <div class="col-md-8">
              <div class="form-inline">
                <div class="form-group">
                  @Html.LabelFor(Function(m) m.actividad, New With {.class = "control-label"})
                  @Html.DropDownListFor(Function(m) m.actividad, Model.actividades, New With {.class = "form-control dropdown", .style = "min-width: 300px;"})
                </div>
              </div>
            </div>
            <div class="col-md-4"></div>
          </div>

          <br />
          <div class="row">
            <div class="col-md-8">
              <div class="form-inline">
                <div class="form-group">
                  @Html.HiddenFor(Function(m) m.subactiv) 
                  @Html.LabelFor(Function(m) m.subactiv, New With {.id = "lblforsubactiv", .class = "control-label"})
                  @Html.TextBoxFor(Function(m) m.subactivtxt, New With {.class = "form-control", .style = "min-width: 400px"})
                  <select id="subactividades" class="form-control dropdown" style="min-width: 300px"></select>
                  <button id="btnmodificarsubactiv" type="submit" class="btn btn-bxmas">Modificar</button>
                </div>
              </div>
            </div>
            <div class="col-md-4"></div>
          </div>

          <br />
          <div class="row">
            <div class="col-md-8">
              <div class="form-inline">
                <div class="form-group">
                  @Html.LabelFor(Function(m) m.sececo, New With {.class = "control-label"})
                  @Html.DropDownListFor(Function(m) m.sececo, Model.sececos, New With {.class = "form-control dropdown", .style = "min-width: 300px;"})
                </div>
              </div>
            </div>
            <div class="col-md-4"></div>
          </div>

          <br />
          <div class="row">
            <div class="col-md-8">
              <div class="form-inline">
                <div class="form-group">
                  @Html.HiddenFor(Function(m) m.riesgo) 
                  @Html.LabelFor(Function(m) m.riesgo, New With {.id = "lblforriesgo", .class = "control-label"})
                  @Html.TextBoxFor(Function(m) m.riesgotxt, New With {.class = "form-control", .style = "min-width: 400px"})
                  <select id="riesgos" class="form-control dropdown" style="min-width: 300px"></select>
                  <button id="btnmodificarriesgo" type="submit" class="btn btn-bxmas">Modificar</button>
                </div>
              </div>
            </div>
            <div class="col-md-4"></div>
          </div>

          <br />
          <div class="row">
            <div class="col-md-8">
              <div class="form-inline">
                <div class="form-group">
                  @Html.LabelFor(Function(m) m.origen, New With {.class = "control-label"})
                  @Html.DropDownListFor(Function(m) m.origen, Model.origenes, New With {.class = "form-control dropdown", .style = "min-width: 300px;"})
                </div>
              </div>
            </div>
            <div class="col-md-4"></div>
          </div>

          <br />
          <div class="row">
            <div class="col-md-8">
              <div class="form-inline">
                <div class="form-group">
                  @Html.HiddenFor(Function(m) m.promotoractivo)  
                  @Html.HiddenFor(Function(m) m.promotor) 
                  @Html.LabelFor(Function(m) m.promotor, New With {.id = "lblforpromotor", .class = "control-label"})
                  @Html.TextBoxFor(Function(m) m.promotortxt, New With {.class = "form-control", .style = "min-width: 400px"})
                  <select id="promotores" class="form-control dropdown" style="min-width: 300px"></select>
                  <button id="btnmodificarpromotor" type="submit" class="btn btn-bxmas">Modificar</button>
                </div>
              </div>
            </div>
            <div class="col-md-4"></div>
          </div>

          <br />
          <div class="row">
            <div class="col-md-8">
              <div class="form-inline">
                <div class="form-group">                  
                  @Html.LabelFor(Function(m) m.pagodomici, New With {.class = "form-check-label"})
                  @Html.CheckBoxFor(Function(m) m.pagodomici, New With {.class = "form-check-input"})
                  @Html.LabelFor(Function(m) m.nbrchequera, New With {.class = "control-label"})
                  @Html.TextBoxFor(Function(m) m.nbrchequera, New With {.Class = "form-control", .style = "width: 300px;"})
                  <label class="REDALERT">(Pago domiciliado)</label>
                </div>
              </div>
            </div>
            <div class="col-md-4"></div>
          </div>

          <br />
          <div class="row">
            <div class="col-md-8">
              <div class="form-inline">
                <div class="form-group">
                  @Html.LabelFor(Function(m) m.metpago, New With {.class = "control-label"})
                  @Html.DropDownListFor(Function(m) m.metpago, Model.metodospago, New With {.class = "form-control dropdown", .style = "min-width: 300px;"})
                  @Html.LabelFor(Function(m) m.metpagocta, New With {.class = "control-label"})
                  @Html.TextBoxFor(Function(m) m.metpagocta, New With {.Class = "form-control", .style = "width: 300px;"})
                  <label class="REDALERT">Facturaci&oacute;n Electr&oacute;nica</label>
                </div>
              </div>
            </div>
            <div class="col-md-4"></div>
          </div>

          <br />
          <div class="row">
            <div class="col-md-8">
              <div class="form-inline">
                <div class="form-group">
                  @Html.LabelFor(Function(m) m.numemp, New With {.class = "control-label"})
                  @Html.TextBoxFor(Function(m) m.numemp, New With {.Class = "form-control", .style = "width: 300px;"})
                </div>
              </div>
            </div>
            <div class="col-md-4"></div>
          </div>

        </div>

        <!-- KYC -->
        <div class="tab-pane fade" id="nav-kyc" role="tabpanel" aria-labelledby="nav-kyc-tab">
          
          <div class="row">
            <div class="col-md-8">
              <div class="form-inline">
                <div class="form-group">
                  @Html.LabelFor(Function(m) m.pais, New With {.class = "control-label"})
                  @Html.DropDownListFor(Function(m) m.pais, Model.paises, New With {.class = "form-control dropdown", .style = "min-width: 300px;"})
                </div>
              </div>
            </div>
            <div class="col-md-4"></div>
          </div>

          <br />
          <div class="row">
            <div class="col-md-8">
              <div class="form-inline">
                <div class="form-group">
                  @Html.LabelFor(Function(m) m.pais_actual, New With {.class = "control-label"})
                  @Html.DropDownListFor(Function(m) m.pais_actual, Model.paises, New With {.class = "form-control dropdown", .style = "min-width: 300px;"})
                </div>
              </div>
            </div>
            <div class="col-md-4"></div>
          </div>

          <br />
          <div class="row">
            <div class="col-md-8">
              <div class="form-inline">
                <div class="form-group">
                  @Html.LabelFor(Function(m) m.altoriesgo, New With {.class = "form-check-label"})
                  @Html.CheckBoxFor(Function(m) m.altoriesgo, New With {.class = "form-check-input"})
                </div>
              </div>
            </div>
            <div class="col-md-4"></div>
          </div>

          <br />
          <div class="row">
            <div class="col-md-8">
              <div class="form-inline">
                <div class="form-group">
                  @Html.LabelFor(Function(m) m.relacion, New With {.class = "form-check-label"})
                  @Html.CheckBoxFor(Function(m) m.relacion, New With {.class = "form-check-input"})
                </div>
              </div>
            </div>
            <div class="col-md-4"></div>
          </div>

          <br />
          <div class="row">
            <div class="col-md-8">
              <div class="form-inline">
                <div class="form-group">
                  @Html.LabelFor(Function(m) m.ocupacion, New With {.class = "control-label"})
                  @Html.TextBoxFor(Function(m) m.ocupacion, New With {.Class = "form-control", .style = "width: 300px;"})
                </div>
              </div>
            </div>
            <div class="col-md-4"></div>
          </div>

          <br />
          <div class="row">
            <div class="col-md-8">
              <div class="form-inline">
                <div class="form-group">
                  @Html.LabelFor(Function(m) m.seriefiel, New With {.class = "control-label"})
                  @Html.TextBoxFor(Function(m) m.seriefiel, New With {.Class = "form-control", .style = "width: 300px;"})
                </div>
              </div>
            </div>
            <div class="col-md-4"></div>
          </div>

          <br />
          <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
            <div class="panel panel-default">
              <div class="panel-heading" role="tab" id="heading1">
                <h4 class="panel-title">
                  <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapse1" aria-expanded="false" aria-controls="collapse1">
                    Proveedores de recursos
                  </a>
                </h4>
              </div>
              <div id="collapse1" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading1">
                <div class="panel-body">
                  <div class="panel panel-default">
                    <div class="panel-body highlight">

                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              @Html.LabelFor(Function(m) m.tieneproveedor, New With {.class = "form-check-label"})
                              @Html.CheckBoxFor(Function(m) m.tieneproveedor, New With {.class = "form-check-input"})
                            </div>
                          </div>
                        </div>
                        <div class="col-md-4"></div>
                      </div>
                      
                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              Buscar por: &nbsp; 
                              <input type="text" id="txtkeyproveedor" class="form-control" style="width: 200px;" /> &nbsp; 
                              <button id="btnbuscarproveedor" type="submit" class="btn btn-bxmas">Buscar</button> &nbsp; 
                              <button id="btnnuevoproveedor" type="submit" class="btn btn-bxmas">Nuevo</button>
                            </div>
                          </div>
                        </div>
                        <div class="col-md-4"></div>
                      </div>                      

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              <select id="cboresultproveedores" class="form-control dropdown" style="min-width: 300px"></select> &nbsp; 
                              <button id="btnasignarproveedor" type="submit" class="btn btn-bxmas">Asignar</button>
                            </div>
                          </div>
                        </div>
                        <div class="col-md-4"></div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              <table class="table table-hover" style="width:100%; padding:0px; border-collapse: collapse; border-spacing:0px">
                                <tr>
                                  <td style="vertical-align:top">
                                    <div class="table-responsive">
                                      <table class="table table-hover">
                                        <thead>
			                                      <tr>
				                                      <th>
					                                      Cliente
				                                      </th>
				                                      <th>
					                                      Nombre
				                                      </th>
				                                      <th>
					                                      R.F.C.
				                                      </th>
			                                      </tr>
	                                      </thead>
	                                      <tbody >
                                          @If (Model.persona_proveedores.Count > 0) Then
                                              For Each pers In Model.persona_proveedores
                                                @<tr>
                                                    <td style="text-align:right">
                                                        <label>@pers.cliente.ToString.PadLeft(6, "0")</label>
				                                                <input id='hdncliente_@pers.cliente.ToString' type='hidden' value='@pers.cliente'>
				                                                <input id='hdnnombre_@pers.cliente.ToString' type='hidden' value='@pers.nombre.Trim'>
				                                                <input id='hdnrfc_@pers.cliente.ToString' type='hidden' value='@pers.rfc.Trim'>
                                                    </td>
                                                    <td style="text-align:center">
                                                      <label>@pers.nombre.Trim</label>
                                                    </td>
                                                    <td style="text-align:center">
                                                      <label>@pers.rfc.Trim</label>
                                                    </td>
                                                 </tr>
                                              Next
                                            Else
                                              @<tr>
                                                  <td style="text-align:right"><label></label></td>
                                                  <td style="text-align:center"><label></label></td>
                                                  <td style="text-align:center"><label></label></td>
                                               </tr>
                                            End If
	                                      </tbody>
                                      </table>
                                    </div>
                                  </td>
                                  <td>
                                    <div style="display: inline; float: left; padding: 10px; border: 1px solid #D1D2D3;">
                                      <div style="text-align:left">
                                        <br />                                  
                                        <button id="btnconsultarproveedor" type="submit" class="btn btn-bxmas">Consultar</button>
                                        <br />
                                        <br />
                                        <button id="btneliminarproveedor" type="submit" class="btn btn-bxmas">Borrar</button>
                                        <br />
                                        <br />
                                      </div>
                                    </div>
                                  </td>
                                </tr>
                              </table>                              
                              
                            </div>
                          </div>
                        </div>
                        <div class="col-md-4"></div>
                      </div>                      

                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="panel panel-default">
              <div class="panel-heading" role="tab" id="heading2">
                <h4 class="panel-title">
                  <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapse2" aria-expanded="false" aria-controls="collapse2">
                    Propietario real de los recursos
                  </a>
                </h4>
              </div>
              <div id="collapse2" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading2">
                <div class="panel-body">
                  <div class="panel panel-default">
                    <div class="panel-body highlight">
                      
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              @Html.LabelFor(Function(m) m.espropietarioreal, New With {.class = "form-check-label"})
                              @Html.CheckBoxFor(Function(m) m.espropietarioreal, New With {.class = "form-check-input"})
                            </div>
                          </div>
                        </div>
                        <div class="col-md-4"></div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              Buscar por: &nbsp; 
                              <input type="text" id="txtbuscarporpropietario" class="form-control" style="width: 200px;"/> &nbsp;
                              <button id="btnbuscarporpropietario" type="submit" class="btn btn-bxmas">Buscar</button> &nbsp;
                              <button id="btnnuevopropietario" type="submit" class="btn btn-bxmas">Nuevo</button>
                            </div>
                          </div>
                        </div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              <select id="cboresultpropietario" class="form-control dropdown" style="min-width: 300px"></select> &nbsp;
                              <button id="btnasignarpropietario" type="submit" class="btn btn-bxmas">Asignar</button>
                            </div>
                          </div>
                        </div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              <table class="table table-hover" style="width:100%; padding:0px; border-collapse: collapse; border-spacing:0px">
                                <tr>
                                  <td style="vertical-align:top">
                                    <div class="table-responsive">
                                      <table class="table table-hover">
                                        <thead>
			                                      <tr>
				                                      <th>Cliente</th>
				                                      <th>Nombre</th>
				                                      <th>R.F.C.</th>
                                              <th>Accionista</th>
                                              <th>Representante</th>
                                              <th>Admnistrador</th>
			                                      </tr>
	                                      </thead>
                                        <tbody>
                                          @If (Model.persona_propietarios.Count > 0) Then
                                              For Each prop In Model.persona_propietarios
                                                @<tr>
                                                      <td style="text-align:right">
                                                        <label>@prop.cliente.ToString.PadLeft(6, "0")</label>
                                                        <input id='hdncliente_@prop.cliente.ToString' type='hidden' value='@prop.cliente'>
                                                        <input id='hdnnombre_@prop.cliente.ToString' type='hidden' value='@prop.nombre.Trim'>
				                                                <input id='hdnrfc_@prop.cliente.ToString' type='hidden' value='@prop.rfc.Trim'>
                                                      </td>
                                                      <td style="text-align:center"><label>@prop.nombre.Trim</label></td>
                                                      <td style="text-align:center"><label>@prop.rfc.Trim</label></td>
                                                      <td style="text-align:center"><label>@IIf(prop.accionista, "Sí", "No")</label></td>
                                                      <td style="text-align:center"><label>@IIf(prop.representante, "Sí", "No")</label></td>
                                                      <td style="text-align:center"><label>@IIf(prop.administrador, "Sí", "No")</label></td>
                                                  </tr>
                                              Next
                                            Else
                                              @<tr>
                                                  <td style="text-align:right"><label></label></td>
                                                  <td style="text-align:center"><label></label></td>
                                                  <td style="text-align:center"><label></label></td>
                                                  <td style="text-align:center"><label></label></td>
                                                  <td style="text-align:center"><label></label></td>
                                                  <td style="text-align:center"><label></label></td>
                                              </tr>
                                            End If                                          
                                        </tbody>
                                      </table>
                                    </div>
                                  </td>
                                  <td>
                                    <div style="display: inline; float: left; padding: 10px; border: 1px solid #D1D2D3;">
                                      <div style="text-align:left">
                                        <br />
                                        <button id="btnconsultarpropietario" type="submit" class="btn btn-bxmas">Consultar</button>
                                        <br />
                                        <br />
                                        <button id="btneliminarpropietario" type="submit" class="btn btn-bxmas">Eliminar</button>
                                        <br />
                                        <br />
                                      </div>
                                    </div>
                                  </td>
                                </tr>
                              </table>
                            </div>
                          </div>
                        </div>
                      </div>

                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="panel panel-default">
              <div class="panel-heading" role="tab" id="heading3">
                <h4 class="panel-title">
                  <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapse3" aria-expanded="false" aria-controls="collapse3">
                    Persona pol&iacute;ticamente expuesta
                  </a>
                </h4>
              </div>
              <div id="collapse3" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading3">

                <div class="panel-body">
                  <div class="panel panel-default">
                    <div class="panel-body highlight">
                      
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              @Html.LabelFor(Function(m) m.pexpuesto, New With {.class = "form-check-label"})
                              @Html.CheckBoxFor(Function(m) m.pexpuesto, New With {.class = "form-check-input"})
                            </div>
                          </div>
                        </div>
                        <div class="col-md-4"></div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              @Html.LabelFor(Function(m) m.puestopublico, New With {.class = "control-label"})
                              @Html.TextBoxFor(Function(m) m.puestopublico, New With {.Class = "form-control", .style = "width: 300px;"})
                            </div>
                          </div>
                        </div>
                        <div class="col-md-4"></div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              @Html.LabelFor(Function(m) m.trabajo, New With {.class = "control-label"})
                              @Html.TextBoxFor(Function(m) m.trabajo, New With {.Class = "form-control", .style = "width: 300px;"})
                            </div>
                          </div>
                        </div>
                        <div class="col-md-4"></div>
                      </div>

                    </div>
                  </div>
                </div>

                <div class="panel-body">
                  <div class="panel panel-default">
                    <div class="panel-body highlight">

                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">Informaci&oacute;n (Padre)</div>
                          </div>
                        </div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              Buscar por: &nbsp; 
                              <input type="text" id="txtbuscarporpadre" class="form-control" style="width: 200px;"/> &nbsp;
                              <button id="btnbuscarporpadre" type="submit" class="btn btn-bxmas">Buscar</button> &nbsp;
                              <button id="btnnuevopadre" type="submit" class="btn btn-bxmas">Nuevo</button>
                            </div>
                          </div>
                        </div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              <select id="cboresultpadre" class="form-control dropdown" style="min-width: 300px"></select> &nbsp;
                              <button id="btnasignarpadre" type="submit" class="btn btn-bxmas">Asignar</button>
                            </div>
                          </div>
                        </div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              <label>Nombre: </label> &nbsp;
                              @Html.TextBoxFor(Function(m) m.persona_padre.nombre, New With {.Class = "form-control", .style = "width: 300px;"}) &nbsp;
                              <button id="btnconsultarpadre" type="submit" class="btn btn-bxmas">Consultar</button> &nbsp; 
                              <button id="btneliminarpadre" type="submit" class="btn btn-bxmas">Borrar</button> &nbsp; 
                            </div>
                          </div>
                        </div>
                      </div>

                    </div>
                  </div>
                </div>

                <div class="panel-body">
                  <div class="panel panel-default">
                    <div class="panel-body highlight">

                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">Informaci&oacute;n (Madre)</div>
                          </div>
                        </div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              Buscar por: &nbsp; 
                              <input type="text" id="txtbuscarpormadre" class="form-control" style="width: 200px;"/> &nbsp;
                              <button id="btnbuscarpormadre" type="submit" class="btn btn-bxmas">Buscar</button> &nbsp;
                              <button id="btnnuevamadre" type="submit" class="btn btn-bxmas">Nuevo</button>
                            </div>
                          </div>
                        </div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              <select id="cboresultmadre" class="form-control dropdown" style="min-width: 300px"></select> &nbsp;
                              <button id="btnasignarmadre" type="submit" class="btn btn-bxmas">Asignar</button>
                            </div>
                          </div>
                        </div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              <label>Nombre: </label> &nbsp;
                              @Html.TextBoxFor(Function(m) m.persona_madre.nombre, New With {.Class = "form-control", .style = "width: 300px;"}) &nbsp;
                              <button id="btnconsultarmadre" type="submit" class="btn btn-bxmas">Consultar</button> &nbsp; 
                              <button id="btneliminarmadre" type="submit" class="btn btn-bxmas">Borrar</button> &nbsp; 
                            </div>
                          </div>
                        </div>
                      </div>

                    </div>
                  </div>
                </div>

                <div class="panel-body">
                  <div class="panel panel-default">
                    <div class="panel-body highlight">

                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">Informaci&oacute;n (Hijos)</div>
                          </div>
                        </div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              Buscar por: &nbsp; 
                              <input type="text" id="txtbuscarporhijos" class="form-control" style="width: 200px;"/> &nbsp;
                              <button id="btnbuscarporhijos" type="submit" class="btn btn-bxmas">Buscar</button> &nbsp;
                              <button id="btnnuevohijo" type="submit" class="btn btn-bxmas">Nuevo</button>
                            </div>
                          </div>
                        </div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              <select id="cboresulthijos" class="form-control dropdown" style="min-width: 300px"></select> &nbsp;
                              <button id="btnasignarhijo" type="submit" class="btn btn-bxmas">Asignar</button>
                            </div>
                          </div>
                        </div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              
                              <table class="table table-hover" style="width:100%; padding:0px; border-collapse: collapse; border-spacing:0px">
                                <tr>
                                  <td style="vertical-align:top">
                                    <div class="table-responsive">
                                      <table class="table table-hover">
                                        <thead>
			                                      <tr>
				                                      <th>
					                                      Cliente
				                                      </th>
				                                      <th>
					                                      Nombre
				                                      </th>
				                                      <th>
					                                      R.F.C.
				                                      </th>
			                                      </tr>
	                                      </thead>
	                                      <tbody >
                                          @If (Model.persona_hijos.Count > 0) Then
                                              For Each hijo In Model.persona_hijos
                                                @<tr>
                                                    <td style="text-align:right">
                                                        <label>@hijo.cliente.ToString.PadLeft(6, "0")</label>
				                                                <input id='hdncliente_@hijo.cliente.ToString' type='hidden' value='@hijo.cliente'>
				                                                <input id='hdnnombre_@hijo.cliente.ToString' type='hidden' value='@hijo.nombre.Trim'>
				                                                <input id='hdnrfc_@hijo.cliente.ToString' type='hidden' value='@hijo.rfc.Trim'>
                                                    </td>
                                                    <td style="text-align:center">
                                                      <label>@hijo.nombre.Trim</label>
                                                    </td>
                                                    <td style="text-align:center">
                                                      <label>@hijo.rfc.Trim</label>
                                                    </td>
                                                 </tr>
                                              Next
                                            Else
                                              @<tr>
                                                  <td style="text-align:right"><label></label></td>
                                                  <td style="text-align:center"><label></label></td>
                                                  <td style="text-align:center"><label></label></td>
                                               </tr>
                                            End If
	                                      </tbody>
                                      </table>
                                    </div>
                                  </td>
                                  <td>
                                    <div style="display: inline; float: left; padding: 10px; border: 1px solid #D1D2D3;">
                                      <div style="text-align:left">
                                        <br />                                  
                                        <button id="btnconsultarhijo" type="submit" class="btn btn-bxmas">Consultar</button>
                                        <br />
                                        <br />
                                        <button id="btneliminarhijo" type="submit" class="btn btn-bxmas">Borrar</button>
                                        <br />
                                        <br />
                                      </div>
                                    </div>
                                  </td>
                                </tr>
                              </table>

                            </div>
                          </div>
                        </div>
                      </div>

                    </div>
                  </div>
                </div>

                <div class="panel-body">
                  <div class="panel panel-default">
                    <div class="panel-body highlight">

                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">Informaci&oacute;n (Conyugue)</div>
                          </div>
                        </div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              Buscar por: &nbsp; 
                              <input type="text" id="txtbuscarporconyugue" class="form-control" style="width: 200px;"/> &nbsp;
                              <button id="btnbuscarporconyugue" type="submit" class="btn btn-bxmas">Buscar</button> &nbsp;
                              <button id="btnnuevoconyugue" type="submit" class="btn btn-bxmas">Nuevo</button>
                            </div>
                          </div>
                        </div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              <select id="cboresultconyugue" class="form-control dropdown" style="min-width: 300px"></select> &nbsp;
                              <button id="btnasignarconyugue" type="submit" class="btn btn-bxmas">Asignar</button>
                            </div>
                          </div>
                        </div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              <label>Nombre: </label> &nbsp;
                              @Html.TextBoxFor(Function(m) m.persona_conyugue.nombre, New With {.Class = "form-control", .style = "width: 300px;"}) &nbsp;
                              <button id="btnconsultarconyugue" type="submit" class="btn btn-bxmas">Consultar</button> &nbsp; 
                              <button id="btneliminarconyugue" type="submit" class="btn btn-bxmas">Borrar</button> &nbsp; 
                            </div>
                          </div>
                        </div>
                      </div>

                    </div>
                  </div>
                </div>

                <div class="panel-body">
                  <div class="panel panel-default">
                    <div class="panel-body highlight">

                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">Informaci&oacute;n (Hermano/s)</div>
                          </div>
                        </div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              Buscar por: &nbsp; 
                              <input type="text" id="txtbuscarporhermanos" class="form-control" style="width: 200px;"/> &nbsp;
                              <button id="btnbuscarporhermanos" type="submit" class="btn btn-bxmas">Buscar</button> &nbsp;
                              <button id="btnnuevohermano" type="submit" class="btn btn-bxmas">Nuevo</button>
                            </div>
                          </div>
                        </div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              <select id="cboresulthermanos" class="form-control dropdown" style="min-width: 300px"></select> &nbsp;
                              <button id="btnasignarhermano" type="submit" class="btn btn-bxmas">Asignar</button>
                            </div>
                          </div>
                        </div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              
                              <table class="table table-hover" style="width:100%; padding:0px; border-collapse: collapse; border-spacing:0px">
                                <tr>
                                  <td style="vertical-align:top">
                                    <div class="table-responsive">
                                      <table class="table table-hover">
                                        <thead>
			                                      <tr>
				                                      <th>
					                                      Cliente
				                                      </th>
				                                      <th>
					                                      Nombre
				                                      </th>
				                                      <th>
					                                      R.F.C.
				                                      </th>
			                                      </tr>
	                                      </thead>
	                                      <tbody >
                                          @If (Model.persona_hermanos.Count > 0) Then
                                              For Each hermano In Model.persona_hermanos
                                                @<tr>
                                                    <td style="text-align:right">
                                                        <label>@hermano.cliente.ToString.PadLeft(6, "0")</label>
				                                                <input id='hdncliente_@hermano.cliente.ToString' type='hidden' value='@hermano.cliente'>
				                                                <input id='hdnnombre_@hermano.cliente.ToString' type='hidden' value='@hermano.nombre.Trim'>
				                                                <input id='hdnrfc_@hermano.cliente.ToString' type='hidden' value='@hermano.rfc.Trim'>
                                                    </td>
                                                    <td style="text-align:center">
                                                      <label>@hermano.nombre.Trim</label>
                                                    </td>
                                                    <td style="text-align:center">
                                                      <label>@hermano.rfc.Trim</label>
                                                    </td>
                                                 </tr>
                                              Next
                                            Else
                                              @<tr>
                                                  <td style="text-align:right"><label></label></td>
                                                  <td style="text-align:center"><label></label></td>
                                                  <td style="text-align:center"><label></label></td>
                                               </tr>
                                            End If
	                                      </tbody>
                                      </table>
                                    </div>
                                  </td>
                                  <td>
                                    <div style="display: inline; float: left; padding: 10px; border: 1px solid #D1D2D3;">
                                      <div style="text-align:left">
                                        <br />                                  
                                        <button id="btnconsultarhermano" type="submit" class="btn btn-bxmas">Consultar</button>
                                        <br />
                                        <br />
                                        <button id="btneliminarhermano" type="submit" class="btn btn-bxmas">Borrar</button>
                                        <br />
                                        <br />
                                      </div>
                                    </div>
                                  </td>
                                </tr>
                              </table>

                            </div>
                          </div>
                        </div>
                      </div>

                    </div>
                  </div>
                </div>

              </div>
            </div>
            <div class="panel panel-default">
              <div class="panel-heading" role="tab" id="heading4">
                <h4 class="panel-title">
                  <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapse4" aria-expanded="false" aria-controls="collapse4">
                    Persona pol&iacute;ticamente expuesta asimilada
                  </a>
                </h4>
              </div>
              <div id="collapse4" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading4">
                <div class="panel-body">
                  <div class="panel panel-default">
                    <div class="panel-body highlight">
                       
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              @Html.LabelFor(Function(m) m.pexpuestoasimilado, New With {.class = "form-check-label"})
                              @Html.CheckBoxFor(Function(m) m.pexpuestoasimilado, New With {.class = "form-check-input"})
                            </div>
                          </div>
                        </div>
                        <div class="col-md-4"></div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              Buscar por: &nbsp; 
                              <input type="text" id="txtbuscarporasimilado" class="form-control" style="width: 200px;"/> &nbsp;
                              <button id="btnbuscarporasimilado" type="submit" class="btn btn-bxmas">Buscar</button> &nbsp;
                              <button id="btnnuevoasimilado" type="submit" class="btn btn-bxmas">Nuevo</button>
                            </div>
                          </div>
                        </div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              <select id="cboresultasimilado" class="form-control dropdown" style="min-width: 300px"></select> &nbsp;
                              <button id="btnasignarasimilado" type="submit" class="btn btn-bxmas">Asignar</button>
                            </div>
                          </div>
                        </div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              <label>Nombre: </label> &nbsp;
                              @Html.TextBoxFor(Function(m) m.persona_asimilado.nombre, New With {.Class = "form-control", .style = "width: 300px;"}) &nbsp;
                              <button id="btnconsultarasimilado" type="submit" class="btn btn-bxmas">Consultar</button> &nbsp; 
                              <button id="btneliminarasimilado" type="submit" class="btn btn-bxmas">Borrar</button> &nbsp; 
                            </div>
                          </div>
                        </div>
                      </div>

                      <br />
                      <div class="row">
                        <div class="col-md-8">
                          <div class="form-inline">
                            <div class="form-group">
                              @Html.LabelFor(Function(m) m.peprelacion, New With {.class = "control-label"})
                              @Html.TextBoxFor(Function(m) m.peprelacion, New With {.Class = "form-control", .style = "width: 300px;"})
                            </div>
                          </div>
                        </div>
                        <div class="col-md-4"></div>
                      </div>

                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>

        </div>

        <!-- INFO CONTABLE -->
        <div class="tab-pane fade" id="nav-infcontable" role="tabpanel" aria-labelledby="nav-infcontable-tab">
          <p>Informaci&oacute;n contable</p>

          <div class="col-md-6">

            <div class="row">
              <div class="col-md-8">
                <div class="form-inline">
                  <div class="form-group">
                    @Html.LabelFor(Function(m) m.fecbalance, New With {.class = "control-label"})
                    <div class='input-group date' id='dpfecbalance' style="width: 200px;">
                      @code
                        Dim sfecbalance = Model.fecbalance.Value.ToString("dd/MM/yyyy", New System.Globalization.CultureInfo("es-mx"))
                        @<input name="fecbalance" class="form-control" id="fecbalance" type="text" value="@sfecbalance" data-val-required="El campo fecha de balance es obligatorio." data-val="true" data-val-date="El campo fecha de balance debe ser una fecha.">
			                  @<span class="input-group-addon">
				                  <span class="glyphicon glyphicon-calendar"></span>
			                  </span>
                      End Code                      
                    </div>
                    @Html.ValidationMessageFor(Function(m) m.fecbalance)
                  </div>
                </div>
              </div>
              <div class="col-md-4"></div>
            </div>

            <br />
            <div class="row">
              <div class="col-md-8">
                <div class="form-inline">
                  <div class="form-group" style="color:red;">
                    (M&aacute;s reciente)
                  </div>
                </div>
              </div>
            </div>

          </div>

          <div class="col-md-6">

            <div class="row">
              <div class="col-md-8">
                <div class="form-inline">
                  <div class="form-group">
                    @Html.LabelFor(Function(m) m.fec_edores, New With {.class = "control-label"})
                    <div class='input-group date' id='dpfec_edores' style="width: 200px;">
                      @code
                        Dim sfec_edores = Model.fec_edores.Value.ToString("dd/MM/yyyy", New System.Globalization.CultureInfo("es-mx"))
                        @<input name="fec_edores" class="form-control" id="fec_edores" type="text" value="@sfec_edores" data-val-required="El campo fecha estado de resultados es obligatorio." data-val="true" data-val-date="El campo fecha estado de resultados debe ser una fecha.">
			                  @<span class="input-group-addon">
				                  <span class="glyphicon glyphicon-calendar"></span>
			                  </span>
                      End Code                      
                    </div>
                    @Html.ValidationMessageFor(Function(m) m.fec_edores)
                  </div>
                </div>
              </div>
              <div class="col-md-4"></div>
            </div>

            <br />
            <div class="row">
              <div class="col-md-8">
                <div class="form-inline">
                  <div class="form-group" style="color:red;">
                    (&Uacute;ltimo ejercicio)
                  </div>
                </div>
              </div>
            </div>

            <br />
            <div class="row">
              <div class="col-md-8">
                <div class="form-inline">
                  @Html.LabelFor(Function(m) m.n, New With {.class = "control-label"})
                  @Html.TextBoxFor(Function(m) m.n, New With {.Class = "form-control", .style = "width: 300px;"})
                </div>
              </div>
            </div>

          </div>
        </div>

        <!-- INFO PERSONAL -->
        <div class="tab-pane fade" id="nav-infpersonal" role="tabpanel" aria-labelledby="nav-infpersonal-tab">
          <p>Informaci&oacute;n personal</p>
        </div>

        <!-- BNC -->
        <div class="tab-pane fade" id="nav-bnc" role="tabpanel" aria-labelledby="nav-bnc-tab">
          <p>BNC</p>
        </div>

        <!-- VARIABLES -->
        <div class="tab-pane fade" id="nav-variables" role="tabpanel" aria-labelledby="nav-variables-tab">
          <p>Variables</p>
        </div>
        
      </div> 
    </div>

  </div>
  
End Using

@section scripts
    <script type="text/javascript">

      $(document).ready(function (e) {
        $('#pills-tab').tab();
        $('#pills-tab a[href="#nav-basicos"]').tab('show');
        $('#dpcltedesde').datetimepicker({ locale: 'es', format: 'DD/MM/YYYY' });
        $('#colonia').attr('disabled', 'disabled');
        $('#colonias').attr('disabled', 'disabled');
        $('#estado').attr('disabled', 'disabled');
        $('#municipio').attr('disabled', 'disabled');

        $('#subactividades').hide();
        $('#subactivtxt').show();
        $('#subactivtxt').attr('disabled', 'disabled');

        $('#riesgos').hide();
        $('#riesgotxt').show();
        $('#riesgotxt').attr('disabled', 'disabled');

        $('#promotores').hide();
        $('#promotortxt').show();
        $('#promotortxt').attr('disabled', 'disabled');

        $('#dpfecbalance').datetimepicker({ locale: 'es', format: 'DD/MM/YYYY' });
        $('#dpfec_edores').datetimepicker({ locale: 'es', format: 'DD/MM/YYYY' });

      });

      $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
        e.target // newly activated tab
        e.relatedTarget // previous active tab
      });

      // #region sececo
      $(document).on('change', '#cp', function (e) {
        cargacbocolonia();
      });

      function cargacbocolonia() {
        $.getJSON("/clientes/consulta_cargacolonias/",
          { cp: $('#cp').val() },
          function (data) {
            fillcbocolonia(data);
          });
      }

      function fillcbocolonia(data) {
        $('#colonias').html('');
        var colonias = JSON.parse(data);
        $.each(colonias, function (idx, item) {
          $('#colonias').append($('<option></option>').val(item.Value).html(item.Text));
        });
        $('#colonias').removeAttr('disabled');
        cargaMuniEdo();
      }

      $(document).on('change', '#colonias', function (e) {
        cargaMuniEdo();
      });

      function cargaMuniEdo() {
        $.getJSON("/clientes/consulta_cargamunicipioestado/",
          {
            cp: $('#cp').val(),
            id_unico: $('#colonias').find('option:selected').val()
          }, function (data) {
            fillMuniEdo(data);
          });
      }

      function fillMuniEdo(data) {
        var edomun = JSON.parse(data);
        $('#estado').val(((edomun.estado == null) || (edomun.estado == undefined)) ? ('') : (edomun.estado));
        $('#municipio').val(((edomun.municipio == null) || (edomun.municipio == undefined)) ? ('') : (edomun.municipio));
      }
      // #endregion

      // #region subactividad
      $(document).on('click', '#btnmodificarsubactiv', function (e) {
        e.preventDefault();
        cargaSubActividades();
        $(this).attr('disabled', 'disabled');
      });

      function cargaSubActividades() {
        $.getJSON("/clientes/consulta_cargasubactividades/",
          {},
          function (data) {
            fillcbosubactividades(data, $('#subactiv').val());
          });
      }

      function fillcbosubactividades(data, valor) {
        var subactivs = JSON.parse(data);
        $.each(subactivs, function (idx, item) {
          $('#subactividades').append(new Option(item.Text, item.Value, false, item.Value == valor ? true : false));
        });
        $('#subactividades').show();
        $('#subactivtxt').hide();
      }

      $(document).on('change', '#subactividades', function (e) {
        $('#subactiv').val($(this).find('option:selected').val());
      });
      // #endregion

      // #region riesgo
      $(document).on('click', '#btnmodificarriesgo', function (e) {
        e.preventDefault();
        cargaRiesgos();
        $(this).attr('disabled', 'disabled');
      });

      function cargaRiesgos() {
        $.getJSON("/clientes/consulta_cargariesgos/",
          {},
          function (data) {
            fillcboriesgos(data, $('#riesgo').val());
          });
      }

      function fillcboriesgos(data, valor) {
        var riesgos = JSON.parse(data);
        $.each(riesgos, function (idx, item) {
          $('#riesgos').append(new Option(item.Text, item.Value, false, item.Value == valor ? true : false));
        });
        $('#riesgos').show();
        $('#riesgotxt').hide();
      }

      $(document).on('change', '#riesgos', function (e) {
        $('#riesgo').val($(this).find('option:selected').val());
      });
      // #endregion

      // #region promotor
      $(document).on('click', '#btnmodificarpromotor', function (e) {
        e.preventDefault();
        cargaPromotores();
        $(this).attr('disabled', 'disabled');
      });

      function cargaPromotores() {
        $.getJSON("/clientes/consulta_cargapromotores/",
          { promotoractivo: $('#promotoractivo').val() },
          function (data) {
            fillcbopromotores(data, $('#promotor').val());
          });
      }

      function fillcbopromotores(data, valor) {
        var riesgos = JSON.parse(data);
        $.each(riesgos, function (idx, item) {
          $('#promotores').append(new Option(item.Text, item.Value, false, item.Value == valor ? true : false));
        });
        $('#promotores').show();
        $('#promotortxt').hide();
      }

      $(document).on('change', '#promotores', function (e) {
        $('#promotor').val($(this).find('option:selected').val());
      });
      // #endregion
    
      $(document).on('click', '#btnriesgopld', function (e) {
        e.preventDefault();
        mensajemodal('En construcción', 'success');
      });

      $(document).on('click', '#btnclientevxmas', function (e) {
        e.preventDefault();
        mensajemodal('En construcción', 'info');
      });

      $(document).on('click', '#btngrupo', function (e) {
        e.preventDefault();
        mensajemodal('En construcción', 'warning');
      });

      $(document).on('click', '#btnpersonalidad', function (e) {
        e.preventDefault();
        mensajemodal('En construcción', 'danger');
      });
      
  </script>  
End Section
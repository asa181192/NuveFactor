@ModelType nuve.Models.ModeloCesionWzd

@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
    ViewData("Title") = "Cesiones"
End Code

@Section Scripts
    <script src="~/Scripts/CatalogosScripts/CesionWzd.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
    <script src="https://cdn.jsdelivr.net/npm/js-cookie@2/src/js.cookie.min.js"></script>
    <script src="~/Scripts/chosen.jquery.js"></script>
    <script src="~/Scripts/moment.js"></script>

End Section

@Section Css
    <link rel="stylesheet" href="~/Content/Formwzd.css" />
    <link rel="stylesheet" href="~/Content/chosen.css" />
End Section



<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="@Request.UrlReferrer.ToString()">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Cesión @Model.cesion - Contrato (@Model.contrato) @Model.nombre  </span>
        </div>
    </div>
</div>



<div class="container" >
    
	    <div class="row center-block ">
		<section>
        <div class="wizard" >
            <div class="wizard-inner">
                <div class="connecting-line"></div>
                <ul class="nav nav-tabs" role="tablist">

                    <li role="presentation" class="active">
                        <a href="#step1" data-toggle="tab" aria-controls="step1" role="tab" title="Generales de cesión">
                             
                            <span class="round-tab" >
                                <i class="glyphicon glyphicon-folder-open" ></i>
                            </span>
                        </a>
                    </li>

                    <li role="presentation" class="disabled">
                        <a href="#step2" data-toggle="tab" aria-controls="step2" role="tab" title="Documentos">
                            <span class="round-tab">
                                <i class="glyphicon glyphicon-pencil"></i>
                            </span>
                        </a>
                    </li>

                    <li role="presentation" class="disabled">
                        <a href="#step3" data-toggle="tab" aria-controls="step3" role="tab" title="Garantía">
                            <span class="round-tab">
                                <i class="glyphicon glyphicon-picture"></i>
                            </span>
                        </a>
                    </li>

                    <li role="presentation" class="disabled">
                        <a href="#step4" data-toggle="tab" aria-controls="step4" role="tab" title="Adeudos liquidados">
                            <span class="round-tab">
                                <i class="glyphicon glyphicon-book"></i>
                            </span>
                        </a>
                    </li>

                    
                    <li role="presentation" class="disabled">
                        <a href="#complete" data-toggle="tab" aria-controls="complete" role="tab" title="Cálculo">
                            <span class="round-tab">
                                <i class="glyphicon glyphicon-ok"></i>
                            </span>
                        </a>
                    </li>
                </ul>
            </div>

            <div class="tab-content" >

                                   <div class="tab-pane active" role="tabpanel" id="step1">

                    @Using Html.BeginForm("CesionWzdUpd", "Catalogos", FormMethod.Post, New With {.class = "popupForm"})
                    @Html.HiddenFor(Function(model) model.contrato)
                    @Html.HiddenFor(Function(model) model.cesion)
                    @Html.HiddenFor(Function(model) model.producto)
                    @Html.HiddenFor(Function(model) model.userid)
                    @Html.HiddenFor(Function(model) model.idtransact)
                    @Html.HiddenFor(Function(model) model.doc)

                        
                        @<div class="row">


                            <div class="col-md-2">
                                <div class="form-group">

                                    @Html.LabelFor(Function(x) x.fec_alta, New With {.class = "control-label"})
                                    @Html.TextBoxFor(Function(x) x.fec_alta, "{0:dd/MM/yyyy}", New With {.class = "form-control input-sm", .Style = "pointer-events : none; width : 100px"})
                                    @Html.ValidationMessageFor(Function(x)  x.fec_alta)
                                </div>
                            </div>

                            <div class="col-md-2">
                                <div class="form-group">
                                    @Html.LabelFor(Function(x) x.fec_vence, New With {.class = "control-label "})
                                    @Html.TextBoxFor(Function(x) x.fec_vence,"{0:dd/MM/yyyy}", New With {.class = "form-control  input-sm", .Style = " width : 100px" ,.autocomplete="off"})
                                    @Html.ValidationMessageFor(Function(x)  x.fec_vence)
                                </div>
                            </div>

                            <div class="col-md-2">
                                <div class="form-group">
                                    @Html.LabelFor(Function(x) x.plazo, New With {.class = "control-label"})
                                    @Html.TextBoxFor(Function(x) x.plazo, New With {.class = "form-control  input-sm", .Style = "pointer-events : none;  width : 50px" })
                                    @Html.ValidationMessageFor(Function(x)  x.plazo)
                                </div>
                            </div>

                            <div class="col-md-2">
                                <div class="form-group">
                                    @Html.LabelFor(Function(x) x.doctos, New With {.class = "control-label"})
                                    <input class = "control-label" type="number" id="doctos" name="doctos" value="1" min="1" max="1000" step="1">
                                    @Html.ValidationMessageFor(Function(x)  x.doctos)
                                </div>
                            </div>


                        </div>

                        @<div class="row">
                            &nbsp;
                        </div>

                        @<div class="row">

                            <div class="col-md-2">
                                <div class="form-group">
                                    @Html.LabelFor(Function(x) x.porc_anti, New With {.class = "control-label"})
                                    @Html.TextBoxFor(Function(x) x.porc_anti, New With {.class = "form-control  input-sm", .Style = "pointer-events : none;  width : 45px"})
                                     @Html.ValidationMessageFor(Function(x) x.porc_anti)
                                </div>
                            </div>

                            <div class="col-md-2">
                                <div class="form-group">
                                    @Html.LabelFor(Function(x) x.tasaoper, New With {.class = "control-label"})
                                    @Html.TextBoxFor(Function(x) x.tasaoper, New With {.class = "form-control   input-sm", .Style = "pointer-events : none;  width : 55px"})
                                    @Html.ValidationMessageFor(Function(x) x.tasaoper)
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    @Html.LabelFor(Function(x) x.tinter, New With {.class = "control-label"})
                                    @Html.DropDownListFor(Function(x) x.tinter, Model.TipointeresDropDown, New With {.class = "form-control  input-sm", .Style = "pointer-events : none;  width : 160px"})
                                    @Html.ValidationMessageFor(Function(x) x.tinter)
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    @Html.LabelFor(Function(x) x.moneda, New With {.class = "control-label"})
                                    @Html.DropDownListFor(Function(x) x.moneda, Model.DivisaDropDown, New With {.class = "form-control", .Style = "pointer-events : none;  width : 100px"})
                                    @Html.ValidationMessageFor(Function(x) x.moneda)
                                </div>
                            </div>

                        </div>

                        @<div class="row">
                            &nbsp;
                        </div>

                        @<div class="row">

                            <div class="form-group">
                                <div class="col-sm-2">
                                    @Html.LabelFor(Function(x) x.importe, New With {.class = "control-label"})
                                    @Html.TextBoxFor(Function(x) x.importe, New With {.class = "form-control input-sm", .Style = "width : 150px"})
                                    @Html.ValidationMessageFor(Function(x)  x.importe)
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-sm-2">
                                    @Html.LabelFor(Function(x) x.impanticipado, New With {.class = "control-label"})
                                    @Html.TextBoxFor(Function(x) x.impanticipado, New With {.class = "form-control input-sm", .Style = "pointer-events : none;  width : 150px"})
                                    @Html.ValidationMessageFor(Function(x) x.impanticipado)
                                </div>
                            </div>


                        </div>

                        @<div class="row">
                            &nbsp;
                        </div>

                        @<div class="row">
                            
                            <div class="col-xs-12">
                                <hr>
                                <ul class="list-inline pull-left">
                                    <li>
                                        <button type="Submit" class="btn btn-default next-step1">Salvar y continuar</button></li>
                                </ul>
                            </div>
                        </div>

                    End Using
                </div>


                <div class="tab-pane" role="tabpanel" id="step2">
                    <div class="panel-heading">
                        @Html.ActionLink("Agregar", "Guardardocto", New With {.iddocto = 0, .contrato = Model.contrato, .idtransact = Model.idtransact, .producto = Model.producto, .cesion=Model.cesion}, New With {.Class = "popup btn bold pull-right"})
                    </div>


                    <div class="row center-block ">
                        <div class="">
                            <div class="table-responsive">
                                <table id="table" class="table cell-border compact hover" style="width: 100%">
                                    <thead>

                                        <tr>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.iddocto)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.docto)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.fec_vence)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.monto)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.interes)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.hono)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.iva)
                                            </th>

                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.nombreDeudor)
                                            </th>

                                        </tr>
                                    </thead>

                                    <tfoot>

                                        <tr>
                                            <th colspan="3" style="text-align: right">Totales </th>
                                            <th style="text-align: right">
                                                <label id="lmonto"></label>
                                            </th>
                                            <th style="text-align: right">
                                                <label id="linteres"></label>
                                            </th>
                                            <th style="text-align: right">
                                                <label id="lhono"></label>
                                            </th>
                                            <th style="text-align: right">
                                                <label id="liva"></label>
                                            </th>
                                            <th style="text-align: right"></th>
                                        </tr>


                                    </tfoot>


                                </table>
                            </div>

                            <hr>
                            <div class="row">
                                <div class="col-xs-12">
                                    <ul class="list-inline pull-left">
                                        <li>
                                            <button type="button" class="btn btn-default prev-step">Anterior</button></li>
                                        <li>
                                            <button type="button" class="btn btn-default next-step">Salvar y continuar</button></li>
                                    </ul>
                                </div>
                            </div>

                        </div>
                    </div>

                </div>
      @*          </div>*@

                <div class="tab-pane" role="tabpanel" id="step3">


                    <div class="row">
                        <div class="panel-heading">
                            @Html.ActionLink("Agregar garantía", "GuardarGarantiaWzd", New With {.garantiaid =0, .contrato = Model.contrato, .idtransact = Model.idtransact, .producto = Model.producto,.cesion = Model.cesion}, New With {.Class = "popup btn bold pull-right"})
                        </div>
                    </div>

                    <div class="row center-block ">
                        <div class="">
                            <div class="table-responsive">
                                <table id="tgarantia" class="table cell-border compact hover" style="width: 100%">
                                    <thead>

                                        <tr>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.garantiaid)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.tipogarantia)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.valor)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.costo)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.cobrado)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.ivacobrado)
                                            </th>
                                            <th>
                                                Editar
                                            </th>

                                            <th>
                                                Cancelar
                                            </th>

                                        </tr>
                                    </thead>

                                    <tfoot>

                                        <tr>
                                            <th colspan="3" style="text-align: right">Totales </th>
                                            <th style="text-align: right">
                                                <label id="lmonto"></label>
                                            </th>
                                            <th style="text-align: right">
                                                <label id="linteres"></label>
                                            </th>
                                            <th style="text-align: right">
                                                <label id="lhono"></label>
                                            </th>
                                            <th style="text-align: right">
                                                <label id="liva"></label>
                                            </th>
                                            <th style="text-align: right"></th>
                                        </tr>


                                    </tfoot>


                                </table>
                            </div>

                            <hr>
                            <div class="row">
                                <div class="col-xs-12">
                                    <ul class="list-inline pull-left">
                                        <li>
                                            <button type="button" class="btn btn-default prev-step">Anterior</button></li>
                                        <li>
                                            <button type="button" class="btn btn-default next-step">Salvar y continuar</button></li>
                                    </ul>
                                </div>
                            </div>

                        </div>
                    </div>



        @*            <div class="row">
                        <div class="col-xs-12">
                            <ul class="list-inline pull-left">
                                <li>
                                    <button type="button" class="btn btn-default prev-step">Anterior</button></li>
                                <li>
                                    <button type="button" class="btn btn-default next-step">Salvar y continuar</button></li>
                            </ul>
                        </div>
                    </div>*@
                
                
                </div>

                <div class="tab-pane" role="tabpanel" id="step4">

                    <div class="row">
                        <div class="panel-heading">
                            @Html.ActionLink("Por pagar", "GuardaradeudosWzd", New With { .contrato = Model.contrato}, New With {.Class = "popup btn bold pull-right"})
                        </div>
                    </div>


                    <div class="">
                        <div class="table-responsive">
                            <table id="tpadeudo" class="table cell-border compact hover" style="width: 100%">

                                <thead>

                                    <tr>
                                        <th>
                                            @Html.DisplayNameFor(Function(model) model.numrec)
                                        </th>

                                        <th>
                                            @Html.DisplayNameFor(Function(model) model.serie)
                                        </th>
                                        <th>
                                            @Html.DisplayNameFor(Function(model) model.tipo)
                                        </th>
                                        <th>
                                            @Html.DisplayNameFor(Function(model) model.docto)
                                        </th>
                                        <th>
                                            @Html.DisplayNameFor(Function(model) model.importe)
                                        </th>
                                        <th>
                                            Editar
                                        </th>
                                        <th>
                                            Cancelar
                                        </th>
                                    </tr>
                                </thead>


                            </table>

                                                <hr>
                            
                            <ul class="list-inline pull-left">
                                <li>
                                    <button type="button" class="btn btn-default prev-step">Anterior</button></li>
                                
                                <li>
                                    <button type="button" class="btn btn-default btn-info-full next-step">Salvar y continuar</button></li>
                            </ul>
                           

                        </div>
                    </div>


                </div>

                <div class="tab-pane" role="tabpanel" id="complete">

                    <h3>Complete</h3>
                    <p>Cesión generada con éxito.</p>

                            <ul class="list-inline pull-left">
                                <li>
                                    <button type="button" class="btn btn-default prev-step">Anterior</button></li>
                            </ul>


                </div>

                <div class="clearfix"></div>
            </div>


        </div>
        </section>
        </div>

</div>



<div id="dialog-confirm" title="" style="display: none">
  <p>
    <span class="glyphicon glyphicon-remove" style="float: left; margin: 12px 12px 20px 0;"></span>
  </p>
</div>

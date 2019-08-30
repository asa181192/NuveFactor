@ModelType nuve.Models.ModeloCesionVM


@code 
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@Section Scripts
    <script src="~/Scripts/CatalogosScripts/GuardarCesion.js"></script>
End Section


<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="@Request.UrlReferrer.ToString()">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Cesion @Model.Cesion.cesion </span>
        </div>
    </div>
</div>

@Html.HiddenFor(Function(model) model.Cesion.contrato)
@Html.HiddenFor(Function(model) model.Cesion.cesion)
@Html.HiddenFor(Function(model) model.producto)


<div class="panel panel-default">
    <div class="panel-body highlight">
        <ul class="nav nav-tabs" role="tablist">
            <li role="presentation" class="active"><a href="#General" class="nav-link" aria-controls="Generales" role="tab" data-toggle="tab">Generales</a></li>
            <li role="presentation" class="nav-item"><a href="#Documento" class="nav-link" aria-controls="Domicilio" role="tab" data-toggle="tab">Documentos</a></li>
            @If Model.producto = 1 Then
                @<li role="presentation" class="nav-item"><a href="#Garantia" class="nav-link" aria-controls="Garantia" role="tab" data-toggle="tab">Garantias</a></li>               
            End If
        </ul>
        <div class="tab-content">
            <div role="tabpanel" class="tab-pane active" id="General">

                <div class="row">


                    <div class="col-md-6">
                        <div class="form-group">
                            @Html.LabelFor(Function(model) model.Cesion.cesion, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Cesion.cesion, New With {.Class = "form-control", .readonly = True})
                        </div>
                        <div class="form-group ">
                            @Html.LabelFor(Function(model) model.Cesion.fec_alta, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Cesion.fec_alta, "{0:dd/MM/yyyy}", New With {.Class = "form-control", .readonly = True})
                        </div>
                        <div class="form-group ">
                            @Html.LabelFor(Function(model) model.Cesion.fec_vence, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Cesion.fec_vence, "{0:dd/MM/yyyy}", New With {.Class = "form-control", .readonly = True})
                        </div>
                        <div class="form-group ">
                            @Html.LabelFor(Function(model) model.Cesion.importe, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Cesion.importe, New With {.Class = "form-control", .readonly = True})
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            @Html.LabelFor(Function(model) model.Cesion.doctos, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Cesion.doctos, New With {.Class = "form-control", .readonly = True})
                        </div>
                        <div class="form-group">
                            @Html.LabelFor(Function(model) model.Cesion.porc_anti, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Cesion.porc_anti, New With {.Class = "form-control", .readonly = True})
                        </div>
                        <div class="form-group">
                            @Html.LabelFor(Function(model) model.Cesion.plazo, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Cesion.plazo, New With {.Class = "form-control", .readonly = True})
                        </div>
                    </div>
                    <hr />
                </div>
                <hr />
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            @Html.LabelFor(Function(model) model.Cesion.impanticipado, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Cesion.impanticipado, New With {.Class = "form-control", .readonly = True})
                        </div>
                        @If Model.producto = 1 Then
                            @<div class="form-group ">
                                @Html.LabelFor(Function(model) model.Cesion.honorario, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.Cesion.honorario, New With {.Class = "form-control", .readonly = True})
                            </div>  
                        End If
                        @If Model.producto = 1 Then
                            @<div class="form-group">
                                @Html.LabelFor(Function(model) model.Cesion.garantnafin, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.Cesion.garantnafin, New With {.Class = "form-control", .readonly = True})
                            </div> 
                        End If
                        <div class="form-group ">
                            @Html.LabelFor(Function(model) model.Cesion.totalpagar, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Cesion.totalpagar, New With {.Class = "form-control", .readonly = True})
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
                                    @Html.LabelFor(Function(model) model.Cesion.tasaoper, New With {.class = "control-label"})
                                    @Html.TextBoxFor(Function(model) model.Cesion.tasaoper, New With {.Class = "form-control", .readonly = True})
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    @Html.LabelFor(Function(model) model.Cesion.interes, New With {.class = "control-label"})
                                    @Html.TextBoxFor(Function(model) model.Cesion.interes, New With {.Class = "form-control", .readonly = True})
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            @Html.LabelFor(Function(model) model.Cesion.tasa_ord, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Cesion.tasa_ord, New With {.Class = "form-control", .readonly = True})
                        </div>
                        @If Model.producto = 1 Then
                            @<div class="form-group">
                                @Html.LabelFor(Function(model) model.Cesion.ivaganafin, New With {.class = "control-label"})
                                @Html.TextBoxFor(Function(model) model.Cesion.ivaganafin, New With {.Class = "form-control", .readonly = True})
                            </div>    
                        End If
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group ">
                            @Html.LabelFor(Function(model) model.Cesion.numreccta, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Cesion.numreccta, New With {.Class = "form-control", .readonly = True})
                        </div>
                        <div class="form-group">
                            @Html.LabelFor(Function(model) model.Cesion.Beneficiario, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Cesion.Beneficiario, New With {.Class = "form-control", .readonly = True})
                        </div>
                        <div class="form-group">
                            @Html.LabelFor(Function(model) model.Cesion.clabe, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(model) model.Cesion.clabe, New With {.Class = "form-control", .readonly = True})
                        </div>
                    </div>
                </div>
            </div>
            <div role="tabpanel" class="tab-pane" id="Documento">
                <div id="tableContainer" class="tableContainer">
                    @*   <div class="panel-heading">
                            <div >
                            </div>
                        </div>*@
                    <div class="panel-body">
                        <div class="jumbotron">
                            <div class="table-responsive">
                                <table id="table" class="table cell-border compact hover" style="width: 100%">
                                    <thead>
                                        <tr>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.Doctos.iddocto)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.Doctos.docto)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.Doctos.fec_vence)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.Doctos.NombreDeudor)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.Doctos.monto)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.Doctos.importe)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.Doctos.descto)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.Doctos.interes)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.Doctos.hono)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.Doctos.iva)
                                            </th>
                                        </tr>
                                    </thead>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div role="tabpanel" class="tab-pane" id="Garantia">

                <div id="tableContainer1" class="tableContainer">
                    <div class="panel-body">
                        <div class="jumbotron">
                            <div class="table-responsive">
                                <table id="table2" class="table cell-border compact hover" style="width: 100%">
                                    <thead>
                                        <tr>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.Garantia.tipo)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.Garantia.valor)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.Garantia.porcentaje)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.Garantia.costo)
                                            </th>
                                            <th>
                                                @Html.DisplayNameFor(Function(model) model.Garantia.cobrado)
                                            </th>
                                            <th>Consulta
                                            </th>
                                        </tr>
                                    </thead>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</div>


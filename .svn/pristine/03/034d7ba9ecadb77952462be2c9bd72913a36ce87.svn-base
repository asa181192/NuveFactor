@ModelType nuve.Reportes.modelohistoriaDoc

@Code
    ViewData("Title") = "HistoriaDocumento"
End Code

@section scripts
    <script src="~/Scripts/Reportes/histDocumento.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
    <script src="https://cdn.jsdelivr.net/npm/js-cookie@2/src/js.cookie.min.js"></script>
End Section

<style>
    .form-inline > * {
        margin: 10px 5px;
    }
</style>



<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="@Request.UrlReferrer.ToString()">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>História de un documento</span>
        </div>
    </div>
</div>



<div class="panel panel-default">
    <div class="panel-body">
        <div class="form-inline">
            <div class="row">
                <div class="form-group col-sm-3">
                    @Html.LabelFor(Function(x) x.contrato, New With {.class = "control-label col-lg-4"})
                    <div class="col-lg-8">
                        @Html.TextBoxFor(Function(x) x.contrato, New With {.class = "form-control"})
                    </div>
                </div>
                <div class="form-group col-sm-3">
                    @Html.LabelFor(Function(x) x.nombreCliente, New With {.class = "control-label col-lg-4"})
                    <div class="col-lg-8">
                        @Html.TextBoxFor(Function(x) x.nombreCliente, New With {.class = "form-control", .style="width:350px;max-width:450px" , .ReadOnly = True})
                    </div>
                </div>                
            </div>
            <div class="row">
                <div class="form-group col-sm-3">
                    @Html.LabelFor(Function(x) x.docto, New With {.class = "control-label col-lg-4" })
                    <div class="col-lg-8">
                        @Html.TextBoxFor(Function(x) x.nombreDocumento, New With {.class = "form-control" , .style="width:350px;max-width:450px"})
                    </div>
                </div>
                <div class="form-group col-sm-3" style="margin-left:100px">
                    <a href="../Reportes/consultarContratoDocumento/" class="consulta btn material-btn main-container__column">consultar</a>
                </div>
            </div>
            <div class="proveedor row" hidden="true">
                <div class="form-group col-sm-3">
                    @Html.Label("Proveedor", New With {.class = "control-label col-lg-4"})
                    <div class="col-lg-8">
                        <select id="proveedor" class="form-control dropdown" ></select>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        @code
            Dim DropDown = New List(Of SelectListItem)
            DropDown.Add(New SelectListItem With {.Value = 1, .Text = "FACTORAJE CON RECURSO"})
            DropDown.Add(New SelectListItem With {.Value = 11, .Text = "FACTORAJE A PROVEEDORES ELECTRONICO"})
            DropDown.Add(New SelectListItem With {.Value = 13, .Text = "PAGO ELECTRONICO NAFIN"})
            DropDown.Add(New SelectListItem With {.Value = 17, .Text = "PAGO ELECTRONICO FIRA"})
            
            Dim divisa = New List(Of SelectListItem)({
                            New SelectListItem() With {
                                              .Value = 1,
                                              .Text = "MXN"
                                              },
                            New SelectListItem() With {
                                              .Value = 2,
                                              .Text = "DLLS"
                                              }
                                           }).ToList()
        End Code
        <div class="form-inline">
            <div class="row">
                <div class="form-group col-sm-3">
                    @Html.Label("Nombre docto", New With {.class = "control-label col-lg-4"})
                    <div class="col-lg-8">
                        @Html.TextBoxFor(Function(x) x.docto, New With {.class = "form-control", .ReadOnly = True})
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-sm-3">
                    @Html.Label("Producto ", New With {.class = "control-label col-lg-4"})
                    <div class="col-lg-8">
                        @Html.DropDownListFor(Function(x) x.producto, DropDown, New With {.Class = "form-control dropdown", .ReadOnly = True})
                    </div>
                </div>
                <div class="form-group col-sm-3 col-sm-offset-1">
                    @Html.Label("Moneda ", New With {.class = "control-label col-lg-4"})
                    <div class="col-lg-8">
                        @Html.DropDownListFor(Function(x) x.producto, divisa, New With {.Class = "form-control dropdown", .ReadOnly = True})
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div class="form-inline">
            <div class="row">
                <div class="col-sm-6">
                    <div>Detalle de cesión</div>
                </div>
                <div class="col-sm-6">
                    <div>Detalle del documento</div>
                </div>
            </div>
            <div class="row" style="margin-top: 15px">
                <div class="form-group col-sm-3">
                    @Html.Label("Cesión", New With {.class = "control-label col-lg-4"})
                    <div class="col-lg-8">
                        @Html.TextBoxFor(Function(x) x.cesion, New With {.class = "form-control", .ReadOnly = True})
                    </div>
                </div>
                <div class="form-group col-sm-3">
                    @Html.Label("Tasa", New With {.class = "control-label col-lg-4"})
                    <div class="col-lg-8">
                        @Html.TextBoxFor(Function(x) x.Tasaoper, New With {.class = "form-control", .ReadOnly = True})
                    </div>
                </div>
                <div class="form-group col-sm-3">
                    @Html.Label("Fecha de vmto", New With {.class = "control-label col-lg-4"})
                    <div class="col-lg-8">

                        @Html.TextBoxFor(Function(x) x.fecvencedocto, New With {.class = "form-control", .ReadOnly = True})
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-sm-3">
                    @Html.Label("Alta", New With {.class = "control-label col-lg-4"})
                    <div class="col-lg-8">
                        @Html.TextBoxFor(Function(x) x.fec_alta, New With {.class = "form-control", .ReadOnly = True})
                    </div>
                </div>
                <div class="form-group col-sm-3">
                    @Html.Label("Pge", New With {.class = "control-label col-lg-4"})
                    <div class="col-lg-8">
                        @Html.TextBoxFor(Function(x) x.porcanti, New With {.class = "form-control", .ReadOnly = True})
                    </div>
                </div>
                <div class="form-group col-sm-3">
                    @Html.Label("Saldo", New With {.class = "control-label col-lg-4"})
                    <div class="col-lg-8">
                        @Html.TextBoxFor(Function(x) x.saldo, New With {.class = "form-control", .ReadOnly = True})
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-sm-3">
                    @Html.Label("Vence", New With {.class = "control-label col-lg-4"})
                    <div class="col-lg-8">
                        @Html.TextBoxFor(Function(x) x.fec_vence, New With {.class = "form-control", .ReadOnly = True})
                    </div>
                </div>
                <div class="form-group col-sm-3">
                    @Html.Label("Importe", New With {.class = "control-label col-lg-4"})
                    <div class="col-lg-8">
                        @Html.TextBoxFor(Function(x) x.importe, New With {.class = "form-control", .ReadOnly = True})
                    </div>
                </div>
            </div>
        </div>

        <hr />
        <div class="row">
            <div class="col-sm-12">
                <div class="form-group">
                    @Html.Label("Historia de pagos", New With {.class = "control-label"})
                    @Html.TextAreaFor(Function(x) x.pagos, 8, 32, New With {.class = "form-control", .ReadOnly = True})
                </div>
            </div>
        </div>


    </div>
</div>





<div>
</div>

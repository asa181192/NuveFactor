@modeltype nuve.Reportes.historiaAdeudoModel


@Code
    ViewData("Title") = "Historia de un documento"
End Code


@section scripts
    <script src="~/Scripts/Reportes/hisAdeudo.js?v=@String.Concat(Today.Day, Today.Month, Today.Year, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second)"></script>
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
            <a href="~/Reportes/Informes">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Historia de un adeudo</span>
        </div>
    </div>
</div>

@code 
    Dim lista = New List(Of SelectListItem)({
                                          New SelectListItem() With {.Text = "A", .Value = "A"},
                                          New SelectListItem() With {.Text = "B", .Value = "B"},
                                          New SelectListItem() With {.Text = "C", .Value = "C"},
                                          New SelectListItem() With {.Text = "D", .Value = "D"}
                                          }).ToList()
End Code


<div class="panel panel-default">
    <div class="panel-body">
        <div class="form-inline">
            <div class="row">
                <div class="form-group col-xs-12 col-sm-3">
                    @Html.LabelFor(Function(x) x.serie, New With {.class = "control-label col-lg-4"})
                    <div class="col-lg-8">
                        @Html.DropDownListFor(Function(x) x.serie, lista, New With {.Class = "form-control dropdown"})
                    </div>

                </div>
                <div class="form-group col-xs-12 col-sm-4">
                    @Html.LabelFor(Function(x) x.docto, New With {.class = "control-label col-lg-4"})
                    <div class="col-lg-8">
                        @Html.TextBoxFor(Function(x) x.docto, New With {.class = "form-control"})
                    </div>
                </div>
                <div class="form-group  col-xs-12 col-sm-4">
                    <div class="col-lg-8">
                        <a href="../Reportes/ConsultaDetalleHistoriaAdeudo/" class="consulta btn material-btn main-container__column">consultar</a>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div class="form-inline">
            <div class="row">
                <div class="form-group col-sm-3">
                    @Html.LabelFor(Function(x) x.contrato, New With {.class = "control-label col-lg-4"})
                    <div class="col-lg-8">
                        @Html.TextBoxFor(Function(x) x.contrato, New With {.class = "form-control" , .ReadOnly=True })
                    </div>
                </div>
                <div class="form-group col-sm-4">
                       @Html.Label("Nombre",New With {.class = "control-label col-lg-4"})
                    <div class="col-lg-8">
                        @Html.TextBoxFor(Function(x) x.nombre, New With {.class = "form-control" , .ReadOnly=True,.style="width:350px;max-width:450px" })
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-sm-3">
                    @Html.LabelFor(Function(x) x.fec_alta, New With {.class = "control-label col-lg-4"})
                    <div class="col-lg-8">
                        @Html.TextBoxFor(Function(x) x.fec_alta, New With {.class = "form-control" , .ReadOnly=True })
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-sm-3">
                    @Html.LabelFor(Function(x) x.importe, New With {.class = "control-label col-lg-4"})
                    <div class="col-lg-8">
                        @Html.TextBoxFor(Function(x) x.importe, New With {.class = "form-control" , .ReadOnly=True })
                    </div>
                </div>
                <div class="form-group col-sm-4">
                    @Html.LabelFor(Function(x) x.saldo, New With {.class = "control-label col-lg-4"})
                    <div class="col-lg-8">
                        @Html.TextBoxFor(Function(x) x.saldo, New With {.class = "form-control" , .ReadOnly=True })
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-xs-12">
                <div class="form-group">
                    @Html.LabelFor(Function(x) x.notas, New With {.class = "control-label"})
                    @Html.TextAreaFor(Function(x) x.notas, 5, 10, New With {.class = "form-control", .ReadOnly = True})
                </div>
            </div>
        </div>

    </div>
</div>
,


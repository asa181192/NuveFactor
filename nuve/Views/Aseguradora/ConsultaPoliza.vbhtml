@ModelType nuve.AseguradoraModels.poliza

@Code
    ViewData("Title") = "ConsultaPoliza"
End Code

@Using Html.BeginForm("GuardarPoliza", "Aseguradora", FormMethod.Post, New With {.id = "popupForm"})
    
    @<div class="form-group">

        @Html.HiddenFor(Function(model) model.idpoliza)

        <div class="form-group">
            <table style="width: 100%; border-collapse: separate; border-spacing: 5px;">
                <tr>
                    <td>@Html.DisplayNameFor(Function(model) model.idaseguradora)</td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.idaseguradora, Model.AseguradoraDropDown, New With {.class = "form-control"})
                    </td>
                </tr>
                <tr>
                    <td>@Html.DisplayNameFor(Function(model) model.poliza)</td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.poliza, New With {.class = "form-control", .autocomplete = "off"})
                        @Html.ValidationMessageFor(Function(model) model.poliza)
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="form-group">
            <table style="width: 100%; border-collapse: separate; border-spacing: 5px;">
                <tr>
                    <td>@Html.DisplayNameFor(Function(model) model.moneda)</td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.moneda, Model.MonedaDropDown, New With {.class = "form-control", .style = "width:150px;"})
                    </td>
                    <td>@Html.DisplayNameFor(Function(model) model.piva)</td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.piva, New With {.class = "form-control inah mon", .style = "width:150px;", .autocomplete = "off", .readonly = "readonly"})
                        @Html.ValidationMessageFor(Function(model) model.piva)
                    </td>
                </tr>
                <tr>
                    <td>@Html.DisplayNameFor(Function(model) model.mvigencia)</td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.mvigencia, Model.VigenciaDropDown, New With {.class = "form-control change", .style = "width:150px;"})
                    </td>
                    <td>@Html.DisplayNameFor(Function(model) model.femision)</td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.femision, "{0:dd/MM/yyyy}", New With {.class = "form-control date", .style = "width:150px;", .autocomplete = "off"})
                        @Html.ValidationMessageFor(Function(model) model.femision)
                    </td>
                </tr>
                <tr>
                    <td>@Html.DisplayNameFor(Function(model) model.fvigencia1)</td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.fvigencia1, "{0:dd/MM/yyyy}", New With {.class = "form-control date", .style = "width:150px;", .autocomplete = "off"})
                        @Html.ValidationMessageFor(Function(model) model.fvigencia1)
                    </td>
                    <td>@Html.DisplayNameFor(Function(model) model.fvigencia2)</td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.fvigencia2, "{0:dd/MM/yyyy}", New With {.class = "form-control date", .style = "width:150px;", .autocomplete = "off"})
                        @Html.ValidationMessageFor(Function(model) model.fvigencia2)
                    </td>
                </tr>
                <tr>
                    <td>@Html.DisplayNameFor(Function(model) model.indemnizacion)</td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.indemnizacion, New With {.class = "form-control mon zero", .style = "width:150px;", .autocomplete = "off"})
                        @Html.ValidationMessageFor(Function(model) model.indemnizacion)
                    </td>
                    <td>@Html.DisplayNameFor(Function(model) model.facturacion)</td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.facturacion, New With {.class = "form-control mon zero", .style = "width:150px;", .autocomplete = "off"})
                        @Html.ValidationMessageFor(Function(model) model.facturacion)
                    </td>
                </tr>
            </table>
        </div>
        <br />

        <div class="form-group">
            <table style="border-collapse: separate; border-spacing: 5px;">
                <thead>
                    <tr>
                        <th colspan="2" style="border-bottom: 1px solid gray">Prima a pagar</th>
                        <th colspan="2" style="border-bottom: 1px solid gray">Anticipo de prima a pagar</th>
                        <th colspan="2" style="border-bottom: 1px solid gray">Gastos de estudio a pagar</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>@Html.DisplayNameFor(Function(model) model.primasubtotal)</td>
                        <td>
                            @Html.TextBoxFor(Function(model) model.primasubtotal, New With {.class = "form-control mon calc zero", .style = "width:150px;", .autocomplete = "off"})
                            @Html.ValidationMessageFor(Function(model) model.primasubtotal)
                        </td>
                        <td>@Html.DisplayNameFor(Function(model) model.primaperiodos)</td>
                        <td>
                            @Html.DropDownListFor(Function(model) model.primaperiodos, Model.PeriodosDropDown, New With {.class = "form-control change", .style = "width:150px;"})
                        </td>
                        <td>@Html.DisplayNameFor(Function(model) model.geperiodos)</td>
                        <td>
                            @Html.DropDownListFor(Function(model) model.geperiodos, Model.PeriodosDropDown, New With {.class = "form-control change", .style = "width:150px;"})
                        </td>
                    </tr>
                    <tr>
                        <td>@Html.DisplayNameFor(Function(model) model.primaiva)</td>
                        <td>
                            @Html.TextBoxFor(Function(model) model.primaiva, New With {.class = "form-control inah mon", .style = "width:150px;", .autocomplete = "off", .readonly = "readonly"})
                            @Html.ValidationMessageFor(Function(model) model.primaiva)
                        </td>
                        <td>@Html.DisplayNameFor(Function(model) model.primaasubtotal)</td>
                        <td>
                            @Html.TextBoxFor(Function(model) model.primaasubtotal, New With {.class = "form-control inah mon", .style = "width:150px;", .autocomplete = "off", .readonly = "readonly"})
                            @Html.ValidationMessageFor(Function(model) model.primaasubtotal)
                        </td>
                        <td>@Html.DisplayNameFor(Function(model) model.gecosto)</td>
                        <td>
                            @Html.TextBoxFor(Function(model) model.gecosto, New With {.class = "form-control mon calc zero", .style = "width:150px;", .autocomplete = "off"})
                            @Html.ValidationMessageFor(Function(model) model.gecosto)
                        </td>
                    </tr>
                    <tr>
                        <td>@Html.DisplayNameFor(Function(model) model.primatotal)</td>
                        <td>
                            @Html.TextBoxFor(Function(model) model.primatotal, New With {.class = "form-control inah mon", .style = "width:150px;", .autocomplete = "off", .readonly = "readonly"})
                            @Html.ValidationMessageFor(Function(model) model.primatotal)
                        </td>
                        <td>@Html.DisplayNameFor(Function(model) model.primaaiva)</td>
                        <td>
                            @Html.TextBoxFor(Function(model) model.primaaiva, New With {.class = "form-control inah mon", .style = "width:150px;", .autocomplete = "off", .readonly = "readonly"})
                            @Html.ValidationMessageFor(Function(model) model.primaaiva)
                        </td>
                        <td>@Html.DisplayNameFor(Function(model) model.geasegurados)</td>
                        <td>
                            @Html.TextBoxFor(Function(model) model.geasegurados, New With {.class = "form-control  calc zero", .style = "width:150px;", .autocomplete = "off"})
                            @Html.ValidationMessageFor(Function(model) model.geasegurados)
                        </td>
                    </tr>
                    <tr>
                        <td>@Html.DisplayNameFor(Function(model) model.primapdescuento)</td>
                        <td>
                            @Html.TextBoxFor(Function(model) model.primapdescuento, New With {.class = "form-control mon calc", .style = "width:150px;", .autocomplete = "off"})
                            @Html.ValidationMessageFor(Function(model) model.primapdescuento)
                        </td>
                        <td>@Html.DisplayNameFor(Function(model) model.primaatotal)</td>
                        <td>
                            @Html.TextBoxFor(Function(model) model.primaatotal, New With {.class = "form-control inah mon", .style = "width:150px;", .autocomplete = "off", .readonly = "readonly"})
                            @Html.ValidationMessageFor(Function(model) model.primaatotal)
                        </td>
                        <td>@Html.DisplayNameFor(Function(model) model.gesubtotal)</td>
                        <td>
                            @Html.TextBoxFor(Function(model) model.gesubtotal, New With {.class = "form-control inah mon", .style = "width:150px;", .autocomplete = "off", .readonly = "readonly"})
                            @Html.ValidationMessageFor(Function(model) model.gesubtotal)
                        </td>
                    </tr>
                    <tr>
                        <td>@Html.DisplayNameFor(Function(model) model.primapagar)</td>
                        <td>
                            @Html.TextBoxFor(Function(model) model.primapagar, New With {.class = "form-control inah mon", .style = "width:150px;", .autocomplete = "off", .readonly = "readonly"})
                            @Html.ValidationMessageFor(Function(model) model.primapagar)
                        </td>
                        <td>@Html.DisplayNameFor(Function(model) model.primaafprimera)</td>
                        <td>
                            @Html.TextBoxFor(Function(model) model.primaafprimera, "{0:dd/MM/yyyy}", New With {.class = "form-control date", .style = "width:150px;", .autocomplete = "off"})
                            @Html.ValidationMessageFor(Function(model) model.primaafprimera)
                        </td>
                        <td>@Html.DisplayNameFor(Function(model) model.geiva)</td>
                        <td>
                            @Html.TextBoxFor(Function(model) model.geiva, New With {.class = "form-control inah mon", .style = "width:150px;", .autocomplete = "off", .readonly = "readonly"})
                            @Html.ValidationMessageFor(Function(model) model.geiva)
                        </td>
                    </tr>
                    <tr>
                        <td>@Html.DisplayNameFor(Function(model) model.primaminima)</td>
                        <td>
                            @Html.TextBoxFor(Function(model) model.primaminima, New With {.class = "form-control mon zero", .style = "width:150px;", .autocomplete = "off"})
                            @Html.ValidationMessageFor(Function(model) model.primaminima)
                        </td>
                        <td></td>
                        <td></td>
                        <td>@Html.DisplayNameFor(Function(model) model.getotal)</td>
                        <td>
                            @Html.TextBoxFor(Function(model) model.getotal, New With {.class = "form-control inah mon", .style = "width:150px;", .autocomplete = "off", .readonly = "readonly"})
                            @Html.ValidationMessageFor(Function(model) model.getotal)
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td>@Html.DisplayNameFor(Function(model) model.geatotal)</td>
                        <td>
                            @Html.TextBoxFor(Function(model) model.geatotal, New With {.class = "form-control inah mon", .style = "width:150px;", .autocomplete = "off", .readonly = "readonly"})
                            @Html.ValidationMessageFor(Function(model) model.geatotal)
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td>@Html.DisplayNameFor(Function(model) model.gefprimera)</td>
                        <td>
                            @Html.TextBoxFor(Function(model) model.gefprimera, "{0:dd/MM/yyyy}", New With {.class = "form-control date", .autocomplete = "off"})
                            @Html.ValidationMessageFor(Function(model) model.gefprimera)
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>



        <div class="form-group">
            <table style="border-collapse: separate; border-spacing: 5px;">
                <tr>
                    <td>@Html.DisplayNameFor(Function(model) model.deducible)</td>
                    <td>
                        @Html.TextBoxFor(Function(model) model.deducible, New With {.class = "form-control mon", .style = "width:150px;", .autocomplete = "off"})
                        @Html.ValidationMessageFor(Function(model) model.deducible)
                    </td>
                    <td>
                        <span class="btn btn-default btn-file">
                        <input type="file">
                        </span>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </div>

        <div class="form-group pull-right">
            <input type="submit" value="Guardar" class="btn bold" />
        </div>
    </div>
    
    
End Using

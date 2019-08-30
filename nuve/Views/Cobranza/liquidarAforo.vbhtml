@ModelType nuve.Models.ModeloAforos

<style>
    .form-group, input {
        font-size: 12px;
    }
</style>

@Using Html.BeginForm("liquidarAforo", "Cobranza", FormMethod.Post, New With {.id = "popupForm"})
    @Html.ValidationSummary(True)
    
    @Html.HiddenFor(Function(x) x.contrato)
    @Html.HiddenFor(Function(x) x.identidad)
    @Html.HiddenFor(Function(x) x.id)
    @Html.HiddenFor(Function(x) x.Moneda)
    @Html.HiddenFor(Function(x) x.monto)
    
    
    @<div class="form-group">
        @Html.LabelFor(Function(model) model.benef, New With {.class = "control-label"})
        @Html.TextBoxFor(Function(model) model.benef, New With {.Class = "form-control" , .readonly = True })
        @Html.ValidationMessageFor(Function(model) model.benef)
    </div>
    
    @<div class="form-group">
        @Html.LabelFor(Function(model) model.pago, New With {.class = "control-label"})
        @Html.TextBoxFor(Function(model) model.pago, New With {.Class = "form-control"})
        @Html.ValidationMessageFor(Function(model) model.pago)
    </div>

      @<div class="form-group">
        @Html.LabelFor(Function(model) model.cartera, New With {.class = "control-label"})
        @Html.TextBoxFor(Function(model) model.cartera, New With {.Class = "form-control", .readonly = True})
        @Html.ValidationMessageFor(Function(model) model.cartera)
    </div>

    @<div class="form-group">
        @Html.LabelFor(Function(model) model.numreccta, New With {.class = "control-label"})
        @Html.DropDownListFor(Function(model) model.numreccta, Model.CuentaLiquidaDropDown, New With {.Class = "form-control dropdown"})
        @Html.ValidationMessageFor(Function(model) model.numreccta)
    </div>
    
  If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.COBRANZA_ACTUALIZAR) Then
    @<div>
        <input type="submit" value="Liquidar" class="btn bold" />
    </div>
    End If
  

    
End Using



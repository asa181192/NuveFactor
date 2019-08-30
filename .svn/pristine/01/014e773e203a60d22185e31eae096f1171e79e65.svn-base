@ModelType nuve.Models.ModeloGarantia

<style>
    .form-group, input {
        font-size: 12px;
    }
</style>

@Using Html.BeginForm("GuardarGarantiaWzdUpd", "Catalogos", FormMethod.Post, New With {.class = "popupWin"})
    
    @Html.HiddenFor(Function(model) model.garantiaid)

    
    @Html.ValidationSummary(True)
    @<div class="form-inline">
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.contrato, New With {.class = "control-label"})
                    @Html.TextBoxFor(Function(model) model.contrato, New With {.Class = "form-control" , .style="width:50%" , .readonly="true"})
                    @Html.ValidationMessageFor(Function(model) model.contrato)
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.cesion, New With {.class = "control-label"})
                    @Html.TextBoxFor(Function(model) model.cesion, New With {.Class = "form-control",.style="width:50%" ,.readonly="true"})
                    @Html.ValidationMessageFor(Function(model) model.cesion)
                </div>
            </div>
        </div>


    </div> 
    @<hr />
    
    @<div class="form-inline">
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                @Html.LabelFor(Function(model) model.codigo)
                @Html.DropDownListFor(Function(model) model.codigo, Model.CodigoGarantiaDropDown, New With {.Class = "form-control dropdown "})
                @Html.ValidationMessageFor(Function(model) model.codigo)
                </div>
            </div>
        </div>
    </div> 
    
    @<div class="row">
        &nbsp;
    </div>
    
     @<div class="form-inline">
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                @Html.LabelFor(Function(model) model.tipo)
                @Html.DropDownListFor(Function(model) model.tipo, Model.TipoGarantiaDropDown, New With {.Class = "form-control dropdown "})
                @Html.ValidationMessageFor(Function(model) model.tipo)
                </div>
            </div>
        </div>
    </div> 
    
           @<div class="row">
        &nbsp;
    </div>
    
    
    @<div class="form-inline">
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                @Html.LabelFor(Function(model) model.valor, New With {.class = "control-label"})
                    @Html.TextBoxFor(Function(model) model.valor, New With {.Class = "form-control", .style = "width:100px"})
                    @Html.ValidationMessageFor(Function(model) model.valor)
                </div>
            </div>
        </div>
    </div> 
    
       @<div class="row">

           &nbsp;
           </div>
    
    
    @<div class="form-inline">
        <div class="row">

            <div class="col-md-4">

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.porcentaje, New With {.class = "control-label"})
                    <input class="control-label" type="number" id="porcentaje" name="porcentaje" value="50" min="1" max="100" step="1">
                    @Html.ValidationMessageFor(Function(model) model.porcentaje)

                </div>
            </div>

            <div class="col-md-4">
                <div class="form-group">

                    @Html.LabelFor(Function(model) model.costo, New With {.class = "control-label"})
                    <input class="control-label" type="number" id="costo" name="costo" value="2.40" min="1" max="100" step=".01">
                    @Html.ValidationMessageFor(Function(model) model.costo)

                   @* @Html.LabelFor(Function(model) model.costo, New With {.class = "control-label"})
                    @Html.TextBoxFor(Function(model) model.costo, New With {.Class = "form-control", .style = "width:100px"})
                    @Html.ValidationMessageFor(Function(model) model.costo)*@
                </div>
            </div>
        </div>
    </div>

       @<div class="row">

           &nbsp;
           </div>
    
    @<div class="form-inline">
        <div class="row">

            <div class="col-md-6">
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.cobrado, New With {.class = "control-label"})
                    @Html.TextBoxFor(Function(model) model.cobrado, New With {.Class = "form-control", .style = "width:100px", .readonly = "true"})
                    @Html.ValidationMessageFor(Function(model) model.cobrado)


                </div>
            </div>

            <div class="col-md-6">
                <div class="form-group">

                    @Html.LabelFor(Function(model) model.ivacobrado, New With {.class = "control-label"})
                    @Html.TextBoxFor(Function(model) model.ivacobrado, New With {.Class = "form-control", .style = "width:100px", .readonly = "true"})
                    @Html.ValidationMessageFor(Function(model) model.ivacobrado)
                </div>

            </div>

        </div>
    </div>

  
  
  @<hr />
   
   
    
    If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.CATALOGOS_ACTUALIZAR) Then
    @<div>
        <input type="submit" value="Guardar" class="btn bold" />
    </div>
    End If
  

    
End Using



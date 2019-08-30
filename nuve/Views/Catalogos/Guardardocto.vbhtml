@ModelType nuve.Models.ModeloDocto

@Section Css
    <link href="https://fonts.googleapis.com/css?family=News+Cycle" rel="stylesheet">
    <style>
        .form-group, input {
            font-size: 12px;
        }
    </style>
End Section



@Using Html.BeginForm("GuardardoctoUpd", "Catalogos", FormMethod.Post, New With {.id = "popupWin"})
    
    @Html.ValidationSummary(True)
    @Html.HiddenFor(Function(model) model.iddocto)
    @Html.HiddenFor(Function(model) model.cesion)
    @Html.HiddenFor(Function(model) model.contrato)
    @Html.HiddenFor(Function(model) model.fec_vence)
    @Html.HiddenFor(Function(model) model.fec_alta)
    @Html.HiddenFor(Function(model) model.monto)
    @Html.HiddenFor(Function(model) model.idtransact)
    
    @<div class="container">


  @*       <div class="row">

            <div class="form-group">
                <div class="col-xs-4">
                    @Html.LabelFor(Function(model) model.idtransact, New With {.class = "control-label"})
                   @Html.TextBoxFor(Function(model) model.idtransact, New With {.Class = "form-control",.style="width:120px"})
                    @Html.ValidationMessageFor(Function(model) model.idtransact)
                </div>
            </div>
        </div>*@

        <div class="row">

            <div class="form-group">
                <div class="col-xs-4">
                    @Html.LabelFor(Function(model) model.cesion, New With {.class = "control-label"})
                   @Html.TextBoxFor(Function(model) model.cesion, New With {.Class = "form-control",.style="width:120px",.Readonly=true})
                    @Html.ValidationMessageFor(Function(model) model.cesion)
                </div>
            </div>
        </div>


        <div class="row">

            <div class="form-group">
                <div class="col-xs-4">
                    @Html.LabelFor(Function(model) model.deudor, New With {.class = "control-label"})
                    @Html.DropDownListFor(Function(model) model.deudor,  Model.AnexoDropDown, " Seleccionar ", New With {.Class = "form-control dropdown", .style="width:350px"})
                    @Html.ValidationMessageFor(Function(model) model.deudor)
                </div>
            </div>
        </div>

        <div class="row">

            <div class="form-group">
                <div class="col-xs-4">

                    @Html.LabelFor(Function(model) model.docto, New With {.class = "control-label"})
                    @Html.TextBoxFor(Function(model) model.docto, New With {.Class = "form-control",.style="width:120px"})
                    @Html.ValidationMessageFor(Function(model) model.docto)

                </div>

            </div>
        </div>

        <div class="row">
            <div class="form-group">

                <div class="col-xs-4">
                    @Html.LabelFor(Function(model) model.dfec_vence, New With {.class = "control-label"})
                    @Html.TextBoxFor(Function(model) model.dfec_vence, "{0:dd/MM/yyyy}", New With {.style = "width:100px", .class = "form-control input-sm",.autocomplete="off"})
                    @Html.ValidationMessageFor(Function(model) model.dfec_vence)
                </div>

            </div>
        </div>

        <div class="row">
            
                <div class="form-group">
                    <div class="col-xs-4">
                    @Html.LabelFor(Function(model) model.dmonto, New With {.class = "control-label"})
                    @Html.TextBoxFor(Function(model) model.dmonto, New With {.style = "width:150px", .class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.dmonto)

                </div>
            </div>
        </div>

        <div class="row  center-block">
    
            <div class="col-xs-12">
                <h5>Ultimo documento guardado: <span class="doc">Sin documento</span></h5>
                <h5>Monto: <span class="monto">0.0</span></h5>
            </div>

        </div>
    </div>
   
      
    
    
    @<div>
        <input type="submit" value="Guardar" class="btn bold" />
    </div>
 

    
End Using



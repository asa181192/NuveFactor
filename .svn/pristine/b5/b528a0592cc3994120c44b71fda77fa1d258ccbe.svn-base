@ModelType nuve.Models.ModeloAnexoVM


@Section Css
    <link href="https://fonts.googleapis.com/css?family=News+Cycle" rel="stylesheet">
    <style>
        .form-group, input {
            font-size: 12px;
        }
    </style>
End Section



@Using Html.BeginForm("GuardarAnexo", "Catalogos", FormMethod.Post, New With {.id = "popupForm"})
    @Html.ValidationSummary(True)        

   @Html.HiddenFor(Function(model) model.Anexo.contrato)
   @Html.HiddenFor(Function(model) model.Anexo.producto)
   @Html.HiddenFor(Function(model) model.Anexo.anexoid)
    
    @<div class="row">
        <div class="col-xs-12">
            @If Model.Anexo.deudor = 0 Then
                @<div class="form-group">
                    @Html.LabelFor(Function(model) model.Anexo.deudor, New With {.class = "control-label"})
                    @Html.TextBoxFor(Function(model) model.Anexo.deudor, New With {.Class = "form-control" , .name ="deudor"})
                    @Html.ValidationMessageFor(Function(model) model.Anexo.deudor)
                </div>  
            Else
                @<div class="form-group">
                    @Html.LabelFor(Function(model) model.Anexo.deudor, New With {.class = "control-label"})
                    @Html.TextBoxFor(Function(model) model.Anexo.deudor, New With {.Class = "form-control", .ReadOnly = True})
                    @Html.ValidationMessageFor(Function(model) model.Anexo.deudor)
                </div>  
    End If

        </div>
        <div class="col-xs-12">
            @If Model.Anexo.producto = 13 Then
                @<div class="form-group">
                    @Html.LabelFor(Function(model) model.Anexo.sobretasa, New With {.class = "control-label"})
                    @Html.TextBoxFor(Function(model) model.Anexo.sobretasa, New With {.Class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.Anexo.sobretasa)
                </div>   
             End If

              @If Model.Anexo.tasadif = True and  Model.Anexo.producto = 11 Then
                @<div class="form-group">
                    @Html.LabelFor(Function(model) model.Anexo.sobretasa, New With {.class = "control-label"})
                    @Html.TextBoxFor(Function(model) model.Anexo.sobretasa, New With {.Class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.Anexo.sobretasa)
                </div>   
             End If

            @If Model.Anexo.tasadif = false and  Model.Anexo.producto = 11 Then
                @<div class="form-group">
                    @Html.LabelFor(Function(model) model.Anexo.sobretasa, New With {.class = "control-label"})
                    @Html.TextBoxFor(Function(model) model.Anexo.sobretasa, New With {.Class = "form-control" , .ReadOnly = true})                    
                </div>   
             End If

             @If Model.Anexo.producto = 1 Then
                @<div class="form-group">
                    @Html.LabelFor(Function(model) model.Anexo.sobretasa, New With {.class = "control-label"})
                    @Html.TextBoxFor(Function(model) model.Anexo.sobretasa, New With {.Class = "form-control" , .ReadOnly=True })           
                </div>   
             End If

              @If Model.Anexo.producto = 17 Then
                @<div class="form-group">
                    @Html.LabelFor(Function(model) model.Anexo.sobretasa, New With {.class = "control-label"})
                    @Html.TextBoxFor(Function(model) model.Anexo.sobretasa, New With {.Class = "form-control" , .ReadOnly=True })                 
                </div>   
             End If

        </div>
        <div class="col-xs-12">
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Anexo.catcte, New With {.class = "control-label"})
                @Html.TextBoxFor(Function(model) model.Anexo.catcte, New With {.Class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.Anexo.catcte)
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Comprador.nombre, New With {.class = "control-label"})
                @Html.TextBoxFor(Function(model) model.Comprador.nombre, New With {.Class = "form-control" , . disabled = True})
                @Html.ValidationMessageFor(Function(model) model.Comprador.nombre)
            </div>
        </div>
        <div class="col-xs-12">
            @If Model.Anexo.producto = 13 Then
                @<div class="form-group">
                    @Html.LabelFor(Function(model) model.Anexo.limite, New With {.class = "control-label"})
                    @Html.TextBoxFor(Function(model) model.Anexo.limite, New With {.Class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.Anexo.limite)
                </div>
             End If

        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="chBox">
                    @Html.CheckBoxFor(Function(model) model.Anexo.activo, New With {.Class = "form-check-input checked"})
                    <span class="checkmark"></span>
                </label>
                @Html.LabelFor(Function(model) model.Anexo.activo, New With {.class = "form-check-label"})
                @Html.ValidationMessageFor(Function(model) model.Anexo.activo)
            </div>
        </div>
    </div>    

    If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.CATALOGOS_ACTUALIZAR) Then
    @<div>
        <input type="submit" value="Guardar" class="btn bold" style="margin-top: 20px" />
    </div>
    End If
  

    
End Using



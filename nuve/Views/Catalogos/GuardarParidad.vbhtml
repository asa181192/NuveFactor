@ModelType nuve.Models.ModeloPar

<div class="head">
    <div class="headForma">
      <div class="headFormaContenido">
        <span>Guardar Paridad</span>
      </div>
    </div>
  </div>

@Using Html.BeginForm("GuardarParidad", "Catalogos", FormMethod.Post ,New With {.id="popupForm" } )
    @Html.ValidationSummary(true)
        
    If Model.fecha Is Nothing Then
          @Html.HiddenFor(Function(model) model.add , New With{.Value = True })     
          @<div class="form-group">
            <label>Fecha</label>
          @Html.TextBoxFor(Function(model) model.fecha, New With {.class = "form-control", .Value = Today.Date.ToShortDateString(), .ReadOnly = True})
        </div>    
    Else
          @Html.HiddenFor(Function(model) model.add , New With{.Value = false }) 
          @<div class="form-group">
            <label>Fecha</label>
          @Html.TextBoxFor(Function(model) model.fecha, New With {.class = "form-control" , .ReadOnly= True}) 
                                                                       
        </div>
    End If

   @<div class="form-group">
        <label>Paridad</label>
        @Html.TextBoxFor(Function(model) model.paridad ,New With {.Class="form-control"})   
        @Html.ValidationMessageFor(Function(model) model.paridad)

    </div>
   @<div class="form-group">
        <label>Udis-Peso</label>
        @Html.TextBoxFor(Function(model) model.udis ,New With {.Class="form-control"}) 
        @Html.ValidationMessageFor(Function(model) model.udis)  
   </div>
       
   @<div>
        <input type="submit" value="Guardar" class="btn bold" />
    </div>

    
End Using



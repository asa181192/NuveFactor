@ModelType nuve.contrasena_cambio

@Code
  ViewData("Title") = "Cambio de contraseña"
End Code

<div class="head">
  <div class="headForma">
    <div class="headFormaContenido">
      <span>@ViewData("Title")</span>
    </div>
  </div>
</div>

<div class="panel panel-default">

@code
  If ViewData("style") = "cambiando" Then
    @<div class="panel-body highlight">    
      La contraseña debe cumplir los siguientes criterios de complejidad:
      <br />
      <ul>
        <li>@ViewData("MinLenght")</li>
        @code
          If ViewData("Caps").ToString.Trim.Length > 0 Then
            @<li>@ViewData("Caps")</li>            
          End If
          If ViewData("SmallCaps").ToString.Trim.Length > 0 Then
            @<li>@ViewData("SmallCaps")</li>            
          End If
          If ViewData("Numbers").ToString.Trim.Length > 0 Then
            @<li>@ViewData("Numbers")</li>            
          End If
          If ViewData("SpeChars").ToString.Trim.Length > 0 Then
            @<li>@ViewData("SpeChars")</li>
          End If
        End Code        
      </ul>
      @ViewData("Nota")
      <br />    
      @Using Html.BeginForm(New With {.ReturnUrl = ViewData("ReturnUrl"), .Class = "form-group"})
        @Html.AntiForgeryToken()
        @Html.ValidationSummary(true)
          @<div class="container">
            <div class="row">
              <div class="form-horizontal">
                <dl class="dl-horizontal">
                  <dt>
                    @Html.LabelFor(Function(m) m.actual, New With {.class = "control-label col-md-2"})
                  </dt>
                  <dd>
                    <div class="col-md-10">                    
                      @Html.PasswordFor(Function(m) m.actual, New With {.Class = "text-box single-line password", .placeholder = "***********************"})
                      @Html.ValidationMessageFor(Function(m) m.actual, "", New With {.class = "text-danger"})
                    </div>
                  </dd>

                  <dt>&nbsp;</dt><dd>&nbsp;</dd>

                  <dt>
                    @Html.LabelFor(Function(m) m.nueva, New With {.class = "control-label col-md-2"})
                  </dt>
                  <dd>
                    <div class="col-md-10">                    
                      @Html.PasswordFor(Function(m) m.nueva, New With {.Class = "text-box single-line password", .placeholder = "***********************"})
                      @Html.ValidationMessageFor(Function(m) m.nueva, "", New With {.class = "text-danger"})
                    </div>
                  </dd>

                  <dt>&nbsp;</dt><dd>&nbsp;</dd>

                  <dt>
                    @Html.LabelFor(Function(m) m.confirmacion, New With {.class = "control-label col-md-2"})
                  </dt>
                  <dd>
                    <div class="col-md-10">                    
                      @Html.PasswordFor(Function(m) m.confirmacion, New With {.Class = "text-box single-line password", .placeholder = "***********************"})
                      @Html.ValidationMessageFor(Function(m) m.confirmacion, "", New With {.class = "text-danger"})
                    </div>
                  </dd>
                </dl>
              </div>
            </div>
         </div>

        @<br />

        @<div class="form-group">
            <div class="col-md-offset-1 col-md-10">
              <input type="submit" value="Enviar" name="btnsubmit" id="btnsubmit" class="btn btn-bxmas btn-large"  /> 
            </div>
         </div>
      End Using

    </div>
  Else    
    @<div class="panel-body highlight">
      <h4>Contraseña cambiada</h4>
      <br />
      La contraseña fue cambiada exitosamente.
      <br />
      <br />
      Para continuar con su sesi&oacute;n de trabajo dir&iacute;gase <a href='@Url.Action("welcome", "Home")'>aqu&iacute;</a>
     </div>
  End If
End Code
  
</div>
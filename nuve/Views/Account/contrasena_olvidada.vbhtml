@ModelType nuve.contrasena_olvidada

@Code
  Layout = Nothing
End Code

<!DOCTYPE html>

<html>
  <head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Signin Template for Bootstrap</title>
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")    
    @Scripts.Render("~/bundles/modernizr")    
    @Styles.Render("~/Content/bootstrap")
    @Styles.Render("~/Content/css")
    <script type="text/javascript">
      window.history.forward();
      window.location.hash = 'no-back-button';
      window.location.hash = 'Again-No-back-button';
      window.onhashchange = function () { window.location.hash = 'no-back-button'; };
    </script>
  </head>

  <body class="bodyback" >
    <div class="loginWrapper">
      <div class="container v-center">
        <div class="row">
          <div class="col-xs-12">
            <div style="text-align: center">
              <img src="/Images/vepormas.png" alt="BX+" style="margin: 5px auto;" class="hidden-xs" />
              <img src="/Images/vepormas.png" alt="BX+" style="margin: 5px auto; margin-top: 30px" class="visible-xs" />
            </div>
          </div>
        </div>
      </div>
      @code
        Html.RenderPartial("_Alerts")
      End Code
      <div class="loginBox">
        <div class="row">
          <div class="col-xs-12">
            <div style="text-align: center">
              <img src="/Images/conformeenlanuve.png" />
            </div>
            <div style="margin-top: 5px; padding: 0px 0px 0px 0px;">
              @Using Html.BeginForm(New With {.ReturnUrl = ViewData("ReturnUrl"), .Class = "form-signin"})
                @Html.AntiForgeryToken()
                @<div class="form-group row form-group-sm">
                  <h5>@ViewData("Title")</h5>
                 </div>
                @<div class="form-group row form-group-sm">
                  <h5>Para reestablecer la contraseña, escriba su dirección de correo electrónico.
                    <br />
                    Se le enviará una nueva contraseña a su correo electrónico.
                  </h5>
                 </div>
                @<div class="form-group row form-group-sm">
                  @Html.LabelFor(Function(m) m.mail, New With {.class = "col-sm-4 col-form-label small"})
                  <div class="col-sm-6">
                    @Html.TextBoxFor(Function(m) m.mail, New With {.Class = "form-control", .placeholder = "email"})
                    @Html.ValidationMessageFor(Function(m) m.mail, "", New With {.class = "text-danger"})
                  </div>
                </div>
                @<div class="form-group row">
                  <div class="col-sm-3 col-form-label">                        
                  </div>
                  <div class="col-sm-8">
                    <input type="submit" value="Enviar" class="btn btn-black btn-sm" style="width: 100px"/>
                  </div>
                 </div>
                @<div class="form-group">
                    <h6>
                      <small>
                        @Html.ValidationSummary(True)
                      </small>                          
                    </h6>                        
                  </div>
              End Using
            </div>
          </div>
        </div>
      </div>
    </div>      
  </body>

</html>
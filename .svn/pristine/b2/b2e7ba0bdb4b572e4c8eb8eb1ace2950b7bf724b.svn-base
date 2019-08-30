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
    <title>Sesion Expirada</title>
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

  <body class="bodyback">
    <div class="loginWrapper">
      <div class="container v-center">
        <div class="row">
          <div class="col-xs-12">
            <div style="text-align: center">
              <img src="../Images/vepormas.png" alt="BX+" style="margin: 5px auto;" class="hidden-xs" />
              <img src="../Images/vepormas.png" alt="BX+" style="margin: 5px auto; margin-top: 30px" class="visible-xs" />
            </div>
          </div>
        </div>
        <div class="loginBox">
          <div class="row">
            <div class="col-xs-12">
              <div style="margin-top: 5px; padding: 0px 0px 0px 0px;">
                <h4 style="text-align:center">Sesi&oacute;n expirada</h4>
                <br />
                La sesión ha expirado por inactividad. Favor de ingresar nuevamente.
                <br />
                <br />
                <a href='@Url.Action("login", "Account")'>Iniciar sesión</a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </body>

</html>
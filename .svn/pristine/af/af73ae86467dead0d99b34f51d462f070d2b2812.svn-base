@ModelType nuve.Notificaciones.NotificacionesModel



<head>
    <meta charset="utf-8" />
    <title>@ViewData("Title")</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="shortcut icon" href="/Images/favicon.ico" type="image/x-icon">
    <link rel="icon" href="~/Images/favicon.ico" type="image/x-icon">
    <meta name="viewport" content="width=device-width" />
    <link href="https://fonts.googleapis.com/css?family=News+Cycle" rel="stylesheet">
</head>

<style>
    .form-group, input {
        font-size: 12px;
    }
</style>




@Using Html.BeginForm("EnviarNotificaciones", "Notificaciones", FormMethod.Post, New With {.id = "popupForm"})
    @<div class="panel panel-default">
        <br />
        <div class="form-inline">

            <div class="form-group">
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.fecha)
                    @Html.TextBoxFor(Function(model) model.fecha, New With {.class = "form-control", .id = "fecha"})
                </div>
            </div>

            

        </div>

        <br />

        <div class="form-inline">

            <div class="form-group">
                @Html.LabelFor(Function(model) model.recurso, New With {.class = ""})
                @Html.CheckBoxFor(Function(model) model.recurso, New With {.class = "checkbox"})
            </div>
            @*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*@
            <div class="form-group">
                @Html.LabelFor(Function(model) model.acuse, New With {.class = ""})
                @Html.CheckBoxFor(Function(model) model.acuse, New With {.class = "checkbox"})
            </div>

        </div>
        <div class="form-inline">

            <div class="form-group">
                @Html.LabelFor(Function(model) model.proveedor, New With {.class = ""})
                @Html.CheckBoxFor(Function(model) model.proveedor, New With {.class = "checkbox"})
            </div>
            @*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*@
            <div class="form-group">
                @Html.LabelFor(Function(model) model.testigos, New With {.class = ""})
                @Html.CheckBoxFor(Function(model) model.testigos, New With {.class = "checkbox"})
            </div>

        </div>
        <br />
        <div class="from-group">

            <input id="btnGuardar" type="button" value="Continuar" class="btn bold" />
        </div>
        <br />
    </div>   
    
    
      
End Using  
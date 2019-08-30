@ModelType nuve.TesoreriaModel.MovimientosModels

@code
    
    Dim conccta As String = "none"
    Dim visibleEntrada As String
    Dim visibleSalida As String
    
   
    
    
    
    
End Code

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

@Using Html.BeginForm("GuardarMovimiento", "Tesoreria", FormMethod.Post, New With {.id = "popupForm"})
    
    @Html.HiddenFor(Function(model) model.numrec, New With {.value = Model.numrec})
    @Html.HiddenFor(Function(model) model.tipo, New With {.value = Model.tipo})
    @Html.HiddenFor(Function(model) model.cancelado, New With {.value = Model.cancelado})
    @Html.HiddenFor(Function(model) model.idctabanco, New With {.value = Model.idctabanco})
    @Html.ValidationSummary(True)

    
    @code
        If Model.tipo = "DE" Or Model.tipo = "TC" Or Model.tipo = "CC" Then
            visibleEntrada = "display:block"
            visibleSalida = "display:none"
        Else
            visibleEntrada = "display:none"
            visibleSalida = "display:block"
        End If
    
        If Model.tipo = "TR" Then
            conccta = "block"
        End If
        
    End Code
    
    
    @<div class="form-group">

        <div class="form-group">

            <div class="form-inline pull-right">
                @Html.Label("Fecha")
                @Html.TextBoxFor(Function(model) model.fecha, "{0:dd/MM/yyyy}", New With {.Class = "form-control", .value = Today.Date, .ReadOnly = True})
            </div>            
            <br /><br />
            <div class="depositos" style="display:none">

                @Html.Label("Banco")
                @Html.TextBoxFor(Function(model) model.banco, New With {.class = "form-control", .autocomplete = "off"})

                @Html.Label("Docto")
                @Html.TextBoxFor(Function(model) model.docto, New With {.class = "form-control", .autocomplete = "off"})

            </div>

            @Html.Label("Beneficiario", New With {.class = "control-label"})
            @Html.TextBoxFor(Function(model) model.beneficiario, New With {.Class = "form-control", .autocomplete = "off"})
            @Html.ValidationMessageFor(Function(model) model.beneficiario)

            @Html.Label("Concepto", New With {.class = "control-label"})
            @Html.TextAreaFor(Function(model) model.concepto, New With {.Class = "form-control w-100 p-3", .autocomplete = "off"})
            @Html.ValidationMessageFor(Function(model) model.concepto)

            <div id="cargos">
                @Html.Label("Cuenta Contable", New With {.class = "control-label", .style = "display:" + conccta, .autocomplete = "off"})
                @Html.TextBoxFor(Function(model) model.concconta, New With {.Class = "form-control", .Style = "display:" + conccta, .autocomplete = "off"})
            </div>            

            @Html.Label("Importe", New With {.class = "control-label"})
            @Html.TextBoxFor(Function(model) model.salida, New With {.Class = "form-control", .Style = visibleSalida, .autocomplete = "off"})
            @Html.ValidationMessageFor(Function(model) model.salida)
            @Html.TextBoxFor(Function(model) model.entrada, New With {.Class = "form-control", .Style = visibleEntrada, .autocomplete = "off"})
            @Html.ValidationMessageFor(Function(model) model.entrada)

            <div class="depositos form-group" style="display:none">
                @Html.Label("C.Generales")
                @Html.TextBoxFor(Function(model) model.generales, New With{.Class = "form-control", .autocomplete = "off"})                

                @Html.Label("Capital")
                @Html.TextBoxFor(Function(model) model.capital, New With {.class = "form-control", .autocomplete = "off", .readonly = True})

                @Html.Label("Contrato")
                <div class="form-inline col-xs-12">
                    <div class="row form-inline">
                        @Html.TextBoxFor(Function(model) model.contrato, New With {.class = "form-control col-xs-2 "})                        
                        @Html.TextBoxFor(Function(model) model.nombre, New With {.class = "form-control col-xs-10", .readonly = True})
                    </div>
                </div>
            </div>
        </div>
        <br />


    </div>
    @<div class="from-group">
        <input id="btnGuardar" type="submit" value="Guardar" class="btn bold" />
    </div>
      
End Using  
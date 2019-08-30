@ModelType nuve.AseguradoraModels.aseguradora

@Code
    ViewData("Title") = "DetalleAseguradora"
End Code

@Using Html.BeginForm("GuardarAseguradora", "Aseguradora", FormMethod.Post, New With {.id = "popupForm"})
    
    
    @<div class="form-group">

        @Html.HiddenFor(Function(model) model.idaseguradora)

        <div class="form-group">
            @Html.DisplayNameFor(Function(model) model.nombre)
            @Html.TextBoxFor(Function(model) model.nombre, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.nombre) 
        </div>

        <div class="form-group">
            @Html.DisplayNameFor(Function(model) model.calle)
            @Html.TextBoxFor(Function(model) model.calle, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.calle) 
        </div>

        <div class="form-group">
            <div class="form-inline">
                @Html.DisplayNameFor(Function(model) model.noext)
                @Html.TextBoxFor(Function(model) model.noext, New With {.class = "form-control", .width = "80px"})
                @Html.ValidationMessageFor(Function(model) model.noext) 

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                @Html.DisplayNameFor(Function(model) model.noint)
                @Html.TextBoxFor(Function(model) model.noint, New With {.class = "form-control", .width = "80px"})
                @Html.ValidationMessageFor(Function(model) model.noint) 
            </div>
        </div>

        <div class="form-group">
            @Html.DisplayNameFor(Function(model) model.colonia)
            @Html.TextBoxFor(Function(model) model.colonia, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.colonia) 
        </div>

        <div class="form-group">
            @Html.DisplayNameFor(Function(model) model.municipio)
            @Html.TextBoxFor(Function(model) model.municipio, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.municipio) 
        </div>

        <div class="form-group">
            @Html.DisplayNameFor(Function(model) model.estado)
            @Html.TextBoxFor(Function(model) model.estado, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.estado) 
        </div>

        <div class="form-group">
            @Html.DisplayNameFor(Function(model) model.pais)
            @Html.TextBoxFor(Function(model) model.pais, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.pais) 
        </div>

        <div class="form-group">
            <div class="form-inline">
                @Html.DisplayNameFor(Function(model) model.cp)
                @Html.TextBoxFor(Function(model) model.cp, New With {.class = "form-control", .width = "40px"})
                @Html.ValidationMessageFor(Function(model) model.cp) 

                &nbsp;&nbsp;&nbsp;&nbsp;

                @Html.DisplayNameFor(Function(model) model.telefono)
                @Html.TextBoxFor(Function(model) model.telefono, New With {.class = "form-control", .width = "60px"})
                @Html.ValidationMessageFor(Function(model) model.telefono) 
            </div>
        </div>
        
        <div class="form-group">
            @Html.DisplayNameFor(Function(model) model.rfc)
            @Html.TextBoxFor(Function(model) model.rfc, New With {.class = "form-control", .width = "120px"})
            @Html.ValidationMessageFor(Function(model) model.rfc) 
        </div>

        <div class="form-group">
            @Html.DisplayNameFor(Function(model) model.email)
            @Html.TextBoxFor(Function(model) model.email, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.email) 
        </div>

        <div class="form-group pull-right">
            <input type="submit" value="Guardar" class="btn bold" />
        </div>

    </div>  
    
End Using

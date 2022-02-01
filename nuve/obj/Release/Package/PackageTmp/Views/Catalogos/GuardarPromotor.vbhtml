﻿@ModelType nuve.Models.ModeloPromotor

@Code
    If ViewBag.Layout Then
        Layout = "~/Views/Shared/_Layout.vbhtml"
        @<div class="head">
            <div class="headForma">
              <div class="headFormaContenido">
                <span>@(IIf(Model.promotor1 > 0,String.Concat(Model.nombre,"(",Model.promotor1.ToString(),")"),"Nuevo Registro")) </span>           
              </div>       
            </div>  
        </div>  
    Else
    
    @<head>
    <meta charset="utf-8" />
    <title>@ViewData("Title")</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="shortcut icon" href="/Images/favicon.ico" type="image/x-icon">
    <link rel="icon" href="~/Images/favicon.ico" type="image/x-icon">   
    <meta name="viewport" content="width=device-width" />   
   <link href="https://fonts.googleapis.com/css?family=News+Cycle" rel="stylesheet">
     </head>
    End If
End Code


@Using Html.BeginForm("GuardarPromotor", "Catalogos", FormMethod.Post ,New With {.id="popupForm"} )

@<div class="panel panel-default">
    <div class="panel-body highlight">
      
            @Html.ValidationSummary(True)
            
            @If Model IsNot Nothing And Model.promotor1 > 0 Then
                    @Html.HiddenFor(Function(model) model.promotor1)
            End If             
              <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active"><a href="#General" class="nav-link" aria-controls="Generales" role="tab" data-toggle="tab">Generales</a></li>
                <li role="presentation" class="nav-item" ><a href="#Domicilio" class="nav-link" aria-controls="Domicilio" role="tab" data-toggle="tab">Domicilio Fiscal</a></li>               
              </ul>             
              <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="General">                    
                     <div class="row">
                        <div class="col-md-12">
                             <div class="form-group">   
                                    @Html.LabelFor(Function(model) model.nombre , new with {.class = "control-label"})                                
                                    @Html.TextBoxFor(Function(model) model.nombre, New With {.Class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.nombre)
                             </div>
                        </div>
                     </div> 
                     <div class="row">
                        <div class="col-md-6">     
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.empleado, New With {.class = "control-label"})                                
                                @Html.TextBoxFor(Function(model) model.empleado, New With {.Class = "form-control"})
                                @Html.ValidationMessageFor(Function(model) model.empleado) 
                            </div>  
                            <div class="form-group">
                                    @Html.LabelFor(Function(model) model.nombret24 , new with {.class = "control-label"})                                
                                    @Html.TextBoxFor(Function(model) model.nombret24, New With {.Class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.nombret24) 
                            </div>
                            <div class="form-group">
                                    @Html.LabelFor(Function(model) model.cc)                             
                                    @Html.TextBoxFor(Function(model) model.cc ,New With {.Class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.cc)
                            </div>                                                        
                            <div class="form-group">
                                    <div class="form-check">                                
                                        <label class="chBox">
                                                  @Html.CheckBoxFor(Function(model) model.interno,New With {.Class = "form-check-input checked"})
                                                  <span class="checkmark"></span>
                                        </label>
                                        @Html.LabelFor(Function(model) model.interno, New With {.class = "form-check-label"})                                    
                                        @Html.ValidationMessageFor(Function(model) model.interno ) 
                                    </div>
                            </div>
                            <div class="form-group">
                                        <div class="form-check">                                
                                            <label class="chBox">
                                                      @Html.CheckBoxFor(Function(model) model.activo,New With {.Class = "form-check-input checked"})
                                                      <span class="checkmark"></span>
                                            </label>
                                            @Html.LabelFor(Function(model) model.activo, New With {.class = "form-check-label"})                                    
                                            @Html.ValidationMessageFor(Function(model) model.activo ) 
                                        </div>
                             </div>    
                           
                        </div>
                        <div class="col-md-6">
                                <div class="form-group">      
                                    @Html.LabelFor(Function(model) model.codigo , new with {.class = "control-label"})                                
                                    @Html.TextBoxFor(Function(model) model.codigo, New With {.Class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.codigo)   
                                </div>  
                                <div class="form-group">
                                    @code
                                        Dim DropDown = New List(Of SelectListItem)
                                        DropDown.Add(New SelectListItem With {.Value = 1, .Text = "De Cuenta Empresarial"})
                                        DropDown.Add(New SelectListItem With {.Value = 2, .Text = "De Producto Factoraje"})
                                        DropDown.Add(New SelectListItem With {.Value = 3, .Text = "De Agronegocios"})
                                    End Code 
                                </div>
                                <div class="form-group">                                    
                                        @Html.LabelFor(Function(model) model.sucursal , new with {.class = "control-label"} )                                    
                                        @Html.DropDownListFor(Function(model) model.sucursal, Model.SucursalDropDown , New With {.Class = "form-control dropdown"})
                                        @Html.ValidationMessageFor(Function(model) model.sucursal) 
                                </div>
                                <div class="form-group">
                                    @Html.LabelFor(Function(model) model.idt24 , new with {.class = "control-label"})                                
                                    @Html.TextBoxFor(Function(model) model.idt24, New With {.Class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.idt24) 
                                </div>                           
                                <div class="form-group">
                                    @Html.LabelFor(Function(model) model.tipopromo , new with {.class = "control-label"} )                                    
                                    @Html.DropDownListFor(Function(model) model.tipopromo, DropDown , "-- Seleccione --", New With {.Class = "form-control dropdown"})
                                    @Html.ValidationMessageFor(Function(model) model.tipopromo) 
                                </div>
                                     
                        </div>
                    </div>                                                     
                </div>
                <div role="tabpanel" class="tab-pane" id="Domicilio">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                  @Html.LabelFor(Function(model) model.domicilio, new with {.class = "control-label"})
                                  @Html.TextBoxFor(Function(model) model.domicilio,New With {.Class = "form-control"})
                                  @Html.ValidationMessageFor(Function(model) model.domicilio)   
                             </div>
                            <div class="form-group">                                                                   
                                  @Html.LabelFor(Function(model) model.colonia, new with {.class = "control-label"})
                                  @Html.TextBoxFor(Function(model) model.colonia,New With {.Class = "form-control"})
                                  @Html.ValidationMessageFor(Function(model) model.colonia) 
                            </div>
                            <div class="form-group">    
                                  @Html.LabelFor(Function(model) model.municipio , new with {.class = "control-label"})
                                  @Html.TextBoxFor(Function(model) model.municipio,New With {.Class = "form-control"})
                                  @Html.ValidationMessageFor(Function(model) model.municipio)
                            </div> 
                            
                            
                        </div>                     
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group"> 
                                  @Html.LabelFor(Function(model) model.estado , new with {.class = "control-label"})
                                  @Html.TextBoxFor(Function(model) model.estado,New With {.Class = "form-control"})
                                  @Html.ValidationMessageFor(Function(model) model.estado) 
                            </div>
                            <div class="form-group"> 
                                  @Html.LabelFor(Function(model) model.telefono, New With {.class = "control-label"})
                                  @Html.TextBoxFor(Function(model) model.telefono, New With {.Class = "form-control"})
                                  @Html.ValidationMessageFor(Function(model) model.telefono) 
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group"> 
                                  @Html.LabelFor(Function(model) model.cp, New With {.class = "control-label"})
                                  @Html.TextBoxFor(Function(model) model.cp, New With {.Class = "form-control"})
                                  @Html.ValidationMessageFor(Function(model) model.cp) 
                            </div>
                            <div class="form-group"> 
                                  @Html.LabelFor(Function(model) model.rfc, New With {.class = "control-label"})
                                  @Html.TextBoxFor(Function(model) model.rfc, New With {.Class = "form-control"})
                                  @Html.ValidationMessageFor(Function(model) model.rfc) 
                            </div> 
                        </div>
                    </div>
                    </div>                      
              </div>       
        <input type="submit" value="Guardar" class="btn bold" style="margin-top:20px" />
    </div>
</div>

    
End Using
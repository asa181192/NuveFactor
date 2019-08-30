@ModelType nuve.Notificaciones.NotificacionesModel

@Code
    ViewData("Title") = "HistorialNotificaciones"
End Code

@Section Scripts
    <script src="~/Scripts/Notificaciones/Notificaciones.js?v=@String.Concat(Today.Day,Today.Month,Today.Year,TimeOfDay.Hour,TimeOfDay.Minute,TimeOfDay.Second)"></script>
End Section


<div class="head">
    <div class="headForma">
        <div class="headFormaContenido">
            <a href="~/Operaciones/index">
                <img src="~/Images/menu/menuregresar.png" /></a>
            <span>Notificaciones</span>
        </div>
    </div>
</div>

<div id="tableContainer" class="tableContainer">
    <div class="panel-heading">
        <div class="topmargin">
            <div class="form-inline">

                <div class="form-group">
                    <label class="bold">Fecha</label>
                    @*<input id="txtFecha" class="form-control form-inline" />*@
                    @Html.TextBoxFor(Function(model) model.fecha, New With {.class = "form-control", .autocomplete = "off"})
                   
                     <a id="btnConsultar" class="btn glyphicon glyphicon-search form-inline"></a>
                </div>

                &nbsp;

              @If TryCast(Session("Permisos"), List(Of Integer)).Contains(nuve.Permisos.Acciones.FACTURACION_ACTUALIZAR) Then
                @<div class="form-group pull-right">
                    <div class="panel panel-default">
                        <div class="panel-heading">

                          <label>Generar notificaciones&nbsp;&nbsp;&nbsp;</label>

                        <div class="form-group">
                           <input type="button" id="notificar" value="Notificar" class="bold" style="border-radius:5px 5px 5px 5px;"/>
                        </div>
                            
                        </div>
                        
                    </div>

                </div>
              End If

            </div>
        </div>
    </div>
    <div class="panel-body">
        <div class="jumbotron">
            <div class="table-responsive">
                <table id="tableNotificaciones" class="table cell-border compact hover" style="width: 100%">
                    <thead>
                        <tr>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.idrec)
                            </th>
                            
                            <th>
                                @Html.DisplayNameFor(Function(model) model.contrato)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.deudor)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.deudorname)
                            </th>
                            
                            <th>
                                @Html.DisplayNameFor(Function(model) model.envio)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.descrip)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.void)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.filename)
                            </th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
</div>
<div id="dialog-confirm" title="Enviar Notificaciones" style="display:none">
  <p >
      <span class="glyphicon glyphicon-warning-sign" style="float:left; margin:12px 12px 20px 0;"></span>¿Desea generar las notificaciones de la fecha <label id="lblFecha"></label>? </p>
</div>
@ModelType nuve.Models.ModeloWebMonitor


@Html.HiddenFor(Function(model) model.username)
@Html.HiddenFor(Function(model) model.nombre)

<div id="tableContainer" class="tableContainer body">
    <div class="panel-heading">
        <div class="form-inline">
            <div class="form-group">
                @Html.Label("Fecha inicial:", New With {.class = "control-label"})
                <div class="form-group materail-input-block materail-input-block_primary">
                    <input id="fechaini" class='materail-input' type="text" autocomplete="off" />
                </div>
            </div>
            <div class="form-group" style="padding-left: 20px">
                @Html.Label("Fecha final:", New With {.class = "control-label"})
                <div class="form-group materail-input-block materail-input-block_primary">
                    <input id="fechafinal" class='materail-input' type="text" autocomplete="off" />
                </div>
            </div>
            <div class="form-group" style="padding-left: 20px">
                <button class="btn material-btn main-container__column" id="btnconsulta">Consultar</button>
            </div>
        </div>
    </div>
    <div class="panel-body">
        <div class="jumbotron">
            <div class="table-responsive">
                <table id="tableDetalle" class="table cell-border compact hover" style="width: 100%">
                    <thead>
                        <tr>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.fecha)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.action)
                            </th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
</div>




//Inicializacion de variables
var tabla;
var title;
var nombre;
var btnAnexo = $("#anexo")
var btnAnexoLiga = $("#anexo").attr("href")
var btnCesion = $("#cesion")
var btnCesionLiga = $("#cesion").attr("href")
var btnAforo = $("#aforo")
var btnAforoLiga = $("#aforo").attr("href")
var btnAdeudo = $("#adeudo")
var btnAdeudoLiga = $("#adeudo").attr("href")
var btnEdocta = $("#cuenta")
var btnEdoctaLiga = $("#cuenta").attr("href")
var btnCartera = $("#cartera")
var btnCarteraLiga = $("#cartera").attr("href")
var data =
{
    inicializarTabla: function (cliente) {

        tabla = $('#table')
            .DataTable({
                ajax: {
                    "url": "../Catalogos/ObtenerContratos/", // url del controlador a consultar 
                    "Type": "GET",
                    "data": function (d) { d.ClienteID = cliente }, // parametros a enviar al controlador 
                    "dataSrc": function (json) {
                        if (typeof (json.Mensaje) != 'undefined') {
                            mensajemodal(json.Mensaje, 'warning', json.titulo);
                            return {};
                        } else {
                            return json.Results;
                        }
                    }
                },
                initComplete: function (settings, json) {
                    $.Loading(false);
                },
                paging: false, // permite la paginacion en la tabla .               
                ordering: false, // genera ordenamiento de columnas 
                order: [[0, 'desc']], // ordena la primer columna
                responsive: true, // realiza la tabla responsiva en moviles
                destroy: true, // permite que cuando se realize una nueva consulta se destruya la vieja tabla y genere una nueva . 
                aoColumns: [ // permite saber que columnas se usaran del json retornado desde el servidor . 
           {
               data: "Contratos.contrato"
           },
           {
               data: "Producto.nombre"
           },
           {
               data: "Contratos.moneda", "render": function (data) {
                   return data == 1 ? 'MXN' : 'USD'
               }
           },
           {
               data: "Contratos.linea", render: $.fn.dataTable.render.number(',', '.', 2, '')
           },
           {
               data: "Contratos.altalinea"
           },
           {
               data: "Contratos.vencelinea"
           },
           {
               data: "Contratos.bloqueado", "render": function (data) {
                   return data == true ? 'Bloqueado' : 'Activo'
               }
           },
           {
               data: function (data, type, dataToSet) {
                   return '<a class="cancelar" href="../Catalogos/CancelarContrato?Contrato=' + data.Contratos.contrato + '" contrato="' + data.Contratos.contrato + '"><button type="button" class="btn glyphicon glyphicon-remove"></button></a>';
               }, "width": "50px"
           },
           {
               data: function (data, type, dataToSet) {
                   return '<a class="popup" href="../Catalogos/GuardarContrato?clienteid=' + data.Contratos.cliente + '&ContratoId=' + data.Contratos.contrato + '"><button type="button" class="btn glyphicon glyphicon-search"></button></a>';
               }, "width": "50px"
           },
           {
               data: "Producto.id"
           }
                ],
                "columnDefs": [
                    { "className": "dt-center", "targets": [0, 2, 3, 4, 5, 6, 7, 8] },
                    {"targets":[9],"visible" : false}
                ]
            });


    }, //Funcion que inicializa la tabla 
    eventos: function () {
        tabla.on('click', 'a.cancelar', function (e) {          
            $('#dialog-confirm').text("Se dara de baja el contrato : " + $(this).attr("contrato"))
            var url = $(this).attr("href")
            $('#dialog-confirm').dialog({
                    resizable: true,
                    height: "auto",
                    title:"Baja de contrato",
                    width: 400,
                    modal: true,
                    buttons: {
                        "Aceptar": function () {
                            data.ajax(url, "POST", null)
                            $(this).dialog('close')
                        },
                        "Cancelar": function () {
                            $(this).dialog('close')
                        }
                    }
                })
            e.preventDefault()
        });
        tabla.on('click', 'tr', function () {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
                btnAnexo.addClass("disabled")
                btnCesion.addClass("disabled")
                btnAforo.addClass("disabled")
                btnAdeudo.addClass("disabled")
                btnEdocta.addClass("disabled")
                btnCartera.addClass("disabled")
            }
            else {
                tabla.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
                btnAnexo.removeClass('disabled');
                btnCesion.removeClass('disabled');
                btnAforo.removeClass('disabled');
                btnAdeudo.removeClass('disabled');
                btnEdocta.removeClass("disabled");
                btnCartera.removeClass("disabled")
                btnAnexo.attr("href", btnAnexoLiga.replace("_contrato", tabla.row('.selected').data()["Contratos"].contrato).replace("_producto", tabla.row('.selected').data()["Producto"].id))
                btnCesion.attr("href", btnCesionLiga.replace("_contrato", tabla.row('.selected').data()["Contratos"].contrato).replace("_producto", tabla.row('.selected').data()["Producto"].id))
                btnAforo.attr("href", btnAforoLiga.replace("_contrato", tabla.row('.selected').data()["Contratos"].contrato))
                btnAdeudo.attr("href", btnAdeudoLiga.replace("_contrato", tabla.row('.selected').data()["Contratos"].contrato))
                btnEdocta.attr("href", btnEdoctaLiga.replace("_contrato", tabla.row('.selected').data()["Contratos"].contrato))
                btnCartera.attr("href", btnCarteraLiga.replace("_contrato", tabla.row('.selected').data()["Contratos"].contrato))
            }
        });    },
    ajax: function (url, tipo, data) {
        $.ajax({
            type: tipo,
            url: url,
            beforeSend: function () {
                $.Loading(true);
            },
            success: function (data) {
                if (data.Result) {
                    mensajemodal(data.Text, data.color, data.titulo);
                    if (tabla !== undefined) {
                        tabla.ajax.reload(null, false); // False- permite quedarte en la misma pagina despues de actualizar
                    }
                } else {
                    mensajemodal(data.Text, data.color, data.titulo);
                }
            },
            error: function () {
                mensajemodal('Ocurrio un error al consultar la informacion favor de intentar de nuevo!!', 'warning');
            },
            complete: function () {
                $.Loading(false);
            }

        });
    }
}

$(document).ready(function (e) {
    //Esto nos permite Abrir modal dentro de modal . 
    $.fn.modal.Constructor.prototype.enforceFocus = function () { };

    data.inicializarTabla($("#Contrato_cliente").val())
    data.eventos();
});
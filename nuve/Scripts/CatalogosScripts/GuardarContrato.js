var data =
{
    inicializacionControles: function () {

        $("#ContratoForm").find(':input').each(function () {

            var value = $(this).val()
            $(this).val(value.trim())

        });

        if ($("input[name='Contrato.interes']:checked").val() == 1) {
            $(".radios").hide();
        }

        if ($("#Contrato_rebate").is(':checked')) {
          $("#Contrato_rebatepts").prop("disabled", false)
        } else {
          $("#Contrato_rebatepts").prop("disabled", true);
          $("#Contrato_rebatepts").val("0.00")
        }

        if ($("#Contrato_seguro").is(':checked')) {
          $("#Contrato_endoso").prop("disabled", false)
          $("#Contrato_cobertura").prop("disabled", false)
          $("#Contrato_idmapfre").prop("disabled", false)
          $("#Contrato_plazo").prop("disabled", false)
        } else {
          $("#Contrato_endoso").prop("disabled", true)
          $("#Contrato_cobertura").prop("disabled", true)
          $("#Contrato_idmapfre").prop("disabled", true)
          $("#Contrato_plazo").prop("disabled", true)
        }

        $('#Contrato_linea').mask('000,000,000,000.00', { reverse: true });
        $('#Contrato_tasa_ord').mask('000.00', { reverse: true });
        $('#Contrato_tasa_ext').mask('000.00', { reverse: true });
        $('#Contrato_porc_anti').mask('000.00', { reverse: true });
        $('#Contrato_dispercom').mask('0,000,000,000,000.00', { reverse: true });
        $('#Contrato_com_cont').mask('000.00', { reverse: true });
        $('#Contrato_hon_admon').mask('000.00', { reverse: true });
        $('#Contrato_rebatepts').mask('000.00', { reverse: true });

        $('#Contrato_cobertura').mask('0,000,000,000,000.00', { reverse: true });

        $("#Contrato_endoso").datepicker({
            dateFormat: 'dd/mm/yy', language: 'es', locale: 'es'
        })

        $("#Contrato_altalinea").datepicker({
            dateFormat: 'dd/mm/yy', language: 'es', locale: 'es'
        })

        $("#Contrato_vencelinea").datepicker({
            dateFormat: 'dd/mm/yy', language: 'es', locale: 'es'
        })

        $("#Contrato_fec_alta").datepicker({
            dateFormat: 'dd/mm/yy', language: 'es', locale: 'es'
        })

        $("#Contrato_fec_vence").datepicker({
            dateFormat: 'dd/mm/yy', language: 'es', locale: 'es'
        })
    },
    validacionCampos: function () {
        //Usar esta validacion en caso que no sea un PopUP
        $("#ContratoForm").data("validator").settings.ignore = "";
        //al momento de dar click genera popup con todos los errores en el formulario 
        $("#submit").click(function () {
            if (!$("#ContratoForm").valid()) {
               var message = ""
               $("input.input-validation-error").each(function (index) {
                   if (!$("[data-valmsg-for='" + $("input.input-validation-error")[index].getAttribute("id").replace("_", ".") + "']").text() == "") {
                       message = message +"- "+ $("[data-valmsg-for='" + $("input.input-validation-error")[index].getAttribute("id").replace("_", ".") + "']").text() + "<br/>"
                   }                  
                });
                mensajemodal(message, "warning", "Revisar los siguientes campos !!");
            }
        })

        jQuery.validator.addMethod(
            'date',
            function (value, element, params) {
                if (this.optional(element)) {
                    return true;
                };
                var result = false;
                try {
                    $.datepicker.parseDate("dd/mm/yy", value);
                    result = true;
                } catch (err) {
                    result = false;
                }
                return result;
            },
            ''
        );
    },
    eventos: function () {
        $("input[name='Contrato.interes']").on("click", function () {
            if ($(this).val() == 1) {
                $(".radios").hide();
            }
            else {
                $(".radios").show();
            }
        });
    }
}

$(document).ready(function (e) {

    data.inicializacionControles();
    data.validacionCampos();
    data.eventos();
   
    $("#Plazo_Ilimitado").change(function (e) {
        $("#Contrato_plazoopera").val("0")
    });


    $("#Contrato_rebate").change(function (e) {
      
      if ($("#Contrato_rebate").is(':checked')) {
        $("#Contrato_rebatepts").prop("disabled", false)
      }else{
        $("#Contrato_rebatepts").prop("disabled", true);
        $("#Contrato_rebatepts").val("0.00")
      }
     
    });

    $("#Contrato_seguro").change(function (e) {
      

    if ($("#Contrato_seguro").is(':checked')) {
      $("#Contrato_endoso").prop("disabled", false)
      $("#Contrato_cobertura").prop("disabled", false)
      $("#Contrato_idmapfre").prop("disabled", false)
      $("#Contrato_plazo").prop("disabled", false)
    } else {
      $("#Contrato_endoso").prop("disabled", true)
      $("#Contrato_cobertura").prop("disabled", true)
      $("#Contrato_idmapfre").prop("disabled", true)
      $("#Contrato_plazo").prop("disabled", true)
    }

    });


    $(document).on('submit',
          '#ContratoForm',
          function (e) {
              var url = $('#ContratoForm')[0].action;
              $.ajax({
                  type: "POST",
                  url: url,
                  data: $('#ContratoForm').serialize(),
                  beforeSend: function () {
                      $.Loading(true);
                  },
                  success: function (data) {
                      if (data.Result) {
                          mensajemodal(data.Text, data.color, data.titulo);
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

              e.preventDefault();
          });

    // Validacion de tool tip 
    $('#ContratoForm').tooltip({
        items: ".input-validation-error",
        content: function () {
            return $("[data-valmsg-for='" + $(this).attr('id').replace("_", ".") + "']").text();
        }
    });



});
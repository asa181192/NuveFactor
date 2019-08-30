var data =
{
   inicializacionControles : function(){
       $("#GroupPF :input").prop('disabled', true);
       if ($("#grupoemp").is(':checked')) {
           $("#clave").prop('disabled', false);
       } else {
           $("#clave").prop('disabled', true);
       }
       $("#ac_fechaDataTime").datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            ignoreReadonly: true,
            widgetPositioning: {
                horizontal: 'left',
                vertical: 'top'
            }
        });
        $("#ac_fechareDataTime").datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
            ignoreReadonly: true,
            widgetPositioning: {
                horizontal: 'left',
                vertical: 'top'
            }
        });
    },
   validacionCampos: function () {
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
   }
}

$(document).ready(function (e) {

    data.inicializacionControles();
    data.validacionCampos();
    // Eventos 
    $("#pfisica1").change(function (e) {
        $("#GroupPF :input").prop('disabled', false);
        $("#nombre").val("")
        $("#GroupPM :input").prop('disabled', true);
    });

    $("#pfisica").change(function (e) {
        $("#GroupPF :input").prop('disabled', true);
        $("#GroupPF :input").val("")
        $("#GroupPM :input").prop('disabled', false);
    });
    
    $(document).on('submit',
          '#clienteForm',
          function (e) {
              var url = $('#clienteForm')[0].action;
              $.ajax({
                  type: "POST",
                  url: url,
                  data: $('#clienteForm').serialize(),
                  beforeSend: function () {
                      $.Loading(true);
                  },
                  success: function (data) {
                      if (data.Result) {
                          mensajemodal(data.Text, 'success');
                      } else {
                          mensajemodal(data.Text, 'warning');
                      }
                      $(document).dialog('close');
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
    
    $('#grupoemp').click(function () {
        //check if checkbox is checked
        if ($(this).is(':checked')) {
            $("#clave").prop('disabled', false);
        } else {
            $("#clave").prop('disabled', true);
            $("#clave").val("");
        }
    });
    // Validacion de tool tip 
    $('#clienteForm').tooltip({
        items: ".input-validation-error",
        content: function () {
            return $("[data-valmsg-for='" + $(this).attr('id') + "']").text();
        }
    });

    

});
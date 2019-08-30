var data =
{
    inicializacionControles: function () {
              
        $("#popupForm").find(':input').each(function () {

            var value = $(this).val()
            $(this).val(value.trim())

        })
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
           
    $('#rfc').keyup(function () {
        $(this).val($(this).val().toUpperCase());
    });

    $(document).on('submit',
          '#popupForm',
          function (e) {
              var url = $('#popupForm')[0].action;
              $.ajax({
                  type: "POST",
                  url: url,
                  data: $('#popupForm').serialize(),
                  beforeSend: function () {
                      $.Loading(true);
                  },
                  success: function (data) {
                      if (data.Result) {
                          mensajemodal(data.Text, 'success',data.titulo);
                      } else {
                          mensajemodal(data.Text, 'warning', data.titulo);
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
    $('#popupForm').tooltip({
        items: ".input-validation-error",
        content: function () {
            return $("[data-valmsg-for='" + $(this).attr('id') + "']").text();
        }
    });



});
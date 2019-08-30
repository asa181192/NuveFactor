$(document).ready(function (e) {

    $('#timecte').mdtimepicker({ format: 'hh:mm' });
    $('#timeend').mdtimepicker({ format: 'hh:mm' });

    $("#popupForm").find(':input').each(function () {
        var value = $(this).val()
        $(this).val(value.trim())
    });


}).on('submit',
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
                         mensajemodal(data.Text, data.color, data.titulo);                       
                     } else {
                         mensajemodal(data.Text, 'warning');
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
         });;
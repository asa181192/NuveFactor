﻿$(document).ready(function (e) {

    $('#dvflexParidad').click(function () {
        window.location.href = '/Catalogos/paridadCambiaria';
    });

    $('#dvflexProveedores').click(function () {
        window.location.href = '/Catalogos/Proveedores';
    });

    $('#dvflexCompradores').click(function () {
        window.location.href = '/Catalogos/Compradores';
    });

    $('#dvflexMonitor').click(function () {
        window.location.href = '/Catalogos/Monitor';
    });
});
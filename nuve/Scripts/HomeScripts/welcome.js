﻿$(document).ready(function(e) {

    $('#dvflexCatalogos').click(function() {
        window.location.href = '../Catalogos/Index';
    });

    $('#dvflexAdministracion').click(function () {
        window.location.href = '../Admin/Index';
    });

      $('#dvflexCuentasBancos').click(function () {
        window.location.href = '../Tesoreria/Index';
    });

    $('#dvflexOperaciones').click(function () {
      window.location.href = '../Operaciones/Index';
    });

    $('#dvflexPromocion').click(function () {
      window.location.href = '../Promocion/Index';
    });

    $('#dvflexConta').click(function () {
      window.location.href = '../Contabilidad/Index';
    });

    $('#dvflexPortal').click(function () {
      window.location.href = '../Portal/Index';
    });

    $('#dvflexReportes').click(function () {     
      window.location.href = '../Reportes/Informes';
    });

    $('#dvflexAseguradoras').click(function () {
        window.location.href = '../Aseguradora/Index';
    });
        
    $('#dvflexReq').click(function () {
        window.location.href = '../Req/requerimientos';
    });
});
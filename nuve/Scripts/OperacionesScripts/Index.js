﻿$(document).ready(function (e) {


    $('#dvflexcobranza').click(function () {
        window.location.href = '../Cobranza/Index';
    });


    $('#dvflexautoriza').click(function () {
        window.location.href = '../Autoriza/Autoriza';
    });

    $('#dvflexNotificaciones').click(function () {
        window.location.href = '../Notificaciones/HistorialNotificaciones';
    });

    $('#dvflexFacturacion').click(function () {
        window.location.href = '../Facturacion/HistorialFacturas';
    });

    $('#dvflexcomplementopago').click(function () {
        window.location.href = '../Facturacion/complementopago';
    });

    $('#factmenu').click(function () {
        window.location.href = '../Facturacion/index';
    });

    $('#dvflexConsolida').click(function () {
      window.location.href = '../Consolidaciones/bitacora';
    });

    
});
(function ($) {
    'use strict';

    //DIAS DE LA SEMANA
    var lunes = document.getElementById("Lunes");
    var martes = document.getElementById("Martes");
    var miercoles = document.getElementById("Miercoles");
    var jueves = document.getElementById("Jueves");
    var viernes = document.getElementById("Viernes");
    var sabado = document.getElementById("Sabado");
    var domingo = document.getElementById("Domingo");

    $("#cbox1").on("click", function () { //Tiene dias y horarios fijos en la semana

        $('#HoraInicioLunes').val('');
        $('#HoraFinLunes').val('');

        $('#HoraInicioMartes').val('');
        $('#HoraFinMartes').val('');

        $('#HoraInicioMiercoles').val('');
        $('#HoraFinMiercoles').val('');

        $('#HoraInicioJueves').val('');
        $('#HoraFinJueves').val('');

        $('#HoraInicioViernes').val('');
        $('#HoraFinViernes').val('');

        $('#HoraInicioSabado').val('');
        $('#HoraFinSabado').val('');

        $('#HoraInicioDomingo').val('');
        $('#HoraFinDomingo').val('');

        if (lunes.checked == true) {
            $("#Lunes").prop("checked", false);
        }

        if (martes.checked == true) {
            $("#Martes").prop("checked", false);
        }

        if (miercoles.checked == true) {
            $("#Miercoles").prop("checked", false);
        }

        if (jueves.checked == true) {
            $("#Jueves").prop("checked", false);
        }

        if (viernes.checked == true) {
            $("#Viernes").prop("checked", false);
        }

        if (sabado.checked == true) {
            $("#Sabado").prop("checked", false);
        }

        if (domingo.checked == true) {
            $("#Domingo").prop("checked", false);
        }

        $('#dias').show(); //muestro dias de la semana

    });

    $("#cbox2").on("click", function () { //No tiene dias y horarios fijos en la semana
        $('#dias').hide(); //oculto dias de la semana
        $('#horarioLunes').hide(); //oculto la hora de inicio y fin del lunes
        $('#horarioMartes').hide(); //oculto la hora de inicio y fin del martes
        $('#horarioMiercoles').hide(); //oculto la hora de inicio y fin del miercoles
        $('#horarioJueves').hide(); //oculto la hora de inicio y fin del jueves
        $('#horarioViernes').hide(); //oculto la hora de inicio y fin del viernes
        $('#horarioSabado').hide(); //oculto la hora de inicio y fin del sabado
        $('#horarioDomingo').hide(); //oculto la hora de inicio y fin del domingo
    });


        if (lunes.checked == true) {
             $('#horarioLunes').show(); //muestro la hora de inicio y fin del lunes
        }

        if (martes.checked == true) {
            $('#horarioMartes').show(); //muestro la hora de inicio y fin del martes
        }

        if (miercoles.checked == true) {
            $('#horarioMiercoles').show(); //muestro la hora de inicio y fin del miercoles
        }

        if (jueves.checked == true) {
            $('#horarioJueves').show(); //muestro la hora de inicio y fin del jueves
        }

        if (viernes.checked == true) {
            $('#horarioViernes').show(); //muestro la hora de inicio y fin del viernes
        }

        if (sabado.checked == true) {
            $('#horarioSabado').show(); //muestro la hora de inicio y fin del sabado
        }

        if (domingo.checked == true) {
            $('#horarioDomingo').show(); //muestro la hora de inicio y fin del domingo
        }

    //Lunes
    $("#Lunes").on("click", function () {
        if (this.checked == true) {
            $(this).val("1");
            $('#horarioLunes').show(); //muestro la hora de inicio y fin del lunes
        }
        else {
            $('#horarioLunes').hide(); //oculto la hora de inicio y fin del lunes
            $(this).val("0");
        }
    });

    //Martes
    $("#Martes").on("click", function () {
        if (this.checked == true) {
           $(this).val("1");
           $('#horarioMartes').show(); //muestro la hora de inicio y fin del Martes
        }
        else {
            $('#horarioMartes').hide(); //oculto la hora de inicio y fin del Martes
            $(this).val("0");
        }
    });

    //Miercoles
    $("#Miercoles").on("click", function () {
        if (this.checked == true) {
            $(this).val("1");
            $('#horarioMiercoles').show(); //muestro la hora de inicio y fin del Miercoles

        }
        else {
            $('#horarioMiercoles').hide(); //oculto la hora de inicio y fin del Miercoles
            $(this).val("0");
        }
    });

    //Jueves
    $("#Jueves").on("click", function () {
        if (this.checked == true) {
            $(this).val("1");
            $('#horarioJueves').show(); //muestro la hora de inicio y fin del Jueves
        }
        else {
            $('#horarioJueves').hide(); //oculto la hora de inicio y fin del Jueves
            $(this).val("0");
        }
    });

    //Viernes
    $("#Viernes").on("click", function () {
        if (this.checked == true) {
            $(this).val("1");
            $('#horarioViernes').show(); //muestro la hora de inicio y fin del Viernes
        }
        else {
            $('#horarioViernes').hide(); //oculto la hora de inicio y fin del Viernes
            $(this).val("0");
        }
    });

    //Sabado
    $("#Sabado").on("click", function () {
        if (this.checked == true) {
            $(this).val("1");
            $('#horarioSabado').show(); //muestro la hora de inicio y fin del Sabado
        }
        else {
            $('#horarioSabado').hide(); //oculto la hora de inicio y fin del Sabado
            $(this).val("0");
        }
    });

    //Domingo
    $("#Domingo").on("click", function () {
        if (this.checked == true) {
            $(this).val("1");
            $('#horarioDomingo').show(); //muestro la hora de inicio y fin del Domingo
        }
        else {
            $('#horarioDomingo').hide(); //oculto la hora de inicio y fin del Domingo
            $(this).val("0");
        }
    });

})(jQuery);

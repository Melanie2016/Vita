(function ($) {
    'use strict';

    $("#cbox1").on("click", function () { //Tiene inicio y fin
        $('#fechas').show(); //muestro las fechas desde y hasta
        $('#dias').hide(); //oculto dias de la semana
        $('#horarios').hide(); //oculto pregunta de horarios
        $('#mismoHorario').hide(); //oculto mismo horario
        $('#horarioLunes').hide(); //oculto la hora de inicio y fin del lunes
        $('#horarioMartes').hide(); //oculto la hora de inicio y fin del martes
        $('#horarioMiercoles').hide(); //oculto la hora de inicio y fin del miercoles
        $('#horarioJueves').hide(); //oculto la hora de inicio y fin del jueves
        $('#horarioViernes').hide(); //oculto la hora de inicio y fin del viernes
        $('#horarioSabado').hide(); //oculto la hora de inicio y fin del sabado
        $('#horarioDomingo').hide(); //oculto la hora de inicio y fin del domingo
    });

    $("#cbox2").on("click", function () { //No tiene inicio y fin
        $('#fechas').hide(); //oculto las fechas desde y hasta
        $('#dias').show(); //muestro dias de la semana
        $('#horarios').show(); //muestro pregunta de horarios
    });


    $("#cbox3").on("click", function () { //Tiene mismo horario para todos los dias
        $('#mismoHorario').show(); //muestro  mismo horario
        $('#horarioLunes').hide(); //oculto la hora de inicio y fin del lunes
        $('#horarioMartes').hide(); //oculto la hora de inicio y fin del martes
        $('#horarioMiercoles').hide(); //oculto la hora de inicio y fin del miercoles
        $('#horarioJueves').hide(); //oculto la hora de inicio y fin del jueves
        $('#horarioViernes').hide(); //oculto la hora de inicio y fin del viernes
        $('#horarioSabado').hide(); //oculto la hora de inicio y fin del sabado
        $('#horarioDomingo').hide(); //oculto la hora de inicio y fin del domingo
    });

    $("#cbox4").on("click", function () { //No tiene el mismo horario para todos los días
        $('#mismoHorario').hide(); //oculto mismo horario
        $('#horarioMartes').hide(); //oculto la hora de inicio y fin del martes
        $('#horarioMiercoles').hide(); //oculto la hora de inicio y fin del miercoles
        $('#horarioJueves').hide(); //oculto la hora de inicio y fin del jueves
        $('#horarioViernes').hide(); //oculto la hora de inicio y fin del viernes
        $('#horarioSabado').hide(); //oculto la hora de inicio y fin del sabado
        $('#horarioDomingo').hide(); //oculto la hora de inicio y fin del domingo


        //DIAS DE LA SEMANA
        var lunes = document.getElementById("Lunes");
        var martes = document.getElementById("Martes");
        var miercoles = document.getElementById("Miercoles");
        var jueves = document.getElementById("Jueves");
        var viernes = document.getElementById("Viernes");
        var sabado = document.getElementById("Sabado");
        var domingo = document.getElementById("Domingo");

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

    });

    //Lunes
    $("#Lunes").on("click", function () {
        if (this.checked == true) {
            $(this).val("1");
            var mismoHorario = document.getElementById("cbox3");
            var distintoHorario = document.getElementById("cbox4");
            if (mismoHorario.checked == false) {
                if (distintoHorario.checked == true) {//distinto horario
                    $('#horarioLunes').show(); //muestro la hora de inicio y fin del lunes
                }
            }
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
            var mismoHorario = document.getElementById("cbox3");
            var distintoHorario = document.getElementById("cbox4");
            if (mismoHorario.checked == false) { 
                if (distintoHorario.checked == true) {//distinto horario
                    $('#horarioMartes').show(); //muestro la hora de inicio y fin del Martes
                }
            }
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
            var mismoHorario = document.getElementById("cbox3");
            var distintoHorario = document.getElementById("cbox4");
            if (mismoHorario.checked == false) {
                if (distintoHorario.checked == true) {//dinstinto horario
                    $('#horarioMiercoles').show(); //muestro la hora de inicio y fin del Miercoles
                }
            }
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
            var mismoHorario = document.getElementById("cbox3");
            var distintoHorario = document.getElementById("cbox4");
            if (mismoHorario.checked == false) {
                if (distintoHorario.checked == true) {//distinto horario
                    $('#horarioJueves').show(); //muestro la hora de inicio y fin del Jueves
                }
            }
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
            var mismoHorario = document.getElementById("cbox3");
            var distintoHorario = document.getElementById("cbox4");
            if (mismoHorario.checked == false) {
                if (distintoHorario.checked == true) {//dinstinto horario
                    $('#horarioViernes').show(); //muestro la hora de inicio y fin del Viernes
                }
            }
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
            var mismoHorario = document.getElementById("cbox3");
            var distintoHorario = document.getElementById("cbox4");
            if (mismoHorario.checked == false) {
                if (distintoHorario.checked == true) {//dinstinto horario
                    $('#horarioSabado').show(); //muestro la hora de inicio y fin del Sabado
                }
            }
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
            var mismoHorario = document.getElementById("cbox3");
            var distintoHorario = document.getElementById("cbox4");
            if (mismoHorario.checked == false) {
                if (distintoHorario.checked == true) {//distinto horario
                    $('#horarioDomingo').show(); //muestro la hora de inicio y fin del Domingo
                }
            }
        }
        else {
            $('#horarioDomingo').hide(); //oculto la hora de inicio y fin del Domingo
            $(this).val("0");
        }
    });

})(jQuery);

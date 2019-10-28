(function ($) {
    'use strict';

    $("#busqueda").on('click', function () {

      
        $("#busqueda_avanzada").toggle("slow", function () {
            if ($("#busqueda_avanzada").is(":visible")) {
                $("#extender").css("height", "60vh");
            }
            else {
                $("#extender").css("height", "30vh");
            }
        });
 });



})(jQuery);
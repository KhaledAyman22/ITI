$(function () {
        var img_width = parseInt($('#img').css('width'));

        var interv = setInterval(
            function () {
                $("#p").text(`<img id="img" src="12.gif" style="left: ${$('#img').css('left')}">`);
            },
            100
        );

        $("#img").animate(
            {left: `${screen.width - img_width}px`},
            5000, 'linear',
            function ()
            {
                clearInterval(interv);
                $("#img").hide('explode', 500);
            }
        );
    }
);
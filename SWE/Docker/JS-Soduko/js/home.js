$(function(){
    $('#start_btn').on('click', function() {
        var tmp =  $('#difficulty_menu');

        if(tmp.css('display') === 'none')
            tmp.slideDown(400);
        else tmp.slideUp(400);
    });

    $('#settings_btn').on('click', function(){
        location.assign('../html/settings.html')
    });

    $("#easy").click(() => {
        location.assign('../html/game.html' + '?diff=e');
    });

    $("#medium").click(() => {
        location.assign('../html/game.html' + '?diff=m');
    });

    $("#hard").click(() => {
        location.assign('../html/game.html' + '?diff=h');
    });
})
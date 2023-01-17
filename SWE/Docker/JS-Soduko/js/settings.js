$(function(){
    var settings = [
        'Timer',
        'Mistake Limit',
        'Mistakes Checker',
        'Hide Numbers',
        'Highlight Duplicates',
        'Highlight Area',
        'Highlight Identical',
    ]

    $('.setting_btn').each(function (i,obj){
        var val = getCookie(settings[i])
        if(val === 'on' || val === null){
            $(this).text('ON');
            $(this).css('background-color','rgb(32, 123, 255)');
            $(this).css('box-shadow','0 5px 15px 1px rgb(32, 123, 255)');
        }
        else{
            $(this).text('OFF');
            $(this).css('background-color','rgb(252, 78, 78)');
            $(this).css('box-shadow','0 5px 15px 1px rgb(252, 78, 78)');
        }
    });


    $('.setting_btn').on('click', function() {
        var caller = $(this);
        var d = new Date();
        d.setDate(d.getDate() + 7);

        if(caller.text() === 'ON'){
            caller.text('OFF');
            caller.css('background-color','rgb(252, 78, 78)');
            caller.css('box-shadow','0 5px 15px 1px rgb(252, 78, 78)');
            setCookie(caller.val(), 'off', d.toUTCString());
        }
        else{
            caller.text('ON');
            caller.css('background-color','rgb(32, 123, 255)');
            caller.css('box-shadow','0 5px 15px 1px rgb(32, 123, 255)');
            setCookie(caller.val(), 'on', d.toUTCString());
        }
    });
})

/*



* */
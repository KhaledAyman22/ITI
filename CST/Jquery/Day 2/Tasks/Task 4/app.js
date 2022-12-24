var res;

$(function (){
    $.ajax('rockbands.json',{
        type: 'get',
        dataType: 'json',
        contentType: 'application/json',
        success: function (data){
            res = data;
            for (const dataKey in res) {
                $('#bands').append(`<option value="${dataKey}">${dataKey}</option>`);
            }
        }
    })

    $('#bands').change(function (){
        $('#artist').empty();
        var val = this.value;

        for (let i = 0; i < res[val].length; i++) {
            $('#artist').append(`<option value="${res[val][i].name}">${res[val][i].name}</option>`);
        }
    })
})
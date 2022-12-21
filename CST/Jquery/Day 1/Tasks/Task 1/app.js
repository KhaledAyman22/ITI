var current = 'about', img = 0;
var complain_data = [];

onload = function (){

  $('#gallery_div').css('display', 'none');
  $('#services_div').css('display', 'none');
  $('#complain_div').css('display', 'none');
  $('#complain_out_div').css('display', 'none');

  $('#about_btn').click (function (){
    $(`#${current}_div`).css('display', 'none');
    $('#about_div').css('display', 'block');
    current = 'about';
  })

  $('#gallery_btn').click (function (){
    $(`#${current}_div`).css('display', 'none');
    $('#gallery_div').css('display', 'block');
    current = 'gallery';
  })

  $('#services_btn').click (function (){
    $(`#${current}_div`).css('display', 'none');
    $('#services_div').css('display', 'block');
    current = 'services';
  })

  $('#complain_btn').click (function () {
    $(`#${current}_div`).css('display', 'none');
    $('#complain_div').css('display', 'block');
    current = 'complain';
  })

  $('#send').click (function () {
    $(`#${current}_div`).css('display', 'none');
    $('#complain_out_div').css('display', 'block');
    current = 'complain_out';

    complain_data = [];
    $('#complain_div :input').each(function(i){
      complain_data.push(this.value)
    })

    $('#complain_preview').html(`Name is ${complain_data[0]}<br>
                                Email is ${complain_data[1]}<br>
                                Phone is ${complain_data[2]}<br>
                                Complain is ${complain_data[3]}`);
  })

  $('#back').click(function (){
    $(`#${current}_div`).css('display', 'none');
    $('#complain_div').css('display', 'block');
    current = 'complain';
  })

  $('#left').click(function(){
    img = (img-1+5)%5;
    $('#main').attr('src', `Img/${img}.jpg`);
  })

  $('#right').click(function(){
    img = (img+1)%5;
    $('#main').attr('src',`Img/${img}.jpg`);
  })

}
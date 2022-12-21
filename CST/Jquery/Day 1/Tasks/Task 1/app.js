var current = 'about', img = 0;
var complain_data = [];

function Switch(new_crnt) {
  $(`#${current}_div`).css('display', 'none');
  $(`#${new_crnt}_div`).css('display', 'block');
  current = new_crnt;
}

onload = function () {

  $('#gallery_div').css('display', 'none');
  $('#services_div').css('display', 'none');
  $('#complain_div').css('display', 'none');
  $('#complain_out_div').css('display', 'none');

  $('#about_btn').click(Switch.bind(this, 'about'))

  $('#gallery_btn').click(Switch.bind(this, 'gallery'))

  $('#services_btn').click(Switch.bind(this, 'services'))

  $('#complain_btn').click(Switch.bind(this, 'complain'))

  $('#send').click(function () {
    Switch('complain_out');

    complain_data = [];

    $('#complain_div :input').each(function () { complain_data.push(this.value) });

    $('#complain_preview').html(`Name is ${complain_data[0]}<br>
                                Email is ${complain_data[1]}<br>
                                Phone is ${complain_data[2]}<br>
                                Complain is ${complain_data[3]}`);
  })

  $('#back').click(Switch.bind(this, 'complain'))

  $('#left').click(function () {
    img = (img + 4) % 5;
    $('#main').attr('src', `Img/${img}.jpg`);
  })

  $('#right').click(function () {
    img = (img + 6) % 5;
    $('#main').attr('src', `Img/${img}.jpg`);
  })

}
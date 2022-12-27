document.body.onload = function () {
    var d = new Date();
    d.setDate(d.getDate() + 10);
    setCookie('visits', parseInt(getCookie('visits')) + 1, d.toUTCString());
    document.getElementById('cookie_name').innerText = getCookie('name');
    document.getElementById('cookie_visits').innerText = getCookie('visits');
    document.getElementById('cookie_gender').src = `assets/${getCookie('gender')}.jpg`;
    document.getElementsByClassName("highlight").item(0).style.color = getCookie('color');
    document.getElementsByClassName("highlight").item(1).style.color = getCookie('color');
}
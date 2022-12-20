setCookie('visits',parseInt(getCookie('visits')) + 1);
document.getElementById('cookie_name').innerText = getCookie('name');
document.getElementById('cookie_visits').innerText = getCookie('visits');
document.getElementById('cookie_gender').src = `assets/${getCookie('gender')}.jpg`;
document.getElementsByClassName("highlight").item(0).style.color = getCookie('color');
document.getElementsByClassName("highlight").item(1).style.color = getCookie('color');
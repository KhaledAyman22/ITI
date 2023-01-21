document.body.onload = function () {
    var d = new Date();
    d.setDate(d.getDate() + 10);
    var vsts = parseInt(window.localStorage.getItem('visits'));
    window.localStorage.setItem('visits', (vsts + 1)+ '');
    document.getElementById('cookie_name').innerText = window.localStorage.getItem('name');
    document.getElementById('cookie_visits').innerText = window.localStorage.getItem('visits');
    document.getElementById('cookie_gender').src = `../assets/${window.localStorage.getItem('gender')}.jpg`;
    document.getElementsByClassName("highlight").item(0).style.color = window.localStorage.getItem('color');
    document.getElementsByClassName("highlight").item(1).style.color = window.localStorage.getItem('color');
}
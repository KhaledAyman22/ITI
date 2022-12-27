document.getElementById("submitBtn").onclick = register;

checkCookies();

function register() {
    var name = document.getElementById('name').value;
    var gender = document.getElementById('genderM').checked === true ? 1 : 2;
    var color = document.getElementById('color').value;

    var d = new Date();
    d.setDate(d.getDate() + 10);


    setCookie('name', name, d.toUTCString());
    setCookie('gender', gender, d.toUTCString());
    setCookie('visits', 0, d.toUTCString());
    setCookie('color', color, d.toUTCString());
    checkCookies();
}

function checkCookies() {
    if (hasCookie('name') && hasCookie('visits')) {
        location.replace('home.html');
    }
}

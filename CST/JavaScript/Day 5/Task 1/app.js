document.getElementById("submitBtn").onclick = register;

checkCookies();

function register(){
    var name = document.getElementById('name').value;
    var gender = document.getElementById('genderM').checked === true? 1:2;
    var color = document.getElementById('color').value;

    setCookie('name',name);
    setCookie('gender', gender);
    setCookie('visits', 0);
    setCookie('color', color);
    checkCookies();
}

function checkCookies() {
    if(hasCookie('name') && hasCookie('visits')){
        location.replace('home.html');
    }
}

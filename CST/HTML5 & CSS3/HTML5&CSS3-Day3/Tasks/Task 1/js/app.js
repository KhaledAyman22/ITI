document.body.onload = function (){
    document.getElementById("submitBtn").onclick = register;
    checkCookies();

    function register() {
        var name = document.getElementById('name').value;
        var gender = document.getElementById('genderM').checked === true ? 1 : 2;
        var color = document.getElementById('color').value;

        var d = new Date();
        d.setDate(d.getDate() + 10);


        window.localStorage.setItem('name', name);
        window.localStorage.setItem('gender', gender+'');
        window.localStorage.setItem('visits', '0');
        window.localStorage.setItem('color', color);
        checkCookies();
    }

    function checkCookies() {
        if (window.localStorage.getItem('name') && window.localStorage.getItem('visits')) {
            location.replace('../html/home.html');
        }
    }

}

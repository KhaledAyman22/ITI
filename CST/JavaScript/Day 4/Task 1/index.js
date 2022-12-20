document.getElementById("submitBtn").onclick = submit;

var name_regex = new RegExp(/([a-z]|[A-Z]| )+$/)
var address_regex = new RegExp(/([a-z]|[A-Z]| |[0-9]|-|\.)+$/)
var mobile_regex = new RegExp(/^((\+201)||(01))(0|1|2|5)[0-9]{8}$/)
var email_regex = new RegExp(/^([a-z]|[A-Z]|[0-9]|_|\.)+@([a-z]|[A-Z])+\.([a-z]|[A-Z])+$/)

function submit() {
    var name = document.getElementById('name').value;
    var address = document.getElementById('address').value;
    var jobTitle = document.getElementById('jobTitle').value;
    var mobile = document.getElementById('mobile').value;
    var email = document.getElementById('email').value;

    if (!name_regex.test(name)) {
        alert('Name field may consist of letters and spaces only!');
        return false;
    }
    if (!address_regex.test(address)) {
        alert('Address field may consist of letters, numbers, spaces, dots, and dashes only!');
        return false;
    }

    if (!name_regex.test(jobTitle)) {
        alert('Job Title field may consist of letters and spaces only!');
        return false;
    }

    if (!email_regex.test(email)) {
        alert('Invalid Email!');
        return false;
    }

    if (!mobile_regex.test(mobile)) {
        alert('Invalid mobile number!');
        return false;
    }
}

function checkBrowser(){

    var isChrome = navigator.userAgent === "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36";

    if(!isChrome) alert("Please use google chrome");
}



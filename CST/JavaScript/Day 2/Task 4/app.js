function run() {
    var data = Read();

    var c = prompt("Enter display color r for red, g for green, b for blue default is blue","b");
    var color;

    switch (c) {
        case 'r': color = 'red'; break;
        case 'g': color = 'green'; break;
        case 'b': color = 'blue'; break;
        default: color = 'blue';
    }

    document.write(`<p style="color : ${color};"> Welcome dear guest <span style="color : black;"> ${data['name']} <\span> <\p>`);
    document.write(`<br>`);

    document.write(`<p style="color : ${color};"> Your phone number is <span style="color : black;"> ${data['phone']} <\span> <\p>`);
    document.write(`<br>`);

    document.write(`<p style="color : ${color};"> Your mobile number is <span style="color : black;"> ${data['mobile']} <\span> <\p>`);
    document.write(`<br>`);

    document.write(`<p style="color : ${color};"> Your email address is <span style="color : black;"> ${data['email']} <\span> <\p>`);
    document.write(`<br>`);
}


function Read() {
    var str, valid, arr = [];
    var name_regex = new RegExp(/([a-z]|[A-Z]| )+$/)
    var phone_regex = new RegExp(/^[0-9]{8}$/)
    var mobile_regex = new RegExp(/^01(0|1|2|5)[0-9]{8}$/)
    var email_regex = new RegExp(/^([a-z]|[A-Z]|[0-9]|_)+@([a-z]|[A-Z])+\.([a-z]|[A-Z])+$/)

    valid = false;
    while (!valid) {
        str = prompt("Enter your name", 'Name');
        valid = name_regex.test(str);
    }

    arr['name'] = str;
    valid = false;

    while (!valid) {
        str = prompt("Enter your phone", 'Phone');
        valid = phone_regex.test(str);
    }

    arr['phone'] = str;
    valid = false;

    while (!valid) {
        str = prompt("Enter your mobile", 'Mobile');
        valid = mobile_regex.test(str);
    }

    arr['mobile'] = str;
    valid = false;

    while (!valid) {
        str = prompt("Enter your email", 'Email');
        valid = email_regex.test(str);
    }
    arr['email'] = str;

    return arr;
}
run();
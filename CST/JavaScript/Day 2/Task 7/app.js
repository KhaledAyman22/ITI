function run() {
    var num;

    num = 'a';
    while(!isNumeric(num)){
        num = prompt(`Enter circle radius`, '1');
    }
    confirm(`The area of the circle is ${Math.PI * Math.pow(parseInt(num),2)}`);

    num = 'a';
    while(!isNumeric(num)){
        num = prompt(`Enter a number`, '1');
    }
    confirm(`The square root of the number is ${Math.sqrt(parseInt(num))}`);


    num = 'a';
    while(!isNumeric(num)){
        num = prompt(`Enter an angle`, '1');
    }
    confirm(`The cosine of the angle is ${Math.cos(parseInt(num) * Math.PI / 180).toFixed(4)}`);
    console.log(parseInt(num) * Math.PI / 180);
}

function isNumeric(str) {
    if (typeof str != "string") return false;
    return !isNaN(str) && !isNaN(parseFloat(str))
}
run();
function run() {
    var data = Read();

    var color = 'red';


    document.write(`<p style="color : ${color};"> Sum of the three values = <span style="color : black;"> ${data[0] + data[1] + data[2]} <\span> <\p>`);
    document.write(`<br>`);

    document.write(`<p style="color : ${color};"> Product of the three values = <span style="color : black;"> ${data[0] * data[1] * data[2]} <\span> <\p>`);
    document.write(`<br>`);


    document.write(`<p style="color : ${color};"> Division of the three values = <span style="color : black;"> ${data[0] / data[1] / data[2]} <\span> <\p>`);
    document.write(`<br>`);
}


function Read() {
   var num, arr = [];

    for (var i = 0; i < 3; i++) {
        num = prompt(`Enter number ${i+1}`, '1');

        if(isNumeric(num)) arr.push(parseInt(num));
        else i--;
    }

    return arr;
}

function isNumeric(str) {
    if (typeof str != "string") return false;
    return !isNaN(str) && !isNaN(parseFloat(str))
}
run();
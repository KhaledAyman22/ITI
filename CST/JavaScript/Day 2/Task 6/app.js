function run() {
    var data = Read();
    var color = 'red';


    document.write(`<p style="color : ${color};"> Normal order = <span style="color : black;"> ${data[0]}, ${data[1]}, ${data[2]}, ${data[3]}, ${data[4]} <\span> <\p>`);
    document.write(`<br>`);

    data.sort((a, b) => a - b);
    document.write(`<p style="color : ${color};"> Ascending order = <span style="color : black;"> ${data[0]}, ${data[1]}, ${data[2]}, ${data[3]}, ${data[4]} <\span> <\p>`);
    document.write(`<br>`);

    data.sort((a, b) => b - a);
    document.write(`<p style="color : ${color};"> Descending order = <span style="color : black;"> ${data[0]}, ${data[1]}, ${data[2]}, ${data[3]}, ${data[4]} <\span> <\p>`);
    document.write(`<br>`);
}


function Read() {
   var num, arr = [];

    for (var i = 0; i < 5; i++) {
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
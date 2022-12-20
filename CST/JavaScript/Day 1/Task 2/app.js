function run() {
    var sum = 0, n = -1;
    while (n != 0 && sum < 100) {
        n = prompt("Enter a number", 0);
        console.log(n);

        if (isNumeric(n)) sum += +n;
        else {

            alert("The entered value is not a number!!");
            n = -1;
        }
    }

    confirm(`The sum is: ${sum}`);
}


function isNumeric(str) {
    if (typeof str != "string") return false;
    return !isNaN(str) && !isNaN(parseFloat(str))
}

run();
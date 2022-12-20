var reverse1 = function () {
    return [].reverse.apply(arguments);
}

function reverse2() {
    return ([].reverse.bind(arguments))();
}

console.log(reverse1(1, 2, 3, 5, 6));
console.log(reverse2(1, 2, 3, 5, 6));

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function onlyTwo() {
    if (arguments.length !== 2) throw new Error("# of parameters isn't 2");
    else console.log('onlyTwo executed');
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function addN() {
    if (arguments.length === 0) throw new Error('0 parameters passed!');

    var sum = 0;

    for (let i = 0; i < arguments.length; i++) {
        if (typeof arguments[i] !== 'number') throw new Error('parameters must be numbers!');
        sum += arguments[i];
    }

    return sum;
}
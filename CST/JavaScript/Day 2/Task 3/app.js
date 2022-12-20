function run() {
    var str = prompt("Enter a string", 'Hello JavaScript');

    confirm(`The largest string is ${Largest(str)}`)
}


function Largest(str) {
    var strs = str.split(' ');
    var longest = ' ';

    for (var i = 0; i < strs.length; i++) {
        if(strs[i].length > longest.length) longest = strs[i];

    }
    return longest;
}

run();
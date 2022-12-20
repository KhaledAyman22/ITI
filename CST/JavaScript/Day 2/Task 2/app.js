function run() {
    var str = prompt("Enter a string", 'Hello JavaScript');

    var choice = confirm("Consider case? Press Ok to consider, Cancel to not consider");

    if (choice === false) str = str.toLowerCase();

    var i = 0, j = str.length - 1;

    while (str[i] === str[j] && i < j) {
        i++; j--;
    }

    if (i >= j) confirm("The string is a palindrome");
    else confirm("The string is not a palindrome");
}


run();
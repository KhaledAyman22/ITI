
var input = prompt("Enter a message", "Hello JavaScript");

input = input || "Hello JavaScript";


for (var i = 1; i < 7; i++) {
    document.write(`<h${i}>${input}</h${i}>`)
}
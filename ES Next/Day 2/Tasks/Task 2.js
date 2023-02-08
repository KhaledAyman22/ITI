//1. The parameter determines the number of elements:
function* fibonacciGenerator1(limit) {
    yield 0;
    if(1<limit) yield 1;

    let [prev, curr] = [0, 1];
    for (let i = 2; i < limit; i++) {
        [prev, curr] = [curr, prev + curr];
        yield curr;
    }
}

console.log('1. The parameter determines the maximum number:')
let f1 = fibonacciGenerator1(10)
let arr1 = [];
for (const number of f1) arr1.push(number)
console.log(arr1.join(', '));


//2. The parameter determines the max value:
function* fibonacciGenerator2(max) {
    yield 0;
    if(1<max) yield 1;

    let [prev, curr] = [0, 1];
    while (curr <= max) {
        [prev, curr] = [curr, prev + curr];
        yield curr;
    }
}

console.log('1. The parameter determines the number of elements:')
let f2 = fibonacciGenerator2(10)
let arr2 = [];
for (const number of f2) arr2.push(number)
console.log(arr2.join(', '));
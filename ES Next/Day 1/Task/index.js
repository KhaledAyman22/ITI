{
    console.log('Swap the values of x and y using destructuring');
    let x = 1, y = 2;

    console.log('X: ',x);
    console.log('Y: ',y);

    [y, x] = [x, y];

    console.log('X: ',x);
    console.log('Y: ',y);
}

console.log('\n');

{
    console.log('Using rest parameter and spread operator return min and max')

    function minMax(...numbers) {
        return numbers.length === 0? [0,0] : [Math.min(...numbers), Math.max(...numbers)];
    }

    let [min, max] = minMax(1, 2, 3, 4, 5);
    console.log("Minimum value:", min);
    console.log("Maximum value:", max);
}

console.log('\n');

{
    const fruits = ["apple", "strawberry", "banana", "orange", "mango"];

    console.log('a. test that every element in the given array is a string');
    function everyElementIsString(array) {
        return array.every(e => typeof e === "string");
    }

    console.log(everyElementIsString(fruits));

    console.log('\n\nb. test that some array elements starts with "a"');
    function someElementsStartWithA(array) {
        return array.some(e => e[0] === "a");
    }

    console.log(someElementsStartWithA(fruits));

    console.log('\n\nc. generate new array filtered from the given array with only elements that starts with "b" or "s"');
    function filterWithBS(array) {
        return array.filter(e => e[0] === "b" || e[0] === "s");
    }

    console.log(filterWithBS(fruits));

    console.log('\n\nd. generate new array, each element of the new array contains a string declaring that you like the given fruit element');
    function likeFruits(array) {
        return array.map(e=> "I like " + e);
    }

    console.log('Generated')

    console.log('\n\ne. use forEach to display all elements of the new array from previous point');
    let i = 1;
    likeFruits(fruits).forEach(e => console.log(`${i++}- ${e}`));

}
var myFun=function fun(){}



(function () {
    console.log("exec");
}()); //IIFE



(function () {
    console.log("anonymous function");
})(); //IIFE

//var fun = function () {}

//anonymous fun
//1)pass param to -->callback function (event handler,timerFun)
//2)return function from another fun
//3)used as method for an object
//4)elem in array
//5)create function expression--->litral creation

/*
setTimeout(function () {
    console.log("anonymous function");

}, 1000);
*/



/*
b()
function a(){
    //
    b()
    
}

a()
function b(){
    
    //
    a()
}

b()

*/

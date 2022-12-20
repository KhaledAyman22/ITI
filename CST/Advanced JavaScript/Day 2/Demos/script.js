var z = 30;
var x = 6;


var myVAr = (function () {

    return function () {
        //
        //
        //

    }
})() //IIFE


var myVar = function () {
    //
    //
    //
}



function f1() {

    function f2() {

        return function () {


        }

    }

}



function outerFun(a) { //x,innerfun

    var x = 10; //shadowing
    var y = 5;

    var innerFun = function (b) { //y
        var y = 20
        return x + y + z + a + b; //scope Chaining

    }

    return innerFun(1)

}

function myFun() { //arr=[fn,fn,fn],i=3
    var arr = [];
    //var a = 3

    for (var i = 0; i < 3; i++) {
        arr.push(function(){
            
            console.log(i);
        })
        
        /*arr.push(function (a) {
            return function () {
                console.log(a)
            };
        }(i))//IIFE DP
*/
        
        
    }


    return arr;

}

var result = myFun();
result[0](1)

//console.log(outerFun(2));

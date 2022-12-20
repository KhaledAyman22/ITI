//Function Objects
//Function Statemt
function funStat() {}

//Function Expression
var funExp = function () {}//anonymous




var str = "hello";
("abc").length



var num = 10;
var arr = [1, 2, 3, 4, function () {
    console.log("as array element");
}];

//function Statement
//function myFun(){}

//function expression
var fun = function () { //anonymous function

    console.log("function expression");

    return function (x) {
        console.log("returned value");
        return "val " + x
    }
}


fun

var result = fun();

console.log(result); //function
console.log(result(10)); //val
fun()(10)








//result();
//fun()();




setTimeout(function () {}, 1000) //pass function as parameter


console.log(show); //fn
show()

function show() {
    console.log(this.objName);

}

var obj = {
    newProp: "val",
    age: 15,
    propObj: {
        color: "green",
        model: "abc"
    },
    disp: function () {
        console.log(this.objName); //caller object
    },
    show: show
};

var x = "propNAme"

obj.objName = "new Object";
obj.type = "js obj";
obj.count = 1;
obj.cat = ["js", "web", "development"];

obj["prop"] = "val";
obj[x] = "new Prop style" //===obj.propNAme===obj["propNAme"]

console.log(obj.prop);
console.log(obj["objName"]);

obj.propObj.model

show()

//var let const
var x = 10;
x = 20;
// x = "";
// x = true;
// console.log(y);
var y;
y = "asda";
// y = 10;
// y = true;
var z = 10; //Type Inference
// z = "asdsd";
// z=20;
var a;
a = 10;
a = "asda";
a = true;
a = {};
a = [];
var a2;
a2 = 10;
a2 = "asda";
a2 = true;
a2 = {};
a2 = [];
// var t=1;
var arr;
arr = [];
// arr = [1];
// var arr2:[number, number];
// arr2 = [1];
// arr2 = [1,2];
var arr3;
arr3 = [];
arr3 = [1];
arr3 = [1, 2];
arr3 = [1, 2, 3];
// arr3 = [1,2,3,""];
var strnum;
strnum = 1;
strnum = "asdas";
// strnum = true;
var arr4;
// var arr4:(string|number)[];
arr4 = [];
arr4 = [1];
arr4 = [1, 2];
arr4 = [""];
// arr4 = ["asdqw",2,2,"asdaf"];
// arr4 = "asaf";
var obj;
obj = {};
obj = { name: "Ahmed", age: 20 };
var obj1;
obj1 = { name: "Ahmed", age: 20 };
obj1 = { name: true, age: "asda" };
var obj2;
obj2 = { name: "Ahmed", age: 20 };
obj2 = { name: "Ahmed", age: 20, address: "123 st" };
var arrObj;
arrObj = [];
arrObj = [{ name: "Aly", age: 10 }, { name: "Aly", age: 10, address: "456 st" }];
var ss = 10;
// let tt = 20;
// tt = "asdasd";
/// Functions
// function abc(){
//     return "abc";
// }
// function abc1():void{
//     // return 10;
// }
// var aa = abc1(); //==> aa = undefined
//Class
class Person {
    constructor(name = "Person Name", age = 0) {
        this.name = name;
        this.age = age;
        // name:string;
        // age:number;
        // constructor(name="Person Name", age=0){
        //     this.name = name;
        //     this.age = age;
        // }
        this.address = "123 st";
        //Condition
        if (this.constructor == Person)
            Person.counter++;
    }
    static getCounter() {
        return Person.counter;
    }
    getName() {
        return this.name;
    }
    get Name() {
        return this.name;
    }
    set Name(val) {
        this.name = val;
    }
}
Person.counter = 0;
var p1 = new Person(); //Person {name:'Person Name',age:0}
var p2 = new Person("Ahmed"); //Person {name:'Ahmed',age:0}
var p3 = new Person("Aly", 20); //Person {name:'Aly',age:20}
class Employee extends Person {
    constructor(name = "Employee Name", age = 20, salary = 10000) {
        super(name, age);
        this.salary = salary;
        Employee.counter++;
    }
}
Employee.counter = 0;
var e1 = new Employee(); //Employee {name:"Person Name", age:0}
//Abstract VS Interface
class APerson {
    getName() {
        return this.name;
    }
}
class Emp1 extends APerson {
    getAge() {
        //throw new Error("Method not implemented.");
    }
}
class Emp2 {
    constructor(name, age) { this.name = name; this.age = age; }
    getName() {
        //throw new Error("Method not implemented.");
    }
    getAge() {
        //throw new Error("Method not implemented.");
    }
}

//var let const
var x:number = 10;
x = 20;
// x = "";
// x = true;

// console.log(y);
var y:string;
y = "asda";
// y = 10;
// y = true;

var z = 10;//Type Inference
// z = "asdsd";
// z=20;

var a:any;
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

var arr:[];
arr = [];
// arr = [1];

// var arr2:[number, number];
// arr2 = [1];
// arr2 = [1,2];

var arr3: number[];
arr3 = [];
arr3 = [1];
arr3 = [1,2];
arr3 = [1,2,3];
// arr3 = [1,2,3,""];

var strnum: number|string;
strnum = 1;
strnum = "asdas";
// strnum = true;

var arr4:string[]|number[];
// var arr4:(string|number)[];
arr4 = [];
arr4 = [1];
arr4 = [1,2];
arr4 = [""];
// arr4 = ["asdqw",2,2,"asdaf"];
// arr4 = "asaf";


var obj:{};
obj = {};
obj = {name:"Ahmed", age:20};

var obj1:{name,age};
obj1 = {name:"Ahmed",age:20};
obj1 = {name:true,age:"asda"};

var obj2:{name:string,age:number,address?:string};
obj2 = {name:"Ahmed", age:20};
obj2 = {name:"Ahmed", age:20,address:"123 st"};

var arrObj:{name:string,age:number,address?:string}[];

arrObj = [];
arrObj = [{name:"Aly",age:10},{name:"Aly",age:10, address:"456 st"}];



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
class Person{
    // name:string;
    // age:number;
    // constructor(name="Person Name", age=0){
    //     this.name = name;
    //     this.age = age;
    // }
    private address = "123 st";
    static counter = 0;
    constructor(public name="Person Name",public age=0){
        //Condition
        if(this.constructor == Person)
            Person.counter++;
    }
    
    static getCounter(){
        return Person.counter;
    }
    getName(){
        return this.name;
    }
    get Name(){//p2.Name
        return this.name;
    }
    set Name(val){
        this.name = val;
    }
}


var p1 = new Person();//Person {name:'Person Name',age:0}
var p2 = new Person("Ahmed");//Person {name:'Ahmed',age:0}
var p3 = new Person("Aly",20);//Person {name:'Aly',age:20}



class Employee extends Person {
    static counter = 0;
    constructor(name="Employee Name", age=20,public salary=10000){
        super(name, age);
        Employee.counter++;
    }

}

var e1 = new Employee();//Employee {name:"Person Name", age:0}


//Abstract VS Interface

abstract class APerson{
    name:string;
    age:number;
    getName(){
        return this.name;
    }
    abstract getAge();
}


class Emp1 extends APerson{
    getAge() {
        //throw new Error("Method not implemented.");
    }
    
}


interface IPerson{
    name:string;
    age:number;
    getName();
    getAge();
}

class Emp2 implements IPerson{
    name: string;
    age: number;
    constructor(name, age){this.name = name; this.age = age}
    getName() {
        //throw new Error("Method not implemented.");
    }
    getAge() {
        //throw new Error("Method not implemented.");
    }
    
}
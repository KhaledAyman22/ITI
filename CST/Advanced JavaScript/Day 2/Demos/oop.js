var str = new String("abc");
var str2 = String("gdfhjk");

var myFun = function (a) {
    var x = a + 10
    return x; //
}
//factory function pattern
var employee = function (nm, id) {
    /* var obj={empnm:nm,
         empID:id}
     return obj;
     */
    return {
        empnm: nm,
        empID: id
    }
}

var emp1 = /*new*/ employee("ali", "sd-123-sa");
emp1.addr = "123 st.";
emp1.age = 50;

var emp2 = employee("mona", "sd-456-sa");

emp2.addr; //undefined////////default property


//ctor

var show = function () {
    return this.prsnName + " lives in " + this.prsnAddr

}

var x=10;
x=20;

//class Person {
//ctor function Pattern
var Person = function (nm="abc", age=10, addr="st.") {
    //arguments,set for default agrs,conditions--->overloading
    //function created once
    this.prsnName = nm
    this.prsnAge = age
    this.prsnAddr = addr
    this.show = show;
    this.age=10;
    this.fun=function(x,y){
        return x+y+parseInt(this.age);
    }


}



//display();///

var p1 = new Person();//"ali", 10, "123st.");
var p2 = new Person("kareem");//, 15, "567st.");
var p = new Person("kareem", 15);//, "567st.");
var p3 = new Person("kareem", 15, "567st.");
p2.show()

p1.prop=10;





//}

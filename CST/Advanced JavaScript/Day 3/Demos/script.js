/*window = {
    alert: function () {},
    propmt: function () {},
    setTimeout: function (cb, ms) {
        //
        //
        //if ms
        cb();
    }
}
*/


//function Obj
//ctor
var Employee = function (nm = "ali", id = "sd-100", sal = 1000, yrbrn) {
    var yearBorn = yrbrn; //private prop

    this.toString=function(){
        console.log(this.empName+" born in "+yearBorn+" his id is "+this.empID);
    }
    //private method
    var greeting = (function () { ///hard binding

        console.log("welcome " + this.empName);
    }).bind(this)

    //this.empName = nm//default prop
    //data Descriptor
    Object.defineProperty(this, "empName", {
        value: nm,
        // writable:true,
        configurable: false,
        enumerable: true
    });

    //this.showData=function(){}
    Object.defineProperty(this, "showData", {
        value: function () {
            console.log(this.empName + " " + this.empID);
        },

    })

    this.empID = id
    this.empSal = sal
    this.disp = function () {
        greeting()
        var x = this; //_this|that|_that|self|_self
        setTimeout(function () { //scope chaining

            console.log(x.empName + " born in " + yearBorn);
        }, 2000);
    }

    //member method//getters
    // this.getYearBorn = function () { //privilged function//inner function
    //   return yearBorn;
    //}

    Object.defineProperty(this, "getYearBorn", {
        value: function () {
            return yearBorn;
        },
    })
    //setters
    //this.setYearBorn = function (val) {
    //  yearBorn = val;
    //}

    //greeting.bind(this)();
    greeting(); //hard binding---->caller obj--->this


}


Employee.prototype.getDataDisp=function(){
    return this.empName+" "+this.empID+" "+this.empSal;//+" "+yearBorn;
    
}

Employee.prototype.valueOf=function(){
    return this.empSal;
}






//Class Prop
Employee.location = "Cairo";

//Class Method
Employee.getInfo = function () {

    console.log(" this is employee ctor located in " + this.location);
}

Employee.getInfo()




var emp = new Employee("kareem", "sd-123-sa", 2000, 1990);

/** 
 * Classes
 * Modules
 * Proxy
 * Promises
*/
/**------------------------------------------------------ */
var myData = Symbol('abc')
class Person
{

    #ID;
     Address = "xyz"//Error
    constructor(id = 5, pName="ALi",pAge=20){
        if(this.constructor == Person){
            throw 'Error'
        }
        this.personName = pName
        this.personAge = pAge
        this.#ID = id
        this[myData] = "xyz"
    }

    get PersonID(){
        return this.#ID
    }

    set PersonID(val){
        this.#ID = val
    }

    display(){
        return `this is ${this.personName} and his age is
         ${this.personAge} and id ${this.#ID}`
    }

    static fun(){
        return `i am static function`
    }

    static counter = 0
    toString(){
        return `your age is ${this.personAge}`
    }
}


Person.prototype.displayInfo = function(){
    return `this is ${this.personName} and his age is
    ${this.personAge}`
}
// var obj = new Person()
// var obj2 = new Person(1,"Ahmed",25)
// var obj2 = new Person(2,"Ahmed")


class User extends Person
{
    constructor(id,name){
        super(id,name)
    }


    // toString(){
    //     return `this is ${this.personName}`
    // }

}
var u =new User()
/**------------------------------------------------------ */
/**Modules */

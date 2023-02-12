export function add(x,y){
    return x + y
}

function sub(x,y){
    return x- y
}

const PI = 3.14

export function calcCircleArea(r){
    return PI* (r**2)
}

export function fun(){
    sub()
}

var myData = Symbol('abc')
export class Person
{
    
    #ID;
    Address = "xyz"//Error
    constructor(id = 5, pName="ALi",pAge=20){
        var x = 10//private
        this.personName = pName
        this.personAge = pAge
        this.#ID = id
        this[myData] = "private"

        this.myProperty = x
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
/**generator function */
function * gen(){
    console.log('start')
    ////
    //
    //
    console.log('hello')
    yield 10
    //
    //
    console.log('2nd step')

    yield "abc"

    console.log("next value")

    yield [1,2,3]

    console.log('Done')
}

var result = gen()

for(var elem of gen()){
    console.log("value "+elem)
}

function * evenGen(arr){
    for(var i =0;i<arr.length;i++){
        if(arr[i]%2 == 0){
            yield arr[i]
        }
    }
}


// var arr=[1,2,3,4,5]

// var xyz = arr[Symbol.iterator]()
// xyz.next()
// xyz.next()
// xyz.next()
// xyz.next()
// xyz.next()
// xyz.next()//{value:undefined}
// xyz.next()
// xyz.next()
// xyz.next()


/**----------------Symbol--------------------------- */
var x = Symbol('abc')
var y = Symbol('abc')


var obj={
    name:"ali",
    [y]:"xyz"
}

var xx = Symbol.for('abc')//Symbol('abc')
var yy = Symbol.for('abc')//SYmbol



console.log("hello world".replace(/l/g,'_'))

// function myReplace(){

// }

// String.prototype.replace = function(){
//     return `hiiiiiiiiiiiiiiiiii`
// }

// console.log("hello world".replace(/l/g,'_'))
"hello world".replace(/l/g,'_')

// String.prototype.replace = function(obj,p){
//     obj[Symbol.replace](this,p)
// }

var myObj ={
    [Symbol.replace]:function(str,p){
        return str.substring(0,p)
    }
}
"hello world".replace(myObj,3)//hel
"hello world".replace(/l/g,3)//hel

















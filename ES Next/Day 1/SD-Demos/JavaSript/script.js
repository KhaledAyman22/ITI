// console.log(x)//undefined
// var x = 10
// // y()//error
// var y = function(){

// }
// // console.log(w)
// //TDZ-->Temporal dead zone-----
// let w = 10
// // console.log(window.w)//XXXXundefined

// // console.log(i)//undefined//error
// for(var i=0;i<3;i++){
//     console.log(i)
// }
// // console.log(i)//3//error
// {
//     let y=5
// }

// function fun(a,b){
//     // console.log(c)
//     let c = 10
//     var xyz = 5
//     return a+b+c+xyz
// }
// // console.log(c)//undefined
// fun()
// // console.log(c)//10
// let c =5
//  console.log(fun())
// var x = 5

//  w =6

//  const  u =123;
//  u =5
//  u=123


// function outerfun(){
//     var arr=[];
//     for(let i=0;i<3;i++){
//         arr.push(function(){
//             console.log(i)
//         })
//     }
//     return arr
// }
// var result = outerfun()//[f,f,f]
// result[0]()
// result[1]()
// result[2]()


/**-------------------------------------------------------------- */
/**Arrow function */
// function fun2(){
//     return 'a'
// }

// var myfun =(a,b)=>  "hello "+a

// console.log(myfun(1,2));

// (function(a,b){
//     console.log(a+" "+b)
// })("x","y")


// setTimeout(function(){
//     console.log('done')
// },100)


// var obj={
//     usrnm:"Ali",
//     display(){
//         // var that = this
//         setTimeout(()=>{  //lexical binding         
//             // console.log(that.usrnm)//Ali
//             console.log(this.usrnm)//undefined
//         },2000)
//     }
// }

// obj.display()//undefined--error

/**--------------------------------------------------------------------- */
//rest parameter & spread operator
function fun(x,y,z,...param){
    console.log(param)
    var w = 0
    for(var i =0;i<param.length;i++){
        z+=param[i]
    }
    console.log(param.reverse())
    w +=x+y+z
    return w
}

fun(1,2,3,4,5,6)

//speard operator
var arr = [1,2,3,4,5,6]
var arr2 = [0,12,...arr]

// var arr3 = []
// for(var i =0 ;i<arr.length;i++){
//     arr3[i]=arr[i]
// }

var array = ["Ahmed","Nour","abc","fdsfdsf"]

function fullName(firstname,lastname){
    console.log(arguments)
    return firstname + " "+lastname
}

// fullName(array[0],array[1])
// console.log(fullName(...array))
/**----------------------------------------------------------------- */
//Destructuring Assignment
var arr = [1,2,3,4,5,6,"a","b",function(){}]
var x = arr[0]
var y = arr[1]
var z =arr[6]
var w = arr[8]
var [x=10,y,z,,,,,w=2,,,,h=5]=arr

function fun(){
    // return [1,2,3,4,5]
    // return "abcdefg"//iterable
    return {name:"ali",age:10}
}

// var [x,y,z]=fun()
//////////////////////
//Object Destructuring

var myobj={
    name:"Es6",
    main:"Javascript",
    born:2015
}

// var x = myobj.name
// y=myobj.born
var {born:y, name:x,instructor:w}=myobj

myobj.born = "ay7aga"

/**------------------------------------------------- */

/**String API
 * 
 */
mystr = "welcome to our demo              "
console.log(mystr.trim())
console.log(mystr.trimEnd())
console.log(mystr.trimStart())

console.log(mystr.startsWith('wcc'))//false
console.log(mystr.endsWith(' '))
console.log(mystr.includes('to'))
console.log(mystr.repeat(3))

var myval = "ahmed"
console.log(`this is our demo: welcome ${myval} thanks`)


/**Updates */
console.log(isFinite(123))//true
console.log(isFinite("123"))//true
console.log(isFinite("ss"))//false
console.log(Number.isFinite(123))//true
console.log(Number.isFinite("123"))//false
console.log(Number.isFinite("sdfds"))//false

console.log(isNaN(123.55))//false
console.log(isNaN("123.55"))//false
console.log(isNaN("123ss"))//false

console.log(Number.isNaN(123))
console.log(Number.isNaN("asdfd"))
var x =NaN
// x == NaN
console.log(Number.isNaN(x))//true
var y ="dsf"/0
console.log(Number.isNaN(y))//true



function Employee(name,age){
    return {
        name,
        age
    }
}





























































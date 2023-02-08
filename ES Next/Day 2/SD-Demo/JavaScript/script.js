/**Default parameters */
 function fun(x=30,y,z=1){
    return x+y+z
 }

 console.log(fun(1,2))

 function fun2(x,y,obj){
    var z = x + y
    var defaulObj={
        nm:"ali",
        age:10
    }
 

    var result = Object.assign({anydata:"dfdsf"},defaulObj,obj)
    return `username is ${result.nm} and age is ${result.age} total is ${z}`


    // {
    //     nm:"ali",
    //     age:10,
    //     username:"ahmed",
    //     userage:20
    // }
 }

//  fun2()
 fun2(1,2,{username:"ahmed",userage:20})
 fun2(1,2,{address:"ahmed",ID:20,time:50})
 fun2(1,2,10)

 /**-------------------------------------------------------------------------- */
 /**Collection */
 /**Set & Map */
 //Set

//  var mySet = new Set()
//  mySet.add(1)
//  mySet.add("abc")
//  mySet.add([1,2,3])

//  console.log(mySet)
//  console.log(mySet.keys())
//  console.log(mySet.values())

//  mySet.add(1)
//  mySet.add([1,2,3])
//  var arr = [1,2,3]
//  mySet.add(arr)
//  mySet.add(arr)
//  arr.pop()

//  mySet.delete(1)
//  mySet.delete(arr)

//  for(elem in mySet.values()){//enuemrable
//     console.log(elem)
//  }

//  for(elem of mySet){
//     console.log(elem)
//  }


//  var arr=[1,2,3,4,5,6]

//  var iteration = arr[Symbol.iterator]()
//  for(elem of arr){
//     console.log(elem)
//  }

//  var obj={
//     nm:"ali",
//     age:10
//  }

// //  for( elem of obj){
// //     console.log(elem)
// //  }

// //iterable objects
// //set , string, array, Map

// var myobj = {
//     name:"ahmed",
//     add:"ay7aga",
//     [Symbol.iterator] :function(){
//         var counter = 0
//         var keys = Object.keys(myobj)
//         return {
//             next:function(){
//                 if(counter ===keys.length){
//                     return {
//                         value:undefined,
//                         done:true
//                     }
//                 }
//                 else{
//                     return {
//                         value:{key:keys[counter],value:myobj[keys[counter++]]},
//                         //myobj[keys[counter++]],
//                         done:false
//                     }
//                 }
//             }
//         }
//     }
// }


// for(var elem of myobj){
//     console.log(elem)
// }

/**Map--unique keys */
var myMap = new Map()
myMap.set("abc",10)
myMap.set(1,"x")
myMap.set(10,["x","y"])
console.log(myMap)

myMap.set(1,2)//

myMap.delete(1)

myMap.clear()

myMap.set('1',"x")
myMap.set(10,"x")

for(var [key,value] of myMap){
    console.log(typeof key +","+value)
}

var newMap = new Map([[3,4],["x",5],[4,function(){}]])








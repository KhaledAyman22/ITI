/**Async
 * Timers
 * Ajax
 * Events
 * Fetch API
 * 
 */

// var myPromise = new Promise(function(success,failure){
//     ///
//     //
//     //
//     if()
//     success()
//     else
//     failure()
// }).then(function(){}).catch()


// var myPromise = new Promise(function(s,f){
//     var xhr = new XMLHttpRequest()
//     xhr.open("GET","https://jsonplaceholder.typicode.com/usrs")
//     xhr.onreadystatechange = function(){
//         if(xhr.readyState==4){
//             if(xhr.status == 200){
//                 // var data = JSON.parse(xhr.responseText)
//                 // console.log(data)
//                 s(xhr.responseText)
//             }
//             else
//             {
//                 f('wrong data')
//             }
//         }
//     }

// xhr.send('')

// })
// .then(function(data){
//     var info = JSON.parse(data)
//     console.log(info)
// })
// .catch(function(msg){
//     console.log(msg)
// })
// // async
//  function fun(){

// var x =10
// var myPromise1 = new Promise((resolve,reject)=>{
//     if(x == 10){
//         setTimeout(()=>{
//             resolve('success p1')
//         },7000)
//     }
//     else{
//         reject('Failed p1')
//     }
// })

// // await myPromise1




// myPromise1.then((data)=>{
//     console.log(data)
//     var y =10
//     var myPromise2 = new Promise((resolve,reject)=>{
//         if(y == 10){
//             setTimeout(()=>{
//                 resolve('success p2')
//             },1000)
//         }
//         else{
//             reject('Failed p2')
//         }
//     })
// return myPromise2
// }).then((data)=>{console.log(data)}).catch((msg)=>{console.log(msg)})
// //myPromise2.then((data)=>{console.log(data)}).catch((msg)=>{console.log(msg)})







// }


// fun()



/**--------------------------------------------------- */

// var a = 1
// if(a){
//     a = 3
// }
// console.log(a)//

// var a =1  ///condition true
// a &&=3
// // a = a && 3
// console.log(a)//3
// // a +=3

var a =0 ///condition false
// if(!a){
//     a = 5
// }
// console.log(a)//5




// a ||=5//a = a ||5
// console.log(a)


// value undefined - null

var x = undefined//null
x??=7

var num1 =500
var num2 = 1_500
var num3 = 1_000_500








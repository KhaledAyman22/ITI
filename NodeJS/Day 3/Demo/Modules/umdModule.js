/**
 * IIFE [Immediatly Invoked Function Expression]
 * 
 */

// function abc(){
//     return "ABC";
// }

// (function(){return "ABC"})();
// (function(x=0,y=0, obj, myFun){
//     myFun();
//     return x+y+obj.a;
// })(5,6,{a:7}, ()=>{});


(function(callingName,environment,myFun){
    if(typeof module != 'undefined'){//true value ==> server-side
        // module.exports = {callingName:myFun}
        module.exports[callingName] = myFun;
        console.log("hello")
    }else{//false ==> client-side
        // window.UMD = myFun
        // environment.UMD = myFun
        environment[callingName] = myFun
    }
})("myUMD",this,()=>{return "Hello UMD"});



/**
 * 1- package.json ==> npm init [name] [small]
 * 2- npm adduser ==> userName ===> password ==> email
 * 3- npm publish []
 */











// var window = "";
// console.log(x);
// console.log(typeof window);
/**Proxy */
var myObj = {
    x:10,
    y:20
}

// console.log(myObj.z)
// myObj.z = 30
// console.log(myObj.z)
var handler ={
    set(target,prop,value){
        // if(target.hasOwnProperty(prop)){
        if(prop == "x"){
            console.log('hiiiiii')
        }
        else{
            console.log('................')
        }
            // if(value >5 && value <30){
            //     target[prop] = value
            // }
            // else{
            //     throw 'invalid range'
            // }
        // }
    },
    get(target,prop){
        if(target.hasOwnProperty(prop)){
            return target[prop]
        }
        else
        {
            throw 'invalid property'
        }
    }
}

var myProxy = new Proxy(myObj,handler)

myProxy.x =20





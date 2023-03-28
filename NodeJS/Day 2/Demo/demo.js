// var EventEmmiter = require("events");
// var e1 = new EventEmmiter();

//Listener(cbf) ==> emit[Fire]

// e1.on("abc",()=>{console.log("Event 'ABC' Fired")})
// // e1.on("xyz",()=>{console.log("Event 'XYZ' Fired")})
// e1.once("xyz",()=>{console.log("Event 'XYZ' Fired")})
// e1.emit("abc");
// e1.emit("xyz");
// e1.emit("xyz");
// e1.emit("xyz");

/////
/** Custom Module  ===>  Events */





var EventEmmiter = require("events");

class myClassEvent extends EventEmmiter{
    //Properties
}

var e1 = new myClassEvent()
e1.on("e1",()=>{});
e1.emit("e1")


module.exports = {
    myClassEvent
}


/**
 * export default ==> file
 * export default ===> import file
 */



/**
 * Server [Views]
 */

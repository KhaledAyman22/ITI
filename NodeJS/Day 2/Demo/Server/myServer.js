// let myMod = require("../Modules/myModule");//{} ==> exports
// // console.log(myMod);//{ AddItem:()=>{}, TotalPrice:()=>{}  }

// myMod.AddItem("Labtop", 20000);
// myMod.AddItem("SmartWatch", 7000);
// myMod.AddItem("HeadPhone", 3000);


// console.log(myMod.TotalPrice());


// let myMod2 = require("../Modules/myModule");

// myMod2.AddItem("Labtop", 20000);
// myMod2.AddItem("SmartWatch", 7000);
// myMod2.AddItem("HeadPhone", 3000);


// console.log(myMod2.TotalPrice());


//import {myClass} from '../Modules/myModule'

let {myClass} = require("../Modules/myModule");//{} ==> exports
// console.log(myClass);//{ myClass: class{} }// 
/**
 * let user1 = new myMod.myClass();
 * let user1 = new myClass();
 */

let user1 = new myClass();
user1.AddItem("Labtop", 20000);
user1.AddItem("SmartWatch", 7000);
user1.AddItem("HeadPhone", 3000);


console.log(user1.TotalPrice());//30000

let user2 = new myClass();
user2.AddItem("Labtop", 20000);
user2.AddItem("SmartWatch", 7000);
user2.AddItem("HeadPhone", 3000);


console.log(user2.TotalPrice());//30000


user1.AddItem("Tab",15000);
console.log(user1.TotalPrice());//45000
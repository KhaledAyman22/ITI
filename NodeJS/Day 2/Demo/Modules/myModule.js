// var x = 10;
// var y = 20;
// var z = 30;
// console.log(global)
// global.x = x;
// console.log(global)

//console.log(exports);
//console.log(module.exports);

// exports.x = x;
// exports.y = y;
// exports = {z};
// module.exports = {z};
// module.exports.z = z;
// module.exports.x = x;
// module.exports.y = y;

// module.exports = {
//     var1:x,
//     var2:y,
//     var3:z
// }


/**
 * exports ===> {} ==> {}.x ==> {}.y
 * module.exports => new {} 
 */


//Functions

/** 
 * Array of {} ==> Items ==> each Item {name, price}
 * AddItem(name, price);
 * totalPrice();
 */

// var Items = [];

// function AddItem(name, price) { 
//     //Add {} To Array
//     let newItem = {name, price};
//     Items.push(newItem);
//  }

// function TotalPrice() { 
//     var sum = 0;
//     for(let i=0; i<Items.length; i++){//Items[i] ==> {name, price}
//         sum+= +(Items[i].price);
//     }
//     return sum;
//  }
//  module.exports = {
//     AddItem,
//     TotalPrice
//  }



class myClass{
    //private
    Items = [];//Property
    AddItem(name, price) {
       let newItem = {name, price};
       this.Items.push(newItem);
    }
    TotalPrice() { 
       var sum = 0;
       for(let i=0; i<this.Items.length; i++){//Items[i] ==> {name, price}
           sum+= +(this.Items[i].price);
       }
       return sum;
    }
}

module.exports = {
    myClass
}
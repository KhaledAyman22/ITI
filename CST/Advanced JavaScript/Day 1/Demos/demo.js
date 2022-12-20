var adding = function (a, b) {

    //arguments collection
    //arguments[0]==a 1
    //arguments[1]==b 2
    //arguments[2]==?? 3
    var sum = 0;

    for (var i = 0; i < arguments.length; i++) {
        ///
        sum += arguments[i];
    }
    return sum;
}
/////////////////////////////////////////////////
adding()
adding(1, 2)
adding(1, 2, 3)
adding(1, 2, 3, 4, 5, 6)




obj = {
    nm: "objnm",
    fun: function (x, y, z) {
        console.log(this.nm);
    }
}


obj2 = {
    nm: "obj2nm"
}

obj.fun()//obj

obj.fun.apply(obj2, [1, 2, 3]);//obj2
obj.fun.call(obj2, 1, 2, 3)//


var f=obj.fun.bind(obj2, 1, 2, 3)//
f()
obj.fun.bind(obj2, 1, 2, 3)()

















obj = {
    id: "SD-10",
    location: "SV",
    addr: "123 st.",
    desc: function () {
        var keys = Array.from(Object.keys(this));
        return `Object properties are ${keys.join(', ')}`;
    },
    getSetGen: function () {
        var keys = Array.from(Object.keys(this));

        for (var i = 0; i < keys.length; i++) {
            if (typeof this[keys[i]] !== 'function') {
                var get = `get${keys[i][0].toUpperCase()}${keys[i].slice(1)}`,
                    set = `s${get.slice(1)}`;

                this[get] = function (j) { return this[keys[j]] }.bind(this, i);

                this[set] = function (j, value) { this[keys[j]] = value }.bind(this, i);
            }
        }
    }
}

emp = {
    id: '123',
    name: 'khaled',
    age: '22',
    display: function () {
        console.log(this.id);
        console.log(this.age);
        console.log(this.name)
    }
}


console.log("Before");
console.log(Object.keys(obj));
console.log(Object.values(obj));
obj.getSetGen();
console.log("After");
console.log(Object.keys(obj));
console.log(Object.values(obj));

//////////////////////////////////////////////////////////////////////////////////////
console.log("Before");
console.log(Object.keys(emp));
console.log(Object.values(emp));
obj.getSetGen.apply(emp);
console.log("After");
obj.getSetGen();
console.log(Object.keys(emp));
console.log(Object.values(emp));
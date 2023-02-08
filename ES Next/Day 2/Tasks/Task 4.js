let obj = {
    prop1: 1,
    prop2: 2,
    prop3: 3,
    prop4: 4,
    prop5: 5,
    prop6: 6,
    prop7: 7,
    prop8: 8,
    prop9: 9,
    prop10: 10,
    func: function * (){
        for (const objElement of Object.keys(this)) {
            if(objElement != 'func')
            yield [objElement, this[objElement]]
        }
    }
}

for (const prop of obj.func()) {
    console.log(prop)
}

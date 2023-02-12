const handler = {
    set(target, prop, value) {
        switch (prop) {
            case 'name':
                if (typeof value === 'string' && value.length === 7)
                    target[prop] = value;
                else
                    throw new TypeError(`Invalid name value: ${value}`);
                break;
            case 'address':
                if (typeof value === 'string')
                    target[prop] = value;
                else
                    throw new TypeError(`Invalid address value: ${value}`);
                break;
            case 'age':
                if (typeof value === 'number' && value >= 25 && value <= 60)
                    target[prop] = value;
                else
                    throw new TypeError(`Invalid age value: ${value}`);

                break;
            default:
                throw new TypeError(`Invalid property: ${prop}`);
        }
        return true;
    },

    get(target,prop){
        if(target.hasOwnProperty(prop)) return target[prop]
        else throw 'invalid property'
    }
};

let object = new Proxy({}, handler);


object.name = '_Khaled'
object.address = 'Giza'
object.age = 25

try{
object.age = '25'
}catch (e) {
    console.log(`Exception ${e} was caught`)
}

try{
    object.phone = '0112233445566'
}catch (e) {
    console.log(`Exception ${e} was caught`)
}

console.log(object)


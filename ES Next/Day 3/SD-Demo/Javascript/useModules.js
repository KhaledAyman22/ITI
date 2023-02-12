// import * as myModules from './Lib.js'
import { add as addingfun,Person } from './Lib.js'

// console.log(myModules.add(1,2))
// console.log(myModules.sub(1,2))

console.log(addingfun(1,2))

class Employee extends Person{
    constructor(id,nm){
        super(id,nm)
    }
}

var emp = new Employee("mona",25)
console.log(emp)
/**------------------------------------------------------------ */
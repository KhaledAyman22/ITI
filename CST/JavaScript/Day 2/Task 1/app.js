function run() {
    var add = new Address(1,2,3);
    var p = new Person("aa","cc",add,111212);

    console.log(p);
}

run.tmp = "WTF";

class Address {
    city;
    zip;
    street;

    constructor(c,z,s) {
        this.city = c;
        this.street=s;
        this.zip=z;
    }

}

class Person {
    firstName;
    lastName;
    address = new Address();
    phone;

    constructor(f,l,a,p){
        this.firstName = f;
        this.phone = p;
        this.lastName = l;
        this.address = a;
    }
}




run();

console.log(run);
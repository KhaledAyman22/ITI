function Rectangle(width, height) {

    this.width = width;

    this.height = height;

    this.area = function () {
        return this.width * this.height;
    };

    this.perimeter = function () {
        return (this.width * 2) + (this.height * 2);
    };

    this.displayInfo = function () {
        console.log(`Rectangle width is ${this.width}cm, height is ${this.height}cm, area is ${this.area()}cm^2, perimeter is ${this.perimeter()}cm`);
    };

}

function Clone(src, dest) {
    Object.keys(src).forEach((prop) => dest[prop] = src[prop]);
}

var myRect = new Rectangle(6, 10);
var myrect = new Rectangle();
Clone(myRect, myrect);
myrect.width = 10;
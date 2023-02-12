import {Circle, Rectangle, Square, Triangle} from "./class_lib.js";

const canvas = document.getElementById("canvas");
const ctx = canvas.getContext("2d");

let polygons = [new Rectangle(400, 200)
    , new Square(400)
    , new Circle(200)
    , new Triangle(400, 320)]

print()

draw()

function print() {
    for (const polygon of polygons) {
        console.log(polygon.toString())
    }
}

function draw() {
    let i = 0

    let interval = setInterval(function (){
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        polygons[i++].draw(ctx)
        if(i === polygons.length) clearInterval(interval);
    }, 5000)
}
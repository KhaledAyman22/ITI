class Polygon {
    constructor(height, width) {
        this.height = height;
        this.width = width;
    }

    toString() {
        return `Polygon height=${this.height}, width=${this.width}`;
    }
}

export class Rectangle extends Polygon {
    constructor(height, width) {
        super(height, width);
    }

    getArea() {
        return this.height * this.width;
    }

    toString() {
        return `Rectangle height=${this.height}, width=${this.width}, area=${this.getArea()}`;
    }

    draw(ctx) {
        ctx.fillRect(10, 10, this.width, this.height);
    }
}

export class Square extends Rectangle {
    constructor(side) {
        super(side, side);
    }

    toString() {
        return `Square side=${this.height}, area=${this.getArea()}`;
    }
}

export class Circle {
    constructor(radius) {
        this.radius = radius;
    }

    getArea() {
        return Math.PI * this.radius * this.radius;
    }

    toString() {
        return `Circle radius=${this.radius}, area=${this.getArea()}`;
    }

    draw(ctx) {
        ctx.beginPath();
        ctx.arc(canvas.width/2, canvas.height/2, this.radius, 0, 2 * Math.PI);
        ctx.fillStyle = "black";
        ctx.fill();
        ctx.stroke();
    }
}

export class Triangle extends Polygon {
    constructor(base, height) {
        super(height, base);
    }

    getArea() {
        return 0.5 * this.height * this.width;
    }

    toString() {
        return `Triangle base=${this.width}, height=${this.height}, area=${this.getArea()}`;
    }

    draw(ctx) {
        ctx.beginPath();
        ctx.moveTo(350, 250 - this.height / 2);
        ctx.lineTo(350 - this.width / 2, 250 + this.height / 2);
        ctx.lineTo(350 + this.width / 2, 250 + this.height / 2);
        ctx.fillStyle = "black";
        ctx.fill();
        ctx.stroke();
    }
}
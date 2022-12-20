var h = screen.height,
        tmp = 0, ok = true;

child = open("child.html", "_blank", "height=100,width=100");

function run() {

        if (ok) {
                tmp += 150;
                child.moveBy(150, 150);
        }
        else {
                tmp -= 150;
                child.moveBy(-150, -150);
        }

        if (tmp - 150 < 0) ok = true;
        if (tmp + 150 > h) ok = false;

        child.focus();
        child.resizeTo(100, 100);
}

function stop() {
        clearInterval(interval);
}

var interval = setInterval(run, 5);

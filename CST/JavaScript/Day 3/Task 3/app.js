function run() {
        child = open("child.html", "_blank", "height=300,width=300");
        child.moveTo(300, 200);
        child.focus();

        var interv = setInterval(scroll, 250);

        function scroll() {
                child.scrollBy(0, 20);

                if ((child.window.innerHeight + child.window.scrollY) >= child.document.body.offsetHeight + 10) {
                        clearInterval(interv);
                        setTimeout(() => child.close(), 700);
                }
        }
}

run();
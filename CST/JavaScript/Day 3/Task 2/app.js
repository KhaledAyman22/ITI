function run() {
        var idx = 0, interv;
        var str = "Hello from child";

        child = open("child.html", "_blank", "height=300,width=300");
        child.moveTo(150, 100);
        child.focus();

        interv = setInterval(type, 250);

        function type() {
                child.document.write(`<span style="color: brown">${str[idx++]}</span>`);

                if (idx === str.length) {
                        clearInterval(interv);
                        setTimeout(() => child.close(), 2000);
                }
        }

}


run();
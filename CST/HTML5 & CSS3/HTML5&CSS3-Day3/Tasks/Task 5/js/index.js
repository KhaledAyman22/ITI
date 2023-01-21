document.body.onload = function (){
    var canvas = document.getElementById('canvas');
    if (canvas.getContext)
    {

        var context = canvas.getContext('2d');

        var grd1 = context.createLinearGradient(200, 100, 200, 250);
        grd1.addColorStop(0, "lightblue");
        grd1.addColorStop(1, "white");

        var grd2 = context.createLinearGradient(250, 250, 250, 400);
        grd2.addColorStop(0, "lightgreen");
        grd2.addColorStop(1, "white");

        var grd3 = context.createLinearGradient(250, 200, 250, 400);
        grd3.addColorStop(0, "black");
        grd3.addColorStop(1, "white");

        context.beginPath();
        context.moveTo(50,100);
        context.lineTo(450,100);
        context.lineTo(450,250);
        context.lineTo(50,250);
        context.lineTo(50,150);
        context.fillStyle = grd1;
        context.fill();
        context.closePath();

        context.beginPath();
        context.moveTo(50,250);
        context.lineTo(450,250);
        context.lineTo(450,400);
        context.lineTo(50,400);
        context.lineTo(50,300);
        context.fillStyle = grd2;
        context.fill();
        context.closePath();

        context.beginPath();
        context.moveTo(180,300);
        context.lineTo(180,200);
        context.lineTo(320,200);
        context.lineTo(320,300);
        context.strokeStyle = grd3;
        context.lineWidth = 3;
        context.stroke();
        context.closePath();

    }

}
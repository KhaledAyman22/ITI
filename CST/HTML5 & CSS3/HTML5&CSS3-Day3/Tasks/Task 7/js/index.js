document.body.onload = function (){
    var canvas = document.getElementById('canvas');
    var img= document.getElementById('img');

    if (canvas.getContext)
    {

        var context = canvas.getContext('2d');


        context.beginPath()
        context.drawImage(img,50,20)
        context.closePath();

        context.beginPath();
        context.font="50px verdana";

        context.shadowBlur=7;
        context.shadowColor="black";
        context.lineWidth=3;
        context.fillStyle="black";
        context.fillText("NO CAMERAS",90,475)
        context.strokeText("NO CAMERAS",90,475);

        context.shadowBlur=0;
        context.shadowColor="transparent";
        context.lineWidth=3;
        context.fillStyle="red";
        context.fillText("NO CAMERAS",90,470);
        context.closePath();
    }

}
document.body.onload = function (){
    var canvas = document.getElementById('canvas');
    if (canvas.getContext)
    {

        var context = canvas.getContext('2d');
        var x = 10;
        context.beginPath();

        var interval = setInterval(function (){
            if(x===500) clearInterval(interval)
            context.moveTo(0,0);
            context.lineTo(x,x);
            context.strokeStyle = "black"
            context.strokeWidth = 5
            context.stroke();
            x+=10;
        },200)
    }

}
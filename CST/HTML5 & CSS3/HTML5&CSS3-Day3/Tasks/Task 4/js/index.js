document.body.onload = function (){
    var canvas = document.getElementById('canvas');
    if (canvas.getContext)
    {

        var context = canvas.getContext('2d');
        var x = 1;



        var interval = setInterval(function (){
            context.beginPath();

            context.clearRect(0,0,canvas.width,canvas.height);

            if(x%2 === 1)
                context.arc(250, 250, 80, Math.PI,0);
            else
                context.arc(250, 250, 80, 0, Math.PI);

            context.fillStyle = 'yellow';
            context.fill();
            context.stroke();
            context.closePath();

            x++;

            if(x===10) {
                clearInterval(interval)
                setTimeout(function (){
                    context.beginPath();
                    context.clearRect(0,0,canvas.width,canvas.height);
                    context.arc(250, 250, 80, 0,2*Math.PI);
                    context.fillStyle = 'yellow';
                    context.fill();
                    context.stroke();
                    context.closePath();
                },500);
            }
        },500)
    }

}
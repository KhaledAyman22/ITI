document.body.onload = function () {
    var canvas = document.getElementById('canvas');
    if (canvas.getContext) {
        var context = canvas.getContext('2d'), angle = 0, direction = 1;

        context.globalAlpha = 0.5;

        setInterval(function(){
            context.save();
            context.beginPath();
            context.translate(canvas.width/2, canvas.height/2);
            context.rotate(angle * Math.PI / 180);
            context.rect(-100 , 50*.1, 100, 40);
            context.fillStyle = 'lightblue';
            context.fill();
            context.restore();

            angle += (20*direction);
            if (angle >= 360 || angle <= 0){
                context.clearRect(0, 0, canvas.width, canvas.height);
                direction *= -1;
            }
        },300)
    }
}
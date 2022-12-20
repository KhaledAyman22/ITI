document.getElementById("main").onmouseover = pauseAnim;
document.getElementById("main").onmouseout = startAnimation;

var current_on = 1;
var interval;

function pauseAnim(){
    clearInterval(interval);
}

function animate(){
    document.getElementById(`i${current_on}`).src = 'assets/off.jpg';

    if(current_on === 5) current_on = 1;
    else current_on++;

    document.getElementById(`i${current_on}`).src = 'assets/on.jpg';
}

function startAnimation(){
    interval = setInterval(animate, 150);
}
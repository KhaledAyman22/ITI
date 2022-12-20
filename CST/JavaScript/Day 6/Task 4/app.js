var interval = setInterval(run,30);

var img1 = document.getElementById('i1');
var img2 = document.getElementById('i2');
var img3 = document.getElementById('i3');

document.getElementById('rst').addEventListener('click',reset);
document.getElementById('stp').addEventListener('click',()=>clearInterval(interval));

var i1d = 'l', i2d = 'r', i3d = 't';
function run() {


    if(i1d ==='r' && parseInt(getComputedStyle(img1).left) + 10 > 570) i1d = 'l';
    else if(i1d ==='l' && parseInt(getComputedStyle(img1).left) - 10 < 10) i1d = 'r';

    if(i2d ==='r' && parseInt(getComputedStyle(img2).left) + 10 > 570) i2d = 'l';
    else if(i2d ==='l' && parseInt(getComputedStyle(img2).left) - 10 < 10) i2d = 'r';

    if(i3d ==='t' && parseInt(getComputedStyle(img3).top) - 10 < 20) i3d = 'd';
    else if(i3d ==='d' && parseInt(getComputedStyle(img3).top) + 10 > 360) i3d = 't';

    if(i1d==='r')
        img1.style.left = (parseInt(getComputedStyle(img1).left) + 10) + 'px';
    else
        img1.style.left = (parseInt(getComputedStyle(img1).left) - 10) + 'px';

    if(i2d==='r')
        img2.style.left = (parseInt(getComputedStyle(img2).left) + 10) + 'px';
    else
        img2.style.left = (parseInt(getComputedStyle(img2).left) - 10) + 'px';

    if(i3d==='t')
        img3.style.top = (parseInt(getComputedStyle(img3).top) - 10) + 'px';
    else
        img3.style.top = (parseInt(getComputedStyle(img3).top) + 10) + 'px';


    document.getElementById('hi1').innerText = `image 1 left = ${getComputedStyle(img1).left}.`;
    document.getElementById('hi2').innerText = `image 2 left = ${getComputedStyle(img2).left}.`;
    document.getElementById('hi3').innerText = `image 3 top = ${getComputedStyle(img3).top}.`;

}



function reset(){
    clearInterval(interval);
    img1.style.left = '570px';
    img2.style.left = '10px';
    img3.style.left = '280px';
    img1.style.top  = '160px';
    img2.style.top  = '160px';
    img3.style.top  = '360px';
    interval = setInterval(run, 30);
}
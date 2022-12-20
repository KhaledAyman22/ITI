document.getElementById("next").onclick = nextImg;
document.getElementById("prev").onclick = prevImg;
document.getElementById("slide").onclick = slideshow;
document.getElementById("stop").onclick = stopSlideshow;


var img_index = 1;
var interval;

function prevImg() {
    if (img_index !== 1)
        document.getElementById("imageView").src = `assets/${--img_index}.jpg`;
}

function nextImg() {
    if (img_index !== 6)
        document.getElementById("imageView").src = `assets/${++img_index}.jpg`;
}

function iterate() {
    if (img_index === 6) img_index = 1;
    else img_index++;

    document.getElementById("imageView").src = `assets/${img_index}.jpg`;
}

function slideshow() {
    interval = setInterval(iterate, 2000);
}

function stopSlideshow() {
    clearInterval(interval);
}
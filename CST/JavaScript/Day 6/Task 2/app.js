document.body.childNodes[1].childNodes[1].style.textAlign = 'right';

var dup  = document.getElementById("header").cloneNode(true);
dup.id = 'header-cloned'
dup.style.textAlign = 'left';

document.body.childNodes[1].appendChild(dup);


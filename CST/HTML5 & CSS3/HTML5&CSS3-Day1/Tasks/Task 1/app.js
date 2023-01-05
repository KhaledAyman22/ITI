document.body.onload = function (){
    for (let elementsByTagNameElement of document.getElementsByTagName('input')) {
        elementsByTagNameElement.oninput = Update;
    }
}
function Update(){
    document.getElementsByTagName('p')[0].style.color =
        `rgb(${document.getElementById('red').value},
             ${document.getElementById('green').value},
             ${document.getElementById('blue').value})`;
}
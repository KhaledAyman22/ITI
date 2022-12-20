var radio = 1;

for (var i = 1; i < 7; i++) {
    document.getElementById(`r${i}`).addEventListener('click', (e)=> {
        radio = parseInt(e.target.id[1]);
    });
}



document.getElementById("btn").addEventListener('click',(e)=>{
    var msg = document.getElementById('msg').value;

    var dv = document.createElement('div');

    var img = document.createElement('img');
    img.src = `http://localhost:63342/Day%206/Task%203/assets/${radio}.jpg`;
    img.width = 1000;
    img.height = 800;

    dv.appendChild(img);

    var header = document.createElement('h1');
    header.innerText = msg;


    var btn = document.createElement('button');
    btn.innerText = 'close';
    btn.addEventListener('click', ()=>win.close());


    var win = window.open("","_blank");
    win.document.body.style.textAlign = 'center'
    win.document.body.appendChild(dv);
    win.document.body.appendChild(header);
    win.document.body.appendChild(btn);
})


var cust_event = new Event('glow');


window.addEventListener('glow', ()=>{
    document.getElementById("form").style.backgroundColor="red";
    
    setTimeout(()=>{ document.getElementById("form").style.backgroundColor="yellow";}, 500);
    setTimeout(()=>{ document.getElementById("form").style.backgroundColor="blue";}, 1000);
    setTimeout(()=>{ document.getElementById("form").style.backgroundColor="white";}, 1500);
});

var timeout = setInterval(()=>window.dispatchEvent(cust_event),5000);


document.getElementById('name').addEventListener('input', ()=>{
    clearInterval(timeout)
    if(document.getElementById('name').value==='')
        timeout = setInterval(()=>window.dispatchEvent(cust_event),5000);
})

document.getElementById("sbmt").addEventListener('click', (e)=>{
    clearInterval(timeout);
    var val = confirm("Do you want to submit?");

    if(val === false) {
        timeout = setInterval(()=>window.dispatchEvent(cust_event),5000);
        e.preventDefault();
    }
});


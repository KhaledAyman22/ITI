window.addEventListener('keydown', (e)=>{
    if(e.altKey)
        alert("Alt was pressed");
    else if(e.ctrlKey)
        alert("Ctrl was pressed");
    else if(e.shiftKey)
        alert("Shift was pressed");
})


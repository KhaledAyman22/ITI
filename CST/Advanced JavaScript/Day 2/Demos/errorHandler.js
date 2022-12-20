onerror=function(msg,url,l,col,err){
    
    console.log(arguments[0]);//message
    console.log(arguments[4].name);//message
    return false;
}


console.log(x);

/*try {

    console.log("abc");

    setTimeout(function () {
        try {
            console.lo("timeout"); //XXXXX
        } catch (er) {
            if(er instanceof SyntaxError){
                
            }
            console.log(err.name);
            console.log(err.message);
            ////
        }
    }, 1000);

} catch (err) {
    console.log("catch block");
}

console.log("final statement");
*/
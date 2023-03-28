/** require("http") */

const http = require("http");
const fs = require("fs");
let mainHtml = fs.readFileSync("../Client/main.html").toString();
let profileHtml = fs.readFileSync("../Client/profile.html").toString();
let styleCSS = fs.readFileSync("../Client/style.css").toString();
let scriptJS = fs.readFileSync("../Client/script.js").toString();
let img = fs.readFileSync("../Client/Images/2.jpg");
let favIcon = fs.readFileSync("../Client/Icons/favicon.ico");

let userName="";

http.createServer((req, res)=>{
    console.log(req.url);
    //#region GET
    if(req.method == "GET"){
        switch(req.url){
            case '/':
            case '/main.html':
            case '/client/main.html':
                // res.writeHead(200,"Hiiii",{"content-type":"text/html"})//MIME Type
                // res.writeHead(200,"Hiiii",{"set-cookie":"name=Ahmed"})//MIME Type
                // res.writeHead(200,"Hiiii",{"Access-Control-Allow-Origin":"*"})//MIME Type ==> third party module [install] ==> cors ==>
                // res.setHeader("content-type","text/html");
                // // res.setHeader("set-cookie","name=ahmed");
                // res.setHeader("Access-Control-Allow-Origin","*")
                res.write(mainHtml);
            break;
            case '/':
            case '/profile.html':
            case '/client/profile.html':
                res.write(profileHtml);
            break;
            case '/style.css':
            case '/client/style.css':
                res.write(styleCSS);
            break;
            case '/script.js':
            case '/client/script.js':
                res.write(scriptJS);
            break;
            case '/2.jpg':
            case '/client/2.jpg':
            case '/client/Images/2.jpg':
                res.write(img);
            break;
            case '/favicon.ico':
            case '/client/favicon.ico':
            case '/client/Icons/favicon.ico':
                res.write(favIcon);
            break;
            case '/':
                //logic
            break;
            default:
                if(req.url.includes("?userName")){
                    res.write(mainHtml);
                }
            break;
        }
        res.end();
    }
    //#endregion
    
    //#region POST
    else if(req.method=="POST"){
        req.on("data",(data)=>{
            console.log(data.toString());//  userName=Ahmed
            userName = data.toString().split("=")[1];
        })
        req.on("end",()=>{
            res.write(profileHtml.replace("{userName}",userName));
            // res.write(profileHtml);
            res.end();
        })
    }
    //#endregion
   
    //#region PUT
    else if(req.method=="PUT"){

    }
    //#endregion
   
    //#region PATCH
    else if(req.method=="PATCH"){

    }
    //#endregion
   
    //#region DELETE
    else if(req.method=="DELETE"){

    }
    //#endregion
    
    //#region Default
    else{
        res.end("Please Select Common Method");
    }
    //#endregion
}).listen(7007,()=>{console.log("Listining on Port 7007")})
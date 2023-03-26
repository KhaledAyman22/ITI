/**
 * Server ==> Port & http ===> require("http")
 */

const http = require("http");
http.createServer((req,res)=>{
    //logic
    if(req.url != "/favicon.ico"){
        console.log(req.url);
        console.log(req.method);
        console.log(req.body);
        // console.log(req.body);
        res.writeHead(200,"ok",{"content-type":"text/plain"})
        res.write("<h1>Hello World at Server</h1>")
        res.end();
    }
}).listen(7000)

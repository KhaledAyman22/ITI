const FS = require("fs");

const http = require("http");
http.createServer((req, resultp) => {
    //logic
    if (req.url !== "/favicon.ico") {

        let params = req.url.split('/').filter(Boolean);

        let code = 200, mess = "ok", result = 0, first = true, op = params.shift()
        
        switch (op) {
            case "add":
                result = 0
                for (const num of params) {
                    if (isNaN(num))
                    {
                        code = 400
                        mess = "BadRequest"
                        break;
                    }

                    result+=Number(num);
                }
                
                break;
            case "sub":
                result = 0
                for (const num of params) {
                    if (isNaN(num))
                    {
                        code = 400
                        mess = "BadRequest"
                        break;
                    }
                    if(first){
                        first = false
                        result = Number(num)
                    }
                    else
                        result-=Number(num)
                }
                
                break;
            case "mul":
                result = 1
                for (const num of params) {
                    if (isNaN(num))
                    {
                        code = 400
                        mess = "BadRequest"
                        break;
                    }

                    result*=Number(num);
                }
                
                break;
            case "div":
                result = 0
                for (const num of params) {
                    if (isNaN(num))
                    {
                        code = 400
                        mess = "BadRequest"
                        break;
                    }
                    if(first){
                        first = false
                        result = Number(num)
                    }
                    else
                        result/=Number(num)
                }
                
                break;
        }

        FS.appendFile("results.txt", `operation: ${op}, params: ${params}, result: ${result}\n`,
            ()=>{})

        resultp.writeHead(code, mess, {"content-type": "text/plain"})
        resultp.write(`<h1>resultult: ${result}</h1>`)
        resultp.end();
    }
}).listen(7000)

const http = require("http")
const fs = require("fs")

http.createServer((req, res) => {
    if (req.method === "GET") {
        switch (req.url) {
            case "/":
            case "/index.html":
                res.write(fs.readFileSync("../client/html/index.html").toString());
                break;

            case "/js/welcome.js":
                res.write(fs.readFileSync("../client/js/welcome.js").toString());
                break;

            case "/css":
                res.write(fs.readFileSync("../Ex").toString());
                break;

            case "/getUsers":
                let f = OpenUsersFile();
                if (f === []) res.write("[]");
                else res.write(JSON.stringify(f));
                break;
        }
        res.end();
    }

    if (req.method === "POST") {
        let params = null

        req.on("data", (data) => {
            params = new URLSearchParams(data.toString());
        })

        req.on("end", () => {
            let file = fs.readFileSync("../client/html/welcome.html").toString()
            file = file.replace("{name}", params.get("name"));
            file = file.replace("{mobile}", params.get("mobile"));
            file = file.replace("{email}", params.get("email"));
            file = file.replace("{address}", params.get("address"));
            res.write(file);


            let users = OpenUsersFile();
            users.push({
                name: params.get("name"),
                mobile: params.get("mobile"),
                email: params.get("email"),
                address: params.get("address")
            });

            fs.writeFile('../users.json', JSON.stringify(users), () => {
            });

            res.end();
        })
    }
})
    .listen(7000)


function OpenUsersFile() {
    let users = null
    try{
        fs.accessSync('../users.json', fs.constants.F_OK);
        let f = fs.readFileSync('../users.json').toString()
        users = JSON.parse(f);
    }catch (e) {
        users = [];
    }
    return users;
}
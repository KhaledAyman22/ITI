const express = require("express"), fs = require("fs"), path = require("path"), bodyParser = require("body-parser"),
    app = express();

app.use(bodyParser.json())
app.use(bodyParser.urlencoded({extended: true}))

app.get('/', (req, res) => {
    res.sendFile(path.join(__dirname, '../client/html/index.html'));
});

app.get('/index.html', (req, res) => {
    res.sendFile(path.join(__dirname, '../client/html/index.html'));
});

app.get('/js/welcome.js', (req, res) => {
    res.sendFile(path.join(__dirname, '../client/js/welcome.js'));
});

app.get('/getUsers', (req, res) => {
    let f = OpenUsersFile();
    if (f === [])
        res.send("[]");
    else res.send(JSON.stringify(f));
});

app.post('/', (req, res) => {
    console.log(typeof req.body)

    let file = fs.readFileSync("../client/html/welcome.html").toString()
    file = file.replace("{name}", req.body["name"]);
    file = file.replace("{mobile}", req.body["mobile"].toString());
    file = file.replace("{email}", req.body["email"].toString());
    file = file.replace("{address}", req.body["address"]);

    let users = OpenUsersFile();
    users.push({
        name: req.body["name"],
        mobile: req.body["mobile"],
        email: req.body["email"],
        address: req.body["address"]
    });

    fs.writeFile('../users.json', JSON.stringify(users), () => {
    });

    res.send(file);
});

app.listen(7000)

function OpenUsersFile() {
    let users;
    try {
        fs.accessSync('../users.json', fs.constants.F_OK);
        let f = fs.readFileSync('../users.json').toString()
        users = JSON.parse(f);
    } catch (e) {
        users = [];
    }
    return users;
}
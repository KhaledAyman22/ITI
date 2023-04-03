// let myMod = require("../Modules/umdModule");
// // console.log(myMod);
// console.log(myMod);


const exp = require("express");
const app = exp();
const path = require("path");
let PORT = process.env.PORT || 7008;
const bodyParser = require("body-parser");
/** JSON.parse() */
/**MiddleWare */
app.use(bodyParser.json())
app.use(bodyParser.urlencoded({extended:true}))

//custom Middleware
app.all("*",(req,res,hamada)=>{
    console.log("MiddleWare Called");
    // res.send("");
    hamada();
})

app.get("/",(req,res)=>{
    console.log("Ana 3la / Get")
    res.send("Hello world")
})
app.get("/main.html",(req,res)=>{
    // res.sendFile("C:/Users/pmost/Desktop/Pd, SWA, Mobile/3-Node JS/Day3/Demo/Client/main.html")
    res.sendFile(path.join(__dirname,"../Client/main.html"))
})
app.get("/:op/:num1/:num2/*",
    (req,res,next)=>{
        console.log(req.params.num1);//{}
        req.params.num1 = 10;
        next()
    },(req,res,next)=>{
        console.log(req.params.num1);//10
        next()
    },(req,res)=>{
    console.log(req.params);//{op:add, num1:5, num2:7}
    res.send("Operation Endded")
})
app.post("/",(req,res)=>{
    // console.log(JSON.parse(req.body));
    console.log(req.body);
    res.send("Post Called")
})

app.all("*",(req,res)=>{
    console.log("MiddleWare Called");
    // res.send("");
    res.send("Please Check ur URL")
})

app.listen(PORT,()=>{console.log("http://www.localhost:"+PORT)});




// console.log(path.join(__dirname,"../Client/main.html"))

// app.delete("",(req,res)=>{})
// app.post("",(req,res)=>{})
// app.patch("",(req,res)=>{})
// app.put("",(req,res)=>{})

//
//cors

//Server
/**
 * 1-express [npm i express]
 * 2-path
 * 3-body-parser
 * 4-port [process.env.PORT]
 * 5-ejs [npm i ejs]
 */

const exp = require("express");
const app = exp();
const PORT = process.env.PORT || 7009;
const path = require("path");
const bodyParser = require("body-parser");
app.use(bodyParser.urlencoded({extended:true}));
app.use(bodyParser.json());
app.use(exp.static(__dirname+"/public"));
// app.use("/assets",exp.static(__dirname+"/public"));

//DB
let userName = "Aly";
let userObj = {userName:"Haitham", age:20, address:"123 st."}
let users = [
    {userName:"Sara", age:22, address:"456 st."},
    {userName:"Samy", age:23, address:"789 st."},
    {userName:"Ahmed", age:24, address:"123 st."},
    {userName:"Nada", age:26, address:"456 st."}
]

app.get("/",(req,res)=>{
    // res.render("home.ejs",{user:userObj, users});
    res.render("home.ejs",{user:userObj, name:userName, users});
})

app.get("/profile/:userName",(req,res)=>{
    let userName = req.params.userName;
    res.render("profile.ejs", {userName});
    // res.redirect("/")
})

app.listen(PORT,()=>{console.log("http://localhost:"+PORT)})



















// const exp = require("express");
// const app = exp();
// const PORT = process.env.PORT || 7009;
// const path = require("path");
// const bodyParser = require("body-parser");
// app.use(bodyParser.urlencoded({extended:true}));
// app.use(bodyParser.json());
// app.use(exp.static(__dirname+"/public"));


// app.listen(PORT,()=>{console.log("http://localhost:"+PORT)})
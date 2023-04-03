/**
 * 1-express
 * 2-path
 * 3-port
 * 4-ejs
 * 5-app.use(exp.static())
 * 6-mongoose [npm i mongoose]
 * 7-Steps of mongoose
 */

//#region Requires
const exp = require("express");
const mongoose = require("mongoose");
const app = exp();
const PORT = process.env.PORT || 7009;
const path = require("path");
const bodyParser = require("body-parser");
//#endregion

//#region MiddleWare
app.use(bodyParser.urlencoded({extended:true}));
app.use(bodyParser.json());
app.use(exp.static(__dirname+"/public"));
//#endregion

//#region Mongoose Configuration 
//1)Connect With DB
    mongoose.connect("mongodb://127.0.0.1:27017/Bank",{useNewUrlParser:true});
//2)Create Schema
    // var BankSchema = mongoose.Schema;
    // let creditCardCustomersSchema = new BankSchema({});
    // let depitCardCustomersSchema = new BankSchema({});
    let creditCardCustomersSchema = new mongoose.Schema({
        CLIENTNUM: Number,
        Customer_Age: Number,
        Gender: String,
        Marital_Status: String,
        Income_Category: String,
        Credit_Limit: Number
    })

//3)Connect With Collection ==> model ==> model.find - All Methods mongo
    let creditCardCustomer = mongoose.model("creditcardcustomers",creditCardCustomersSchema)
//4)Event Listener [Error - Open] ==> mongoose.connection.on||once
mongoose.connection.on("error",()=>{console.log("7asal Error")})
mongoose.connection.once("open",()=>{
    console.log("Connected Successfully");
    //Handle All Requests Here
    app.get("/clients", async (req,res)=>{
        //1)Get All Data From Mongo
        let allData = await creditCardCustomer.find({});
        // res.json(allData);
        res.render("mongo.ejs",{clients:allData});
        //2)response to Front ==> res.render(viwe,{data:})
    })
    app.get("/add",(req,res)=>{
        res.render("AddNewCustomer.ejs")
    })
    app.post("/add", async (req,res)=>{
        //1)Get Body [req.body]
        // console.log(req.body);
        var body = req.body;
        //2)Create New Element [Body] ==> var newCus = new creditCardCustomer(body)
        var newCustomer = new creditCardCustomer(body);
        //3)Save DB ==> newCus.save()
        await newCustomer.save();
        //4) res???
        res.redirect("/clients");
    })
    app.get("/delete/:id", async (req,res)=>{
        //find Element By iD ==> Delete
        await creditCardCustomer.findByIdAndDelete(req.params.id);
        res.redirect("/clients");
    })
})
// 768805383
//#endregion


app.listen(PORT,()=>{console.log("http://localhost:"+PORT)})


/**
 * Socket[real chat App] ==> mongoose
 * 2 Browsers [user1 - user2]
 * publish ==> real chat ==> vercal - render - 000webhost - heroku
 */
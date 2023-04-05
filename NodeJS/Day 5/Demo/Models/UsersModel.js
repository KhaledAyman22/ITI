//mongoDB ==> mongoose

//Connect DB [School] [Students - Parents - Inst - ] [users]
//Schema
//module.exports = mongoose.model("collection", schema)

const mongoose = require("mongoose");
mongoose.connect("mongodb://127.0.0.1:27017/PDSWAMOBILE");

//2)Create Schema
usersSchema = new mongoose.Schema({
    name:String,
    age:Number,
    email:String,
    password:String
})

//3)Connect Schema With Collection
module.exports = mongoose.model("users",usersSchema);


//mongoose.connection.on("error",()=>{})
//mongoose.connection.once("open",()=>{})
//exec() ==> [async await]
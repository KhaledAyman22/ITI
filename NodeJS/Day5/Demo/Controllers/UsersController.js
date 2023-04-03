const userModel = require("../Models/UsersModel");//.find .findOneAndUpdate
const bcrypt = require("bcrypt");

let AddNewUser = async (req,res)=>{
    //DB
    /**
     * 1-body ==> email ===> Exist
     * 2- Email Exist ==> "Already Exist"
     * 3- Email Not Exist ==> next Step ==> Hash Password
     * 4- Add User to DB
     */
    let newUser = req.body;
    let foundUser = await userModel.findOne({email:newUser.email}).exec();//found[true] || notFound[false]
    if(foundUser) return res.status(401).json({message:"User Already Exist !!"});

    //Hash Password?? [npm i bcrypt]
    let genSalt = await bcrypt.genSalt(10);
    let hashedPassword = await bcrypt.hash(newUser.password, genSalt);
    newUser.password = hashedPassword;

    let newUSER = new userModel(newUser);
    await newUSER.save();

    return res.status(201).json({message:"User Added Successfully",data:newUSER});

}


let LoginUser = async (req,res)=>{
    //DB
    let logUser = req.body;//From Client
    let foundUser = await userModel.findOne({email:logUser.email}).exec();//From DB [Encrypted]
    if(!foundUser) return res.status(401).json({message:"Invalid Email Or Password"});

    //2)Check Password
    let checkPass = bcrypt.compareSync(logUser.password, foundUser.password);//true | false
    if(!checkPass) return res.status(401).json({message:"Invalid Email Or Password"});

    res.status(200).json({message:"Logged-In Successfully"})

}


module.exports = {
    AddNewUser,
    LoginUser
}



//jwt ==> [npm i jsonwebtoken]


//
/**
 * Doctor & Patient [MVC] [MongoDB]
 * 
 * 
 * 
 * users name, age, email, password +++++
 */
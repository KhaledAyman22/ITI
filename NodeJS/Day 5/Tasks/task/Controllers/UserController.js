const UserModel = require("../Models/User");
const UserValidation = require("../Schemas/UserValidationSchema")
const bcrypt = require("bcrypt");

let Register = async (req, res) => {
    if(UserValidation(req.body)) {
        let foundUser = await UserModel.findOne({email: req.body.email}).exec();
        if (foundUser) return res.render('Shared/error.ejs', {message: "Email already exists"});

        let genSalt = await bcrypt.genSalt(10);
        req.body.password = await bcrypt.hash(req.body.password, genSalt);

        await UserModel.create(req.body)
            .then((doc) => {
                res.redirect('/doctors/')
            })
            .catch((err) => {
                res.render('Shared/error.ejs', {message: `Couldn't register user\nError: ${err}`})
            });
        return;
    }

    return res.render('Shared/error.ejs', {message: "Invalid user object."})
}

let Login = async (req, res) => {
    let foundUser = await UserModel.findOne({email: req.body.email}).exec();
    if (!foundUser) return res.render('Shared/error.ejs', {message: "Invalid Email Or Password"});

    let checkPass = bcrypt.compareSync(req.body.password, foundUser.password);
    if (!checkPass) return res.render('Shared/error.ejs', {message: "Invalid Email Or Password"});

    res.redirect('/doctors/')
}

let RegisterHome = async (req, res) => {
    res.render('Shared/register.ejs')
}

let LoginHome = async (req, res) => {
    res.render('Shared/login.ejs')
}

module.exports = {
    Register, RegisterHome, Login, LoginHome
}
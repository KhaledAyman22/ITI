const DoctorValidation = require("../Schemas/DoctorValidationSchema");
const DoctorModel = require("../Models/Doctor");
const bcrypt = require("bcrypt");

let CreatePage = async (req, res) =>{
    res.render('Doctor/addDoctor.ejs')
}

let UpdatePage = async (req, res) =>{
    let doctor = await DoctorModel.findById(req.params.id).exec()
    res.render('Doctor/updateDoctor.ejs', {doctor})
}

let CreateDoctor = async (req, res) => {
    if (DoctorValidation(req.body)) {
        let user = await DoctorModel.findOne({email: req.body.email}).exec()

        if (user) {
            res.render('Shared/error.ejs',{message:"Email already used."})
        }
        else {
            let genSalt = await bcrypt.genSalt(10);
            req.body.password = await bcrypt.hash(req.body.password, genSalt);

            await DoctorModel.create(req.body)
                .then((doc) => {
                    res.redirect('/doctors')
                })
                .catch((err) => {
                    res.render('Shared/error.ejs',{message:err});
                });
        }
    }
    else {
        res.render('Shared/error.ejs',{message:"Invalid object"})
    }
}

let DeleteDoctor = async (req, res) => {
    let doctor = await DoctorModel.findByIdAndDelete(req.params.id).exec()
    if (doctor) {
        res.redirect('/doctors')
    }
    else {
        res.render('Shared/error.ejs',{message:"Invalid Id"})
    }
}

let GetDoctor = async (req, res) => {
    let doctor = await DoctorModel.findById(req.params.id).exec()
    if (doctor) {
        res.render('Doctor/doctorDetails.ejs', {doctor})
    }
    else {
        res.render('Shared/error.ejs',{message:"Invalid Id"})
    }
}

let GetDoctors = async (req, res) => {
    let doctors = await DoctorModel.find().exec()
    res.render('Doctor/doctors.ejs', {doctors})
}

let UpdateDoctor = async (req, res) => {
    if (DoctorValidation(req.body)) {
        let doctor = await DoctorModel.findByIdAndUpdate(req.params.id, req.body).exec()
        if (doctor) {
            res.redirect('/doctors');
        }
        else {
            res.render('Shared/error.ejs',{message:"Couldn't Update"})
        }
    }
}

module.exports = {
    CreateDoctor, DeleteDoctor, GetDoctor, GetDoctors, UpdateDoctor,
    CreatePage, UpdatePage
}
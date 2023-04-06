const PatientValidation = require("../Schemas/PatientValidationSchema")
const PatientModel = require("../Models/Patient");
const bcrypt = require("bcrypt");

let CreatePage = async (req, res) => {
    res.render('Patient/addPatient.ejs')
}

let UpdatePage = async (req, res) => {
    let patient = await PatientModel.findById(req.params.id).exec()
    res.render('Patient/updatePatient.ejs', {patient})
}

let CreatePatient = async (req, res) => {
    if (PatientValidation(req.body)) {
        let user = await PatientModel.findOne({email: req.body.email}).exec()

        if (user) {
            res.render('Shared/error', {message: "Email already used."})
        }
        else {
            let genSalt = await bcrypt.genSalt(10);
            req.body.password = await bcrypt.hash(req.body.password, genSalt);

            await PatientModel.create(req.body)
                .then((doc) => {
                    res.redirect('/patients')
                })
                .catch((err) => {
                    res.render('Shared/error', {message: err})
                });
        }
    }
    else {
        res.render('Shared/error', {message: "Invalid Object."})
    }
}

let DeletePatient = async (req, res) => {
    let patient = await PatientModel.findByIdAndDelete(req.params.id).exec()
    if (patient) {
        res.redirect('/patients')
    }
    else {
        res.render('Shared/error', {message: "Invalid Id"})
    }
}

let GetPatient = async (req, res) => {
    let patient = await PatientModel.findById(req.params.id).exec()
    if (patient) {
        res.render('Patient/patientDetails.ejs', {patient})
    }
    else {
        res.render('Shared/error', {message: "Invalid Id"})
    }
}

let GetPatients = async (req, res) => {
    let patients = await PatientModel.find().exec()
    res.render('Patient/patients.ejs', {patients})
}

let UpdatePatient = async (req, res) => {
    if (PatientValidation(req.body)) {
        let patient = await PatientModel.findByIdAndUpdate(req.params.id, req.body).exec()
        if (patient) {
            res.redirect('/patients')
        }
        else {
            res.render('Shared/error', {message: "Couldn't update"})
        }
    }
}

module.exports = {
    CreatePatient, DeletePatient, GetPatient, GetPatients, UpdatePatient,
    CreatePage, UpdatePage
}
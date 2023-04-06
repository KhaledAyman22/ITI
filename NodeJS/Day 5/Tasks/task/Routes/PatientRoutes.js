const express = require("express");
const router = new express.Router();
const PatientController = require("../Controllers/PatientController");

router.get("", PatientController.GetPatients);
router.get("/create", PatientController.CreatePage);
router.get("/update/:id", PatientController.UpdatePage);
router.get("/:id", PatientController.GetPatient);

router.post("/create", PatientController.CreatePatient);

router.post("/update/:id", PatientController.UpdatePatient);

router.get("/delete/:id", PatientController.DeletePatient);

module.exports = router;
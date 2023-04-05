const express = require("express");
const router = new express.Router();
const PatientController = require("../Controllers/PatientController");

router.get("", PatientController.GetPatients);
router.get("/create", PatientController.CreatePage);
router.get("/update", PatientController.UpdatePatient);
router.get("/:id", PatientController.GetPatient);

router.post("/create", PatientController.CreatePatient);

router.post("/update/:id", PatientController.UpdatePage);

router.delete("/delete/:id", PatientController.DeletePatient);

module.exports = router;
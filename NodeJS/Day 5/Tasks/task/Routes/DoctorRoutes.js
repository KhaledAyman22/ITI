const express = require("express");
const router = new express.Router();
const DoctorController = require("../Controllers/DoctorController");

router.get("", DoctorController.GetDoctors);
router.get("/create", DoctorController.CreatePage);
router.get("/update/:id", DoctorController.UpdatePage);
router.get("/:id", DoctorController.GetDoctor);

router.post("/create", DoctorController.CreateDoctor);

router.post("/update/:id", DoctorController.UpdateDoctor);

router.get("/delete/:id", DoctorController.DeleteDoctor);

module.exports = router;
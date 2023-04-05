const express = require("express");
const router = new express.Router();
const UserController = require("../Controllers/UserController");

router.get("/register", UserController.RegisterHome);
router.get("/login", UserController.LoginHome);
router.get("", UserController.RegisterHome);
router.post("/register", UserController.Register);
router.post("/login", UserController.Login);

module.exports = router;
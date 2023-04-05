const express = require("express");
const router = new express.Router();
const UsersController = require("../Controllers/UsersController");

router.post("/reg",UsersController.AddNewUser);
router.post("/login",UsersController.LoginUser);

module.exports = router;
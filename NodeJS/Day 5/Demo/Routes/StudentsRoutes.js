const express = require("express");
const router = new express.Router();
const StudnetsController = require("../Controllers/StudentsController");//{GetAllStudent:()=>{}, Get}

//Get All Students
router.get("/", StudnetsController.GetAllStudents);
//Get Student By ID
router.get("/:id", StudnetsController.GetStudentByID);
//Add New Student
router.post("/create", StudnetsController.AddNewStudnet);
//Update Student
router.put("/update/:id", StudnetsController.UpdateStudentById);
//Delete Student
router.delete("/delete/:id", StudnetsController.DeleteStudentByID);

module.exports = router;


//Controllers
/**
 * router.get("/",GetAllStudents) ===> (req,res)=>{res.json(Students)}
 * router.get("/:id",GetStudentByID)
 * router.post("/create",AddNewStudent)
 * router.put("/update/:id",UpdataStudent)
 * router.delete("/delete/:id",DeleteStudent)
 */
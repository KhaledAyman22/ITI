const express = require("express");
const router = new express.Router();
const CourseValidate = require("../utils/courseSchema");


//#region Courses Array
var Courses = [];//{id, name, duration, desc}
var course_id = 0;
//#endregion


//Get All Courses
router.get("/",(req,res)=>{
    res.status(200).json(Courses);
})
//Get Course By ID
router.get("/:id",(req,res)=>{
    let ID = req.params.id;
    let foundCourse = Courses.find((Course)=>{return Course.id == ID})||{};
    res.status(200).json(foundCourse);
})
//Add New Course
router.post("/create",(req,res)=>{
    let oneCourse = req.body;//{name, age, courses}
    ++course_id;
    oneCourse.id = course_id;
    Courses.push(oneCourse);
    res.status(201).json({message: "Created Successfully", data:oneCourse});
})
//Update Course
router.put("/update/:id",(req,res)=>{
    //Course??? ==> id ===> data from body
    let ID = req.params.id;
    let UpdatedCourse = req.body;
    let foundCourse = Courses.find((Course)=>{
        //condition ==> Course.id == ID ==> Course.name = 
        if(Course.id == ID){
            Course.name = UpdatedCourse.name;
            Course.age = UpdatedCourse.age;
            Course.courses = UpdatedCourse.courses;
        }
        return Course.id == ID
    })
    res.status(200).json({message:"Updated Successfully", data:foundCourse})
})
//Delete Course
router.delete("/delete/:id",(req,res)=>{
    let ID = req.params.id;
    let foundIndex = Courses.findIndex((Course)=>{return Course.id == ID});
    Courses.splice(foundIndex, 1);
    res.send("Deleted Successfully");
})

module.exports = router;
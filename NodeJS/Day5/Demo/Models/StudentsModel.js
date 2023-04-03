//DB ==> Mongo

const StudentValidate = require("../utils/studentSchema");

//#region Students Array
var Students = [];//{id, name, age, courses}
var student_id = 0;
//#endregion


class Student{
    constructor(name, age, dept, courses){
        this.name = name;
        this.age = age;
        this.dept = dept ;
        this.courses = courses;
    }
    static GetAllStudents(){
        return Students;
    }
    SaveStudent(){
        //push at Array ==> this
        if (StudentValidate(this)) {
            ++student_id;
            this.id = student_id;
            Students.push(this);
            return { message: "Created Successfully", data: this, status:201 }
            // res.status(201).json({ message: "Created Successfully", data: oneStudent });
          } else {
            return {message:"Check ur Data Type", status:401}
            // res.send("Check ur Data Type");
          }
    }
}

module.exports = Student;

//Add New Student
/**
 * var s1 = new Student(body.name, body);
 * s1.SaveStudnet()
 * 
 * s1.GetAllStudent() XXXXXX
 * Student.GetAllStudent() ; 
 * 
 */


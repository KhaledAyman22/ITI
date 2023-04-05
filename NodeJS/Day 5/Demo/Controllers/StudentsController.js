const StudentValidate = require("../utils/studentSchema");
const StudentModel = require("../Models/StudentsModel");//Class

let GetAllStudents = (req, res) => {
        let AllStudents = StudentModel.GetAllStudents();//[]
        // res.status(200).json(Students);
        res.status(200).json(AllStudents);
    }

let GetStudentByID = (req, res) => {
    let ID = req.params.id;
    let foundStudent =
      Students.find((student) => {
        return student.id == ID;
      }) || {};
    res.status(200).json(foundStudent);
  }

let AddNewStudnet = (req, res) => {
    let oneStudent = req.body; //{name, age, courses}
    let newStudent = new StudentModel(oneStudent.name,oneStudent.age,oneStudent.dept,oneStudent.courses);
    let studentRes = newStudent.SaveStudent();
    res.status(studentRes.status).json(studentRes);
    //console.log(oneStudent);
    // console.log(validate(oneStudent));//true || false
    // if (StudentValidate(oneStudent)) {
    //   ++student_id;
    //   oneStudent.id = student_id;
    //   Students.push(oneStudent);
    //   res.status(201).json({ message: "Created Successfully", data: oneStudent });
    // } else {
    //   res.send("Check ur Data Type");
    // }
  }

let UpdateStudentById = (req, res) => {
    //student??? ==> id ===> data from body
    let ID = req.params.id;
    let UpdatedStudent = req.body;
    if (StudentValidate(UpdatedStudent)) {
      let foundStudent = Students.find((student) => {
        //condition ==> student.id == ID ==> student.name =
        if (student.id == ID) {
          student.name = UpdatedStudent.name;
          student.age = UpdatedStudent.age;
          student.dept = UpdatedStudent.dept;
          student.courses = UpdatedStudent.courses;
        }
        return student.id == ID;
      });
      res
        .status(200)
        .json({ message: "Updated Successfully", data: foundStudent });
    } else {
      res.send("Check ur Data Type");
    }
  }

let DeleteStudentByID = (req, res) => {
    let ID = req.params.id;
    let foundIndex = Students.findIndex((student) => {
      return student.id == ID;
    });
    Students.splice(foundIndex, 1);
    res.send("Deleted Successfully");
  }

module.exports = {
    GetAllStudents,
    GetStudentByID,
    UpdateStudentById,
    AddNewStudnet,
    DeleteStudentByID
}


/**
 * Models ==> class [Methods] ==> GetAllStudents
 */
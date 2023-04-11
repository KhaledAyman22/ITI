import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {StudentsService} from "../../Services/students.service";

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
})
export class AddComponent{
  student = {
    name:'',
    email:'',
    age:'',
    courses:'',
    phone:''
  }

  constructor(private studentService: StudentsService, private router: Router) {
  }

  Add(){
    let tmp = {
      name: this.student.name,
      age: this.student.age,
      email: this.student.email,
      phone: this.student.phone,
      courses: this.student.courses.split(',').map(s => s.trim())
    }

    this.studentService.AddStudent(tmp).subscribe(
      {
        next:(data)=>{
          this.router.navigate(['']);
        },
        error: (err)=>{
          console.log(err)
        }
      })
  }
}

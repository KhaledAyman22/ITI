import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {StudentsService} from "../../Services/students.service";

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
})
export class UpdateComponent implements OnInit {
  id: any
  student: any

  constructor(private route: ActivatedRoute, private studentService: StudentsService, private router: Router) {
    this.id = route.snapshot.params["id"];
  }

  ngOnInit(): void {
    this.studentService.GetStudent(this.id).subscribe({
      next: (data) => {
        this.student = data;
      },
      error: (err) => {
        console.log(err)
      }
    })
  }

  Update(){
    this.studentService.UpdateStudent(this.id, this.student).subscribe(
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

import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {StudentsService} from "../../Services/students.service";

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
})
export class DetailsComponent implements OnInit {
  id: any
  student: any

  constructor(private route: ActivatedRoute, private studentService: StudentsService) {
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

}

import {Component, OnInit} from '@angular/core';
import {StudentsService} from "../../Services/students.service";
import {Router} from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  students: any

  constructor(private studentsService: StudentsService, private router: Router) {
  }

  ngOnInit(): void {
    this.studentsService.GetStudents().subscribe(
      {
        next: (data) => {
          this.students = data;
        },
        error: (err) => {
          console.log(err)
        }
      }
    );
  }

  Delete(id: any) {
    this.studentsService.DeleteStudent(id).subscribe(
      {
        next: () => {
          this.studentsService.GetStudents().subscribe(
            {
              next: (data) => {
                this.students = data;
              },
              error: (err) => {
                console.log(err)
              }
            }
          );
        },
        error: (err) => {
          console.log(err)
        }
      }
    );
  }
}

import {Component} from '@angular/core';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styles: []
})
export class StudentsComponent {
  students = [
    {
      name: "Alice",
      age: 20,
      email: "alice@example.com"
    },
    {
      name: "Bob",
      age: 21,
      email: "bob@example.com"
    },
    {
      name: "Charlie",
      age: 22,
      email: "charlie@example.com"
    }
  ]


}

import { Component } from '@angular/core';

@Component({
  selector: 'app-all-in-one',
  templateUrl: './all-in-one.component.html',
  styleUrls: ['./all-in-one.component.css']
})
export class AllInOneComponent {
  name = "";
  age = "";
  Students:{name:string, age:string}[] = [];
  add(){
    let newStudent = {name:this.name, age:this.age};
    if(+this.age <= 50)
    {
      this.Students.push(newStudent);
      this.name = "";
      this.age = "";
    }
    // console.log(this.Students);
  }
}

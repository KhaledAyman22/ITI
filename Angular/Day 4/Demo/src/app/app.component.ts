import { Component } from '@angular/core';

//Decorator
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',//HTML
  styleUrls: ['./app.component.css']//CSS
})
export class AppComponent {//Logic
  // title = 'demo';
  // DataParent = "2na Data Mn El Parent";
  // DataFromLogin = "";
  // fName = "Ahmed"
  // getData(data:any){
  //   // console.log(data);
  //   this.DataFromLogin = data;
  // }
  //Logic

  //Day4
  // Students:{name:string, age:string}[]=[];
  oneStudent:any;
  getData(data:any){
    // this.Students.push(data);
    this.oneStudent = data;
  }
}

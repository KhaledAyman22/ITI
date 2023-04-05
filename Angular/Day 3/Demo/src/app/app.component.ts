import { Component } from '@angular/core';

//Decorator
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',//HTML
  styleUrls: ['./app.component.css']//CSS
})
export class AppComponent {//Logic
  title = 'demo';
  DataParent = "2na Data Mn El Parent";
  DataFromLogin = "";
  fName = "Ahmed"
  getData(data:any){
    // console.log(data);
    this.DataFromLogin = data;
  }
  //Logic
}

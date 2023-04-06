import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  DataLogin = "2na Data Mn El Login";
  // constructor(){
  //   setTimeout(()=>{
  //     this.myEvent.emit(this.DataLogin);
  //   },3000)
  // }
  @Output("EventDala3") myEvent = new EventEmitter();

  Fire(){
    this.myEvent.emit(this.DataLogin);
  }
  //Data ==> ??
  //Fire?? ==> emit(data)
}

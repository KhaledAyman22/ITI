import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: [
  ]
})
export class RegistrationComponent {
  // name="";
  // age="";
  @Output() myEvent = new EventEmitter();
  Add(name:string, age:string){
    let newStudent= {name, age};
    this.myEvent.emit(newStudent);
  }
}

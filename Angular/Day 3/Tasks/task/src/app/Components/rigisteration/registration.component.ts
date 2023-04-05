import {Component, EventEmitter, Output} from '@angular/core';

interface User {
  name: string;
  age: number;
}

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {
  user: User ={
    name:'',age:21
  }

  @Output() newUser = new EventEmitter();

  Register(): void {
    if (this.user.name.length < 3 || this.user.age < 20 || this.user.age > 40) return;

    this.newUser.emit({
      name: this.user.name,
      age: this.user.age
    });
  }
}

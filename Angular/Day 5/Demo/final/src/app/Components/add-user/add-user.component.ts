import { Component } from '@angular/core';
import { UsersService } from 'src/app/Services/users.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styles: [
  ]
})
export class AddUserComponent {
  constructor(private myService:UsersService){}

  Add(name:any, email:any, phone:any){
    //service==>AddNewUser().subscribe()
    let newUser = {name, email, phone};
    this.myService.AddNewUser(newUser).subscribe();
  }

}

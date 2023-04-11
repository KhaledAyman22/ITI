import { Component,OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UsersService } from 'src/app/Services/users.service';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styles: [
  ]
})
export class UserDetailsComponent implements OnInit {
  ID:any;
  user:any;//undefined ==> falsy Value
  constructor(myActivated:ActivatedRoute, private myService:UsersService){
    this.ID = myActivated.snapshot.params["id"];
  }
  ngOnInit(): void {
    this.myService.getUserByID(this.ID).subscribe({
      next:(data)=>{
        //console.log(data)
        this.user = data;
      },
      error:(err)=>{console.log(err)},
    })
  }

}





/**
 * 1- Get ID ==> ActivateRoute
 * 2- Fetch APi With this ID
 * 3- Fetch At Start Of Component [OnInit]
 */

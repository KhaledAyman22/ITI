import { Component, OnInit } from '@angular/core';
import { UsersService } from 'src/app/Services/users.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styles: [
  ]
})
export class UsersComponent implements OnInit {
  constructor(private myService:UsersService){}

  users:any;

  //Call API [OnInit]
  ngOnInit(): void {
    //throw new Error('Method not implemented.');
    // this.myService.getAllUsers().subscribe(
    //   (data)=>{console.log(data)},
    //   (err)=>{console.log(err)}
    // );
    this.myService.getAllUsers().subscribe(
      {
        next:(data)=>{
          //console.log(data)
          this.users = data;
        },
        error:(err)=>{console.log(err)}
      }
    );
  }


}

import { Component } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: [
  ]
})
export class HomeComponent {
  formValidation = new FormGroup({
    name:new FormControl("John Doe",[Validators.minLength(3), Validators.required]),
    age:new FormControl(20,[Validators.min(20), Validators.max(40), Validators.required]),
    email:new FormControl("example@example.com",[Validators.email, Validators.required])
  })

  valid: boolean = false

  get NameValid(){
    return this.formValidation.controls["name"].valid
  }

  get AgeValid(){
    return this.formValidation.controls["age"].valid
  }

  get EmailValid(){
    return this.formValidation.controls["email"].valid
  }

  Check():void{
    console.log('here')
    if(this.NameValid && this.AgeValid && this.EmailValid){
      this.valid = true
      setTimeout(()=>{this.valid = false},3000)
    }
  }
}

import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-validation',
  templateUrl: './validation.component.html',
  styles: [
  ]
})
export class ValidationComponent {
  formValidation = new FormGroup({
    name:new FormControl("KOKO",Validators.required),
    age:new FormControl(0,[Validators.min(20), Validators.max(40)])
  })

  get NameValid(){
    return this.formValidation.controls["name"].valid
  }


  get AgeValid(){
    return this.formValidation.controls["age"].valid
  }

  getValue(){
    console.log("Form: ",this.formValidation.valid);
    console.log("Name: ",this.formValidation.controls["name"].valid);
    console.log("Age: ",this.formValidation.controls["age"].valid);
  }
}

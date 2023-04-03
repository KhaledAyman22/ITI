import { Component } from '@angular/core';

@Component({
  selector: 'app-first-component',
  templateUrl: './first-component.component.html',
  styleUrls: ['./first-component.component.css']
})
export class FirstComponentComponent {

  public input:String = "";

  InputChange(e: any) {
    this.input = e.target.value;
    console.log(typeof e);
  }

  Reset(e: any) {
    this.input = "";
  }
}

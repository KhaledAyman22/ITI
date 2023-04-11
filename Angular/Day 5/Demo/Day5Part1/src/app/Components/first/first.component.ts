import { Component } from "@angular/core";

@Component({
  selector:"app-first",
  templateUrl:"./first.component.html",
  styleUrls:["./first.component.css"]
})
export class FirstComponent{
  name = "Ahmed";
  imgSrc = "assets/Images/1.jpg";
  fName = "";
  lName = "";
  chg(){
    this.name = "Aly";
    this.imgSrc = "assets/Images/2.jpg";
  }

  getData(e:any){
    // console.log(e.target.value);
    this.fName = e.target.value;
  }
}

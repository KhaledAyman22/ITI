import { Directive, ElementRef, HostListener, Input } from '@angular/core';

@Directive({
  selector: '[appCustom]'
})
export class CustomDirective {

  constructor(private myRef:ElementRef) {
    // console.log(myRef);
    myRef.nativeElement.style.color = "red";
    myRef.nativeElement.style.backgroundColor = "blue";
  }

  @HostListener("click") click(){
    // this.myRef.nativeElement.style.color = "blue";
    // this.myRef.nativeElement.style.backgroundColor = "yellow";
    this.myRef.nativeElement.style.color = this.objColor.fc;
    this.myRef.nativeElement.style.backgroundColor = this.objColor.bc;
  }

  // @Input("appCustom") color="";
  @Input("appCustom") objColor:any;

}





/**
 * <input *ngIf="asdad" >
 * <input [appCustom]="{fc:'', bc:''}" >
 */

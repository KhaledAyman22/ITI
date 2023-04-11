import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styles: [
  ]
})
export class StudentsComponent implements OnChanges {
  ngOnChanges(changes: SimpleChanges): void {
    // console.log(changes);
    //throw new Error('Method not implemented.');
    // this.allStudents.push(this.student);
    // if(changes["student"].currentValue){
    // if(!changes["student"].firstChange){
    if(this.student){
      this.allStudents.push(this.student);
    }
  }
  // @Input() allStudents:any;
  allStudents:{name:string, age:string}[]=[];
  @Input() student:any;//undefined
  //push???
  //how to know u recived new Student??
  //Angular Component life cycle [Constructor] ==> [ngDestroy]
}

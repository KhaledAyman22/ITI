import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-user-item',
  templateUrl: './user-item.component.html',
  styles: [
  ]
})
export class UserItemComponent {
  @Input() oneUser:any;
}

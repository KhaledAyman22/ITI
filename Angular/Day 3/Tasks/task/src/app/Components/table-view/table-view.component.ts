import {Component, Input} from '@angular/core';

interface User {
  name: string;
  age: number;
}

@Component({
  selector: 'app-table-view',
  templateUrl: './table-view.component.html',
  styleUrls: ['./table-view.component.css']
})

export class TableViewComponent {
  @Input() users: User[] = []
}

import { Component } from '@angular/core';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styles: [
  ]
})
export class DetailsComponent {
    user = {
      name: "Bob",
      age: 21,
      email: "bob@example.com"
    }
}

import {Component} from '@angular/core';

@Component({
  selector: 'app-second-component',
  templateUrl: './second-component.component.html',
  styleUrls: ['./second-component.component.css']
})
export class SecondComponentComponent {
  count: number = 1;

  imgSrc: String = `assets/images/${this.count}.jpg`;

  interval: any;

  Next(e: any) {
    if (this.count != 5) {
      this.count++;
      this.SetImgSrc();
    }
  }

  Prev(e: any) {
    if (this.count != 1) {
      this.count--;
      this.SetImgSrc();
    }
  }

  Slide($event: MouseEvent) {
    clearInterval(this.interval);

    this.interval = setInterval(() => {
      this.count = (this.count + 1) % 6
      if (this.count == 0) this.count = 1;
      this.SetImgSrc();
    }, 1000)
  }

  Stop($event: MouseEvent) {
    clearInterval(this.interval);
  }


  SetImgSrc() {
    this.imgSrc = `assets/images/${this.count}.jpg`;
  }
}

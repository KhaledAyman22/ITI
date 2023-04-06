import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { MainComponent } from './Components/main/main.component';
import { HomeComponent } from './Components/home/home.component';
import { StudentsComponent } from './Components/students/students.component';
import { DetailsComponent } from './Components/details/details.component';
import { ErrorComponent } from './Components/error/error.component';
import {RouterLink, RouterLinkActive, RouterModule, RouterOutlet} from "@angular/router";
import {ReactiveFormsModule} from "@angular/forms";

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    HomeComponent,
    StudentsComponent,
    DetailsComponent,
    ErrorComponent
  ],
  imports: [
    BrowserModule,
    RouterLink,
    RouterLinkActive,
    RouterOutlet,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {path:"",component:HomeComponent},
      {path:"students",component:StudentsComponent},
      {path:"details",component:DetailsComponent},
      {path:"**",component:ErrorComponent},
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

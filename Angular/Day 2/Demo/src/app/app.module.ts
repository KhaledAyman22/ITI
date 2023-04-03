import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { FirstComponent } from './Components/first/first.component';
import { SecondComponent } from './Components/second/second.component';
import { FormsModule } from '@angular/forms';


//Decorator
@NgModule({
  declarations: [
    AppComponent,
    FirstComponent,
    SecondComponent
    /**
     * 1- Components
     * 2- Pipes
     * 3- Directives
     */
  ],
  imports: [
    BrowserModule,
    FormsModule
    /**
     * 4- External Module [httpClientModule - routerModule - formsModule - ReactiveFormsModule - .....]
     */
  ],
  providers: [
    /**
     * 5- Services
     */
  ],
  bootstrap: [AppComponent /**Parent Component */]
})
export class AppModule { }

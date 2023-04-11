import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UsersComponent } from './Components/users/users.component';
import { UserDetailsComponent } from './Components/user-details/user-details.component';
import { ErrorComponent } from './Components/error/error.component';
import { HeaderComponent } from './Components/header/header.component';
import {HttpClientModule} from '@angular/common/http'
import { UsersService } from './Services/users.service';
import { AddUserComponent } from './Components/add-user/add-user.component';
import { UserItemComponent } from './Components/user-item/user-item.component';

@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    UserDetailsComponent,
    ErrorComponent,
    HeaderComponent,
    AddUserComponent,
    UserItemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    /**
     * 5- Service
     */
    UsersService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./Components/home/home.component";
import {DetailsComponent} from "./Components/details/details.component";
import {AddComponent} from "./Components/add/add.component";
import {UpdateComponent} from "./Components/update/update.component";

const routes: Routes = [
  {path:"",component:HomeComponent},
  {path:"students",component:HomeComponent},
  {path:"students/:id",component:DetailsComponent},
  {path:"students/update/:id",component:UpdateComponent},
  {path:"add",component:AddComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

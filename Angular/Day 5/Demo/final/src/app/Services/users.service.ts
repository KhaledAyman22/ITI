import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


//HttpClient [Get-Post-Delete-Put-Patch]
@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private readonly myClient:HttpClient) {  }

  // private readonly URL = "https://jsonplaceholder.typicode.com/users";//API
  private readonly URL = "http://localhost:3000/users";//API
  getAllUsers(){
    return this.myClient.get(this.URL);
  }
  getUserByID(id:any){
    return this.myClient.get(this.URL+'/'+id);
  }
  AddNewUser(user:any){
    return this.myClient.post(this.URL, user);
  }

  UpdateUserByID(id:any,user:any){
    return this.myClient.put(this.URL+"/"+id, user);
  }

  DeleteUserByID(id:any){
    return this.myClient.delete(this.URL+"/"+id);
  }
}



/**
 * Service Root
 * UsersService
 * StudentsService
 * InstService
 * CoursesService
 */



//fetch(url,{method:'post', body:[{},{}]})

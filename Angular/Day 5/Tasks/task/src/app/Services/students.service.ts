import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class StudentsService {
  constructor(private readonly httpClient: HttpClient) {
  }

  private readonly url = "http://localhost:3000/students";

  GetStudents() {
    return this.httpClient.get(this.url);
  }

  GetStudent(id: any) {
    return this.httpClient.get(this.url + '/' + id);
  }

  AddStudent(user: any) {
    return this.httpClient.post(this.url, user);
  }

  UpdateStudent(id: any, user: any) {
    return this.httpClient.put(this.url + "/" + id, user);
  }

  DeleteStudent(id: any) {
    return this.httpClient.delete(this.url + "/" + id);
  }
}

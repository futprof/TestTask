import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIURl = 'http://localhost:57967/api';

  constructor(private http:HttpClient) { }

  getAllTasks(val:any):Observable<any[]>{
    return this.http.post<any[]>(this.APIURl + '/get-all-tasks', val);
  }

  changeStatus(val:any){
    return this.http.post(this.APIURl + '/change-status', val);
  }

  addTask(val:any){
    return this.http.post(this.APIURl + '/add-task', val);
  }

  getTask(id:string|null){
    return this.http.get<any>(this.APIURl + '/get-task/' + id);
  }

  updateTask(val:any){
    return this.http.post(this.APIURl + '/update-task', val);
  }

  deleteTask(id:string|null){
    return this.http.delete<any>(this.APIURl + '/del-task/' + id);
  }

  getTaskAmount(){
    return this.http.get<any>(this.APIURl + '/tasks-amount');
  }

  searchTaskByName(name:string){
    return this.http.get<any>(this.APIURl + '/search-by-name/' + name );
  }

  filterByStatus(status:boolean){
    return this.http.get<any>(this.APIURl + '/search-by-status/' + status);
  }
}

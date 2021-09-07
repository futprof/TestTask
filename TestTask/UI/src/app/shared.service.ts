import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIURl = 'http://localhost:57967/api';

  constructor(private http:HttpClient) { }

  getAllTasks():Observable<any[]>{
    return this.http.get<any[]>(this.APIURl + '/get-all-tasks');
  }

  changeStatus(val:any){
    return this.http.post(this.APIURl + '/change-status', val);
  }

  addTask(val:any){
    return this.http.post(this.APIURl + '/add-task', val);
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShareService {
  readonly APIUrl="http://localhost:57967/api";
  constructor(private http:HttpClient) { }

  getTaskList():Observable<any[]>{    
    return this.http.get<any>(this.APIUrl + 'get-all-tasks');
  }
}

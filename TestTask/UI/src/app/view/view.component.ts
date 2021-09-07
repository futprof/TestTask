import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';



@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {

  constructor(private service:SharedService) { }


  ngOnInit(): void {
    this.refreshTasksList();
  }

  taskList:any=[];

  refreshTasksList(){
    this.service.getAllTasks().subscribe(data=>{
      this.taskList = data;
    });
  }


  fieldsChange(values:any):void {
    var formData: any = new FormData();
    formData.append("id", values.currentTarget.id);
    formData.append("status", values.currentTarget.checked);
    
    this.service.changeStatus(formData).subscribe(x=>{
      console.log(x);});    

  }

}

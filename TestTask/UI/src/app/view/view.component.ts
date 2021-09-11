import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';




@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {

  constructor(private service:SharedService) { }
 
  tasksAmount:number = 0;
  page:number = 1;
  pageSize:number = 10;
  pageSizes:Array<number> = [10, 50, 100];;

  ngOnInit(): void {
    this.getTasksAmount();
    this.refreshTasksList();
    
  }

  taskList:any=[];
  taskListPoor:any=[];

  refreshTasksList(){
    var formData:any = new FormData();
    formData.append('page', this.page);
    formData.append('results', this.pageSize);

    this.service.getAllTasks(formData).subscribe(data=>{
      this.taskList = data;
      this.taskListPoor = data;
    });
  }


  statusChange(values:any):void {
    var formData: any = new FormData();
    formData.append("id", values.currentTarget.id);
    formData.append("status", values.currentTarget.checked);
    
    this.service.changeStatus(formData).subscribe(x=>{console.log(x);});    

  }

  sortResult(property:any, flag:boolean){
    this.taskList = this.taskListPoor.sort(function(a:any, b:any){
      if(flag){
        return (a[property]>b[property]) ? 1: ((a[property]<b[property]) ?-1 : 0) ;
      } else return (b[property]>a[property]) ? 1: ((b[property]<a[property]) ?-1: 0) ;
    });
  }

  sortByDate(property:any, flag:boolean){
    this.taskList = this.taskListPoor.sort(function(a:any, b:any){
      if(flag){
        return <any>new Date(b.DueDate) - <any>new Date(a.DueDate);
      } else return <any>new Date(a.DueDate) - <any>new Date(b.DueDate);
    });
  }

  getTasksAmount(){
    this.service.getTaskAmount().subscribe(data=>{
      this.tasksAmount = data.TasksAmount;
    });
  }

  handlePageChange(event: number): void {
    this.page = event;
    this.refreshTasksList();
  }

  

  handlePageSizeChange(event: any): void {
    this.pageSize = event.target.value;   
    this.refreshTasksList();
  }
}

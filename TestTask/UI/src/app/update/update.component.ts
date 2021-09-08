import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from '../shared.service';
import { FormBuilder } from '@angular/forms';
import { formatDate } from "@angular/common";

import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {

  task: any;

  checkoutForm = this.formBuilder.group({
    id: "",
    name: "",
    dueDate: ""
  });
  minDate: Date = new Date();



  constructor(
    private service: SharedService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private location: Location) {
  }

  ngOnInit(): void {

    const id = this.route.snapshot.paramMap.get('id');
    this.getTask(id);
    console.log(id);
  }


  getTask(id: string | null) {
    this.service.getTask(id).subscribe(data => {
      this.task = data;
      this.checkoutForm.patchValue({ id: this.task['Id'] });
      this.checkoutForm.patchValue({ name: this.task['Name'] });
      this.checkoutForm.patchValue({ dueDate: formatDate(this.task['DueDate'], 'yyyy-MM-dd', 'en-US') });
    });
  }

  onUpdate(){
    var formData: any = new FormData();
    formData.append("id", this.checkoutForm.value.id);
    formData.append("name", this.checkoutForm.value.name);
    formData.append("dueDate", this.checkoutForm.value.dueDate);

    this.service.updateTask(formData).subscribe(result => {
      console.log(result);
      this.checkoutForm.reset();
    });
  }

  onDelete(){
    this.service.deleteTask(this.checkoutForm.value.id).subscribe(result => {
      console.log(result);
      this.location.back();
    });
  }

}

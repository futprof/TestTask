import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';
import { FormBuilder } from '@angular/forms';


@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  checkoutForm = this.formBuilder.group({
    name: '',
    dueDate: ''
  });
  minDate: Date = new Date();

  constructor(
    private service: SharedService,
    private formBuilder: FormBuilder) {
  };  

  ngOnInit(): void {
    this.minDate = new Date();
  }

  onClickSubmit() {
    var formData: any = new FormData();
    formData.append("name", this.checkoutForm.value.name);
    formData.append("dueDate", this.checkoutForm.value.dueDate);    

    this.service.addTask(formData).subscribe(result => {
      console.log(result);
      this.checkoutForm.reset();
    });
    
  }

}

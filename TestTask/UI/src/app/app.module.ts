import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TasksComponent } from './tasks/tasks.component';
import { AddComponent } from './tasks/add/add.component';
import { ViewComponent } from './tasks/view/view.component';
import { UpdateComponent } from './tasks/update/update.component';
import { ShareService } from './share.service';

@NgModule({
  declarations: [
    AppComponent,
    TasksComponent,
    AddComponent,
    ViewComponent,
    UpdateComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [ShareService],
  bootstrap: [AppComponent]
})
export class AppModule { }

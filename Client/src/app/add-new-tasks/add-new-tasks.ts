import { Component , output, signal} from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common'; 
import {Tasks} from '../models/tasks.model';
import { eGradeLevelTesk } from '../models/tasks.model';
import { TasksService } from '../tasks-service';



@Component({
  selector: 'app-add-new-tasks',
  standalone: true,
  imports: [FormsModule, DatePipe],
  templateUrl: './add-new-tasks.html',
  styleUrl: './add-new-tasks.css',
})
export class AddNewTasks {
  tasks = signal<Partial<Tasks>>({
  name: '',
  description: '',
  status: 'InProgress',
  dueDate: new Date(),
  grade: eGradeLevelTesk.a
});
  
  close=output<void>();

  constructor(public _tasksService: TasksService,
    private router:Router,
  ){}
 

  save(){
  this._tasksService.addTasks(this.tasks() as Tasks).subscribe({
    next: () => this.goToList(),
  });
  }

  goToList(){
           this.router.navigate(["tasks-list"]);

  }
}
